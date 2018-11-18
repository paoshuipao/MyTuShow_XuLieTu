#if UNITY_EDITOR

using Sirenix.Utilities.Editor;
using Sirenix.Utilities;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;

namespace Sirenix.OdinInspector.Editor
{

    public class SirenixPreferencesWindow : OdinMenuEditorWindow
    {
        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(true)
            {
                { "General",                        GeneralDrawerConfig.Instance},
                { "Editor Types",                   InspectorConfig.Instance},
                { "Editor Only Mode",               EditorOnlyModeConfig.Instance},
                { "Persistent Context Cache",       PersistentContextCache.Instance},
                { "Color Palettes",                 ColorPaletteManager.Instance},
                { "Serialization",                  GlobalSerializationConfig.Instance},
                { "AOT Generation",                 AOTGenerationConfig.Instance},
//                { "Test",                 LearnStaticCS},
            };

            return tree;
        }



        /// <summary>
        /// Opens the ODIN inspector preferences window.
        /// </summary>
        [MenuItem("Tools/演示/Preferences", priority = 4)]
        public static void OpenSirenixPreferences()
        {
            var window = GetWindow<SirenixPreferencesWindow>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(900, 600);
        }


    }
}
#endif