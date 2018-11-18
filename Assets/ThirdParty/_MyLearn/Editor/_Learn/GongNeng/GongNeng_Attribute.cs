using System;
using System.Collections.Generic;
using System.Linq;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Demos;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEngine;
using Object = UnityEngine.Object;
using ObjectFieldAlignment = Sirenix.OdinInspector.ObjectFieldAlignment;

using Random = UnityEngine.Random;

namespace UnityEditor
{
    public class GongNeng_Attribute : AbstractTreeKuang<GongNeng_Attribute>
    {

        [MenuItem(LearnMenu.GongNeng_TeiXin)]
        static void ShowWindow()
        {
            CreateWindow("记录 特性", 650, 550);
        }


        protected override void AddTree(OdinMenuTree tree)
        {
            tree.AddObjectAtPath("Unity 特性", null, false, MyEnumColor.Yellow);
            AddNew<MyBuJu>(tree, "自定义布局");
            AddNew<MyBuJu2>(tree, "自定义布局2");
            AddNew<TextTuiJin>(tree, "前文字推进");
            AddNew<MyNoNeed>(tree, "不需要变量也能显示");
            AddNew<MyDoList>(tree, "集合样式");
            AddNew<MyDoBtn>(tree, "按钮");
            AddNew<MyEnumEx>(tree, "枚举");
            AddNew<MyDoColor2>(tree, "颜色", MyEnumColor.Green);
            AddNew<MyDoShow>(tree, "显示 or 隐藏");
            AddNew<MyDoRead>(tree, "可改 or 不可改");
            AddNew<MyInFloat>(tree, "基础类型", "int、float");
            AddNew<MyDoGameObject>(tree, "基础类型", "GameObject");
            AddNew<MyDoColor>(tree, "特殊", "颜色取色");
            AddNew<MyDoProgress>(tree, "特殊", "水平的彩色条");
            AddNew<MyDoPath>(tree, "特殊", "取得文件或者文件夹路径");
            AddNew<MyDoBiaoGe>(tree, "特殊", "表格（不能实现）");
        }



