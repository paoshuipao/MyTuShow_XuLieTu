using PSPUtil.StaticUtil;

#if UNITY_EDITOR
namespace Sirenix.OdinInspector.Editor
{
    using UnityEditor;
    using UnityEngine;
    using Sirenix.Utilities.Editor;
    using Sirenix.Utilities;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// 用菜单树绘制一个编辑器窗口
    /// Draws an editor window with a menu tree.
    /// </summary>
    /// <example>
    /// <code>
    /// public class OdinMenuEditorWindowExample : OdinMenuEditorWindow
    /// {
    ///     [SerializeField, HideLabel]
    ///     private SomeData someData = new SomeData();
    /// 
    ///     protected override OdinMenuTree BuildMenuTree()
    ///     {
    ///         OdinMenuTree tree = new OdinMenuTree(supportsMultiSelect: true)
    ///         {
    ///             { "Home",                           this,                           EditorIcons.House       }, // draws the someDataField in this case.
    ///             { "ODIN Settings",                  null,                           EditorIcons.SettingsCog },
    ///             { "ODIN Settings/Color Palettes",   ColorPaletteManager.Instance,   EditorIcons.EyeDropper  },
    ///             { "ODIN Settings/AOT Generation",   AOTGenerationConfig.Instance,   EditorIcons.SmartPhone  },
    ///             { "Camera current",                 Camera.current                                          },
    ///             { "Some Class",                     this.someData                                           }
    ///         };
    /// 
    ///         tree.AddAllAssetsAtPath("More ODIN Settings", SirenixAssetPaths.OdinEditorConfigsPath, typeof(ScriptableObject), true)
    ///             .AddThumbnailIcons();
    /// 
    ///         tree.AddAssetAtPath("ODIN Getting Started", SirenixAssetPaths.SirenixPluginPath + "Getting Started With ODIN.asset");
    /// 
    ///         var customMenuItem = new OdinMenuItem(tree, "Menu Style", tree.DefaultMenuStyle);
    ///         tree.MenuItems.Insert(2, customMenuItem);
    /// 
    ///         tree.Add("Menu/Items/Are/Created/As/Needed", new GUIContent());
    ///         tree.Add("Menu/Items/Are/Created", new GUIContent("And can be overridden"));
    /// 
    ///         // As you can see, ODIN provides a few ways to quickly add editors / objects to your menu tree.
    ///         // The API also gives you full control over the selection, etc..
    ///         // Make sure to check out the API Documentation for OdinMenuEditorWindow, OdinMenuTree and OdinMenuItem for more information on what you can do!
    /// 
    ///         return tree;
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="OdinEditorWindow" />
    /// <seealso cref="OdinMenuTree" />
    /// <seealso cref="OdinMenuItem" />
    /// <seealso cref="OdinMenuStyle" />
    /// <seealso cref="OdinMenuTreeSelection" />
    /// <seealso cref="OdinMenuTreeExtensions" />
    /// <seealso cref="OdinMenuEditorWindow" />
    public abstract class OdinMenuEditorWindow : OdinEditorWindow
    {

        /// <summary>
        /// Gets the menu tree.
        /// </summary>
        public OdinMenuTree MenuTree                             // 获取菜单树
        {
            get { return this.menuTree; }
        }

        #region 私有

        [NonSerialized]
        private bool isDirty;

        [SerializeField, HideInInspector]
        private Vector2 menuScrollPos;

        [SerializeField, HideInInspector]
        private float menuWidth = 180;

        [NonSerialized]
        private OdinMenuTree menuTree;

        [NonSerialized]
        private object trySelectObject;

        [SerializeField, HideInInspector]
        private List<string> selectedItems = new List<string>();

        [SerializeField, HideInInspector]
        private bool resizableMenuWidth;

        private void ProjectWindowChanged()
        {
            // Menu trees are often build based on paths and names of assets.
            // If any of them changes then rebuild the menu-tree with the new names / instances / locations.
            this.isDirty = true;
        }

        private void OnSelectionChanged()
        {
            this.Repaint();
            GUIHelper.RemoveFocusControl();
            this.selectedItems = this.menuTree.Selection.Select(x => x.GetFullPath()).ToList();
            EditorUtility.SetDirty(this);
        }
        #endregion



        /// <summary>
        /// Builds the menu tree.
        /// </summary>
        protected abstract OdinMenuTree BuildMenuTree();

