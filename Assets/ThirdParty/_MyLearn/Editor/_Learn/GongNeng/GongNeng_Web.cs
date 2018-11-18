using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class GongNeng_Web : AbstactNewKuang
    {
        [MenuItem(LearnMenu.GongNeng_Web)]
        static void Init()
        {
            GongNeng_Web Instance = GetWindow<GongNeng_Web>(false, "");
            Instance.SetupWindow();
        }

        protected override void DrawLeft()
        {

            #region 网络协议知识

            bool isTmp1 = (type == EType.ZhiShi || type == EType.ZhiShi1 || type == EType.ZhiShi2 || type == EType.ZhiShi3);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "网络协议知识";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.ZhiShi ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.ZhiShi);
            }

            if (isTmp1)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ZhiShi1 ? "   HTTP 协议".AddBlue() : "   HTTP 协议");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ZhiShi1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ZhiShi2 ? "   状态码".AddBlue() : "   状态码");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ZhiShi2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ZhiShi3 ? "   TCP/UDP 协议".AddBlue() : "   TCP/UDP 协议");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ZhiShi3);
                }
            }

            #endregion

            AddSpace();

            #region Socket

            bool isTmp2 = (type == EType.Socket || type == EType.Socket1 || type == EType.Socket2 || type == EType.Socket3 || type == EType.Socket4 || type == EType.Socket5);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Socket";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isTmp2 ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Socket1);
            }
            if (isTmp2)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Socket1 ? "   Socket API".AddBlue() : "   Socket API");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Socket1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Socket2 ? "   相关枚举".AddBlue() : "   相关枚举");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Socket2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Socket3 ? "   相关接口与类".AddBlue() : "   相关接口与类");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Socket3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Socket4 ? "   扩展知识".AddBlue() : "   扩展知识");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Socket4);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Socket5 ? "   简单例子".AddBlue() : "   简单例子");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Socket5);
                }

            }
            #endregion

            AddSpace();

            #region 数据库


            bool isTmp3 = (type == EType.Sql || type == EType.Sql1 || type == EType.Sql2 || type == EType.Sql3 || type == EType.Sql4);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "数据库";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Sql ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Sql);
            }
            if (isTmp3)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Sql1 ? "  Sql 语句".AddBlue() : "  Sql 语句");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Sql1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Sql2 ? "  MySQL".AddBlue() : "  MySQL");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Sql2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Sql3 ? "  Bmob 简单数据库".AddBlue() : "  Bmob 简单数据库");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Sql3);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Sql4 ? "  Bmob 过程".AddBlue() : "  Bmob 过程");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Sql4);
                }
            }

            #endregion


            AddSpace();


            #region Unity 网络

            bool isWeb = (type == EType.UnityWeb || type == EType.UnityWeb1 || type == EType.UnityWeb2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Unity 网络";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.UnityWeb ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.UnityWeb);
            }
            if (isWeb)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.UnityWeb1 ? "  WWW".AddBlue() : "  WWW");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.UnityWeb1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.UnityWeb2 ? "  多人局域网".AddBlue() : "  多人局域网");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.UnityWeb2);
                }
            }


            #endregion

            AddSpace();

            #region Suct

            bool isSuct = (type == EType.Suct || type == EType.Suct1 || type == EType.Suct2);


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Suct";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Suct ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Suct);
            }
            if (isSuct)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Suct1 ? "  配置环境".AddBlue() : "  配置环境");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Suct1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Suct2 ? "  使用".AddBlue() : "  使用");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Suct2);
                }
            }


            #endregion


            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Photon";

            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Photon ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Photon);
            }

        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.ZhiShi:         DrawRightPage1(DrawZhiShi);        break;
                case EType.ZhiShi1:        DrawRightPage3(DrawHTTP);          break;
                case EType.ZhiShi2:        DrawRightPage3(DrawMa);            break;
                case EType.ZhiShi3:        DrawRightPage4(DrawTCPUDP);        break;
                case EType.Socket1:        DrawRightPage5(DrawAPI);           break;
                case EType.Socket2:        DrawRightPage6(DrawEnum);          break;
                case EType.Socket3:        DrawRightPage7(DrawOther);         break;
                case EType.Socket4:        DrawRightPage8(DrawKuaiZhan);      break;
                case EType.Socket5:        DrawRightPage1(DrawLiZI);          break;
                case EType.Sql:            DrawRightPage3(DrawJieShao);       break;
                case EType.Sql1:           DrawRightPage4(DrawSqlYuJu);       break;
                case EType.Sql2:           DrawRightPage5(DrawMySQL);         break;
                case EType.Sql3:           DrawRightPage6(DrawBmob);          break;
                case EType.Sql4:           DrawRightPage7(DrawBmob2);         break;
                case EType.UnityWeb:       DrawRightPage1(DrawUnityWeb);      break;
                case EType.UnityWeb1:      DrawRightPage1(DrawWWW);           break;
                case EType.UnityWeb2:      DrawRightPage1(DrawDuoRen);        break;
                case EType.Suct:           DrawRightPage3(DrawScut);          break;
                case EType.Suct1:          DrawRightPage4(DrawSuctBeiZhi);    break;
                case EType.Photon:         DrawRightPage6(DrawPhoton);        break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.ZhiShi2:
                    mWindowSettings.pageWidthExtraSpace.target = 60;
                    break;
                case EType.Socket1:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.Socket2:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.Socket3:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.Socket4:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.Socket5:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.Sql:
                    mWindowSettings.pageWidthExtraSpace.target = -50;
                    break;
                case EType.Sql1:
                    mWindowSettings.pageWidthExtraSpace.target = -50;
                    break;
                case EType.Sql2:
                    mWindowSettings.pageWidthExtraSpace.target = -50;
                    break;
                case EType.Sql3:
                    mWindowSettings.pageWidthExtraSpace.target = -20;
                    break;
                case EType.Suct1:
                    mWindowSettings.pageWidthExtraSpace.target = 50;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target =0;
                    break;
            }
        }


        #region 私有
        private bool isAddressFamily, isSocketType, isProtocolType, isSend, isSocketError, isReceive, isSocketFlags, isBeginConnect;
        private bool isBeginReceive, isEndReceive, isEndAccept, isBeginAccept, isTong, isListen, isBeginSend, isEndConnect;
        private bool  isPost, isDownload, isDownloadHandler, isTex, isAB, isFile, isMovieTexture, isClip, isIIS05;
        private bool isWorkbench, isUse, isCreate, isBiao, isGuan, isShuJu, isGuanLi,is01,is02;
        private bool isTu, isInternaet, isIIS02, isIIS03, isIIS04, isDaiMa ,isMiMa, _isTieDian;
        private bool isTwoMethod, isDes, isZiDai, isFrist, isShowByWhere, isAddType;
        private static readonly string YuanData = "原数据".AddYellow();
        private static readonly string LastData = "最终数据".AddGreen();
        private static readonly string LengthData = "数据长度标识".AddBlue();
        private static readonly string ShuJuStr = " 数据长度 ".AddYellow();
        private static readonly string MethodStr = "方法".AddGreen();
        private static readonly string ZhuZaiStr = "阻塞".AddRed();
        private static readonly string serverSocketStr = "serverSocket".AddBlue();
        private static readonly string clientSocketStr = "clientSocket".AddBlue();
        private static readonly string StartAcceptStr = "StartAccept".AddYellow();
        private static readonly string E_ClinetConnectionStr = "E_ClinetConnection".AddWhite();

        private const string BmobWeb = @"www.bmob.cn";
        private const string BmobJiaoCheng = @"http://docs.bmob.cn/unity/developdoc/index.html?menukey=develop_doc&key=develop_unity";

        enum DoTestEnum
        {
            增删改,
            查,
            用户
        }

        enum BmobType
        {
            BmobTable,
            BmobUser
        }


        private DoTestEnum m_DoTestEnum = DoTestEnum.查;
        private BmobType m_BmobType = BmobType.BmobTable;



        private EType type = EType.ZhiShi;
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
            return "网络总结";
        }


        private enum EType
        {
            ZhiShi,ZhiShi1,ZhiShi2,ZhiShi3,
            Socket,Socket1,Socket2, Socket3,Socket4,Socket5,
            Sql,Sql1,Sql2,Sql3, Sql4,
            UnityWeb,UnityWeb1,UnityWeb2,
            Suct,Suct1,Suct2,
            Photon,
        }



        private void DesByWhere(int num, string str1, string str2)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.Text((num + ".").AddWhite() + str1.AddBlue(), 250);
                MyCreate.Text(str2.AddWhite());
            });
        }

        private void DesByWhere_Long(int num, string str1, string str2)
        {
            MyCreate.Text((num + ".").AddWhite() + str1.AddBlue());
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(100);
                MyCreate.Text(str2.AddWhite());
            });
        }
        #endregion


        #region 网络协议知识

        private void DrawZhiShi()                              // 网络协议知识
        {
            m_Tools.BiaoTi_O("各种协议简单总结");
            MyCreate.Box(() =>
            {
                MyCreate.Text("短连接协议 ：" + "HTTP 协议".AddYellow());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("请求".AddBlue(), "（Get、Post） ->", " 响应".AddBlue(), "(状态码 + 内容 )");
                });
                MyCreate.Text("长连接 ：" + "TCP/IP 协议".AddYellow());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("IP + 端口 <- 通信 -> IP + 端口");
                    m_Tools.Text_H("应用", "[数据]".AddWhite(), "-> 加TCP、IP -> ", "Socket".AddBlue(), " -> 解IP、TCP ->", "[数据]".AddWhite(), "另一应用");
                });

                MyCreate.Text("其他协议：文件传输协议" + "（FTP）".AddYellow() + ",  简单邮件传送协议" + "（SMTP）".AddYellow());
            });

            AddSpace_3();
            m_Tools.BiaoTi_O("因特网 —— 体系结构");
            MyCreate.Box(() =>
            {
                MyCreate.Text("客户机/服务器体系结构 " + "(彼此之间不直接通信)".AddGreen());
                m_Tools.TextText_BL("   [服务器]", "[客户机]", 120);
                m_Tools.TextText_BL("▪ 总是打开", "▫ 总是打开或间歇打开", 80);
                m_Tools.TextText_BL("▪ 为多个客户机请求提供服务", "▫ 向服务器发出请求", 80);
                m_Tools.TextText_BL("▪ 永久的 IP 地址", "▫ 具有动态的 IP 地址", 80);
                m_Tools.TextText_BL("▪ 可以扩展为服务器场景（主机群集）", "", 80);
                MyCreate.Text("纯 P2P 体系结构（peer - to - peer）");
                m_Tools.TextText("▪ 不需要打开的服务器".AddBlue(), "▪ 任意端系统(对等方)可以直接通信".AddBlue(),50);
                m_Tools.TextText("▪ 对等方间歇地连接，IP 地址不固定".AddBlue(), "▪ 例子：文件分发、因特网电话等".AddBlue(),50);

            });

        }


        private void DrawHTTP()                                  // HTTP协议
        {
            m_Tools.BiaoTi_B("短连接协议 ：超文本传输协议" + "（HyperText Transfer Protocol）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_L("HTTP 协议使用的底层运输协议是" + " TCP".AddGreen());
                m_Tools.BiaoTi_L("HTTP 协议的默认端口： " + "80".AddGreen());
                m_Tools.BiaoTi_L("HTTP 请求响应模式");
                m_Tools.Text_G("HTTP 协议永远都是客户端发起请求，服务器回送响应");
                m_Tools.Text_H("                 ————— 请求 —————▶");
                m_Tools.Text_Y("客户端（Client）                                 服务器（Server）");
                m_Tools.Text_H("                 ◀————— 响应 —————");
                MyCreate.Text("特点：");
                m_Tools.Text_G("1.短小快", " 连接、请求".AddHui(), "（GET、POST）".AddLightGreen(), "、响应、断开，通信速度快".AddHui());
                m_Tools.Text_G("2.无连接", " 响应完就断开连接，不关我 p 事了".AddHui());
                m_Tools.Text_G("3.无状态", " 不会记得上次的事件".AddHui());
                m_Tools.BiaoTi_L("HTTP 状态码");
                m_Tools.TextText_YG("1XX", "表示已经接受请求，继续处理", -100);
                m_Tools.TextText_YG("2XX", "表示接受请求", -100);
                m_Tools.TextText_YG("3XX", "重定向，要完成请求必须进行更近一步的操作", -100);
                m_Tools.TextText_YR("4XX", "客户端错误，请求有语法错误或者请求无法实现", -100);
                m_Tools.TextText_YR("5XX", "服务器错误", -100);
                m_Tools.BiaoTi_L("常见的错误4XX状态码");
                m_Tools.TextText_YR("400", "Bad Request".AddHui() + "  错误的请求", -100);
                m_Tools.TextText_YR("401", "Unauthorized ".AddHui() + "需要先登录有效的用户名和密码", -100);
                m_Tools.TextText_YR("403", "Forbidden".AddHui() + "   服务器拒绝处理这个请求（权限设置）", -100);
                m_Tools.TextText_YR("404", "Not Found ".AddHui() + " 服务器无法回应", -100);
                m_Tools.BiaoTi_L("Cookie 说明：");
                m_Tools.Text_H("允许 Web 站点跟踪、识别用户");
                m_Tools.Text_H("服务器可以限制用户访问，或把内容与用户身份关联");
                MyCreate.Text("用途：身份认证、推荐广告、用户会话状态等");
                MyCreate.Text("缺陷：站点可以知道用户许多信息、不利于用户隐私保护");



            });
            AddSpace_3();
            m_Tools.BiaoTi_B("HTTP 请求：" + "Get".AddLightBlue() + " 和 " + "Post".AddLightBlue());
            MyCreate.Box(() =>
            {
                MyCreate.Text("传递的表单".AddGreen());
                m_Tools.TextText_BL("Get:", "通过 URL 传递表单值", -140);
                m_Tools.TextText_BL("Post:", "传递的表单值是隐含于 http 报文中，url 中看不到", -140);
                MyCreate.Text("Get 通过 URL 传递数据的格式".AddGreen());
                m_Tools.Text_L("▪ URL 中请求的文件名后跟着 “？” ");
                m_Tools.Text_L("▪ 多组键值对之间用 “&” 进行分割");
                m_Tools.Text_L("▪ 包含汉字、特殊符号，需要对这些字符进行编码");

                MyCreate.Text("优点/缺点".AddGreen());
                m_Tools.TextText_BL("Get:", "便于测试、简洁明了 / 不可大量数据，安全性相对低", -140);
                m_Tools.TextText_BL("Post:", "可大量数据，安全必相对高 / 测试不太方便", -140);
                MyCreate.Text("例子：".AddGreen());
                m_Tools.TextText_BH("Get:", "http://xxx.cn/xxx?User=11&Password=123", -140);
                m_Tools.TextText_BG("", "// 发送了两组数据 User 和 Password", -140);
                m_Tools.TextText_BH("Post:", "http://xxx.cn/xxx", -140);
                m_Tools.TextText_BG("", "// 两组数据 User 和 Password 会隐含于报文中", -140);

            });
        }

        private void DrawMa()                                     // 状态码
        {
            m_Tools.BiaoTi_B("4xx (请求错误)，表示请求出错，妨碍了服务器的处理");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("400", "(错误请求)".AddRed() + "服务器不理解请求的语法", -100);
                m_Tools.TextText_BL("401", "(未授权)".AddRed() + "请求要求身份验证", -100);
                m_Tools.TextText_BL("403", "(禁止)".AddRed() + "服务器拒绝请求", -100);
                m_Tools.TextText_BL("404", "(未找到)".AddRed() + "服务器找不到请求的网页", -100);
                m_Tools.TextText_BL("405", "(方法禁用)".AddRed() + "禁用请求中指定的方法", -100);
                m_Tools.TextText_BL("406", "(不接受)".AddRed() + "无法使用请求的内容特性响应请求的网页", -100);
                m_Tools.TextText_BL("407", "(需要代理授权)".AddRed() + "与 401 类似，但指定请求者应当授权使用代理", -100);
                m_Tools.TextText_BL("408", "(请求超时)".AddRed() + "服务器等候请求时发生超时", -100);
                m_Tools.TextText_BL("409", "(冲突)".AddRed() + "服务器在完成请求时发生冲突", -100);
                m_Tools.TextText_BL("410", "(已删除)".AddRed() + "请求的资源已永久删除", -100);
                m_Tools.TextText_BL("411", "(需要有效长度)".AddRed() + "服务器不接受不含有效内容长度标头字段的请求", -100);
                m_Tools.TextText_BL("412", "(未满足前提条件)".AddRed() + "服务器未满足请求者在请求中设置的其中一个前提条件", -100);
                m_Tools.TextText_BL("413", "(请求实体过大)".AddRed() + "请求实体过大，超出服务器的处理能力", -100);
                m_Tools.TextText_BL("414", "(请求的 URL 过长)".AddRed() + "请求的 URL 过长，服务器无法处理", -100);
                m_Tools.TextText_BL("415", "(不支持的媒体类型)".AddRed() + "请求的格式不受请求页面的支持", -100);
                m_Tools.TextText_BL("416", "(请求范围不符合要求)".AddRed() + "页面无法提供请求的范围", -100);
                m_Tools.TextText_BL("417", "(未萍踪期望值)".AddRed() + "服务器未满足”期望“请求标头字段的要求", -100);
            });
            AddSpace();
            m_Tools.BiaoTi_B("5xx (服务器错误)，表示服务器在尝试处理请求时发生内部错误");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("500", "(服务器内部错误)".AddRed() + "服务器遇到错误，无法完成请求", -100);
                m_Tools.TextText_BL("501", "(尚未实施)".AddRed() + "服务器不具备完成请求的功能", -100);
                m_Tools.TextText_BL("502", "(错误网关)".AddRed() + "服务器网关或代理收到无效响应", -100);
                m_Tools.TextText_BL("503", "(服务不可用)".AddRed() + "服务器目前无法使用（例:由于超载或停机维护）", -100);
                m_Tools.TextText_BL("504", "(网关超时)".AddRed() + "服务器网关或代理没有及时收到请求", -100);
                m_Tools.TextText_BL("505", "(HTTP 版本不受支持)".AddRed() + "服务器不支持请求中所用的 HTTP 协议版本", -100);
            });

        }



        private void DrawTCPUDP()                                   // TCP UDP 协议
        {
            m_Tools.BiaoTi_B("TCP —— 可靠的传输服务");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("通信进程可以无差错、按适当顺序交付发送的数据");
                m_Tools.Text_H("没有数据丢失和重复");
                m_Tools.Text_L("能保证交付所有的数据，但并不保证这些数据传输的速率以及传输时延");
                m_Tools.Text_L("TCP 协议", "不适合实时应用".AddGreen());
            });

            AddSpace();
            MyCreate.Window("TCP/IP 网络模型", () =>
            {
                m_Tools.TextText_BY("应用层", "↓ ".AddLightBlue() + "应用程序发出" + "数据".AddGreen() + "，带端口", -75);
                m_Tools.TextText_BY("传输层", "↓ ".AddLightBlue() + "使用 " + "TCP".AddGreen() + " 或 " + "UDP".AddGreen() + " 协议", -75);
                m_Tools.TextText_BY("网络层", "↓ ".AddLightBlue() + "使用 IP 协议添加 " + "IP".AddGreen(), -75);
                m_Tools.TextText_BY("物理+数据链路", "   ".AddLightBlue() + "中继器等互联设备", -75);
            });
            AddSpace_15();
            MyCreate.Window("Socket", () =>
            {
                m_Tools.TextText_BY("应用层", "↓ ".AddLightBlue() + "应用程序发出" + "数据".AddGreen(), -75);
                m_Tools.TextText_BY("Socket 抽象层", "↓ ".AddLightBlue() + "封装了 " + "TCP/UDP、IP 、端口".AddGreen(), -75);
                m_Tools.TextText_BY("物理+数据链路", "   ".AddLightBlue() + "中继器等互联设备", -75);
            });
            AddSpace_15();
            MyCreate.Window("网络交互", () =>
            {
                m_Tools.Text_Y("IP :192.168.1.2                            IP :192.168.1.3");
                m_Tools.Text_H("                  ——————————▶");
                m_Tools.Text_Y("QQ (端口 4000)       ", "通信协议 ".AddHui(), "          (端口 4000) QQ");
                m_Tools.Text_H("                  ◀——————————");
                m_Tools.Text_L("▪ 互联网通过 IP 定位电脑");
                m_Tools.Text_L("▪ 在电脑中通过 Prot 定位程序");
                m_Tools.Text_L("▪ 程序和程序间通过协议定义通信数据格式");
            });

            m_Tools.Text_W("图解：", ref isTu, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711235115956-95912260.png");
            });

            MyCreate.AddSpace(20);
            MyCreate.Heng(() =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.Shu(() =>
                    {
                        m_Tools.Text_Y("1. 指定要连接服务端的 ", "IP".AddGreen(), " 和", " 端口".AddGreen());
                        m_Tools.Text_Y("2. 通过 Socket 对象", "指明 TCP".AddGreen(), " 连接");
                    });
                });
                MyCreate.AddSpace(180);
            });
            m_Tools.Text_Y("客户端 Socket   ", "─────────────▶".AddHui(), "  服务器 Socket".AddOrange());
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(110);
                MyCreate.Box(() =>
                {
                    MyCreate.Shu(() =>
                    {
                        m_Tools.Text_O("1. 接收客户连接请求", "（但不负责与客户端通信）".AddGreen());
                        m_Tools.Text_O("2. 每成功接收到一个客户端便", "产生一个 Socket".AddGreen());
                        m_Tools.Text_O("3. 这个 Socket 负责与客户端", "通信".AddGreen());
                    });
                });

            });

            AddSpace();
            m_Tools.BiaoTi_B("UDP —— 用户数据报协议");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("没有流控，没有握手，没有成功确认，一个数据包发过去就不管");
                MyCreate.Text("快的同时不可靠，比如流媒体，偶尔丢失错乱几个包不是大问题");
                m_Tools.Text_H("无连接：".AddBlue(), "两个进程通信前没有握手过程");
                m_Tools.Text_H("不可靠数据传输：".AddBlue(), "不保证能够被接收或收到的报文是乱序到达");
                m_Tools.Text_H("没有拥塞控制机制：".AddBlue(), "发送进程可以在任意速率发送数据");
                m_Tools.Text_B("不提供时延保证:", "就是错过了就错过了，不会保证留下记录".AddHui());
                m_Tools.Text_G("适合实时应用".AddGreen());
            });
        }


        #endregion


        #region 数据库

        private void DrawJieShao()                               // 数据库介绍
        {
            AddToggleButton("官方网页", "MySQL", "Oracle", () =>
            {
                Application.OpenURL("https://www.mysql.com/");
            }, () =>
            {
                Application.OpenURL("https://www.oracle.com/index.html");

            });
            AddSpace();
            m_Tools.BiaoTi_B("什么是数据库？");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("Excel就是一个数据表，人操作");
                m_Tools.Text_L("MySQL是一个数据库，便于程序操作，便于存储百万以上级别的数据");
                m_Tools.Text_L("关系数据库：Oracle 、 MySQL 、 SQL Server");
            });
            AddSpace();
            m_Tools.BiaoTi_B("服务器端");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("可以把 服务器端 当作一台没有界面，性能好的电脑");
                m_Tools.Text_H("如果数据很大，要把数据库也放在一台性能好的电脑上");
                MyCreate.Text("一些 cmd 命令：");
                m_Tools.TextText_HG("ping www.baidu.com / ping 127.0.0.1", "// 检测 IP 地址是否通", 60);
                m_Tools.TextText_HG("ipconfig", "// 看自己的 IP 地址", 60);
            });

        }

        private void DrawBmob()                                  // Bmob简单数据库
        {
            m_Tools.GuangFangWenDan(BmobWeb, "网站");
            m_Tools.GuangFangWenDan(BmobJiaoCheng, "文档");
            m_Tools.BiaoTi_B("一、准备工作 ", ref isFrist, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text("   1.进入官网创建应用");
                    AddSpace();
                    m_Tools.Text("   2.点击应用 -> 设置 获得应用密钥");
                    AddSpace();
                    MyCreate.Heng(() =>
                    {
                        m_Tools.Text("   3.将Bmob-Unity.dll 放到 libs文件夹");
                        MyCreate.AddSpace(70);
                        MyCreate.SelectText("libs");
                    });
                    m_Tools.Text("   4.把BmobUniy加入到组件上(填写Id和Key)");
                });

            });
            AddSpace_3();

            MyCreate.Heng(() =>
            {
                m_Tools.BiaoTi_B("二、添加 Ctrl_UseBmobData", true);
                MyCreate.Button("导入包", () =>
                {
                    Application.OpenURL(@"F:\ZiLiao\使用其它插件的包\数据库\使用Bmob.unitypackage");
                });

            });
            AddSpace_3();

            m_Tools.BiaoTi_B("三、创建 bean 继承 1. 普通" + " BmobTable".AddYellow() + "   2.用户 " + "BmobUser".AddYellow(), true);
            MyCreate.Box(() =>
            {
                m_Tools.Text(" 自带的字段", ref isZiDai, () =>
                {
                    m_BmobType = (BmobType)m_Tools.BiaoTi_O("        [  " + m_BmobType + "  ]", m_BmobType);
                    m_Tools.Text3("objectId", "主键", "string");
                    if (m_BmobType == BmobType.BmobUser)
                    {
                        m_Tools.Text3("username", "用户名", "string");
                        m_Tools.Text3("password", "密码", "string");
                        m_Tools.Text3("phone", "手机号码", "string");
                        m_Tools.Text3("emailVerified", "是否验证了邮箱", "BmobBoolean");
                        m_Tools.Text3("email", "邮箱", "string");
                        m_Tools.Text3("sessionToken", "当前登录的配置信息", "string");
                    }
                    m_Tools.Text3("createdAT", "创建时间", "Data");
                    m_Tools.Text3("updateAt", "更新时间", "Data");
                });
                m_Tools.Text(" 添加列的类型", ref isAddType, () =>
                {
                    m_Tools.TextText_OY("      String  " + "(string)".AddLightBlue(), "");
                    m_Tools.TextText_OY("      Number  " + "(BmobInt)".AddLightBlue(), "int 整数");
                    m_Tools.TextText_OY("      Boolean  " + "(BmobBoolean)".AddLightBlue(), "bool ");
                    m_Tools.TextText_OY("      File  " + "(BmobFile)".AddLightBlue(), "路径  D:\\Game\\1.JPG");
                    m_Tools.TextText_OY("      Date  " + "(BmobDate)".AddLightBlue(), "2018-01-05 13:29:22");
                });
                m_Tools.Text(" 继承两个函数  " + "( readFields )  ".AddYellow() + "( write )".AddYellow(), ref isTwoMethod, () =>
                {
                    m_Tools.Text_G("[ 例子 ]    （ score、name 为数据库列名）");
                    m_Tools.Text_Y("readFields  -> 添加的字段需要补上：");
                    m_Tools.Text_O("       Score = input.getInt(\"score\");");
                    m_Tools.Text_O("       PlayerName = input.getString(\"name\")");
                    MyCreate.FenGeXian();
                    m_Tools.Text_Y("write  -> 添加的字段需要补上：");
                    m_Tools.Text_O("       output.Put(\"score\", Score);");
                    m_Tools.Text_O("       output.Put(\"name\", PlayerName);");
                });
                m_Tools.Text(" 关于BmobUser说明", ref isDes, () =>
                {
                    m_Tools.Text_G("1. username、password 必需 ，email 可选");
                    m_Tools.Text_G("2. email 可用于密码找回");
                    m_Tools.Text_G("3. email 可作为 username");
                    m_Tools.Text_G("4. 如需要在注册时发送一封验证邮件，以确真实性");
                    m_Tools.Text_G("       可在应用设置-->邮件设置，把“邮箱验证”功能打开");


                });
            });
            AddSpace_3();

            m_Tools.BiaoTi_B("四、Ctrl_UseBmobData的增删改查");
            MyCreate.Box(() =>
            {
                m_DoTestEnum = (DoTestEnum)m_Tools.BiaoTi_O("[  " + m_DoTestEnum + "  ]", m_DoTestEnum);
                switch (m_DoTestEnum)
                {
                    case DoTestEnum.增删改:
                        MyCreate.Box(() =>
                        {
                            m_Tools.TextText(" 增加", "Add");
                            m_Tools.TextText(" 删除", "Delete");
                            m_Tools.TextText(" 修改", "UpdateData");
                        });

                        break;
                    case DoTestEnum.用户:
                        MyCreate.Box(() =>
                        {
                            m_Tools.TextText(" 用户注册", "User_Registered");
                            m_Tools.TextText(" 用户登录", "User_Login");
                            m_Tools.TextText(" 更新用户信息", "User_Update");
                            m_Tools.TextText(" 重置用户密码", "User_ResetPassword");
                        });

                        break;
                    case DoTestEnum.查:
                        m_Tools.Text_O("Find_XXX");
                        m_Tools.Text("按约束条件来查询 —" + " Find_ByWhere".AddYellow() + " (BmobQuery的用法)", ref isShowByWhere, null);
                        if (isShowByWhere)
                        {
                            MyCreate.Box(() =>
                            {
                                m_Tools.BiaoTi_O("比较查询");
                                DesByWhere(1, " WhereEqualTo(\"Name\", \"Barbie\")", "名字等于Barbie的");
                                DesByWhere(2, " WhereNotEqualTo(\"Name\", \"Barbie\")", "名字不等于Barbie的");
                                DesByWhere(3, " WhereGreaterThan(\"score\", 60);", "分数 > 60分");
                                DesByWhere(4, " WhereLessThan(\"score\", 60);", "分数 < 60分");
                                DesByWhere_Long(5, " WhereContainedIn(\"Name\", {\"Barbie\", \"Joe\", \"Julia\"})", "查询“Barbie”,“Joe”,“Julia”三个人的成绩");

                                m_Tools.BiaoTi_O(" 分页查询");
                                DesByWhere(1, " Limit(20)", "最多返回20条记录");
                                DesByWhere(2, " Skip(20)", "忽略前20条数据");

                                m_Tools.BiaoTi_O("结果排序");
                                DesByWhere(1, " OrderBy(\"score\")", "对分数进行升序排序");
                                DesByWhere(2, " OrderByDescending(\"score\")", "对分数进行降序排序");
                                DesByWhere_Long(3, "OrderBy(\"score\").ThenBy(\"score2\")", "两个或者以上的字段进行升序排序");
                                DesByWhere_Long(3, "OrderByDescending(\"score\").ThenByDescending(\"score2\")", "两个或者以上的字段进行降序排序");

                                m_Tools.BiaoTi_O("或查询");
                                m_Tools.Text_W("上面都是and作为连接条件查询的，使用 " + "Or".AddBlue() + "或查询");
                            });

                        }
                        break;
                }
            });
            AddSpace_3();
            m_Tools.BiaoTi_B("五、数据关联", true);
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("传统数据库中的主外键关系一样，如：");
                m_Tools.Text_Y("       一条微博由一个用户发布，可以有多个用户评论，");
                m_Tools.Text_Y("       每条评论信息对应一个用户 (详细看官方文档)");
            });

        }


        private void DrawBmob2()                                  // Bmob 2
        {



        }


        private void DrawMySQL()                                 // MySQL
        {
            m_Tools.BiaoTi_B("官方文档位置", ref isGuan, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.GuangFangWenDan("https://dev.mysql.com/doc/refman/5.7/en/data-types.html", "数据类型 INT/VARCHAR/等等的说明使用");
                });
            });

            m_Tools.BiaoTi_B("MySQL Workbench 打开与汉化", ref isWorkbench, () =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.Heng(() =>
                    {
                        m_Tools.TextButton_Open("打开 MySQL Workbench 应用 " + "（MySQL 的GUI界面）".AddGreen(), () =>
                        {
                            Application.OpenURL(@"C:\Program Files\MySQL\MySQL Workbench 6.3 CE\MySQLWorkbench.exe");
                        });
                    });

                    m_Tools.TextButton_Open("开启 MySQL57 服务 " + "（ 不开启连接不上数据库 ）".AddGreen(), () =>
                    {
                        Application.OpenURL(@"C:\Windows\System32\services.msc");
                    });

                    m_Tools.TextButton_Open("汉化 MySQL Workbench " + "（修改 xml -> caption -> 后面）".AddGreen(), () =>
                    {
                        Application.OpenURL(@"C:\Program Files\MySQL\MySQL Workbench 6.3 CE\data\main_menu.xml");
                    });

                });
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712092001087-1691143075.png");

            });
            AddSpace();
            m_Tools.BiaoTi_B("MySQL Workbench 的使用", true);
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("右侧 Navigator 导航界面 ", ref isUse, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712092024287-1212678873.png");
                });
                AddSpace_3();
                m_Tools.Text_B("创建 Schemas （一个游戏对应一个 Schemas）", ref isCreate, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712092032532-1282195187.png");
                });
                AddSpace_3();
                m_Tools.Text_B("创建 表", ref isBiao, () =>
                {
                    m_Tools.Text_L("对着 Tables 右键 Create Tables");
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712092041180-167281.png");

                });
                AddSpace_3();
                m_Tools.Text_B("数据类型", ref isShuJu, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_OY("INT(length)", "int（不加 为最大长度）  整数", -50);
                        m_Tools.TextText_OY("FLOAT", "float   小数", -50);
                        m_Tools.TextText_OY("VARCHAR(length)", "string（length） 字符串(长度)", -50);
                        m_Tools.TextText_OY("DATETIME", "date   日期时间", -50);

                    });
                });
                AddSpace_3();
                m_Tools.Text_B("设置外键关联", ref isGuanLi, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712092054824-314358142.png");
                });
                AddSpace_3();

            });



        }

        private void DrawSqlYuJu()                               // Sql语句
        {
            m_Tools.BiaoTi_O("Structured Query Language (SQL 语句)");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("对于数据库的基本操作：增删改查");
                m_Tools.Text_L("1，每个命令后      2，不区分大小写");
            });
            m_Tools.BiaoTi_B("增");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("create table 表名", "// 创建表", 40);
                m_Tools.Text_H("{");
                m_Tools.TextText_HG("     列名1 类型 auto_increment,", "// 类型如：INT、varchar(30)", 15);
                m_Tools.Text_H("     列名2 类型 not null,");
                m_Tools.TextText_HG("     primary key(列名1)", "// 用列名1作为主键", 15);
                m_Tools.Text_H("};");
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("insert into tablename(列1,列2) values(值1,值2);", "// 插入表");

            });
            m_Tools.BiaoTi_B("删");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("delete from 表名 where 条件;", "// 不加条件就全部删除咯");
            });
            m_Tools.BiaoTi_B("改");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("update 表名", "// 更新数据", 40);
                m_Tools.Text_H("set 列名1 = 值1,列名2 = 值2");
                m_Tools.TextText_HG("where id =1;", "// 那条修改，写对应条件");
            });

            m_Tools.BiaoTi_B("查");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("select * from 表名 limit 4;", "// 查询前4行的数据", 20);
                m_Tools.TextText_HG("select * from 表名 limit 2，3;", "// 2是偏移，3是大小", 20);

                m_Tools.Text_L("select column_list ");
                m_Tools.Text_L("    from 表名 ");
                m_Tools.Text_L("    where 条件 ");
                m_Tools.TextText_LG("    order by 列名", "// 按 列名 排序", 20);
                m_Tools.Text_L("    limit 数量;");

            });
            m_Tools.BiaoTi_B("where条件");
            MyCreate.Box(() =>
            {
                MyCreate.Text("判断操作");
                m_Tools.TextText_LG("1, 数字 >、< 、= 、>= 、<= 、<>", "// <> 不等于", 20);
                m_Tools.Text_L("2, 字符串 = ''、 > 、 < 、 >= 、 <= 、 <> 、!=");
                MyCreate.Text("逻辑操作");
                m_Tools.Text_L("and 、 or 、 not 、 is null 、 is not null ");
                MyCreate.Text("范围判断");
                m_Tools.Text_L("between  范围， 例子：");
                m_Tools.Text_H("select * from 表名 where 列名 between 1 and 9;");
                m_Tools.Text_L("like   模糊搜索");
            });

        }

        #endregion


        #region Unity Web


        private void DrawUnityWeb()                              // Unity 网络
        {
            m_Tools.BiaoTi_B("通过 NetworkReachability " + "判断网络情况".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("Application.internetReachability ".AddWhite() + " -> 获得网络情况：");
                m_Tools.TextText_BL("NotReachable", "没有网络", 60);
                m_Tools.TextText_BL("ReachableViaLocalAreaNetwork", "有wifi", 60);
                m_Tools.TextText_BL("ReachableViaCarrierDataNetwork", "有移动网络", 60);
            });
            AddSpace();
            m_Tools.BiaoTi_B("UnityWebRequest(已封装)  使用 " + "using ".AddGreen() + " 与流操作相同");
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.html");
                m_Tools.Text_Y("1.", "UnityWebRequest".AddHui(), " 要使用 ", "using".AddGreen(), "，非 www 那样直接连接");
                m_Tools.Text_Y("2.", "连接调用", " SendWebRequest".AddGreen(), " 方法，放在 ", "yield return ".AddHui(), "上");
                m_Tools.Text_Y("3.获得实体内容调用 ", "DownloadHandlerXXX".AddGreen());
                MyCreate.StaticMethodWindow(() =>
                {
                    m_Tools.Method_BY("Get", "string url", "HTTP GET", "UnityWebRequest");
                    m_Tools.Method_BY("Post", "string url,string 表单主体数据", "HTTP POST", "UnityWebRequest", ref isPost, () =>
                    {
                        m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.Post.html");
                    });
                    m_Tools.Method_BY("Put", "string url,byte[]  data", "上传", "UnityWebRequest");
                    m_Tools.Method_BY("GetAssetBundle", "string url，0", "获得AB", "UnityWebRequest");
                });

                MyCreate.MethodWindow(() =>
                {
                    m_Tools.Method_BY("SendWebRequest", "", "与服务器通信", "UnityWebRequestAsyncOperation", -50);
                    m_Tools.Method_BY("SetRequestHeader", "string name,string value", "自定义请求头");
                });

                MyCreate.PropertiesWindow(() =>
                {
                    MyCreate.Text("可设置");
                    m_Tools.Method_BY("timeout", "", "几秒后尝试中止，默认0不应用超时", "int", -50);
                    MyCreate.Text("返回错误");
                    m_Tools.Method_BY("error", "只读", "系统错误" + "（如404不为系统错误）".AddLightGreen(), "string", -50);
                    m_Tools.Method_BY("isHttpError", "只读", ">= 400 Http响应代码返回 ture", "bool", -50);
                    m_Tools.Method_BY("isNetworkError", "只读", "无法解析DNS条目,套接字错误等返回ture", "bool", -50);
                    MyCreate.Text("返回信息");
                    m_Tools.Text_Y("进度", "downloadProgress".AddHui(), "、是否完成", "isDone".AddHui(), "上传进度", "uploadProgress".AddHui());
                    m_Tools.Text_Y("服务器返回的数字HTTP响应代码", "responseCode".AddHui(), "，如200或404");
                });
                m_Tools.ButtonText("DownloadHandlerXXX", "给 UnityWebRequest 获得实体内容", ref isDownload, () =>
                {
                    m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Networking.DownloadHandler.html");
                    m_Tools.BiaoTi_O("DownloadHandler 下面类的" + "父类".AddYellow(), ref isDownloadHandler, () =>
                    {
                        MyCreate.PropertiesWindow(() =>
                        {
                            m_Tools.Method_BY("data", "只读", "", "byte[]");
                            m_Tools.Method_BY("isDone", "只读", "true 所有数据已被接收", "bool");
                            m_Tools.Method_BY("text", "只读", "UTF8字符串的数据中的字节", "string");
                        });
                        MyCreate.MethodWindow(() =>
                        {
                            m_Tools.Method_BY("Dispose", "", "");

                        });

                    });
                    m_Tools.BiaoTi_O("DownloadHandlerTexture " + "下载图像进行了优化".AddYellow(), ref isTex, () =>
                    {
                        MyCreate.StaticMethodWindow(() =>
                        {
                            m_Tools.Method_BY("GetContent", "Networking.UnityWebRequest", "", "Texture2D");
                        });
                    });
                    m_Tools.BiaoTi_O("DownloadHandlerMovieTexture " + "MovieTexture".AddYellow(), ref isMovieTexture, () =>
                    {
                        MyCreate.StaticMethodWindow(() =>
                        {
                            m_Tools.Method_BY("GetContent", "Networking.UnityWebRequest", "", "MovieTexture");
                        });
                    });
                    m_Tools.BiaoTi_O("DownloadHandlerAssetBundle " + "专门用于下载AssetBundle".AddYellow(), ref isAB, () =>
                    {
                        MyCreate.StaticMethodWindow(() =>
                        {
                            m_Tools.Method_BY("GetContent", "Networking.UnityWebRequest", "", "AssetBundle");
                        });
                    });
                    m_Tools.BiaoTi_O("DownloadHandlerAudioClip " + "音频数据".AddYellow(), ref isClip, () =>
                    {
                        MyCreate.StaticMethodWindow(() =>
                        {
                            m_Tools.Method_BY("GetContent", "Networking.UnityWebRequest", "", "AudioClip");
                        });
                    });


                    m_Tools.BiaoTi_O("DownloadHandlerFile " + "数据保存到文件".AddYellow(), ref isFile, () =>
                    {
                        MyCreate.PropertiesWindow(() =>
                        {
                            m_Tools.Method_BY("removeFileOnAbort", "", "当下载中断是否删除创建文件", "bool", -30);
                        });
                    });
                });
            });

        }

        private void DrawWWW()                                   // WWW（快过时）
        {
            m_Tools.BiaoTi_B("WWW（快过时）"+ "基于" + " HTTP 协议".AddGreen() + "的网络传输、资源加载");
            m_Tools.TextButton_Open("关于 Http 协议 说明".PadLeft(25), () =>
            {
                SetTheSame(EType.ZhiShi1);
            });
            m_Tools.TextText_HG("WWW www =new WWW(url)", "// 创建并发送 GET 请求到 url");
            m_Tools.TextText_HG("WWW www =new WWW(url，WWWForm)", "// 使用 WWWForm 提交表单");
            m_Tools.Text_G("WWWForm wwwFrom =new WWWForm()");
            m_Tools.Text_G("wwwFrom.AddField( key ,value)");

        }

        private void DrawDuoRen()                                // 多人局域网
        {
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("优点：简单易用" + " (适合个人开发、少人在线游戏)".AddGreen());
                m_Tools.Text_R("缺点：连接数量有限".AddRed());
            });

            m_Tools.BiaoTi_B("Network 组件说明");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_YB("NetworkManager", "网络管理者");
                m_Tools.TextText_YB("NetworkManagerHUD", "系统提供的简单 GUI 例子");
                m_Tools.TextText_YB("NetworkIdentity", "网络识别对象(是本地的还是网络生成的)");

                MyCreate.Box(() =>
                {
                    m_Tools.Text_L("比如 Player 预制体添加上该组件，用来识别是自己角色还是别人的角色");
                });
                m_Tools.TextText_YB("NetworkTransform", "网络同步位置");


            });




