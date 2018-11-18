using DG.Tweening;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using UnityEngine;


[AddComponentMenu("我的组件/DOTween/DTToggle9_Fade")]
public class DTToggle9_Fade : MonoBehaviour 
{

    public void SetFistInit()
    {
        mOneGroup.alpha = 0;
        mTwoGroup.alpha = 0;
        mThreeGroup.alpha = 0;
        mFourGroup.alpha = 0;
        mFiveGroup.alpha = 0;
        mSixGroup.alpha = 0;
        mSevenGroup.alpha = 0;
        mEightGroup.alpha = 0;
        mNineGroup.alpha = 0;


        GO_One.SetActive(false);
        GO_Two.SetActive(false);
        GO_Three.SetActive(false);
        GO_Four.SetActive(false);
        GO_Five.SetActive(false);
        GO_Six.SetActive(false);
        GO_Seven.SetActive(false);
        GO_Eight.SetActive(false);
        GO_Nine.SetActive(false);


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
            case GroupState.Five:
                mFiveGroup.alpha = 1;
                GO_Five.SetActive(true);
                break;
            case GroupState.Six:
                mSixGroup.alpha = 1;
                GO_Six.SetActive(true);
                break;
            case GroupState.Seven:
                mSevenGroup.alpha = 1;
                GO_Seven.SetActive(true);
                break;
            case GroupState.Eight:
                mEightGroup.alpha = 1;
                GO_Eight.SetActive(true);
                break;
            case GroupState.Nine:
                mNineGroup.alpha = 1;
                GO_Nine.SetActive(true);
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


    public void Change2Three()                 // 切换成第 3 个
    {
        if (mCurrentState == GroupState.THREE)
        {
            return;
        }
        ChangeState(GroupState.THREE);
        GO_Three.SetActive(true);
        mThreeGroup.DOFade(1, FadeDuration);
    }



    public void Change2Four()                  // 切换成第 4 个
    {
        if (mCurrentState == GroupState.FOUR)
        {
            return;
        }
        ChangeState(GroupState.FOUR);
        GO_Four.SetActive(true);
        mFourGroup.DOFade(1, FadeDuration);
    }


    public void Change2Five()                  // 切换成第 5 个
    {
        if (mCurrentState == GroupState.Five)
        {
            return;
        }
        ChangeState(GroupState.Five);
        GO_Five.SetActive(true);
        mFiveGroup.DOFade(1, FadeDuration);
    }



    public void Change2Six()                   // 切换成第 6 个
    {
        if (mCurrentState == GroupState.Six)
        {
            return;
        }
        ChangeState(GroupState.Six);
        GO_Six.SetActive(true);
        mSixGroup.DOFade(1, FadeDuration);
    }


    public void Change2Seven()                 // 切换成第 7 个
    {
        if (mCurrentState == GroupState.Seven)
        {
            return;
        }
        ChangeState(GroupState.Seven);
        GO_Seven.SetActive(true);
        mSevenGroup.DOFade(1, FadeDuration);
    }


    public void Change2Eight()                 // 切换成第 8 个
    {
        if (mCurrentState == GroupState.Eight)
        {
            return;
        }
        ChangeState(GroupState.Eight);
        GO_Eight.SetActive(true);
        mEightGroup.DOFade(1, FadeDuration);
    }


    public void Change2Nine()                 // 切换成第 9 个
    {
        if (mCurrentState == GroupState.Nine)
        {
            return;
        }
        ChangeState(GroupState.Nine);
        GO_Nine.SetActive(true);
        mNineGroup.DOFade(1, FadeDuration);
    }




    public GameObject GO_One;
    public GameObject GO_Two;
    public GameObject GO_Three;
    public GameObject GO_Four;
    public GameObject GO_Five;
    public GameObject GO_Six;
    public GameObject GO_Seven;
    public GameObject GO_Eight;
    public GameObject GO_Nine;

    public GroupState FirstShow = GroupState.ONE;
    public float FadeDuration;        // 时间



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
                case GroupState.FOUR:
                    Tweener t4 = mFourGroup.DOFade(0, FadeDuration);
                    t4.OnComplete(() =>
                    {
                        GO_Four.SetActive(false);
                    });
                    break;
                case GroupState.Five:
                    Tweener t5 = mFiveGroup.DOFade(0, FadeDuration);
                    t5.OnComplete(() =>
                    {
                        GO_Five.SetActive(false);
                    });
                    break;
                case GroupState.Six:
                    Tweener t6 = mSixGroup.DOFade(0, FadeDuration);
                    t6.OnComplete(() =>
                    {
                        GO_Six.SetActive(false);
                    });
                    break;
                case GroupState.Seven:
                    Tweener t7 = mSevenGroup.DOFade(0, FadeDuration);
                    t7.OnComplete(() =>
                    {
                        GO_Seven.SetActive(false);
                    });
                    break;
                case GroupState.Eight:
                    Tweener t8 = mEightGroup.DOFade(0, FadeDuration);
                    t8.OnComplete(() =>
                    {
                        GO_Eight.SetActive(false);
                    });
                    break;
                case GroupState.Nine:
                    Tweener t9 = mNineGroup.DOFade(0, FadeDuration);
                    t9.OnComplete(() =>
                    {
                        GO_Nine.SetActive(false);
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
                case GroupState.Five:
                    mFiveGroup.alpha = 0;
                    GO_Five.SetActive(false);
                    break;
                case GroupState.Six:
                    mSixGroup.alpha = 0;
                    GO_Six.SetActive(false);
                    break;
                case GroupState.Seven:
                    mSevenGroup.alpha = 0;
                    GO_Seven.SetActive(false);
                    break;
                case GroupState.Eight:
                    mEightGroup.alpha = 0;
                    GO_Eight.SetActive(false);
                    break;
                case GroupState.Nine:
                    mNineGroup.alpha = 0;
                    GO_Nine.SetActive(false);
                    break;
            }
        }

        mCurrentState = nextState;
    }




