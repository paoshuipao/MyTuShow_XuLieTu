using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class JiLu_MyUtil : AbstactNewKuang
    {

        [MenuItem(LearnMenu.MyUtil)]
        static void Init()
        {
            JiLu_MyUtil instance = GetWindow<JiLu_MyUtil>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {
            #region StaticUtil

            bool isExe = (type == EType.Static || type == EType.Static1 || type == EType.Static2 || type == EType.Static3 || type == EType.Static4 || type == EType.Static5 || type == EType.Static6 || type == EType.Static7);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "StaticUtil";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isExe ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Static1);
            }

            if (isExe)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Static1 ? "  MyAssetUtil".AddBlue() : "  MyAssetUtil");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Static1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Static2 ? "  MyColor".AddBlue() : "  MyColor");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Static2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Static3 ? "  MyGUI".AddBlue() : "  MyGUI");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Static3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Static4 ? "  MyIO".AddBlue() : "  MyIO");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Static4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Static5 ? "  MyRandom".AddBlue() : "  MyRandom");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Static5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Static6 ? "  MyType".AddBlue() : "  MyType");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Static6);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Static7 ? "  MyWebDownLoader".AddBlue() : "  MyWebDownLoader");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Static7);
                }

            }

            #endregion


            AddSpace();

            #region 数据结构

            bool isWeb = (type == EType.ShuJuJieGuo || type == EType.ShuJuJieGuo1 || type == EType.ShuJuJieGuo2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "数据结构";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isWeb ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.ShuJuJieGuo);
            }

            if (isWeb)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ShuJuJieGuo1 ? "  MyDictionary".AddBlue() : "  MyDictionary");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ShuJuJieGuo1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ShuJuJieGuo2 ? " MyHuoCheTou".AddBlue() : "  MyHuoCheTou");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ShuJuJieGuo2);
                }

            }

            #endregion


            AddSpace();

            #region 扩展方法

            bool isExensions = (type == EType.Exensions || type == EType.Exensions1 || type == EType.Exensions2 || type == EType.Exensions3 || type == EType.Exensions4 || type == EType.Exensions5 || type == EType.Exensions6 || type == EType.Exensions7 || type == EType.Exensions8);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "扩展方法";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isExensions ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Exensions1);
            }

            if (isExensions)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exensions1 ? "  数组 扩展".AddBlue() : "  数组 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exensions1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exensions2 ? "  字典 扩展".AddBlue() : "  字典 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exensions2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exensions5 ? "  List 扩展".AddBlue() : "  List 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exensions5);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exensions3 ? "  Transform 扩展".AddBlue() : "  Transform 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exensions3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exensions4 ? "  GameObject 扩展".AddBlue() : "  GameObject 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exensions4);
                }


                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exensions6 ? "  string 扩展".AddBlue() : "  string 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exensions6);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exensions7 ? "  Vector 扩展".AddBlue() : "  Vector 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exensions7);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exensions8 ? "  Camera 扩展".AddBlue() : "  Camera 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exensions8);
                }
            }

            #endregion


            AddSpace();

            #region Editor

            bool isEditor = (type == EType.Editor || type == EType.Editor1 || type == EType.Editor2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "PSPEditor";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isEditor ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Editor1);
            }

            if (isEditor)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Editor1 ? "  LoadRes".AddBlue() : "  LoadRes");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Editor1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Editor2 ? " OpenWindow".AddBlue() : "  OpenWindow");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Editor2);
                }

            }

            #endregion


        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Static:
                    break;
                case EType.Static1:
                    break;
                case EType.Static2:
                    break;
                case EType.Static3:
                    break;
                case EType.Static4:
                    break;
                case EType.Static5:
                    break;
                case EType.Static6:
                    break;
                case EType.Static7:
                    break;
                case EType.ShuJuJieGuo:
                    break;
                case EType.ShuJuJieGuo1:
                    break;
                case EType.ShuJuJieGuo2:
                    break;
                case EType.Exensions1:         DrawRightPage1(DrawArrayKZ);         break;
                case EType.Exensions2:         DrawRightPage3(DrawDicKZ);           break;
                case EType.Exensions3:         DrawRightPage4(DrawListKZ);          break;
                case EType.Exensions4:         DrawRightPage5(DrawTransformKZ);     break;
                case EType.Exensions5:         DrawRightPage6(DrawGameObjectKZ);    break;
                case EType.Exensions6:         DrawRightPage7(DrawStringKZ);        break;
                case EType.Exensions7:         DrawRightPage8(DrawVectorKZ);        break;
                case EType.Exensions8:         DrawRightPage1(DrawCameraKZ);        break;
                case EType.Editor:
                    break;
                case EType.Editor1:
                    break;
                case EType.Editor2:
                    break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
            }
        }



        #region 私有

        private bool isStringGeShiy, isFormatString, isIsAttackRange, isGetAssetsBackPath;
        private bool isSingleton_Mono, isSingleton_New;

        private enum EType
        {
            Static,Static1,Static2,Static3,Static4,Static5,Static6,Static7,
            ShuJuJieGuo, ShuJuJieGuo1, ShuJuJieGuo2,
            Exensions, Exensions1, Exensions2, Exensions3, Exensions4, Exensions5,Exensions6, Exensions7, Exensions8,

            Editor, Editor1, Editor2,

        }


        private EType type = EType.Static1;

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
            return "记录";
        }



        #endregion



        private void DrawMyType()                                // MyType
        {
            m_Tools.BiaoTi_O("反射 Type 工具类");
            m_Tools.Method_BY("GetType", "", "", "Type");

        }

        private void DrawMyColor()                               // MyColor
        {
            m_Tools.BiaoTi_O("MyColor  " + "(关于 颜色 的工具类)".AddGreen());
            m_Tools.Method_BY("GetColor", "string #FFFFFFFF/#FFFF 格式", "rgba/Rrrggbbaa", "Color", 80);
            m_Tools.Method_BY("GetColor", "int r，int g，int b，int a", "每个 0 到 255", "Color", 80);
            m_Tools.Method_BY("GetColor", "MyEnumColor", "能过枚举", "Color", 80);
            AddSpace();
            m_Tools.Method_BY("GetColorString", "MyEnumColor", "枚举 -> “#ffffffff”", "string", 80);
            m_Tools.Method_BY("GetEnumColor", "string，ref MyEnumColor", "通过字符串返回枚举", "bool", 80);
            MyCreate.Box(() =>
            {
                MyCreate.Text("现包含的字符串有：");
                m_Tools.Text_L("red、blue、green、white、yellow、orange");
                m_Tools.Text_L("其他不包含的，返回 false");
            });

        }

        private void DrawMyAssetUtil()                           // MyAssetUtil
        {
            m_Tools.BiaoTi_O("MyAssetUtil  " + "(关于 Asset 路径的工具类)".AddGreen());
            m_Tools.BiaoTi_L("工程 Application.dataPath ：" + "E:/Pro/PSPFramework/Assets".AddYellow());
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("GetApplicationDataPathNoAssets()", "", "E:/Pro/", "Data不带Assets", 80);

            });
            AddSpace();
            m_Tools.BiaoTi_L("下面都以" + " E:/Pro/PSPFramework/Assets/Text.cs".AddYellow() + " 作为全路径参数");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("GetAssetsBackPath", "string", "Assets/Text.cs", "Assets后路径", ref isGetAssetsBackPath,
                    () =>
                    {
                        m_Tools.Method_BY("GetAssetsBackPath", "string[] 全路径数组", "可以多个", "string[]", 80);

                    }, 80);
                m_Tools.Method_BY("GetAssetsProPath", "string", "E:/Pro/PSPFramework/", "Assets前路径", 80);
                m_Tools.Method_BY("GetFileNameByFullName", "string", "Text.cs", "文件名带后缀", 80);
                m_Tools.Method_BY("GetFileNameByFullNameNoSuffix", "string", "Text", "文件名没后缀", 80);
                m_Tools.Method_BY("GetFileSuffix", "string", "cs", "文件后缀", 80);
            });
            AddSpace();
            m_Tools.BiaoTi_L("下面都以" + " Assets/Text.cs".AddYellow() + " 作为参数");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("GetFullName", "string", "E:/Pro/PSPFramework/Assets/Text.cs", "Assets路径 ->全路径", -55);
            });
        }

        private void DrawSingleton()                             // 单例基类
        {
            m_Tools.BiaoTi_B("Singleton_Mono<T>   " + "继承Mono的 单例".AddLightBlue() + "(DontDestroyOnLoad)".AddGreen(), ref isSingleton_Mono,
                () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_G("1. 跳场景不会销毁的");
                        m_Tools.Text_G("2. 调用 Instance 会自动添加在场景中，不需要手动添加到场景中");
                    });
                });
            MyCreate.Box(() =>
            {
                MyCreate.Text("public 全局调用");
                m_Tools.Text_L("public GameObject", " CacheGameObject".AddYellow());
                m_Tools.Text_L("public Transform ", "   CacheTransform".AddYellow());
            });
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("protected virtual 给子类继承用的");
                m_Tools.Text_H("void ", "OnAwake()".AddWhite());
                m_Tools.Text_H("void ", "OnStart()".AddWhite());
                m_Tools.Text_H("void ", "OnUpdate(float deltaTime)".AddWhite());
                m_Tools.Text_H("void ", "OnFixedUpdata()".AddWhite());
                m_Tools.TextText_HG("void " + "OnJumpScene()".AddWhite(), "// 每次跳场景都调用一次");
                m_Tools.Text_H("void ", "OnDestroy2Do()".AddWhite());
            });
            AddSpace_15();
            m_Tools.BiaoTi_B("Singleton_New<T>   " + "New 出来的 单例".AddLightBlue() + "(不适合多线程使用)".AddGreen(), ref isSingleton_New,
                () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_G("1. 缺点： 构造函数没有私有化，还是能用 new 出来");

                    });
                });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("protected virtual void ", "Init()".AddWhite());

            });
            MyCreate.AddSpace(18);
            m_Tools.BiaoTi_B("扩展：单例与 static 类的区别");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("   单例类", "        Static 工具类");
                m_Tools.TextText_WL("有状态", "不保存状态", 20);
                m_Tools.TextText_WL("都能使用", "仅提供一些静态方法或静态属性来使用", 20);
                m_Tools.TextText_WL("可以有子类继承，能多态", "不可继承多态", 20);
                m_Tools.TextText_WL("唯一的对象实例", "只不过是一些方法属性的集合", 20);
            });

        }


        #region 扩展方法

        private void DrawArrayKZ()                               // 数组扩展
        {
            m_Tools.BiaoTi_B("数组扩展" + "(即所有 [] 都有扩展)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("数组.AddArray", " T[] ", "在一个数组上再添加另一个数组", "T[]");
                m_Tools.Method_BL("数组.ForAdd2", "Action<T 第1个值, T 第2个值> 两个值的情况，Action<T> 1个值的情况", "");
            });
        }


        private void DrawDicKZ()                                 // 字典扩展
        {
            m_Tools.BiaoTi_Y("Dictionary 字典扩展");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YW("字典.RemoveWhere", "Func<T1,T2,bool>", "根据条件来删除", "Dictionary<T1,T2>", 60);
                m_Tools.Method_YW("字典.AddOrUpdate", "T1,T2", "重复添加 key 就更新 key 的值", "", 60);
                m_Tools.Method_YW("字典.ContainsKey2Do", "T1，string 不包含log，Action<T2>", "包含Key做什么", "", 30);
            });
        }


        private void DrawListKZ()                                // List 扩展
        {
            m_Tools.BiaoTi_B("List 扩展");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("集合.ForAdd2", "Action<T 第1个值, T 第2个值> 两个值的情况，Action<T> 1个值的情况", "");
            });


            AddSpace_15();
            m_Tools.BiaoTi_B("IList 扩展");

        }
        private void DrawTransformKZ()                           // Transform 扩展
        {
            m_Tools.Method_RG("展开范围者.IsAttackRange", "float 左右几米，float 前方几米，Transform 入侵者", "", "bool");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("检测入侵者是否入侵范围内 " + "（指甲刀展开正前范围，判断是否夏提雅进来了）".AddGreen());



            });
        }

        private void DrawGameObjectKZ()                          // GameObject 扩展
        {
            m_Tools.BiaoTi_O("GameObject 扩展");
            MyCreate.Box(() =>
            {
                m_Tools.Method_OY("go.GetOrAddComponent<T>", "", "获得组件,没有就添加组件", "T", 40);
                m_Tools.Method_OY("go.GetComponentNo2Log<T>", "", "获得组件,没有打 Log", "T", 40);
            });
        }


        private void DrawStringKZ()                              // string 扩展
        {
            MyCreate.Text("加密与解密");
            m_Tools.Method_BL("AddPassword", "string 密码=“58741236”", "带密码的加密字符串", "string", 60);
            m_Tools.Method_BL("ParsePassword", "string 密码=“58741236", "解密失败返源串", "string", 60);
            m_Tools.Method_BL("Md5AddPassword", "", "Md5加密", "string", 30);
            m_Tools.Method_BL("Md5ParsePassword", "", "Md5解密", "string", 30);
            MyCreate.Text("字符串的格式");
            m_Tools.Method_BL("GetStringGeShi", "", "判断全中文/全英文/中英混格式合", "StringGeShi", ref isStringGeShiy, () =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_OY("English", "全英文");
                    m_Tools.TextText_OY("China", "全中文");
                    m_Tools.TextText_OY("EnglishChinaMix", "中英混合");
                });
            });
            m_Tools.Method_BL("FormatString", "", "对中英格式化", "string", ref isFormatString, () =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("全英文情况：“thisIsCamelCase” -> “This Is Camel Case”");
                    m_Tools.Text_H("中英混合情况：“继承Object” -> “ 继承 Object”");
                });
            });
        }


        private void DrawVectorKZ()                             // Vector 扩展
        {

        }


        private void DrawCameraKZ()                              // Camera 扩展
        {
        }


        #endregion


        private void DrawPSPUtil()                               // PSPUtil
        {
            m_Tools.BiaoTi_B("Attribute" + "  特性(其他的用插件)".AddLightBlue());
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("MyHead", "string 头部说明文字，MyEnumColor 颜色，OffsetX X轴偏移", "");
            });
            AddSpace();
            m_Tools.BiaoTi_B("ErrorException" + "  抛出异常".AddLightBlue());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_RG("Error_DictionaryNoKey", "字典没有注册过对应的 Key", 20);
                m_Tools.TextText_RG("Error_ResourcesNoPath", "Resources 路径加载错误", 20);
                m_Tools.TextText_RG("Error_SwitchEnumNoDefines", "Switch case 枚举没有定义", 20);
            });
            AddSpace();
            m_Tools.BiaoTi_B("Exensions" + "  扩展方法 ->".AddLightBlue());
            AddSpace();
            m_Tools.BiaoTi_B("Singleton" + "  单例基类 ->".AddLightBlue());
            AddSpace();
            m_Tools.BiaoTi_B("StaticUtil" + "  工具类 ->".AddLightBlue());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_OY("MyAssetUtil", "关于 Asset 路径的工具类");
                m_Tools.TextText_OY("MyIO", "");
                m_Tools.TextText_OY("MyColor", "关于 颜色 的工具类");
                m_Tools.TextText_OY("MyGUI", "");
                m_Tools.TextText_OY("MyType", "");
            });


        }


        private void DrawOpenWindow()                            // OpenWindow
        {


        }

        private void DrawMyClick()                               // MyClick
        {


        }

        private void DrawLoadRes()                               // LoadRes
        {

        }

    }

}