        #region 私有
        #region l_Inspector 改变 Inspector
        private readonly SelectTextAddText2[] l_Inspector =
        {
            new SelectTextAddText2("[EnumToggleButtons]", "改变".AddRed()+"枚举的样式","枚举"),

            new SelectTextAddText2("[HideLabel]", "隐藏".AddBlue()+"前面的字段名称","所有字段"),

            new SelectTextAddText2("[ListDrawerSettings(NumberOfItemsPerPage = 5)]", "数组".AddBlue()+"用这个","数组"),

            new SelectTextAddText2("[ReadOnly]", "暴露的字段"+"只可读".AddBlue()+"不可写","所有字段"),

            new SelectTextAddText2("[ContextMenuItem(\"按键名\", \"方法名称\")]","在字段上加一个"+"右键按钮".AddLightBlue(),"所有字段", () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711231342852-1456919447.png");
            }),
            new SelectTextAddText2(" [ContextMenu(\"按键名\")]","在方法上加一个"+"右键按钮".AddLightBlue(),"方法", () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711231441750-1416717158.png");
            }),
            new SelectTextAddText2("[TextArea(最小行数, 最大行数)]", "可滚动的文本区域编辑字符串","string", () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711231546839-1646848593.png");
            }),
            new SelectTextAddText2("[MultiLineProperty(行数)]", "插件扩展：多行编辑框".AddOrange(),"string 字段+属性"),
            new SelectTextAddText2("[Multiline(行数)]", "多行文本框编辑字符串"+"(用TextArea更好)".AddLightGreen(),"string"),
            new SelectTextAddText2("[Tooltip(\"string\")]", "鼠标移到有"+"提示".AddLightBlue(),"所有字段"),
            new SelectTextAddText2("[Header(\"string\")]", "字段上面增加Header"+"提示".AddLightBlue(),"所有字段"),
            new SelectTextAddText2("[Range(最小值,最大值)]", "数值滑动条","float、int、byte"),
            new SelectTextAddText2("[MinValue/MinValue(int)]", "限定最大值/最小值","float、int、byte"),
            new SelectTextAddText2("[ShowInInspector]", "插件扩展：Private protected 的字段也会显示出来".AddOrange(),"字段+属性"),
            new SelectTextAddText2("[SerializeField]", "Private protected 的字段也会显示出来","所有字段"),
            new SelectTextAddText2("[HideInInspector]", "Public也会隐藏属性","所有字段"),
            new SelectTextAddText2("[Serializable]", "序列化Class struct,可将它们显示出来","Class、struct", () =>
            {
                 ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711231738502-725084601.png");
            }),

            new SelectTextAddText2("[Space(空格数)]", "增加空位","所有字段"),

        };
        #endregion

        #region l_Mono 继承MonoBehaviour的组件Class使用
        private readonly SelectTextAddText2[] l_Mono =
        {
            new SelectTextAddText2("[AddComponentMenu(\"我的组件\")]", "在Component的Menu中增加自定义的项目","MonoBehaviour"),
            new SelectTextAddText2("[ExecuteInEditMode]", "不用运行，也可以运行Update和LateUpdate","MonoBehaviour", () =>
            {
               ShowImage("https://images2018.cnblogs.com/blog/959112/201808/959112-20180808221955715-590724908.png");
            }),
            new SelectTextAddText2("[DisallowMultipleComponent]", "禁止重复添加这个组件","MonoBehaviour"),
            new SelectTextAddText2("[RequireComponent(typeof(其它组件))]", "此组件的必需要添加的其它组件","MonoBehaviour"),
        };
        #endregion

        #region l_Editor Editor
        private readonly SelectTextAddText2[] l_Editor =
        {
            new SelectTextAddText2("[MenuItem(\"string %ctrl,#shift,&alt\")]", "Editor菜单","static 方法"),
            new SelectTextAddText2("[CustomEditor(typeof(class组件))]", "改class组件的Inspector面板","class"),
            new SelectTextAddText2("[CanEditMultipleObjects]", "同时选择多个 GameObject 也能进行编辑","class"),
        };
        #endregion

        #region l_System System
        private readonly SelectTextAddText2[] l_System =
        {
            new SelectTextAddText2("[Obsolete]", "标记为过时了","所有都可以"),
            new SelectTextAddText2("[Flags]","使用 | 表示多种的复合状态的枚举","enum", () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711233500209-2084986290.png");
            }),

            new SelectTextAddText2("[NotNull]","提示不能为空","方法参数"),
        };

        #endregion



        protected override void OnInit()
        {
            base.OnInit();
            l_AllTextAttribute = new List<SearchText>();
            l_AllTextAttribute.AddRange(l_Inspector);
            l_AllTextAttribute.AddRange(l_Mono);
            l_AllTextAttribute.AddRange(l_Editor);
            l_AllTextAttribute.AddRange(l_System);
        }

        private readonly ZuHeTool m_Tools = new ZuHeTool(50);

        protected override void OnNullGUI()
        {
            base.OnNullGUI();
            GUI.skin = LoadRes.ResourcesSkin;
            DrawUnityAtt();

        }





        private bool isInspector = true, isMonoBehaviour, isEditorr, isSystem, isOpen;
        private string m_Input;
        private List<SearchText> l_AllTextAttribute;
        private Vector2 m_Position;


        private void Item(string itemName, ref bool isShow, SelectTextAddText2[] l_SearchText)
        {
            m_Tools.BiaoTi_B(itemName, ref isShow, () =>
            {
                foreach (SelectTextAddText2 searchText in l_SearchText)
                {
                    searchText.Show(m_Tools, m_Input);
                }
            });
        }


        protected static void ShowImage(string path)
        {
            Texture2D texture = LoadRes.DownImage(path);
            if (null != texture)
            {
                Rect rect = GUILayoutUtility.GetRect(0f, 0f);
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


        protected void AddSearch(ref string input,               //加个搜索框,搜索第一个Text，不关下面GUI逻辑事
            List<SearchText> allText, Action action)
        {
            input = m_Tools.TextString("【 搜索 】".AddGreenBold(), input, () =>
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

        #endregion


        //————————————————————————————————————
#pragma warning disable
        #region 自定义布局1

        private class MyBuJu
        {

            [Title("优先级限定布局特性   [PropertyOrder(1)]")]
            public int 先写;

            [PropertyOrder(-1)]
            public int 后写优先;



            [Space(10)]
            [Title("加了布局", MyEnumColor.Blue)]
            [PreviewField]
            public Object RegularPreview;


            [VerticalGroup("row1/left")]
            public string A1, B1, C1;


            [HideLabel]
            [PreviewField(50, ObjectFieldAlignment.Right)]
            [HorizontalGroup("row1", 50), VerticalGroup("row1/right")]
            public Object D1;


            [HideLabel]
            [PreviewField(50, ObjectFieldAlignment.Left)]
            [HorizontalGroup("row2", 50), VerticalGroup("row2/left")]
            public Object E1;

            [VerticalGroup("row2/right"), LabelWidth(-54)]
            public string F1, G1, H1;


            [HideLabel] [Multiline(15)] [SuffixLabel("代码", true)]
            public string Test =
                "[VerticalGroup(\"row1/left\")]\n" +
                "public string A1, B1, C1;\n" +
                "\n" +
                "[HideLabel]\n" +
                "[PreviewField(50, ObjectFieldAlignment.Right)]\n" +
                "[HorizontalGroup(\"row1\", 50), VerticalGroup(\"row1/right\")]\n" +
                "public Object D1;\n" +
                "\n" +
                "[HideLabel]\n" +
                "[PreviewField(50, ObjectFieldAlignment.Left)]\n" +
                "[HorizontalGroup(\"row2\", 50), VerticalGroup(\"row2/left\")]\n" +
                "public Object E1;\n" +
                "\n" +
                "[VerticalGroup(\"row2/right\"), LabelWidth(-54)]\n" +
                " public string F1, G1, H1;\n" +
                "\n";
        }

        #endregion

        #region 自定义布局2

        private class MyBuJu2
        {

            [HorizontalGroup]
            public int A;

            [HideLabel, LabelWidth(150)]
            [HorizontalGroup(150)]
            public LayerMask B;

            [HorizontalGroup("Group 1", LabelWidth = 20)]
            public int C;

            [HorizontalGroup("Group 1")]
            public int D;

            [HorizontalGroup("Group 1")]
            public int E;

            [HorizontalGroup("Split", 0.5f, LabelWidth = 20)]
            [BoxGroup("Split/Left")]
            public int L;

            [BoxGroup("Split/Right")]
            public int M;

            [BoxGroup("Split/Left")]
            public int N;

            [BoxGroup("Split/Right")]
            public int O;

            [Space(5)]
            [HideLabel]
            [Multiline(25)]
            [SuffixLabel("代码", true)]
            public string Test =
                "[HorizontalGroup]\n" +
                "public int A;\n" +
                "\n" +
                "[HideLabel, LabelWidth(150)]\n" +
                "[HorizontalGroup(150)]\n" +
                "public LayerMask B;\n" +
                "\n" +
                "[HorizontalGroup(\"Group 1\", LabelWidth = 20)]\n" +
                "public int C;\n" +
                "\n" +
                "[HorizontalGroup(\"Group 1\")]\n" +
                " public int D;\n" +
                "\n" +
                "[HorizontalGroup(\"Group 1\")]\n" +
                "public int E;\n" +
                "\n" +
                "[HorizontalGroup(\"Split\", 0.5f, LabelWidth = 20)]\n" +
                "[BoxGroup(\"Split/Left\")]\n" +
                "public int L;\n" +
                "\n" +
                "[BoxGroup(\"Split/Right\")]\n" +
                "public int M;\n" +
                "\n" +
                "[BoxGroup(\"Split/Left\")]\n" +
                "public int N;\n" +
                "\n" +
                "[BoxGroup(\"Split/Right\")]\n" +
                "public int O;\n" +
                "\n" +
                "\n";


        }

        #endregion


        #region 前文字推进
        private class TextTuiJin
        {

#if UNITY_EDITOR

            [Indent]
            public int A;
            [Indent(2)]
            public int B;
            [Indent(3)]
            public int C;

            [Indent(4)]
            public int D;

            [Indent]
            public int E;

            [Indent(0)]
            public int F;

            [Indent(-1)]
            public int G;


            [HideLabel]
            [Multiline(15)]
            [SuffixLabel("代码", true)]
            public string Test = "[Indent]\n" +
                                 "public int A;\n" +
                                 "\n"+
                                 "[Indent(2)]\n" +
                                 "public int B;\n" +
                                 "\n" +
                                 "[Indent(3)]\n" +
                                 "public int C;\n"+
                                 "\n" +
                                 "[Indent(4)]\n" +
                                 "public int D;\n" +
                                 "\n" +
                                 "\n" +
                                 "\n";
#endif
        }


        #endregion


        #region 不需要变量也能显示
        private class MyNoNeed
        {

#if UNITY_EDITOR
            [PropertyOrder(int.MinValue), OnInspectorGUI]
            private void DrawTitle()
            {
                AllEditorGUI.Title("1. Title      记得使用 #if UNITY_EDITOR", "", TextAlignment.Left, false);
            }


            [PropertyOrder(int.MinValue), OnInspectorGUI]
            private void DrawIntroInfoBox()
            {
                AllEditorGUI.InfoMessageBox(" 1. InfoMessageBox");
            }


            [PropertyOrder(int.MinValue), OnInspectorGUI]
            private void DrawWarningMessageBox()
            {
                AllEditorGUI.WarningMessageBox("2. WarningMessageBox");
            }

            [PropertyOrder(int.MinValue), OnInspectorGUI]
            private void DrawErrorMessageBox()
            {
                AllEditorGUI.ErrorMessageBox("3. ErrorMessageBox");
            }





            [HideLabel]
            [Multiline(14)]
            [SuffixLabel("代码", true)]
            public string Test = "#if UNITY_EDITOR\n" +
                                 "using Sirenix.OdinInspector;\n" +
                                 "using Sirenix.Utilities.Editor;\n" +
                                 "#endif\n" +
                                 "\n" +
                                 "#if UNITY_EDITOR\n" +
                                 "    [PropertyOrder(int.MinValue), OnInspectorGUI]\n" +
                                 "     private void DrawTitle()\n" +
                                 "    {\n" +
                                 "        AllEditorGUI.InfoMessageBox(\" 文字\");\n" +
                                 "    }\n" +
                                 "#endif";



#endif
        }


        #endregion


        #region 集合样式


        private class MyDoList
        {
            [Title("自定义结构体    （下面为结构体数组 Struct[]）", MyEnumColor.Green)]
            public SomeOtherStruct[] StructList=new []
            {
                new SomeOtherStruct()
            };

            [Multiline(15), HideLabel]
            [SuffixLabel("代码", true)]
            public string Test = "[System.Serializable]\n" +
                                 "public struct 自定义结构体{\n" +
                                 "      [HorizontalGroup(\"Split\", 55), PropertyOrder(-1)]\n" +
                                 "      [PreviewField(50,ObjectFieldAlignment.Left)]\n" +
                                 "      [HideLabel]\n" +
                                 "      public UnityEngine.MonoBehaviour SomeObject;\n" +
                                 "\n" +
                                 "      [FoldoutGroup(\"Split/$Name\", false)]\n" +
                                 "      public string 名字;\n" +
                                 "\n" +
                                 "      FoldoutGroup(\"Split/$Name\", false)]\n" +
                                 "      public Sprite 图片;\n" +
                                 "\n" +
                                 "      private string Name { get { return this.SomeObject ? this.SomeObject.name : \"Null\"; } } }\n";

            [Space(12)]
            [Title("特性 【ListDrawerSettings()】 用法]")]
            [ListDrawerSettings(NumberOfItemsPerPage = 5)]
            public int[] FiveItemsPerPage;
            [Space(5)]

            [ListDrawerSettings(ShowIndexLabels = true, ListElementLabelName = "SomeString")]
            public SomeStruct[] IndexLabels;
            [Space(5)]
            [ListDrawerSettings(DraggableItems = false, Expanded = false, ShowIndexLabels = true, ShowPaging = false, ShowItemCount = false)]
            public int[] MoreListSettings = new int[] { 1, 2, 3 };
            [Space(5)]
            [ListDrawerSettings(OnBeginListElementGUI = "BeginDrawListElement", OnEndListElementGUI = "EndDrawListElement")]
            public SomeStruct[] InjectListElementGUI;
            [Space(5)]
            [ListDrawerSettings(HideAddButton = true, OnTitleBarGUI = "DrawAddButton")]
            public List<int> CustomButtons;


            private void BeginDrawListElement(int index)
            {
                AllEditorGUI.BeginBox(this.InjectListElementGUI[index].SomeString);
            }

            private void EndDrawListElement(int index)
            {
                AllEditorGUI.EndBox();
            }

            private void DrawAddButton()
            {
                if (AllEditorGUI.ToolbarButton(EditorIcons.Plus))
                {
                    CustomButtons.Add(Random.Range(0, 100));
                }

                Sirenix.Utilities.Editor.GUIHelper.PushGUIEnabled(GUI.enabled && this.CustomButtons.Count > 0);
                if (AllEditorGUI.ToolbarButton(EditorIcons.Minus))
                {
                    CustomButtons.RemoveAt(this.CustomButtons.Count - 1);
                }
                Sirenix.Utilities.Editor.GUIHelper.PopGUIEnabled();
            }


        }

        [System.Serializable]
        public struct SomeStruct
        {
            public string SomeString;
            public int One;
            public int Two;
            public int Three;
        }


        [System.Serializable]
        public struct SomeOtherStruct
        {
            [HorizontalGroup("Split", 55), PropertyOrder(-1)]
            [PreviewField(50,ObjectFieldAlignment.Left), HideLabel]
            public UnityEngine.MonoBehaviour SomeObject;

            [FoldoutGroup("Split/$Name", false)]
            public string 名字;

            [FoldoutGroup("Split/$Name", false)]
            public int A, B, C;


            [FoldoutGroup("Split/$Name", false)]
            public Sprite 图片;

            private string Name { get { return this.SomeObject ? this.SomeObject.name : "Null"; } }
        }

        #endregion


        #region 按钮
        private class MyDoBtn
        {


            // Horizontal Group also has supprot for: Title, MarginLeft, MarginRight, PaddingLeft, PaddingRight, MinWidth and MaxWidth.
            [HorizontalGroup("Button", MarginLeft = 0.25f, MarginRight = 0.25f)]
            public void SomeButton()
            {

            }


            [PropertyOrder(-1)]  // 优先级，不然方法一定在字段下面
            [Title("在方法上面直接添加 [Button] 特性", MyEnumColor.Yellow, false)]
            [Button(ButtonSizes.Large)]
            private void 方法加Button()
            {
                MyLog.Green("点击了 Button");
            }

            [ButtonGroup]
            private void A() { MyLog.Green("A");}

            [ButtonGroup]
            private void B() { MyLog.Green("B"); }

            [ButtonGroup]
            private void C() { MyLog.Green("C"); }

            [ButtonGroup]
            private void D() { MyLog.Green("D"); }

            [Button(ButtonSizes.Large)]
            [ButtonGroup("My Button Group")]
            private void E() { MyLog.Green("E"); }


            [GUIColor(0, 1, 0)]
            [ButtonGroup("My Button Group")]
            private void F() { MyLog.Green("F"); }

            [Title("这是添加在字段上的按钮", MyEnumColor.Yellow, false)]
            [InlineButton("ZiDun", "<- 字段按钮")]
            public int InlineButton;

            private void ZiDun()
            {
                MyLog.Blue("这是添加在字段上的按钮回调");
            }


            [PropertyOrder(20)]
            public bool Toggle;

            [Button(ButtonSizes.Small)]
            private void SmallButton()
            {
                MyLog.Green("小");
            }

            [Button(ButtonSizes.Medium)]
            private void MediumButton()
            {
                MyLog.Green("中");
            }

            [Button(ButtonSizes.Large)]
            private void LargeButton()
            {
                MyLog.Green("大");

            }

            [Button(ButtonSizes.Gigantic)]
            private void GiganticButton()
            {
                MyLog.Green("超大");

            }

            [Button(90)]
            private void Custom90SizedButton()
            {
                MyLog.Green("用数字来表示的大");
            }

            [DisableIf("Toggle")]
            [HorizontalGroup("Split", 0.5f)]
            [Button(ButtonSizes.Large), GUIColor(0.4f, 0.8f, 1)]
            private void FanzyButton1()
            {
                this.Toggle = !this.Toggle;
            }

            [HideIf("Toggle")]
            [VerticalGroup("Split/right")]
            [Button(ButtonSizes.Gigantic), GUIColor(0, 1, 0)]
            private void FanzyButton2()
            {
                this.Toggle = !this.Toggle;
            }

            [ShowIf("Toggle")]
            [VerticalGroup("Split/right")]
            [Button(ButtonSizes.Large), GUIColor(1, 0.2f, 0)]
            private void FanzyButton3()
            {
                this.Toggle = !this.Toggle;
            }
        }

        #endregion

        #region 枚举
        private class MyEnumEx
        {

            [Title("用枚举 或者 bool 来控制是否可改", null, TitleAlignments.Centered)]
            [EnumToggleButtons]
            public InfoMessageType SomeEnum;

            public bool IsToggled;

            [EnableIf("SomeEnum", InfoMessageType.Info)]
            public Vector2 Info;

            [EnableIf("SomeEnum", InfoMessageType.Error)]
            public Vector2 Error;

            [EnableIf("SomeEnum", InfoMessageType.Warning)]
            public Vector2 Warning;

            [EnableIf("IsToggled")]
            public int EnableIfToggled;

            [DisableIf("IsToggled")]
            public int DisableIfToggled;



            [Multiline(16), HideLabel]
            [SuffixLabel("代码", true)]
            public string Test2 = "[EnumToggleButtons]\n" +
                                  "public InfoMessageType SomeEnum;\n" +
                                  "\n" +
                                  "public bool IsToggled;\n" +
                                  "\n" +
                                  "[EnableIf(\"SomeEnum\", InfoMessageType.Info)]\n" +
                                  "public Vector2 Info;\n" +
                                  "\n" +
                                  "[EnableIf(\"SomeEnum\", InfoMessageType.Error)]\n" +
                                  "public Vector2 Error;\n" +
                                  "\n" +
                                  "[EnableIf(\"SomeEnum\", InfoMessageType.Warning)]\n" +
                                  "public Vector2 Warning;\n" +
                                  "\n" +
                                  "[EnableIf(\"IsToggled\")]\n" +
                                  "public int EnableIfToggled;\n" +
                                  "\n" +
                                  "[DisableIf(\"IsToggled\")]\n" +
                                  "public int DisableIfToggled;";


            [Space(10)]
            [Title("枚举的单选按钮", MyEnumColor.Yellow, false)]
            [EnumToggleButtons]
            public SomeEnum Enum单选;



            [SuffixLabel("代码", true)]
            [Multiline(3), HideLabel]
            public string text1 = 
                "     [EnumToggleButtons]\n"+
                "     public SomeEnum 枚举字段;";





            [Space(10)]
            [Title("多选按钮，同样是使用 EnumToggleButtons，只是枚举加了 Flags", MyEnumColor.Yellow, false)]
            [EnumToggleButtons]
            public SomeBitmaskEnum Enum多选 = SomeBitmaskEnum.A | SomeBitmaskEnum.B;

        }


        public enum SomeEnum
        {
            First, Second, Third, Fourth
        }

        [System.Flags]
        public enum SomeBitmaskEnum
        {
            A = 1 << 1,
            B = 1 << 2,
            C = 1 << 3,
            All = A | B | C
        }

        #endregion

        #region 颜色

        private class MyDoColor2
        {

            [PropertyOrder(-1)]
            [ButtonGroup]
            [GUIColor(0, 1, 0)]
            private void Apply()
            {
            }

            [ButtonGroup]
            [GUIColor(1, 0.6f, 0.4f)]
            private void Cancel()
            {
            }

            [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
            public int ColoredInt1;

            [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
            public int ColoredInt2;




            [Space(6)]
            [SuffixLabel("代码", true)]
            [Multiline(14), HideLabel]
            public string text1 =
                "[PropertyOrder(-1)]            // 把方法按钮优先提前\n" +
                "[ButtonGroup]\n" +
                "[GUIColor(0, 1, 0)]\n" +
                "private void Apply()｛  ｝\n" +
                "\n" +
                "[ButtonGroup]\n" +
                "[GUIColor(1, 0.6f, 0.4f)]\n" +
                "private void Cancel()｛  ｝\n" +
                "\n" +
                "[GUIColor(0.3f, 0.8f, 0.8f, 1f)]\n" +
                "public int ColoredInt1;\n" +
                "\n" +
                "[GUIColor(0.3f, 0.8f, 0.8f, 1f)]\n" +
                "public int ColoredInt2;\n" +
                "";


        }


        #endregion


        #region 显示 or 隐藏
        private class MyDoShow
        {

            [Title("隐藏 HideIf 、显示 ShowIf", null, TitleAlignments.Centered)]
            public bool isHidden;

            [HideIf("isHidden")]    // ShowIf
            public int index;


            [Multiline(4), HideLabel]
            [SuffixLabel("代码", true)]
            public string Test1 = "public bool isHidden;\n" +
                                 "\n" +
                                 "[HideIf(\"isHidden\")] \n" +
                                 "public int index;\n";





            [Space(15)]
            [Title("隐藏的还是可以看到的", null, TitleAlignments.Centered)]
            [EnumToggleButtons]
            public InfoMessageType SomeEnum;

            public bool IsToggled;

            [EnableIf("SomeEnum", InfoMessageType.Info)]
            public Vector2 Info;

            [EnableIf("SomeEnum", InfoMessageType.Error)]
            public Vector2 Error;

            [EnableIf("SomeEnum", InfoMessageType.Warning)]
            public Vector2 Warning;

            [EnableIf("IsToggled")]
            public int EnableIfToggled;

            [DisableIf("IsToggled")]
            public int DisableIfToggled;

            [Space(15)]
            [Title("折叠隐藏", null, TitleAlignments.Centered)]
            [DisplayAsString(false)]
            [HideLabel]
            public string str = "把 string 通通隐藏";

            [FoldoutGroup("Group 1")]
            public int A;
            [FoldoutGroup("Group 1")]
            public int B;


            [Multiline(4), HideLabel]
            [SuffixLabel("代码", true)]
            public string Test = "[FoldoutGroup(“Group 1”)]\n" +
                                 "public int A;\n" +
                                 "[FoldoutGroup(“Group 1”)]\n" +
                                 "public int B;\n";




        }



        #endregion


        #region 可改 or 不可改

        private class MyDoRead
        {

            [PropertyOrder(int.MinValue), OnInspectorGUI]
            private void DrawTitle()
            {
                AllEditorGUI.Title("这个是直接切换每个项 例：  [TabGroup(\"1个类\")]", "", TextAlignment.Center, true);
            }

            [TabGroup("2个 int")]
            public int One;
            [TabGroup("2个 int")]
            public int Two;
            [TabGroup("1个 string")]
            public string MyString;
            [TabGroup("1个类")]
            [HideLabel]
            public MyTabObject TabC;
            [Serializable]
            public class MyTabObject
            {
                public Sprite A;
                public GameObject B;
            }

            [SuffixLabel("代码", true)]
            [Multiline(15), HideLabel]
            public string text =
                "     [TabGroup(\"2个 int\")]\n" +
                "     public int One;\n" +
                "     [TabGroup(\"2个 int\")]\n" +
                "     public int Two;\n" +
                "     \n" +
                "     [TabGroup(\"1个 string\")]\n" +
                "     public string MyString;\n" +
                "     \n" +
                "     [TabGroup(\"1个类\")]\n" +
                "     [HideLabel]\n" +
                "     public MyTabObject TabC;\n" +
                "     [Serializable]\n" +
                "     public class MyTabObject\n" +
                "     {\n" +
                "        public Sprite A;\n" +
                "        public GameObject B;\n" +
                "     }";



            [Title("用 [ReadOnly] 特性直接隐藏一个字段", null, TitleAlignments.Centered)]
            [ReadOnly]
            public int MyInt = 9001;

            [Space(5)]
            [Title("用一个 bool 来控制是否可改", null, TitleAlignments.Centered)]
            [ToggleLeft]
            public bool 是否打开;
            [EnableIf("是否打开")]
            public int A;
            [EnableIf("是否打开")]
            public bool B;

            [Multiline(8), HideLabel]
            [SuffixLabel("代码", true)]
            public string Test = "[ToggleLeft]               // 可以不加这个（按钮设置左边）\n" +
                                 "public bool 是否打开;\n" +
                                 "[EnableIf(\"是否打开\")]\n" +
                                 "\n" +
                                 "public int A;\n" +
                                 "[EnableIf(\"是否打开\")]\n" +
                                 "\n" +
                                 "[EnableIf(\"是否打开\")]\n" +
                                 "public bool B;";


        }



        #endregion


        #region int、float

        private class MyInFloat
        {
            [Title("限定 数值 最小值（没有最大值）")]
            [MinValue(10)]
            public int 最小0;
            [Title("限定 数值 最大值（没有最小值）")]
            [MaxValue(100)]
            public int 最大100;

            [Space(8)]
            [Multiline(5), HideLabel]
            [SuffixLabel("代码", true)]
            public string Test1 = "[MinValue(10)]\n" +
                                  "public int 最小0;\n" +
                                  "\n" +
                                  "[MaxValue(100)]\n" +
                                  "public int 最大100;";


            [SerializeField, HideInInspector]
            private int evenNumber;

            [Title("      这个是 属性")]
            [ShowInInspector]
            public int EvenNumber
            {
                get
                {
                    return this.evenNumber;
                }
                set
                {
                    this.evenNumber = value + value % 2;
                    
                }
            }
        }

        #endregion



        #region GameObject

        private class MyDoGameObject
        {
            [Title("只能拖 Asset 上的 Prefab 进来")]
            [AssetsOnly]
            public GameObject Prefab对象;

            [Multiline(3), HideLabel]
            [SuffixLabel("代码", true)]
            public string Test1 = "[AssetsOnly]\n" +
                                 "public GameObject Prefab对象;";


            [Space(20)]
            [Title("只能拖进 场景中的游戏对象 进来")]
            [SceneObjectsOnly]
            public GameObject 场景对象;
            [Multiline(3), HideLabel]
            [SuffixLabel("代码", true)]
            public string Test2 = "[SceneObjectsOnly]\n" +
                                  "public GameObject 场景对象;";


        }


        #endregion



        #region 水平的彩色条

        private class MyDoProgress
        {
            [ProgressBar(0, 100)]
            public int ProgressBar = 50;

            [Space(30)]
            [ProgressBar(0, 100, ColorMember = "GetHealthBarColor")]
            public float HealthBar = 50;


            [Range(0, 300), Space(30)]
            public float StackedHealth=15;


            [HideLabel, ShowInInspector]
            [ProgressBar(0, 100, ColorMember = "GetStackedHealthColor", BackgroundColorMember = "GetStackHealthBackgroundColor")]
            private float StackedHealthProgressBar
            {
                // Loops the stacked health value between 0, and 100.
                get { return this.StackedHealth - 100 * (int)((this.StackedHealth - 1) / 100); }
            }


            [Space(30)]
            [PropertyOrder(10), HideLabel, Space(15)]
            [ProgressBar(-100, 100, r: 1, g: 1, b: 1, Height = 30)]
            public short BigProgressBar = 50;



            private Color GetStackedHealthColor()
            {
                return
                    this.StackedHealth > 200 ? Color.cyan :
                        this.StackedHealth > 100 ? Color.green :
                            Color.red;
            }

            private Color GetStackHealthBackgroundColor()
            {
                return
                    this.StackedHealth > 200 ? Color.green :
                        this.StackedHealth > 100 ? Color.red :
                            new Color(0.16f, 0.16f, 0.16f, 1f);
            }


            private Color GetHealthBarColor(float value)
            {
                // Blends between red, and yellow color for when the health is below 30,
                // and blends between yellow and green color for when the health is above 30.
                return Color.Lerp(Color.Lerp(
                        Color.red, Color.yellow, MathUtilities.LinearStep(0f, 30f, value)),
                    Color.green, MathUtilities.LinearStep(0f, 100f, value));
            }


        }


        #endregion

        #region 取得文件或者文件夹路径

        private class MyDoPath
        {
            [InfoBox(
                "FolderPath attribute provides a neat interface for assigning paths to strings.\n" +
                "It also supports drag and drop from the project folder.")]
            // By default, FolderPath provides a path relative to the Unity project.
            [FolderPath]
            public string UnityProjectPath;

            // It is possible to provide custom parent path. Parent paths can be relative to the Unity project, or absolute.
            [FolderPath(ParentFolder = "Assets/Plugins/Sirenix")]
            public string RelativeToParentPath;

            // Using parent path, FolderPath can also provide a path relative to a resources folder.
            [FolderPath(ParentFolder = "Assets/Resources")]
            public string ResourcePath;

            // By setting AbsolutePath to true, the FolderPath will provide an absolute path instead.
            [FolderPath(AbsolutePath = true)]
            [BoxGroup("Conditions")]
            public string AbsolutePath;

            // FolderPath can also be configured to show an error, if the provided path is invalid.
            [FolderPath(RequireValidPath = true)]
            [BoxGroup("Conditions")]
            public string ValidPath;

            // By default, FolderPath will enforce the use of forward slashes. It can also be configured to use backslashes instead.
            [FolderPath(UseBackslashes = true)]
            [BoxGroup("Conditions")]
            public string Backslashes;

            // FolderPath also supports member references with the $ symbol.
            [FolderPath(ParentFolder = "$DynamicParent")]
            [BoxGroup("Member referencing")]
            public string DynamicFolderPath;

            [BoxGroup("Member referencing")]
            public string DynamicParent = "Assets/Plugins/Sirenix";

            // FolderPath also supports lists and arrays.
            [FolderPath(ParentFolder = "Assets/Plugins/Sirenix")]
            [BoxGroup("Lists")]
            public string[] ListOfFolders;
        }



        #endregion


  


        #region 表格

        private class MyDoBiaoGe
        {
            [Multiline(7), HideLabel] [SuffixLabel("实现过程", true)]
            public string Test =
                "1. 需要继承 SerializedMonoBehaviour\n" +
                "\n" +
                "2. 直接写两维数组即可\n" +
                "   public bool[,] BooleanMatrix = new bool[15, 6];\n" +
                "   public string[,] StringMatrix = new string[4, 4];\n";

            [Space]
            [Multiline(20), HideLabel]
            [SuffixLabel("6 到没朋友了", true)]
            public string Test2 =
                "1. 两样需要继承 SerializedMonoBehaviour\n" +
                "\n" +
                "2. 代码如下\n" +
                "[TableMatrix(HorizontalTitle = \"Custom Cell Drawing\", DrawElementMethod = \"DrawColoredEnumElement\", ResizableColumns = false, RowHeight = 16)]\n" +
                "public bool[,] CustomCellDrawing = new bool[30, 30];\n" +
                "#if UNITY_EDITOR\n" +
                " private static bool DrawColoredEnumElement(Rect rect, bool value){\n" +
                "   if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition)){\n" +
                "       value = !value;\n" +
                "       GUI.changed = true;\n" +
                "       Event.current.Use();}\n" +
                "   UnityEditor.EditorGUI.DrawRect(rect.Padding(1), value ? new Color(0.1f, 0.8f, 0.2f) : new Color(0, 0, 0, 0.5f));\n" +
                "   return value;\n";
        }

        #endregion


        #region 颜色取色
        private class MyDoColor
        {
            [ColorPalette]
            public Color ColorOptions;

            [ColorPalette("Underwater")]
            public Color UnderwaterColor;

            [ColorPalette("My Palette")]
            public Color MyColor;

            public string DynamicPaletteName = "Clovers";

            [ColorPalette("$DynamicPaletteName")]
            public Color DynamicPaletteColor;

            [ColorPalette("Fall"), HideLabel]
            public Color WideColorPalette;

            [ColorPalette("Clovers")]
            public Color[] ColorArray;

            [FoldoutGroup("Color Palettes", expanded: false)]
            [ListDrawerSettings(IsReadOnly = true)]
            [PropertyOrder(9)]
            public List<ColorPaletteExamples.ColorPalette> ColorPalettes;

#if UNITY_EDITOR

            [FoldoutGroup("Color Palettes"), Button(ButtonSizes.Large), GUIColor(0, 1, 0), PropertyOrder(8)]
            private void FetchColorPalettes()
            {
                this.ColorPalettes = Sirenix.OdinInspector.Editor.ColorPaletteManager.Instance.ColorPalettes
                    .Select(x => new ColorPaletteExamples.ColorPalette()
                    {
                        Name = x.Name,
                        Colors = x.Colors.ToArray()
                    })
                    .ToList();
            }

#endif
            [Serializable]
            public class ColorPalette
            {
                [HideInInspector]
                public string Name;

                [LabelText("$Name")]
                [ListDrawerSettings(IsReadOnly = true, Expanded = false)]
                public Color[] Colors;
            }
        }

        #endregion

#pragma warning restore



        //————————————————————————————————————

        private void DrawUnityAtt()                              // Unity 的特性
        {
            AddSearch(ref m_Input, l_AllTextAttribute, () =>
            {
                isInspector = true;
                isMonoBehaviour = true;
                isEditorr = true;
                isSystem = true;
            });
            MyCreate.TextButton(isOpen ? "收缩" : "张开", () =>
            {
                isOpen = !isOpen;
                isInspector = isOpen;
                isMonoBehaviour = isOpen;
                isEditorr = isOpen;
                isSystem = isOpen;
            });

            Item("改变 Inspector", ref isInspector, l_Inspector);
            MyCreate.AddSpace(3);
            Item("继承MonoBehaviour的组件Class使用", ref isMonoBehaviour, l_Mono);
            MyCreate.AddSpace(3);
            Item("Editor", ref isEditorr, l_Editor);
            MyCreate.AddSpace(3);
            Item("System", ref isSystem, l_System);

        }




    }




}