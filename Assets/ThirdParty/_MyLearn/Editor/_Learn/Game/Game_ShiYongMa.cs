/*
using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Game_ShiYongMa : AbstactNewKuang
    {
        [MenuItem(LearnMenu.ZhiShi_ShiYongYuanMa)]
        static void Init()
        {
            Game_ShiYongMa instance = GetWindow<Game_ShiYongMa>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "遍历枚举实例化".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.First ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.First);
            }
            AddSpace();
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "UI实现拖拽".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Drag ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Drag);
            }
        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.First:
                    DrawRightPage1(DrawEnumNew);
                    break;
                case EType.Drag:
                    DrawRightPage3(DrawDrag);
                    break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 40;
                    break;
            }
        }


        #region 私有
        private enum EType
        {
            First,
            Drag,
        }

        private EType type = EType.First;

        private void SetTheSame(EType t)
        {
            if (type != t)
            {
                type = t;
                ResetPageView();
            }

        }

        protected override string Tittle()
        {
            return "实用源码";
        }



        #endregion


        private void DrawEnumNew()                               // 遍历枚举实例化
        {
            m_Tools.Text_L("遍历枚举,把枚举下的按名称实例化");

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public enum E枚举｛ Enum1，Enum2 ｝");
                AddSpace();

                m_Tools.Text_H("foreach (E枚举 type in Enum.GetValues(typeof(E枚举)))");
                m_Tools.Text_H("{");
                m_Tools.Text_H("    AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName()");
                m_Tools.Text_H("    Assembly.Load(assemblyName).CreateInstance(type.ToString())");
                m_Tools.Text_H("}");

            });


        }


        private static readonly string SetDraggedPositionStr = "SetDraggedPosition".AddWhite();
        private static readonly string CheckPosStr = "CheckPos".AddLightBlue();


        private void DrawDrag()                                  // UI实现拖拽
        {
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public class UIDrag : MonoBehaviour,"," IBeginDragHandler, IDragHandler, IEndDragHandler".AddYellow());
                m_Tools.Text_H("    private RectTransform rt;");
                m_Tools.Text_H("    public void OnBeginDrag(PointerEventData eventData)");
                m_Tools.Text_H("    {");
                m_Tools.Text_H("        rt = gameObject.GetComponent<RectTransform>();");
                m_Tools.Text_H("        ", SetDraggedPositionStr,"(eventData);");
                m_Tools.Text_H("    }");
                m_Tools.Text_H("    public void OnDrag(PointerEventData eventData)");
                m_Tools.Text_H("    {");
                m_Tools.Text_H("        ", SetDraggedPositionStr,"(eventData);");
                m_Tools.Text_H("    }");
                m_Tools.Text_H("    public void OnEndDrag(PointerEventData eventData)");
                m_Tools.Text_H("    {");
                m_Tools.Text_H("        ", SetDraggedPositionStr,"(eventData);");
                m_Tools.Text_H("    }");
                AddSpace();
                m_Tools.Text_H("    private void ", SetDraggedPositionStr,"(PointerEventData eventData)");
                m_Tools.Text_H("    {");
                m_Tools.Text_H("        Vector3 globalMousePos;");
                m_Tools.Text_H("        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos))");
                m_Tools.Text_H("        {");
                m_Tools.Text_H("            rt.position = ", CheckPosStr,"(globalMousePos);");
                m_Tools.Text_H("        }");
                m_Tools.Text_H("    }");
                AddSpace();
                m_Tools.Text_H("    Vector3 ", CheckPosStr,"(Vector3 pos)");
                m_Tools.Text_H("    {");
                m_Tools.Text_H("        if (pos.x < 10)");
                m_Tools.Text_H("            pos.x = 10;");
                m_Tools.Text_H("        else if (pos.x > Screen.width)");
                m_Tools.Text_H("            pos.x = Screen.width;");
                m_Tools.Text_H("        if (pos.y < 10)");
                m_Tools.Text_H("            pos.y = 10;");
                m_Tools.Text_H("        else if (pos.y > Screen.height)");
                m_Tools.Text_H("            pos.y = Screen.height;");
                m_Tools.Text_H("        return pos;");
                m_Tools.Text_H("    }");
            });
        }



    }

}

*/
