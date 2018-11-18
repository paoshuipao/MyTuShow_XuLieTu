using System;
using System.Reflection;
using DG.Tweening;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using UnityEngine;

public enum EValueType
{
    INT,
    FLOAT,
    VECTOR2,
    VECTOR3,
    COLOR,
}

public enum EIsProperty
{
    Property,
    Field
}


[AddComponentMenu("我的组件/DOTween/DTExpansion_Value")]    // DoTween 扩展1 -> 应用于基础类型 int float Vector Color
public class DTExpansion_Value : MonoBehaviour
{
    public string ComponentName;             // 组件名
    public string PropertyName;              // 属性或字段名

    [EnumToggleButtons]
    public EIsProperty isProperty;           // 是属性还是字段


    public float Duration=1;                 // 持续时间


    [EnumToggleButtons] 
    public EValueType TO;                    // 达到的目标

    [Indent]
    [ShowIf("TO", EValueType.INT)]
    public int IntValue;

    [Indent]
    [ShowIf("TO", EValueType.FLOAT)]
    public float FloatValue;

    [Indent]
    [ShowIf("TO", EValueType.VECTOR2)]
    public Vector2 Vector2Value;

    [Indent]
    [ShowIf("TO", EValueType.VECTOR3)]
    public Vector3 Vector3Value;


    [Indent]
    [ShowIf("TO", EValueType.COLOR)]
    public Color ColorValue;


    void Start ()
    {
        CheckIsOk((info,c) =>
        {
            DOTween.To(()=>(int)info.GetValue(c,null),x=> info.SetValue(c,x,null), IntValue, Duration);
        }, (info, c) =>
        {
            DOTween.To(() => (float)info.GetValue(c, null), x => info.SetValue(c, x, null), FloatValue, Duration);
        }, (info, c) =>
        {
            DOTween.To(() => ((Vector2)info.GetValue(c, null)), x => info.SetValue(c, x, null), Vector2Value, Duration);
        }, (info, c) =>
        {
            DOTween.To(() => (Vector3)info.GetValue(c, null), x => info.SetValue(c, x, null), Vector3Value, Duration);
        }, (info, c) =>
        {
            DOTween.To(() => (Color)info.GetValue(c, null), x => info.SetValue(c, x, null), ColorValue, Duration);
        }, (info, c) =>
        {
            DOTween.To(() => (int)info.GetValue(c), x => info.SetValue(c, x), IntValue, Duration);
        }, (info, c) =>
        {
            DOTween.To(() => (float)info.GetValue(c), x => info.SetValue(c, x), FloatValue, Duration);
        }, (info, c) =>
        {
            DOTween.To(() => ((Vector2)info.GetValue(c)), x => info.SetValue(c, x), Vector2Value, Duration);
        }, (info, c) =>
        {
            DOTween.To(() => (Vector3)info.GetValue(c), x => info.SetValue(c, x), Vector3Value, Duration);
        }, (info, c) =>
        {
            DOTween.To(() => (Color)info.GetValue(c), x => info.SetValue(c, x), ColorValue, Duration);
        });
    }


    #region 私有

    private delegate void OkCallBack(PropertyInfo info, object obj);

    private delegate void OkCallBack2(FieldInfo info,object obj);

#if UNITY_EDITOR 

    [Button("检测是否正确",ButtonSizes.Medium)]
    public void CheckIsOk()
    {
        CheckIsOk(LogOk,LogOk,LogOk,LogOk, LogOk, LogOk2, LogOk2, LogOk2, LogOk2, LogOk2);
    }


    private void LogOk(PropertyInfo info, object obj)
    {
        MyLog.Green("OK");
    }
    private void LogOk2(FieldInfo info, object obj)
    {
        MyLog.Green("OK");
    }

#endif

    #endregion


