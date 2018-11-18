using System.Collections.Generic;
using Ez.Editor;
using Ez.Pooly;
using Ez.Pooly.Statistics;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using QuickEngine.Core;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace Ez
{
    public class Tools_EZ : QWindow
    {

        [MenuItem(LearnMenu.Pools)]
        static void Init()
        {
            Instance = GetWindow<Tools_EZ>(false, "");
            Instance.SetupWindow();
        }


        private void DrawRight()                                 // 画左边
        {
            tempLabel = WindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Pooly";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(WindowSettings.currentPage == Page.Pooly ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), WindowSettings.SidebarCurrentWidth, WindowSettings.sidebarButtonHeight))
            {
                if (WindowSettings.currentPage != Page.Pooly)
                {
                    WindowSettings.currentPage = Page.Pooly;
                    ResetPageView();
                }
            }
            MyCreate.AddSpace(20);
            tempLabel = WindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "翻译文档";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(WindowSettings.currentPage == Page.FanYi ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), WindowSettings.SidebarCurrentWidth, WindowSettings.sidebarButtonHeight))
            {
                if (WindowSettings.currentPage != Page.FanYi)
                {
                    WindowSettings.currentPage = Page.FanYi;
                    ResetPageView();
                }
            }
            MyCreate.AddSpace(20);

            tempLabel = WindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "使用";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(WindowSettings.currentPage == Page.Use ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), WindowSettings.SidebarCurrentWidth, WindowSettings.sidebarButtonHeight))
            {
                if (WindowSettings.currentPage != Page.Use)
                {
                    WindowSettings.currentPage = Page.Use;
                    ResetPageView();
                }
            }


        }


        void InitPages()                                         // 大小
        {
            switch (WindowSettings.currentPage)
            {
                case Page.Pooly:
                    WindowSettings.pageWidthExtraSpace.target = 150;
/*                    if (PreviousPage != WindowSettings.currentPage || refreshData)
                    {
                        InitPooly();
                    }*/
                    WindowSettings.pageWidthExtraSpace.target += 10;
                    break;
                case Page.FanYi:
                    WindowSettings.pageWidthExtraSpace.target = 0;
                    break;
                case Page.Use:
                    WindowSettings.pageWidthExtraSpace.target = 0;
                    break;
            }
        }

        void DrawPages()                                         // 画右边
        {
            InitPages();

            PageScrollPosition = QUI.BeginScrollView(PageScrollPosition);
            {
                QUI.BeginVertical(WindowSettings.CurrentPageContentWidth);
                {
                    switch (WindowSettings.currentPage)
                    {
                        case Page.Pooly: DrawPooly(); break;
                        case Page.FanYi: DrawFanYi(); break;
                        case Page.Use: DrawUse(); break;
                    }
                    QUI.FlexibleSpace();
                }
                QUI.EndVertical();
                QUI.Space(16);
            }
            QUI.EndScrollView();

            if (PreviousPage != WindowSettings.currentPage || refreshData)
            {
                PreviousPage = WindowSettings.currentPage;
                refreshData = false;
            }
        }

        #region 私有

        private readonly ZuHeTool m_Tools =new ZuHeTool(150);

        #region 

        public static Tools_EZ Instance;

        GUIStyle _pageHeaderTitleStyle;
        GUIStyle PageHeaderTitleStyle
        {
            get
            {
                if(_pageHeaderTitleStyle == null)
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

        GUIStyle _pageHeaderSubtitleStyle;
        GUIStyle PageHeaderSubtitleStyle
        {
            get
            {
                if(_pageHeaderSubtitleStyle == null)
                {
                    _pageHeaderSubtitleStyle = new GUIStyle(GUI.skin.label)
                    {
//                        font = QResources.GetFont(Sansation.Light),
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

        public static bool Selected = false;

        public enum Page
        {
            Pooly,
            FanYi,
            Use,
        }

        public static Page PreviousPage = Page.Pooly;
        public static bool refreshData = true;
        private static Vector2 PageScrollPosition = Vector2.zero;
        private static Vector2 PageLastScrollPosition = Vector2.zero;
        int inspectorUpdateFrame = 0;
        public static ControlPanelWindowSettings WindowSettings
        {
            get
            {
                return ControlPanelWindowSettings.Instance;
            }
        }

        private string SearchPattern = string.Empty;
        private static AnimBool SearchPatternAnimBool = new AnimBool(false);

        private float tempFloat;
        private string tempLabel = string.Empty;
        private Rect tempRect;

        private static PoolySettings _poolySettings;
        public static PoolySettings PoolySettings
        {
            get
            {
                if (_poolySettings == null)
                {
                    _poolySettings = Q.GetResource<PoolySettings>(EZT.RESOURCES_PATH_POOLY_SETTINGS, "PoolySettings");
                    if (_poolySettings == null)
                    {
                        _poolySettings = Q.CreateAsset<PoolySettings>(EZT.RELATIVE_PATH_POOLY_SETTINGS, "PoolySettings");
                    }
                }
                return _poolySettings;
            }
        }

        private static PoolyStatistics _poolyStatistics;
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

        private static Pooly.Pooly _pooly;
        public static Pooly.Pooly Pooly
        {
            get
            {
                if (_pooly == null)
                {
                    _pooly = FindObjectOfType<Pooly.Pooly>();
                }
                return _pooly;
            }
        }

        private static PoolyExtension _poolyExtension;
        public static PoolyExtension PoolyExtension
        {
            get
            {
                if (_poolyExtension == null)
                {
                    _poolyExtension = FindObjectOfType<PoolyExtension>();
                }
                return _poolyExtension;
            }
        }

        AnimBool editStats;

        GUIStyle graphNumberStyle, itemDetailsStyle, miniTitleStyle, miniSubtitleStyle;

        QLabel poolyQLabel;
        GUIContent poolyTempContent;
        Vector2 poolyTempContentSize;


        #endregion

        void ResetPageView()
        {
            PageScrollPosition = Vector2.zero; //reset scroll
            PageLastScrollPosition = PageScrollPosition;

            SearchPattern = ""; //reset search pattern
            SearchPatternAnimBool.value = false; //reset ui for search pattern
        }

        private void SetupWindow()
        {
            titleContent = new GUIContent("对象池");
            WindowSettings.sidebarIsExpanded.speed = 2;
            WindowSettings.sidebarIsExpanded.valueChanged.RemoveAllListeners();
            WindowSettings.sidebarIsExpanded.valueChanged.AddListener(Repaint);
            WindowSettings.sidebarIsExpanded.valueChanged.AddListener(UpdateWindowSize);

            WindowSettings.pageWidthExtraSpace.valueChanged.RemoveAllListeners();
            WindowSettings.pageWidthExtraSpace.valueChanged.AddListener(Repaint);
            WindowSettings.pageWidthExtraSpace.valueChanged.AddListener(UpdateWindowSize);

            UpdateWindowSize();
            CenterWindow();
        }

        private void UpdateWindowSize()
        {
            minSize = new Vector2(WindowSettings.windowMinimumWidth, WindowSettings.windowMinimumHeight);
            maxSize = new Vector2(minSize.x, Screen.currentResolution.height);
        }


        void OnEnable()
        {
            InitPooly();
            autoRepaintOnSceneChange = true;
            PreviousPage = Page.Pooly;
            InitPages();
        }
        void OnDisable()
        {
            switch(WindowSettings.currentPage)
            {
                case Page.Pooly:
                    PoolyOnDisable();
                    break;
            }
            QUI.SetDirty(WindowSettings);
            AssetDatabase.SaveAssets();
        }

        void OnFocus()
        {
            switch(WindowSettings.currentPage)
            {
                case Page.Pooly:
                    PoolyOnFocus();
                    break;
            }
        }
        void OnLostFocus()
        {
            switch(WindowSettings.currentPage)
            {
                case Page.Pooly:
                    PoolyOnLostFocus();
                    break;
            }
            QUI.SetDirty(WindowSettings);
            AssetDatabase.SaveAssets();
        }

        void OnInspectorUpdate()
        {
            if(inspectorUpdateFrame % 10 == 0) //once a second (every 10th frame)
            {
                Repaint(); //force the window to repaint
            }

            inspectorUpdateFrame++; //track what frame we're on, so we can call code less often
        }

        void OnGUI()
        {
            GUI.skin = LoadRes.ResourcesSkin;
            UpdateWindowSize();

            DrawBackground();

            QUI.BeginHorizontal(position.width);
            {
                DrawSideBar();
                QUI.Space(WindowSettings.pageShadowWidth);
                DrawPages();
            }
            QUI.EndHorizontal();

            if(Event.current.type != EventType.Layout)
            {
                if(PageScrollPosition != PageLastScrollPosition) //if the user has scrolled, deselect - this is because control IDs within carousel will change when scrolled so we'd end up with the wrong box selected.
                {
                    GUI.FocusControl(""); //deselect
                    PageLastScrollPosition = PageScrollPosition;
                }
            }

            SearchPatternAnimBool.target = !SearchPattern.IsNullOrEmpty();

            Repaint();
        }

        void DrawBackground()
        {
            tempRect = new Rect(0, 0, position.width, position.height);
            QUI.DrawTexture(new Rect(tempRect.x, tempRect.y, WindowSettings.SidebarCurrentWidth, tempRect.height), QResources.backgroundSidebar.texture);
            tempRect.x += WindowSettings.SidebarCurrentWidth;
            QUI.DrawTexture(new Rect(tempRect.x, tempRect.y, WindowSettings.pageShadowWidth, tempRect.height), QResources.backgroundContentShadowLeft.texture);
            tempRect.x += WindowSettings.pageShadowWidth;
            QUI.DrawTexture(new Rect(tempRect.x, tempRect.y, WindowSettings.pageShadowWidth + WindowSettings.CurrentPageContentWidth + WindowSettings.scrollbarSize, tempRect.height), QResources.backgroundContent.texture);
            //tempRect.x += Settings.CurrentPageContentWidth;
            //QUI.DrawTexture(new Rect(tempRect.x, tempRect.y, Settings.scrollbarSize, tempRect.height), QResources.backgroundContent.texture);
        }

        void DrawSideBar()
        {
            QUI.BeginVertical(WindowSettings.SidebarCurrentWidth);
            {
                // 画 Logo
                if (WindowSettings.sidebarIsExpanded.faded <= 0.1f)
                {
                    QUI.DrawTexture(EZResources.sidebarLogo10.texture, WindowSettings.sidebarExpandedWidth,
                        WindowSettings.sidebarLogoHeight);
                }
                else
                {
                    QUI.DrawTexture(EZResources.sidebarLogo0.texture, WindowSettings.sidebarExpandedWidth, WindowSettings.sidebarLogoHeight);
                }

                // 画缩放按钮
                if (QUI.Button("", EZStyles.GetStyle(WindowSettings.sidebarIsExpanded.faded < 0.9f ? EZStyles.General.SideButtonExpandSideBar : EZStyles.General.SideButtonCollapseSideBar), WindowSettings.SidebarCurrentWidth, WindowSettings.sidebarButtonHeight))
                {
                    WindowSettings.sidebarIsExpanded.target = !WindowSettings.sidebarIsExpanded.target;
                }
                QUI.Space(WindowSettings.sidebarVerticalSpacing);
                DrawRight();
            }
            QUI.EndVertical();
        }


        void GeneratePoolyInfoMessages()
        {
            if (infoMessage == null)
            {
                infoMessage = new Dictionary<string, InfoMessage>();
            }
            if (!infoMessage.ContainsKey("PoolyNoStatistics"))
            {
                infoMessage.Add("PoolyNoStatistics", new InfoMessage() { title = "没有 统计 注册进来", message = "至少输入运行一次 和 产生一些东西", show = new AnimBool(true), type = InfoMessageType.Info });
            }
            if (!infoMessage.ContainsKey("PoolyEmptyPool"))
            {
                infoMessage.Add("PoolyEmptyPool", new InfoMessage() { title = "空对象池...", message = "", show = new AnimBool(true), type = InfoMessageType.Info });
            }
            if (!infoMessage.ContainsKey("PoolyEmptyCategory"))
            {
                infoMessage.Add("PoolyEmptyCategory", new InfoMessage() { title = "Empty category...", message = "", show = new AnimBool(true), type = InfoMessageType.Info });
            }
            if (!infoMessage.ContainsKey("PoolyEmptyItem"))
            {
                infoMessage.Add("PoolyEmptyItem", new InfoMessage() { title = "No statistics have been registered for this prefab...", message = "", show = new AnimBool(true), type = InfoMessageType.Info });
            }
        }

        void CreateCustomStylesForPooly()
        {
            if (Event.current == null || Event.current.type == EventType.Layout)
            {
                return;
            }
            graphNumberStyle = new GUIStyle(QStyles.GetStyle(Style.Text.Small))
            {
                normal = { textColor = QUI.IsProSkin ? QColors.UnityLight.Color : QColors.UnityDark.Color },
                alignment = TextAnchor.MiddleCenter
            };

            itemDetailsStyle = new GUIStyle(QStyles.GetStyle(Style.Text.Normal))
            {
                normal = { textColor = QUI.IsProSkin ? QColors.UnityLight.Color : QColors.UnityDark.Color },
                alignment = TextAnchor.MiddleLeft,
                fontSize = 18
            };

            miniTitleStyle = new GUIStyle(QStyles.GetStyle(Style.Text.Subtitle))
            {
                normal = { textColor = QUI.IsProSkin ? QColors.UnityLight.Color : QColors.UnityDark.Color },
                alignment = TextAnchor.MiddleLeft,
                fontSize = 10
            };

            miniSubtitleStyle = new GUIStyle(QStyles.GetStyle(Style.Text.Subtitle))
            {
                normal = { textColor = QUI.IsProSkin ? QColors.UnityLight.Color : QColors.UnityDark.Color },
                alignment = TextAnchor.MiddleLeft,
                fontSize = 7
            };
        }

        void InitPooly()
        {
            CreateCustomStylesForPooly();
            GeneratePoolyInfoMessages();

            editStats = new AnimBool(false, Repaint);
            poolyTempContent = new GUIContent();
            poolyTempContentSize = Vector2.zero;
        }

        void PoolyOnDisable()
        {

        }
        void PoolyOnFocus()
        {

        }
        void PoolyOnLostFocus()
        {

        }

        void DrawPoolyAddRemoveButtons(float width)
        {
            QUI.BeginHorizontal(width);
            {
                QUI.FlexibleSpace();
                DrawPoolyTabButtonAddPooly((width - 8) / 2, 20);
                DrawPoolyTabButtonAddPoolyExtension((width - 8) / 2, 20);
                QUI.FlexibleSpace();
            }
            QUI.EndHorizontal();
        }
        void DrawPoolyTabButtonAddPooly(float buttonWidth, float buttonHeight)
        {
            if (Pooly == null)
            {
                if (QUI.SlicedButton("将 Pooly 添加到场景", QColors.Color.Green, buttonWidth, buttonHeight))
                {
                    Undo.RegisterCreatedObjectUndo(new GameObject("Pooly", typeof(Pooly.Pooly)), "AddPoolyToScene");
                    Selection.activeObject = Pooly.gameObject;
                }
            }
            else
            {
                if (QUI.SlicedButton("移除 Pooly ", QColors.Color.Red, buttonWidth, buttonHeight))
                {
                    if (QUI.DisplayDialog("移除 Pooly",
                                                   "确定要删除附加了 ”Pooly“ 的 GameObject 吗？" +
                                                   "\n\n\n" +
                                                   "您将失去在 inspector 中设置的所有参考和值",
                                                   "确定",
                                                   "取消"))
                    {
                        Undo.DestroyObjectImmediate(Pooly.gameObject);
                    }
                }
            }
        }
        void DrawPoolyTabButtonAddPoolyExtension(float buttonWidth, float buttonHeight)
        {
            if (PoolyExtension == null)
            {
                if (QUI.SlicedButton("将 PoolyExtension 添加到场景", QColors.Color.Blue, buttonWidth, buttonHeight))
                {
                    Undo.RegisterCreatedObjectUndo(new GameObject("PoolyExtension", typeof(PoolyExtension)), "AddPoolyExtensionToScene");
                    Selection.activeObject = PoolyExtension.gameObject;
                }
            }
            else
            {
                if (QUI.SlicedButton("移除 PoolyExtension", QColors.Color.Red, buttonWidth, buttonHeight))
                {
                    if (QUI.DisplayDialog("移除 PoolyExtension",
                                                   "确定要删除附加了”PoolyExtension“的GameObject吗？" +
                                                   "\n\n\n" +
                                                   "您将失去在 inspector 中设置的所有参考和值",
                                                   "确定",
                                                   "取消"))
                    {
                        Undo.DestroyObjectImmediate(PoolyExtension.gameObject);
                    }
                }
            }
        }

        void DrawPoolyStatistics(float width)
        {
            DrawPoolyStatisticsOptions(width);  //Draw Options
            QUI.Space(4);
            if (graphNumberStyle == null || itemDetailsStyle == null || miniTitleStyle == null || miniSubtitleStyle == null)
            {
                CreateCustomStylesForPooly();
                return;
            }
            DrawPoolyStatisticsDatabase(width); //Draw Database
        }

        void DrawPoolyStatisticsOptions(float width)
        {
            QUI.BeginHorizontal(width);
            {
                QUI.Space(8);
                QUI.BeginChangeCheck();
                PoolySettings.enableStatistics = QUI.Toggle(PoolySettings.enableStatistics);

                // 是否启用启用统计，启用了就变大点
                if (QUI.EndChangeCheck())
                {
                    QUI.SetDirty(PoolySettings);
                    QUI.SetDirty(WindowSettings);
                    AssetDatabase.SaveAssets();
                    WindowSettings.pageWidthExtraSpace.target = Ez.Pooly.Pooly.PoolySettings.enableStatistics ? Ez.Pooly.Statistics.PoolyStatistics.Instance.poolyWidth : 0;
                }
                QUI.Space(2);
                poolyQLabel.text = "启用 统计".AddGreen();
                poolyQLabel.style = Style.Text.Normal;
                QUI.Label(poolyQLabel.text, Style.Text.Normal, poolyQLabel.x, 12);
                QUI.FlexibleSpace();

                if (PoolySettings.enableStatistics)
                {
                    if (QUI.GhostButton("编辑 统计", QColors.Color.Orange, 80, 20, editStats.target))
                    {
                        editStats.target = !editStats.target;
                    }
                    if (editStats.faded > 0.05f)
                    {
                        if (QUI.GhostButton("清除所有统计", QColors.Color.Orange, PS.databaseClearStatisticsButtonWidth * editStats.faded, 20))
                        {
                            if (QUI.DisplayDialog("清除所有统计", "你确定要清除所有记录的统计数据吗？\n\n操作无法撤销！", "Yes", "No"))
                            {

                                if (PS.pools == null) { PS.pools = new List<PoolyStatistics.StatisticsPool>(); }
                                if (PS.pools.Count == 0) { return; }
                                for (int poolIndex = 0; poolIndex < PS.pools.Count; poolIndex++) { PS.pools[poolIndex].ClearStatistics(); }
                                QUI.SetDirty(PS);
                                AssetDatabase.SaveAssets();
                            }
                        }
                        if (QUI.GhostButton("删除所有", QColors.Color.Orange, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                        {
                            if (QUI.DisplayDialog("删除所有统计", "你确定要删除统计数据库中的所有数据吗？\n\n操作无法撤销！", "Yes", "No"))
                            {
                                if (PS.pools == null) { PS.pools = new List<PoolyStatistics.StatisticsPool>(); }
                                if (PS.pools.Count == 0) { return; }
                                PS.pools.Clear();
                                QUI.SetDirty(PS);
                                AssetDatabase.SaveAssets();
                            }
                        }
                    }
                }
            }
            QUI.EndHorizontal();

            if (!PoolySettings.enableStatistics)
            {
                QUI.Space((position.height - WindowSettings.pageHeaderHeight - 200) / 2);
                QUI.BeginHorizontal(width, 115);
                {
                    QUI.Space((width - 300) / 2);
                    QUI.DrawTexture(EZResources.imagePoolyStatisticsAreDisabled.texture);
                    QUI.Space((width - 300) / 2);
                }
                QUI.EndHorizontal();
            }
        }

        void DrawPoolyStatisticsDatabase(float width)
        {
            if (!PoolySettings.enableStatistics) { return; }

            if (PS.pools == null) { PS.pools = new List<PoolyStatistics.StatisticsPool>(); }

            if (PS.pools.Count == 0)
            {
                QUI.BeginHorizontal(width);
                {
                    QUI.Space(8);
                    DrawInfoMessage("PoolyNoStatistics", width - 8);
                }
                QUI.EndHorizontal();
                return;
            }

            for (int poolIndex = 0; poolIndex < PS.pools.Count; poolIndex++)
            {
                DrawPoolyStatisticsDatabasePool(PS.pools[poolIndex], width);
                QUI.Space(PS.databaseLineVerticalSpacing * 2);
            }
        }
        void DrawPoolyStatisticsDatabasePool(PoolyStatistics.StatisticsPool pool, float width)
        {
            QUI.BeginHorizontal(width);
            {
                if (QUI.GhostBar((pool.poolType == PoolyStatistics.PoolType.MainPool ? "MAIN POOL" : "POOL EXTENSION") + "    /    scene: " + pool.sceneName,
                                 pool.poolType == PoolyStatistics.PoolType.MainPool ? QColors.Color.Green : QColors.Color.Blue,
                                 pool.isExpanded,
                                 (width - (PS.databaseClearStatisticsButtonWidth + PS.databaseDeleteButtonWidth) * editStats.faded),
                                 24))
                {
                    pool.isExpanded.target = !pool.isExpanded.target;
                    if (!pool.isExpanded.target)
                    {
                        pool.ClosePool();
                        QUI.SetDirty(PS);
                        AssetDatabase.SaveAssets();
                    }
                }
                if (editStats.target)
                {

                    if (QUI.GhostButton("清除池统计信息", pool.poolType == PoolyStatistics.PoolType.MainPool ? QColors.Color.Green : QColors.Color.Blue, PS.databaseClearStatisticsButtonWidth * editStats.faded, 24, pool.isExpanded.value))
                    {
                        if (QUI.DisplayDialog("清除池统计信息", "您确定要清除此池的所有记录统计信息吗？ (" + (pool.poolType == PoolyStatistics.PoolType.MainPool ? "MAIN POOL" : "POOL EXTENSION") + " / scene: " + pool.sceneName + ")?\n\nOperation cannot be undone!", "Yes", "No"))
                        {
                            pool.ClearStatistics();
                            QUI.SetDirty(PS);
                            AssetDatabase.SaveAssets();
                        }
                    }
                    if (QUI.GhostButton("删除池", pool.poolType == PoolyStatistics.PoolType.MainPool ? QColors.Color.Green : QColors.Color.Blue, PS.databaseDeleteButtonWidth * editStats.faded, 24, pool.isExpanded.value))
                    {
                        if (QUI.DisplayDialog("删除池统计信息", "您确定要删除此池吗？ (" + (pool.poolType == PoolyStatistics.PoolType.MainPool ? "MAIN POOL" : "POOL EXTENSION") + " / scene: " + pool.sceneName + ") from the statistics database?\n\nOperation cannot be undone!", "Yes", "No"))
                        {
                            PS.DeletePool(pool);
                            QUI.SetDirty(PS);
                            AssetDatabase.SaveAssets();
                        }

                    }
                }
                QUI.FlexibleSpace();
            }
            QUI.EndHorizontal();

            if (QUI.BeginFadeGroup(pool.isExpanded.faded))
            {
                QUI.BeginVertical(width);
                {
                    if (pool.categories == null || pool.categories.Count == 0)
                    {
                        DrawInfoMessage("PoolyEmptyPool", width);
                    }
                    else
                    {
                        for (int categoryIndex = 0; categoryIndex < pool.categories.Count; categoryIndex++)
                        {
                            QUI.Space(PS.databaseLineVerticalSpacing);
                            QUI.BeginHorizontal(width);
                            {
                                QUI.Space(PS.databaseLineHorizontalIndent * pool.isExpanded.faded);
                                DrawPoolyStatisticsDatabasePoolCategory(pool, pool.categories[categoryIndex], width - PS.databaseLineHorizontalIndent);
                            }
                            QUI.EndHorizontal();
                        }
                    }
                }
                QUI.EndVertical();
            }
            QUI.EndFadeGroup();
        }
        void DrawPoolyStatisticsDatabasePoolCategory(PoolyStatistics.StatisticsPool pool, PoolyStatistics.StatisticsPoolCategory category, float width)
        {
            QUI.BeginVertical(width);
            {
                QUI.BeginHorizontal(width);
                {
                    if (QUI.GhostBar(category.categoryName,
                                    QColors.Color.Gray,
                                    category.isExpanded,
                                    width - (PS.databaseClearStatisticsButtonWidth + PS.databaseDeleteButtonWidth) * editStats.faded,
                                    20))
                    {
                        category.isExpanded.target = !category.isExpanded.target;
                        if (!category.isExpanded.target)
                        {
                            category.CloseCategory();
                            QUI.SetDirty(PS);
                            AssetDatabase.SaveAssets();
                        }
                    }

                    if (category.items != null && category.items.Count > 0)
                    {
                        QUI.Space(-60);
                        QUI.BeginHorizontal(60, 20);
                        {
                            QUI.FlexibleSpace();

                            category.UpdateMessageFlags();

                            if (category.hasInfoMessage)
                            {
                                QUI.Space(-8);
                                QUI.BeginVertical(16, 20);
                                {
                                    QUI.FlexibleSpace();
                                    QUI.Space(2);
                                    QUI.Label(QResources.iconInfo.texture, 16, 16);
                                    QUI.FlexibleSpace();
                                }
                                QUI.EndVertical();
                            }


                            if (category.hasWarningMessage)
                            {
                                QUI.Space(-8);
                                QUI.BeginVertical(16, 20);
                                {
                                    QUI.FlexibleSpace();
                                    QUI.Space(2);
                                    QUI.Label(QResources.iconWarning.texture, 16, 16);
                                    QUI.FlexibleSpace();
                                }
                                QUI.EndVertical();
                            }

                            if (category.hasErrorMessage)
                            {
                                QUI.Space(-8);
                                QUI.BeginVertical(16, 20);
                                {
                                    QUI.FlexibleSpace();
                                    QUI.Space(2);
                                    QUI.Label(QResources.iconError.texture, 16, 16);
                                    QUI.FlexibleSpace();
                                }
                                QUI.EndVertical();
                            }
                        }
                        QUI.EndHorizontal();
                    }

                    if (editStats.target)
                    {
                        if (QUI.GhostButton("清除类别统计", QColors.Color.Gray, PS.databaseClearStatisticsButtonWidth * editStats.faded, 20, category.isExpanded.value))
                        {
                            if (QUI.DisplayDialog("清除类别统计", "您确定要清除此类别的所有记录统计信息吗？(" + category.categoryName + ")?\n\n操作无法撤消！", "Yes", "No"))
                            {
                                category.ClearStatistics();
                                QUI.SetDirty(PS);
                                AssetDatabase.SaveAssets();
                            }
                        }
                        if (QUI.GhostButton("删除类别", QColors.Color.Gray, PS.databaseDeleteButtonWidth * editStats.faded, 20, category.isExpanded.value))
                        {
                            if (QUI.DisplayDialog("删除类别统计", "您确定要删除此类别吗？ (" + category.categoryName + ") 来自统计数据库?\n\n操作无法撤消！", "Yes", "No"))
                            {
                                pool.DeleteCategory(category);
                                QUI.SetDirty(PS);
                                AssetDatabase.SaveAssets();
                            }
                        }
                    }
                    QUI.FlexibleSpace();
                }
                QUI.EndHorizontal();

                if (QUI.BeginFadeGroup(category.isExpanded.faded))
                {
                    QUI.BeginVertical(width);
                    {
                        if (category.items == null || category.items.Count == 0)
                        {
                            DrawInfoMessage("PoolyEmptyCategory", width);
                        }
                        else
                        {
                            QUI.Space(PS.databaseLineVerticalSpacing * 2);
                            for (int itemIndex = 0; itemIndex < category.items.Count; itemIndex++)
                            {
                                QUI.BeginHorizontal(width);
                                {
                                    QUI.Space(PS.databaseLineHorizontalIndent * category.isExpanded.faded);
                                    DrawPoolyStatisticsDatabasePoolCategoryItem(category, category.items[itemIndex], width - PS.databaseLineHorizontalIndent);
                                }
                                QUI.EndHorizontal();
                                QUI.Space(PS.databaseLineVerticalSpacing / 4);
                            }
                        }
                    }
                    QUI.EndVertical();
                }
                QUI.EndFadeGroup();
            }
            QUI.EndVertical();
        }
        void DrawPoolyStatisticsDatabasePoolCategoryItem(PoolyStatistics.StatisticsPoolCategory category, PoolyStatistics.StatisticsItem item, float width)
        {

            QUI.BeginVertical(width);
            {
                QUI.Space(4 * item.warningsEnabled.faded * item.showInfoMessage.faded);

                float backgroundHeight = PS.databaseLineHeight + 6 + PS.graphHeight * item.showGraph.faded;
                if (item.warningsEnabled.target && item.showInfoMessage.target)
                {
                    backgroundHeight += 25 * item.warningsEnabled.faded * item.showInfoMessage.faded;
                }

                QUI.BeginHorizontal(width);
                {
                    QUI.Space(-2);
                    QUI.Box(QStyles.GetBackgroundStyle(Style.BackgroundType.Low, QColors.Color.Gray), width + 2, backgroundHeight); //Draw the ITEM line background
                }
                QUI.EndHorizontal();

                QUI.Space(-backgroundHeight);

                if (item.warningsEnabled.target)
                {
                    QUI.Space(-1);
                    QUI.BeginHorizontal(width);
                    {
                        QUI.Space(-3 * item.warningsEnabled.faded);
                        DrawPoolyStatisticsDatabasePoolCategoryItemInfoMessage(item, width + 3 * item.warningsEnabled.faded);
                        QUI.FlexibleSpace();
                    }
                    QUI.EndHorizontal();
                }

                QUI.Space(4 - (item.warningsEnabled.target ? 0 : 1));

                QUI.BeginHorizontal(width, PS.databaseLineHeight);
                {
                    QUI.Space(1);
                    if (QUI.GhostButton(item.prefabName, QColors.Color.Gray, PS.databaseItemButtonWidth, PS.databaseLineHeight))
                    {
                        if (item.prefab != null)
                        {
                            EditorGUIUtility.PingObject(item.prefab.gameObject);
                            Selection.activeGameObject = item.prefab.gameObject;
                        }
                    }

                    QUI.Space(PS.databaseElementHorizontalSpacing * 10 * category.isExpanded.faded);

                    if (item.data == null || item.data.Count == 0)
                    {
                        QUI.BeginVertical(width - PS.databaseItemButtonWidth - PS.databaseElementHorizontalSpacing * 3 - PS.databaseDeleteButtonWidth * editStats.faded, PS.databaseLineHeight);
                        {
                            QUI.FlexibleSpace();
                            QUI.Space(-4);
                            DrawInfoMessage("PoolyEmptyItem", width - PS.databaseItemButtonWidth - PS.databaseElementHorizontalSpacing * 3 - PS.databaseDeleteButtonWidth * editStats.faded);
                            QUI.FlexibleSpace();
                        }
                        QUI.EndVertical();
                        QUI.FlexibleSpace();
                        QUI.Space(-4);
                        if (editStats.target)
                        {
                            if (QUI.GhostButton("Delete Item", QColors.Color.Gray, (PS.databaseDeleteButtonWidth - 2) * editStats.faded, PS.databaseLineHeight))
                            {
                                if (QUI.DisplayDialog("Delete Item Statistics", "Are you sure you want to delete this item (" + item.prefabName + ") from the statistics database?\n\nOperation cannot be undone!", "Yes", "No"))
                                {
                                    category.DeleteItem(item);
                                    QUI.SetDirty(PS);
                                    AssetDatabase.SaveAssets();
                                }
                            }
                            QUI.Space(2);
                        }
                    }
                    else
                    {
                        QUI.BeginVertical(20, PS.databaseLineHeight);
                        {
                            QUI.FlexibleSpace();
                            if (QUI.ButtonGraph(item.showGraph.value))
                            {
                                item.showGraph.target = !item.showGraph.target;
                                QUI.SetDirty(PS);
                                AssetDatabase.SaveAssets();
                            }
                            QUI.FlexibleSpace();
                        }
                        QUI.EndVertical();

                        if (item.lowWarningThreshold < 0) { item.lowWarningThreshold = 0; }
                        if (item.highWarningThreshold > 100) { item.highWarningThreshold = 100; }
                        if (item.lowWarningThreshold > item.highWarningThreshold) { item.lowWarningThreshold = item.highWarningThreshold; }
                        else if (item.highWarningThreshold < item.lowWarningThreshold) { item.highWarningThreshold = item.lowWarningThreshold; }

                        QUI.BeginVertical(width - PS.databaseItemButtonWidth - PS.databaseElementHorizontalSpacing - 20 - PS.databaseElementHorizontalSpacing - 4, PS.databaseLineHeight);
                        {
                            QUI.Space(-4);
                            QUI.BeginHorizontal();
                            {
                                QUI.Space(PS.databaseElementHorizontalSpacing * 8 * category.isExpanded.faded);

                                poolyTempContent.text = "PRELOADED CLONE COUNT";
                                poolyTempContentSize = miniTitleStyle.CalcSize(poolyTempContent);
                                QUI.BeginVertical(poolyTempContentSize.x, PS.databaseLineHeight);
                                {
                                    QUI.FlexibleSpace();
                                    QUI.Label(poolyTempContent.text, miniTitleStyle, poolyTempContentSize.x, 14);
                                    QUI.Space(-7);
                                    QUI.Label("LAST RECORDED", miniSubtitleStyle, poolyTempContentSize.x, 12);
                                    QUI.FlexibleSpace();
                                }
                                QUI.EndVertical();

                                poolyTempContent.text = item.LastRecordedPreloadedClones.ToString();
                                poolyTempContentSize = itemDetailsStyle.CalcSize(poolyTempContent);
                                QUI.BeginVertical(poolyTempContentSize.x, PS.databaseLineHeight);
                                {
                                    QUI.FlexibleSpace();
                                    QUI.Space(1);
                                    QUI.Label(poolyTempContent, itemDetailsStyle, poolyTempContentSize.x, 18);
                                    QUI.FlexibleSpace();
                                }
                                QUI.EndVertical();

                                QUI.Space(PS.databaseElementHorizontalSpacing * 8 * category.isExpanded.faded);

                                poolyTempContent.text = "HIGHEST SPAWN COUNT";
                                poolyTempContentSize = miniTitleStyle.CalcSize(poolyTempContent);
                                QUI.BeginVertical(poolyTempContentSize.x, PS.databaseLineHeight);
                                {
                                    QUI.FlexibleSpace();
                                    QUI.Label(poolyTempContent.text, miniTitleStyle, poolyTempContentSize.x, 14);
                                    QUI.Space(-7);
                                    QUI.Label("EVER RECORDED", miniSubtitleStyle, poolyTempContentSize.x, 12);
                                    QUI.FlexibleSpace();
                                }
                                QUI.EndVertical();

                                poolyTempContent.text = item.alltimeMaxSpawnCount.ToString();
                                poolyTempContentSize = itemDetailsStyle.CalcSize(poolyTempContent);
                                QUI.BeginVertical(poolyTempContentSize.x, PS.databaseLineHeight);
                                {
                                    QUI.FlexibleSpace();
                                    QUI.Space(1);
                                    QUI.Label(poolyTempContent, itemDetailsStyle, poolyTempContentSize.x, 18);
                                    QUI.FlexibleSpace();
                                }
                                QUI.EndVertical();

                                QUI.FlexibleSpace();

                                if (editStats.faded < 0.95f)
                                {
                                    QUI.BeginVertical(72 * (1 - editStats.faded), PS.databaseLineHeight);
                                    {
                                        QUI.FlexibleSpace();
                                        QUI.Space(4);
                                        if (QUI.SlicedButton("WARNINGS", QColors.Color.Gray, 72 * (1 - editStats.faded), PS.databaseLineHeight, item.warningsEnabled.value))
                                        {
                                            item.warningsEnabled.target = !item.warningsEnabled.target;
                                        }
                                        QUI.FlexibleSpace();
                                    }
                                    QUI.EndVertical();

                                    if (item.warningsEnabled.faded > 0.05f)
                                    {
                                        QUI.Space(2 * (1 - editStats.faded) * item.warningsEnabled.faded);
                                        poolyTempContent.text = "LOW";
                                        poolyTempContentSize = miniTitleStyle.CalcSize(poolyTempContent);
                                        QUI.BeginVertical(poolyTempContentSize.x * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                        {
                                            QUI.FlexibleSpace();
                                            QUI.Space(3);
                                            QUI.SetGUIColor(QUI.IsProSkin ? QColors.Blue.Color : QColors.BlueLight.Color);
                                            QUI.Label(poolyTempContent.text, miniTitleStyle, poolyTempContentSize.x * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                            QUI.ResetColors();
                                            QUI.FlexibleSpace();
                                        }
                                        QUI.EndVertical();

                                        QUI.Space(-4);

                                        QUI.BeginVertical(30 * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                        {
                                            QUI.FlexibleSpace();
                                            QUI.Space(3);
                                            QUI.SetGUIBackgroundColor(QUI.IsProSkin ? QColors.Blue.Color : QColors.BlueLight.Color);
                                            item.lowWarningThreshold = EditorGUILayout.DelayedFloatField(item.lowWarningThreshold, GUILayout.Width(30 * (1 - editStats.faded) * item.warningsEnabled.faded));
                                            QUI.ResetColors();
                                            QUI.FlexibleSpace();
                                        }
                                        QUI.EndVertical();

                                        QUI.Space(-6);

                                        poolyTempContent.text = "%";
                                        poolyTempContentSize = miniTitleStyle.CalcSize(poolyTempContent);
                                        QUI.BeginVertical(poolyTempContentSize.x * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                        {
                                            QUI.FlexibleSpace();
                                            QUI.Space(3);
                                            QUI.SetGUIColor(QUI.IsProSkin ? QColors.Blue.Color : QColors.BlueLight.Color);
                                            QUI.Label(poolyTempContent.text, miniTitleStyle, poolyTempContentSize.x * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                            QUI.ResetColors();
                                            QUI.FlexibleSpace();
                                        }
                                        QUI.EndVertical();

                                        QUI.Space(2 * (1 - editStats.faded) * item.warningsEnabled.faded);

                                        poolyTempContent.text = "HIGH";
                                        poolyTempContentSize = miniTitleStyle.CalcSize(poolyTempContent);
                                        QUI.BeginVertical(poolyTempContentSize.x * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                        {
                                            QUI.FlexibleSpace();
                                            QUI.Space(3);
                                            QUI.SetGUIColor(QUI.IsProSkin ? QColors.Orange.Color : QColors.OrangeLight.Color);
                                            QUI.Label(poolyTempContent.text, miniTitleStyle, poolyTempContentSize.x * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                            QUI.ResetColors();
                                            QUI.FlexibleSpace();
                                        }
                                        QUI.EndVertical();

                                        QUI.Space(-4);

                                        QUI.BeginVertical(30 * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                        {
                                            QUI.FlexibleSpace();
                                            QUI.Space(3);
                                            QUI.SetGUIBackgroundColor(QUI.IsProSkin ? QColors.Orange.Color : QColors.OrangeLight.Color);
                                            item.highWarningThreshold = EditorGUILayout.DelayedFloatField(item.highWarningThreshold, GUILayout.Width(30 * (1 - editStats.faded) * item.warningsEnabled.faded));
                                            QUI.ResetColors();
                                            QUI.FlexibleSpace();
                                        }
                                        QUI.EndVertical();

                                        QUI.Space(-6);

                                        poolyTempContent.text = "%";
                                        poolyTempContentSize = miniTitleStyle.CalcSize(poolyTempContent);
                                        QUI.BeginVertical(poolyTempContentSize.x * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                        {
                                            QUI.FlexibleSpace();
                                            QUI.Space(3);
                                            QUI.SetGUIColor(QUI.IsProSkin ? QColors.Orange.Color : QColors.OrangeLight.Color);
                                            QUI.Label(poolyTempContent.text, miniTitleStyle, poolyTempContentSize.x * (1 - editStats.faded) * item.warningsEnabled.faded, PS.databaseLineHeight);
                                            QUI.ResetColors();
                                            QUI.FlexibleSpace();
                                        }
                                        QUI.EndVertical();
                                    }
                                    QUI.Space(12 + 3 * (1 - item.warningsEnabled.faded));
                                }
                                if (editStats.target)
                                {
                                    QUI.BeginVertical((PS.databaseClearStatisticsButtonWidth - 1) * editStats.faded, PS.databaseLineHeight);
                                    {
                                        QUI.FlexibleSpace();
                                        QUI.Space(4);
                                        if (QUI.GhostButton("清除 Item 统计", QColors.Color.Gray, (PS.databaseClearStatisticsButtonWidth - 1) * editStats.faded, PS.databaseLineHeight))
                                        {
                                            if (QUI.DisplayDialog("清除 Item 统计", "您确定要清除此项目的所有记录统计信息吗？ (" + item.prefabName + ")?\n\n操作无法撤消！", "Yes", "No"))
                                            {
                                                item.ClearStatistics();
                                                QUI.SetDirty(PS);
                                                AssetDatabase.SaveAssets();
                                            }
                                        }
                                        QUI.FlexibleSpace();
                                    }
                                    QUI.EndVertical();
                                    QUI.BeginVertical((PS.databaseDeleteButtonWidth - 2) * editStats.faded, PS.databaseLineHeight);
                                    {
                                        QUI.FlexibleSpace();
                                        QUI.Space(4);
                                        if (QUI.GhostButton("删除 Item", QColors.Color.Gray, (PS.databaseDeleteButtonWidth - 2) * editStats.faded, PS.databaseLineHeight))
                                        {
                                            if (QUI.DisplayDialog("删除 Item 统计", "你确定要删除这个 item 吗 (" + item.prefabName + ") 从这个统计数据库中 \n\n操作无法撤消！", "Yes", "No"))
                                            {
                                                category.DeleteItem(item);
                                                QUI.SetDirty(PS);
                                                AssetDatabase.SaveAssets();
                                            }
                                        }
                                        QUI.FlexibleSpace();
                                    }
                                    QUI.EndVertical();
                                }
                                QUI.Space(15 * editStats.faded);
                            }
                            QUI.EndHorizontal();
                        }
                        QUI.EndVertical();
                    }
                }
                QUI.EndHorizontal();

                if (item.data != null && item.data.Count > 0)
                {
                    QUI.Space(2);

                    if (QUI.BeginFadeGroup(item.showGraph.faded))
                    {
                        QUI.BeginVertical();
                        {
                            QUI.Space(2 + PS.graphHeight * item.showGraph.faded);
                            DrawPoolyStatisticsDatabasePoolCategoryItemGraph(item, width);
                            QUI.Space(8 * item.showGraph.faded);
                        }
                        QUI.EndVertical();
                    }
                    QUI.EndFadeGroup();
                }
                else
                {
                    item.showGraph.value = false;
                }

                QUI.Space(8 * item.warningsEnabled.faded * item.showInfoMessage.faded);
            }
            QUI.EndVertical();
        }

        void DrawPoolyStatisticsDatabasePoolCategoryItemGraph(PoolyStatistics.StatisticsItem item, float width)
        {
            Rect rect = new Rect(GUILayoutUtility.GetLastRect());
            if (PS.graphHeight <= 24) { PS.graphHeight = 24; }
            rect.width = width - 1;
            rect.height = PS.graphHeight * item.showGraph.faded;

            QUI.Box(rect, QStyles.GetBackgroundStyle(Style.BackgroundType.Low, QColors.Color.Gray)); //Draw Graph Background

            if (item.warningsEnabled.target)
            {
                QUI.DrawLine(new Rect(rect.x,
                                         rect.y + (PS.graphHeight - PS.graphHeight * (item.highWarningThreshold / 100)),
                                         rect.width,
                                         1),
                             QColors.Color.Orange); //Draw Graph LINE (orange) for MAX Warning Threshold

                QUI.SetGUIColor(QUI.IsProSkin ? QColors.Orange.Color : QColors.OrangeDark.Color);
                poolyTempContent.text = "HIGH: " + (int)(item.highWarningThreshold * item.LastRecordedPreloadedClones / 100) + " clones"; //Draw Graph LABEL for MAX Warning Threshold
                poolyTempContentSize = QStyles.CalcSize(poolyTempContent, Style.Text.Small);
                GUI.Label(new Rect(rect.x + width - poolyTempContentSize.x - 8,
                                   rect.y + 2 + (PS.graphHeight - PS.graphHeight * (item.highWarningThreshold / 100)),
                                   poolyTempContentSize.x, poolyTempContentSize.y),
                          poolyTempContent,
                          QStyles.GetStyle(Style.Text.Small));
                QUI.ResetColors();
            }

            rect.y += PS.graphHeight * item.showGraph.faded;

            if (item.warningsEnabled.target)
            {
                QUI.DrawLine(new Rect(rect.x,
                                      rect.y - (PS.graphHeight * (item.lowWarningThreshold / 100)) - 1,
                                      rect.width,
                                      1),
                             QColors.Color.Blue); //Draw Graph LINE (blue) for MIN Warning Threshold

                QUI.SetGUIColor(QUI.IsProSkin ? QColors.Blue.Color : QColors.BlueDark.Color);
                poolyTempContent.text = "LOW: " + (int)(item.lowWarningThreshold * item.LastRecordedPreloadedClones / 100) + " clones"; //Draw Graph LABEL for MIN Warning Threshold
                poolyTempContentSize = QStyles.CalcSize(poolyTempContent, Style.Text.Small);
                GUI.Label(new Rect(rect.x + width - poolyTempContentSize.x - 8,
                                   rect.y - 2 - poolyTempContentSize.y - (PS.graphHeight * (item.lowWarningThreshold / 100)),
                                   poolyTempContentSize.x,
                                   poolyTempContentSize.y),
                          poolyTempContent,
                          QStyles.GetStyle(Style.Text.Small));
                QUI.ResetColors();
            }


            rect.y -= PS.graphPointSize / 2;
            rect.x += PS.graphPointSize / 2 + 8;
            float maxHeight = rect.y;
            float minHeight = rect.y - (PS.graphHeight * item.showGraph.faded - PS.graphPointSize);

            float labelX;
            float labelY;

            if (item.data.Count >= 2)
            {
                for (int dataIndex = 0; dataIndex < item.data.Count; dataIndex++) //Draw Graph Lines
                {
                    if (dataIndex > 0)
                    {
                        QDrawing.DrawLine(new Vector2(rect.x + PS.graphPointToPointDistance * (dataIndex - 1),
                                                      Mathf.Clamp(rect.y - (item.data[dataIndex - 1].maxSpawnCount * (PS.graphHeight * item.showGraph.faded - PS.graphPointSize)) / item.data[item.data.Count - 1].preloadedClones, minHeight, maxHeight)), //formula is: x = (current maximumUsage * grahpHeight) / last preloadedClones
                                          new Vector2(rect.x + PS.graphPointToPointDistance * dataIndex,
                                                      Mathf.Clamp(rect.y - (item.data[dataIndex].maxSpawnCount * (PS.graphHeight * item.showGraph.faded - PS.graphPointSize)) / item.data[item.data.Count - 1].preloadedClones, minHeight, maxHeight)),
                                          QUI.IsProSkin ? QColors.UnityMild.Color : QColors.UnityMild.Color,
                                          PS.graphLineWidth,
                                          true);
                    }
                }
            }

            for (int dataIndex = 0; dataIndex < item.data.Count; dataIndex++) //Draw Graph Point Icons
            {
                float x = rect.x - PS.graphPointSize / 2 + PS.graphPointToPointDistance * dataIndex;
                float y = rect.y - PS.graphPointSize / 2 - (item.data[dataIndex].maxSpawnCount * (PS.graphHeight * item.showGraph.faded - PS.graphPointSize)) / item.data[item.data.Count - 1].preloadedClones;
                QUI.DrawTexture(new Rect(x + (PS.graphPointSize / 2) * editStats.faded,
                                         Mathf.Clamp(y, minHeight - PS.graphPointSize / 2, maxHeight - PS.graphPointSize / 2) + (PS.graphPointSize / 2) * editStats.faded,
                                         PS.graphPointSize * (1 - editStats.faded),
                                         PS.graphPointSize * (1 - editStats.faded)),
                                GetPoolyStatisticsGraphPointIcon(item, dataIndex));

                poolyTempContent.text = item.data[dataIndex].maxSpawnCount.ToString();
                poolyTempContentSize = QStyles.CalcSize(poolyTempContent, Style.Text.Small);

                labelX = x + PS.graphPointSize;
                labelY = y + PS.graphPointSize / 2;
                labelY = Mathf.Clamp(labelY, minHeight, maxHeight - PS.graphPointSize / 2);

                QUI.Label(new Rect(labelX,
                                   labelY,
                                   poolyTempContentSize.x,
                                   poolyTempContentSize.y),
                          item.data[dataIndex].maxSpawnCount.ToString(),
                          Style.Text.Small);

                if (editStats.faded > 0.1f)
                {
                    if (GUI.Button(new Rect(x + (PS.graphPointSize / 2) * (1 - editStats.faded),
                                         Mathf.Clamp(y, minHeight - PS.graphPointSize / 2, maxHeight - PS.graphPointSize / 2) + (PS.graphPointSize / 2) * (1 - editStats.faded),
                                         PS.graphPointSize * editStats.faded,
                                         PS.graphPointSize * editStats.faded),
                                  "",
                                  QStyles.GetStyle(Style.QuickButton.Cancel)))
                    {
                        item.data.RemoveAt(dataIndex);
                        QUI.ExitGUI();
                    }
                }
            }
        }

        Texture GetPoolyStatisticsGraphPointIcon(PoolyStatistics.StatisticsItem item, int dataIndex)
        {
            if (!item.warningsEnabled.value) return QResources.backgroundHighBlue.texture;
            if (item.data[dataIndex].maxSpawnCount < item.LastRecordedPreloadedClones * (item.lowWarningThreshold / 100)) { return QResources.iconInfo.normal; }        //Warning Threshold - UNDER LOW WARNING THRESHOLD
            if (item.data[dataIndex].maxSpawnCount >= item.LastRecordedPreloadedClones) { return QResources.iconError.texture; }                                        //EXCEEDED PRELOADED CLONE COUNT
            if (item.data[dataIndex].maxSpawnCount > item.LastRecordedPreloadedClones * (item.highWarningThreshold / 100)) { return QResources.iconWarning.normal; }    //Warning Threshold - OVER HIGH WARNING THRESHOLD
            return QResources.iconOk.texture;                                                                                                                          //Optimum Settings (No Warning)
        }
        void DrawPoolyStatisticsDatabasePoolCategoryItemInfoMessage(PoolyStatistics.StatisticsItem item, float width)
        {
            switch (item.GetItemStatus())
            {
                case PoolyStatistics.StatisticsItem.ItemStatus.OptimumSettings: //Optimum Settings (No Warning)
                    item.showInfoMessage.target = false;
                    break;
                case PoolyStatistics.StatisticsItem.ItemStatus.UnderLowThreshold: //Warning Threshold - UNDER MINIMUM WARNING THRESHOLD
                    item.showInfoMessage.target = true;
                    QUI.DrawInfoMessage(new InfoMessage()
                    {
                        title = "您可能会为这个预制体聚集太多克隆...（低警告阈值" + (int)(item.LastRecordedPreloadedClones * (item.lowWarningThreshold / 100)) + " clones / " + item.lowWarningThreshold + "% 阈值)",
                        show = item.showInfoMessage,
                        type = InfoMessageType.Info
                    }, width);
                    break;
                case PoolyStatistics.StatisticsItem.ItemStatus.OverHighThreshold: //Warning Threshold - OVER MAXIMUM WARNING THRESHOLD
                    item.showInfoMessage.target = true;
                    QUI.DrawInfoMessage(new InfoMessage() { title = "Consider increasing the preloaded clones count... (HIGH Warning Threshold: " + (int)(item.LastRecordedPreloadedClones * (item.highWarningThreshold / 100)) + " clones / " + item.highWarningThreshold + "% threshold)", show = item.showInfoMessage, type = InfoMessageType.Warning }, width);
                    break;
                case PoolyStatistics.StatisticsItem.ItemStatus.ExceededPreloadCount: //EXCEEDED PRELOADED CLONE COUNT
                    item.showInfoMessage.target = true;
                    QUI.DrawInfoMessage(new InfoMessage() { title = "Increase the preloaded clones count! The maximum usage has exceeded the set preload clone count (in the pool)!", show = item.showInfoMessage, type = InfoMessageType.Error }, width);
                    break;
                case PoolyStatistics.StatisticsItem.ItemStatus.NoStats:
                    item.showInfoMessage.target = false;
                    break;
            }
        }



        void DrawPageHeader(string title, QColor titleColor, string subtitle, QColor subtitleColor, QTexture iconQTexture)
        {
            QUI.Space(2);
            QUI.Box(QStyles.GetBackgroundStyle(Style.BackgroundType.Low, QColors.Color.Gray), WindowSettings.CurrentPageContentWidth + WindowSettings.pageShadowWidth, WindowSettings.pageHeaderHeight);
            QUI.Space(-WindowSettings.pageHeaderHeight + (WindowSettings.pageHeaderHeight - WindowSettings.pageHeaderHeight * 0.8f) / 2);
            QUI.BeginHorizontal(WindowSettings.CurrentPageContentWidth + WindowSettings.pageShadowWidth, WindowSettings.pageHeaderHeight * 0.8f);
            {
                QUI.Space((WindowSettings.pageHeaderHeight - WindowSettings.pageHeaderHeight * 0.8f));
                QUI.BeginVertical((WindowSettings.CurrentPageContentWidth + WindowSettings.pageShadowWidth) / 2, WindowSettings.pageHeaderHeight * 0.8f);
                {
                    QUI.FlexibleSpace();
                    if (!title.IsNullOrEmpty())
                    {
                        QUI.Space(-2);
                        QUI.SetGUIColor(titleColor.Color);
                        QUI.Label(title, PageHeaderTitleStyle, (WindowSettings.CurrentPageContentWidth + WindowSettings.pageShadowWidth) / 2, 26);
                        QUI.ResetColors();
                    }

                    if (!subtitle.IsNullOrEmpty())
                    {
                        QUI.Space(-2);
                        QUI.SetGUIColor(subtitleColor.Color);
                        QUI.Label(subtitle, PageHeaderSubtitleStyle, (WindowSettings.CurrentPageContentWidth + WindowSettings.pageShadowWidth) / 2, 18);
                        QUI.ResetColors();
                    }
                    QUI.FlexibleSpace();
                }
                QUI.EndVertical();
                QUI.FlexibleSpace();
                QUI.DrawTexture(iconQTexture.texture, WindowSettings.pageHeaderHeight * 0.8f, WindowSettings.pageHeaderHeight * 0.8f);
                QUI.Space((WindowSettings.pageHeaderHeight - WindowSettings.pageHeaderHeight * 0.8f) / 2);
            }
            QUI.EndHorizontal();
        }
        #endregion

  

        //————————————————————————————————————
        void DrawPooly()                                        // 对象池
        {
            poolyQLabel = new QLabel();

            DrawPageHeader("Pooly", QColors.Green, "（Pooly 是单例不销毁 Mono类）", QUI.IsProSkin ? QColors.UnityLight : QColors.UnityMild, EZResources.IconPooly);
            QUI.Space(6);
            DrawPoolyAddRemoveButtons(WindowSettings.CurrentPageContentWidth + WindowSettings.pageShadowWidth);
            QUI.Space(16);
            DrawPoolyStatistics(WindowSettings.CurrentPageContentWidth + WindowSettings.pageShadowWidth);
        }



        private void DrawFanYi()                               // 翻译文档
        {
            DrawPageHeader("ControlPanelWindow", QColors.Green, "（使用了 partial 分多个脚本合成一个）", QUI.IsProSkin ? QColors.UnityLight : QColors.UnityMild, EZResources.IconPooly);
            m_Tools.BiaoTi_B("使用过程：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("1.在开始场景拖个 "+"Pooly 组件(单例 不销毁 Mono类)".AddRed());
                m_Tools.Text_L("2.将所需的预制件添加到池中");
            });


            MyCreate.AddSpace(10);
            m_Tools.BiaoTi_B("Pooly 组件面板");
            MyCreate.Box(() =>
            {

            });

        }



        private void DrawUse()                                  // 使用
        {


        }











    }
}
