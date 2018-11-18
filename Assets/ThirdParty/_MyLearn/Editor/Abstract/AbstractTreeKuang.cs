using System;
using System.Linq;
using PSPEditor.EditorUtil;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector.Demos;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;


public abstract class AbstractTreeKuang<T> : OdinMenuEditorWindow
    where T : OdinMenuEditorWindow
{

    protected abstract void AddTree(OdinMenuTree tree);



    protected override OdinMenuTree BuildMenuTree()
    {
        OdinMenuTree tree = FirstInit();
        AddTree(tree);
        return tree;
    }


    #region 私有

    private OdinMenuTree FirstInit()
    {
        OdinMenuTree tree = new OdinMenuTree(true);
        OdinMenuStyle customMenuStyle = new OdinMenuStyle
        {
            BorderPadding = 0f,
            AlignTriangleLeft = true,
            TriangleSize = 16f,
            TrianglePadding = 0f,
            Offset = 20f,
            Height = 30,
            IconPadding = 0f,
            BorderAlpha = 0.323f
        };
        tree.DefaultMenuStyle = customMenuStyle;
        return tree;
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        OnInit();

    }
    #endregion



    /// <summary>
    /// 单 Class 单个添加
    /// </summary>
    /// <typeparam name="T">那个类</typeparam>
    /// <param name="tree">树</param>
    /// <param name="subString">菜单项名</param>
    /// <param name="color">字体颜色</param>
    protected void AddNew<R>(OdinMenuTree tree, string subString, MyEnumColor color = MyEnumColor.Blue)
        where R : new()
    {
        tree.AddObjectAtPath(subString, MyType.NewTypeClass<R>(),false, color);
    }



    /// <summary>
    /// 单 Class 的按组添加
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tree"></param>
    /// <param name="bigStr"></param>
    /// <param name="subString"></param>
    /// <param name="color"></param>
    protected void AddNew<R>(OdinMenuTree tree, string bigStr, string subString,MyEnumColor color=MyEnumColor.Blue)
        where R : new()
    {
        OdinMenuItem item1 = new OdinMenuItem(tree, subString, MyType.NewTypeClass<R>());
        item1.TextColor = color;
        tree.AddMenuItemAtPath(bigStr, item1);
    }





    //————————————————————————————————————

    protected static T CreateWindow(string biaoTi)                              //一开始调用这 创建窗口
    {
        T t = (T)GetWindow(typeof(T), false, biaoTi);
        t.Show();
        Resources.UnloadUnusedAssets();
        GC.Collect();
        return t;
    }

    protected static T CreateWindow(string biaoTi, int width, int height)
    {
        T window = (T)GetWindow(typeof(T), false, biaoTi);
        window.position = new Rect(window.position.xMin + 100f, window.position.yMin + 100f, width, height);
        window.Show();
        Resources.UnloadUnusedAssets();
        GC.Collect();
        return window;
    }


    protected virtual void OnInit() { }



}