/*
            AddSpace();

            m_Tools.ButtonText_H("NetWorkView(5.3后过时了)", "多人游戏的网络通讯" + "组件".AddGreen(), ref isNetWorkView, () =>

            }, () =>
            {
            });
            AddSpace();*/

/*            m_Tools.Text_B("多人游戏的基本结构 Client/Server");
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_L("客户端发送信息，服务器反馈结果");
                MyCreate.Text("优点".AddGreen());
                m_Tools.Text_G("有效防止客户端作弊，统一不同客户端之间的物理表现和互动状况");
                MyCreate.Text("缺点".AddRed());
                m_Tools.Text_R("存在网络延时时，发出一个命令要过一段时间才能接收到反馈");
                AddSpace_3();
                m_Tools.BiaoTi_L("客户端自己处理用户输入和对象逻辑，最后把结果发给服务器");
                MyCreate.Text("优点".AddGreen());
                m_Tools.Text_G("服务端要处理的数据量相对比较小，缓解服务器压力");
                MyCreate.Text("缺点".AddRed());
                m_Tools.Text_R("安全性相对较低");
            });*/
        }

        #endregion


        #region Socket


        private void DrawOther()                                 // 其他类
        {
            m_Tools.BiaoTi_B("IPAddress " + "(IP地址)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("IPAddress.Any ", " 指示服务器必须侦听的所有客户端的 IP 地址 ->".AddLightBlue(), "  IPAddress".AddWhite());
                m_Tools.Text_B("IPAddress.Parse(”127.0.0.1“)", "  将字符串转成 ->".AddLightBlue(), "IPAddress".AddWhite());

            });
            AddSpace();
            m_Tools.BiaoTi_B("IPEndPoint " + "( IP 地址 + 端口号)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("构造函数".AddBlue(), " -> new IPEndPoint（IPAddress，int） -> 就是 IP + 端口号");
                MyCreate.Text("属性：");
                m_Tools.Method_LW("AddressFamily", "", "获取寻址方案", "AddressFamily(枚举)");
            });
            AddSpace();
            m_Tools.BiaoTi_Y("IAsyncResult" + " (异步操作结果)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("属性：");
                m_Tools.Method_YG("AsyncState", "只读", "此属性返回启动异步操作的方法的最后一个参数的对象", "object", -10);
                m_Tools.Method_YH("AsyncWaitHandle", "只读", "获取用于等待异步操作完成的 WaitHandle", "WaitHandle", 25);
                m_Tools.Method_YH("CompletedSynchronously", "只读", "是否同步完成", "bool", 25);
                m_Tools.Method_YH("IsCompleted", "只读", "是否已完成", "bool", 25);
            });
            AddSpace();
            m_Tools.BiaoTi_Y("SocketAsyncEventArgs " + "（异步 Socket 操作、new 出来）".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("事件：");
                m_Tools.TextText_BL("Completed +=", "用于完成异步操作的事件");
                MyCreate.Text("属性：");
                m_Tools.Method_BL("AcceptSocket", "", "获得接收到的客户端 Socket", "Socket");



            });

        }

        private void DrawEnum()                                  // 枚举
        {
            m_Tools.BiaoTi_B("AddressFamily " + "(指定寻址方案)".AddGreen(), ref isAddressFamily, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_WY("InterNetworkV6", "IPV6 地址", -30);
                    MyCreate.Text("下面完全不知道是什么鬼。。。");
                    m_Tools.TextText_WY("AppleTalk", "AppleTalk 地址", -30);
                    m_Tools.TextText_WY("Atm", "本机 ATM 服务地址", -30);
                    m_Tools.TextText_WY("Banyan", "Banyan 地址", -30);
                    m_Tools.TextText_WY("Ccitt", "对于 CCITT 协议，如 X.25 地址", -30);
                    m_Tools.TextText_WY("Chaos", "MIT 混乱不堪的局面协议的地址", -30);
                    m_Tools.TextText_WY("Cluster", "针对 Microsoft 群集产品的地址", -30);
                    m_Tools.TextText_WY("DataKit", "Datakit 协议的地址", -30);
                    m_Tools.TextText_WY("DataLink", "Datakit 协议的地址", -30);
                    m_Tools.TextText_WY("DecNet", "DECnet 地址", -30);
                    m_Tools.TextText_WY("Ecma", "欧洲计算机制造商协会 (ECMA) 地址", -30);
                    m_Tools.TextText_WY("FireFox", "FireFox 地址", -30);
                    m_Tools.TextText_WY("HyperChannel", "NSC Hyperchannel 地址", -30);
                    m_Tools.TextText_WY("Ieee12844", "IEEE 1284.4 工作组地址", -30);
                    m_Tools.TextText_WY("ImpLink", "当初 ARPANET 导入地址", -30);
                    m_Tools.TextText_WY("Ipx", "IPX 或 SPX 地址", -30);
                    m_Tools.TextText_WY("Irda", "IrDA 地址", -30);
                    m_Tools.TextText_WY("Iso", "对 ISO 协议的地址", -30);
                    m_Tools.TextText_WY("Lat", "LAT 地址", -30);
                    m_Tools.TextText_WY("Max", "最大地址", -30);
                    m_Tools.TextText_WY("NetBios", "NetBios 地址", -30);
                    m_Tools.TextText_WY("NetworkDesigners", "网络设计器 OSI 网关启用的协议的地址", -30);
                    m_Tools.TextText_WY("NS", "Xerox NS 协议的地址", -30);
                    m_Tools.TextText_WY("Osi", "OSI 协议的地址", -30);
                    m_Tools.TextText_WY("Pup", "PUP 协议的地址", -30);
                    m_Tools.TextText_WY("Sna", "IBM SNA 地址", -30);
                    m_Tools.TextText_WY("Unix", "Unix 本地主机地址", -30);
                    m_Tools.TextText_WY("Unknown", "未知的地址族", -30);
                    m_Tools.TextText_WY("Unspecified", "未指定的地址族", -30);
                    m_Tools.TextText_WY("VoiceView", "VoiceView 地址", -30);
                });
            });
            MyCreate.Box(() =>
            {
                MyCreate.Text("唯一常用的枚举属性".AddHui());
                m_Tools.TextText_WY("InterNetwork", "IPV4 地址，不包含 V6", -30);
                MyCreate.Text("new IPEndPoint(IPAddress.Any, 端口号).AddressFamily -> ".AddHui());
                m_Tools.TextText_WY("同样返回枚举属性", "代表强制指定某个网卡上的IP绑定", -30);
            });

            AddSpace_15();
            m_Tools.BiaoTi_B("SocketType " + "(指定套接字类型)".AddGreen(), ref isSocketType, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BL("Raw", "支持访问基础传输协议", -30);
                    m_Tools.TextText_BL("Rdm", "支持无连接、 面向消息的、 可靠地发送的消息", -30);
                    m_Tools.TextText_BL("Seqpacket", "面向连接的和可靠的双向传输", -30);
                    m_Tools.TextText_BL("Unknown", "指定未知 Socket 类型", -30);

                });
            });
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Stream", "支持可靠、双向、基于连接的字节流", -30);
                m_Tools.TextText_BL("Dgram", "支持数据报，（即无连接的、不可靠的消息）", -30);

            });

            AddSpace_15();

            m_Tools.BiaoTi_B("ProtocolType " + "(指定 Socket 类支持的协议)".AddGreen(), ref isProtocolType, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BL("Ggp", "网关到网关协议", -30);
                    m_Tools.TextText_BL("Icmp", "Internet 控制消息协议", -30);
                    m_Tools.TextText_BL("IcmpV6", "IPv6 的 Internet 控制消息协议", -30);
                    m_Tools.TextText_BL("Idp", "Internet 数据报协议", -30);
                    m_Tools.TextText_BL("Igmp", "Internet 组管理协议", -30);
                    m_Tools.TextText_BL("IP", "Internet 协议", -30);
                    m_Tools.TextText_BL("IPSecAuthenticationHeader", "IPv6 身份验证标头。 有关详细信息，请参阅 ", -30);
                    m_Tools.TextText_BL("IPSecEncapsulatingSecurityPayload", "IPv6 封装安全负载标头", -30);
                    m_Tools.TextText_BL("IPv4", "Internet 协议版本 4", -30);
                    m_Tools.TextText_BL("IPv6", "Internet 协议版本 6 (IPv6)", -30);
                    m_Tools.TextText_BL("IPv6DestinationOptions", "IPv6 目标选项标头", -30);
                    m_Tools.TextText_BL("IPv6FragmentHeader", "IPv6 片段标头", -30);
                    m_Tools.TextText_BL("IPv6HopByHopOptions", "IPv6 逐跳选项标头", -30);
                    m_Tools.TextText_BL("IPv6NoNextHeader", "IPv6 无下一个标头", -30);
                    m_Tools.TextText_BL("IPv6RoutingHeader", "IPv6 路由标头", -30);
                    m_Tools.TextText_BL("Ipx", "Internet 数据包交换协议", -30);
                    m_Tools.TextText_BL("ND", "网络磁盘协议（非正式）", -30);
                    m_Tools.TextText_BL("Pup", "PARC 通用数据包协议", -30);
                    m_Tools.TextText_BL("Raw", "原始 IP 数据包协议", -30);
                    m_Tools.TextText_BL("Spx", "顺序包交换协议", -30);
                    m_Tools.TextText_BL("SpxII", "顺序包交换版本 2 协议", -30);
                    m_Tools.TextText_BL("Unknown", "未知的协议", -30);
                    m_Tools.TextText_BL("Unspecified", "未指定的协议", -30);

                });

            });
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WY("Tcp", "传输控制协议", -30);
                m_Tools.TextText_WY("Udp", "用户数据报协议", -30);
            });
            AddSpace();
            m_Tools.BiaoTi_B("SocketError " + "Socket 错误码".AddGreen(), ref isSocketError, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BL("AccessDenied", "尝试访问 Socket 禁止使用其访问权限的方式", -30);
                    m_Tools.TextText_BL("AddressAlreadyInUse", "通常情况下允许只能有一个使用的地址", -30);
                    m_Tools.TextText_BL("AddressFamilyNotSupported", "不支持指定的地址族", -30);
                    m_Tools.TextText_BL("AddressNotAvailable", "所选的 IP 地址在此上下文中无效", -30);
                    m_Tools.TextText_BL("AlreadyInProgress", "非阻塞 Socket 已有一个操作正在进行中", -30);
                    m_Tools.TextText_BL("ConnectionAborted", "连接已中止.NET Framework 或基础套接字提供程序", -30);
                    m_Tools.TextText_BL("ConnectionRefused", "远程主机正在主动拒绝连接", -30);
                    m_Tools.TextText_BL("ConnectionReset", "连接被远程对等方重置", -30);
                    m_Tools.TextText_BL("DestinationAddressRequired", "在上一个操作中被省略了必需的地址 Socket", -30);
                    m_Tools.TextText_BL("Disconnecting", "正常关闭正在进行中", -30);
                    m_Tools.TextText_BL("Fault", "检测到无效的指针地址的基础套接字提供程序", -30);
                    m_Tools.TextText_BL("HostDown", "操作失败，因为远程主机已关闭", -30);
                    m_Tools.TextText_BL("HostNotFound", "此主机不是已知的。 名称不是正式的主机名或别名", -30);
                    m_Tools.TextText_BL("HostUnreachable", "没有到指定的主机的网络路由", -30);
                    m_Tools.TextText_BL("InProgress", "阻止操作正在进行", -30);
                    m_Tools.TextText_BL("Interrupted", "阻塞 Socket 调用已被取消", -30);
                    m_Tools.TextText_BL("IOPending", "应用程序已开始将重叠的操作不能立即完成的", -30);
                    m_Tools.TextText_BL("......", ".......", -30);
                });

            });
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Shutdown", "若要发送或接收数据的请求被禁止，因为 Socket 已关闭", -30);
                m_Tools.TextText_BL("NetworkDown", "网络不可用", -30);
                m_Tools.TextText_BL("TimedOut", "连接尝试超时或被连接的主机未能响应", -30);
            });

            AddSpace();
            m_Tools.BiaoTi_B("SocketFlags " + "Socket 标记".AddGreen(), ref isSocketFlags, () =>
            {
                m_Tools.TextText_WY("Broadcast", "指示广播数据包", -30);
                m_Tools.TextText_WY("ControlDataTruncated", "指示控制数据无法放入64KB的内部缓冲区且已被截断", -30);
                m_Tools.TextText_WY("DontRoute", "不使用路由表进行发送", -30);
                m_Tools.TextText_WY("MaxIOVectorLength", "提供用于发送和接收数据的 WSABUF 结构数的标准值", -30);
                m_Tools.TextText_WY("Multicast", "指示多播数据包", -30);
                m_Tools.TextText_WY("OutOfBand", "处理带外数据", -30);
                m_Tools.TextText_WY("Partial", "部分发送或接收消息", -30);
                m_Tools.TextText_WY("Peek", "快速查看传入消息", -30);
                m_Tools.TextText_WY("Truncated", "消息太大，无法放入指定的缓冲区，并且已被截断", -30);

            });
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WY("None", "不对此调用使用任何标志", -30);

            });


        }

        private void DrawLiZI()                                  // TCP简单例子
        {
            m_Tools.BiaoTi_B("Server 服务端");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)");
                m_Tools.Text_G("// 1. 创建 IPV4 地址、字节流式、Tcp协议 的 Socket 作为服务端 -> ", serverSocketStr);
                m_Tools.Text_H(serverSocketStr, ".Bind(new IPEndPoint(IPAddress.Any, 端口号))");
                m_Tools.Text_G("// 2. 接收任何 Ip 地址 + 端口号  -> 绑定上");
                m_Tools.TextText_HG(serverSocketStr + ".Listen(10)", "// 3. 处于监听状态（最大等待数量）");
                m_Tools.TextText_HG(StartAcceptStr + "();", "// 4. 等待客户端接收进来");

                AddSpace_3();
            });
            MyCreate.Text(StartAcceptStr + " 方法：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H(serverSocketStr, ".BeginAccept(", E_ClinetConnectionStr, ", null);");
            });
            MyCreate.Text(E_ClinetConnectionStr + " 方法：" + "(当有新的客户端连接过来要做什么)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("Socket clientSocket = ", serverSocketStr, ".EndAccept(result);");
                m_Tools.Text_H("....// 用这个 clientSocket 负责与服务器通信");
                m_Tools.TextText_HG(StartAcceptStr + "();", "// 5. 再开始等待下一个客户端接收进来");
            });
            AddSpace_15();
            m_Tools.BiaoTi_O("Client 客户端");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)");
                m_Tools.Text_G("// 一. 创建的参数与上面一致 -> ", clientSocketStr);
                m_Tools.Text_H("IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(“127.0.0.1”), 端口号)");
                m_Tools.Text_G("// 二. 创建 IP 地址 + 端口号 -> IPEndPoint类");

            });

        }


        private void DrawAPI()                                   // Socket API
        {
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket(v=vs.110).aspx");
            m_Tools.BiaoTi_Y("构造函数", true);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("new Socket（AddressFamily，SocketType，ProtocolType）", "// 三个枚举".AddGreen());
            });
            AddSpace_3();

            m_Tools.BiaoTi_Y("开启与关闭的" + MethodStr, true);
            MyCreate.Box(() =>
            {
                m_Tools.Method_BW("Bind", "EndPoint", "将 IP + 端口号 绑定到 Socket 上");
                m_Tools.Method_BW("Listen", "int 最大的等待数量", "让 Socket 处于侦听状态" + "（等待数量，不是最大数量）".AddGreen(), "", ref isListen, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_L("Listen(10): ".AddOrange(), "100个要连接进来，100个都会连接进来，分批最多等待10个");
                        m_Tools.Text_L("Listen(0):  ".AddOrange(), "0为无限制。即无需等待，一次过100个连接进来，有性能问题");
                    });
                });
                m_Tools.Method_BW("Close", "", "关闭 Socket 连接和释放所有关联资源");
            });
            AddSpace_3();
            m_Tools.BiaoTi_Y("总结关系链" + "(同步会阻塞，异步要用 End 结束,但过程一样)".AddGreen(), true);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("等待接收".AddLightBlue(), "客户端连接  ->  来了  ->  产生通信用的 ", "Socket".AddWhite());
                m_Tools.Text_H("发送数据".AddLightBlue(), "  ->  返回总共发送过去的字节数", "(int)".AddWhite());
                m_Tools.Text_H("接收数据".AddLightBlue(), "  ->  返回总共接收到的字节数", "(int)".AddWhite());
                MyCreate.Text("1. 同步会阻塞，可以通过属性" + "设置阻塞超时值".AddGreen() + "（如 ReceiveTimeout）");
                MyCreate.Text("2." + " Begin异步".AddYellow() + "(最后两个参数：" + "AsyncCallback，Object".AddGreen() + ") -> 当完成操作 -> 回调");
                MyCreate.Text("    AsyncCallback".AddGreen() + "：delegate(IAsyncResult) -> " + "End异步".AddYellow() + " -> 获得Socket/字节数");
                MyCreate.Text("    -> 通过 IAsyncResult.AsyncState 获得最后一个参数 -> " + "Objet".AddGreen());
            });
            AddSpace_3();
            m_Tools.BiaoTi_Y("Begin/End 异步操作" + MethodStr, true);
            MyCreate.Box(() =>
            {
                MyCreate.Text("等待客户端连接 -> 接收 -> End接收，只会执行一次（要用 While）");
                m_Tools.Method_BL("BeginAccept", "AsyncCallback，Object", "接收客户端连接", "IAsyncResult", ref isBeginAccept,
                    () =>
                    {
                        m_Tools.Method_BL(ZhongZai + "BeginAccept", "int 要接受来自该发件人的字节数，AsyncCallback，object", "");
                        m_Tools.Method_BL(ZhongZai + "BeginAccept", "Socket 接受 Socket 对象（可能为 null），int，AsyncCallback，object", "");
                    }, 40);
                m_Tools.Method_BL("EndAccept", "IAsyncResult", "连接结束，创建一个Socket处理通信", "Socket", ref isEndAccept, () =>
                {
                    m_Tools.Method_BL(ZhongZai + "EndAccept", "out Byte[] 初始数据，IAsyncResult", "", "Socket");
                    m_Tools.Method_BL(ZhongZai + "EndAccept", "out Byte[]，out int 字节数 ,IAsyncResult", "", "Socket");
                }, 40);


                m_Tools.Method_BL("BeginConnect", "EndPoint，AsyncCallback，Object", "发起连接请求", "IAsyncResult", ref isBeginConnect,
                    () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_G("EndPoint -> 有子类：IPEndPoint、DnsEndPoint");
                        });
                        m_Tools.Method_BL(ZhongZai + "BeginConnect", "IPAddress ip地址，int 端口号，AsyncCallback，object", "");
                        m_Tools.Method_BL(ZhongZai + "BeginConnect", "string，int，AsyncCallback，object", "");
                    }, 120);
                m_Tools.Method_BL("EndConnect", "IAsyncResult", "发起连接请求结束", "", ref isEndConnect, () =>
                {
                    m_Tools.Method_BL(ZhongZai + "BeginConnect", "out Byte[] 初始数据，IAsyncResult", "", "Socket");
                    m_Tools.Method_BL(ZhongZai + "BeginConnect", "out Byte[]，out int 字节数 ,IAsyncResult", "", "Socket");
                }, 120);


                AddSpace();
                MyCreate.Text("发送数据 与 接收数据：（除了 AsyncCallBack，Object，还带以下参数）");
                MyCreate.Box(() =>
                {

                    m_Tools.Text_H("byte[]", " 数据 ".AddWhite(), "        int ", "偏移量  ".AddWhite(), "      int ", "大小".AddWhite());
                    m_Tools.Text_H("SocketFlags ", "标记(枚举)  ".AddWhite(), "           SocketError", " 错误信息(枚举)".AddWhite());
                });

                m_Tools.Method_BL("BeginSend", "byte[]，int，int，SocketFlags，AsyncCallback，Object", "", "IAsyncResult", ref isBeginSend, () =>
                {
                    m_Tools.Method_BL(ZhongZai + "BeginSend", "byte[]，int，int，SocketFlags，out SocketError，AsyncCallback，Object", "", "");
                    m_Tools.Method_BL(ZhongZai + "BeginSend", "IList<ArraySegment<Byte>>，SocketFlags，AsyncCallback，Object", "", "");
                });
                m_Tools.Method_BL("BeginReceive", "byte[]，int，int，SocketFlags，AsyncCallback，Object", "", "IAsyncResult", ref isBeginReceive, () =>
                {
                    m_Tools.Method_BL(ZhongZai + "BeginReceive", "byte[]，int，int，SocketFlags，out SocketError，AsyncCallback，Object", "", "");
                    m_Tools.Method_BL(ZhongZai + "BeginReceive", "IList<ArraySegment<Byte>>，SocketFlags，AsyncCallback，Object", "", "");
                });

                m_Tools.Method_BW("EndSend", "IAsyncResult", "结束异步发送", "int 发送过去的字节数", ref isEndReceive, () =>
                {
                    m_Tools.Method_BL(ZhongZai + "EndSend", "IAsyncResult，out SocketError", "", "int");
                }, 10);

                m_Tools.Method_BW("EndReceive", "IAsyncResult", "结束异步读取", "int 接收到的字节数", ref isEndReceive, () =>
                {
                    m_Tools.Method_BL(ZhongZai + "EndReceive", "IAsyncResult，out SocketError", "", "int");
                }, 10);
            });

            m_Tools.BiaoTi_Y("异步操作Async" + MethodStr + "(通过 SocketAsyncEventArgs类 完成所有操作)");
            MyCreate.Box(() =>
            {
                m_Tools.Method_WL("AcceptAsync", "SocketAsyncEventArgs", "");
                m_Tools.Method_WL("ConnectAsync", "SocketAsyncEventArgs", "");
                m_Tools.Method_WL("SendAsync", "SocketAsyncEventArgs", "");
                m_Tools.Method_WL("ReceiveAsync", "SocketAsyncEventArgs", "");
            });
            m_Tools.BiaoTi_Y("同步操作" + MethodStr, ref isTong, () =>
            {
                MyCreate.PropertiesWindow(() =>
                {
                    m_Tools.Method_YW("ReceiveTimeout", "", "Receive 方法" + ZhuZaiStr + "设置超时值（毫秒为单位，默认0无限制）", "int", -50);

                });
                MyCreate.MethodWindow(() =>
                {
                    m_Tools.Method_BY("Accept", "", "程序" + ZhuZaiStr + "在此,直到有客户端连接进来，产生通信用的", "Socket", -30);
                    m_Tools.Method_BY("Send", "byte[]", "同步方式发送，大文件肯定会" + ZhuZaiStr, "int 发送到的字节数", ref isSend, () =>
                    {
                        m_Tools.Method_BY(ZhongZai + "Send", "byte[]，SocketFlags 标记(枚举)", "", "int");
                        m_Tools.Method_BY(ZhongZai + "Send", "byte[]，int 要发送的字节数，SocketFlags", "", "int");
                        m_Tools.Method_BY(ZhongZai + "Send", "byte[],int 偏移量，int 大小,SocketFlags", "", "int");
                        m_Tools.Method_BY(ZhongZai + "Send", "byte[]，int，int，SocketFlags，out SocketError 错误(枚举)", "", "int");
                        m_Tools.Method_BY(ZhongZai + "Send", "IList<ArraySegment<byte>> 一组缓冲区列表", "", "int");
                    }, -30);
                    m_Tools.Method_BY("Receive", "Byte[]", "程序" + ZhuZaiStr + "在此，直到接收到数据", "int 收到的字节数", ref isReceive, () =>
                    {
                        m_Tools.Method_BY(ZhongZai + "Receive", "byte[]，SocketFlags 标记(枚举)", "", "int");
                        m_Tools.Method_BY(ZhongZai + "Receive", "byte[]，int 要接收的字节数，SocketFlags", "", "int");
                        m_Tools.Method_BY(ZhongZai + "Receive", "byte[],int 偏移量，int 大小,SocketFlags", "", "int");
                        m_Tools.Method_BY(ZhongZai + "Receive", "byte[]，int，int，SocketFlags，out SocketError 错误(枚举)", "", "int");
                        m_Tools.Method_BY(ZhongZai + "Receive", "IList<ArraySegment<byte>> 一组缓冲区列表", "", "int");
                    }, -30);
                });

            });

        }

        private void DrawKuaiZhan()                                // Socket扩展
        {
            AddSpace_15();
            MyCreate.Window("扩展 (实现传送文件)", () =>
            {
                MyCreate.Text("如何判断接收数据是文件还是文字？");
                m_Tools.Text_Y("★ 设计 ”协议“ ：");
                m_Tools.Text_W("   ▪ 把要传递的字节数组前面都加上" + " 一个字节 ".AddYellow() + "做为标识");
                m_Tools.Text_W("   ▪ 文字：" + "0".AddYellow() + " + 文字 （字节数组表示）");
                m_Tools.Text_W("   ▪ 文件：" + "1".AddYellow() + " + 文件的二进制信息");
                ;
            });
            AddSpace_15();
            MyCreate.Window("注意", () =>
            {
                m_Tools.Text_H("1. 端口号必须在 1024 和 65535 之间");
                m_Tools.Text_H("2. 客户端 一个 Socket 一次只能连接一台主机");
                m_Tools.Text_H("3. Socket 关闭后无法再次使用，需要重新 new 过");
            });
            AddSpace();
            m_Tools.BiaoTi_B("什么是粘包和分包 与 解决");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("粘包".AddBlue(), "：数据很小 + 发送频率很高，发送过去的数据会整合成一个包发过去");
                m_Tools.Text_L("分包".AddBlue(), "：数据很大，会把数据分成几个小包发过去");
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("★ 设计 ”协议“ ：");
                m_Tools.Text_W("   ▪ 把要传递的字节数组前面都加上" + ShuJuStr + "做为标识");
                m_Tools.Text_W("   ▪ 读取的数据有多长就按照" + ShuJuStr + "来读取");
                m_Tools.Text_L("比如用int,是4个字节，先读取4个字节的数据长度，再根据长度来读取数据");
                m_Tools.Text_G("使用 BitConverter 转换: ");
                m_Tools.Text_G("int 数据长度 -> byte[]  ，  前4个 byte[] ->int 数据长度");
                m_Tools.Text_O("具体实现代码：", ref isDaiMa, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("public static byte[] GetBytes(string data)");
                        m_Tools.Text_H("     byte[] ", YuanData, " = Encoding.UTF8.GetBytes(data)");
                        m_Tools.Text_H("     int dataLength = ", YuanData, ".Length");
                        m_Tools.Text_H("     byte[] ", LengthData, " = BitConverter.GetBytes(dataLength)");
                        m_Tools.Text_H("     byte[] ", LastData, " = ", LengthData, ".Concat(", YuanData, ").ToArray()");
                        m_Tools.TextText_HG("     return " + LastData, "// 4个字节的数据长度 + 原数据");
                    });
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("读取 ：TODO");
                    });

                });


            });

            AddSpace();

        }


        #endregion


        private void DrawPhoton()                                    // Photon
        {
            m_Tools.TextText_BL("Photon" + "（手机网游）".AddLightGreen(), "实时 Socket 服务器和开发框架");
            m_Tools.GuangFangWenDan("https://www.photonengine.com/zh-CN/Photon");
            m_Tools.TextUrl("我的 Photon 主页", "https://www.photonengine.com/zh-tw/dashboard");
            m_Tools.Text_W("Photon 引擎特点：", ref _isTieDian, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_L("1.架构于Windows平台下原生态性能高度优化的系统");
                    m_Tools.Text_L("2.经过证明适用于众多商业游戏");
                    m_Tools.Text_L("3.服务器端逻辑采用 C# 语言实现");
                    m_Tools.Text_L("4.采用纤程处理消息机制避免采用线程导致的问题");
                    m_Tools.Text_L("5.部署简单，支持云端服务");
                    m_Tools.Text_L("6.采用小尺寸的二进制协议，可根据需要使用有序可靠的UDP");
                    m_Tools.Text_L("7.封装了每个客户端平台的网络层的模块");


                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_L("配置 Photon");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("1. 下载安装 Photon SDK");
                m_Tools.Text_L("2. 设置 Photon 配置文件");
                m_Tools.Text_L("3. 运行 PhotonControl.exe");


            });
        }



        #region Suct

        private void DrawScut()                                      // Suct
        {
            m_Tools.GuangFangWenDan("https://github.com/ScutGame/Scut/wiki", "GitHub 带教程");

            m_Tools.BiaoTi_B("Suct 免费开源的游戏服务器引擎");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("1.适用 ".AddHui(), "AVG", "(冒险游戏) ".AddHui(), "SLGRPG", "(战略类角色扮演) ".AddHui(), "MMOG", "(大型多人在线)".AddHui());
                m_Tools.Text_H("2.同时支持", " Http、WebSocket、Socket".AddYellow(), "协议通讯");
                m_Tools.Text_H("3.游戏逻辑可使用", " C#、Python、Lua".AddYellow(), "开发");
                m_Tools.Text_H("4.可支持的数据库", " Mysql、MSSQL、MoSql".AddYellow());
                m_Tools.Text_H("5.采用 MVC 框架设计，提供了丰富类库和游戏案例");
                m_Tools.Text_H("6.", "稳定，游戏服超过1000小时无须任何维护，数据自动同步");
                m_Tools.Text_H("7.玩家不在线，在 24H 内将数据从Cache中移除，释放内存使用");
                m_Tools.Text_H("8.单服在线人数支持30000 - 50000 没问题");

            });

            m_Tools.BiaoTi_B("服务器框架层次结构图解");
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702185517497-1110112982.png", 25);

        }


        private void DrawSuctBeiZhi()                                // Suct 配置环境
        {
            m_Tools.BiaoTi_B("一、搞掂 IIS Web服务器");
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("1. 控制面板 -> 程序 -> 程序和功能 -> 打开或关闭 Windows 功能");
                m_Tools.Text_W("   把 " + "Internaet 信息服务".AddLightBlue() + "全勾选上", ref isInternaet, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702185740802-1068048154.png", 30);
                });
                AddSpace_3();
                m_Tools.Text_W("2. 开始 -> 所有程序 -> 管理工具 ->" + " IIS Manager".AddLightBlue() + " 打开");
                AddSpace_3();
                m_Tools.Text_L("3. 网站 -> 添加网站 -> 填写名称（主机名）、" + "存储路径".AddGreen(), ref isIIS02, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702190302656-625713968.png", 30);
                });
                AddSpace_3();
                MyCreate.Heng(() =>
                {
                    m_Tools.Text_L("4. 配置 host " + "例：（127.0.0.1 www.test.com）".AddLightGreen(), ref isIIS03, null);
                    MyCreate.AddSpace();
                    MyCreate.Button(" 打开 ", () =>
                    {
                        Application.OpenURL(@"C:\Windows\System32\drivers\etc\hosts");
                    });
                });
                if (isIIS03)
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702222756556-865926009.png",30);
                }
                AddSpace_3();
                m_Tools.Text_W("5. 设置" + "存储路径".AddGreen() + "的权限成 Everyone 所有人", ref isIIS04, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702222903429-529482489.png", 30);
                });
                AddSpace_3();
                m_Tools.Text_W("6. 设置" + "C:/Windows/temp".AddGreen() + "文件夹 IIS_IUSRS 权限全打勾", ref isIIS05, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702224132647-2106939631.png", 30);
                });
            });
            AddSpace();

            m_Tools.BiaoTi_B("二、将 Suct 源码的 Tools/ContractTools/release 设置成网站" + " 存储路径".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("源码网盘位置：（E盘 功能 插件源码）-> Scut7.9.8Code.zip", ref is01, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702225156290-1285116914.png", 30);
                });
                m_Tools.Text_L("最终显示 Suct 效果", ref is02, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702230202679-1124827817.png", 30);
                });
            });
            AddSpace();
            m_Tools.BiaoTi_B("三、设置并导入 MySql 数据库 (密码是 729611611)");
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("将 "+"存储路径 的 “web.config”".AddGreen()+" 密码改成 MySql 的密码",ref isMiMa, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180703081808365-1931907494.png");
                });

                m_Tools.Text_W("【运行 SQL 文件】，将 Suct 数据库导进来");

            });

            m_Tools.BiaoTi_B("四、做个小案例");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("TODO");
            });



            AddSpace();
            m_Tools.BiaoTi_B("配置 Scut 协议服务器");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("1. 安装 IIS 服务器");
                m_Tools.Text_Y("2. 安装 Mysql 和 Navicat For Mysql");
                m_Tools.Text_Y("3. 安装Scut (到官网下载)");
                m_Tools.Text_Y("4. 拷贝 Scut 的发布文件到 IIS 根目录");
                m_Tools.Text_Y("5. 修改本地域名解析");
                m_Tools.Text_Y("6. 导入 Scut 的测试数据到 Mysql");
                m_Tools.Text_Y("7. 刷新浏览器，出现 Scut 协议管理工具");
            });


        }


        #endregion
    }

}
