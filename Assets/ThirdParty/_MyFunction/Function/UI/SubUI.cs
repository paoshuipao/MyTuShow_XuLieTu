using System;
using PSPUtil.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class SubUI        // 每个大 UI 下的 子UI
{

    #region 私有

    public abstract string GetUIPathForRoot();           // 以那个 游戏对象 作为根UI

    protected abstract void OnStart(Transform root);         // 使用 root 来 Find（"组件"）、窗口初始化
    public abstract void OnEnable();                       //显示的时候要做什么(/怎么显示)

    public abstract void OnDisable();                      // 隐藏要做什么



    public void Start(Transform root)
    {
        OnStart(root);
    }



    public void SetRooTransform(Transform root)
    {
        mUITransform = root;
        mUIGameObject = mUITransform.gameObject;
    }


    protected Transform mUITransform { get; private set; }
    protected GameObject mUIGameObject { get; private set; }

    #endregion



    protected Transform GetTransform(string path)
    {
        Transform t = mUITransform.Find(path);
        if (null == t)
        {
            throw new Exception(string.Format(mUITransform + " 获取路径错误 —{0}— ", path.AddBlue()));
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
        return GetTransform(path).GetComponentsInChildren<T>(true);
    }




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



    protected void AddInputOnEndEdit(InputField input, UnityAction<string> action)
    {
        if (null != action)
        {
            input.onEndEdit.AddListener(action);
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



    protected void AddScrollbarValueChange(string path,UnityAction<float> action)
    {
        if (null != action)
        {
            Scrollbar scrollbar = GetTransform(path).GetComponentNo2Log<Scrollbar>();
            scrollbar.onValueChanged.AddListener(action);
        }
    }


    //—————————————————— ——————————————————


    protected Transform InstantiateMoBan(GameObject go,Transform parent,string goName ="",bool isAutoPosition =false)
    {
        GameObject res = UnityEngine.Object.Instantiate<GameObject>(go, parent);
        if (!string.IsNullOrEmpty(goName))
        {
            res.name = goName;
        }
        res.SetActive(true);
        Transform t = res.transform;
        t.localScale =Vector3.one;
        if (!isAutoPosition)
        {
            t.localPosition = Vector3.zero;
        }

        return t;

    }





}
