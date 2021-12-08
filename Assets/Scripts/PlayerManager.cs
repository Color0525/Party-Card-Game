using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //static PlayerManager m_instance;
    //static public PlayerManager Instance => m_instance;
    //private void Awake() => m_instance = this;


    [SerializeField] List<PlayerController> m_allPlayers = new List<PlayerController>();
    public List<PlayerController> AllPlayers => m_allPlayers;
    

    //[SerializeField] List<CardController> m_playerFieldcards = new List<CardController>();
    //List<CardInfo> m_enemyFieldcards = new List<CardInfo>();
    
    
}
