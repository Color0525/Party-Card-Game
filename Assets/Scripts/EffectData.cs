using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectData
{
    //public AbilityType m_abilityType;
    //public Condition m_condition;

    public enum Condition
    {
        ON_TURN_START,
        ON_TURN_END,
    }
    public enum Target
    {
        ALL_ENEMY_UNITS,
        ALLIED_PLAYER,
    }
    public enum AbilityType
    {
        Damaging,
        DrawCard,
    }
}
