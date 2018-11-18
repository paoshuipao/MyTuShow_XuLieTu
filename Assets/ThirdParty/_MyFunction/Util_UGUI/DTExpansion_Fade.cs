using System;
using DG.Tweening;
using PSPUtil.Attribute;
using Sirenix.OdinInspector;
using UnityEngine;


public enum EFadeType
{
    [Header("0 到 原来的值")]
    Zero2One,                  // 0 到 原来的值 （若原来的值为 0 不算）
    [Header("原来的值到 0 ")]
    One2Zero                    // 原来的值到 0  （若原来的值为 0 不算）
}



[AddComponentMenu("我的组件/DOTween/DTExpansion_Fade")]
[RequireComponent(typeof(CanvasGroup))]
public class DTExpansion_Fade : MonoBehaviour 
{

    public float GetTime()
    {
        return Delay + Duration;
    }


    public void PlayForward()
    {
        switch (ContrlFadeType)
        {
            case EFadeType.Zero2One:
                Zero2One();
                break;
            case EFadeType.One2Zero:
                One2Zero();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void PlayBackwards()
    {
        if (IsBackNoDalay)
        {
            isUseDalay = false;
        }
        switch (ContrlFadeType)
        {
            case EFadeType.Zero2One:
                One2Zero();
                break;
            case EFadeType.One2Zero:
                Zero2One();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        isUseDalay = true;
    }

    public void Zero2One()                // 0 -> 1
    {
        if (IsEndSetFalse)
        {
            gameObject.SetActive(true);
        }
        if (null == mCanvasGroup)
        {
            mCanvasGroup = GetComponent<CanvasGroup>();
        }
        mCanvasGroup.alpha = 0;
        Tweener tweener= mCanvasGroup.DOFade(mDefalutValue,Duration);
        if (isUseDalay)
        {
            tweener.SetDelay(Delay);
        }
        if (IsCloseAllBuuton)
        {
            tweener.OnStart(() =>
            {
                mCanvasGroup.interactable = false;
            });
            tweener.OnComplete(() =>
            {
                mCanvasGroup.interactable = true;
            });
        }

    }

    public void One2Zero()                // 1->0
    {
        if (null == mCanvasGroup)
        {
            mCanvasGroup = GetComponent<CanvasGroup>();
        }
        mCanvasGroup.alpha = mDefalutValue;
        Tweener tweener = mCanvasGroup.DOFade(0, Duration);
        if (isUseDalay)
        {
            tweener.SetDelay(Delay);
        }
        if (IsCloseAllBuuton)
        {
            tweener.OnStart(() =>
            {
                mCanvasGroup.interactable = false;
            });
            tweener.OnComplete(() =>
            {
                mCanvasGroup.interactable = true;
                if (IsEndSetFalse)
                {
                    gameObject.SetActive(false);
                }
            });
        }

    }




    [MyHead("true：一开始设置成透明")]
    public bool IsAutoSetZero;

    [HideIf("IsUseDTContrl")]
    [MyHead("一开始自动播放")]
    public bool IsAutoPlay;

#if UNITY_EDITOR
    [Indent]
    [ShowIf("IsAutoPlay")]
    [HideIf("IsUseDTContrl")]
    [MyChinaEnum]
#endif
    public EFadeType AudoFadeType = EFadeType.Zero2One;


    public float Delay = 0;

    [MinValue(0.01f)]
    public float Duration = 1;



    [MyHead("是否在动画过程禁用所有按钮")]
    public bool IsCloseAllBuuton = false;

    [MyHead("是否使用 DT_Contrl 统一控制")]
    public bool IsUseDTContrl;

    [MyHead("true : 0 时 SetActive = false")]
    public bool IsEndSetFalse;



#if UNITY_EDITOR
    [Indent]
    [ShowIf("IsUseDTContrl")]
    [MyHead("Forward 是做那个动画")]
    [MyChinaEnum]
#endif
    public EFadeType ContrlFadeType = EFadeType.Zero2One;


#if UNITY_EDITOR
    [Indent]
    [ShowIf("IsUseDTContrl")]
    [MyHead("true：在返回的动画不使用延时")]
#endif
    public bool IsBackNoDalay = false;

    void Awake()
    {
        mCanvasGroup = GetComponent<CanvasGroup>();
        mDefalutValue = mCanvasGroup.alpha;
        if (IsUseDTContrl)
        {
            IsAutoSetZero = false;
        }

    }


    void Start()
    {
        if (IsAutoSetZero)
        {
            mCanvasGroup.alpha = 0;
        }

        if (IsAutoPlay)
        {
            switch (AudoFadeType)
            {
                case EFadeType.Zero2One:
                    Zero2One();
                    break;
                case EFadeType.One2Zero:
                    One2Zero();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }

    private bool isUseDalay = true;
    private float mDefalutValue;    // 一开始默认值
    private CanvasGroup mCanvasGroup;


}