        /// <summary>
        /// Gets or sets the width of the menu.
        /// </summary>
        public virtual float MenuWidth
        {
            get { return this.menuWidth; }
            set { this.menuWidth = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the menu is resizable.
        /// </summary>
        public virtual bool ResizableMenuWidth
        {
            get { return this.resizableMenuWidth; }
            set { this.resizableMenuWidth = value; }
        }


        /// <summary>
        /// Forces the menu tree rebuild.
        /// </summary>
        protected void ForceMenuTreeRebuild()
        {
            this.menuTree = this.BuildMenuTree();

            if (this.selectedItems.Count == 0 && this.menuTree.Selection.Count == 0)
            {
                // Select first item if nothing was specified by the user in BuildMenuTree
                var firstMenu = this.menuTree.EnumerateTree().FirstOrDefault(x => x.ObjectInstance != null);
                if (firstMenu != null)
                {
                    firstMenu.Select();
                }
            }
            else if (this.menuTree.Selection.Count == 0 && this.selectedItems.Count > 0)
            {
                // Select whatever was selected before.
                foreach (var item in this.menuTree.EnumerateTree())
                {
                    if (this.selectedItems.Contains(item.GetFullPath()))
                    {
                        item.Select(true);
                    }
                }
            }

            this.menuTree.Selection.OnSelectionChanged += this.OnSelectionChanged;
        }

   

        /// <summary>
        /// Tries to select the menu item with the specified object.
        /// </summary>
        protected void TrySelectMenuItemWithObject(object obj)
        {
            this.trySelectObject = obj;
        }

        /// <summary>
        /// Draws the menu tree selection.
        /// </summary>
        protected override IEnumerable<object> GetTargets()
        {
            if (this.menuTree == null || this.menuTree.Selection.Count == 0)
            {
                return Enumerable.Empty<object>();
            }
            else
            {
                return this.menuTree.Selection
                    .Where(x => x != null && x.ObjectInstances != null)
                    .SelectMany(x => x.ObjectInstances);
            }
        }




        /// <summary>
        /// The method that draws the menu.
        /// </summary>
        protected virtual void DrawMenu()
        {
            if (this.menuTree == null)
            {
                return;
            }

            this.menuScrollPos = EditorGUILayout.BeginScrollView(this.menuScrollPos);
            this.menuTree.DrawMenuTree();
            EditorGUILayout.EndScrollView();
        }



        /// <summary>
        /// Draws the ODIN Editor Window.
        /// </summary>
        protected override void OnGUI()
        {

            if (Event.current.type == EventType.Layout)
            {
                if (this.menuTree == null || this.isDirty)
                {
                    this.ForceMenuTreeRebuild();

                    if (UnityEditorEventUtility.HasOnProjectChanged)
                    {
                        UnityEditorEventUtility.OnProjectChanged -= ProjectWindowChanged;
                        UnityEditorEventUtility.OnProjectChanged += ProjectWindowChanged;
                    }
                    else
                    {
#pragma warning disable 0618
                        EditorApplication.projectWindowChanged -= ProjectWindowChanged;
                        EditorApplication.projectWindowChanged += ProjectWindowChanged;
#pragma warning restore 0618
                    }

                    this.isDirty = false;
                }

                // Try select object.
                if (this.trySelectObject != null && this.menuTree != null)
                {
                    var menuItem = this.menuTree.EnumerateTree()
                        .FirstOrDefault(x => x.ObjectInstance == this.trySelectObject);

                    if (menuItem != null)
                    {
                        this.menuTree.Selection.Clear();
                        menuItem.Select();
                        this.trySelectObject = null;
                    }
                }
            }

            Rect menuBorderRect;
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical(GUILayoutOptions.Width(this.MenuWidth));
            {
                Rect rect = GUIHelper.GetCurrentLayoutRect();
                EditorGUI.DrawRect(rect, SirenixGUIStyles.MenuBackgroundColor);
                menuBorderRect = rect;
                menuBorderRect.xMin = rect.xMax - 4;
                menuBorderRect.xMax += 4;
                if (this.ResizableMenuWidth)
                {
                    EditorGUIUtility.AddCursorRect(menuBorderRect, MouseCursor.ResizeHorizontal);
                    this.MenuWidth += AllEditorGUI.SlideRect(menuBorderRect).x;
                }
                // 左边的菜单编辑在这里
                this.DrawMenu();

            }
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            {
                var rect = GUIHelper.GetCurrentLayoutRect();
                EditorGUI.DrawRect(rect, SirenixGUIStyles.DarkEditorBackground);
                base.OnGUI();

            }
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            EditorGUI.DrawRect(menuBorderRect.AlignCenter(1), SirenixGUIStyles.BorderColor);

            if (this.menuTree != null)
            {
                this.menuTree.HandleKeybaordMenuNavigation();

                // TODO: Handle scroll to selected menu items...
                // this.menuTree.Selection.Last() is the latest selected item.
            }
        }



        /// <summary>
        /// Called when the window is destroyed. Remember to call base.OnDestroy();
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (UnityEditorEventUtility.HasOnProjectChanged)
            {
                UnityEditorEventUtility.OnProjectChanged -= ProjectWindowChanged;
                UnityEditorEventUtility.OnProjectChanged -= ProjectWindowChanged;
            }
            else
            {
#pragma warning disable 0618
                EditorApplication.projectWindowChanged -= ProjectWindowChanged;
                EditorApplication.projectWindowChanged -= ProjectWindowChanged;
#pragma warning restore 0618
            }
        }


    }



}
#endif