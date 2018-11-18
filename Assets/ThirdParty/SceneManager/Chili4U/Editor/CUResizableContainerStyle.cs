using PSPEditor.EditorUtil;
using UnityEngine;
using UnityEditor;

public class CUResizableContainerStyle
{
    private static CUResizableContainerStyle defaultStyle;
    public GUIStyle resizerVertical;
    public GUIStyle resizerHorizontal;

    public static CUResizableContainerStyle DefaultStyle
    {
        get
        {
            if (defaultStyle == null)
            {
                defaultStyle = new CUResizableContainerStyle();
            }
            return defaultStyle;
        }
        set { defaultStyle = value; }
    }

    public CUResizableContainerStyle()
    {
        resizerVertical = new GUIStyle();
        resizerVertical.fixedHeight = 6;
        resizerVertical.fixedWidth = 42;
        resizerVertical.margin = new RectOffset(0, 0, 1, 0);
        resizerVertical.imagePosition = ImagePosition.ImageOnly;
        if (EditorGUIUtility.isProSkin)
        {
            resizerVertical.normal.background = LoadRes.FindTextureOrGUISkin<Texture2D>("CUResizeDarkVertical.png");
        }
        else
        {
            resizerVertical.normal.background = LoadRes.FindTextureOrGUISkin<Texture2D>("CUResizeLightVertical.png");
        }

        resizerHorizontal = new GUIStyle();
        resizerHorizontal.fixedHeight = 42;
        resizerHorizontal.fixedWidth = 6;
        resizerHorizontal.margin = new RectOffset(1, 0, 0, 0);
        resizerHorizontal.imagePosition = ImagePosition.ImageOnly;
        if (EditorGUIUtility.isProSkin)
        {
            resizerHorizontal.normal.background = LoadRes.FindTextureOrGUISkin<Texture2D>("CUResizeDarkHorizontal.png");
        }
        else
        {
            resizerHorizontal.normal.background =
                LoadRes.FindTextureOrGUISkin<Texture2D>("CUResizeLightHorizontal.png");
        }
    }

}