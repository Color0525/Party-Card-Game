using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[CreateAssetMenu(fileName = "NewCardData", menuName = "CreateCardData", order = 2)]
public class CardController : MonoBehaviour// ScriptableObject
{
    //public enum ID
    //{
    //    Slime,
    //    Pixie,
    //}

    [Serializable]
    public class Effect
    {
        public CardEffect.ConditionType m_condition;
        public CardEffect.TargetType m_target;
        public CardEffect.AbilityType m_abilityType;
        public int value;
        //public UnityEvent m_conditions = new UnityEvent();
        //public UnityEvent m_ability = new UnityEvent();
    }

    //[SerializeField] bool m_isActive = false;
    //[SerializeField] ID m_id;
    [SerializeField] string m_name = null;
    //[SerializeField] Sprite m_image = null;
    [SerializeField] [Multiline(4)] string m_text = null;
    [SerializeField] int m_initialPower = 1;
    [SerializeField] int m_currentPower = 1;
    [SerializeField] List<Effect> m_effects = new List<Effect>() { new Effect() };
    //[SerializeField] List<EffectData> effectDatas = new List<EffectData>() { new EffectData() };
    [SerializeField] PlayerController m_owner;
    public PlayerController Owner => m_owner;
    //public bool IsActive { get { return m_isActive; }}
    //public int CurrentPower { get { return m_currentPower; } }

    public void Play(CardController card)
    {
        //m_owner.Play(this);
    }

    public void ChangeActive(bool newBool)
    {
        //m_isActive = newBool;
    }
}
