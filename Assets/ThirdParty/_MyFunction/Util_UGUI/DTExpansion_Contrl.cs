using System.Collections.Generic;
using DG.Tweening;
using PSPUtil.StaticUtil;
using UnityEngine;

[AddComponentMenu("我的组件/DOTween/DTExpansion_Contrl")]           // DoTween 扩展3 -> 应用于下面有很多的 DoTween
public class DTExpansion_Contrl : MonoBehaviour
{


    public void DOPlay()
    {
        foreach (DOTweenAnimation doTween in l_DoTweens)
        {
            doTween.DOPlay();
        }
    }


    public void DORestart()
    {
        foreach (DOTweenAnimation doTween in l_DoTweens)
        {
            doTween.DORestart();
        }
    }


    public void DOPlayForward()
    {
        foreach (DOTweenAnimation doTween in l_DoTweens)
        {
            doTween.DOPlayForward();
        }
        foreach (DTExpansion_Fade fade in l_Fades)
        {
            fade.PlayForward();
        }
    }


    public void DOPlayBackwards()
    {
        foreach (DOTweenAnimation doTween in l_DoTweens)
        {
            doTween.DOPlayBackwards();
        }
        foreach (DTExpansion_Fade fade in l_Fades)
        {
            fade.PlayBackwards();
        }
    }



    public bool isCloseAll;
    public List<DOTweenAnimation> l_DoTweens =new List<DOTweenAnimation>();
    public List<DTExpansion_Fade> l_Fades = new List<DTExpansion_Fade>();






    public void DoReset()                 // 用于刷新下 控制的 DOTweenAnimation
    {
        l_DoTweens.Clear();
        DOTweenAnimation[] doTweens = GetComponentsInChildren<DOTweenAnimation>();
        foreach (DOTweenAnimation doTween in doTweens)
        {
            if (doTween.isUseDTContrl)
            {
                l_DoTweens.Add(doTween);
            }
        }
        l_Fades.Clear();
        DTExpansion_Fade[] fades = GetComponentsInChildren<DTExpansion_Fade>();
        foreach (DTExpansion_Fade fade in fades)
        {
            if (fade.IsUseDTContrl)
            {
                l_Fades.Add(fade);
            }
        }

    }



    void Reset()
    {
        DoReset();

    }


    void Awake()
    {

        if ((l_DoTweens.Count+ l_Fades .Count)< 2)
        {
            MyLog.Red("少过 2 个 DOTweenAnimation，加这个有什么意义？");
        }


    }


    public bool isAutoStart;


    void Start()
    {
        if (isAutoStart)
        {
            DOPlayForward();
        }

    }


}
