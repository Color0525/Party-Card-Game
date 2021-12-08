using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    static public GameManager Instance => m_instance;
    private void Awake() => m_instance = this;


    //public enum Phase
    //{
    //    BeforeBattle,
    //    BeginTurn,
    //    InTurn,
    //    EndTurn,
    //    AfterBattle,
    //}

    //[SerializeField] Phase m_state = Phase.BeginTurn;
    int m_currentNum = 0;

    //public Phase State { get { return m_state; } set { m_state = value; } }


    [SerializeField] List<CardData> m_deck = new List<CardData>();
    //public List<CardData> Deck => m_deck;

    PlayerManager m_playerM = default;

    private void Start()
    {
        m_playerM = GetComponent<PlayerManager>();

        BeginCurrentPlayer();
    }


    void BeginCurrentPlayer()
    {
        m_playerM.AllPlayers[m_currentNum].BeginTurn();
        Debug.Log($"P{m_currentNum}");
    }
    public void EndPlayer()
    {
        BeginNextPlayer();
    }
    void BeginNextPlayer()
    {
        m_currentNum++;
        if (m_playerM.AllPlayers.Count <= m_currentNum) m_currentNum = 0;

        BeginCurrentPlayer();
    }

   

    public void UpdateTotalPower()
    {
        //m_totalPower = 0;
        //m_playerFieldcards.ForEach(x => m_totalPower += x.CurrentPower);
        //Debug.Log(m_totalPower);
        //return _totalPower;
    } 
}
