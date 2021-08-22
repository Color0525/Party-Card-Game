using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardMove : MonoBehaviour, IDragHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler// IPointerUpHandler
{
    [SerializeField] string m_fieldTagName = "FieldTag";
    [SerializeField] GameObject m_dummyPlefab = null;//リソースからにする
    //CardInfo m_card = null;
    Image m_cardImage = null;
    RectTransform m_dummyRectTransform = null;

    /// <summary>テーブルオブジェクト（"TableTag" が付いている UI オブジェクト）</summary>
    //GameObject m_table = null;
    /// <summary>このオブジェクトの Rect Transform</summary>
    //RectTransform m_rectTransform = null;
    ///// <summary>デッキの外に置けるかどうかの設定</summary>
    //[SerializeField] bool m_canPutOutOfDeck = false;
    /// <summary>動かす前の位置</summary>
    Vector2 m_originDeckPos;

    void Start()
    {
        //m_card = GetComponent<CardInfo>();
        m_cardImage = GetComponent<Image>();
        //m_rectTransform = GetComponent<RectTransform>();
        //m_table = GameObject.FindGameObjectWithTag("TableTag");
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        string message = $"OnPointerDown: {this.name}: ";
        var currentDeck = GetCurrentDeck(eventData);

        if (currentDeck)
        {
            message += $"マウスポインタは {currentDeck.name} の上にあります";
        }
        else
        {
            message += "マウスポインタはデッキの上にありません";
        }
        Debug.Log(message);
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"OnBeginDrag: {this.name}");

        m_originDeckPos = this.transform.localPosition;//.parent;
        m_cardImage.color = Color.clear;

        GameObject dummy = Instantiate(m_dummyPlefab, this.transform.root);
        dummy.GetComponent<Image>().sprite = m_cardImage.sprite;
        m_dummyRectTransform = dummy.GetComponent<RectTransform>();
        m_dummyRectTransform.position = eventData.position;


        //this.transform.SetParent(m_table.transform);
        //this.transform.SetAsLastSibling();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        m_dummyRectTransform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        m_cardImage.color = Color.white;
        Destroy(m_dummyRectTransform.gameObject);
        string message = $"OnEndDrag: {this.name}: ";
        var currentDeck = GetCurrentDeck(eventData);

        if (currentDeck)
        {
            this.transform.SetParent(currentDeck.transform);
            GameManager.Instance.Play(GetComponent<CardInfo>());
        }
        else// if (!m_canPutOutOfDeck)
        {
            this.transform.localPosition = m_originDeckPos;//.SetParent(m_originDeck);
        }

        Debug.Log(message);
    }

    /// <summary>
    /// マウスカーソルが現在どのデッキの上にあるかを返す。デッキとは "TableTag" がタグ付けされた GameObject のこと。
    /// なお、デッキは UI オブジェクトつまり Rect Transform コンポーネントがアタッチされたオブジェクトである必要がある。
    /// </summary>
    /// <param name="eventData">PointerEventData 型の引数。マウス操作の情報が入っている。</param>
    /// <returns></returns>
    GameObject GetCurrentDeck(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results); // マウスポインタの位置上に重なっている UI を全て results に取得する（※）
        var result = results.Where(x => x.gameObject.CompareTag(m_fieldTagName)).FirstOrDefault();    // results に入っているオブジェクトのうち、DeckTag が付いているオブジェクトを一つ取得する
        return result.gameObject;   // 結果の GameObject を返す

        //（※）EventSystem のインターフェイスを使った通常のプログラミングだと、オブジェクトが重なっている場合は「一番上に描画されているオブジェクト」しかマウスの動きを検出できない。
        // そのため、デッキの上にカードが重なっている場合、デッキ側でマウスの動きを検出できない。そのため EventSystem.current.RaycastAll を使う必要があった。
        // ちなみに Hierarchy 上で下にある UI オブジェクトが前面に描画される。
    }
}
