using System;
using PSPUtil.StaticUtil;
using UnityEditor;
using UnityEngine;

namespace QuickEditor
{
    [Serializable]
    public class QColor
    {
        public Color Dark { get; set; }
        public Color Light { get; set; }

        public Color Color { get { return EditorGUIUtility.isProSkin ? Dark : Light; } }

        public QColor(Color color)
        {
            Dark = color;
            Light = color;
        }

        public QColor(Color color, float alpha)
        {
            Dark = new Color(color.r, color.g, color.b, alpha);
            Light = new Color(color.r, color.g, color.b, alpha);
        }

        public QColor(QColor qColor)
        {
            Dark = qColor.Dark;
            Light = qColor.Light;
        }

        public QColor(QColor qColor, float alpha, bool from256 = true)
        {
            Dark = new Color(qColor.Dark.r, qColor.Dark.g, qColor.Dark.b, from256 ? alpha / 256f : alpha);
            Light = new Color(qColor.Light.r, qColor.Light.g, qColor.Light.b, from256 ? alpha / 256f : alpha);
        }

        public QColor(Color dark, Color light)
        {
            Dark = dark;
            Light = light;
        }

        public QColor(int r, int g, int b, bool from256 = true)
        {
            Dark = from256 ? MyColor.GetColor(r, g, b) : new Color(r, g, b);
            Light = from256 ? MyColor.GetColor(r, g, b) : new Color(r, g, b);
        }

        public QColor(int r, int g, int b, int a, bool from256 = true)
        {
            Dark = from256 ? MyColor.GetColor(r, g, b, a) : new Color(r, g, b, a);
            Light = from256 ? MyColor.GetColor(r, g, b, a) : new Color(r, g, b, a);
        }

        public QColor(int rDark, int gDark, int bDark, int rLight, int gLight, int bLight, bool from256 = true)
        {
            Dark = from256 ? MyColor.GetColor(rDark, gDark, bDark) : new Color(rDark, gDark, bDark);
            Light = from256 ? MyColor.GetColor(rLight, gLight, bLight) : new Color(rLight, gLight, bLight);
        }

        public QColor(int rDark, int gDark, int bDark, int aDark, int rLight, int gLight, int bLight, int aLight, bool from256 = true)
        {
            Dark = from256 ? MyColor.GetColor(rDark, gDark, bDark, aDark) : new Color(rDark, gDark, bDark, aDark);
            Light = from256 ? MyColor.GetColor(rLight, gLight, bLight, aLight) : new Color(rLight, gLight, bLight, aLight);
        }
    }
}
