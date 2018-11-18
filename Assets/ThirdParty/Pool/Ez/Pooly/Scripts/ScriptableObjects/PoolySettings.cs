using System;
using PSPUtil.StaticUtil;
using UnityEngine;

namespace Ez.Pooly
{
    [Serializable]
    public class PoolySettings : ScriptableObject
    {
        public bool showSpawnerIcon = true;
        public bool showSpawnLocationsIcons = true;
        public bool alwaysShowIcons = true;
        public bool allowIconScaling = false;

        public bool showLabels = true;
        public int decimalPoins = 1;

        public bool showDottedLines = true;
        public Color dottedLinesColor = Orange;
        public float dottedLinesScreenSpaceSize = 4f;

        public bool showInfoMessages = true;

        public bool enableStatistics = false;

        public void ResetIconsSetting()
        {
            showSpawnerIcon = true;
            showSpawnLocationsIcons = true;
            alwaysShowIcons = true;
            allowIconScaling = false;
        }

        public void ResetLabelSettings()
        {
            showLabels = true;
            decimalPoins = 1;
        }

        public void ResetDottedLinesSettings()
        {
            dottedLinesColor = Orange;
            dottedLinesScreenSpaceSize = 4f;
        }

        public static Color Orange { get { return MyColor.GetColor(255, 147, 30); } }
    }
}
