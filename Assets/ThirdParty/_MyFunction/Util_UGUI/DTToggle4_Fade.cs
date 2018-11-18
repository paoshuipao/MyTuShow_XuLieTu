using System;
using System.Collections;
using DG.Tweening;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using UnityEngine;



[AddComponentMenu("我的组件/DOTween/DTToggle4_Fade")]
public class DTToggle4_Fade : MonoBehaviour
{
    public void SetFistInit()
    {
        mOneGroup.alpha = 0;
        mTwoGroup.alpha = 0;
        mThreeGroup.alpha = 0;
        mFourGroup.alpha = 0;

        GO_One.SetActive(false);
        GO_Two.SetActive(false);
        GO_Three.SetActive(false);
        GO_Four.SetActive(false);


        switch (FirstShow)
        {
            case GroupState.ONE:
                mOneGroup.alpha = 1;
                GO_One.SetActive(true);
                break;
            case GroupState.TWO:
                mTwoGroup.alpha = 1;
                GO_Two.SetActive(true);
                break;
            case GroupState.THREE:
                mThreeGroup.alpha = 1;
                GO_Three.SetActive(true);
                break;
            case GroupState.FOUR:
                mFourGroup.alpha = 1;
                GO_Four.SetActive(true);
                break;
        }

        mCurrentState = FirstShow;

    }



    public void Change2One()                  // 切换成第 1 个
    {
        if (mCurrentState == GroupState.ONE)
        {
            return;
        }
        ChangeState(GroupState.ONE);
        GO_One.SetActive(true);
        mOneGroup.DOFade(1, FadeDuration);
    }


    public void Change2Two()                  // 切换成第 2 个
    {
        if (mCurrentState == GroupState.TWO)
        {
            return;
        }
        ChangeState(GroupState.TWO);
        GO_Two.SetActive(true);
        mTwoGroup.DOFade(1, FadeDuration);
    }


    public void Change2Three()                // 切换成第 3 个
    {
        if (mCurrentState == GroupState.THREE)
        {
            return;
        }
        ChangeState(GroupState.THREE);
        GO_Three.SetActive(true);
        mThreeGroup.DOFade(1, FadeDuration);
    }



    public void Change2Four()                 // 切换成第 4 个
    {
        if (mCurrentState == GroupState.FOUR)
        {
            return;
        }
        ChangeState(GroupState.FOUR);
        GO_Four.SetActive(true);
        mFourGroup.DOFade(1, FadeDuration);
    }






    #region 私有


    public GameObject GO_One;
    public GameObject GO_Two;
    public GameObject GO_Three;
    public GameObject GO_Four;
    public GroupState FirstShow = GroupState.ONE;
    public float FadeDuration = 0.2f;        // 时间



    private CanvasGroup mOneGroup,mTwoGroup,mThreeGroup,mFourGroup;
    private GroupState mCurrentState ;

    public enum GroupState
    {
        ONE,TWO,THREE,FOUR
    }



    private void ChangeState(GroupState nextState)        // 先关闭之前的状态
    {
        if (FadeDuration>0)
        {
            switch (mCurrentState)
            {
                case GroupState.ONE:
                    Tweener t1 = mOneGroup.DOFade(0, FadeDuration);     // 变透明咯
                    t1.OnComplete(() =>
                    {
                        GO_One.SetActive(false);
                    });
                    break;
                case GroupState.TWO:
                    Tweener t2 = mTwoGroup.DOFade(0, FadeDuration);
                    t2.OnComplete(() =>
                    {
                        GO_Two.SetActive(false);
                    });
                    break;
                case GroupState.THREE:
                    Tweener t3 = mThreeGroup.DOFade(0, FadeDuration);
                    t3.OnComplete(() =>
                    {
                        GO_Three.SetActive(false);
                    });
                    break;
                case GroupState.FOUR:
                    Tweener t4 = mFourGroup.DOFade(0, FadeDuration);
                    t4.OnComplete(() =>
                    {
                        GO_Four.SetActive(false);
                    });
                    break;
            }
        }
        else
        {
            switch (mCurrentState)
            {
                case GroupState.ONE:
                    mOneGroup.alpha = 0;
                    GO_One.SetActive(false);
                    break;
                case GroupState.TWO:
                    mTwoGroup.alpha = 0;
                    GO_Two.SetActive(false);
                    break;
                case GroupState.THREE:
                    mThreeGroup.alpha = 0;
                    GO_Three.SetActive(false);
                    break;
                case GroupState.FOUR:
                    mFourGroup.alpha = 0;
                    GO_Four.SetActive(false);
                    break;
            }
        }

        mCurrentState = nextState;
    }



    #endregion

    void Awake()
    {
        if (null == GO_One || null == GO_Two || null == GO_Three || null == GO_Four)
        {
            MyLog.Red("这四个游戏对象有空的情况   " + gameObject);
            return;
        }
        mOneGroup = GO_One.AddComponent<CanvasGroup>();
        mTwoGroup = GO_Two.AddComponent<CanvasGroup>();
        mThreeGroup = GO_Three.AddComponent<CanvasGroup>();
        mFourGroup = GO_Four.AddComponent<CanvasGroup>();
        SetFistInit();



    }




    [Button("快速设置")]
    void QuitSet()
    {
        GO_One = transform.GetChild(0).gameObject;
        GO_Two = transform.GetChild(1).gameObject;
        GO_Three = transform.GetChild(2).gameObject;
        GO_Four = transform.GetChild(3).gameObject;

    }



}
