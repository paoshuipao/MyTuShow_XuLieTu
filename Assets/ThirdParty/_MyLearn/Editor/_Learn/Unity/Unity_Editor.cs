using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Unity_Editor : AbstactNewKuang
    {

        [MenuItem(LearnMenu.UnityEditor)]
        static void Init()
        {
            Unity_Editor instance = GetWindow<Unity_Editor>(false, "");
            instance.SetupWindow();
        }


        protected override void DrawLeft()
        {

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "特殊文件夹";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Eidtor1 ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Eidtor1);
            }
            AddSpace();
            MyCreate.Text("API");

            #region Eidtor ->  特性

            bool tmpAtt = (type == EType.Att || type == EType.Att1 || type == EType.Att2 || type == EType.Att3 || type == EType.Att4);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Eidtor ->  特性".AddSize(14);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Att ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Att);
            }

            if (tmpAtt)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Att1 ? "MenuItem".AddBlue() : "MenuItem");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Att1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Att2 ? "CustomPropertyDrawer".AddBlue() : "CustomPropertyDrawer");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Att2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Att3 ? "CustomEditor".AddBlue() : "CustomEditor");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Att3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Att4 ? "AttributeUsage".AddBlue() : "AttributeUsage");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Att4);
                }


            }

            #endregion


            AddSpace();

            #region Eidtor ->  类

            bool tmpZi = (type == EType.NorLie || type == EType.NorLie1 || type == EType.NorLie2 || type == EType.NorLie3 || type == EType.NorLie4);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Eidtor ->  类".AddSize(14);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.NorLie ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.NorLie);
            }

            if (tmpZi)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.NorLie1 ? "SerializedObject".AddBlue() : "SerializedObject");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.NorLie1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.NorLie2 ? "SerializedProperty".AddBlue() : "SerializedProperty");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.NorLie2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.NorLie3 ? "GUIContent".AddBlue() : "GUIContent");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.NorLie3);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.NorLie4 ? "GUIStyle".AddBlue() : "GUIStyle");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.NorLie4);
                }

            }

            #endregion

            AddSpace();

            #region Eidtor -> Static 类

            bool tmpStatic = (type == EType.Lie || type == EType.Lie1 || type == EType.Lie2 || type == EType.Lie3 || type == EType.Lie4);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Eidtor -> Static 类".AddSize(14);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Lie ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Lie);
            }

            if (tmpStatic)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Lie1 ? " Selection".AddBlue() : " Selection");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Lie1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Lie2 ? " EditorUtility".AddBlue() : " EditorUtility");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Lie2);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Lie3 ? " 总结 GUI".AddBlue() : " 总结 GUI");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Lie3);
                }
