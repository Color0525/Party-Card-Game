using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[CreateAssetMenu(fileName = "NewCardData", menuName = "CreateCardData", order = 2)]
public class CardData : MonoBehaviour// ScriptableObject
{
    //public enum ID
    //{
    //    Slime,
    //    Pixie,
    //}

    [Serializable]
    public class Effect
    {
        public EffectData.Condition m_condition;
        public EffectData.Target m_target;
        public EffectData.AbilityType m_abilityType;
        public int value;

        

        //public UnityEvent m_conditions = new UnityEvent();
        //public UnityEvent m_ability = new UnityEvent();
    }

    //[SerializeField] ID m_id;
    [SerializeField] string m_name = null;
    //[SerializeField] Sprite m_image = null;
    [SerializeField] [Multiline(4)] string m_text = null;
    [SerializeField] int m_initialPower = 1;
    [SerializeField] List<Effect> m_effects = new List<Effect>() { new Effect() };
    //[SerializeField] List<EffectData> effectDatas = new List<EffectData>() { new EffectData() };

    [SerializeField] int m_currentPower;
    //[SerializeField] PlayerController m_owner;
}
