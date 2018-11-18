using System;
using System.Collections.Generic;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class JiLu_ShengHuo : AbstactNewKuang
    {
        [MenuItem(LearnMenu.ShengHuo)]
        static void Init()
        {
            JiLu_ShengHuo instance = GetWindow<JiLu_ShengHuo>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {

            #region 电脑程序

            bool isExe = (type == EType.Exe || type == EType.Exe1 || type == EType.Exe2 || type == EType.Exe3 || type == EType.Exe4 || type == EType.Exe5 || type == EType.Exe6 || type == EType.Exe7 || type == EType.Exe8);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "电脑程序";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isExe ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Exe1);
            }

            if (isExe)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exe1 ? "  与 Unity 相关程序".AddBlue() : "  与 Unity 相关程序");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exe1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exe2 ? "  图片 类".AddBlue() : "  图片 类");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exe2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exe3 ? "  Gif 类".AddBlue() : "  Gif 类");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exe3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exe4 ? "  视频 类".AddBlue() : "  视频 类");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exe4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exe5 ? "  程序 类".AddBlue() : "  程序 类");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exe5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exe6 ? "  使用 Bat".AddBlue() : "  使用 Bat");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exe6);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exe7 ? "  重装记录".AddBlue() : "  重装记录");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exe7);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Exe8 ? "  符号标记".AddBlue() : "  符号标记");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Exe8);
                }
            }

            #endregion

            AddSpace();

            #region 网上使用

            bool isWeb = (type == EType.Web || type == EType.Web1 || type == EType.Web2 || type == EType.Github);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "网上使用";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isWeb ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Github);
            }

            if (isWeb)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Github ? "  Github".AddBlue() : "  Github");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Github);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Web1 ? " 网上有趣的转载".AddBlue() : "  网上有趣的转载");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Web1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Web2 ? "  网站密码".AddBlue() : "  网站密码");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Web2);
                }

            }

            #endregion

            AddSpace();

            #region 游戏分类

            bool isGame = (type == EType.Game || type == EType.Game1 || type == EType.Game2 || type == EType.Game3 || type == EType.Game4 || type == EType.Game5 || type == EType.Game6);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "游戏分类";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Game ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Game);
            }
            if (isGame)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Game1 ? "  动作游戏".AddBlue() : "  动作游戏");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Game1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Game2 ? " 冒险游戏".AddBlue() : "  冒险游戏");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Game2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Game3 ? "  模拟游戏".AddBlue() : "  模拟游戏");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Game3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Game4 ? "  角色扮演游戏".AddBlue() : "  角色扮演游戏");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Game4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Game5 ? "  策略游戏".AddBlue() : "  策略游戏");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Game5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Game6 ? "  其余大类".AddBlue() : "  其余大类");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Game6);
                }
            }
            #endregion

            AddSpace();

            #region 重装

            bool isZhong = (type == EType.Zhong || type == EType.Zhong1 || type == EType.Zhong2 || type == EType.Zhong3);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "重装";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isZhong ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Zhong1);
            }

            if (isZhong)
            {

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zhong1 ? "  谷歌浏览器".AddBlue() : "  谷歌浏览器");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zhong1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zhong2 ? "  VS".AddBlue() : "  VS");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zhong2);
                }

            }

            #endregion

            AddSpace();

            #region 自控力

            bool isZi = (type == EType.Zi || type == EType.Zi1 || type == EType.Zi2 || type == EType.Zi3 || type == EType.Zi4 || type == EType.Zi5 || type == EType.Zi6);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "自控力";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Zi ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Zi);
            }

            if (isZi)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zi1 ? "  解析意志力".AddBlue() : "  解析意志力");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zi1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zi2 ? "  管理自己".AddBlue() : "  管理自己");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zi2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zi3 ? "  提升自控力极限".AddBlue() : "  提升自控力极限");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zi3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zi4 ? "  错误的自控".AddBlue() : "  错误的自控");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zi4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zi5 ? "  情绪也会影响自控力".AddBlue() : "  情绪也会影响自控力");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zi5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Zi6 ? "  思考未来".AddBlue() : "  思考未来");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Zi6);
                }

            }

            #endregion


            AddSpace();

            #region 视频分割上传

            bool isShiPing = (type == EType.ShiPing || type == EType.ShiPing1 || type == EType.ShiPing2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "杂项";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isShiPing ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.ShiPing1);
            }

            if (isShiPing)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ShiPing1 ? "  视频分割上传".AddBlue() : "  视频分割上传");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ShiPing1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ShiPing2 ? "  清理缓存".AddBlue() : "  清理缓存");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ShiPing2);
                }
            }

            #endregion



        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Exe1:      DrawRightPage1(DrawUntiyExe);      break;
                case EType.Exe2:      DrawRightPage3(DrawTu);            break;
                case EType.Exe3:      DrawRightPage4(DrawGif);           break;
                case EType.Exe4:      DrawRightPage5(DrawShiPin);        break;
                case EType.Exe5:      DrawRightPage6(DrawExe);           break;
                case EType.Exe6:      DrawRightPage7(DrawBat);           break;
                case EType.Exe7:      DrawRightPage8(DrawChongZhuang);   break;
                case EType.Exe8:      DrawRightPage8(DrawBiaoJi);        break;
                case EType.Github:    DrawRightPage1(DrawGitHub);        break;
                case EType.Web1:      DrawRightPage3(DrawInteresting);   break;
                case EType.Web2:      DrawRightPage4(DrawMiMa);          break;
                case EType.Game:      DrawRightPage1(DrawShuoXie);       break;
                case EType.Game1:     DrawRightPage3(DrawDongZuo);       break;
                case EType.Game2:     DrawRightPage4(DrawMao);           break;
                case EType.Game3:     DrawRightPage5(DrawMoNi);          break;
                case EType.Game4:     DrawRightPage6(DrawJieSe);         break;
                case EType.Game5:     DrawRightPage7(DrawCi);            break;
                case EType.Game6:     DrawRightPage8(DrawOther);         break;
                case EType.Zi:        DrawRightPage1(DrawZiKong);        break;
                case EType.Zi1:       DrawRightPage3(DrawYiZhiLi);       break;
                case EType.ShiPing1:  DrawRightPage4(DrawShiPing);       break;
                case EType.Zhong1:    DrawRightPage4(DrawGuGe);          break;
                case EType.Zhong2:    DrawRightPage5(DrawClearWeb);      break;


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
        private bool isJian;
        private bool _isAnZhuang, _isYinWen=true, _isJieShao = true, _isShow = true;


        private enum EType
        {
            Exe, Exe1, Exe2, Exe3, Exe4, Exe5, Exe6, Exe7, Exe8,
            Web, Github, Web1, Web2,
            Game,Game1, Game2, Game3, Game4, Game5, Game6,
            Zhong,Zhong1,Zhong2,Zhong3,

            Zi,Zi1,Zi2,Zi3,Zi4,Zi5,Zi6,
            ShiPing, ShiPing1, ShiPing2,

        }

        private EType type = EType.Exe1;

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
            return "生活记录";
        }


        private void BiaoTi(string str1, string str2, string str3, string str4, string str5, Action action = null)
        {
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BY(str1.AddOrange() + str2.AddHui(), str3, 50);
                if (!isJian)
                {
                    if (!string.IsNullOrEmpty(str4))
                    {
                        MyCreate.Text("特点：    ".AddGreen() + str4);
                    }
                    MyCreate.Text("代表作：".AddGreen() + str5.AddLightBlue());
                }
                if (null != action)
                {
                    action();
                }
            });
            AddSpace_3();
        }


        private void TDrawnOne(string str, Action action)             // 层次结构第一层
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

        private void TDrawTwo(string str, Action action)              // 层次结构第二层
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

        private void TDrawThree(string str, Action action)            // 层次结构第三层
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



        private static readonly KeyValuePair<string, string>[] l_EngChina =
{
            new KeyValuePair<string, string>("Pull requests", "发起请求"),
            new KeyValuePair<string, string>("Issues", "问题"),
            new KeyValuePair<string, string>("Marketplace", "市井"),
            new KeyValuePair<string, string>("Explore", "探索"),
            new KeyValuePair<string, string>("Browse", "浏览"),
            new KeyValuePair<string, string>("Discover", "发现"),
            new KeyValuePair<string, string>("repositories", "资料库"),
            new KeyValuePair<string, string>("Sources", "来源"),
            new KeyValuePair<string, string>("Forks", "叉"),
            new KeyValuePair<string, string>("profile", "轮廓"),
            new KeyValuePair<string, string>("stars", "明星"),
            new KeyValuePair<string, string>("gists", "学家、要领"),
            new KeyValuePair<string, string>("provided", "提供"),
            new KeyValuePair<string, string>("organization", "组织"),
            new KeyValuePair<string, string>("Wiki", "维基"),
            new KeyValuePair<string, string>("Insights", "洞察"),
            new KeyValuePair<string, string>("website", "网站"),
            new KeyValuePair<string, string>("topics", "主题"),
            new KeyValuePair<string, string>("commits", "提交"),
            new KeyValuePair<string, string>("branch", "分支"),
            new KeyValuePair<string, string>("releases", "发布"),
            new KeyValuePair<string, string>("contributor", "贡献者"),
            new KeyValuePair<string, string>("Filters", "过滤器"),
            new KeyValuePair<string, string>("Milestones", "里程碑"),
            new KeyValuePair<string, string>("organize", "组织"),
            new KeyValuePair<string, string>("boards", "板"),
            new KeyValuePair<string, string>("document", "文件"),
            new KeyValuePair<string, string>("webhooks", "网络挂接"),
            new KeyValuePair<string, string>("Branches", "分行"),
            new KeyValuePair<string, string>("Collaborators", "合作者"),
        };


        private void OpenFile(string des, string filePath,       // 打开文件
            bool islast = false)
        {
            m_Tools.TextButton_B(des, "    打开", () => { Application.OpenURL(filePath); }, 20);
            if (!islast)
            {
                MyCreate.AddSpace(8);
            }
        }


        private void OpenFloder(string des, string url,          // 打开文件夹
            bool islast = false)
        {
            m_Tools.TextButton_B(des + "(文件夹)".AddLightBlue(), "    打开", () => { Application.OpenURL(url); }, 20);

            if (!islast)
            {
                MyCreate.AddSpace(8);
            }
        }

        private void OpenWeb(string des, string url,             // 打开网页
            bool islast = false)
        {
            m_Tools.TextButton_B(des + "(网页)".AddLightBlue(), "    打开", () => { Application.OpenURL(url); }, 20);

            if (!islast)
            {
                MyCreate.AddSpace(8);
            }
        }
        #endregion



        #region 电脑程序

        private void DrawUntiyExe()                              // 与Unity相关程序
        {
            m_Tools.BiaoTi_O("与Unity相关程序");
            MyCreate.Box(() =>
            {
                OpenFloder("创建脚本初设置", MyComputePath.CreateScriptPath);
                OpenFloder("创建快捷键", MyComputePath.CreateQuickPath);
                OpenFloder("Unity商店下载的包", MyComputePath.UnityDownLoader);
                OpenFloder("CG类库", MyComputePath.CGIncludesPath);
                OpenFloder("Application.persistentDataPath", MyComputePath.PersistentDataPath);
                OpenFile("PSPUtil", MyComputePath.MyPSPUtilPath);
            });
        }

        private void DrawTu()                                    // 图片 类
        {
            m_Tools.BiaoTi_O("图片 类");
            MyCreate.Box(() =>
            {
                OpenFile("图片" + "放大缩小".AddYellow(), MyComputePath.FangDaTuPath);
                OpenWeb("图片" + "压缩".AddYellow(), MyComputePath.TuYaSuoPath);
                OpenFile("切图和" + "合图".AddYellow(), MyComputePath.HeTuPath);
                OpenFile("TexturePacker", MyComputePath.TexturePackerPath);
                OpenFile("去水印", MyComputePath.QuShuiYinPath);
                OpenFile("美图秀秀批量处理", MyComputePath.MeiTuPath);
                OpenFile("批量转换图片格式", MyComputePath.TuZhuangPath);
                OpenFile("图片转ICO图标", MyComputePath.AveIconPath);
                OpenFile("视频".AddYellow() + "拆分成图片/Gif", MyComputePath.ShiPinPath, true);
            });
        }

        private void DrawGif()                                   // Gif 类
        {
            m_Tools.BiaoTi_O("Gif 类");
            MyCreate.Box(() =>
            {
                OpenFile("Gif录制", MyComputePath.GifLuPath);
                OpenFile("图片合成Gif", MyComputePath.GifHeChengPath);
                OpenFile("Gif拆分成图片", MyComputePath.GifCaiPath);
                OpenWeb("一个Gif网站", MyComputePath.GifUrlPath, true);
            });
        }

        private void DrawShiPin()                                // 视频 类
        {
            m_Tools.BiaoTi_O("视频 类");
            MyCreate.Box(() =>
            {
                OpenFile("录屏幕成视频", MyComputePath.LuShiPinPath, true);
            });
        }

        private void DrawExe()                                   // 程序 类
        {
            m_Tools.BiaoTi_O("程序 类");
            MyCreate.Box(() =>
            {
                OpenFile("按键精灵", MyComputePath.AnJianJinLinPath);
                OpenFile("手机显示到屏幕", MyComputePath.AsmPath);
                OpenFile("取颜色值", MyComputePath.MycolorPath);
                OpenFile("精致取颜色/坐标值", MyComputePath.ColorPath);
                OpenFile("量尺寸", MyComputePath.SizePath);
                OpenFile("HiJson", MyComputePath.HiJsonPath, true);
            });
        }

        private void DrawBat()                                   // Bat 
        {
            m_Tools.BiaoTi_B("压缩包隐藏到图片格式");
            MyCreate.Box(() =>
            {
                MyCreate.SelectText("copy/b 图片名称.jpg+压缩包名称.rar 生成后图片的名称.jpg");
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702201802317-1976090067.png", 25);
            });

            AddSpace();
            m_Tools.BiaoTi_B("提取文件名");
            MyCreate.Box(() =>
            {
                MyCreate.SelectText("dir /w >列表.txt ");
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180702203702231-72846668.png", 25);
            });
            AddSpace();
            m_Tools.BiaoTi_B("批量修改后缀名");
            MyCreate.Box(() =>
            {
                MyCreate.SelectText(" ren *.*    *.");
                m_Tools.Text_L("例如把所有 .txt 转成 .mp3 ->  ", "ren *.txt*    *.mp3".AddWhite());
            });



        }

        private void DrawBiaoJi()                               // 标记
        {
            m_Tools.SelectTextText_B("º ¹ ² ³ ⁴ ⁵ ⁶ ⁷ ⁸ ⁹", "上标数字");
            m_Tools.SelectTextText_B("₀ ₁ ₂ ₃ ₄ ₅ ₆ ₇ ₈ ₉", "下标数字");
            m_Tools.SelectTextText_B("㆒㆓㆔㆕", "上标");
        }


        private void DrawChongZhuang()                          // 重装记录
        {
            m_Tools.BiaoTi_O("ReSharper 重装与破解");
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://www.cnblogs.com/djd66/p/8005678.html", "详情看这个");

                m_Tools.Text_Y("1. 安装 JetBrains.ReSharperUltimate.2017.2.2");
                m_Tools.Text_Y("2. 直接对 dvt-jb_licsrv.amd64.exe 目录 cmd");
                m_Tools.TextSelectText_Y("3. 输入", "dvt-jb_licsrv.amd64.exe -mode install", -80);
                m_Tools.Text_Y("3. 打开 ReSharper 的密钥设置第三个 Server address");
                m_Tools.TextSelectText_Y("3. 输入", "http://127.0.0.1:1337", -80);
            });
            MyCreate.AddSpace(10);
            m_Tools.BiaoTi_O("VS 快捷键设置");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Ctrl + 1", "编辑，折叠到定义", -30);
                m_Tools.TextText_BL("Ctrl + 2", "编辑：展开所有大纲显示", -30);
                m_Tools.TextText_BL("Ctrl + Y", "编辑：删除行", -30);
                m_Tools.TextText_BL("Ctrl + Alt + L", "编辑：设置选定内容的格式", -30);

            });


        }



        #endregion


        #region 网上使用


        private void DrawMiMa()                                  // 网站密码
        {
            MyCreate.Text("博客园：");
            m_Tools.TextSelectText_B("账号", "泡水泡");
            m_Tools.TextSelectText_B("密码(最后有个点)", "nan729611611.");
            AddSpace_3();
            MyCreate.Text("CSDN：");
            m_Tools.TextSelectText_B("账号", "15361253090");
            m_Tools.TextSelectText_B("密码(最后有个点)", "nan729611611.");
            AddSpace_3();
            MyCreate.Text("Unity：");
            m_Tools.TextSelectText_B("账号", "wwknan");
            m_Tools.TextSelectText_B("密码", "nanNAN123");
            AddSpace_3();
            MyCreate.Text("高通AR ：");
            m_Tools.TextSelectText_B("账号", "paoshuipao");
            m_Tools.TextSelectText_B("密码", "nanNAN123");
            AddSpace_3();
            MyCreate.Text("Github ：");
            m_Tools.TextSelectText_B("账号", "paoshuipao");
            m_Tools.TextSelectText_B("密码", "nan729611611");
            AddSpace_3();
            MyCreate.Text("微信小号 ：");
            m_Tools.SelectTextText_B("13944637913", "abc729611611");
            m_Tools.SelectTextText_B("13778664598", "abc729611611");

        }



        


        private void DrawInteresting()                           // 网上有趣的东西
        {
            m_Tools.TextUrl("267篇教学实用文章转载地址".PadLeft(55), "http://forum.china.unity3d.com/thread-23091-1-1.html");
            AddSpace();
            m_Tools.Text_L("1.按住 Alt键点击对象,就可以展开或收起该对象所有的子节点");
            m_Tools.Text_L("2.按 F 键会将该对象聚焦到屏幕中心");
            m_Tools.Text_L("3.按 Shift＋F 键让镜头跟着该对象后面移动");
            m_Tools.Text_L("4.颜色是可以右键复制的");
            m_Tools.Text_L("5.颜色下边有保存颜色值的");
            m_Tools.Text_L("6.Ctrl＋D 也可以应用于Inspector面板的数组");
            m_Tools.Text_L("7.在Inspector面板查看私有变量 右键 Inspectore 选择Debug");
            m_Tools.Text_L("8.鼠标聚焦在窗口名上，按Shift＋空格键最大化与还原");
            m_Tools.Text_L("9._GameSystem 存放脚本、预设");
            m_Tools.Text_L("10._GameAssets 存放纹理、材质、模型、声音等资源");

            m_Tools.BiaoTi_O("推荐使用的插件");
            m_Tools.TextUrl("插件推荐1", "http://forum.china.unity3d.com/thread-22342-1-12.html");
            m_Tools.TextUrl("插件推荐2", "http://forum.china.unity3d.com/thread-416-1-36.html");
            m_Tools.TextUrl("十大人气插件", "http://forum.china.unity3d.com/thread-22723-1-8.html");
            m_Tools.TextText_BL("Pause your game", "有选择地暂停游戏");
            m_Tools.TextText_BL("Save your game", "保存游戏序列化");
            m_Tools.TextText_BL("Favorite Tab", "给资源做标记汇总到一个单独窗口中");
            m_Tools.TextText_BL("Decal System", "美丽的贴花");
            m_Tools.TextText_BL("Lightmapping Extended", "光照贴图增强");
            m_Tools.TextText_BL("DOTween/iTween", "动画");
            m_Tools.TextText_BL("Mecanim Example Scenes", "动画系统教程资源");
            m_Tools.TextText_BL("Photon Cloud", "轻松实现游戏中的多人联网");
        }



        private void DrawGitHub()                                // GitHub
        {
            m_Tools.ShowEnglish(ref _isYinWen, ref _isShow, l_EngChina);

            AddSpace();
            m_Tools.BiaoTi_O("简介与功能原理", ref _isJieShao, () =>
            {
                m_Tools.TextUrl("我的Github主页".PadLeft(75), "https://github.com/paoshuipao");
                MyCreate.AddSpace(15);
                MyCreate.Window("功能原理", () =>
                {
                    m_Tools.Text_G("1. git 跟踪的是文件的修改而不是全部文件");
                    m_Tools.Text_G("2. git 擅长管理代码等文本文件，不擅长管理图片等二进制文件");
                    AddSpace_3();
                    m_Tools.Text_H("   ━━━━━━━━━━ checkout ━━━━━━━━━━   ━━clone/fetch/pull ━");
                    m_Tools.Text_H("  ↓                                             ↑  ↓                          ↑");
                    m_Tools.Text_H("[工作区]".AddWhite(), " —add→ ", "缓存区".AddLightGreen(),
                        "—commit→" + "[版本库]".AddWhite(), " —commit→", "[远程库]".AddWhite());
                });
            });
            AddSpace();
            m_Tools.BiaoTi_O("下载安装 git 和 ToroiseGit（小乌龟）+配置", ref _isAnZhuang, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_L("1. 安装全部按默认即可");
                    m_Tools.Text_L("2. 小乌龟Setting -> Git -> Global");
                    m_Tools.Text_H("    填写 Name 和 Email " + "（就是Github上的名和邮箱）".AddLightGreen());
                    m_Tools.Text_L("3.直接在 Setting 的第一行设置中文");
                });
            });
            AddSpace();

            m_Tools.BiaoTi_O("上传文件夹", true);
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("0. 新建文件夹，放入资料");
                m_Tools.Text_L("1. 对着文件夹右鍵,选择 ", "Git 在这里创建版本库".AddWhite());
                m_Tools.Text_L("2. 右键，选择 ", "Git 提交".AddWhite());
                m_Tools.Text_L("    在提交前，先把需要的 ", "Add".AddHui());
                m_Tools.Text_L("    不需要的 ", "添加到忽略列表".AddHui());
                m_Tools.Text_L("3. 最后上传 Github");
                m_Tools.Text_L("    右键", "推送".AddWhite(), " -> 点击", "管理".AddWhite(), ",填写好", " URL".AddHui(), " 和",
                    " 推送URL".AddHui());
            });
        }

        #endregion


        #region 游戏分类

        private void DrawShuoXie()                               // 游戏分类
        {
            BiaoTi("RPG", "(Role Playing Game)", "角色扮演游戏", "更强调剧情发展和个人体验", "《最终幻想》、《仙剑》");
            BiaoTi("AVG", "(Adventure Game)", "冒险游戏", "故事情节往往是以完成一个任务或解开谜题的形式出现", "《生化危机》、《古墓丽影》");
            BiaoTi("ACT", "(Action Game)", "动作游戏", "强打击感、目的通关、不追求故事情节，", "《鬼泣》、《魂斗罗》");
            BiaoTi("SLG", "(Simulation Game)", "策略游戏", "玩家运用策略与电脑或其它玩家较量，以取得胜利", "《三国志》", () =>
            {
                MyCreate.Text("分支：    ".AddGreen() + "模拟经营".AddYellow() + " SIM".AddOrange() + "（simulation）".AddHui() + (isJian ? "" : "   《模拟人生》".AddLightBlue()));
            });
            BiaoTi("SRPG", "(Simulation Role playing Game)", "战略类角色扮演", "有丰富剧情 + 具有战略战斗", "《火焰纹章》");
            BiaoTi("RTS", "(Real Time Strategy Game)", "即时战略游戏", "", "《魔兽争霸》、《红色警戒》");
            BiaoTi("FTG", "(Fighting Game)", "格斗游戏", "双方控制角色进行格斗，依靠玩家判断和微操作取胜", "《拳皇》、《街霸》");
            BiaoTi("STG", "(Shooting Game)", "射击类游戏", "控制各种飞行物过关的游戏", "《雷电》、《全民打飞机》");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BY("FPS".AddOrange() + "First Personal Shooting Game".AddHui(), "第一人称视角射击游戏", 50);
                if (!isJian)
                {
                    MyCreate.Text("代表作：".AddGreen() + "《CS》、《守望先锋》".AddLightBlue());
                }
                m_Tools.TextText_BY("TPS".AddOrange() + "Third Personal Shooting Game".AddHui(), "第三人称视角射击游戏", 50);
                if (!isJian)
                {
                    MyCreate.Text("代表作：".AddGreen() + "《合金弹头》".AddLightBlue());
                }
            });
            BiaoTi("SPG", "(Sports Game)", "体育竞技类游戏", "模拟各类竞技体育运动的游戏", "《实况足球》、《NBA Live》");
            BiaoTi("RCG", "(Racing Game)", "竞速游戏", "模拟各类赛车比赛", "《极品飞车》、《QQ飞车》");
            BiaoTi("CAG", "(Card Game)", "卡片游戏", "通过卡片战斗模式", "《炉石传说》、《游戏王》");
            BiaoTi("TAB", "(Table Game)", "桌面游戏", "", "《斗地主》、《麻将》");
            BiaoTi("MSC", "(Music Game)", "音乐游戏", "", "《劲乐团》、《节奏大师》");
            BiaoTi("MOBA", "(Multiplayer online battle arena)", "多人在线战术竞技游戏", "", "《英雄联盟》、《dota》");
            MyCreate.Button(isJian ? "切换详细版".PadLeft(40) : "切换简化版".PadLeft(40), () =>
            {
                isJian = !isJian;
            });
        }

        private void DrawDongZuo()                               // 动作游戏
        {
            TDrawnOne("传统分类", () =>
            {
                TDrawTwo("平台动作", null);
                TDrawTwo("卷轴动作", null);
            });
            TDrawnOne("按游戏方式", () =>
            {
                TDrawTwo("射击游戏", () =>
                {
                    TDrawThree("第一人称射击游戏", null);
                    TDrawThree("第三人称射击游戏", null);
                    TDrawThree("俯视、卷轴与其他人称射击游戏", null);
                });
                TDrawTwo("格斗游戏", () =>
                {
                    TDrawThree("2D/格斗游戏", null);
                    TDrawThree("2.5D格斗游戏", null);
                    TDrawThree("3D格斗游戏", null);
                });
                TDrawTwo("模拟动作游戏" + "(与角色扮演游戏结合)".AddGreen(), () =>
                {
                    TDrawThree("模拟射击游戏", null);
                    TDrawThree("模拟格斗游戏", null);
                });
                TDrawTwo("动作冒险游戏" + "(与冒险游戏结合)".AddGreen(), null);
                TDrawTwo("动作角色扮演游戏" + "(与角色扮演游戏结合)".AddGreen(), null);
            });

            TDrawnOne("按内容", () =>
            {
                TDrawTwo("战争游戏", null);
                TDrawTwo("体育游戏" + "(在过去体育游戏是动作游戏的分支分类)".AddGreen(), null);
            });


        }

        private void DrawMao()                                   // 冒险游戏
        {
            TDrawnOne("传统分类", () =>
            {
                TDrawTwo("文字冒险游戏", null);
                TDrawTwo("图像冒险游戏", null);
            });
            TDrawnOne("按游戏方式", () =>
            {
                TDrawTwo("动作冒险游戏" + "(与动作游戏相结合)".AddGreen(), null);
                TDrawTwo("文字冒险游戏" + "(传统的文字冒险游戏和图像冒险游戏)".AddGreen(), null);
                TDrawTwo("视觉小说", null);
                TDrawTwo("角色扮演冒险游戏" + "(与角色扮演游戏结合)".AddGreen(), null);
                TDrawTwo("沙盒冒险游戏" + "(与沙盒游戏结合)".AddGreen(), null);

            });

            TDrawnOne("按主题", () =>
            {
                TDrawTwo("解谜冒险游戏", null);
                TDrawTwo("恋爱冒险游戏" + "(美少女+恋爱元素+加冒险)".AddGreen(), null);
                TDrawTwo("恋爱游戏" + "(包括恋爱冒险游戏和恋爱模拟游戏)".AddGreen(), null);
                TDrawTwo("美少女恋爱游戏" + "(属于美少女游戏的分支)".AddGreen(), null);
            });

        }


        private void DrawMoNi()                                  // 模拟游戏
        {
            TDrawnOne("按游戏方式", () =>
            {
                TDrawTwo("角色扮演模拟游戏", null);
                TDrawTwo("策略模拟游戏", null);
                TDrawTwo("动作模拟游戏", () =>
                {
                    TDrawThree("模拟射击游戏", null);
                    TDrawThree("模拟格斗游戏", null);
                });
            });

            TDrawnOne("按主题", () =>
            {
                TDrawTwo("模拟经营/模拟养成/普通模拟/模拟沙盘 游戏", null);
            });
            TDrawnOne("按内容", () =>
            {
                TDrawTwo("战争游戏", null);
                TDrawTwo("飞行模拟游戏" + "(客机模拟/战斗机模拟)".AddGreen(), null);
                TDrawTwo("载具模拟" + "(车辆/赛车/舰船/民船/军舰/列车 模拟)".AddGreen(), null);
                TDrawTwo("城市建造游戏", null);
                TDrawTwo("商业模拟游戏", null);
                TDrawTwo("恋爱模拟游戏", null);
                TDrawTwo("模拟软件", null);
                TDrawTwo("射击场游戏", null);
            });
            TDrawnOne("其他", () =>
            {
                TDrawTwo("战术射击游戏", null);
                TDrawTwo("上帝模拟游戏", null);
            });
        }



        private void DrawJieSe()                                 // 角色扮演游戏
        {
            TDrawnOne("按载体", () =>
            {
                TDrawTwo("桌面角色扮演游戏", null);
                TDrawTwo("电子平台角色扮演游戏", null);
                TDrawTwo("实演角色扮演游戏", null);
            });

            TDrawnOne("按游戏方式", () =>
            {
                TDrawTwo("动作角色扮演游戏", null);
                TDrawTwo("模拟角色扮演游戏", null);
                TDrawTwo("策略角色扮演游戏", null);
                TDrawTwo("角色扮演冒险游戏", null);
            });
            TDrawnOne("按主题", () =>
            {
                TDrawTwo("恋爱角色扮演游戏", null);
                TDrawTwo("角色扮演解谜游戏", null);
            });
            TDrawnOne("大型多人在线游戏", () =>
            {
                TDrawTwo("大型多人在线角色扮演游戏", null);
            });

        }



        private void DrawCi()                                    // 策略游戏
        {
            TDrawnOne("按规模", () =>
            {
                TDrawTwo("战略游戏", null);
                TDrawTwo("战术游戏", null);

            });

            TDrawnOne("传统分类", () =>
            {
                TDrawTwo("回合制战略游戏", null);
                TDrawTwo("回合制战术游戏", null);
                TDrawTwo("即时战略游戏", null);
                TDrawTwo("即时战术游戏", null);

            });
            TDrawnOne("按主题", () =>
            {
                TDrawTwo("战争游戏", null);
                TDrawTwo("战术射击游戏", null);
                TDrawTwo("抽象策略游戏", null);
                TDrawTwo("解谜游戏", null);

            });
            TDrawnOne("按游戏方式", () =>
            {
                TDrawTwo("策略角色扮演游戏", null);
                TDrawTwo("策略冒险游戏", null);
                TDrawTwo("角色扮演模拟游戏", null);
                TDrawTwo("益智游戏", null);
            });

        }



        private void DrawOther()                                 // 其余大类
        {
            TDrawnOne("音乐游戏", null);
            TDrawnOne("休闲游戏", null);
            TDrawnOne("体育游戏", null);
            TDrawnOne("竞速游戏", null);
            TDrawnOne("网页游戏", null);
            TDrawnOne("小游戏", null);
            TDrawnOne("大型多人在线网络游戏", null);


        }

        #endregion

        #region 自控力


        private void DrawZiKong()
        {

        }

        private void DrawYiZhiLi()                               // 意志力
        {
            m_Tools.BiaoTi_B("意志力 —>"+" 控制自己的注意力、情绪和欲望的能力".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BY("基础：","自知之明",-30);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("   人最怕没有自知之明，明明是错的，总说没问题，我没错");
                });
                m_Tools.TextText_BY("关键：","认识到有问题",-30);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("    1. 出现严重危机或病情才认识到有问题");
                    m_Tools.Text_H("    2. 在没出现问题前，提前预知到问题所在");
                    m_Tools.Text_G("    3. 提前预知到问题是自控力的关键点");
                });

                m_Tools.TextText_BY("三种自控：","我要做、我不要、我想要",-30);
                MyCreate.Box_Hei((() =>
                {
                    m_Tools.Text_H("    我要做： 我要吃饭，我要减肥");
                    m_Tools.Text_H("    我不要： 我不要吃垃圾食品，我不要吃高质量的食物");
                    m_Tools.Text_H("    我想要： 我想要减多多少斤，反馈给我要做 -> 多少运动");
                }));
            });

            AddSpace_3();
            m_Tools.BiaoTi_Y("训练大脑  -> "+"冥想".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_W("    1. 每天只需坚持 5 分钟");
                m_Tools.Text_W("    2. 静坐  ->  数 呼吸（走神的时候拉回来）");

            });

            AddSpace_3();
            m_Tools.BiaoTi_Y("面对内心的欲望，可以怎么做");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("    1. 降低呼吸频率：深呼吸 -> 喝口水 -> 再深呼吸");
                m_Tools.Text_L("    2. 做运动（慢跑几圈，边跑边想）");



            });

        }





        #endregion


        #region 重装

        private void DrawGuGe()                                  // 谷歌浏览器
        {

            m_Tools.BiaoTi_O("下载百度云保存的");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("不要安装最新版的谷歌，太坑了");
                m_Tools.TextButton_Open("打开分享下载", "https://pan.baidu.com/s/1zk0BEPuAQLOpz3vV10bSVA");

                m_Tools.Text_G("全部先用后缀改成  zip  ->  然后解压出来");
                m_Tools.Text_G("把  _metadata   去除   _");
                m_Tools.Text_G("用开发模式加载");


            });
            AddSpace_3();




            m_Tools.BiaoTi_O("复制网站地址");
            MyCreate.Box(() =>
            {
                MyCreate.SelectText("http://www.manew.com/");
                MyCreate.SelectText("http://www.6m5m.com/");
                MyCreate.SelectText("http://www.taikr.com/");
                MyCreate.SelectText("https://translate.google.cn/#en/zh-CN");
            });
            AddSpace();
            m_Tools.BiaoTi_O("Tampermonkey");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open("打开下载脚本网站", "https://greasyfork.org/zh-CN");


            });

        }



        #endregion


        #region 杂项


        private void DrawShiPing()                               // 视频分割上传
        {

            m_Tools.BiaoTi_O("1.1 视频分割");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open("打开视频编辑专家", @"D:\Soft_CommonlyUsed\视频编辑专家\视频编辑专家\Startup.exe");

                m_Tools.Text_L("  1. 点击视频分割,添加要分割的视频文件");
                m_Tools.Text_H("       ▪ 添加文件  ▪ 设置输出目录  ▪ 下一步");
                m_Tools.Text_L("  2. 分割设置");
                m_Tools.Text_H("       ▪ 设置手动分割  在下面随意的分割许多段   ▪ 下一步  ▪ OK");
            });
            m_Tools.BiaoTi_O("1.1 合并 原视频 + 任意小片段");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open("打开格式工厂", @"D:\Soft_CommonlyUsed\格式工厂\FormatFactory.exe");
                m_Tools.Text_L("  1. 先在左下角点击添加文件夹"+"(设置输出路径)".AddGreen());
                m_Tools.Text_L("  2. 点击视频合并 "+"(添加文件：原视频＋１个分割的小视频)");
                m_Tools.Text_H("       ▪ 重复把　　原视频　＋　所有每　１　个分割的小视频合并");
                m_Tools.Text_H("       ▪ 只要是把 原视频 ","放在前面 ".AddGreen(),"+ 任意小片段  即可");
            });

            m_Tools.BiaoTi_O("2. 批量生成和批量改标题");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open("http://jz.haihui100.com/1.php", @"http://jz.haihui100.com/1.php");
                m_Tools.Text_L("   把视频全部改名成网站要的名字");
                m_Tools.TextText_BL("      .Bat 原理", " ren 原文件名.mp4 改文件名.mp4", -30);

            });

            m_Tools.BiaoTi_O("3.1 传B站");
            MyCreate.Box(() =>
            {

                m_Tools.TextButton_Open("打开 bibi"+ "(会提供用户、密码)".AddGreen(), @"https://www.bilibili.com/");
                m_Tools.TextButton_Open("打开 60 码平台" + "(会提供用户、密码)".AddGreen(), @"http://www.60ma.net/");
                MyCreate.Box(() =>
                {
                    MyCreate.SelectText(" 1193452659      weihai  ");
                    MyCreate.SelectText(" lzh75535     3334444  ");
                });
                m_Tools.Text_L("   使用 60 码平台绑定 bibi 手机号");


                m_Tools.TextButton_Open("打开 bibi 投稿工具"  , @"D:\Soft\B站投稿\ugc_assistant\ugc_assistant.exe");
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("注意：".AddYellow());
                    m_Tools.Text_B("     ▪ 在设置中设置：同时上传视频数为 1 ");
                    m_Tools.Text_B("     ▪ 把视频码率过高那个选项 ","不选".AddGreen());

                });

                m_Tools.Text_L("  然后点击投稿   -> 一直点新建投稿  ");
                m_Tools.Text_L("  随机加封面图  ");
                m_Tools.Text_L("  选择  自制、科技（演讲*分开课、野生技术协会、趣味科普人文 随机一个）");
                m_Tools.Text_L("  标签就随意 公开课、经验分享、视频教程、教育、野生技术协会");
                m_Tools.Text_L("  简介 可复制标题、也可写   快速建站视频！");
                m_Tools.Text_L("  “上传完成 5 秒后自动提交” 打勾 -> 写好信息就可挂机");


                m_Tools.Text_H("     换账号  ->  重启下路由器  +  清理下缓存  ->  识别新的电脑");

            });
            m_Tools.BiaoTi_O("3.2. 传优酷");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open("打开 优酷客户端" , @"D:\Soft\优酷\YoukuClient\proxy\YoukuDesktop.exe");

                m_Tools.Text_L(" 主页  ->  上传  -> 注册 -> 60 码网站（60码官方）");

                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("注意：".AddYellow());
                    m_Tools.Text_B("     ▪  点击头像  ->  进度条  -> 进入浏览器  -> 修改  ->");
                    m_Tools.Text_B("           修改会员号", "（带一个自己的名字 的名称）".AddGreen());
                    m_Tools.Text_B("     ▪ 在设置中设置：同时上传视频数为 1 ");
                });

                m_Tools.Text_L(" 然后新建上传  -> 点击教育");
                m_Tools.Text_L(" 记录“ 会员号 + 上传成功的视频名称”");
                m_Tools.Text_L(" 如果都不成功那就换一个会员号");


            });
            m_Tools.BiaoTi_O("3.2. 传爱奇艺");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open("打开 271 网站", @"http://so.iqiyi.com/");
                m_Tools.TextButton_Open("打开 上传客户端", @"D:\Soft\优酷\爱其艺\IQIYI Video\Uploader\bin\QYUploader.exe");

            });
        }



        private void DrawClearWeb()                              // 清理缓存
        {

            MyCreate.SelectText("ipconfig /flushdns");

        }


        #endregion



    }
}


