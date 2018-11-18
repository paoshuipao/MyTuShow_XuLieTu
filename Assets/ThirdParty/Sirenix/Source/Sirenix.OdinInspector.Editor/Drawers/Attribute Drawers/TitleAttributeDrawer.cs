#if UNITY_EDITOR

using PSPUtil.StaticUtil;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;


namespace Sirenix.OdinInspector.Editor.Drawers
{
    /// <summary>
    /// Draws properties marked with <see cref="TitleAttribute"/>.
    /// </summary>
    /// <seealso cref="TitleAttribute"/>
    /// <seealso cref="TitleGroupAttribute"/>
    [OdinDrawer]
    [DrawerPriority(1, 0, 0)]
    public sealed class TitleAttributeDrawer : OdinAttributeDrawer<TitleAttribute>
    {
        private class TitleContext
        {
            public string ErrorMessage;
            public StringMemberHelper TitleHelper;
            public StringMemberHelper SubtitleHelper;
        }

        protected override void DrawPropertyLayout(InspectorProperty property, TitleAttribute attribute,GUIContent label)
        {
            var context = property.Context.Get<TitleContext>(this, "TitleContext", (TitleContext) null);

            if (context.Value == null)
            {
                context.Value = new TitleContext();
                context.Value.TitleHelper = new StringMemberHelper(property.ParentType, attribute.Title,
                    ref context.Value.ErrorMessage);
                context.Value.SubtitleHelper = new StringMemberHelper(property.ParentType, attribute.Subtitle,
                    ref context.Value.ErrorMessage);
            }

            // Don't draw added emtpy space for the first property.
            if (property != property.Tree.GetRootProperty(0))
            {
                EditorGUILayout.Space();
            }

            if (context.Value.ErrorMessage != null)
            {
                AllEditorGUI.ErrorMessageBox(context.Value.ErrorMessage);
            }
            else
            {
                AllEditorGUI.Title(
                    context.Value.TitleHelper.GetString(property),
                    context.Value.SubtitleHelper.GetString(property),
                    (TextAlignment) attribute.TitleAlignment,
                    attribute.HorizontalLine,
                    attribute.Bold, attribute.TextColor);
            }
            CallNextDrawer(property, label);

        }


    }


}
#endif