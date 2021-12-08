using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardMove : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler// IPointerUpHandler, IPointerDownHandler
{
    //[SerializeField] string m_fieldTagName = "Field";
    //[SerializeField] string m_handTagName = "Hand";
    [SerializeField] GameObject m_dummyPlefab = null;//リソースからにする
    [SerializeField] Image m_originImage = default;
    GameObject m_originHand = default;
    Vector2 m_originPos = default;
    RectTransform m_dummyRectTransform = default;
    //CardController m_cardCon = default;
    bool m_available = false;
    //bool m_select = false;

    void Start()
    {
        //m_image = GetComponent<Image>();
        //m_cardCon = GetComponent<CardController>();
    }

    //void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    //{
    //    string message = $"OnPointerDown: {this.name}: ";
    //    var currentDeck = GetCurrentDeck(eventData);

    //    if (currentDeck)
    //    {
    //        message += $"マウスポインタは {currentDeck.name} の上にあります";
    //    }
    //    else
    //    {
    //        message += "マウスポインタはデッキの上にありません";
    //    }
    //    Debug.Log(message);
    //}

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //if (m_cardCon.o && GetCurrentDeck(eventData, m_handTagName)) m_select = true;//手札の上なら

        if (!m_available) return;
        //if (!m_canMove) return;

        //本体を透明にしてダミーを生成//ダミーは表示非表示にする？
        m_originHand = this.transform.parent.gameObject;
        m_originPos = this.transform.localPosition;//.parent;
        m_originImage.color = Color.clear;

        GameObject dummy = Instantiate(m_dummyPlefab, this.transform.root);
        dummy.GetComponent<Image>().sprite = m_originImage.sprite;
        m_dummyRectTransform = dummy.GetComponent<RectTransform>();
        m_dummyRectTransform.position = eventData.position;


        //this.transform.SetParent(m_table.transform);
        //this.transform.SetAsLastSibling();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!m_available) return;
        //if (!m_canMove) return;

        //ダミーをドラッグ
        m_dummyRectTransform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (!m_available) return;
        //if (!m_canMove) return;

        //透明度やダミーを戻す
        m_originImage.color = Color.white;
        Destroy(m_dummyRectTransform.gameObject);

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results); // マウスポインタの位置上に重なっている UI を全て results に取得する（※）
        //var currentDeck = GetCurrentDeck(eventData, m_handTagName);
        //if (!currentDeck || currentDeck != m_originPanel)
        if (!results.Any(x => x.gameObject == m_originHand))　//その中に元の手札がないなら
        {
            //this.transform.SetParent(currentDeck.transform);//Pl
            CardController cc = GetComponent<CardController>();
            cc.Owner.MoveToField(cc);
        }
        //else// if (!m_canPutOutOfDeck)
        //{
        //    this.transform.localPosition = m_originPos;//.SetParent(m_originDeck);
        //}
        //m_select = false;
    }

    ///// <summary>
    ///// マウスカーソルが現在指定tagNameオブジェクト上にあるならそのオブジェクトを返す。
    ///// なお、デッキは UI オブジェクトつまり Rect Transform コンポーネントがアタッチされたオブジェクトである必要がある。
    ///// </summary>
    ///// <param name="eventData">PointerEventData 型の引数。マウス操作の情報が入っている。</param>
    ///// <returns></returns>
    //GameObject GetCurrentDeck(PointerEventData eventData, string tagName)
    //{
    //    var results = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll(eventData, results); // マウスポインタの位置上に重なっている UI を全て results に取得する（※）
    //    var result = results.Where(x => x.gameObject.CompareTag(tagName)).FirstOrDefault();    // results に入っているオブジェクトのうち、DeckTag が付いているオブジェクトを一つ取得する
    //    return result.gameObject;   // 結果の GameObject を返す

    //    //（※）EventSystem のインターフェイスを使った通常のプログラミングだと、オブジェクトが重なっている場合は「一番上に描画されているオブジェクト」しかマウスの動きを検出できない。
    //    // そのため、デッキの上にカードが重なっている場合、デッキ側でマウスの動きを検出できない。そのため EventSystem.current.RaycastAll を使う必要があった。
    //    // ちなみに Hierarchy 上で下にある UI オブジェクトが前面に描画される。
    //}
}
