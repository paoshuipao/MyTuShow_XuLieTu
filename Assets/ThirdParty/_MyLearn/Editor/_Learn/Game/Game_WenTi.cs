using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Game_WenTi : AbstactNewKuang
    {

        [MenuItem(LearnMenu.ZhiShi_WenTi)]
        static void Init()
        {
            Game_WenTi instance = GetWindow<Game_WenTi>(false, "");
            instance.SetupWindow();
        }


        protected override void DrawLeft()
        {
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "大纲";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.ZhongJie ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.ZhongJie);
            }
            AddSpace();


            bool isYuMa = (type == EType.YuMa || type == EType.YuMa1 || type == EType.YuMa2 || type == EType.YuMa3 || type == EType.YuMa4 || type == EType.YuMa5 || type == EType.YuMa6);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "源码 问题";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isYuMa ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.YuMa1);
            }

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.YuMa1 ? " 看源码".AddBlue() : " 看源码");
            if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.YuMa1);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.YuMa2 ? " == 与 Equals 区别".AddBlue() : " == 与 Equals 区别");
            if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.YuMa2);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.YuMa3 ? " 怪 前后问题".AddBlue() : " 怪 前后问题");
            if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.YuMa3);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.YuMa4 ? " 操作运算符".AddBlue() : " 操作运算符");
            if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.YuMa4);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.YuMa5 ? " 转 UGUI 坐标".AddBlue() : " 转 UGUI 坐标");
            if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.YuMa5);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.YuMa6 ? " 复制 粘贴".AddBlue() : " 复制 粘贴");
            if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.YuMa6);
            }
            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "普通 问题";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Normal ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Normal);
            }
            AddSpace();
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Error 问题";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Error ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Error);
            }

        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.ZhongJie:    DrawRightPage1(DrawDaGang);       break;
                case EType.YuMa1:       DrawRightPage3(DrawLook);         break;
                case EType.YuMa2:       DrawRightPage4(DrawEquit);        break;
                case EType.YuMa3:       DrawRightPage5(DrawGong);         break;
                case EType.YuMa4:       DrawRightPage8(DrawYunFu);        break;
                case EType.YuMa5:       DrawRightPage8(DrawUGUIPosition); break;
                case EType.YuMa6:       DrawRightPage8(DrawCopy);         break;
                case EType.Normal:      DrawRightPage6(DrawNormal);       break;
                case EType.Error:       DrawRightPage7(DrawError);        break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -10;
                    break;
            }
        }



        #region 私有


        private enum EType
        {
            ZhongJie,
            YuMa, YuMa1, YuMa2, YuMa3, YuMa4,YuMa5, YuMa6,
            Normal,
            Error,


        }

        private EType type = EType.ZhongJie;

        private void SetTheSame(EType t)
        {
            if (type != t)
            {
                type = t;
                ResetPageView();
            }

        }


        protected override string Tittle()
        {
            return "问题总结";
        }



        #endregion

        private void DrawDaGang()                                // 大纲
        {
            m_Tools.BiaoTi_B("源码 问题");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("  1.  怎么看源码");
                m_Tools.Text_B("  2.  == 与 Equals 区别");
                m_Tools.Text_B("  3.  如何 当怪进入左右各 3 米，前方 5 米，就进行攻击");
                m_Tools.Text_B("  4.  不清楚的操作运算符   ", "（如 1<<8、？？）".AddHui());

            });

            AddSpace();
            m_Tools.BiaoTi_Y("普通 问题");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("  1.  如何 找到 Dll");
                m_Tools.Text_Y("  2.  如何 不显示 引用后面的作者和更改选项");
                m_Tools.Text_Y("  3.  怎么打开 .db 文件");
            });


            AddSpace();
            m_Tools.BiaoTi_R("Error 问题");
            MyCreate.Box(() =>
            {
                m_Tools.Text_R("  1.  解决 Unity Dll 4.x 不兼容问题");
                m_Tools.Text_R("  2.  IIS 下载 没有 MIME 映射的问题");
                m_Tools.Text_R("  3.  Shader 中的错误");
            });

        }


        private void DrawLook()                                  // 怎么看源码
        {
            m_Tools.Text_B("1. 是否按钮拖拽( 搜索 Button  - > 看下是否有 )");
            m_Tools.Text_B("2. 注意这四个使用字符串的情况：");
            MyCreate.SelectText("      Invoke  InvokeRepeating   StartCoroutine  StopCoroutine");
            m_Tools.Text_B("3. 将看上去不使用的文件扔到这个文件夹上");
            MyCreate.SelectText("      WebplayerTemplates");

            m_Tools.Text_L("4. 源码先保存一分，然后该删的就删，只留能运行的部分");

            m_Tools.TextButton_Open("5. 对于面板式开发，使用特性注释插件".AddBlue(), @"F:\ZiLiao\使用其它插件的包\编辑实用扩展\特性Eidtor.unitypackage");

            m_Tools.Text_B("6. 把 Public 改成 Private , 再添加上特性");
            MyCreate.SelectText("      [SerializeField]");



        }

        private void DrawEquit()                                 // == 与 Equals 区别
        {
            m_Tools.BiaoTi_O("== 与 Equals 区别" + "(==内容、equal地址、string 都相等)".AddGreen());

            MyCreate.Box(() =>
            {
                m_Tools.Text_L("1. equal 对比的是变量里的地址是否相等");
                m_Tools.Text_L("2. == 比较的内容是否一样");
                MyCreate.Text("重写 == :".AddGreen() + "public static bool operator == ( T t1,T t2)");
                m_Tools.Text_L("3. 除了 string 特殊的引用类型 ");
                MyCreate.Text("(== 与 Equals相等):".AddGreen() + "其实就是 string 重写了 Equals 的方法");
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("string tmpA =new string(new char[]｛'H','L'｝)");
                m_Tools.Text_H("string tmpB =new string(new char[]｛'H','L'｝)");
                AddSpace_3();
                m_Tools.TextText_HG("tmpA == tmpB", "// true");
                m_Tools.TextText_HG("tmpA.Equals( tmpB )", "// true");

            });
            MyCreate.Box(() =>
            {
                MyCreate.Text("内存分三部分：" + "堆、栈、全局变量区（static）".AddWhite());
                m_Tools.TextText_BY("      堆", "      栈");
                m_Tools.Text_Y("    tmpA   ".AddBlue(), "    指针指向→  ".AddWhite(), "new string(new char[]｛'H','L'｝)", "// 地址1".AddLightGreen());
                m_Tools.Text_Y("    tmpB   ".AddBlue(), "    指针指向→  ".AddWhite(), "new string(new char[]｛'H','L'｝)", "// 地址2".AddLightGreen());
                AddSpace_3();
                m_Tools.Text_L("1. 当方法结束：" + "tmpA 就会直接销毁".AddGreen(), "，指向对象的指针就没有");
                m_Tools.Text_G("2. 而 栈 里的对象只有完全没有指针指向，才会通过GC回收");


            });

        }

        private void DrawGong()                                  // 如何当怪进入左右各 3 米，前方 5 米，就进行攻击
        {
            m_Tools.BiaoTi_O("如何当怪进入左右各 3 米，前方 5 米，就进行攻击");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("使用我的 Transform的扩展 ：AttackRange 方法");
                m_Tools.Method_BY("AttackRange", "this Transform,float,float,Transform", "", "bool");
                m_Tools.TextText_HG("this Transform", "展开范围者");
                m_Tools.TextText_HG("float", "左右各多少米");
                m_Tools.TextText_HG("float", "前方多少米");
                m_Tools.TextText_HG("Transform", "入侵者");

            });

        }



        private void DrawUGUIPosition()                         // 转UGUI坐标
        {
            m_Tools.BiaoTi_B("鼠标坐标转成 UGUI 的坐标");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Vector2 pos;");
                m_Tools.Text_H("RectTransformUtility.ScreenPointToLocalPointInRectangle(父RectTransform,Input.mousePosition, 相机, out pos)");
                m_Tools.TextText_HG("rt.anchoredPosition = pos", "// 不是 Postion 哦");

            });
        }

         
        private void DrawCopy()                                 // 复制 粘贴
        {
            m_Tools.BiaoTi_B("相当于 Ctrl + C 和 Ctrl + V");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("GUIUtility".AddBlue()+".systemCopyBuffer { get ; set }","// 可读可写");
            });

        }



        private void DrawYunFu()                                 // 不清楚的操作运算符
        {
            m_Tools.BiaoTi_B("左移运算符  " + "<<".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("• 定义：", "按二进制形式".AddGreen(),"把所有的数字向左移动对应的位数".AddBlue());
                m_Tools.Text_L("• 备注：");
                m_Tools.Text_B("       1. 第二个操作数的类型必须是 int 类型");
                m_Tools.Text_B("       2. ", "可重载( 使用operator".AddGreen(),")，第一个操作数 为用户定义的类型");
                m_Tools.Text_L("• 计算的方法：");
                m_Tools.Text_Y("       8 << 1 的值为 -> 8*2 = 16");
                m_Tools.Text_Y("       8 << 2 的值为 -> 8*(2^2) = 32");
                m_Tools.Text_Y("       8 << n 的值为 -> 8*（2^n）");
                m_Tools.Text_L("• 实际过程：");
                m_Tools.Text_G("       8  二进制-> 1000 -> 左移1位 -> 10000   -> 16");
                m_Tools.Text_G("       8  二进制-> 1000 -> 左移2位 -> 100000 -> 32");
            });
            m_Tools.BiaoTi_B("右移运算符  " + "<<".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("• 例子：");
                m_Tools.Text_Y("       8 >> 1 的值为 -> 4");
                m_Tools.Text_Y("       8 >> 2 的值为 -> 2");
                m_Tools.Text_Y("       8 >> 3 的值为 -> 1");
                m_Tools.Text_Y("       8 >> 4 的值为 -> 0"+"( 之后的都为 0 )".AddGreen());
                m_Tools.Text_L("• 实际过程：");
                m_Tools.Text_G("       8  二进制-> 1000 -> 右移1位 -> 100 -> 4");
                m_Tools.Text_G("       8  二进制-> 1000 -> 右移2位 -> 10   -> 2");
                m_Tools.Text_G("       8  二进制-> 1000 -> 右移3位 -> 1    -> 1");
                m_Tools.Text_G("       8  二进制-> 1000 -> 右移4位 -> 0    -> 0");
                m_Tools.Text_G("       8  二进制-> 1000 -> 右移5位 -> 00   -> 0");


            });

            m_Tools.BiaoTi_B("命名空间别名限定符运算符  "+"::".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("例如：  global::System.Console.WriteLine(“Hello”);".AddHui());
            });
        }


        private void DrawNormal()                                // 普通 问题
        {
            m_Tools.BiaoTi_Y("如何 找到 Dll");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("引用 —> 管理 NuGet 程序包 —> 搜索 —> 安装");
                m_Tools.Text_L("运行就会有 dll 啦");

            });
            AddSpace_3();


            m_Tools.BiaoTi_Y("如何 不显示 引用后面的作者和更改选项");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("文本编辑器 -> 所有语言 -> CodeLens -> xxx");
            });
            AddSpace();


            m_Tools.BiaoTi_Y("怎么打开 .db 文件");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("1. 打开 MySql 服务");
            });

        }


        private void DrawError()                                 // Error 问题
        {
            m_Tools.BiaoTi_R("解决 Unity Dll 4.x 不兼容问题");
            MyCreate.Box(() =>
            {
                MyCreate.Text("Unity targets .NET 4.x and is marked as compatible with editor, ".AddRed());
                MyCreate.Text("Editor can only use assemblies targeting .NET 3.5 or lower".AddRed());
                AddSpace_3();
                m_Tools.Text_G("解决方法：");
                m_Tools.Text_L("PlayerSetting —> OtherSettings —> Configuration 下面第一个");
                m_Tools.Text_L("Scripting Runtime Version 选择 " + "Experimental(.NET 4.6)".AddGreen());

            });
            AddSpace_15();



            m_Tools.BiaoTi_R("IIS 下载 没有 MIME 映射的问题");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("筛选：MIME 类型 ->添加");
                MyCreate.SelectText("application/octet-stream");

            });

            AddSpace_15();


            m_Tools.BiaoTi_R("Shader 中的错误");
            MyCreate.Box(() =>
            {
                m_Tools.Text_R("1. 数字不要带 f !!!" + " (如 5f )".AddHui());
            });
            AddSpace_15();
        }




    }

}

