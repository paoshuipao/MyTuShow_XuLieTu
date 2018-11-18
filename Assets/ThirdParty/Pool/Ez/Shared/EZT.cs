using System;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;

namespace Ez
{
    [Serializable]
    public partial class EZT
    {
        public const string RESOURCES_PATH_CONTROL_PANEL_WINDOW_SETTINGS = "EZT/Shared/Settings/";
        public const string RESOURCES_PATH_POOLY_SETTINGS = "EZT/Pooly/Settings/";
        public const string RESOURCES_PATH_POOLY_STATISTICS = "EZT/Pooly/Statistics/";

        private static string _EZ_PATH = "";
        public static string PATH
        {
            get
            {
                if(_EZ_PATH.IsNullOrEmpty())
                {
                    _EZ_PATH = MyAssetUtil.GetAssetPathInAssets("Ez");
                }
                return _EZ_PATH;
            }
        }

        public static string RELATIVE_PATH_CONTROL_PANEL_WINDOW_SETTINGS
        {
            get { return PATH + "/Shared/Editor/Resources/" + RESOURCES_PATH_CONTROL_PANEL_WINDOW_SETTINGS; }
        }


        public static string RELATIVE_PATH_POOLY_SETTINGS
        {
            get { return PATH + "/Pooly/Editor/Resources/" + RESOURCES_PATH_POOLY_SETTINGS; }
        }

        public static string RELATIVE_PATH_POOLY_STATISTICS
        {
            get { return PATH + "/Pooly/Editor/Resources/" + RESOURCES_PATH_POOLY_STATISTICS; }
        }


    }
}
