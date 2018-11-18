using System.Collections.Generic;
using DG.DemiEditor;
using DG.DOTweenEditor.Core;
using DG.Tweening;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(DTExpansion_Contrl))]
public class DTExpansion_Contrl_Editor : ABSAnimationInspector
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(3);
        EditorGUIUtils.SetGUIStyles();

        GUILayout.BeginHorizontal();
        EditorGUIUtils.InspectorLogo();


        GUILayout.Label("对子类的 DoTweem 统一控制", EditorGUIUtils.sideLogoIconBoldLabelStyle);
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("▲", DeGUI.styles.button.toolIco)) UnityEditorInternal.ComponentUtility.MoveComponentUp(_src);
        if (GUILayout.Button("▼", DeGUI.styles.button.toolIco)) UnityEditorInternal.ComponentUtility.MoveComponentDown(_src);
        GUILayout.EndHorizontal();

        _src.isAutoStart = EditorGUILayout.Toggle("是否一开始显示", _src.isAutoStart);

        GUILayout.Label("DOTweenAnimation:");

        List<DOTweenAnimation> list = _src.l_DoTweens;
        List<DTExpansion_Fade> lFades = _src.l_Fades;
        for (int i = 0; i < list.Count; i++)
        {
            string tipStr = list[i].delay + " 延时," + list[i].duration + "运行 " + list[i].tipStr;
            DrawText(list[i].name, list[i].animationType.ToString(), tipStr, list[i].transform);
        }

        if (lFades.Count > 0)
        {
            GUILayout.Label("DTExpansion_Fade:");
            for (int i = 0; i < lFades.Count; i++)
            {
                string tmpStr = "";
                string tipStr = lFades[i].Delay+ " 延时," + lFades[i].Duration + "运行 ";
                switch (lFades[i].ContrlFadeType)
                {
                    case EFadeType.Zero2One:
                        tmpStr = "0 -> 1";
                        break;
                    case EFadeType.One2Zero:
                        tmpStr = "1 -> 0";
                        break;
                }
                DrawText(lFades[i].name, tmpStr, tipStr, lFades[i].transform);
            }
        }

        GUILayout.Space(3);
        if (GUILayout.Button("  刷新一下  "))
        {
            _src.DoReset();
        }



    }



    private void DrawText(string str1,string str2,string tip,Transform t)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("   "+str1, EditorGUIUtils.handlelabelStyle, GUILayout.Width(110));

        GUILayout.Label(str2, EditorGUIUtils.handleSelectedLabelStyle);
        if (!tip.IsNullOrEmpty())
        {
            tip = "(" + tip + ")";
            GUILayout.Label(tip);
        }
        GUILayout.FlexibleSpace();

        if (GUILayout.Button(" ◀ ", DeGUI.styles.button.toolIco))
        {

            Selection.activeTransform = t;
        }
        GUILayout.EndHorizontal();
    }



    DTExpansion_Contrl _src;


    void OnEnable()
    {
        _src = target as DTExpansion_Contrl;

    }


}
