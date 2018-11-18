using System;
using PSPUtil.StaticUtil;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Implementation of <see cref="AB_CUItemRenderer{T}"/> for rendering string items in a list.
/// </summary>
public class SMSceneRenderer : AB_CUItemRenderer<string>
{
    private Texture levelMarker;
    private Texture screenMarker;
    private GUIStyle addon;

    private readonly SMSceneConfigurationBase configuration;

    public SMSceneRenderer(SMSceneConfigurationBase configuration)
    {
        this.configuration = configuration;
    }

    public override float MeasureHeight(string item)
    {
        return 36f;
    }

    public override void Arrange(string item, int itemIndex, bool selected, bool focused, Rect itemRect)
    {
        if (levelMarker == null)
        {
            GUISkin skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);
            levelMarker = SMEditorResources.SMLevelMarker;
            screenMarker = SMEditorResources.SMScreenMarker;
            addon = new GUIStyle(skin.FindStyle("PlayerSettingsPlatform"));
            addon.alignment = TextAnchor.MiddleRight;
            addon.padding.right += 10;
        }

        GUIStyle backgroundStyle = itemIndex % 2 == 1 ? ListStyle.oddBackground : ListStyle.evenBackground;
        backgroundStyle.Draw(itemRect, false, false, selected, false);
        ListStyle.item.Draw(new Rect(itemRect.x + 32, itemRect.y, itemRect.width, itemRect.height),new GUIContent(item), true, false, selected, false);

        if (Array.IndexOf(configuration.levels, item) > -1)
        {
            GUI.DrawTexture(new Rect(itemRect.x + 4, itemRect.y + 4, 28, 28), levelMarker);


        }
        else if (Array.IndexOf(configuration.screens, item) > -1)
        {
            GUI.DrawTexture(new Rect(itemRect.x + 4, itemRect.y + 4, 28, 28), screenMarker);
        }

        string addonText = "";
        if (item == configuration.firstScreen)
        {
            addonText = "开始场景";
        }

        if (item == configuration.firstScreenAfterLevel)
        {
            addonText = Append(addonText, "所有关卡完成跳转此场景");
        }

        if (configuration is SMGroupedSceneConfiguration)
        {
            if (item == ((SMGroupedSceneConfiguration) configuration).firstScreenAfterGroup)
            {
                addonText = Append(addonText, "完成组后场景");
            }
        }

        if (!String.IsNullOrEmpty(addonText))
        {
            addon.Draw(itemRect, addonText, false, false, selected, false);
        }


    }

    private string Append(string text, string addon)
    {
        if (String.IsNullOrEmpty(text))
        {
            return addon;
        }

        return text + ", " + addon;
    }
}