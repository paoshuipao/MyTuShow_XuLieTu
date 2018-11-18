using QuickEditor;

namespace Ez
{
    public partial class EZResources
    {
        private static string _IMAGES;

        public static string IMAGES
        {
            get {
                if (string.IsNullOrEmpty(_IMAGES))
                {
                    _IMAGES = EZT.PATH + "/Shared/Editor/Images/";
                } return _IMAGES; }
        }

        private static string _CHUYIN;

        public static string CHUYIN
        {
            get {
                if (string.IsNullOrEmpty(_CHUYIN))
                {
                    _CHUYIN = IMAGES + "ChuYin/";
                } return _CHUYIN; }
        }

        private static string _EDITORHEADERS;

        public static string EDITORHEADERS
        {
            get { if(string.IsNullOrEmpty(_EDITORHEADERS)) { _EDITORHEADERS = IMAGES + "EditorHeaders/"; } return _EDITORHEADERS; }
        }

        private static string _GENERAL;
        public static string GENERAL { get { if(string.IsNullOrEmpty(_GENERAL)) { _GENERAL = IMAGES + "General/"; } return _GENERAL; } }

        private static string _ICONS;

        public static string ICONS
        {
            get
            {
                if(string.IsNullOrEmpty(_ICONS)) { _ICONS = IMAGES + "Icons/"; } return _ICONS;
            }
        }


        //——————————————————EditorHeaders 文件夹下——————————————————

        public static QTexture editorHeaderPoolyExtension = new QTexture(EDITORHEADERS, "editorHeaderPoolyExtension" + QResources.IsProSkinTag);
        public static QTexture editorHeaderPoolyDespawnerCollider = new QTexture(EDITORHEADERS, "editorHeaderPoolyDespawnerCollider" + QResources.IsProSkinTag);
        public static QTexture editorHeaderPoolyDespawnerCollider2D = new QTexture(EDITORHEADERS, "editorHeaderPoolyDespawnerCollider2D" + QResources.IsProSkinTag);
        public static QTexture editorHeaderPoolyDespawnerEffectPlayed = new QTexture(EDITORHEADERS, "editorHeaderPoolyDespawnerEffectPlayed" + QResources.IsProSkinTag);

        public static QTexture editorHeaderPoolyDespawnerSoundPlayed = new QTexture(EDITORHEADERS, "editorHeaderPoolyDespawnerSoundPlayed" + QResources.IsProSkinTag);

        public static QTexture editorHeaderPoolyDespawnerTime = new QTexture(EDITORHEADERS, "editorHeaderPoolyDespawnerTime" + QResources.IsProSkinTag);

        public static QTexture editorHeaderPoolyDespawnerTrigger = new QTexture(EDITORHEADERS, "editorHeaderPoolyDespawnerTrigger" + QResources.IsProSkinTag);
        public static QTexture editorHeaderPoolyDespawnerTrigger2D = new QTexture(EDITORHEADERS, "editorHeaderPoolyDespawnerTrigger2D" + QResources.IsProSkinTag);


        //——————————————————General 文件夹下——————————————————

        public static QTexture sidebarLogo0 = new QTexture(GENERAL, "sidebarLogo0");
        public static QTexture sidebarLogo10 = new QTexture(GENERAL, "sidebarLogo10");

        public static QTexture sideButtonCollapseSideBar = new QTexture(GENERAL, "sideButtonCollapseSideBar" + QResources.IsProSkinTag);
        public static QTexture sideButtonExpandSideBar = new QTexture(GENERAL, "sideButtonExpandSideBar" + QResources.IsProSkinTag);
        public static QTexture sideButtonControlPanel = new QTexture(GENERAL, "sideButtonControlPanel" + QResources.IsProSkinTag);
        public static QTexture sideButtonControlPanelSelected = new QTexture(GENERAL, "sideButtonControlPanel" + QResources.IsProSkinTag + "Selected");
        public static QTexture sideButtonDefineSymbols = new QTexture(GENERAL, "sideButtonDefineSymbols" + QResources.IsProSkinTag);
        public static QTexture sideButtonDefineSymbolsSelected = new QTexture(GENERAL, "sideButtonDefineSymbols" + QResources.IsProSkinTag + "Selected");
        public static QTexture sideButtonDataManager = new QTexture(GENERAL, "sideButtonDataManager" + QResources.IsProSkinTag);
        public static QTexture sideButtonDataManagerSelected = new QTexture(GENERAL, "sideButtonDataManager" + QResources.IsProSkinTag + "Selected");
        public static QTexture sideButtonDataBind = new QTexture(GENERAL, "sideButtonDataBind" + QResources.IsProSkinTag);
        public static QTexture sideButtonDataBindSelected = new QTexture(GENERAL, "sideButtonDataBind" + QResources.IsProSkinTag + "Selected");
        public static QTexture sideButtonPooly = new QTexture(GENERAL, "sideButtonPooly" + QResources.IsProSkinTag);
        public static QTexture sideButtonPoolySelected = new QTexture(GENERAL, "sideButtonPooly" + QResources.IsProSkinTag + "Selected");
        public static QTexture sideButtonAdsManager = new QTexture(GENERAL, "sideButtonAdsManager" + QResources.IsProSkinTag);
        public static QTexture sideButtonAdsManagerSelected = new QTexture(GENERAL, "sideButtonAdsManager" + QResources.IsProSkinTag + "Selected");
        public static QTexture sideButtonHelp = new QTexture(GENERAL, "sideButtonHelp" + QResources.IsProSkinTag);
        public static QTexture sideButtonHelpSelected = new QTexture(GENERAL, "sideButtonHelp" + QResources.IsProSkinTag + "Selected");
        public static QTexture sideButtonAbout = new QTexture(GENERAL, "sideButtonAbout" + QResources.IsProSkinTag);
        public static QTexture sideButtonAboutSelected = new QTexture(GENERAL, "sideButtonAbout" + QResources.IsProSkinTag + "Selected");

        public static QTexture sideButtonTwitter = new QTexture(GENERAL, "sideButtonTwitter" + QResources.IsProSkinTag);
        public static QTexture sideButtonFacebook = new QTexture(GENERAL, "sideButtonFacebook" + QResources.IsProSkinTag);
        public static QTexture sideButtonYoutube = new QTexture(GENERAL, "sideButtonYoutube" + QResources.IsProSkinTag);

        //——————————————————ICONS 文件夹下——————————————————
        public static QTexture IconPooly = new QTexture(ICONS, "IconPooly");
        public static QTexture imagePoolyStatisticsAreDisabled = new QTexture(ICONS, "imagePoolyStatisticsAreDisabled" + QResources.IsProSkinTag);


        //——————————————————ChuYin 文件夹下——————————————————

        public static QTexture ChuYin1 = new QTexture(CHUYIN, "ChuYin1");
        public static QTexture ChuYin2 = new QTexture(CHUYIN, "ChuYin2");
        public static QTexture ChuYin3 = new QTexture(CHUYIN, "ChuYin3");
        public static QTexture ChuYin4 = new QTexture(CHUYIN, "ChuYin4");
        public static QTexture ChuYin5 = new QTexture(CHUYIN, "ChuYin5");
        public static QTexture ChuYin6 = new QTexture(CHUYIN, "ChuYin6");
        public static QTexture ChuYin7 = new QTexture(CHUYIN, "ChuYin7");
        public static QTexture ChuYin8= new QTexture(CHUYIN, "ChuYin8");


    }
}
