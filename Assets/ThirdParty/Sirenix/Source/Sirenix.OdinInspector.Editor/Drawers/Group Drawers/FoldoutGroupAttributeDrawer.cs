#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="FoldoutGroupAttributeDrawer.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Sirenix.OdinInspector.Editor.Drawers
{
    using System;
    using Utilities.Editor;
    using UnityEngine;

    /// <summary>
    /// Draws all properties grouped together with the <see cref="FoldoutGroupAttribute"/>
    /// </summary>
    /// <seealso cref="FoldoutGroupAttribute"/>
    [OdinDrawer]
    public class FoldoutGroupAttributeDrawer : OdinGroupDrawer<FoldoutGroupAttribute>
    {
        private class FoldoutGroupContext
        {
            public LocalPersistentContext<bool> IsVisible;
            public StringMemberHelper TitleHelper;
        }

        /// <summary>
        /// Draws the property.
        /// </summary>
        protected override void DrawPropertyGroupLayout(InspectorProperty property, FoldoutGroupAttribute attribute, GUIContent label)
        {
            var context = property.Context.Get<FoldoutGroupContext>(this, "FoldoutGroupContext", (FoldoutGroupContext)null);
            if (context.Value == null)
            {
                context.Value = new FoldoutGroupContext()
                {
                    IsVisible = property.Context.GetPersistent<bool>(this, "IsVisible", attribute.HasDefinedExpanded ? attribute.Expanded : AllEditorGUI.ExpandFoldoutByDefault),
                    TitleHelper = new StringMemberHelper(property.ParentType, attribute.GroupName)
                };
            }

            if (context.Value.TitleHelper.ErrorMessage != null)
            {
                AllEditorGUI.ErrorMessageBox(context.Value.TitleHelper.ErrorMessage);
            }

            AllEditorGUI.BeginBox();
            {
                AllEditorGUI.BeginBoxHeader();
                var content = GUIHelper.TempContent(context.Value.TitleHelper.GetString(property));
                var rect = GUILayoutUtility.GetRect(content, SirenixGUIStyles.Label);
                context.Value.IsVisible.Value = AllEditorGUI.Foldout(rect, context.Value.IsVisible.Value, content);
                AllEditorGUI.EndBoxHeader();

                if (AllEditorGUI.BeginFadeGroup(context, context.Value.IsVisible.Value))
                {
                    for (int i = 0; i < property.Children.Count; i++)
                    {
                        InspectorUtilities.DrawProperty(property.Children[i]);
                    }
                }

                AllEditorGUI.EndFadeGroup();
            }
            AllEditorGUI.EndBox();
        }
    }
}
#endif