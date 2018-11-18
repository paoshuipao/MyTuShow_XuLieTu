using System.Collections.Generic;
using PSPEditor.EditorUtil;
using PSPUtil.StaticUtil;
using UnityEditor;
using UnityEngine;

public abstract class AbstractInspector<T> : Editor                         //要想改面板 就继承这个
    where T : Object
{

    #region 私有



    private T m_Bean;
    protected ZuHeTool m_Tools;


    void OnEnable()                                          //初始化
    {
        m_Tools = new ZuHeTool(OnChangeJianGe());
        m_Bean = target as T;
        if (null == m_Bean)
        {
            MyLog.Red("看下 AbstractInspector<脚本名> 是不是写错了>");
        }
        else
        {
            OnInit(m_Bean);
        }
    }
    void OnSceneGUI()                                        //点击GameObject时场景视图的GUI
    {
        serializedObject.Update();
        OnSceneGui();
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }

        serializedObject.ApplyModifiedProperties();
    }


    public override void OnInspectorGUI()
    {
        GUISkin skin = LoadRes.ResourcesSkin;
        if (null == skin)
        {
            MyLog.Red("未能加载 GUISkin");
            return;
        }
        GUI.skin = skin;
        OnEditorGUI(m_Bean);

    }


    protected virtual int OnChangeJianGe()                         //改变间隔
    {
        return 100;
    }


    protected abstract void OnEditorGUI(T bean);
    #endregion


    protected void AddBaseInspector()                        //调用原来的Inspector
    {
        DrawDefaultInspector();
    }


    protected virtual void OnInit(T bean) { }                //用来初始化

    protected virtual void OnSceneGui() {  }                // 点击GameObject时场景视图的GUI

}
