#if UNITY_EDITOR
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;

namespace Sirenix.OdinInspector.Editor.Drawers
{
    /// <summary>
    /// Draws an enum in a horizontal button group instead of a dropdown.
    /// </summary>
    [OdinDrawer]
    public class EnumToggleButtonsAttributeDrawer<T> : OdinAttributeDrawer<EnumToggleButtonsAttribute, T>
    {
        /// <summary>
        /// Returns <c>true</c> if the drawer can draw the type.
        /// </summary>
        public override bool CanDrawTypeFilter(Type type)
        {
            return type.IsEnum;
        }

        private class Context
        {
            public GUIContent[] Names;
            public ulong[] Values;
            public float[] NameSizes;
            public bool IsFlagsEnum;
            public List<int> ColumnCounts;
            public float PreviousControlRectWidth;
        }

        /// <summary>
        /// Draws the property.
        /// </summary>
        protected override void DrawPropertyLayout(IPropertyValueEntry<T> entry, EnumToggleButtonsAttribute attribute, GUIContent label)
        {
            bool isBiaoTi = attribute.IsBiaoTi;
            int buttonSize = attribute.ButtonSize;
            MyEnumColor textColor = attribute.TextColor;
            var t = entry.WeakValues[0].GetType();
            int i = 1;
            for (; i < entry.WeakValues.Count; i++)
            {
                if (t != entry.WeakValues[i].GetType())
                {
                    AllEditorGUI.ErrorMessageBox("ToggleEnum does not support multiple different enum types.");
                    return;
                }
            }

            var enumType = entry.TypeOfValue;

            var context = entry.Property.Context.Get(this, "context", (Context)null);

            if (context.Value == null)
            {
                var enumNames = Enum.GetNames(enumType);
                context.Value = new Context();
                context.Value.Names = enumNames.Select(x => new GUIContent(isBiaoTi ? x.TitleCase_ChinaFormat().AddColor(textColor, false) : x)).ToArray();
                context.Value.Values = new ulong[context.Value.Names.Length];
                context.Value.IsFlagsEnum = entry.TypeOfValue.IsDefined<FlagsAttribute>();

                if (isBiaoTi)
                {
                    context.Value.NameSizes = new float[context.Value.Names.Length];
                    for (int j = 0; j < context.Value.NameSizes.Length; j++)
                    {
                        context.Value.NameSizes[j] = buttonSize;
                    }

                }
                else
                {
                    context.Value.NameSizes = context.Value.Names.Select(x => SirenixGUIStyles.ButtonMid.CalcSize(x).x).ToArray();
                }


                context.Value.ColumnCounts = new List<int>() { context.Value.NameSizes.Length };
                GUIHelper.RequestRepaint();
                i = 0;
                for (; i < context.Value.Values.Length; i++)
                {
                    context.Value.Values[i] = TypeExtensions.GetEnumBitmask(Enum.Parse(enumType, enumNames[i]), enumType);
                }
            }

            ulong value = TypeExtensions.GetEnumBitmask(entry.SmartValue, enumType);

            Rect controlRect = new Rect();

            i = 0;
            for (int j = 0; j < context.Value.ColumnCounts.Count; j++)
            {
                var rect = EditorGUILayout.GetControlRect();
                if (label != null)
                {
                    rect = EditorGUI.PrefixLabel(rect, j == 0 ? label : new GUIContent(" "));
                }

                if (j == 0)
                {
                    controlRect = rect;
                }

                var xMax = rect.xMax;
                rect.width /= context.Value.ColumnCounts[j];
                rect.width = (int)rect.width;
                int from = i;
                int to = i + context.Value.ColumnCounts[j];
                for (; i < to; i++)
                {
                    bool selected;

                    if (context.Value.IsFlagsEnum)
                    {
                        var mask = TypeExtensions.GetEnumBitmask(context.Value.Values[i], enumType);
                        selected = (mask & value) == mask;
                    }
                    else
                    {
                        selected = context.Value.Values[i] == value;
                    }

                    GUIStyle style;
   
                    Rect btnRect = rect;
                    if (i == from && i == to - 1)
                    {
                        style = selected ? SirenixGUIStyles.ButtonSelected : SirenixGUIStyles.Button;
                        btnRect.x -= 1;
                        btnRect.xMax = xMax + 1;
                    }
                    else if (i == from)
                        style = selected ? SirenixGUIStyles.ButtonLeftSelected : SirenixGUIStyles.ButtonLeft;
                    else if (i == to - 1)
                    {
                        style = selected ? SirenixGUIStyles.ButtonRightSelected : SirenixGUIStyles.ButtonRight;
                        btnRect.xMax = xMax;
                    }
                    else
                        style = selected ? SirenixGUIStyles.ButtonMidSelected : SirenixGUIStyles.ButtonMid;

                    //��д�ġ�����������������������������������������������������������������������
                    if (isBiaoTi)
                    {
                        style.fontStyle = FontStyle.Bold;
                        style.richText = true;
                        style.fontSize = 13;
                        btnRect.height += 5f;
                        if (btnRect.y > 14)
                        {
                            btnRect.y += 5f;
                        }
                    }

                    if (GUI.Button(btnRect, context.Value.Names[i], style))
                    {
                        GUIHelper.RemoveFocusControl();

                        if (!context.Value.IsFlagsEnum || Event.current.button == 1 || Event.current.modifiers == EventModifiers.Control)
                        {
                            entry.WeakSmartValue = Enum.ToObject(enumType, context.Value.Values[i]);
                        }
                        else
                        {
                            if (selected)
                            {
                                value &= ~context.Value.Values[i];
                            }
                            else
                            {
                                value |= context.Value.Values[i];
                            }

                            entry.WeakSmartValue = Enum.ToObject(enumType, value);
                        }

                        GUIHelper.RequestRepaint();
                    }

                    rect.x += rect.width;
                }

            }


            if (Event.current.type == EventType.Repaint && context.Value.PreviousControlRectWidth != controlRect.width)
            {
                context.Value.PreviousControlRectWidth = controlRect.width;

                float maxBtnWidth = 0;
                int row = 0;
                context.Value.ColumnCounts.Clear();
                context.Value.ColumnCounts.Add(0);
                i = 0;
                for (; i < context.Value.NameSizes.Length; i++)
                {
                    float btnWidth = context.Value.NameSizes[i] + 3;
                    int columnCount = ++context.Value.ColumnCounts[row];
                    float columnWidth = controlRect.width / columnCount;

                    maxBtnWidth = Mathf.Max(btnWidth, maxBtnWidth);

                    if (maxBtnWidth > columnWidth && columnCount > 1)
                    {
                        context.Value.ColumnCounts[row]--;
                        context.Value.ColumnCounts.Add(1);
                        row++;
                        maxBtnWidth = btnWidth;
                    }
                }
            }
        }




    }
}
#endif