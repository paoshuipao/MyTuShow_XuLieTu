using System;
using System.Collections;
using PSPUtil.Attribute;
using UnityEngine;
using UnityEngine.EventSystems;

public class UGUI_PointEnterAndExit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Action E_OnMouseEnter;          // 鼠标进入
    public Action E_OnMouseExit;           // 鼠标离开

    [MyHead("进入要显示的对象，可空")]
    public GameObject EnterSee;

    [MyHead("鼠标离开延迟多少才算离开")]
    public float DelayTimer;


    private bool isEndter;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEndter = true;
        if (DelayTimer>0)
        {
            StopCoroutine(StartDelay());
        }
        if (null!= E_OnMouseEnter)
        {
            E_OnMouseEnter();
        }
        if (null!= EnterSee)
        {
            EnterSee.SetActive(true);
        }
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        if (DelayTimer>0)
        {
            isEndter = false;
            StartCoroutine(StartDelay());
        }
        else
        {
            if (null != E_OnMouseExit)
            {
                E_OnMouseExit();
            }
            if (null != EnterSee)
            {
                EnterSee.SetActive(false);
            }
        }
    }


    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(DelayTimer);
        if (!isEndter)
        {
            if (null != E_OnMouseExit)
            {
                E_OnMouseExit();
            }
            if (null != EnterSee)
            {
                EnterSee.SetActive(false);
            }
        }

    }


}

