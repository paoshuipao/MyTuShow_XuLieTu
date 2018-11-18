using DG.DemiEditor;
using DG.DOTweenEditor.Core;
using UnityEditor;
using UnityEngine;



[CustomEditor(typeof(DTExpansion_Fade_Easy))]
public class DTExpansion_Fade_Easy_Editor : ABSAnimationInspector
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUIUtils.SetGUIStyles();

        GUILayout.BeginHorizontal();
        EditorGUIUtils.InspectorLogo();

        GUILayout.Label("控制 CanvasGroup 的 Alpha");
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("▲", DeGUI.styles.button.toolIco)) UnityEditorInternal.ComponentUtility.MoveComponentUp(mFade);
        if (GUILayout.Button("▼", DeGUI.styles.button.toolIco)) UnityEditorInternal.ComponentUtility.MoveComponentDown(mFade);
        GUILayout.EndHorizontal();

        mFade.Duration = EditorGUILayout.FloatField("持续时间", mFade.Duration);
        if (mFade.Duration < 0)
        {
            mFade.Duration = 0.1f;
        }

        GUILayout.Space(5);

        //        mFade.Dalay = EditorGUILayout.FloatField("延迟", mFade.Dalay);
        //        if (mFade.Dalay < 0)
        //        {
        //            mFade.Dalay = 0;
        //        }


        GUILayout.BeginHorizontal();
        if (GUILayout.Button(mFade.IsFrom ? "FROM" : "TO", EditorGUIUtils.sideBtStyle, GUILayout.Width(100)))
        {
            mFade.IsFrom = !mFade.IsFrom;
        }
        GUILayout.Space(22);
        mFade.EndValue = EditorGUILayout.Slider(mFade.EndValue,0,1);
        GUILayout.EndHorizontal();


        GUILayout.Space(5);

        string middleStr = mFade.IsFrom ? "    From <-    " : "    TO ->    ";

        string valueStr = mFade.GetCurrentAlpha + middleStr + mFade.EndValue;

        GUILayout.BeginHorizontal();


        GUILayout.Label("Alpha", EditorGUIUtils.handlelabelStyle, GUILayout.Width(80));
        GUILayout.Label(valueStr, EditorGUIUtils.handleSelectedLabelStyle);

        GUILayout.EndHorizontal();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(mFade);
        }


    }


    DTExpansion_Fade_Easy mFade;

    void OnEnable()
    {
        mFade = target as DTExpansion_Fade_Easy;
    }
}