    private CanvasGroup mOneGroup, mTwoGroup, mThreeGroup, mFourGroup, mFiveGroup, mSixGroup, mSevenGroup, mEightGroup, mNineGroup;
    private GroupState mCurrentState;

    public enum GroupState
    {
        ONE, TWO, THREE, FOUR, Five, Six, Seven, Eight,Nine
    }

    void Awake()
    {
        if (null == GO_One || null == GO_Two || null == GO_Three || null == GO_Four || null == GO_Five || null == GO_Six || null == GO_Seven || null == GO_Eight || null == GO_Nine)
        {
            MyLog.Red("这八个游戏对象有空的情况   " + gameObject);
            return;
        }
        mOneGroup = GO_One.AddComponent<CanvasGroup>();
        mTwoGroup = GO_Two.AddComponent<CanvasGroup>();
        mThreeGroup = GO_Three.AddComponent<CanvasGroup>();
        mFourGroup = GO_Four.AddComponent<CanvasGroup>();
        mFiveGroup = GO_Five.AddComponent<CanvasGroup>();
        mSixGroup = GO_Six.AddComponent<CanvasGroup>();
        mSevenGroup = GO_Seven.AddComponent<CanvasGroup>();
        mEightGroup = GO_Eight.AddComponent<CanvasGroup>();
        mNineGroup = GO_Nine.AddComponent<CanvasGroup>();
        SetFistInit();
    }



    [Button("快速设置")]
    void QuitSet()
    {
        GO_One = transform.GetChild(0).gameObject;
        GO_Two = transform.GetChild(1).gameObject;
        GO_Three = transform.GetChild(2).gameObject;
        GO_Four = transform.GetChild(3).gameObject;
        GO_Five = transform.GetChild(4).gameObject;
        GO_Six = transform.GetChild(5).gameObject;
        GO_Seven = transform.GetChild(6).gameObject;
        GO_Eight = transform.GetChild(7).gameObject;
        GO_Nine = transform.GetChild(8).gameObject;

    }
}
