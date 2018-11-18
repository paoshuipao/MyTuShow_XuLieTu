using System;
using System.Collections;
using PSPUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public abstract class BaseUI_Mono : MonoBehaviour       // 这种 UI 是直接放在场景中,且放在 UIRoot的最前面
{

    void Start()
    {
        transform.SetParent(UIRoot.Instance.FirstUiTransform);
        RectTransform viewRect = transform as RectTransform;
        if (null == viewRect)
        {
            MyLog.Red("不是 UI ？");
            return;
        }
        viewRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
        viewRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
        viewRect.anchorMin = Vector2.zero;
        viewRect.anchorMax = Vector2.one;

        MyEventCenter.AddListener(GetShowEvent(), E_OnShow);
        MyEventCenter.AddListener(GetHideEvent(), E_OnHide);
        OnAddListener();

        OnStart();
        gameObject.SetActive(false);
    }



    void Update()
    {
        OnUpdate();
    }


    void OnDestroy()
    {
        OnRemoveListener();
        MyEventCenter.RemoveListener(GetShowEvent(), E_OnShow);
        MyEventCenter.RemoveListener(GetHideEvent(), E_OnHide);
    }


    protected abstract void OnStart();

    protected virtual void OnUpdate()
    {

    }


    protected abstract void OnShow();                              //显示的时候要做什么(怎么显示)

    protected abstract void OnHideAnim();                         //隐藏的时候要做什么


    protected abstract void OnAddListener();                       //游戏事件注册

    protected abstract void OnRemoveListener();                    //游戏事件注消


    protected abstract E_GameEvent GetShowEvent();                 // 用那个事件来响应显示

    protected abstract E_GameEvent GetHideEvent();                 // 用那个事件来响应隐藏


    private void E_OnShow()
    {
        gameObject.SetActive(true);
        transform.localPosition =Vector3.zero;
        transform.localScale = Vector3.one;
        OnShow();
    }

    private void E_OnHide()                   // 隐藏操作需要自己控制
    {
        OnHideAnim();
    }



    //————————————————————————————————————



    protected Transform GetTransform(string path)
    {
        Transform t = transform.Find(path);
        if (null == t)
        {
            throw new Exception("查找 Transform 失败 —— "+path);
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
        return transform.GetComponentNo2Log<T>();
    }

    protected T Get<T>(string path)
        where T : Component
    {
        return GetTransform(path).GetComponentNo2Log<T>();
    }


    protected GameObject InstantiateMoBan(GameObject go,Transform parent)
    {
        GameObject tmpGo = Instantiate(go, parent);
        tmpGo.transform.localScale = Vector3.one;
        tmpGo.transform.localPosition = Vector3.zero;
        tmpGo.SetActive(true);
        return tmpGo;

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
        slider.onValueChanged.AddListener(action);
    }
    protected void AddToggleOnValueChanged(Toggle toggle, UnityAction<bool> action)
    {
        if (null != action)
        {
            toggle.onValueChanged.AddListener(action);
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


}
