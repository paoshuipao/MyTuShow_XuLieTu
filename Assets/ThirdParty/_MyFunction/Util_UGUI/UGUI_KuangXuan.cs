using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class UGUI_KuangXuan : MonoBehaviour , IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    public Action<Vector2> E_OnClickDown;    // Vector2 -> 起始坐标
    public Action<Vector2> E_OnDarg;         // Vector2 -> 宽高
    public Action E_OnClickUp;               // 抬手



    private Vector2 mStartPosition,mDragPosition;
    private RectTransform rt;

    void Start()
    {
        rt = transform as RectTransform;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, eventData.position, UIRoot.Instance.UICamera, out mStartPosition);
        if (null!= E_OnClickDown)
        {
            E_OnClickDown(mStartPosition);
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, eventData.position, UIRoot.Instance.UICamera, out mDragPosition);
        Vector2 wh = new Vector2(Mathf.Abs(mStartPosition.x - mDragPosition.x),Mathf.Abs(mStartPosition.y - mDragPosition.y));
        if (null!= E_OnDarg)
        {
            E_OnDarg(wh);
        }

    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if (null!= E_OnClickUp)
        {
            E_OnClickUp();
        }
    }






}
