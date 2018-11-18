using System;
using System.Text;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEditor
{
    public class Tools_Context                               // 附加在组件上按钮
    {

        [MenuItem("CONTEXT/Image/复制 Color")]
        static void CopyColor()
        {
            Image image = GetImage();
            if (null == image)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(image.color.r);
            sb.Append(SplitChar);
            sb.Append(image.color.g);
            sb.Append(SplitChar);
            sb.Append(image.color.b);
            sb.Append(SplitChar);
            sb.Append(image.color.a);
            EditorGUIUtility.systemCopyBuffer = sb.ToString();

        }


        [MenuItem("CONTEXT/Image/粘贴 Color")]
        static void PasteColor()
        {
            Image image = GetImage();
            if (null == image)
            {
                return;
            }
            if (!EditorGUIUtility.systemCopyBuffer.IsNullOrEmpty())
            {
                string[] strs = EditorGUIUtility.systemCopyBuffer.Split(SplitChar);
                if (strs.Length == 4)
                {
                    float r = Convert.ToSingle(strs[0]);
                    float g = Convert.ToSingle(strs[1]);
                    float b = Convert.ToSingle(strs[2]);
                    float a = Convert.ToSingle(strs[3]);
                    image.color = new Color(r, g, b, a);
                }
            }

        }


        [MenuItem("CONTEXT/Image/复制颜色代码 如->#FFFFFF00")]  
        static void CopyColorCode()
        {
            Image image = GetImage();
            if (null == image)
            {
                return;
            }
            EditorGUIUtility.systemCopyBuffer = SplitChar + ColorUtility.ToHtmlStringRGBA(image.color);

        }

        [MenuItem("CONTEXT/Image/复制C#代码 如->new Color(1f, 1f, 1f, 0f)")]
        static void CopyColorCCode()
        {
            Image image = GetImage();
            if (null == image)
            {
                return;
            }
            EditorGUIUtility.systemCopyBuffer = image.color.ToCSharpColor();
        }



        #region 私有


        private const char SplitChar = '#';
        private static Image GetImage()
        {
            Image[] images = Selection.activeTransform.GetComponents<Image>();
            if (images.Length == 1)
            {
                return images[0];
            }
            else
            {
                MyLog.Red("这里没有 Image 或者 有多个");
                return null;
            }
        }

        #endregion
    }

}