/*
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Lie4 ? " EditorGUI".AddBlue() : " EditorGUI");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Lie4);
                }*/
                
            }

            #endregion

            AddSpace();

            MyCreate.Text("实用功能");

            #region 修改属性例子

            bool tmpLiZi = (type == EType.LiZi || type == EType.LiZi1 || type == EType.LiZi2 || type == EType.LiZi3 );

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "修改面板单属性".AddSize(14);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(tmpLiZi ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.LiZi1);
            }

            if (tmpLiZi)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LiZi1 ? "将 枚举 修成中文".AddBlue() : "将 枚举 修成中文");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LiZi1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LiZi2 ? "将 Color 增加功能".AddBlue() : "将 Color 增加功能");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LiZi2);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LiZi3 ? "TODO".AddBlue() : "TODO");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LiZi3);
                }


            }

            #endregion

            AddSpace();


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "修改 Hierarchy 显示".AddSize(14);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Hierarchy ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Hierarchy);
            }
            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Gizmos";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Gizmos ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Gizmos);
            }


        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Eidtor1:    DrawRightPage1(DrawFolder);           break;
                case EType.Att:        DrawRightPage8(DrawAtt);              break;
                case EType.Att1:       DrawRightPage3(DrawMenuItem);         break;
                case EType.Att2:       DrawRightPage4(DrawCPD);              break;
                case EType.Att4:       DrawRightPage5(DrawAU);               break;
                case EType.NorLie:     DrawRightPage8(DrawEditorLie);        break;
                case EType.NorLie1:    DrawRightPage8(DrawSerializedObject); break;
                case EType.NorLie2:    DrawRightPage1(DrawSerializedP);      break;
                case EType.Lie:        DrawRightPage6(DrawStaticEditor);     break;
                case EType.Lie1:       DrawRightPage6(DrawSelection);        break;
                case EType.Lie2:       DrawRightPage2(DrawEditorUtility);    break;
                case EType.Lie3:       DrawRightPage3(DrawGUIZhong);  break;
                case EType.Lie4:       DrawRightPage4(DrawEditorGUI);        break;
                case EType.MainBan:    DrawRightPage5(DrawMainBanZhongJie);  break;
                case EType.MainBan1:   DrawRightPage6(DrawZhiJie);           break;
                case EType.MainBan2:   DrawRightPage7(DrawInspector);        break;
                case EType.MainBan3:   DrawRightPage8(DrawAttIn);            break;
                case EType.Gizmos:     DrawRightPage1(DrawGizmos);           break;
                case EType.LiZi1:      DrawRightPage3(DrawZhongWen);         break;
                case EType.Hierarchy:  DrawRightPage4(DrawHierarchyShow);    break;
                
            }
        }

        protected override void DrawRightSize()
        {

            switch (type)
            {
                case EType.NorLie1:
                    mWindowSettings.pageWidthExtraSpace.target = 40;
                    break;
                case EType.Lie2:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.LiZi1:
                    mWindowSettings.pageWidthExtraSpace.target = 90;
                    break;
                case EType.Hierarchy:
                    mWindowSettings.pageWidthExtraSpace.target = 60;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
            }

        }



        #region 私有
        private bool isPropertyDrawer = true, isDecoratorDrawer, isTu, isGizmos, isWebplayerTemplates;
        private bool isYanZhen, isUse, isTuJie, isAttributeUsage, isPropertyAttribute;
        private bool isHidden, isResources, isStreamingAssets = true;

        private static readonly string DrawHierarchyIconStr = "DrawHierarchyIcon".AddYellow();
        private static readonly string SerializedPropertyStr = "SerializedProperty".AddRed();
        private static readonly string SerializedObjectStr = "SerializedObject".AddOrange();
        private static readonly string ScriptableObjectStr = "ScriptableObject".AddYellow();
        private static readonly string MyChinaEnumStr = "MyChinaEnumAttribute".AddYellow();
        private static readonly string HeaderStr = "Header".AddYellow();
        private static readonly string propertyStr = "property".AddOrange();
        private static readonly string displayNameStr = "displayName".AddWhite();



        private enum EType
        {
            Eidtor1,
            Att,Att1,Att2,Att3, Att4,
            NorLie, NorLie1, NorLie2, NorLie3, NorLie4,
            Lie,Lie1,Lie2, Lie3, Lie4,
            LiZi, LiZi1, LiZi2, LiZi3,
            Hierarchy,

            MainBan,MainBan1,MainBan2, MainBan3,
            Gizmos

        }

        private EType type = EType.Eidtor1;

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
            return "Editor 相关";
        }


        #endregion


        private void DrawFolder()                                // 特殊文件夹
        {
            m_Tools.BiaoTi_O("脚本编译顺序(从先到后)");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("1.  最先被编译的", "", "Standard Assets", " (Asset/ 目录下)".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("●  一般是放一些Unity 内置的一些资源".AddHui());
                });

                m_Tools.Method_BY("1.  Pro版本使用的", "", "Pro Standard Assets", "(Asset/ 目录下)".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("●  功能更丰富如：一些高级内置的shader文件只有Pro版才起作用".AddHui());
                });

                m_Tools.Method_BY("2.   native 插件 ", "", "Plugins ", "(Asset/ 目录下)".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_YL("Plugins/x86 或 x86_64", "PC平台插件(32/64位)" + "（dll 文件）".AddHui());
                    m_Tools.TextText_YL("Plugins/Android", ".jar 文件".AddHui() + "、java 语言的插件、" + "so 文件".AddHui());
                    m_Tools.TextText_YL("Plugins/iOS", ".o、.m 、 .mm 、.c 、.cpp".AddHui() + " 等文件");
                });
            });
            AddSpace();
            m_Tools.BiaoTi_O("Asset 资源操作文件夹");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("Resources", "", "全部打包进去游戏并经过处理", "(任意、多个)", ref isResources, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_L("1.可有多个Resources ,不建议在多个中放同名的资源");
                        m_Tools.Text_L("2.当这些资源被实例化后就会被加载到内存中");
                        m_Tools.Text_H("  所以不用时：先 " + "Destroy".AddGreen() + " 物体");
                        m_Tools.Text_H("  再调用" + "Resources.UnloadUnusedAssets".AddGreen() + "来释放内存");
                    });
                });
                m_Tools.Method_YL("StreamingAssets", "", "不会修改全部拷贝", "(Asset/ 目录下)".AddGreen(), ref isStreamingAssets, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("■ 位于 StreamingAssets 文件夹中的 .dll 文件不参与编译");
                    });
                });
            });
            AddSpace();


            m_Tools.BiaoTi_O("Editor 编辑器文件夹，不会打包进游戏");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("Editor ", "", "", "(任意、多个)");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("• 同样可以有 Resources 文件夹，不会打包进入游戏");
                    m_Tools.Text_H("• 在 Editor 下的 MonoBehaviour 组件不能放到GameObject上");
                });
                m_Tools.Method_YL("Editor Default Resources", "", "", "(Asset/ 目录下)".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("使用 EditorGUIUtility.Load 加载资源");
                });

                m_Tools.Method_YL("Gizmos", "", " Scene 视图编辑", "(Asset/ 目录下)".AddGreen(), ref isGizmos, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("1. Gizmos 中的贴图资源可以直接通过名称使用");
                        m_Tools.Text_H("2. OnDrawGizmos 函数调用");
                    });
                });
            });
            AddSpace();
            m_Tools.BiaoTi_O("隐藏文件夹");
            m_Tools.TextText_BY("隐藏的文件或文件夹 ", "( . ~ cvs .tmp )", ref isHidden, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_L("1. 以 " + ".".AddYellow() + " 为" + "开头".AddYellow() + "的文件和文件夹");
                    m_Tools.Text_L("2. 以 " + "~" + " 为" + "结尾".AddYellow() + "的文件和文件夹");
                    m_Tools.Text_L("3. 名为" + " cvs".AddYellow() + "的文件和文件夹");
                    m_Tools.Text_L("4. " + "扩展名".AddYellow() + "为" + " .tmp".AddYellow() + " 的文件");
                });
            });

            m_Tools.TextText_BY("隐藏脚本的文件夹 ", "WebplayerTemplates", ref isWebplayerTemplates, () =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.SelectText("WebplayerTemplates");
                    m_Tools.Text_G("如果脚本出现错误又想运行，就把脚本扔到这个文件夹下");

                });
            });
        }


        #region 编辑 特性

        private void DrawAtt()                                  // 编辑特性总结
        {
            m_Tools.BiaoTi_O("MenuItem "+ONE + "（将 Static 方法放在菜单栏上）".AddYellow());
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/MenuItem-ctor.html");
                m_Tools.Text_L("  1. 该特性肯定是放在 ","Static 方法".AddBlue(),"上，该方法可以"," 私有/保护/公共/不写".AddBlue());
                m_Tools.Text_L("  2. 菜单栏  -> 还包含 右键 出现的菜单栏~");
                m_Tools.TextSelectText_L("  3. 放在 Editor 文件夹下或 使用预处理", "#if UNITY_EDITOR   #endif",80);


            });
            AddSpace();
            m_Tools.BiaoTi_O("修改面板会用到的特性");
            MyCreate.Box(() =>
            {
                AddSpace_3();
                m_Tools.Method_OW("CustomPropertyDrawer "+TWO, "", "修改 " + "单个 ".AddYellow() + "属性面板" + "(可属性，可特性)".AddYellow(), "class");
                AddSpace_3();
                m_Tools.Method_OW("CustomEditor "+THREE, "", "修改 整个类".AddYellow() + "的面板都修改", "class");
                AddSpace_3();
                MyCreate.Text("使用 特性 自定义面板的话，下面的特性就能用到");
                m_Tools.Method_OW("AttributeUsage "+FOUR, "", "给" + "特性类".AddYellow() + "添加限制", "自定义特性的 class");
                AddSpace_3();

            });






        }

        private void DrawMenuItem()                             // 特性 MenuItem
        {
            m_Tools.BiaoTi_B("构造函数");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("[MenuItem(string 路径名",ONE,")]");
                m_Tools.Text_B("[MenuItem(string ,bool 用于 验证判断", TWO, ")]");
                m_Tools.Text_B("[MenuItem(string ,bool ,int 优先级的顺序", THREE, ")]");
                
            });
            AddSpace();

            m_Tools.BiaoTi_Y("string 路径名"+ONE);
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("  1. 快捷键：  " + "%".AddGreen() + " ctrl     " + "#".AddGreen() + " shift     " + "&".AddGreen() + " alt");
                m_Tools.Text_Y("  2. 特殊的路径" + "（右键弹出菜单选项）".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("想要在 " + "Project 视图".AddGreen()+" 右键添加菜单栏");
                    MyCreate.SelectText("   [MenuItem(\"Assets/名\")]");
                    MyCreate.Text("想要在 " + "Hierarchy 视图".AddGreen() + " 右键添加菜单栏"+ "(优先级priority 要靠前，如在 20 之前)".AddGreen());
                    MyCreate.SelectText("   [MenuItem(\"GameObject/名\",false,10)]");
                    MyCreate.Text("想要在 " + "对应组件".AddGreen() + " 右键添加菜单栏"+ "(下面以 Rigidbody 为例)".AddLightGreen());
                    MyCreate.SelectText("   [MenuItem(\"CONTEXT/Rigidbody/名\")]");
                    MyCreate.SelectText("   private static void 方法名(MenuCommand menuCommand)");
                    m_Tools.Text_L("menuCommand.context as Rigidbody -> 那就能得到对应组件了");

                });
            });

            m_Tools.BiaoTi_Y("bool 用于 验证判断" + TWO);
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("false  ->  ","平常那样用".AddWhite(),"      true -> "," 需要验证是否能点击".AddWhite());
                m_Tools.Text_H("[使用图解]：",ref isYanZhen, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712000105915-1481569306.png");
                });
            });

            m_Tools.BiaoTi_Y("int 控制优先级的顺序" + THREE);
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("  1. 越小，优先级越高");
                m_Tools.Text_G("  2. 默认 " + "1000".AddYellow());
                m_Tools.Text_G("  3. 优先级高 " + "11".AddYellow() + " 及以上,会创建一个分割线");
            });
        }


        private void DrawCPD()                                  // CustomPropertyDrawer
        {
            m_Tools.Text_L("修改 " + "单个 ".AddYellow() + "属性面板");
            m_Tools.BiaoTi_B("构造函数");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("[CustomPropertyDrawer(type 类、特性、基础类型、enum 都行)]");
                m_Tools.Text_B("[CustomPropertyDrawer(type ,bool 衍生类是否应用该特性)]");

            });

        }



        private void DrawAU()                                    // AttributeUsage
        {  
            m_Tools.BiaoTi_L("先写个 特性类"+"(补参数，补构造)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("[AttributeUsage(...)]  ->  给这个 特性类 加限制");
                MyCreate.SelectText("    class xxxAttribute : PropertyAttribute");
            });
            AddSpace_3();
            m_Tools.BiaoTi_Y("AttributeUsage 构造");
            MyCreate.Box(() =>
            {
                MyCreate.Text("唯一构造：");
                m_Tools.Text_B("[AttributeUsage(", "AttributeTargets ".AddYellow(),"限制特性作用于那些类型", ONE, ")]");
                MyCreate.Text("但还有 2个 属性"+" (通过属性直接赋值)");
                m_Tools.Text_B("[AttributeUsage(AttributeTargets，", "AllowMultiple = false".AddYellow(), TWO, ")]");
                m_Tools.Text_B("[AttributeUsage(AttributeTargets，", "Inherited = false".AddYellow(), THREE, ")]");
            });
            AddSpace_3();

            m_Tools.BiaoTi_B("AttributeTargets 限制特性作用于那些类型"+ONE);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L(" 这是个 ","带 flag 标签的枚举".AddGreen(),"，所以可以应用下面的"+"多个参数".AddGreen());
                m_Tools.Text4_B(" All"," 任何程序元素 ","Assembly"," 程序集 ",20);
                m_Tools.Text4_B(" Class"," 类 ","Constructor"," 构造函数 ", 20);
                m_Tools.Text4_B(" Delegate"," 委托 ","Enum"," 枚举 ", 20);
                m_Tools.Text4_B(" Event"," 事件 ","Field"," 字段 ", 20);
                m_Tools.Text4_B(" GenericParamerter"," 泛型参数 ","Interface"," 接口 ", 20);
                m_Tools.Text4_B(" Method"," 方法 ","Module"," 模块 ", 20);
                m_Tools.Text4_B(" Parameter"," 参数 ","Property"," 属性 ", 20);
                m_Tools.Text4_B(" ReturnValue"," 返回的值 ","Struct"," 结构体，类型值 ", 20);
            });

            AddSpace_3();
            m_Tools.BiaoTi_B("AllowMultiple" + TWO);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("  1. true -> ","允许可以添加多个该特性".AddGreen()," ，false -> 只能 1 个");
                m_Tools.Text_L("  2. 默认 false");

            });
            AddSpace_3();

            m_Tools.BiaoTi_B("Inherited" + TWO);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("  1. true -> 衍生类同样能有该特性作用");
                m_Tools.Text_L("  2. 默认 true");

            });

        }


        #endregion


        #region Editor -> 类



        private void DrawEditorLie()                            // Editor -> 类
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace();
                if (QUI.GhostButton("官方文档", QColors.Color.Orange, 80, 20, editStats.target))
                {
                    editStats.target = !editStats.target;
                }
                if (editStats.faded > 0.05f)
                {
                    if (QUI.GhostButton("GUIContent", QColors.Color.Green, PS.databaseClearStatisticsButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://docs.unity3d.com/ScriptReference/GUIContent.html");
                    }
                    if (QUI.GhostButton("SerializedObject", QColors.Color.Blue, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://docs.unity3d.com/ScriptReference/SerializedObject.html");

                    }
                    if (QUI.GhostButton("SerializedProperty", QColors.Color.Orange, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                       Application.OpenURL("https://docs.unity3d.com/ScriptReference/SerializedProperty.html");
                    }
                }
            });
            m_Tools.BiaoTi_B("总结");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("SerializedObject"+ONE, "整个 class");
                m_Tools.TextText_BL("SerializedProperty"+TWO, "单个属性");
                m_Tools.TextText_BL("GUIContent" + THREE, "");
                m_Tools.TextText_BL("GUIStyle" + FOUR, "");

                m_Tools.TextText_BL("","");
            });

            m_Tools.BiaoTi_O("关于 3个很相似的类描述");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L(SerializedObjectStr, "     命名空间 -> UnityEditor", "  // 修改整个面板会提供".AddGreen());
                m_Tools.Text_L(SerializedPropertyStr, "  命名空间 -> UnityEditor","  // 修改单个属性会提供".AddGreen());
                m_Tools.Text_G("SerializedObject 对象能随时得到任意一个 SerializedProperty 属性");
                m_Tools.Text_L(ScriptableObjectStr, "    命名空间 -> UnityEngine ,继承 -> Object");


            });
            AddSpace_3();
            m_Tools.BiaoTi_O("官方例子");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("public class MyObject : " + ScriptableObjectStr, "// 就是 Bean 实现化", 30);
                m_Tools.Text_H("{");
                m_Tools.Text_H("     public int myInt = 42;");
                m_Tools.Text_H("}");
                AddSpace();
                MyCreate.Text("运行：");
                m_Tools.Text_H("MyObject obj = ", ScriptableObjectStr, ".CreateInstance<MyObject>();");
                m_Tools.TextText_HG(SerializedObjectStr + " so = new " + SerializedObjectStr + "(obj);", "//整个对象", 180);
                m_Tools.TextText_HG(SerializedPropertyStr + " spInt = so.FindProperty(”myInt“);", "//单个属性", 180);
            });
        }


        private void DrawSerializedObject()                     // SerializedObject
        {
            m_Tools.BiaoTi_B("构造函数"+"(即这个类可以直接 new 出来)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LG("new SerializedObject( Object )","// 即组件、资源都可以");
            });
            AddSpace_3();
            m_Tools.BiaoTi_B("属性");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("targetObject", "只读","获得这个 Class 对象", "Object");
                m_Tools.Method_BL("targetObjects", "只读","如果是多个的情况", "Object[]");
                m_Tools.Method_BL("isEditingMultipleObjects", "只读", "列化对象是否表示多个对象？", "bool");
            });
            AddSpace_3();
            m_Tools.BiaoTi_B("方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("ApplyModifiedProperties", "", "应用 ".AddGreen()+"属性修改", "bool",60);
                m_Tools.Method_BL("ApplyModifiedPropertiesWithoutUndo", "", "在不注册撤消操作的情况下应用属性修改", "bool",60);
                m_Tools.Method_BL("CopyFromSerializedProperty", "SerializedProperty", "从属性中 -> 复制", "", 60);
                m_Tools.Method_OY("FindProperty", "string", "按名称查找序列化属性", "SerializedProperty", 60);
                m_Tools.Method_OY("GetIterator", "", "获取第一个序列化属性", "SerializedProperty", 60);
                m_Tools.Method_BL("Update", "", "更新".AddGreen()+"序列化对象的表示", "", 60);
            });


        }

        private void DrawSerializedP()                          // SerializedProperty
        {
            m_Tools.BiaoTi_O("属性");
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_B("xxxValue -> 获取对应的数值"+ "(相当于解包),可读可写".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("[ 这个 SerializedProperty 对应是 int 类型，那么使用 intValue 来解包出来 ]");
                    m_Tools.Text4_BL("boolValue", "bool", "floatValue", "float",10);
                    m_Tools.Text4_BL("intValue", "int", "stringValue", "string",10);
                    m_Tools.Text4_BL("vector3Value", "Vector3", "rectValue", "Rect",10);
                    m_Tools.Text4_BL("colorValue", "颜色", "enumValueIndex", "枚举索引 ->  int", 10);
                    m_Tools.Text4_BL("animationCurveValue", "动画曲线", "quaternionValue", "Quaternion", 10);
                });
                m_Tools.BiaoTi_B("读取信息"+"(只读)".AddGreen());
                MyCreate.Box(() =>
                {
                    m_Tools.Text4("displayName".AddGreen(), " (显示名称)".AddLightBlue(), "enumNames".AddGreen(), " (枚举名 string[])".AddLightBlue());
                    m_Tools.Text4("propertyType".AddLightBlue(), " (是那个类型)".AddHui(), "serializedObject".AddGreen(), " (对应的序列化类)".AddLightBlue());
                    m_Tools.Text4("tooltip".AddLightBlue(), " (鼠标悬浮的提示)".AddHui(), "enumDisplayNames".AddGreen(), " (枚举显示名 string[])".AddLightBlue());
                });
            });
        }


        #endregion


        #region 编辑 Static 类

        private void DrawStaticEditor()                          // Static 类 总结
        {
            m_Tools.BiaoTi_O("Selection "+ONE + "(点击选择 ->  反馈点击了那些对象)".AddYellow());
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Selection.html");
                m_Tools.Text_L("  包括 场景 中的，也包括 Project -> Assets 中的");
            });
            AddSpace();
            m_Tools.BiaoTi_O("EditorUtility "+TWO+"（编辑器中的实用功能）".AddYellow());
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/EditorUtility.html");
                m_Tools.Text_L("  1. 弹出个","进度条/提示框".AddGreen(),"/菜单");
                m_Tools.Text_L("  2. ","显示文件管理器 ".AddGreen(),"-> 可选择文件/文件夹，也可以保存记录");
                m_Tools.Text_L("  3. 特殊功能 -> 设置相机、复制Unity对象的所有设置、针对 Texture 等等");
            });
            AddSpace();

            m_Tools.BiaoTi_O("两个 自动布局 GUI 的 工具类");
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/EditorGUILayout.html", "EditorGUILayout");
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/EditorGUI.html", "EditorGUI");
                m_Tools.TextText_OY("EditorGUILayout "+THREE, "适合用于 写窗口",10);
                m_Tools.TextText_OY("EditorGUI " + FOUR, "适合用于 修改 Inspector 面板", 10);

            });


        }


        private void DrawSelection()                             // Selection 类
        {
            m_Tools.BiaoTi_B("Static 属性");
            MyCreate.Box(() =>
            {
                MyCreate.Text("返回一个");
                m_Tools.Method_BL("activeTransform", "", "只包含 Hierarchy 上的", "Transform");
                m_Tools.Method_BL("activeGameObject", "", "包括预制，其他返回null", "GameObject");
                m_Tools.Method_BL("activeObject", "", "所有激活的对象", "Object");
                MyCreate.Text("返回多个,结果同上");
                m_Tools.Method_BL("transforms", "", "选择所有，下面有选择", "Transform[]");
                m_Tools.Method_BL("gameObjects", "", "", "GameObject[]");
                m_Tools.Method_BL("objects", "", "", " Object[]");
            });
            AddSpace_3();
            m_Tools.BiaoTi_B("Static 方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_OY("GetTransforms", "SelectionMode", "", "Transform[]");
                m_Tools.Method_OY("GetFiltered", "Type，SelectionMode", "会过渡一些选择对象 ", "Object[]",15);
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("Asset 中 Type 类型包含以下：".AddHui());
                    m_Tools.Text4_B("   文件夹、Dll、Lua", " DefaultAsset ", "图片", " Texture2D ", 40);
                    m_Tools.Text4_B("   C# 脚本、txt", " MonoScript ", "预制、Model", " GameObject ", 40);
                    m_Tools.Text4_B("   场景", " SceneAsset ", "GUISkin", " GUISkin ", 40);
                    m_Tools.Text4_B("   Material", " Material ", "Shader", " Shader ", 40);
                });

            });
            m_Tools.BiaoTi_B("SelectionMode 选择模式 " + "(flag 枚举，即能多选)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text4_L("Unfiltered", "返回整个选择", "TopLevel", "只返回最上面的 Transform", 20);
                m_Tools.Text4_L("Deep", "返回选择的所有子 Transform", "ExcludePrefab", "排除选择中的任何 Prefab", 20);
                m_Tools.Text4_L("DeepAssets", "文件夹下的所有", "Editable", "排除不应修改的任何对象", 20);
                m_Tools.Text4_L("Assets", "仅返回属于 Asset 目录中资产的对象", "", "  ", 20);
            });
        }



        private void DrawEditorUtility()                         // EditorUtility
        {

            m_Tools.BiaoTi_B("Static 方法-> 弹出个进度条");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("DisplayProgressBar", "string 标题，string 提示，float 进度", "显示（不带取消按钮）", "", 150);
                m_Tools.Method_BY("DisplayCancelableProgressBar", "同上", "显示"+"具有取消按钮".AddGreen()+ "的进度条", "", 150);
                m_Tools.Method_BY("ClearProgressBar", "", "关闭"+"(上面任意一个用完都需要调用此)".AddGreen(), "", 150);
            });

            m_Tools.BiaoTi_B("Static 方法-> 弹出个提示框");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("DisplayDialog", "string 标题，string 提示，string true名，string false名", "  2 个按钮", "bool", 150);
                m_Tools.Method_BY("DisplayDialogComplex", "string，string，string 0名，string 1名，string 2名", "3 个按钮 提示框", "int", 150);
                
            });

            m_Tools.BiaoTi_B("Static 方法-> 显示文件管理器 -> 打开文件/文件夹/保存");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("打开文件/文件夹使用的是 OpenFilePanel、OpenFolderPanel");
                m_Tools.BiaoTi_L("我简单封装了下："+ "(使用 OpenWindow )".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("打开Windows资源管理器，并"+"选择一个文件".AddGreen());
                    m_Tools.Method_BW("ChooseFile", "string 默认打开的路径，out string 输出文件全路径", "","bool 成功返回 true");
                    m_Tools.Method_BW(ZhongZai+ "ChooseFile", "string 说明，string，out string","", "bool");
                    AddSpace_3();
                    MyCreate.Text("打开Windows资源管理器，并" + "选择一个文件夹".AddGreen());
                    m_Tools.Method_BW("ChooseFloder", "string 默认打开的路径，out string 输出文件全路径", "", "bool 成功返回 true");
                    m_Tools.Method_BW(ZhongZai + "ChooseFloder", "string 说明，string，out string", "", "bool");

                });
            });
            m_Tools.BiaoTi_B("Static 方法-> 特殊功能");

        }



        private void DrawGUIZhong()                             // 总结 GUI
        {
            m_Tools.BiaoTi_B("问题：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_O("GUI、GUILayout、EditorGUI、EditorGUILayout  区别");
                m_Tools.Text_L("    GUI".AddWhite()," -> UnityEngine 命名空间  -> 普通类");
                m_Tools.Text_L("    GUILayout".AddWhite()," -> UnityEngine 命名空间  -> 普通类");
                m_Tools.Text_L("    EditorGUI".AddWhite()," -> UnityEditor 编辑器命名空间  -> sealed 类");
                m_Tools.Text_L("    EditorGUILayout".AddWhite()," -> UnityEditor 编辑器命名空间  -> sealed 类");

                m_Tools.TextText_YB("程序/通用  ","-> GUI、GUILayout",-10);
                m_Tools.TextText_YB("窗口框框 ", "-> EditorGUILayout"+ "(我用 GUILayout ...)".AddGreen(),-10);
                m_Tools.TextText_YB("面板 Inspector ", "-> EditorGUI",-10);
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_O("又多了 GUIUtility 、EditorGUIUtility 类");

            });


        }

        private void DrawEditorGUI()                            // EditorGUI
        {


            m_Tools.BiaoTi_B("EditorGUI 特有的 Static 属性"+ "(EditorGUILayout 没有属性)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Method_OY("indentLevel", "", "字段标签的缩进级别"+"(不用空格)".AddGreen(), "int",-20);
            });



        }





        #endregion



        #region 修改属性 例子


        private void DrawZhongWen()                              // 将 枚举 修成中文
        {
            MyCreate.Box(() =>
            {
                MyCreate.Text("MyChinaEnum 特性 ： 没什么特别，就一个 string 属性".AddBlue());
                m_Tools.TextText_HG("[AttributeUsage(AttributeTargets.Field)]", "   // 只能作用于 枚举");
                m_Tools.Text_H("public class ", MyChinaEnumStr," : PropertyAttribute ");
                m_Tools.Text_H("     ->   string EnumTypeName   +  构造函数");

                MyCreate.Text("在任意枚举中的枚举分量添加 Header 特性 -> 设置的中文说明".AddBlue());
                m_Tools.Text_H("public enum ETestEnum");
                m_Tools.Text_H("{");
                m_Tools.Text_H("     [", HeaderStr,"(“枚举分量 1”)]   Enum1,");
                m_Tools.Text_H("     [", HeaderStr,"(“枚举分量 2”)]   Enum2,");
                m_Tools.Text_H("}");
                MyCreate.Text("使用 MyChinaEnum 特性 在需要的字段上面".AddBlue());
                m_Tools.Text_H("[","MyChinaEnum".AddYellow(),"(“中文名”)]   public ETestEnum Dotest;");
            });
            m_Tools.BiaoTi_O("Editor   ->  重点来了");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("[","CustomPropertyDrawer".AddYellow(),"(typeof(", MyChinaEnumStr,"))]");
                m_Tools.Text_H("这里写一个类 继承 PropertyDrawer -> 重写  OnGUI 方法");
                MyCreate.Text("OnGUI(Rect position,"+" SerializedProperty property".AddOrange()+", GUIContent label)  -> ");
                m_Tools.TextText_HG("if ("+ propertyStr+".propertyType != SerializedPropertyType.Enum)  return;", "// 不是枚举 滚开");
                m_Tools.TextText_HG("Type type = "+ propertyStr+".serializedObject.targetObject.GetType()", "// -> class 的 Type");
                m_Tools.TextText_HG("FieldInfo field = type.GetField("+ propertyStr+".name)", "// 从这个 class 查找这个字段");
                m_Tools.TextText_HG("Type enumtype = field.FieldType;", "               // -> 找到这个 枚举 的 Type");
                AddSpace();
                m_Tools.TextText_HG("string[] enumNames = "+ propertyStr+".enumNames;", "// 获得这个枚举所有枚举分量");
                m_Tools.TextText_HG("string[] "+ displayNameStr+" = new string[enumNames.Length];", "// 最终用于显示的 集合名称");
                AddSpace();

                m_Tools.Text_H("for (int i = 0; i < enumNames.Length; i++)");
                m_Tools.Text_H("{");
                m_Tools.Text_H("     FieldInfo enumfield = enumtype.GetField(enumNames[i]);");
                m_Tools.Text_H("     HeaderAttribute ".AddYellow(),"header = enumfield.GetAttribute<","HeaderAttribute".AddYellow(),">();");
                m_Tools.Text_H("     if (null != header)");
                m_Tools.Text_H("          "+ displayNameStr+"[i] = header.header;");
                m_Tools.Text_H("     else");
                m_Tools.Text_H("          "+ displayNameStr+"[i] = enumNames[i];");
                m_Tools.Text_H("}");
                m_Tools.Text_H(MyChinaEnumStr," att = (", MyChinaEnumStr,")attribute;");
                m_Tools.TextText_HG(propertyStr+".enumValueIndex = EditorGUI.Popup(","// 记得赋值回去",150);
                m_Tools.TextText_HG("                   position,", "// 用原来的位置",150);
                m_Tools.TextText_HG("                   att.EnumTypeName,", "// 使用 特性 的名称作为显示名", 150);
                m_Tools.TextText_HG("                   "+ propertyStr+".enumValueIndex,", "// 索引用回索引", 150);
                m_Tools.TextText_HG("                   "+ displayNameStr+")", "// 使用上面的中文集合", 150);
            });

        }


        #endregion


        #region 编辑面板

        private void DrawMainBanZhongJie()                        // 面板总结
        {
             
        }



        private void DrawZhiJie()                                // 生成窗口
        {
            m_Tools.Text_G("   继承 ScriptableObject");

            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BL("maximized", "", "设定是否最大化", "bool");
                m_Tools.Method_BL("maxSize/minSize", "", "最大/最小 多大", "Vector2(宽、高)");
                m_Tools.Method_BL("position", "", "窗口位置", "Rect");
                m_Tools.Method_BL("titleContent", "", "标题", "GUIContent");

            });
            MyCreate.MethodWindow(() =>
            {
                m_Tools.Method_BY("Close", "", "关闭窗口");
                m_Tools.Method_BY("Repaint", "", "使窗口重画", "");
            });

        }

        private void DrawInspector()                             // 修改面板
        {
            m_Tools.BiaoTi_B("使用 AbstractInspector " + "(不能对 UGUI 修改)".AddLightBlue());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("[", "CustomEditor".AddYellow(), "(typeof(组件))]");
                m_Tools.Text_H("internal sealed class 类名 : ", "AbstractInspector<组件> ".AddYellow());
                AddSpace_3();
                m_Tools.Text_H("    protected override void OnEditorGUI(Image bean)");
                m_Tools.Text_H("    {");
                m_Tools.TextText_YG("          AddBaseInspector();", "  // 使用原来的面板");
                m_Tools.Text_H("    }");
                AddSpace_3();
                m_Tools.Text_H("    protected override void ", "OnSceneGui".AddYellow(), "()", "  // 场景视图 GUI".AddGreen());
                m_Tools.Text_H("    {");
                m_Tools.Text_H("        base.OnSceneGui();");
                m_Tools.Text_H("    }");
            });
            AddSpace();
            m_Tools.BiaoTi_B("重写 UGUI " + "(新建一个类，继承 UI 组件，再编辑新类面板)".AddLightBlue());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public class ", "MyImage".AddYellow(), " : ", "Image".AddYellow());
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("[CustomEditor(typeof(", "MyImage".AddYellow(), "))]");
                m_Tools.Text_H(" internal sealed class MyImageEditor: " + "ImageEditor".AddYellow());
                AddSpace_3();
                m_Tools.Text_H("    public override void OnInspectorGUI()");
                m_Tools.Text_H("    {");
                m_Tools.TextText_HG("          base.OnInspectorGUI();", " // 或者用DrawDefaultInspector()");
                m_Tools.TextText_HG("          if (GUILayout.Button(\"按钮\"))", " // 用法一样");
                m_Tools.Text_H("    }");

            });

        }



        private void DrawAttIn()                                 // 通过特性修改面板
        {
            m_Tools.BiaoTi_B("通过自定义特性调整 Inspector 面板", ref isUse, () =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.Text("第一步写个特性类" + "（ 使用方法与 Bean 相同）".AddLightGreen());
                    m_Tools.Text_Y("继承" + " PropertyAttribute".AddGreen() + "，与 Bean 相同（补参数，补构造）", ref isPropertyAttribute, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_G("自定义特性类（非Unity面板）" + "继承 Attribute + 加规则".AddYellow());
                            m_Tools.Text_G("然后通过" + "反射".AddYellow() + "来获取信息再修改");
                        });
                    });
                    MyCreate.Text("加规则:".AddGreen());
                    m_Tools.Text_Y("[" + "AttributeUsage".AddGreen() + " AttributeTargets(+AllowMultiple + Inherited)]", ref isAttributeUsage, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_B("AttributeTargets ".AddYellow(), "规定在那个头上,具体在下");
                            m_Tools.Text_B("AllowMultiple ".AddYellow(), "是否允许加多个这特性 ", "(默认 false)".AddLightBlue());
                            m_Tools.Text_B("Inherited".AddYellow(), " 是否用在继承类也能用 ", "(默认 true)".AddLightBlue());
                        });
                    });
                    m_Tools.Text_Y("AttributeTargets ".AddGreen() + "的成员：", ref isTuJie, () =>
                    {
                        ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712000159954-1776954843.png");
                    });

                    MyCreate.Text("第二步编写 Editor 使用 PropertyDrawer 或 DecoratorDrawer");
                });
            });

            MyCreate.Text("[CustomPropertyDrawer(typeof(特性))]".AddLightBlue());
            m_Tools.ButtonText("PropertyDrawer", "每个字段是怎么样的", ref isPropertyDrawer, () =>
            {
                m_Tools.Text_G("1.重写 OnGUI 方法");
                m_Tools.Text_H(" OnGUI（Rect 方框, SerializedProperty 属性, GUIContent 设计）");
                m_Tools.TextUrl("2.使用 EditorGUI 来设计属性", "打开EditorGUI文档", "https://docs.unity3d.com/ScriptReference/EditorGUI.html");
                m_Tools.Text_G("3.普通的不带属性使用 GUI");
                m_Tools.Text_G("图解", ref isTu, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712000444215-173385113.png");
                });
            });
            m_Tools.ButtonText("DecoratorDrawer", "字段上面的GUI" + "（如Space、Header）".AddLightBlue(), ref isDecoratorDrawer, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712000504066-1563483384.png");
            });

        }

        #endregion



        private void DrawHierarchyShow()                        // 修改 Hierarchy 显示
        {
            m_Tools.BiaoTi_O("在场景对象的最右侧添加图标");
            m_Tools.BiaoTi_B("1. 创建一个普通的类，使用 InitializeOnLoad 特性");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_OG("[InitializeOnLoad]"," // Unity 启动 -> 调用 Static 构造",50);
                m_Tools.Text_H("public class 随便名字的普通类");
                m_Tools.Text_H("{");
                m_Tools.TextText_HG("     private static Texture2D icon", "// 图片",50);
                m_Tools.TextText_HG("     static 随便名字的普通类", "// Static 构造",50);
                m_Tools.Text_H("    {");
                m_Tools.Text_H("         icon = (Texture2D) Resources.Load(“图片名”);");
                m_Tools.Text_B("         // 要运行的 核心代码 如下↓");
                m_Tools.Text_H("    }");
                m_Tools.Text_H("}");
            });

            m_Tools.BiaoTi_B("2. 核心代码");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("EditorApplication.HierarchyWindowItemCallback callBack = ", DrawHierarchyIconStr);
                m_Tools.Text_L("EditorApplication.hierarchyWindowItemOnGUI = ");
                m_Tools.Text_L("        (EditorApplication.HierarchyWindowItemCallback)Delegate.Combine");
                m_Tools.Text_L("        (EditorApplication.hierarchyWindowItemOnGUI, callBack);");

            });

            m_Tools.BiaoTi_B("2.1. "+ DrawHierarchyIconStr+" 回调方法");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("private static void ", DrawHierarchyIconStr,"(int instanceID, Rect selectionRect)");
                m_Tools.Text_H("{");
                m_Tools.Text_H("    GameObject gameObject = (GameObject)");
                m_Tools.TextText_HG("          EditorUtility.InstanceIDToObject(instanceID);","  // 获得场景中的对象");
                m_Tools.Text_H("    Rect rect = new Rect");
                m_Tools.Text_H("          (selectionRect.x + selectionRect.width - 16f, selectionRect.y, 16f, 16f)");
                m_Tools.Text_H("    if(gameObject.GetComponent<","脚本".AddWhite(),">() != null)");
                m_Tools.Text_H("    {");
                m_Tools.Text_H("        GUI.DrawTexture(rect, icon);");
                m_Tools.Text_H("    }");
                m_Tools.Text_H("}");

            });
        }


        private void DrawGizmos()                                // Gizmos
        {
            m_Tools.BiaoTi_O("Mono 中关于 Gizmos 的回调函数");
            m_Tools.TextText_OY("OnDrawGizmos", " 场景中总是显示");
            m_Tools.TextText_OY("OnDrawGizmosSelected", " 只有选中有该组件的游戏对象才显示");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_G("    1. 生命周期在 LateUpdate、场景渲染 之后 ，在 OnGUI 之前");
                m_Tools.Text_G("    2. 组件在 Inspector 折叠不会调用函数");

            });
            AddSpace();
            m_Tools.BiaoTi_B("Static 属性");
            MyCreate.Box(() =>
            {
                m_Tools.Text4_BW( "   color", "颜色", "matrix", "矩阵", 20);
            });

            m_Tools.BiaoTi_B("Static 方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("DrawCube", "Vector3 中心点,Vector3 大小", "实体 Cube", "", 140);
                m_Tools.Method_YL("DrawWireCube", "Vector3 中心点,Vector3 大小", "虚线 Cube", "", 140);
                m_Tools.Method_YL("DrawGUITexture", "Rect，Texture", "纹理", "", 140);
                m_Tools.Method_YL("DrawIcon", "Vector3 中心点, string 文件路径名", "图标", "", 140);
                m_Tools.Method_YL(ZhongZai + "DrawIcon", "Vector3，string，bool", "");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HW("     center", "图标在世界空间中的位置", -20);
                    m_Tools.TextText_HW("     name", "Assets / Gizmos文件夹中的名 (包含后缀)", -20);
                    m_Tools.TextText_HW("     allowScaling", "是否允许缩放图标(默认允许)", -20);
                });
                m_Tools.Method_YL("DrawLine", "Vector3 始点, Vector3 终点", "线", "", 140);
                m_Tools.Method_YL("DrawRay", "Ray", "射线", "", 140);
                m_Tools.Method_YL("DrawSphere", "Vector3 中心点, float 半径", "实心球", "", 140);
                m_Tools.Method_YL("DrawWireSphere", "Vector3 中心点, float 半径", "虚线球", "", 140);
                m_Tools.Method_YL("DrawMesh", "", "实体网格", "", 140);
                m_Tools.Method_YL("DrawWireMesh", "", "虚线网格", "", 140);
                m_Tools.Method_YL("DrawFrustum", "", "锥体", "", 140);
            });
        }




    }

}

