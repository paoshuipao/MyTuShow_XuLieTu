using System;
using System.Collections.Generic;
using System.IO;
using Ez;
using Ez.Pooly.Statistics;
using JetBrains.Annotations;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using QuickEngine.Core;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace UnityEditor
{
    public abstract class AbstactNewKuang: QWindow
    {

        void DrawSideBar()                                       // 画左边
        {
            bool isEasy = OnIsEasy();
            QUI.BeginVertical(mWindowSettings.SidebarCurrentWidth);
            {
                DrawSideBarLogo();
                if (!isEasy)
                {
                    DrawBtnExpandCollapseSideBar();
                }
                else
                {
                    AddSpace_3();
                }
                QUI.Space(mWindowSettings.sidebarVerticalSpacing);
                DrawLeft();
                QUI.FlexibleSpace();
                if (!isEasy)
                {
                    DrawSocialButtons();
                }
            }
            QUI.EndVertical();
        }
        void DrawPages()                                         // 画右边
        {
            DrawRightSize();
            GUI.skin = LoadRes.ResourcesSkin;
            PageScrollPosition = QUI.BeginScrollView(PageScrollPosition);
            {
                QUI.BeginVertical(mWindowSettings.CurrentPageContentWidth);
                {
                    DrawRight();
                    QUI.FlexibleSpace();
                }
                QUI.EndVertical();
                QUI.Space(16);
            }
            QUI.EndScrollView();
        }



        #region 私有

        protected AnimBool editStats;
        private GUIStyle _pageHeaderTitleStyle;
        private GUIStyle _pageHeaderSubtitleStyle;
        private static PoolyStatistics _poolyStatistics;
        private string mTittle;
        protected WindowSetting mWindowSettings;
        private static Vector2 PageScrollPosition = Vector2.zero;
        private static Vector2 PageLastScrollPosition = Vector2.zero;
        public static bool Selected = false;
        protected string tempLabel = string.Empty;
        private Rect tempRect;
        protected bool isNeedTu = true;
        protected ZuHeTool m_Tools;


        public static PoolyStatistics PS
        {
            get
            {
                if (_poolyStatistics == null)
                {
                    _poolyStatistics = Q.GetResource<PoolyStatistics>(EZT.RESOURCES_PATH_POOLY_STATISTICS, "PoolyStatistics");
                    if (_poolyStatistics == null)
                    {
                        _poolyStatistics = Q.CreateAsset<PoolyStatistics>(EZT.RELATIVE_PATH_POOLY_STATISTICS, "PoolyStatistics");
                    }
                }
                return _poolyStatistics;
            }
        }
        private GUIStyle PageHeaderTitleStyle
        {
            get
            {
                if (_pageHeaderTitleStyle == null)
                {
                    _pageHeaderTitleStyle = new GUIStyle(GUI.skin.label)
                    {
//                        font = QResources.GetFont(Sansation.Regular),
                        fontSize = 26,
                        alignment = TextAnchor.MiddleLeft,
                        wordWrap = false,
                        margin = new RectOffset(0, 0, 0, 0),
                        border = new RectOffset(0, 0, 0, 0),
                        padding = new RectOffset(0, 0, 0, 0),
                    };
                }
                return _pageHeaderTitleStyle;
            }
        }

        private GUIStyle PageHeaderSubtitleStyle
        {
            get
            {
                if (_pageHeaderSubtitleStyle == null)
                {
                    _pageHeaderSubtitleStyle = new GUIStyle(GUI.skin.label)
                    {
                        fontSize = 16,
                        alignment = TextAnchor.MiddleLeft,
                        wordWrap = false,
                        margin = new RectOffset(0, 0, 0, 0),
                        border = new RectOffset(0, 0, 0, 0),
                        padding = new RectOffset(0, 0, 0, 0)
                    };
                }
                return _pageHeaderSubtitleStyle;
            }
        }



        protected void ResetPageView()
        {
            PageScrollPosition = Vector2.zero; //reset scroll
            PageLastScrollPosition = PageScrollPosition;
        }

        protected void SetupWindow()
        {
            titleContent = new GUIContent(mTittle);
            mWindowSettings.sidebarIsExpanded.speed = 2;
            mWindowSettings.sidebarIsExpanded.valueChanged.RemoveAllListeners();
            mWindowSettings.sidebarIsExpanded.valueChanged.AddListener(Repaint);
            mWindowSettings.sidebarIsExpanded.valueChanged.AddListener(UpdateWindowSize);

            mWindowSettings.pageWidthExtraSpace.valueChanged.RemoveAllListeners();
            mWindowSettings.pageWidthExtraSpace.valueChanged.AddListener(Repaint);
            mWindowSettings.pageWidthExtraSpace.valueChanged.AddListener(UpdateWindowSize);

            UpdateWindowSize();
            CenterWindow();
        }

        protected abstract void DrawLeft();
        protected abstract void DrawRight();
        protected abstract void DrawRightSize();
        protected abstract string Tittle();

        void OnGUI()
        {
            UpdateWindowSize();
            DrawBackground();

            QUI.BeginHorizontal(position.width);
            {
                DrawSideBar();
                QUI.Space(mWindowSettings.pageShadowWidth);
                DrawPages();
            }
            QUI.EndHorizontal();

            if (Event.current.type != EventType.Layout)
            {
                if (PageScrollPosition != PageLastScrollPosition) //if the user has scrolled, deselect - this is because control IDs within carousel will change when scrolled so we'd end up with the wrong box selected.
                {
                    GUI.FocusControl(""); //deselect
                    PageLastScrollPosition = PageScrollPosition;
                }
            }

            Repaint();

        }

        void OnEnable()
        {
            OnInit();
            editStats = new AnimBool(false, Repaint);
            m_Tools = new ZuHeTool(OnChangeJianGe());
            mTittle = Tittle();
            mWindowSettings = LearnWindowSetting.Instance;
            autoRepaintOnSceneChange = true;
            OnIsEasy();
        }

        void OnDisable()
        {
            Resources.UnloadUnusedAssets();
            GC.Collect();
        }





        private void UpdateWindowSize()
        {
            minSize = new Vector2(mWindowSettings.windowMinimumWidth, mWindowSettings.windowMinimumHeight);
            maxSize = new Vector2(minSize.x, Screen.currentResolution.height);
        }


        private void DrawSideBarLogo()
        {
            if (mWindowSettings.sidebarIsExpanded.faded <= 0.1f)
            {
                QUI.DrawTexture(EZResources.sidebarLogo10.texture, mWindowSettings.sidebarExpandedWidth, mWindowSettings.sidebarLogoHeight);
            }
            else if (mWindowSettings.sidebarIsExpanded.faded <= 0.9f)
            {
                QUI.DrawTexture(Texture2D.blackTexture, mWindowSettings.sidebarExpandedWidth, mWindowSettings.sidebarLogoHeight);
            }
            else { QUI.DrawTexture(EZResources.sidebarLogo0.texture, mWindowSettings.sidebarExpandedWidth, mWindowSettings.sidebarLogoHeight); }
        }


        private void DrawBtnExpandCollapseSideBar()
        {
            if (QUI.Button("", EZStyles.GetStyle(mWindowSettings.sidebarIsExpanded.faded < 0.9f ? EZStyles.General.SideButtonExpandSideBar : EZStyles.General.SideButtonCollapseSideBar), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                mWindowSettings.sidebarIsExpanded.target = !mWindowSettings.sidebarIsExpanded.target;
            }
        }


        private void DrawBackground()
        {
            tempRect = new Rect(0, 0, position.width, position.height);
            QUI.DrawTexture(new Rect(tempRect.x, tempRect.y, mWindowSettings.SidebarCurrentWidth, tempRect.height), QResources.backgroundSidebar.texture);
            tempRect.x += mWindowSettings.SidebarCurrentWidth;
            QUI.DrawTexture(new Rect(tempRect.x, tempRect.y, mWindowSettings.pageShadowWidth, tempRect.height), QResources.backgroundContentShadowLeft.texture);
            tempRect.x += mWindowSettings.pageShadowWidth;
            QUI.DrawTexture(new Rect(tempRect.x, tempRect.y, mWindowSettings.pageShadowWidth + mWindowSettings.CurrentPageContentWidth + mWindowSettings.scrollbarSize, tempRect.height), QResources.backgroundContent.texture);
        }


        private void DrawRightPage(Texture text, [NotNull]Action page, bool isBox,Action nextButton)  // 画任意 右边页面都使用这个
        {
            QUI.Space(5);
            if (isNeedTu)
            {
                QUI.DrawTexture(text, mWindowSettings.CurrentPageContentWidth, 620);
                QUI.Space(-620);
            }
            QUI.Space(2);
            if (isBox)
            {
                MyCreate.Box(page);
            }
            else
            {
                MyCreate.Box_Hei(page);
            }
            MyCreate.AddSpace();
            if (null!= nextButton)
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.AddSpace();
                    if (GUILayout.Button("", QStyles.GetStyle(Style.LinkButton.Unity), GUILayout.Width(80), GUILayout.Height(20)))
                    {
                        nextButton();
                    }
                });
            }

        }


        private void DrawPageHeader(string title, QColor titleColor, string subtitle, QColor subtitleColor, QTexture iconQTexture)
        {
            QUI.Space(2);
            QUI.Box(QStyles.GetBackgroundStyle(Style.BackgroundType.Low, QColors.Color.Gray), mWindowSettings.CurrentPageContentWidth + mWindowSettings.pageShadowWidth, mWindowSettings.pageHeaderHeight);
            QUI.Space(-mWindowSettings.pageHeaderHeight + (mWindowSettings.pageHeaderHeight - mWindowSettings.pageHeaderHeight * 0.8f) / 2);
            QUI.BeginHorizontal(mWindowSettings.CurrentPageContentWidth + mWindowSettings.pageShadowWidth, mWindowSettings.pageHeaderHeight * 0.8f);
            {
                QUI.Space((mWindowSettings.pageHeaderHeight - mWindowSettings.pageHeaderHeight * 0.8f));
                QUI.BeginVertical((mWindowSettings.CurrentPageContentWidth + mWindowSettings.pageShadowWidth) / 2, mWindowSettings.pageHeaderHeight * 0.8f);
                {
                    QUI.FlexibleSpace();
                    if (!title.IsNullOrEmpty())
                    {
                        QUI.Space(-2);
                        QUI.SetGUIColor(titleColor.Color);
                        QUI.Label(title, PageHeaderTitleStyle, (mWindowSettings.CurrentPageContentWidth + mWindowSettings.pageShadowWidth) / 2, 26);
                        QUI.ResetColors();
                    }

                    if (!subtitle.IsNullOrEmpty())
                    {
                        QUI.Space(-2);
                        QUI.SetGUIColor(subtitleColor.Color);
                        QUI.Label(subtitle, PageHeaderSubtitleStyle, (mWindowSettings.CurrentPageContentWidth + mWindowSettings.pageShadowWidth) / 2, 18);
                        QUI.ResetColors();
                    }
                    QUI.FlexibleSpace();
                }
                QUI.EndVertical();
                QUI.FlexibleSpace();
                QUI.DrawTexture(iconQTexture.texture, mWindowSettings.pageHeaderHeight * 0.8f, mWindowSettings.pageHeaderHeight * 0.8f);
                QUI.Space((mWindowSettings.pageHeaderHeight - mWindowSettings.pageHeaderHeight * 0.8f) / 2);
            }
            QUI.EndHorizontal();
        }



        #endregion


        protected void AddHead(string biaoTi,string fuBiaoTi)    // 在右边  加个头标记
        {
            DrawPageHeader(biaoTi, QColors.Green, fuBiaoTi, QUI.IsProSkin ? QColors.UnityLight : QColors.UnityMild, EZResources.IconPooly);

        }


        protected void AddToggleButton(string biaoTi,string actionStr1,string actionStr2,[NotNull]Action action1, [NotNull]Action action2)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace();
                if (QUI.GhostButton(biaoTi, QColors.Color.Orange, 80, 20, editStats.target))
                {
                    editStats.target = !editStats.target;
                }
                if (editStats.faded > 0.05f)
                {
                    if (QUI.GhostButton(actionStr1, QColors.Color.Green, PS.databaseClearStatisticsButtonWidth * editStats.faded, 20))
                    {
                        action1();
                    }
                    if (QUI.GhostButton(actionStr2, QColors.Color.Blue, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        action2();
                    }
                }
            });

        }


        protected virtual bool OnIsEasy()                           // 是否简易模式（默认不是）
        {
            return false;
        }


        //————————————————————————————————————
        


        void DrawSocialButtons()                                 // 按钮1  按钮2 
        {
            if (mWindowSettings.sidebarIsExpanded.faded < 0.3f)
            {
                QUI.BeginVertical(mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight * 3);
            }
            else
            {
                QUI.BeginHorizontal(mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight);
            }
            int btnNum = 2;
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.8f ? "" : (isNeedTu? "去图" : "加图");
            if (QUI.Button(tempLabel,
                EZStyles.GetStyle(EZStyles.General.SideButtonTwitter),
                mWindowSettings.sidebarExpandedWidth / btnNum >= mWindowSettings.SidebarCurrentWidth ? mWindowSettings.SidebarCurrentWidth : mWindowSettings.SidebarCurrentWidth / btnNum, mWindowSettings.sidebarButtonHeight))
            {
                isNeedTu = !isNeedTu;
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.8f ? "" : "退出";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.sidebarExpandedWidth / btnNum >= mWindowSettings.SidebarCurrentWidth ? mWindowSettings.SidebarCurrentWidth : mWindowSettings.SidebarCurrentWidth / btnNum, mWindowSettings.sidebarButtonHeight))
            {
                OnClickBtn2();
            }
            QUI.FlexibleSpace();

            if (mWindowSettings.sidebarIsExpanded.faded < 0.3f)
            {
                QUI.EndVertical();
            }
            else
            {
                QUI.EndHorizontal();
            }
        }

        protected virtual void OnClickBtn2()                     // 点击按钮 2 做什么
        {
            Close();
        }



        protected void DrawRightPage([NotNull]Action page, Action nextButton = null)
        {
            QUI.Space(7);
            MyCreate.Box(page);
            MyCreate.AddSpace();
            if (null != nextButton)
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.AddSpace();
                    if (GUILayout.Button("", QStyles.GetStyle(Style.LinkButton.Unity), GUILayout.Width(80), GUILayout.Height(20)))
                    {
                        nextButton();
                    }
                });
            }
        }
        protected void DrawRightPage1([NotNull]Action page, Action nextButton = null)
        {
            DrawRightPage(EZResources.ChuYin1.texture, page, true, nextButton);
        }
        protected void DrawRightPage2([NotNull]Action page, Action nextButton = null)
        {
            DrawRightPage(EZResources.ChuYin2.texture, page,false, nextButton);
        }
        protected void DrawRightPage3([NotNull]Action page, Action nextButton = null)
        {
            DrawRightPage(EZResources.ChuYin3.texture, page,true, nextButton);
        }
        protected void DrawRightPage4([NotNull]Action page, Action nextButton = null)
        {
            DrawRightPage(EZResources.ChuYin4.texture, page, true, nextButton);
        }

        protected void DrawRightPage5([NotNull]Action page, Action nextButton = null)
        {
            DrawRightPage(EZResources.ChuYin5.texture, page, true, nextButton);
        }
        protected void DrawRightPage6([NotNull]Action page, Action nextButton = null)
        {
            DrawRightPage(EZResources.ChuYin6.texture, page, true, nextButton);
        }

        protected void DrawRightPage7([NotNull]Action page, Action nextButton = null)
        {
            DrawRightPage(EZResources.ChuYin7.texture, page, true, nextButton);
        }

        protected void DrawRightPage8([NotNull]Action page, Action nextButton = null)
        {
            DrawRightPage(EZResources.ChuYin8.texture, page, true, nextButton);
        }

        //—————————————————— Old ——————————————————


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




        protected static readonly string OpenSure = "开启：".AddWhite();
        protected static readonly string ZhongZai = "+ ".AddLightGreen();
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

        protected static void ShowImage(string path, int kongGe = 13)
        {
            Texture2D texture = LoadRes.DownImage(path);
            ShowImage(texture);
        }

        protected static void ShowImage(Texture2D texture)
        {
            if (null != texture)
            {
                Rect rect = GUILayoutUtility.GetRect(0, 0);
                rect.x = 10;
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



        protected virtual void OnInit() { }

        protected virtual int OnChangeJianGe()                         // 改变间隔
        {
            return 200;
        }



        protected void DrawnOne(string str, Action action)             // 层次结构第一层
        {
            m_Tools.Text_O("───", str.AddOrange());
            if (null != action)
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.AddSpace(35);
                    MyCreate.Box(action);
                });
            }
        }

        protected void DrawTwo(string str, Action action)              // 层次结构第二层
        {
            m_Tools.Text_B("─── ", str.AddBlue());
            if (null != action)
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.AddSpace(35);
                    MyCreate.Box(action);
                });
            }
        }

        protected void DrawThree(string str, Action action)            // 层次结构第三层
        {
            m_Tools.Text_L("───  ", str.AddLightBlue());
            if (null != action)
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.AddSpace(35);
                    MyCreate.Box(action);
                });
            }
        }




        protected static readonly string ONE = "① ".AddColorAndSize(MyEnumColor.Red,15,false);
        protected static readonly string TWO = "② ".AddColorAndSize(MyEnumColor.Red, 15, false);
        protected static readonly string THREE = "③ ".AddColorAndSize(MyEnumColor.Red, 15, false);
        protected static readonly string FOUR = "④ ".AddColorAndSize(MyEnumColor.Red, 15, false);
        protected static readonly string FIVE = "⑤ ".AddColorAndSize(MyEnumColor.Red, 15, false);
        protected static readonly string SIX = "⑥ ".AddColorAndSize(MyEnumColor.Red, 15, false);
        protected static readonly string SEVEN = "⑦ ".AddColorAndSize(MyEnumColor.Red, 15, false);
        protected static readonly string EIGHT = "⑧ ".AddColorAndSize(MyEnumColor.Red, 15, false);


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
            int width = 64;
            int height = 64;
            Texture2D texture = new Texture2D(width, height);
            texture.LoadImage(bytes);
            return texture;
        }
    }

}

