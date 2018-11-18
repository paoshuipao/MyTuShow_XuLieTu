using System;
using PSPEditor.EditorUtil;
using UnityEngine;

public class SMEditorResources
{
    private static Texture _SMLevelMarker;
    private static Texture _SMScreenMarker;
    private static Texture _SMScreenGroup;

    public static Texture SMLevelMarker
    {
        get
        {
            if (_SMLevelMarker == null)
            {

                _SMLevelMarker = LoadRes.FindTextureOrGUISkin<Texture>("SMLevelMarker.png");
            }
            return _SMLevelMarker;
        }
    }

    public static Texture SMScreenMarker
    {
        get
        {
            if (_SMScreenMarker == null)
            {
                _SMScreenMarker = LoadRes.FindTextureOrGUISkin<Texture>("SMScreenMarker.png");
            }
            return _SMScreenMarker;
        }
    }

    public static Texture SMScreenGroup
    {
        get
        {
            if (_SMScreenGroup == null)
            {
                _SMScreenGroup = LoadRes.FindTextureOrGUISkin<Texture>("SMScreenGroup.png");
            }
            return _SMScreenGroup;
        }
    }

}