using System;
using System.Collections.Generic;
using System.IO;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector.Editor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public abstract class AbstractChooseKuang<T> : OdinEditorWindow
    where T: OdinEditorWindow
{

    #region 系统函数
    protected override void OnEnable()
    {
        base.OnEnable();
        m_Tools = new ZuHeTool(OnChangeJianGe());
        OnInit();
    }

    protected override void OnEndDrawEditors()
    {
        base.OnEndDrawEditors();
        GUISkin skin = LoadRes.ResourcesSkin;
        if (null == skin)
        {
            MyLog.Red("未能加载 GUISkin");
            return;
        }
        GUI.skin = skin;
        MyCreate.AddSpace(8);
        MyCreate.Box(OnEditorGUI);
    }

    #endregion


    #region 私有

    protected ZuHeTool m_Tools;

    protected abstract void OnEditorGUI();


    protected static readonly string OpenSure = "开启：".AddWhite();

    #endregion


    protected static T CreateWindow(string biaoTi)           //一开始调用这 创建窗口
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



    protected static readonly string ZhongZai = "+".AddLightGreen();


    //方法----------------------------------------------------------------------------------
    protected void AddSpace()
    {
        MyCreate.AddSpace(8);
    }


    protected void AddSpace_3()
    {
        MyCreate.AddSpace(3);
    }

    protected void AddSpace_15()
    {
        MyCreate.AddSpace(15);
    }

    protected void DrawnOne(string str, Action action,bool isKongGe=true)      // 层次结构第一层
    {
        if (isKongGe)
        {
            m_Tools.Text_L("─── ", str.AddBlue());
            if (null != action)
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.AddSpace(35);
                    MyCreate.Box(action);
                });
            }
        }
        else
        {
            MyCreate.Text(" ── "+ str);
            if (null != action)
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.AddSpace(18);
                    MyCreate.Box(action);
                });
            }
        }

    }
    protected void DrawnOne(string str, Action action, Action onClick)         // 层次结构第一层 + 打开按钮
    {
        MyCreate.Heng(() =>
        {
            m_Tools.Text_L("─── ", str.AddBlue());
            MyCreate.AddSpace();
            MyCreate.Button("  打开  ", onClick);
        });

        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }

    protected void DrawTwo(string str, Action action, bool isKongGe = true)    // 层次结构第二层
    {
        m_Tools.Text_L("─── ", str.AddLightBlue());
        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }

    protected void DrawTwo(string str, Action action, Action onClick)          // 层次结构第二层 + 打开按钮
    {
        MyCreate.Heng(() =>
        {
            m_Tools.Text_L("─── ", str.AddLightBlue());
            MyCreate.AddSpace();
            MyCreate.Button("  打开  ", onClick);

        });
        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }


    protected void DrawThree(string str, Action action, bool isKongGe = true)  // 层次结构第三层
    {
        m_Tools.Text_L("─── ", str.AddHui());
        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }


    protected void DrawThree(string str, Action action, Action onClick)        // 层次结构第三层 + 打开按钮
    {
        MyCreate.Heng(() =>
        {
            m_Tools.Text_L("─── ", str.AddHui());
            MyCreate.AddSpace();
            MyCreate.Button("  打开 ", onClick);

        });
        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }


    protected void DrawnOne(string str, string greedStr ,ref bool isShow,Action action, Action nextAction)
    {
        bool isTmp = isShow;
        m_Tools.TextText_LG("─── " + str, greedStr,ref isTmp, action);
        if (null != nextAction)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(nextAction);
            });
        }
        isShow = isTmp;
    }

    protected void DrawnOne_NoColor(string str, Action action, Action onClick) 
    {
        MyCreate.Heng(() =>
        {
            m_Tools.Text_L("─── ", str);
            MyCreate.AddSpace();
            MyCreate.Button("  打开  ", onClick);
        });

        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }

    protected void DrawTwo_NoColor(string str, Action action, bool isKongGe = true)
    {
        m_Tools.Text_L("─── ", str);
        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }

    protected void DrawTwo_NoColor(string str, Action action, Action onClick)
    {
        MyCreate.Heng(() =>
        {
            m_Tools.Text_L("─── ", str);
            MyCreate.AddSpace();
            MyCreate.Button("  打开  ", onClick);

        });
        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }


    protected void DrawThree_NoColor(string str, Action action, bool isKongGe = true)
    {
        m_Tools.Text_L("─── ", str);
        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }


    protected void DrawThree_NoColor(string str, Action action, Action onClick)
    {
        MyCreate.Heng(() =>
        {
            m_Tools.Text_L("─── ", str);
            MyCreate.AddSpace();
            MyCreate.Button("  打开 ", onClick);

        });
        if (null != action)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(35);
                MyCreate.Box(action);
            });
        }
    }



    protected void AddSearch(ref string input,               //加个搜索框,搜索第一个Text，不关下面GUI逻辑事
        List<SearchText> allText, Action action)
    {
        input = m_Tools.TextString("【 搜索 】".AddGreen().AddBold(), input, () =>
        {
            if (null != action)
            {
                action();
            }
        }, -50);
        bool tmpIsNone = true;
        if (!string.IsNullOrEmpty(input))
        {
            if (null != action)
            {
                action();
            }
            for (int i = 0; i < allText.Count; i++)
            {
                if (allText[i].Text1.ToLower().Contains(input.ToLower()))
                {
                    tmpIsNone = false;
                    break;
                }
            }
        }
        else
        {
            tmpIsNone = false;
        }
        if (tmpIsNone)
        {
            m_Tools.Text_G("没有这个  " + input);
        }
        MyCreate.AddSpace(10);
    }




    protected static void ShowImage(string path,int kongGe =0)
    {
        Texture2D texture = LoadRes.DownImage(path);
        if (null != texture)
        {
            Rect rect = GUILayoutUtility.GetRect(0, 0);
            rect.x = kongGe;
            rect.width = texture.width;
            rect.height = texture.height;
            GUILayout.Space(rect.height);
            GUI.DrawTexture(rect, texture);
        }
        else
        {
            MyCreate.Image(Texture2D.whiteTexture);
        }
    }


    protected static void ShowButtomImage(string path)
    {
        Texture2D texture = LoadRes.DownImage(path);
        if (null != texture)
        {
            MyCreate.Image(texture);
        }
        else
        {

            MyCreate.Image(Texture2D.whiteTexture);
        }
    }








    //给继承----------------------------------------------------------------------------------
    protected virtual void OnInit() { }

    protected virtual int OnChangeJianGe()                   //改变间隔
    {
        return 200;
    }

    //系统给的继承----------------------------------------------------------------------------------
    protected virtual void OnHierarchyChange() { }            //Hierarchy面板有任何拖拽修改删除等操作都调用
    protected virtual void OnProjectChange() { }              //Project面板有任何拖拽修改删除等操作都调用



    //——————————————————最新——————————————————



    protected Texture2D LoadTextureInLocal(string file_path)                    // IO 流式 从电脑加载图片
    {
        //创建文件读取流
        FileStream fileStream = new FileStream(file_path, FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        //创建Texture
        int width = 300;
        int height = 372;
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);
        return texture;
    }


    protected Image CreateImage(string imageName)                               // 直接创建个默认 Image
    {

        GameObject canvas = new GameObject("Canvas");
        Canvas c = canvas.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<GraphicRaycaster>();
        CanvasScaler cs = canvas.AddComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        cs.referenceResolution = new Vector2(1366f, 768f);
        cs.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

        DefaultControls.Resources res = new DefaultControls.Resources();
        GameObject go = DefaultControls.CreateImage(res);
        go.name = imageName;
        go.transform.parent = canvas.transform;
        return go.GetComponent<Image>();
    }


    // 四个按钮
    protected void FourButton(string btn1, string btn2, string btn3, string btn4, Action action1, Action action2, Action action3, Action action4)
    {
        MyCreate.Heng(() =>
        {
            int eachWidth = Screen.width / 4 - 10;
            MyCreate.Button(btn1, eachWidth, action1);
            MyCreate.Button(btn2, eachWidth, action2);
            MyCreate.Button(btn3, eachWidth, action3);
            MyCreate.Button(btn4, eachWidth, action4);
        });

    }


    // 三个按钮
    protected void ThreeButton(string btn1, string btn2, string btn3, Action action1, Action action2, Action action3)
    {
        MyCreate.Heng(() =>
        {
            int eachWidth = Screen.width / 3 - 14;
            MyCreate.Button(btn1, eachWidth, action1);
            MyCreate.Button(btn2, eachWidth, action2);
            MyCreate.Button(btn3, eachWidth, action3);
        });

    }




}
