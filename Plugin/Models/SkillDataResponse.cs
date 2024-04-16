﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace SkillsExtended.Models
{
    public struct SkillDataResponse
    {
        public MedicalSkillData MedicalSkills;

        public WeaponSkillData UsecRifleSkill;

        public WeaponSkillData BearRifleSkill;

        public LockPickingData LockPickingSkill;

        public UsecTacticsData UsecTacticsSkill;

        public BearRawPowerData BearRawPowerSkill;
    }

    public struct MedicalSkillData
    {
        [JsonProperty("MEDKIT_HP_BONUS")]
        public float MedkitHpBonus;

        [JsonProperty("MEDKIT_HP_BONUS_ELITE")]
        public float MedkitHpBonusElite;

        [JsonProperty("MEDICAL_SPEED_BONUS")]
        public float MedicalSpeedBonus;

        [JsonProperty("MEDICAL_SPEED_BONUS_ELITE")]
        public float MedicalSpeedBonusElite;
    }

    public struct WeaponSkillData
    {
        [JsonProperty("WEAPON_PROF_XP")]
        public float WeaponProfXp;

        [JsonProperty("ERGO_MOD")]
        public float ErgoMod;

        [JsonProperty("ERGO_MOD_ELITE")]
        public float ErgoModElite;

        [JsonProperty("RECOIL_REDUCTION")]
        public float RecoilReduction;

        [JsonProperty("RECOIL_REDUCTION_ELITE")]
        public float RecoilReductionElite;
    }

    public struct LockPickingData
    {
        [JsonProperty("BASE_PICK_TIME")]
        public float BasePickTime;

        [JsonProperty("PICK_TIME_REDUCTION")]
        public float PickTimeReduction;

        [JsonProperty("PICK_TIME_REDUCTION_ELITE")]
        public float PickTimeReductionElite;

        [JsonProperty("BASE_PICK_CHANCE")]
        public float BasePickChance;

        [JsonProperty("BONUS_CHANCE_PER_LEVEL")]
        public float BonusChancePerLevel;

        [JsonProperty("BONUS_CHANCE_PER_LEVEL_ELITE")]
        public float BonusChancePerLevelElite;

        [JsonProperty("DOOR_PICK_LEVELS")]
        public DoorPickLevels DoorPickLevels;
    }

    // DoorId : level to pick the lock
    public struct DoorPickLevels
    {
        public Dictionary<string, int> Factory;
        public Dictionary<string, int> Woods;
        public Dictionary<string, int> Customs;
        public Dictionary<string, int> Interchange;
        public Dictionary<string, int> Reserve;
        public Dictionary<string, int> Shoreline;
        public Dictionary<string, int> Labs;
        public Dictionary<string, int> Lighthouse;
        public Dictionary<string, int> Streets;
        public Dictionary<string, int> GroundZero;
    }

    public struct UsecTacticsData
    {
        [JsonProperty("USEC_INERTIA_RED_BONUS")]
        public float InertiaRedBonus;

        [JsonProperty("USEC_INERTIA_RED_BONUS_ELITE")]
        public float InertiaRedBonusElite;
    }

    public struct BearRawPowerData
    {
        [JsonProperty("BEAR_POWER_HP_BONUS")]
        public float HPBonus;

        [JsonProperty("BEAR_POWER_HP_BONUS_ELITE")]
        public float HPBonusElite;

        [JsonProperty("BEAR_POWER_UPDATE_TIME")]
        public double UpdateTime;
    }
}