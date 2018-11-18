using System.Collections;
using DG.Tweening;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using UnityEngine;



[AddComponentMenu("我的组件/DOTween/DTToggle3_Fade")]
public class DTToggle3_Fade : MonoBehaviour 
{
    public void SetFistInit()
    {
        mOneGroup.alpha = 0;
        mTwoGroup.alpha = 0;
        mThreeGroup.alpha = 0;

        GO_One.SetActive(false);
        GO_Two.SetActive(false);
        GO_Three.SetActive(false);


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
        }

        mCurrentState = FirstShow;

    }


    public bool IsFirsting
    {
        get { return mCurrentState == GroupState.ONE; }
    }

    public bool IsSecond
    {
        get { return mCurrentState == GroupState.TWO; }
    }

    public bool IsThree
    {
        get { return mCurrentState == GroupState.THREE; }
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





    public GameObject GO_One;
    public GameObject GO_Two;
    public GameObject GO_Three;




    public GroupState FirstShow = GroupState.ONE;
    public float FadeDuration = 0.2f;        // 时间



    private CanvasGroup mOneGroup, mTwoGroup, mThreeGroup;
    private GroupState mCurrentState;

    public enum GroupState
    {
        ONE, TWO, THREE
    }



    private void ChangeState(GroupState nextState)        // 先关闭之前的状态
    {
        if (FadeDuration > 0)
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
            }
        }

        mCurrentState = nextState;
    }




    void Awake()
    {
        if (null == GO_One || null == GO_Two || null == GO_Three)
        {
            MyLog.Red("这三个游戏对象有空的情况   " + gameObject);
            return;
        }
        mOneGroup = GO_One.AddComponent<CanvasGroup>();
        mTwoGroup = GO_Two.AddComponent<CanvasGroup>();
        mThreeGroup = GO_Three.AddComponent<CanvasGroup>();
        SetFistInit();
    }




    [Button("快速设置")]
    void QuitSet()
    {
        GO_One = transform.GetChild(0).gameObject;
        GO_Two = transform.GetChild(1).gameObject;
        GO_Three = transform.GetChild(2).gameObject;

    }



}
