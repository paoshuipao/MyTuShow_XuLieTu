using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderEvent : MonoBehaviour , IInitializePotentialDragHandler, IDragHandler, IEndDragHandler
{

    public Action E_OnClick;           // 开始点击
    public Action E_OnDrag;            // 拖拽
    public Action E_OnDragEnd;         // 拖拽结束 



    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if (null!= E_OnClick)
        {
            E_OnClick();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (null != E_OnDrag)
        {
            E_OnDrag();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (null != E_OnDragEnd)
        {
            E_OnDragEnd();
        }
    }




}
