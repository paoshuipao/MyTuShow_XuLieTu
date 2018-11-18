using DG.Tweening;
using PSPUtil.StaticUtil;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class DTExpansion_Fade_Easy : MonoBehaviour 
{


    public float Duration =0.2f;
//    public float Dalay;

    public float EndValue;

    public bool IsFrom=false;



    private float firstValue;

    public void DOPlayBackwards()
    {
        if (IsFrom)         // 从 end值到 first值
        {
            CanvasGroup.DOFade(EndValue, Duration);
        }
        else
        {
            CanvasGroup.DOFade(firstValue, Duration);

        }
    }


    public void DOPlayForward()
    {
        if (IsFrom)         // 从 end值到 first值
        {
            CanvasGroup.DOFade(firstValue, Duration);
        }
        else
        {
            CanvasGroup.DOFade(EndValue, Duration);

        }

    }

    private CanvasGroup CanvasGroup
    {
        get
        {
            if (null == mCanvasGroup)
            {
                mCanvasGroup = GetComponent<CanvasGroup>();
            }
            return mCanvasGroup;
        }
    }

    public float GetCurrentAlpha
    {
        get { return CanvasGroup.alpha; }
    }


    void Awake()
    {

        firstValue = CanvasGroup.alpha;

        if (IsFrom)
        {
            CanvasGroup.alpha = EndValue;
        }
    }


    private CanvasGroup mCanvasGroup;


}
