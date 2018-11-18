using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Learn_Function : AbstactNewKuang
    {
        [MenuItem(LearnMenu.XiaoFunction, false, LearnMenu.XIAO_INDEX)]
        static void Init()
        {
            Learn_Function instance = GetWindow<Learn_Function>(false, "");
            instance.SetupWindow();
        }


        protected override void DrawLeft()
        {
            #region 正则表达式 1

            bool tmpZhen = (type == EType.ZhengZhe || type == EType.ZhengZhe1 || type == EType.ZhengZhe2 || type == EType.ZhengZhe3);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "正则表达式";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.ZhengZhe ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.ZhengZhe);
            }
            if (tmpZhen)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ZhengZhe1 ? "常用正则大全".AddBlue() : "常用正则大全");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ZhengZhe1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ZhengZhe2 ? "Regex 类".AddBlue() : "Regex 类");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ZhengZhe2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ZhengZhe3 ? "正则富文本".AddBlue() : "正则富文本");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ZhengZhe3);
                }

            }

            #endregion

            AddSpace_3();

            #region 富文本 预处理 2

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "富文本";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Fu ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Fu);
            }

            AddSpace_3();
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "预处理";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Yu ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Yu);
            }

            #endregion


            AddSpace_3();


            #region 加载图片 3

            bool isLoad = (type == EType.LoadTu || type == EType.LoadTu2 || type == EType.LoadTu3 );
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "加载图片总结";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isLoad ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.LoadTu);
            }

            if (isLoad)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LoadTu ? "FileStream 文件流".AddBlue() : "FileStream 文件流");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LoadTu);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LoadTu2 ? "System.Drawing".AddBlue() : "System.Drawing");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LoadTu2);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LoadTu3 ? "WWW 网络".AddBlue() : "WWW 网络");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LoadTu3);
                }
            }

            #endregion

            #region Json 4

            bool isTmp1 = (type == EType.Json || type == EType.Json1 || type == EType.Json2 || type == EType.Json3);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Json";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Json ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Json);
            }

            if (isTmp1)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Json1 ? "   SimpleJSON".AddBlue() : "   SimpleJSON");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Json1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Json2 ? "   解析｛｝开头".AddBlue() : "   解析｛｝开头");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Json2);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Json3 ? "   解析 [  ] 开头".AddBlue() : "   解析 [  ] 开头");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Json3);
                }
            }

            #endregion

            AddSpace_3();

            #region Xml 5

            bool isXML = (type == EType.Xml || type == EType.Xml1 || type == EType.Xml2);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Xml";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Xml ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Xml);
            }

            if (isXML)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Xml1 ? "读取 xml 例子 1".AddBlue() : "读取 xml 例子 1");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Xml1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Xml2 ? "读取 xml 例子 2".AddBlue() : "读取 xml 例子 2");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Xml2);
                }
            }

            #endregion


            AddSpace_3();


            #region Protobuf 6


            bool tmpProtobuf = (type == EType.Protobuf || type == EType.Protobuf1 || type == EType.Protobuf2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Protobuf";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Protobuf ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Protobuf);
            }
            if (tmpProtobuf)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Protobuf1 ? "   简单例子".AddBlue() : "   简单例子");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Protobuf1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Protobuf2 ? "   深入使用".AddBlue() : "   深入使用");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Protobuf2);
                }
            }

            #endregion

            AddSpace_3();
             
            #region 其他文本 7

            bool isWenBen = (type == EType.WenBen || type == EType.Excel || type == EType.Txt || type == EType.PDF);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "其他文本";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.WenBen ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Txt);
            }
            if (isWenBen)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Txt ? "   Txt".AddBlue() : "   Txt");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Txt);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Excel ? "   Excel".AddBlue() : "   Excel");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Excel);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.PDF ? "   PDF".AddBlue() : "   PDF");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.PDF);
                }

            }

            #endregion

            AddSpace_3();


            #region 时间

            bool isTime = (type == EType.Time || type == EType.Time1 || type == EType.Time2 || type == EType.Time3);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "时间";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isTime ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Time1);
            }
            if (isTime)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Time1 ? "  Time".AddBlue() : "  Time");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Time1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Time2 ? "  DateTime".AddBlue() : "  DateTime");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Time2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Time3 ? "  DateTime 对照表".AddBlue() : "  DateTime 对照表");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Time3);
                }
            }

            #endregion


        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.ZhengZhe: DrawRightPage1(DrawZhenZhe); break;
                case EType.ZhengZhe1: DrawRightPage(ZhenZhe1); break;
                case EType.ZhengZhe2: DrawRightPage(DrawRegex); break;
                case EType.ZhengZhe3: DrawRightPage(DrawZhenFu); break;
                case EType.Fu: DrawRightPage4(DrawRichText); break;
                case EType.Yu: DrawRightPage8(DrawYuDealWith); break;
                case EType.Txt: DrawRightPage1(DrawTxt); break;
                case EType.Json: DrawRightPage3(DrawJson); break;
                case EType.Json1: DrawRightPage4(DrawSimpleJSON); break;
                case EType.Json2: DrawRightPage5(DrawSimpleJSON1); break;
                case EType.Json3: DrawRightPage8(DrawSimpleJSON2); break;
                case EType.Xml: DrawRightPage4(DrawXML); break;
                case EType.Xml1: DrawRightPage5(DrawXML1); break;
                case EType.Xml2: DrawRightPage6(DrawXML2); break;
                case EType.Protobuf: DrawRightPage5(DrawProtobuf); break;
                case EType.Protobuf1: DrawRightPage5(DrawProLiZi); break;
                case EType.Excel: DrawRightPage6(DrawExcel); break;
                case EType.Time1: DrawRightPage7(DrawTime); break;
                case EType.Time2: DrawRightPage8(DrawDateTime); break;
                case EType.Time3: DrawRightPage1(DrawDataTime2); break;



                case EType.LoadTu: DrawRightPage(DrawLoadTu1); break;
                case EType.LoadTu2: DrawRightPage(DrawLoadTu2); break;
                case EType.LoadTu3: DrawRightPage(DrawLoadTu3); break;


            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.ZhengZhe:
                    mWindowSettings.pageWidthExtraSpace.target = 15;
                    break;
                case EType.ZhengZhe1:
                    mWindowSettings.pageWidthExtraSpace.target = 45;
                    break;
                case EType.Xml:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.Xml1:
                    mWindowSettings.pageWidthExtraSpace.target = 130;
                    break;
                case EType.Xml2:
                    mWindowSettings.pageWidthExtraSpace.target = 130;
                    break;
                case EType.Json:
                    mWindowSettings.pageWidthExtraSpace.target = 70;
                    break;
                case EType.Json1:
                    mWindowSettings.pageWidthExtraSpace.target = 30;
                    break;
                case EType.Json2:
                    mWindowSettings.pageWidthExtraSpace.target = 30;
                    break;
                case EType.Protobuf:
                    mWindowSettings.pageWidthExtraSpace.target = 90;
                    break;
                case EType.Time1:
                    mWindowSettings.pageWidthExtraSpace.target = 10;
                    break;
                case EType.Time2:
                    mWindowSettings.pageWidthExtraSpace.target = 30;
                    break;
                case EType.Time3:
                    mWindowSettings.pageWidthExtraSpace.target = 30;
                    break;
                case EType.LoadTu:
                    mWindowSettings.pageWidthExtraSpace.target = 50;
                    break;
                case EType.LoadTu2:
                    mWindowSettings.pageWidthExtraSpace.target = 50;
                    break;
                case EType.LoadTu3:
                    mWindowSettings.pageWidthExtraSpace.target = 50;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -20;
                    break;
            }
        }



        #region 私有

        private DateTime mDemoTime1 = new DateTime();
        private DateTime mDemoTime2 = new DateTime(2018, 8, 8);
        private DateTime mDemoTime3 = new DateTime(2018, 8, 8, 2, 20, 30);
        private DateTime mDemoTime4;


        private string ChuYinPath;
        private Texture2D Texture2D1, Texture2D12;
        protected override void OnInit()
        {
            base.OnInit();
            mDemoTime4 = DateTime.Now;
            string[] assetPathsId = AssetDatabase.FindAssets("sidebarLogo0");
            if (assetPathsId.Length==0)
            {
                MyLog.Red("把 sidebarLogo0 这图片删除了？");
                return;
            }
            string assetPath = AssetDatabase.GUIDToAssetPath(assetPathsId[0]);
            ChuYinPath = MyAssetUtil.GetFullPath(assetPath);

            Texture2D1 = LoadTextureInLocal(ChuYinPath);

            Texture2D12 = LoadText(ChuYinPath);


        }





        private bool isRegexOptions, isOther;
        private static readonly string UserBeanStr = "UserBean".AddWhite();
        private static readonly string PathStr = "路径".AddLightBlue();
        private static readonly string NameCnStr = "NameCn".AddYellow();
        private static readonly string PlayerNumStr = "PlayerNum".AddYellow();
        private static readonly string MapLoadCfgStr = "MapLoadCfg".AddOrange();
        private static readonly string MapIDStr = " MapID".AddBlue();
        private static readonly string InfoNodeListStr = "infoNodeList".AddWhite();
        private static readonly string BeanStr = "bean".AddGreen();
        private static readonly string ChildNodesStr = ".ChildNodes".AddRed();
        private static readonly string GetAttributeNodeStr = ".GetAttributeNode".AddRed();
        private static readonly string InnerTextNodeStr = ".InnerText".AddRed();
        private static readonly string RandomNameStr = "RandomName".AddOrange();
        private static readonly string Name1Str = "Name1".AddBlue();
        private static readonly string Name2Str = "Name2".AddBlue();
        private static readonly string Name3Str = "Name3".AddBlue();
        private static readonly string KeyOne = "“Key 1”".AddBlue();
        private static readonly string SuiBian2 = "“随便2”".AddLightBlue();
        private static readonly string JSONNode = "JSONNode".AddBlue();



        private enum EType
        {
            ZhengZhe, ZhengZhe1, ZhengZhe2, ZhengZhe3,
            Fu,
            Yu,

            Json, Json1, Json2, Json3,
            Xml, Xml1, Xml2,
            Protobuf, Protobuf1, Protobuf2,
            WenBen, Txt, Excel, PDF,
            Time, Time1, Time2, Time3,

            LoadTu,LoadTu2,LoadTu3
            


        }

        private EType type = EType.ZhengZhe;

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
            return "小功能";
        }



        private void ThisColor(string str1, string color, string str2, string color2)
        {
            StringBuilder sb = new StringBuilder();

            MyCreate.Heng(() =>
            {
                sb.Append("<color=");
                sb.Append(color);
                sb.Append(">");
                sb.Append(str1);
                sb.Append("</color>");
                m_Tools.TextSelectText_Y(sb.ToString(), color, -90);
                MyCreate.AddSpace(10);
                sb.Length = 0;
                sb.Append("<color=");
                sb.Append(color2);
                sb.Append(">");
                sb.Append(str2);
                sb.Append("</color>");
                m_Tools.TextSelectText_Y(sb.ToString(), color2, -90);
            });
        }
        #endregion


        #region 正则表达式

        private void DrawZhenZhe()                                     // 正则表达式
        {
            m_Tools.BiaoTi_L("网上工具");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open("开源中国的在线正则表达式测试工具", "http://tool.oschina.net/regex");
                m_Tools.TextButton_Open("站长之家的在线正则表达式测试工具", "http://tool.chinaz.com/regex/");

            });
            AddSpace_3();
            m_Tools.BiaoTi_B("例子：输入内容合法性检测");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("public string A = “ ^[A - Za - z0 - 9] + $”", "//数字或英文", 120);

                m_Tools.Text_H("void Start () ");
                m_Tools.Text_H("{");
                m_Tools.TextText_HG("     Regex reg = new Regex(A，RegexOptions.IgnoreCase))", "// 忽略大小写");
                m_Tools.Text_H("     bool isContain = reg.IsMatch(“输入的内容”)");
                m_Tools.Text_H("}");
            });
            AddSpace_3();
            m_Tools.BiaoTi_B("正则的常用元字符");
            MyCreate.Box(() =>
            {
                MyCreate.Text("开始结束符".AddGreen());
                m_Tools.Text4_BW("   ^", "开始", "$", "结束", 20);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("    前后添加了 ^ $ ，代表整句话只能使用正则的才能通过");
                    m_Tools.Text_H("    如 ", "“1”".AddBlue(), ":”213“ 也通过， ”^ 1$“：只有", " ”1“".AddBlue(), " 才通过，", "“^1”".AddBlue(), " :开头是1就通过");

                });
                MyCreate.Text("一个 还是 多个".AddGreen());
                m_Tools.TextText_BW("*", "重复零次或更多次", -30);
                m_Tools.TextText_BW("+", "重复一次或更多次", -30);
                m_Tools.TextText_BW("?", "重复零次或一次", -30);

                MyCreate.Text("常用固定词".AddGreen());

                m_Tools.TextText_BW(@"\W", "匹配任意不是字母，数字，下划线，汉字的字符", -30);
                m_Tools.TextText_BW(@"\S", "匹配任意不是空白符的字符", -30);
                m_Tools.TextText_BW(@"\D", "匹配任意非数字的字符", -30);
                m_Tools.TextText_BW(@"\B", "匹配不是单词开头或结束的位置", -30);
                m_Tools.TextText_BW(@"\w", "匹配字母或数字或下划线", -30);
                m_Tools.TextText_BW(@"\s", "匹配任意的空白符", -30);
                m_Tools.TextText_BW(@"\d", "匹配数字", -30);
                m_Tools.TextText_BW(@"\b", "匹配单词的开始或结束", -30);

            });


        }

        private void ZhenZhe1()                                        // 正则大全
        {
            MyCreate.Text("字符");
            m_Tools.TextSelectText_L("只能 长度为 3 的字符", @"^.{3}$", 100);
            m_Tools.TextSelectText_L("验证 是否含有^%&’,;=?$\\”等字符", @"[^%&’,;=?$\x22]+", 100);

            MyCreate.Text("数字".AddBlue());
            m_Tools.TextSelectText_L("只能 数字", @"^[0-9]*$", 100);
            m_Tools.TextSelectText_L("只能 n 位的数字", @"^\d{n}$", 100);
            m_Tools.TextSelectText_L("至少 n 位的数字", @"^\d{n,}$", 100);
            m_Tools.TextSelectText_L("只能 m ~ n 位的数字", @"^\d{m,n}$", 100);
            m_Tools.TextSelectText_L("只能 零和非零开头的数字", @"^(0|[1-9][0-9]*)$", 100);
            m_Tools.TextSelectText_L("只能 有两位小数的正实数", @"^[0-9]+(.[0-9]{2})?$", 100);
            m_Tools.TextSelectText_L("只能 有1~3位小数的正实数", @"^[0-9]+(.[0-9]{1,3})?$", 100);
            m_Tools.TextSelectText_L("只能 非零的正整数", @"^\+?[1-9][0-9]*$", 100);


            MyCreate.Text("字符串".AddBlue());

            m_Tools.TextSelectText_L("只能 26个英文字母 的字符串", @"^[A-Za-z]+$", 100);
            m_Tools.TextSelectText_L("只能 26个大写英文字母 的字符串", @"^[A-Z]+$", 100);
            m_Tools.TextSelectText_L("只能 26个小写英文字母 的字符串", @"^[a-z]+$", 100);
            m_Tools.TextSelectText_L("只能 数字和 26 个英文字母 的字符串", @"^[A-Za-z0-9]+$", 100);
            m_Tools.TextSelectText_L("只能 数字、26 个英文字母或者下划线", @"^\w+$", 100);
            m_Tools.TextSelectText_L("只能 汉字", @"^[\u4e00-\u9fa5]{0,}$", 100);


            MyCreate.Text("应用".AddYellow());
            m_Tools.Text_L("验证用户密码", "(以字母开头，长度在6~18之间，只能包含字符、数字和下划线)".AddGreen());
            m_Tools.TextSelectText_L("", @"^[a-zA-Z]\w{5,17}$", 10);
            m_Tools.TextSelectText_L("验证 Email 地址", @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", 10);
            m_Tools.TextSelectText_L("验证 URL 是否合理", @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$", 10);
            m_Tools.TextSelectText_L("提取图片地址", @"/(http(s)?\:\/\/)?(www\.)?(\w+\:\d+)?(\/\w+)+\.(png|gif|jpg|bmp|jpeg)/gi", -100);
            m_Tools.Text_L("验证固话号码", "(“XXX-XXXXXXX”、“XXXXXXX”、“XXXXXXXX”、“XXX-XXXXXXXX”)".AddGreen());
            m_Tools.TextSelectText_L("", @"^(\(\d{3,4}-)|\d{3.4}-)?\d{7,8}$", 10);
            m_Tools.TextSelectText_L("验证身份证号(15位或18位数字)", @"^\d{15}|\d{18}$", 100);
            m_Tools.TextSelectText_L("验证是否12个月的写法" + "（01~09 或 1~12）".AddGreen(), @"^(0?[1-9]|1[0-2])$", 100);
            m_Tools.TextSelectText_L("验证是否31天的写法" + "（01~09 或1~31）".AddGreen(), @"^((0?[1-9])|((1|2)[0-9])|30|31)$", 100);

        }


        private void DrawRegex()                                       // Regex 类
        {
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.text.regularexpressions.regex(v=vs.110).aspx");

            m_Tools.BiaoTi_O("Regex 构造函数");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("1. 无参 ", "new Regex()".AddYellow());
                m_Tools.Text_L("2. 带正则字符串 ", "new Regex(string)".AddYellow());
                m_Tools.Text_L("3. 带正则字符串和匹配规则的枚举 " + "new Regex(string，RegexOptions)".AddYellow(), ref isRegexOptions,
                    () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.TextText_BW("None", "默认");
                            m_Tools.TextText_BW("IgnoreCase", "不区分大小写");
                            m_Tools.TextText_BW("Multiline", "多行模式。更改 ^ 和 $ 的含义，使它们分别在任意一行的行首和行尾匹配");
                            m_Tools.TextText_BW("RightToLeft", "搜索从右向左而不是从左向右进行");
                            m_Tools.TextText_BW("Singleline", "单行模式。 更改点 （.） 的含义");
                            m_Tools.TextText_BW("Compiled", "");
                            m_Tools.TextText_BW("CultureInvariant", "");
                            m_Tools.TextText_BW("ECMAScript", "");
                            m_Tools.TextText_BW("ExplicitCapture", "");
                            m_Tools.TextText_BW("IgnorePatternWhitespace", "");

                        });
                    });
            });
            AddSpace();
            m_Tools.BiaoTi_O("Regex 方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YW("IsMatch", "string", "是否正则的匹配项", "bool", 50);
                m_Tools.Method_YW("Replace", "string，string 要替换成的字符", "替换", "string", 50);
                m_Tools.Method_YW("Match", "string", "第一个匹配项", "match", 50);
            });

            AddSpace();

            m_Tools.BiaoTi_L("match 属性");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("Index", "只读", "第一个字符的索引", "int");
                m_Tools.Method_BL("Length", "只读", "匹配的字符串长度", "int");
                m_Tools.Method_BL("Success", "只读", "是否匹配成功", "bool");
                m_Tools.Method_BL("Value", "只读", "匹配的子字符串", "string");

            });
            m_Tools.BiaoTi_L("match 方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("NextMatch", "", "下一个匹配选项", "Match");
            });



        }

        private void DrawZhenFu()                                      // 正则富文本
        {
            mInput = m_Tools.TextString_B("输入值", mInput); ;

            MyCreate.Text(GetRichString(mInput));
            AddSpace_15();

        }

        private string mInput = "点击此处进入[yellow]新手[-]1111";
        private Regex mRegex = new Regex(@"\[(red|green|yellow)]\S+\[-]");

        private string GetRichString(string text)
        {
            Match match = mRegex.Match(text);
            if (match.Success)
            {

                string firstStr = text.Substring(0, match.Index);   // 前头字符串
                string lastStr = text.Substring(match.Index + match.Length); // 最后面的字符串
                string middleStr = match.Value;
                MyEnumColor color = MyEnumColor.Blue;
                int middleIndex = 0;
                if (middleStr.Contains("[red]"))
                {
                    color = MyEnumColor.Red;
                    middleIndex = 5;
                }
                else if (middleStr.Contains("[green]"))
                {
                    color = MyEnumColor.Green;
                    middleIndex = 7;
                }
                else if (middleStr.Contains("[yellow]"))
                {
                    color = MyEnumColor.Green;
                    middleIndex = 8;
                }
                middleStr = middleStr.Substring(middleIndex, match.Length - 3 - middleIndex).AddColor(color, false);
                return firstStr + middleStr + lastStr;
            }
            else
            {
                return text;
            }
        }

        #endregion



        private void DrawYuDealWith()                            // 预处理
        {

            m_Tools.BiaoTi_B("定义预处理" + "(可用在 Editor 上)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextSelectText_L("必须放在最开头处", "#define");

            });
            m_Tools.BiaoTi_B("预处理");
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/PlatformDependentCompilation.html");
                m_Tools.TextSelectText("给出警告", "#warning XXX");
                m_Tools.TextSelectText("不需要警告_头", "#pragma warning disable");
                m_Tools.TextSelectText("不需要警告_尾", "#pragma warning restore");
                MyCreate.FenGeXian();
                MyCreate.Text("发布".AddLightBlue());
                m_Tools.TextSelectText_B("发布在 Win 中编译", "#if UNITY_STANDALONE_WIN ... #endif");
                m_Tools.TextSelectText_B("发布在 安卓 下编译", "#if UNITY_ANDROID ... #endif");
                m_Tools.TextSelectText_B("发布在 IOS 下编译", "#if UNITY_IOS ... #endif");
                MyCreate.Text("编辑器".AddLightBlue());
                m_Tools.TextSelectText_B("只在编辑器中编译", "#if UNITY_EDITOR ... #endif");
                m_Tools.TextSelectText_B("编辑器 win 下编译", "#if UNITY_EDITOR_WIN ... #endif");
                m_Tools.Text_B("还有其它", ref isOther, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextSelectText_B("编辑器 osx ", "#if UNITY_EDITOR_OSX ... #endif");
                        m_Tools.TextSelectText_B("发布 osx", "#if UNITY_STANDALONE_OSX ... #endif");
                        m_Tools.TextSelectText_B("发布在 Unity 5.x", "#if UNITY_5 ... #endif");

                    });
                });
                MyCreate.FenGeXian();
                m_Tools.BiaoTi_G("在Unity自定义预处理");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("Player Settings -> Other Settings -> Scripting Define Symbols");
                    m_Tools.Text_H("    在", " CROSS_PLATFORM_INPUT ".AddGreen(), "后面加 ;" + "(分号)".AddLightGreen() + " + 接自定义名");
                });
            });
        }

        private void DrawRichText()                              // 富文本
        {

            m_Tools.BiaoTi_B("富文本");
            MyCreate.Box(() =>
            {
                m_Tools.TextSelectText("加粗".AddBold(), "<b> ... </b> ");
                m_Tools.TextSelectText("加斜".AddItalic(), "<i> ... </i> ");
                m_Tools.TextSelectText("改大小".AddSize(9), "<size=9> ... </size> ");
                m_Tools.TextSelectText("加颜色".AddGreen(), "<color=green>    ... </color> ");
                MyCreate.Box(() =>
                {
                    ThisColor("aqua", "#00ffffff", "black", "#000000ff");
                    ThisColor("blue", "#0000ffff", "brown", "#a52a2aff");
                    ThisColor("cyan ", "#00ffffff", "darkblue", "#0000a0ff");
                    ThisColor("fuchsia ", "#ff00ffff", "green", "#008000ff");
                    ThisColor("grey", "#808080ff", "lightblue", "#add8e6ff");
                    ThisColor("magenta ", "#ff00ffff", "lime ", "#00ff00ff");
                    ThisColor("navy ", "#000080ff", "maroon ", "#800000ff");
                    ThisColor("olive ", "#808000ff", "orange ", "#ffa500ff");
                    ThisColor("purple ", "#800080ff", "red ", "#ff0000ff");
                    ThisColor("silver ", "#c0c0c0ff", "teal ", "#008080ff");
                    ThisColor("white ", "#ffffffff", "yellow ", "#ffff00ff");
                });
            });
        }



        #region Json



        private void DrawJson()                                  //json
        {

            AddToggleButton("Json 相关网站", "官网", "格式化、编辑网站", () =>
            {
                Application.OpenURL("http://www.json.org/");
            }, () =>
            {
                Application.OpenURL("http://www.kjson.com/");

            });

            m_Tools.BiaoTi_O("JSON （JavaScript Objct Notation - " + "JavaScript 对象表示法".AddLightGreen() + "）");
            MyCreate.Box(() =>
            {
                m_Tools.TextText("• 基于文本".AddLightBlue(), "• 轻量级的数据交换格式".AddLightBlue());
                m_Tools.TextText("• 自我描述性，容易理解".AddLightBlue(), "• 独立于语言(C++、C、JS、C#、JAVA...)".AddLightBlue());
            });
            m_Tools.BiaoTi_B("语法规则");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("▪  数据键值对由", "冒号 :".AddGreen(), " 分隔", " （“字符串”： 数字、字符串、bool、数组、对象、null）".AddHui());
                m_Tools.Text_B("▪  数据与数据之间由", "逗号 ,".AddGreen(), " 分隔");
                m_Tools.Text_B("▪  一个对象用花", "括号｛ ｝ ".AddGreen(), " 包含");
                m_Tools.Text_B("▪  一个数组用方", "括号 [ ] ".AddGreen(), "   包含");

            });

            m_Tools.BiaoTi_B(" 例子:");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("{", "// 对象", 50);
                m_Tools.TextText_HG("    ”Text“ : ”字符串“", "// Key ：字符串", 50);
                m_Tools.TextText_HG("    ”Id“ : 123", "// Key ：数字", 50);
                m_Tools.TextText_HG("    ”Objects“ :", "// Key ：对象", 50);
                m_Tools.Text_H("        {");
                m_Tools.TextText_HG("            ”List“ : [”1“，”2“，”3“]", "// Key ：数组", 50);
                m_Tools.TextText_HG("            ”IsTure“ : true", "// Key ：bool", 50);
                m_Tools.TextText_HG("            ”Bean“ : {}", "// Key ：null", 50);
                m_Tools.Text_H("         }");
                m_Tools.Text_H("}");
                AddSpace_3();
            });

            m_Tools.BiaoTi_O("解析 Json ");
            MyCreate.Box(() =>
            {
                MyCreate.Text("不推荐".AddRed());
                m_Tools.Text_Y("1. Json.NET  .NET自带的 Json 库，缺点：", "比较臃肿".AddRed());
                m_Tools.Text_Y("2. MiniJson 缺点：", "不支持算定义的序列化".AddRed());
                m_Tools.Text_Y("3. LitJson 缺点：", "IOS 平台支持不太友好 ".AddRed(), "优点：", "轻巧(只做 Android 平台可以使用)".AddGreen());
                MyCreate.Text("推荐");
                m_Tools.TextButton_Open("       MyJson", () =>
                {
                    Application.OpenURL("https://github.com/lightszero/myjson");
                });
                m_Tools.TextButton_Open("       SimpleJson" + "(我选择这个)", () =>
                {
                    Application.OpenURL("http://blog.csdn.net/kakashi8841/article/details/21877131");
                });
                MyCreate.Text("推荐：".AddGreen() + "JsonFX ".AddYellow());
                MyCreate.Box(() =>
                {
                    AddToggleButton("JsonFX 网站", "github 开源地址", "JsonFX for Unity", () =>
                    {
                        Application.OpenURL("https://github.com/jsonfx/jsonfx");
                    }, () =>
                    {
                        Application.OpenURL("https://bitbucket.org/TowerOfBricks/jsonfx-for-unity3d/");

                    });
                    m_Tools.TextSelectText_B("Git 下载的（Demo）", "https://code.csdn.net/s10141303/jsonfxinunity.git");
                });
            });


        }



        private void DrawSimpleJSON()                           // SimpleJSON
        {

            m_Tools.TextButton_Open("SimpleJson.cs文件 和 一个 dll文件(导入)".AddYellow(), () =>
            {
                Application.OpenURL(@"F:\ZiLiao\项目必备\解析Json\SimpleJSON.unitypackage");
            });
            AddSpace();
            m_Tools.BiaoTi_O("1. 读取出来");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("TextAsset data = Resources.Load<TextAsset>(“文件名”);");
                m_Tools.Text_H(JSONNode, " jn = JSON.Parse(data.text);");
            });
            m_Tools.BiaoTi_O("2. { } -> 对象，[ ]  -> 数组");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("{ }开头：");
                m_Tools.Text_L("JSONClass jc = jn.AsObject;");
                m_Tools.Text_L("jc[“ObjectKey”]  -> ", JSONNode);
                AddSpace();
                MyCreate.Text("[ ]开头：");
                m_Tools.Text_L("JSONArray jA = jn.AsArray;");
                m_Tools.Text_L("foreach (", JSONNode, " jsonNode in ja)");
            });

            m_Tools.BiaoTi_O("3. " + JSONNode + " 再取得值");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("jsonNode[“Key”].Value/AsInt/AsFloat/AsBool   ->  取得值");
            });

            MyCreate.FenGeXian();
            m_Tools.BiaoTi_B("JSONNode 的 API");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BW("AsArray", "只读", "->  [  ]", "JSONArray");
                m_Tools.Method_BW("AsObject", "只读", "->  ｛｝", "JSONClass");
                m_Tools.Method_BW("Value/AsInt/AsFloat/AsDouble/AsBool", "", " ->  string/int/float/double/bool", "");
            });
            m_Tools.BiaoTi_B("JSONClass 的 API");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("this[ string 索引器 ]   ", JSONSTR);
            });
            m_Tools.BiaoTi_B("JSONArray 的 API (继承 IEnumerable)");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("1. this[ string 索引器 ]   ", JSONSTR);
                m_Tools.Text_B("2. this[ int 索引器 ]      ", JSONSTR);
                m_Tools.Text_B("3. 使用 foreach      ", JSONSTR);
            });


        }

        private static readonly string JSONSTR = "  ->  JSONNode".AddLightBlue();


        private void DrawSimpleJSON1()
        {

            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("“Map.json” 文件：" + "(开头使用 { })".AddOrange());
                m_Tools.Text_H("{");
                m_Tools.Text_H("    ", KeyOne, ": ");
                m_Tools.Text_H("    {");
                m_Tools.Text_H("         “随便1”: 100，");
                m_Tools.Text_H("         ", SuiBian2, ": “abc” ");
                m_Tools.Text_H("    }");
                m_Tools.Text_H("    “Key 2”: { “随便4”: 10 }");
                m_Tools.Text_H("}");
            });
            AddSpace();
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("TextAsset bindata = Resources.Load<TextAsset>(“Map”);");
                m_Tools.Text_H("JSONClass jc = JSON.Parse(bindata.text)", ".AsObject;".AddYellow());
                m_Tools.TextText_HG("jc[" + KeyOne + "]", "->  {“随便1”:100, “随便2”:“abc”}");
                m_Tools.TextText_HG("jc[" + KeyOne + "][" + SuiBian2 + "]", "->  “abc”" + "(带双引号)".AddWhite(), 30);
                m_Tools.TextText_HG("jc[" + KeyOne + "][" + SuiBian2 + "]" + ".Value".AddYellow(), "->  abc", 30);
                m_Tools.TextText_HG("jc[" + KeyOne + "][" + SuiBian2 + "].AsInt", "->  0" + "(不报错，内使用 int.TryParse)".AddWhite(), 30);
                m_Tools.TextText_HG("jc[“Key 2”][“随便4”]" + ".AsInt".AddYellow(), "->  10", 30);
            });


        }


        private static readonly string KEYSTR = "”key“".AddYellow();
        private static readonly string VALUESTR = "”value“".AddYellow();


        private void DrawSimpleJSON2()
        {
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("“StrDictionary.json” 文件：" + "(开头使用 [ ])".AddOrange());
                m_Tools.Text_H("[");
                m_Tools.Text_H("     {");
                m_Tools.Text_H("          ", KEYSTR, ": ”ATTACK“，");
                m_Tools.Text_H("          ", VALUESTR, ": ”攻击力“");
                m_Tools.Text_H("     }，");
                m_Tools.Text_H("     {");
                m_Tools.Text_H("          ", KEYSTR, ": ”DEFENSE“，");
                m_Tools.Text_H("          ", VALUESTR, ": ”防御力“");
                m_Tools.Text_H("     }，");
                m_Tools.Text_H("     {");
                m_Tools.Text_H("          ", KEYSTR, ": ”HP“，");
                m_Tools.Text_H("          ", VALUESTR, ": ”生命值“");
                m_Tools.Text_H("     }");
                m_Tools.Text_H("]");
            });
            AddSpace_3();
            m_Tools.BiaoTi_B("解析 ->  得到 " + "JSONArray ja".AddLightBlue());
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("TextAsset data = Resources.Load<TextAsset>(“StrDictionary”);");
                m_Tools.Text_H("ja = JSON.Parse(data.text)", ".AsArray;".AddBlue());
            });

            m_Tools.BiaoTi_B("功能 ：" + "传入 英文  -> 得到对应中文".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public string 功能(string 英文Key)");
                m_Tools.Text_H("{");
                m_Tools.Text_H("     foreach (JSONNode n in ja)");
                m_Tools.Text_H("     {");
                m_Tools.Text_H("          JSONClass jObject = n.AsObject;");
                m_Tools.Text_H("          if(jObject[", KEYSTR, "].Value == 英文Key)");
                m_Tools.Text_H("          {");
                m_Tools.Text_H("              return jObject[", VALUESTR, "];");
                m_Tools.Text_H("          }");
                m_Tools.Text_H("     }");
                m_Tools.Text_H("     return null;");
                m_Tools.Text_H("}");
            });

        }



        #endregion


        #region Xml 

        private void DrawXML()                                 // Xml
        {
            AddToggleButton("XML 相关网站", "格式化工具", "xml 教程", () =>
            {
                Application.OpenURL("http://web.chacuo.net/formatxml");
            }, () =>
            {
                Application.OpenURL("http://www.w3school.com.cn/example/xmle_examples.asp");

            });

            m_Tools.BiaoTi_O("XML （Extensible Markup Language - " + "扩展性标识语言".AddHui() + "）");
            MyCreate.Box(() =>
            {
                m_Tools.TextText("• 标签可以自定义".AddLightBlue(), "• 用来结构化、存储和传输信息".AddLightBlue());

            });
            m_Tools.BiaoTi_B("XML 结构");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("<?xml version=\"1.0\" encoding=\"gb2312\"?>", "//声明版本号和编码", 100);
                m_Tools.TextText_HG("<note>", "// 根" + "（必须）".AddLightGreen(), 100);
                m_Tools.TextText_HG("   <to> 普通 </to>", "// 子元素节点", 100);
                m_Tools.TextText_HG("   <file type=“gif”> 带属性.gif </file>", "// 属性声明(必须双引号)", 100);
                m_Tools.TextText_HG("</note>", "// 根 结束", 100);
            });
            m_Tools.BiaoTi_B("XML 语法规则");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_B("1. 必须有关闭标签  ", "<node/> 或者 <node></node>".AddGreen());
                m_Tools.Text_B("2. 标签对大小写敏感，必须正确地嵌套", "  <node><p></p></node>".AddGreen());
                m_Tools.Text_B("3. 属性必须加上引号（不限单/双引号）");
                m_Tools.TextText_RG("错 <node id =101>", "对 <node id =“101”> 或 <node id ='101'>");
            });
            m_Tools.BiaoTi_B("XML 命名规则");

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("1. 名字可以包含", "中文(需要在 xml 声明时指定 encoding 类型)".AddGreen());
                m_Tools.Text_L("2. 名字不能以", "数字、标点符号、字符“xml”、“XML” 开头".AddRed());
                m_Tools.Text_L("3. 名字不可以包含", "空格、冒号".AddRed());

            });

            m_Tools.BiaoTi_O("XML 编辑相关的类 " + "（属性 System.Xml 下）".AddLightGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("XmlDocument  " + "(xml读取和写入等功能)".AddGreen());
                m_Tools.TextText_BL("CreateElement", "创建一个元素");
                m_Tools.TextText_BL("AppendChild", "往节点下追加根节点");
                m_Tools.TextText_BL("Save", "保存 xml 文件");
                AddSpace();
                MyCreate.Text("XMLDeclaration  ");
                m_Tools.TextText_BL("CreateXmlDeclaration", "创建 xml 的声明节点");
                AddSpace();
                MyCreate.Text("XmlElement  " + "(用于获取)".AddGreen());
                m_Tools.TextText_BL("GetElementsByTagName", "获取所有子节点元素");
                m_Tools.TextText_BL("SetAttribute", "设置元素属性");
                m_Tools.TextText_BL("GetAttribute", "获得元素的属性");
                m_Tools.TextText_BL("InnerText", "设置中间的值");
                m_Tools.TextText_BL("InnerXml", "设置中间的值内含xml");
            });

        }


        private void DrawXML1()                                // Xml例子1
        {
            m_Tools.BiaoTi_B(MapLoadCfgStr + ".xml 文件");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("<?xml version=“1.0” encoding=“UTF - 8” standalone=“yes”?>");
                m_Tools.Text_H("<", MapLoadCfgStr, " xmlns:xsi=“http://www.w3.org/2001/XMLSchema-instance”>");
                m_Tools.TextText_HG("   <info" + MapIDStr + "=“1000”>", "// 对应 uint ID", 140);
                m_Tools.TextText_HG("       <" + NameCnStr + ">奥斯深渊新手</" + NameCnStr + ">", "// 对应 string Name", 140);
                m_Tools.TextText_HG("       <" + PlayerNumStr + ">6</" + PlayerNumStr + ">", "// 对应 int PlayerNum", 140);
                m_Tools.Text_H("   </info>");

                m_Tools.Text_H("   <info" + MapIDStr, "=“1001”>");
                m_Tools.Text_H("       <", NameCnStr, ">圣光营地</", NameCnStr, ">");
                m_Tools.Text_H("       <", PlayerNumStr, ">10</", PlayerNumStr, ">");
                m_Tools.Text_H("   </info>");

                m_Tools.Text_H("   <info" + MapIDStr, "=“1002”>");
                m_Tools.Text_H("       <", NameCnStr, ">奥斯深渊</", NameCnStr, ">");
                m_Tools.Text_H("       <", PlayerNumStr, ">10</", PlayerNumStr, ">");
                m_Tools.Text_H("   </info>");
                m_Tools.Text_H("</", MapLoadCfgStr, ">");
            });

            m_Tools.BiaoTi_B("对应的 MapBean 的几个属性");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("public uint ID；   public string Name；    public int PlayerNum；");
            });

            m_Tools.BiaoTi_B("解析");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Ctrl_LoadManager.Instance.LoadResAsyn<TextAsset>(“路径/", MapLoadCfgStr, "”, (xmlfile) =>");
                m_Tools.Text_H("{");
                m_Tools.Text_H("     XmlDocument mXmlDoc = new XmlDocument();");
                m_Tools.Text_H("     mXmlDoc.LoadXml(xmlfile.text);");
                m_Tools.Text_H("     XmlNodeList ", InfoNodeListStr, " = mXmlDoc.SelectSingleNode(“", MapLoadCfgStr, "”)", ChildNodesStr);
                m_Tools.Text_H("     for (int i = 0; i < ", InfoNodeListStr, ".Count; i++)");
                m_Tools.Text_H("     {");
                m_Tools.Text_H("         XmlAttribute idAtt = (", InfoNodeListStr, "[i] as XmlElement).", GetAttributeNodeStr, "(“", MapIDStr, "”);");
                m_Tools.Text_H("         if ( idAttribute == null)     { continue; }");
                m_Tools.Text_H("         MapBean ", BeanStr, " = new MapBean();");
                m_Tools.Text_H("         ", BeanStr, ".Id = Convert.ToUInt32(idAtt", InnerTextNodeStr, ");");
                m_Tools.Text_H("         foreach (XmlElement xEle in ", InfoNodeListStr, "[i]", ChildNodesStr, ")");
                m_Tools.Text_H("             {");
                m_Tools.Text_H("                  switch (xEle.Name)");
                m_Tools.Text_H("                  {");
                m_Tools.Text_H("                        case “", NameCnStr, "”:");
                m_Tools.Text_H("                                ", BeanStr, ".Name = Convert.ToString(xEle", InnerTextNodeStr, ");");
                m_Tools.Text_H("                                break;");
                m_Tools.Text_H("                        case “", PlayerNumStr, "”:");
                m_Tools.Text_H("                                ", BeanStr, ".PlayerNum = Convert.ToString(xEle", InnerTextNodeStr, ");");
                m_Tools.Text_H("                                break;");
                m_Tools.Text_H("                  }");
                m_Tools.Text_H("             }");
                m_Tools.Text_H("     }");
                m_Tools.Text_H("}");

            });
        }



        private void DrawXML2()                                // Xml例子2
        {
            m_Tools.BiaoTi_B(RandomNameStr + ".xml 文件");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("<?xml version=“1.0” encoding=“UTF - 8” standalone=“yes”?>");
                m_Tools.Text_H("<", RandomNameStr, ">");
                m_Tools.Text_H("     <info ", Name1Str, "=“银” ", Name2Str, "=“狼” ", Name3Str, "=“将军”/>");
                m_Tools.Text_H("     <info ", Name1Str, "=“末” ", Name2Str, "=“世” ", Name3Str, "=“侯爵”/>");
                m_Tools.Text_H("     <info ", Name1Str, "=“苍” ", Name2Str, "=“月” ", Name3Str, "=“守护者”/>");
                m_Tools.Text_H("     <info ", Name1Str, "=“灵” ", Name2Str, "=“影” ", Name3Str, "=“暴君”/>");
                m_Tools.Text_H("</", RandomNameStr, ">");
            });
            m_Tools.BiaoTi_B("解析 " + "(分别将 Name1、Name2、Name3 存储在 3 个集合当中)".AddLightBlue());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Ctrl_LoadManager.Instance.LoadResAsyn<TextAsset>(“路径/", RandomNameStr, "”, (xmlfile) =>");
                m_Tools.Text_H("{");
                m_Tools.Text_H("     XmlDocument mXmlDoc = new XmlDocument();");
                m_Tools.Text_H("     mXmlDoc.LoadXml(xmlfile.text);");
                m_Tools.Text_H("     XmlNodeList ", InfoNodeListStr, " = mXmlDoc.SelectSingleNode(“", RandomNameStr, "”)", ChildNodesStr);
                m_Tools.Text_H("     for (int i = 0; i < ", InfoNodeListStr, ".Count; i++)");
                m_Tools.Text_H("     {");
                m_Tools.Text_H("         for (int j = 1; j <= 3; ++j)");
                m_Tools.Text_H("         {");
                m_Tools.Text_H("              XmlElement xmlEle = ", InfoNodeListStr, "[i] as XmlElement;");
                m_Tools.Text_H("              string name = ", "“Name” + j.ToString();".AddBlue());
                m_Tools.Text_H("              if (xmlEle", GetAttributeNodeStr, "(nodeName) != null)");
                m_Tools.Text_H("              {");
                m_Tools.Text_H("                  string res = xmlEle", GetAttributeNodeStr, "(nodeName)", InnerTextNodeStr);
                m_Tools.Text_H("                  if(if (j == 1))  集合1.Add(res)");
                m_Tools.Text_H("                  if(if (j == 2))  集合2.Add(res)");
                m_Tools.Text_H("                  if(if (j == 3))  集合3.Add(res)");
                m_Tools.Text_H("              }");
                m_Tools.Text_H("         }");
                m_Tools.Text_H("     }");
                m_Tools.Text_H("}");

            });

        }


        #endregion


        #region Protobuf


        private void DrawProtobuf()                              // Protobuf
        {
            m_Tools.BiaoTi_B("Protobuf 简介");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("Protocol Buffers", "google 推出的一种二进制数据交换格式", -30);
                m_Tools.TextText_OY("Protocol -net", "Protocol Buffer 的 .NET 实现", -30);
                m_Tools.GuangFangWenDan("https://github.com/mgravell/protobuf-net", "github");
                MyCreate.Text("优点：（小、快、好）".AddGreen());
                m_Tools.Text_L("1. 数据描述文件只需要原来的 1/10 至 1/3");
                m_Tools.Text_L("2. 解析速度是原来的 20 ~ 100 倍");
                m_Tools.Text_L("3. 生成了更容易在编程中使用的数据访问类");
                m_Tools.Text_L("4. 同样支持多种编程语言");
                MyCreate.Text("应用领域：".AddGreen());
                m_Tools.Text_L("网络传输（节省流量）、配置文件、数据存储");
            });


            AddSpace();

            m_Tools.BiaoTi_B("封装使用 Proto 工具类");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HG("public static string Serialize2String<T>(T data)", "//序列化成 string", 180);
                m_Tools.Text_H("     using(MemoryStream ms =new MemoryStream())");
                m_Tools.Text_H("          Serializer.Serialize(ms, data);");
                m_Tools.Text_H("          return Encoding.UTF8.GetString(ms.ToArray());");
                AddSpace_15();
                m_Tools.TextText_HG("public static void Serialize2File<T>(string " + PathStr + ",T data)", "//序列化成文件", 180);
                m_Tools.Text_H("     using (Stream file = File.Create(path))");
                m_Tools.Text_H("          Serializer.Serialize<T>(file,data);");
                m_Tools.Text_H("          file.Close();");
                AddSpace_15();
                m_Tools.TextText_HG("public static T ParseString<T>(string bin)", "//根据 string 返回对象", 180);
                m_Tools.Text_H("     using (MemoryStream ms =new MemoryStream(Encoding.UTF8.GetBytes(bin)))");
                m_Tools.Text_H("          return Serializer.Deserialize<T>(ms);");
                AddSpace_15();
                m_Tools.TextText_HG("public static T ParseFile<T>(string " + PathStr + ")", "//根据文件路径返回对象", 180);
                m_Tools.Text_H("     using (var fs = File.OpenRead(", PathStr, "))");
                m_Tools.Text_H("          return Serializer.Deserialize<T>(fs);");

            });

        }


        private void DrawProLiZi()                              // Protobuf 例子
        {
            m_Tools.BiaoTi_B("Protobuf 简单例子", true);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_Y("[ProtoContract]");
                m_Tools.Text_H("public class ", UserBeanStr);
                m_Tools.TextText_YG("    [ProtoMember(1)]", "// 从 1 开始的正整数");
                m_Tools.Text_H("    public string Username { get; set; }");
                m_Tools.TextText_YG("    [ProtoMember(2)]", "// Bean类、IList、字典都能使用");
                m_Tools.Text_H("    public int Password { get; set; }");
            });
            MyCreate.Text("写成 Bin 文件" + "（路径要全称 Application.dataPath + ”/User.bin“）".AddLightBlue());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H(UserBeanStr, " user = new ", UserBeanStr, "(Username = ”ab“, Password = 123);");
                m_Tools.Text_H(" using (var fs = File.Create(", PathStr, "))");
                m_Tools.Text_H("     Serializer.Serialize".AddBlue(), "<", UserBeanStr, ">(fs, user);");
                m_Tools.Text_G("// 直接使用 List 也可以的：", "list.Add(user1、user2)");
                m_Tools.Text_G("// Serializer.Serialize<List<", UserBeanStr, ">>(fs, user)");
            });
            MyCreate.Text("解析 Bin 文件");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H(UserBeanStr, " user = null;");
                m_Tools.Text_H("using (var fs = File.OpenRead(", PathStr, "))");
                m_Tools.Text_H("     user =", " Serializer.Deserialize".AddBlue(), "<", UserBeanStr, ">(fs);");
                m_Tools.Text_H("user.Username/user.Password....");
            });
        }


        #endregion


        #region 其他文本


        private void DrawExcel()                                 // Excel
        {

        }

        private void DrawTxt()                                   // Txt
        {
        }


        #endregion


        #region 时间 

        private void DrawTime()                                  // Time Unity 提供的时间工具类
        {
            m_Tools.BiaoTi_B("Time " + "(Unity 提供的时间工具类)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("▪ DateTime  ->", "  结构体".AddGreen(), " -> 要 new 出来");
                m_Tools.Text_L("▪ Time  -> sealed 类 ->  全部都是 ", "Static 属性".AddGreen());
            });
            AddSpace();
            m_Tools.BiaoTi_Y("游戏控制");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("timeScale", "", "1 为正常游戏时间，0 为暂停游戏", "float");

            });
            m_Tools.BiaoTi_Y("帧的间隔");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("deltaTime", "只读", "Update这一帧所用的时间（以秒计）", "float");
                m_Tools.Method_BY("smoothDeltaTime", "只读", "平滑的Time.deltaTime", "float");
                m_Tools.Method_BY("fixedDeltaTime", "", "FixedUpdate 固定的帧速率", "float");
            });
            m_Tools.BiaoTi_Y("游戏启动一直叠加的时间 " + "（不受timeScale的影响 就是暂停时也叠加）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("fixedTime", "只读", "一直 + fixedDeltaTime 固定时间间隔", "float");
                m_Tools.Method_BY("fixedUnscaledTime", "只读", "+ fixedDeltaTime，不受timeScale的影响", "float");
                m_Tools.Method_BY("time", "只读", "一直 + 秒", "float");
                m_Tools.Method_BY("realtimeSinceStartup", "只读", "一直 + 秒，不受timeScale的影响", "float");
                m_Tools.Method_BY("timeSinceLevelLoad", "只读", "从帧开始的时间一直 + 秒", "float");
                m_Tools.Method_BY("unscaledTime", "只读", "未缩放的固定时间 + 秒", "float");
            });


        }

        private void DrawDateTime()                              // DateTime System 提供的时间工具类
        {
            m_Tools.BiaoTi_B("DateTime " + "(System)提供的时间 struct 类".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.datetime(v=vs.110).aspx");
                m_Tools.Text_L("▪ DateTime  ->", "  结构体".AddGreen(), " -> 要 new 出来");
                m_Tools.Text_L("▪ Time  -> sealed 类 ->  全部都是 ", "Static 属性".AddGreen());
                m_Tools.Text_L("▪ 可直接看下面的 DateTime 对照表");
            });
            m_Tools.BiaoTi_O("构造方法" + "(年月日分秒 超出范围会报错)".AddRed());
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("1. 可无参      2.带三个 int，int，int  -> 年月日 ", "（常用）".AddGreen());
                m_Tools.Text_W("3. 带五个 int，int，int，int，int  -> 年月日分秒 ");

            });
            m_Tools.BiaoTi_O("Static 属性");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("Now", "只读", "现在：" + "5/3/2018 15:03:06 PM".AddHui(), "DateTime", -50);
                m_Tools.Method_BY("Today", "只读", "今日：" + "5/3/2018 12:00:00 AM ".AddHui(), "DateTime", -50);
            });
            m_Tools.BiaoTi_O("属性");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("Year", "只读", "年 " + "（1～9999）".AddGreen(), "int", -20);
                m_Tools.Method_BY("Month", "只读", "月 " + "（1～12）".AddGreen(), "int", -20);
                m_Tools.Method_BY("Day", "只读", "天 " + "（1～31）".AddGreen(), "int", -20);
                m_Tools.Method_BY("Hour", "只读", "小时 " + "（0～23）".AddGreen(), "int", -20);
                m_Tools.Method_BY("Minute", "只读", "分 " + "（0～59）".AddGreen(), "int", -20);
                m_Tools.Method_BY("Second", "只读", "秒 " + "（0～59）".AddGreen(), "int", -20);
                m_Tools.Method_BL("DayOfWeek", "只读", "这天是星期几", "DayOfWeek 枚举", -20);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_L("DayOfWeek.Sunday = 0 -> 星期日     DayOfWeek.Monday = 1 -> 星期一");
                });
                m_Tools.Method_BL("DayOfYear", "只读", "该年中的第几天", "int", -20);
                m_Tools.Method_BL("Millisecond", "只读", "毫秒", "int", -20);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_L("两秒之间相关 1000 毫秒");
                    m_Tools.Text_G("1 秒   <-   1000 毫秒  ->   下 1 秒");
                });

            });
            m_Tools.BiaoTi_O("方法");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("AddDays/");
            });
            m_Tools.BiaoTi_O("Static 方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("DaysInMonth", "int 年，int 月","这年这月有几天","int");
            });
            m_Tools.BiaoTi_B("格式化日期");
            MyCreate.Box(() =>
            {
                MyCreate.SelectText("DateTime.Now.ToString(\"yyyy - MM - dd HH: mm:ss: ffff\")");
                m_Tools.Text_Y("结果：2018-03-05 15:03:09:542");
                m_Tools.Text_Y("    yyyy（年）MM（月） dd（日） HH（小时） mm（分）ss: ffff");
            });
        }

        private void DrawDataTime2()                             // DateTime 对照表
        {
            MyCreate.Text("下面数据都是直接打印出来的".AddGreen());
            m_Tools.BiaoTi_B("构造函数");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BY("new DateTime()", mDemoTime1.ToString(), 80);
                m_Tools.TextText_BY("new DateTime(2018,8,8)", mDemoTime2.ToString(), 80);
                m_Tools.TextText_BY("new DateTime(2018,8,8,2,20,30)", mDemoTime3.ToString(), 80);
            });
            m_Tools.BiaoTi_B("Satic 属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("DateTime.Now" + "（当前时间 会一直动）".AddGreen(), DateTime.Now.ToString(), 80);
                m_Tools.TextText_OY("DateTime.Today", DateTime.Today.ToString(), 80);

            });
            m_Tools.BiaoTi_B("ToString 格式化日期");
            MyCreate.Box(() =>
            {
                m_Tools.SelectTextText_Y("ToString()", mDemoTime4.ToString(), 80);
                m_Tools.SelectTextText_Y("ToString(\"yy/MM/dd\")", mDemoTime4.ToString("yy/MM/dd"), 80);
                m_Tools.SelectTextText_Y("ToString(\"yy.MM.dd\")", mDemoTime4.ToString("yy.MM.dd"), 80);
                m_Tools.SelectTextText_Y("ToString(\"yy-MM-dd\")", mDemoTime4.ToString("yy-MM-dd"), 80);
                m_Tools.SelectTextText_Y("ToString(\"yyyy.MM.dd\")", mDemoTime4.ToString("yyyy.MM.dd"), 80);
                m_Tools.SelectTextText_Y("ToString(\"yyyy - MM - dd HH: mm:ss: ffff\")", mDemoTime4.ToString("yyyy - MM - dd HH: mm:ss: ffff"), 80);
            });

            AddSpace();
            m_Tools.BiaoTi_B("其他");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("DateTime.Now.Ticks", DateTime.Now.Ticks.ToString(), 80);
                m_Tools.TextText_OY("DateTime.Now.DayOfWeek", DateTime.Now.Date.DayOfWeek.ToString(), 80);

            });

        }

        #endregion

        #region 加载图片方法


        private void DrawLoadTu1()             // FileStream 文件流
        {
            ShowImage(Texture2D1);
            AddSpace();
            m_Tools.BiaoTi_B("核心代码->  方法(文件路径) 返回 Texture2D");

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_G(" // 读取这张图片，创建文件读取流");
                m_Tools.Text_H("FileStream fileStream = new FileStream(路径,FileMode.Open,FileAccess.Read)");
                m_Tools.Text_H("fileStream.Seek(0, SeekOrigin.Begin);");
                m_Tools.TextText_HG("byte[] bytes = new byte[fileStream.Length];","  //把数据存储在这里");
                m_Tools.Text_H("fileStream.Read(bytes, 0, (int)fileStream.Length);");
                m_Tools.TextText_HG("fileStream.Close();", " // 释放文件读取流");
                m_Tools.Text_H("fileStream.Dispose();");
                MyCreate.FenGeXian();
                m_Tools.TextText_HG("Texture2D texture = new Texture2D(随便宽高，不影响);", "// 大小会按原图");
                m_Tools.TextText_HG("texture.LoadImage(bytes);", "// 把上面的数据加到 Texture2D 上");
                m_Tools.Text_H("获得 -> texture;");
            });

            AddSpace_15();
            m_Tools.BiaoTi_L("优".AddWhite()+"缺点");
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("优点：简单，不需要导入其他 Dll");   
                m_Tools.Text_L("缺点：Texture2D 大小不能改变，就是原图大小");   
            });

        }


        private Texture2D LoadText(string path)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(path);
            image = image.GetThumbnailImage(200, 50, () => false, System.IntPtr.Zero);
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] bytes = ms.ToArray();
                Texture2D texture = new Texture2D(64, 64);
                texture.LoadImage(bytes);
                return texture;
            }
        }

        private void DrawLoadTu2()             //System.Drawing
        {
            ShowImage(Texture2D12);
            AddSpace();
            m_Tools.BiaoTi_B("核心代码->  方法(文件路径) 返回 Texture2D");

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("System.Drawing.Image image = System.Drawing.Image.FromFile(路径);");
                m_Tools.Text_G("// Texture2D 会根据下面的宽高调整 缩略图 大小");
                m_Tools.Text_H("image = image.GetThumbnailImage(宽, 高, () => false, System.IntPtr.Zero);");
                m_Tools.Text_H("using (var ms = new MemoryStream())");
                m_Tools.Text_H("{");
                m_Tools.Text_H("    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);");
                m_Tools.Text_H("    byte[] bytes = ms.ToArray();");
                MyCreate.FenGeXian();
                m_Tools.Text_H("    Texture2D texture = new Texture2D(随便宽高，不影响);");
                m_Tools.TextText_HG("    texture.LoadImage(bytes);", "// 把上面的数据加到 Texture2D 上");
                m_Tools.Text_H("    获得 -> texture;");
                m_Tools.Text_H("}");
            });

            AddSpace_15();
            m_Tools.BiaoTi_L("优".AddWhite() + "缺点");
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("优点：大小，保存什么格式都能控制");
                m_Tools.Text_L("缺点：需要先导入 System.Drawing.Dll,Build 那里还要设置 .NET 2.0");
            });

        }


        private void DrawLoadTu3()             // WWW 网络
        {

            m_Tools.BiaoTi_B("1. 使用 WWW ");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("WWW www = new WWW(路径);");
                m_Tools.Text_H("yield return www");
                m_Tools.TextText_HG("Texture2D texture = www.textureNonReadable;","// 只可读，不可写", 120);
                m_Tools.TextText_WG("或者 Texture2D texture = www.texture;","// 可诗可写", 120);
                m_Tools.Text_H("www.Dispose()");
            });
            AddSpace_15();
            m_Tools.BiaoTi_B("2. 使用 UnityWebRequest ");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("using (","UnityWebRequest".AddBlue()," request = ","UnityWebRequestTexture".AddBlue(),".GetTexture(路径))");
                m_Tools.Text_H("{");
                m_Tools.TextText_HG("    request.timeout = timeOut;","// 设置超时时间",120);
                m_Tools.TextText_HG("    yield return request.SendWebRequest();","// 发送请求",120);
                m_Tools.TextText_HG("    if (isNoError(request))","// 请求没有错误的话", 120);
                m_Tools.Text_H("    {");
                m_Tools.Text_H("         Texture2D texture = ","DownloadHandlerTexture".AddBlue(),".GetContent(request);");
                m_Tools.Text_H("    }");
                m_Tools.Text_H("}");
            });


            //            Texture2D texture = null;
            //            WWW www = new WWW(url);
            //            while (!www.isDone)
            //            {
            //                MyCreate.ShowProgressBar("下载图片", www.progress);
            //            }
            //            MyCreate.ProgressBarFinish();
            //            if (www.error != null)
            //            {
            //                MyLog.Red("图片加载失败！！ —— " + www.error);
            //                MyLog.Red("URL —— " + url);
            //                urlK_Texture.Add(url, null);
            //            }
            //            else
            //            {
            //                texture = www.textureNonReadable;
            //                urlK_Texture.Add(url, texture);
            //            }
            //            www.Dispose();
            //            return texture;


        }



        #endregion
    }

}

