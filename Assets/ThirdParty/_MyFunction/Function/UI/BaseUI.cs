using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using PSPUtil;
using PSPUtil.Control;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class BaseUI    // 1. 全部都是异步生成
{

    public void PreLoad()                                        // 预加载
    {
        if (null != mUITransform || null != mUIGameObject)
        {
            return;
        }
        isCreating = true;
        string resName = GetResName();
        if (string.IsNullOrEmpty(resName))
        {
            throw new Exception("路径为空 —— 写路径啊喂");
        }
        LoadManager load = Manager.Get<LoadManager>(EF_Manager.Load);

        int sceneIndex = (int)GetSceneType();

        load.LoadUIAsyn(resName, UIRoot.Instance.UITransforms[sceneIndex], (go) =>
        {
            mUIGameObject = go;
            mUITransform = go.transform;

            isPause2Do = IsInPause2Hide();
            if (isPause2Do)
            {
                mCanvasGroup = mUIGameObject.GetComponent<CanvasGroup>();
                if (null == mCanvasGroup)
                {
                    mCanvasGroup = mUIGameObject.AddComponent<CanvasGroup>();
                }
            }
            OnStart(mUITransform);                 // 创建出来时调用 OnStart 方法 初始化
            mUIGameObject.SetActive(false);
            isCreating = false;

            SubUI[] subs = GetSubUI();
            if (null != subs && subs.Length > 0)   //获得所有子UI
            {
                subK_SubUIV = new Dictionary<Transform, SubUI>();
                foreach (SubUI subUi in subs)
                {
                    string subName = subUi.GetUIPathForRoot();
                    Transform subRoot;
                    if (subName.IsNullOrEmpty())
                    {
                         subRoot = mUITransform;
                    }
                    else
                    {
                         subRoot = mUITransform.Find(subName);
                    }
                    subUi.SetRooTransform(subRoot);
                    subUi.Start(subRoot);
                    subK_SubUIV.Add(subRoot, subUi);
                }
            }
            MyEventCenter.AddListener(GetShowEvent(), Show);    // 加入显示事件
            MyEventCenter.AddListener(GetHideEvent(), Hide);    // 加入隐藏事件
        });
    }



    public void Destroy()                                        // 销毁 
    {
        MyEventCenter.RemoveListener(GetShowEvent(), Show);    // 删除显示事件
        MyEventCenter.RemoveListener(GetHideEvent(), Hide);    // 删除隐藏事件
        if (null != subK_SubUIV)
        {
            foreach (SubUI subUi in subK_SubUIV.Values)
            {
                subUi.OnDisable();
            }
        }
        OnDisable();
        OnRemoveListener();                        // 移除事件
        if (isPause2Do)
        {
            MyEventCenter.RemoveListener(E_GameEvent.ShowPauseUI, OnShowPauseUI);
            MyEventCenter.RemoveListener(E_GameEvent.HidePauseUI, OnHidePauseUI);
        }
        OnDestroy2Do();
        Manager.Get<LoadManager>(EF_Manager.Load).Destory(mUIGameObject);
        mUITransform = null;
        mUIGameObject = null;
        isCreating = false;
    }



    public void Update()                                        // 每帧调用
    {
        if (null != mUITransform && null != mUIGameObject && mUIGameObject.activeSelf)
        {
            OnUpdate();
        }
    }



    #region 私有

    private CanvasGroup mCanvasGroup;
    private bool isPause2Do;

    private Dictionary<Transform, SubUI> subK_SubUIV;
    protected Transform mUITransform { get; private set; }
    protected GameObject mUIGameObject { get; private set; }


    private bool isCreating = false;                          // 是否在创建中

    protected abstract void OnStart(Transform root);          // 使用 root 来 Find（"组件"）、窗口初始化

    protected abstract void OnEnable();                       //显示的时候要做什么(/怎么显示)


    protected abstract void OnDisable();                      // 隐藏要做什么

    protected abstract void OnAddListener();                  //游戏事件注册

    protected abstract void OnRemoveListener();               //游戏事件注消


    protected abstract SubUI[] GetSubUI();                  // 获得子UI集合
    
    

    protected abstract E_GameEvent GetShowEvent();    // 用那个事件来响应显示 （show-> 就是激活它）


    protected abstract E_GameEvent GetHideEvent();   // 用那个事件来响应隐藏 （hide-> 只是隐藏，换场景就会自动删除）
     
    protected abstract string GetResName();          //资源路径名


    public abstract EF_Scenes GetSceneType();       // 那个场景的 UI


    private void Show()              // 直接显示即可（肯定已经产生出来了）
    {
        if (isCreating)
        {
            MyLog.Red("正在创建中，这应该不可能吧~~~~");
            return;
        }
        if (null == mUITransform || null == mUIGameObject)
        {
            MyLog.Red("预加载中没有这个UI -> 1. 核对场景  2.是否发错事件");
            return;
        }
        if (mUIGameObject.activeSelf)
        {
            MyLog.Red("已经存在的 UI —— " + mUITransform.name);
            return;
        }

        mUITransform.SetAsLastSibling();              // 最前显示
        mUITransform.localPosition = Vector3.zero;    // 坐标
        mUITransform.localScale = Vector3.one;        // 大小
        mUIGameObject.SetActive(true);
        OnEnable();                                   // 显示
        if (null!= subK_SubUIV)
        {
            foreach (SubUI subUi in subK_SubUIV.Values)
            {
                subUi.OnEnable();
            }
        }
        if (isPause2Do)
        {
            MyEventCenter.AddListener(E_GameEvent.ShowPauseUI, OnShowPauseUI);
            MyEventCenter.AddListener(E_GameEvent.HidePauseUI, OnHidePauseUI);
        }
        OnAddListener();                              // 加事件
        OnShowAnim();                                 // 动画
    }


    private void Hide()
    {
        Ctrl_Coroutine.Instance.StartCoroutine(StartHide());   // 隐藏有可能会带动画
    }

    IEnumerator StartHide()
    {
        float time = OnHideAnim();                 // 开始隐藏动画
        yield return new WaitForSeconds(time);     // 时间
        if (null != subK_SubUIV)
        {
            foreach (SubUI subUi in subK_SubUIV.Values)
            {
                subUi.OnDisable();
            }
        }
        OnDisable();                               // 不显示
        OnRemoveListener();                        // 移除事件
        if (isPause2Do)
        {
            MyEventCenter.RemoveListener(E_GameEvent.ShowPauseUI, OnShowPauseUI);
            MyEventCenter.RemoveListener(E_GameEvent.HidePauseUI, OnHidePauseUI);
        }
        mUIGameObject.SetActive(false);

    }


    #endregion

    //——————————————————可重写的方法——————————————————


    protected virtual bool IsInPause2Hide()            // 如果需要在暂停时隐藏，那就返回 true
    {
        return false;
    }

    protected virtual void OnShowPauseUI()             // 显示暂停UI时做什么
    {
        if (!isPause2Do)
        {
            MyLog.Red("应该不可能吧");
            return;
        }
        Tweener t =  mCanvasGroup.DOFade(0, 0.2f);
        t.SetUpdate(true);

    }

    protected virtual void OnHidePauseUI()             // 隐藏暂停UI时做什么
    {
        if (!isPause2Do)
        {
            MyLog.Red("应该不可能吧");
            return;
        }
        Tweener t = mCanvasGroup.DOFade(1, 0.2f);
        t.SetUpdate(true);

    }


    protected virtual void OnShowAnim()                      // 展示时要播放的动画
    {
    }
    protected virtual float OnHideAnim()
    {
        return 0;
    }
    protected virtual void OnUpdate() { }                         // 每帧调用

    protected virtual void OnDestroy2Do() { }                 //需要在 Ondestory 销毁时做，就重写


    //————————————————————————————————————


    protected Transform GetTransform(string path)
    {
        Transform t = mUITransform.Find(path);
        if (null == t)
        {
            throw new Exception(string.Format(mUITransform+ " 获取路径错误 —{0}— ", path.AddBlue()));
        }
        return t;
    }

    protected GameObject GetGameObject(string path)
    {
        return GetTransform(path).gameObject;
    }


    protected T Get<T>()
        where T : Component

    {
        return mUIGameObject.GetComponentNo2Log<T>();
    }

    protected T Get<T>(string path)
        where T : Component
    {
        T t = GetTransform(path).GetComponentNo2Log<T>();
        if (null == t)
        {
            throw new Exception(path + " 获得组件失败");
        }
        return t;
    }


    protected T[] Gets<T>(string path)
        where T : Component
    {
        return GetTransform(path).GetComponentsInChildren<T>();
    }



    //按组件添加----------------------------------------------------------------------------------

    protected void AddButtOnClick(string path, UnityAction action)
    {
        if (null != action)
        {
            Button btn = GetTransform(path).GetComponentNo2Log<Button>();
            btn.onClick.AddListener(action);
        }
    }

    protected void AddButtOnClick(Button btn, UnityAction action)
    {
        if (null != action)
        {
            btn.onClick.AddListener(action);
        }
    }

    protected void AddSliderOnValueChanged(string path, UnityAction<float> action)
    {
        if (null != action)
        {
            Slider slider = GetTransform(path).GetComponentNo2Log<Slider>();
            slider.onValueChanged.AddListener(action);
        }
    }

    protected void AddSliderOnValueChanged(Slider slider, UnityAction<float> action)
    {
        if (null != action)
        {
            slider.onValueChanged.AddListener(action);
        }
    }

    protected void AddToggleOnValueChanged(string path, UnityAction<bool> action)
    {
        if (null != action)
        {
            Toggle toggle = GetTransform(path).GetComponentNo2Log<Toggle>();
            toggle.onValueChanged.AddListener(action);
        }
    }

    protected void AddToggleOnValueChanged(Toggle toggle, UnityAction<bool> action)
    {
        if (null != action)
        {
            toggle.onValueChanged.AddListener(action);
        }
    }
    protected void AddInputOnValueChanged(string path, UnityAction<string> action)
    {
        if (null != action)
        {
            InputField input = GetTransform(path).GetComponentNo2Log<InputField>();
            input.onValueChanged.AddListener(action);
        }
    }
    protected void AddInputOnValueChanged(InputField input, UnityAction<string> action)
    {
        if (null != action)
        {
            input.onValueChanged.AddListener(action);
        }
    }


    protected void AddInputOnEndEdit(string path, UnityAction<string> action)
    {
        if (null != action)
        {
            InputField input = GetTransform(path).GetComponentNo2Log<InputField>();
            input.onEndEdit.AddListener(action);
        }
    }



    //按组件移除----------------------------------------------------------------------------------

    protected void RemoveButtOnClick(string path, UnityAction action)
    {
        if (null != action)
        {
            Button btn = GetTransform(path).GetComponentNo2Log<Button>();
            btn.onClick.RemoveListener(action);
        }
    }
    protected void RemoveButtOnClick(Button btn, UnityAction action)
    {
        if (null != action)
        {
            btn.onClick.RemoveListener(action);
        }
    }
    protected void RemoveSliderOnValueChanged(string path, UnityAction<float> action)
    {
        if (null != action)
        {
            Slider slider = GetTransform(path).GetComponentNo2Log<Slider>();
            slider.onValueChanged.RemoveListener(action);
        }
    }

    protected void RemoveSliderOnValueChanged(Slider slider, UnityAction<float> action)
    {
        if (null != action)
        {
            slider.onValueChanged.RemoveListener(action);
        }
    }

    protected void RemoveToggleOnValueChanged(string path, UnityAction<bool> action)
    {
        if (null != action)
        {
            Toggle toggle = GetTransform(path).GetComponentNo2Log<Toggle>();
            toggle.onValueChanged.RemoveListener(action);
        }
    }
    protected void RemoveInputOnValueChanged(string path, UnityAction<string> action)
    {
        if (null != action)
        {
            InputField input = GetTransform(path).GetComponentNo2Log<InputField>();
            input.onValueChanged.RemoveListener(action);
        }
    }
    protected void RemoveInputOnValueChanged(InputField input, UnityAction<string> action)
    {
        if (null != action)
        {
            input.onValueChanged.RemoveListener(action);
        }
    }
    protected void RemoveInputOnEndEdit(string path, UnityAction<string> action)
    {
        if (null != action)
        {
            InputField input = GetTransform(path).GetComponentNo2Log<InputField>();
            input.onEndEdit.RemoveListener(action);
        }
    }

}
