using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardEffect
{
    //public AbilityType m_abilityType;
    //public Condition m_condition;

    ////[SerializeField] TargetType _targetType = TargetType.None;
    ////[SerializeField] int Priority = 0;

    ////[SerializeField, SerializeReference, SubclassSelector]
    ////List<ICondition> _condition = new List<ICondition>();

    ////[SerializeField, SerializeReference, SubclassSelector]
    ////IAbility _ability = null;

    public enum ConditionType
    {
        ON_TURN_START,
        ON_TURN_END,
    }
    public enum TimingType
    {
        
    }
    public enum TargetType
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
