using System.Collections;
using DG.Tweening;
using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using UnityEngine;


[AddComponentMenu("我的组件/DOTween/DTToggle2_Fade")]
public class DTToggle2_Fade : MonoBehaviour
{

    public bool isFirsting                // 是否当前是第1
    {
        get { return GO_One.activeSelf; }
    }


    public void SetFistInit()
    {
        isFirst = true;
        mFirstGroup.alpha = 1;
        mChangeGroup.alpha = 0;
        GO_One.SetActive(true);
        GO_Two.SetActive(false);
    }



    public void Change2One()              // 切换成第1个
    {
        if (isFirst)
        {
            return;
        }
        isFirst = true;
        if (GO_One.activeSelf && mFirstGroup.alpha ==1 && mChangeGroup.alpha==0)  // 已经是这样了，那就没必要继承下面啊
        {
            return;
        }
        GO_One.SetActive(true);
        Tweener t1 = mFirstGroup.DOFade(1, FadeDuration);
        Tweener t2 = mChangeGroup.DOFade(0, FadeDuration);
        if (isPauseGoHead)
        {
            t1.SetUpdate(true);
            t2.SetUpdate(true);
        }
        t2.OnComplete(() =>
        {
            GO_Two.SetActive(false);
        });
    }


    public void Change2Two()             // 切换成第2个
    {
        if (!isFirst)
        {
            return;
        }
        isFirst = false;
        if (GO_Two.activeSelf && mFirstGroup.alpha == 0 && mChangeGroup.alpha == 1)  // 已经是这样了，那就没必要继承下面啊
        {
            return;
        }
        GO_Two.SetActive(true);
        Tweener t1 = mFirstGroup.DOFade(0, FadeDuration);
        Tweener t2 = mChangeGroup.DOFade(1, FadeDuration);
        if (isPauseGoHead)
        {
            t1.SetUpdate(true);
            t2.SetUpdate(true);
        }
        t2.OnComplete(() =>
        {
            GO_One.SetActive(false);
        });
    }


    #region 私有



    public GameObject GO_One;         // 一开始显示的那个
    public GameObject GO_Two;        // 第2个切换的

    public float FadeDuration = 0.2f;        // 时间

    [MyHead("true :暂停不会影响")]
    public bool isPauseGoHead;


    private bool isFirst = true;

    private CanvasGroup mFirstGroup,mChangeGroup;
    #endregion





    void Awake()
    {
        if (null == GO_One || null == GO_Two)
        {
            MyLog.Red("这两个游戏对象为空，还没有拖进来啊   " + gameObject);
            return;
        }
        mFirstGroup = GO_One.AddComponent<CanvasGroup>();
        mChangeGroup = GO_Two.AddComponent<CanvasGroup>();
        SetFistInit();
    }


}