    private void CheckIsOk(OkCallBack intAction, OkCallBack floatAction, OkCallBack vector2Action, OkCallBack vector3Action, OkCallBack colorAction, OkCallBack2 intAction2, OkCallBack2 floatAction2, OkCallBack2 vector2Action2, OkCallBack2 vector3Action2, OkCallBack2 colorAction2)
    {
        Component c = GetComponent(ComponentName);
        if (null == c)
        {
            MyLog.Red("获取不到这个组件名 —— " + ComponentName);
            return;
        }
        Type type = c.GetType();

        switch (isProperty)
        {
            case EIsProperty.Property:
                CheckProperty(type,c,intAction,floatAction,vector2Action,vector3Action,colorAction);
                break;
            case EIsProperty.Field:
                CheckField(type,c, intAction2, floatAction2, vector2Action2, vector3Action2, colorAction2);
                break;
        }

    }


    private void CheckProperty(Type type, Component c,OkCallBack intAction, OkCallBack floatAction, OkCallBack vector2Action, OkCallBack vector3Action, OkCallBack colorAction)
    {
        PropertyInfo pInfo = type.GetProperty(PropertyName);

        if (null == pInfo)
        {
            MyLog.Red("1. 看下是否属性  2.看下有没有写错属性名");
        }
        else
        {
            Type lieType = pInfo.GetValue(c, null).GetType();
            switch (TO)
            {
                case EValueType.INT:
                    if (lieType == typeof(Int32))
                    {
                        if (null != intAction)
                        {
                            intAction(pInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Int32), lieType));
                    }
                    break;
                case EValueType.FLOAT:
                    if (lieType == typeof(Single))
                    {
                        if (null != floatAction)
                        {
                            floatAction(pInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Single), lieType));
                    }
                    break;
                case EValueType.VECTOR2:
                    if (lieType == typeof(Vector2))
                    {
                        if (null != vector2Action)
                        {
                            vector2Action(pInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Vector2), lieType));
                    }
                    break;
                case EValueType.VECTOR3:
                    if (lieType == typeof(Vector3))
                    {
                        if (null != vector3Action)
                        {
                            vector3Action(pInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Vector3), lieType));
                    }
                    break;
                case EValueType.COLOR:
                    if (lieType == typeof(Color))
                    {
                        if (null != colorAction)
                        {
                            colorAction(pInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Color), lieType));
                    }
                    break;
                default:
                    MyLog.Red(string.Format("这个 {0} 类型没有定义", lieType));
                    break;
            }


        }
    }

    private void CheckField(Type type, Component c, OkCallBack2 intAction, OkCallBack2 floatAction, OkCallBack2 vector2Action, OkCallBack2 vector3Action, OkCallBack2 colorAction)
    {
        FieldInfo fInfo = type.GetField(PropertyName);

        if (null == fInfo)
        {
            MyLog.Red("1. 看下是否字段  2.看下有没有写错字段名");
        }
        else
        {
            Type lieType = fInfo.GetValue(c).GetType();
            switch (TO)
            {
                case EValueType.INT:
                    if (lieType == typeof(Int32))
                    {
                        if (null != intAction)
                        {
                            intAction(fInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Int32), lieType));
                    }
                    break;
                case EValueType.FLOAT:
                    if (lieType == typeof(Single))
                    {
                        if (null != floatAction)
                        {
                            floatAction(fInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Single), lieType));
                    }
                    break;
                case EValueType.VECTOR2:
                    if (lieType == typeof(Vector2))
                    {
                        if (null != vector2Action)
                        {
                            vector2Action(fInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Vector2), lieType));
                    }
                    break;
                case EValueType.VECTOR3:
                    if (lieType == typeof(Vector3))
                    {
                        if (null != vector3Action)
                        {
                            vector3Action(fInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Vector3), lieType));
                    }
                    break;
                case EValueType.COLOR:
                    if (lieType == typeof(Color))
                    {
                        if (null != colorAction)
                        {
                            colorAction(fInfo, c);
                        }
                    }
                    else
                    {
                        MyLog.Red(string.Format("不是 {0} 类型，而是 {1}", typeof(Color), lieType));
                    }
                    break;
                default:
                    MyLog.Red(string.Format("这个 {0} 类型没有定义", lieType));
                    break;
            }


        }
    }



}
