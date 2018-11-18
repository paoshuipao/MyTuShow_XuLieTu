/*
using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Test_JiaoKe : AbstactNewKuang
    {
        protected override void DrawLeft()
        {
            #region 课程介绍

            bool isKe1 = (type == EType.Ke1 || type == EType.Ke11 || type == EType.Ke12);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "课程介绍";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isKe1 ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Ke11);
            }
            if (isKe1)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke11 ? "   教学大纲".AddBlue() : "   教学大纲");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke11);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke12 ? "   地址".AddBlue() : "   地址");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke12);
                }
            }
            #endregion

            AddSpace();

            #region 使用特性

            bool isKe2 = (type == EType.Ke2 || type == EType.Ke21 || type == EType.Ke22 || type == EType.Ke23 || type == EType.Ke24);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "使用特性";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isKe2 ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Ke21);
            }
            if (isKe2)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke21 ? "   Inspector".AddBlue() : "   Inspector");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke21);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke22 ? "   Class".AddBlue() : "   Class");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke22);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke23 ? "   Editor".AddBlue() : "   Editor");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke23);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke24 ? "   System".AddBlue() : "   System");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke24);
                }
            }
            #endregion


            AddSpace();

            #region 自定义特性

            bool isKe3 = (type == EType.Ke3 || type == EType.Ke31 || type == EType.Ke32 || type == EType.Ke33 || type == EType.Ke34);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "自定义特性";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isKe3 ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Ke31);
            }
            if (isKe3)
            {
                MyCreate.Text("简单创建 特性");
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke31 ? "C# 自定义 Attribute".AddBlue() : "C# 自定义 Attribute");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke31);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke32 ? "反射获取特性信息".AddBlue() : "反射获取特性信息");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke32);
                }
                MyCreate.Text("应用 Unity 特性例子：");
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke33 ? "颜色 Header 特性".AddBlue() : "颜色 Header 特性");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke33);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke34 ? "中文枚举 特性".AddBlue() : " 中文枚举 特性");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke34);
                }
            }
            #endregion


            AddSpace();

            #region Odin 插件

            bool isKe4 = (type == EType.Ke4 || type == EType.Ke41 || type == EType.Ke42);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Odin 插件";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isKe4 ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Ke41);
            }
            if (isKe4)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke41 ? "   介绍插件".AddBlue() : "   介绍插件");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke41);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Ke42 ? "   简单归类".AddBlue() : "   简单归类");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Ke42);
                }
            }
            #endregion

            AddSpace();


            bool isZJ= (type == EType.Zhong || type == EType.Zhong1 || type == EType.Zhong2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "最后";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isZJ ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Zhong1);
            }

            if (isZJ)
            {

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zhong1 ? "   问题、建议反馈".AddBlue() : "   问题、建议反馈");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zhong1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zhong2 ? "   TODO".AddBlue() : "   TODO");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zhong2);
                }


            }

        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Ke11:
                    DrawRightPage1(DrawJiaoXue);
                    break;
                case EType.Ke12:
                    DrawRightPage3(DrawDiZi);
                    break;
                case EType.Ke21:
                    break;
                case EType.Ke22:
                    break;
                case EType.Ke23:
                    break;
                case EType.Ke31:
                    DrawRightPage4(DrawCAtt);
                    break;
                case EType.Ke32:
                    break;
                case EType.Ke33:
                    break;
                case EType.Ke34:
                    break;
                case EType.Ke41:
                    break;
                case EType.Ke42:
                    break;
                case EType.Zhong:
                    break;
                case EType.Zhong1:
                    DrawRightPage(DrawWenTi);
                    break;
                case EType.Zhong2:
                    break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.Ke12:
                    mWindowSettings.pageWidthExtraSpace.target = -30;
                    break;
                 default:
                     mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
            }
        }


        #region 私有
        [MenuItem("Tools/教学课程大纲/01 特性")]
        static void Init()
        {
            Test_JiaoKe instance = GetWindow<Test_JiaoKe>(false, "");
            instance.SetupWindow();
        }


        private enum EType
        {
            Ke1,Ke11, Ke12,
            Ke2,Ke21, Ke22, Ke23, Ke24,
            Ke3,Ke31, Ke32, Ke33, Ke34,
            Ke4,Ke41, Ke42,
            Zhong, Zhong1, Zhong2,

        }

        private EType type = EType.Ke11;

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
            return "课程大纲";
        }


        #endregion




        private void DrawJiaoXue()                               // 教学大纲
        {
            m_Tools.BiaoTi_B("1. ".AddWhite()+ "了解 Attribute(特性) +  编辑工具");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("─── 简单演示"+" Header  + Button".AddLightGreen()+" 例子带入门");
                m_Tools.Text_B("─── C# 自定义 Attribute");
                m_Tools.Text_L("        ─── 利用控制台程序讲解");
                m_Tools.Text_L("        ─── 通过反射来获取 Attribute 中的信息");

            });
            AddSpace_3();
            m_Tools.BiaoTi_B("2. ".AddWhite()+"了解几个常用的 Unity 特性");
            MyCreate.Box(() =>
            {
                m_Tools.Text_O("─── Inspector");
                m_Tools.Text_Y("        ─── ContextMenu、Range、Space、Tooltip");
                m_Tools.Text_Y("        ─── HideInInspector、SerializeField、TextArea");
                m_Tools.Text_O("─── 用于继承 MonoBehaviour 组件 Class");
                m_Tools.Text_Y("        ─── AddComponentMenu、DisallowMultipleComponent");
                m_Tools.Text_Y("        ─── RequireComponent、ExecuteInEditMode");
                m_Tools.Text_O("─── Editor");
                m_Tools.Text_Y("        ─── MenuItem");
                m_Tools.Text_O("─── System");
                m_Tools.Text_Y("        ─── Obsolete、Flags、AttributeUsage");
            });
            AddSpace_3();

            m_Tools.BiaoTi_B("3. ".AddWhite()+ "自定义编写实用的 Attribute 应用");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("─── 颜色 Header 特性"+" MyHead".AddYellow());
                m_Tools.Text_B("─── 中文枚举特性"+ " MyChinaEnum ".AddYellow() + "(涉及反射知识，会讲解)".AddGreen());

            });
            m_Tools.BiaoTi_B("4.".AddWhite()+" Odin 插件");
            MyCreate.Box(() =>
            {
                m_Tools.Text_O("─── 介绍");
                m_Tools.Text_O("─── 给众多 Attribute 归类总结");
            });
            m_Tools.BiaoTi_B("5.".AddWhite() + " 最后总结与问题反馈");

        }




        private void DrawDiZi()                                  // 网盘地址
        {
            m_Tools.BiaoTi_L("版本");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("本次教学 Unity 版本为：  ","2017.2.0f3".AddLightBlue());
                m_Tools.Text_H("Odin 插件为：  ","Odin - Inspector and Serializer v1.0.6.0               ".AddLightBlue());

            });
            m_Tools.BiaoTi_Y("Attribute 工具"+"（CSDN）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextSelectText_L("网址", "https://download.csdn.net/download/wwknan/10590393",-90);
            });
            AddSpace();
            m_Tools.BiaoTi_Y("课程源码 && Odin 插件");
            MyCreate.Box(() =>
            {
                m_Tools.TextSelectText_L("链接","",-30);
                m_Tools.TextSelectText_L("密码","",-30);
            });
            AddSpace();
            m_Tools.BiaoTi_Y("相关官方文档连接处");
            MyCreate.Box(() =>
            {
                m_Tools.TextTextOpen_LH("Unity Attribute", "", () =>
                {
                    Application.OpenURL("https://docs.unity3d.com/ScriptReference/AddComponentMenu.html");
                },0,"打开");
                m_Tools.TextTextOpen_LH("MSDN Attribute 类", "", () =>
                {
                    Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/system.attribute(v=vs.110).aspx");

                }, 0, "打开");
            });
            AddSpace();
            m_Tools.BiaoTi_Y("推荐博客文章");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("");
                m_Tools.Text_H("");
                m_Tools.Text_H("");
            });

        }



        private void DrawCAtt()                                  // C# 自定义 Attribute
        {
            MyCreate.SelectText("Attribute");
            MyCreate.SelectText("AttrubuteUsage");


        }



        private void DrawWenTi()                                 // 问题、建议反馈
        {
            MyCreate.Box(() =>
            {
                AddHead("感谢大家看到最后".AddColorAndSize(MyEnumColor.Blue,20,false).AddBold(),"有缘我们下期教程再见咯".AddColorAndSize(MyEnumColor.LightBlue, 12, false));

            });

            AddSpace_15();
            m_Tools.BiaoTi_B("Attribute 工具" + "（CSDN）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextSelectText_L("网址", "https://download.csdn.net/download/wwknan/10590393", -90);
            });
            AddSpace();
            m_Tools.BiaoTi_B("课程源码 && Odin 插件");
            MyCreate.Box(() =>
            {
                m_Tools.TextSelectText_L("链接", "https://pan.baidu.com/s/16ma83kFkJRKXVJlmtE2WmA", -90);
                m_Tools.TextSelectText_L("密码", "cnpy", -90);
            });
            AddSpace();
            m_Tools.BiaoTi_B("问题、建议反馈处：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("[第一次录视频，问题很多，有什么不足的都可以提出来]");
                m_Tools.Text_L("     1. 可在评论处中提出");
                m_Tools.Text_L("     2. 也直接发个邮件给我 —— ","1349601693@qq.com  泡水泡".AddYellow() , "(不要加 QQ..)".AddGreen());
            });

        }



    }


}

*/
