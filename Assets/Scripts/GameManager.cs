using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    static public GameManager Instance => m_instance; 

    [SerializeField] List<CardInfo> m_playerFieldcards = new List<CardInfo>();
    //List<CardInfo> m_enemyFieldcards = new List<CardInfo>();
    [SerializeField] int m_totalPower = 0;

    private void Awake()
    {
        m_instance = this;
    }

    public void Play(CardInfo card)
    {
        m_playerFieldcards.Add(card);
        UpdateTotalPower();
    }

    public void UpdateTotalPower()
    {
        int total = 0;
        m_playerFieldcards.ForEach(x => total += x.m_power);
        m_totalPower = total;
        Debug.Log(m_totalPower);
        //return _totalPower;
    } 
}
