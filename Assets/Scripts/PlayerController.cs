using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] int m_playerNum = default;
    [SerializeField] List<CardData> m_hand = new List<CardData>();
    //[SerializeField] List<CardController> m_field = new List<CardController>();
    //[SerializeField] GameObject m_handObj = default;
    //[SerializeField] GameObject m_fieldObj = default;
    //[SerializeField] int m_totalPower = 0;
    [SerializeField] Button m_endButton = default;

    //get set
    //public List<CardData> Hand { get { return m_hand; } set { m_hand = value; } }

    //private void Awake()
    //{
    //    m_endButton.interactable = false;
    //}

    public void BeginTurn()
    {
        Debug.Log(m_endButton.interactable);
        m_endButton.interactable = true;
        Debug.Log(m_endButton.interactable);

        //GameManager.Instance.State = GameManager.Phase.InTurn;
        //m_hand.ForEach(x => x.ChangeActive(true));
        //m_field.ForEach(x => x.ChangeActive(true));
        Debug.Log($"{name} 開始");
        //Draw();
    }
    public void EndTurn()
    {
        m_endButton.interactable = false;
        //GameManager.Instance.State = GameManager.Phase.EndTurn;
        //m_hand.ForEach(x => x.ChangeActive(false));
        //m_field.ForEach(x => x.ChangeActive(true));
        Debug.Log($"{name} 終了");
        GameManager.Instance.EndPlayer();
    }

    //public void Draw(PlayerController target)//効果クラスに？
    //{
    //    GameManager.Instance.Deck.
    //    Debug.Log($"{name} ドロー");

    //}

    public void MoveToField(CardController card)
    {
        //card.transform.SetParent(m_fieldObj.transform);
    }
}
