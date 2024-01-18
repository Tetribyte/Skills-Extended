﻿using EFT;
using System;
using SkillRedux;
using EFT.HealthSystem;
using System.Reflection;
using EFT.InventoryLogic;
using Aki.Reflection.Patching;
using SkillRedux.Helpers;
using HarmonyLib;
using EFT.UI.DragAndDrop;

namespace Skill_Redux.Patches
{
    internal class FirstAidSkillPatches
    {
        private static bool _isSurgery = false;

        internal class HealthControllerMedEffectPatch : ModulePatch
        {
            protected override MethodBase GetTargetMethod() =>
                typeof(ActiveHealthController).GetMethod("DoMedEffect");

            [PatchPrefix]
            public static void Prefix(ref Item item)
            {
                // We dont want to alter surgery with the first aid skill
                if (item is MedsClass meds)
                {
                    // Surgery item, dont adjust time
                    if (meds.HealthEffectsComponent.AffectsAny(EDamageEffectType.DestroyedPart))
                    {
                        Plugin.Log.LogDebug("Surgery effect, skipping time modification");
                        _isSurgery = true;
                    }
                }
                _isSurgery = false;
            }
        }

        internal class HealthEffectComponentPatch : ModulePatch
        {
            protected override MethodBase GetTargetMethod() =>
                typeof(HealthEffectsComponent).GetMethod("UseTimeFor");

            [PatchPostfix]
            public static void Postfix(ref float __result)
            {
                if (!_isSurgery)
                {
                    Plugin.FAScript.ApplyExp();
                    __result = __result * Plugin.FAScript.CalculateSpeedBonus();
                    Plugin.Log.LogDebug($"First aid time {__result} seconds");
                    return;
                }
                _isSurgery = false;
            }
        }

        internal class FirstAidEnablePatch : ModulePatch
        {
            protected override MethodBase GetTargetMethod() =>
                typeof(SkillManager).GetMethod("method_3", BindingFlags.NonPublic | BindingFlags.Instance);

            [PatchPostfix]
            public static void Postfix(SkillManager __instance)
            {
                var skillType = Utils.GetSkillType();

                AccessTools.Field(skillType, "Locked").SetValue(__instance.FirstAid, false);
            }
        }
    }
}
