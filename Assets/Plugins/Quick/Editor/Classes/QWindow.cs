using System.Collections.Generic;
using PSPUtil.StaticUtil;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace QuickEditor
{
    public class QWindow : EditorWindow
    {

        public Dictionary<string, InfoMessage> infoMessage;
        protected void DrawInfoMessage(string key, float width)
        {
            if (infoMessage == null)
            {
                Debug.Log("The infoMessage database is null.");
                return;
            }
            if (infoMessage.Count == 0)
            {
                Debug.Log("The infoMessage database is empty. Add the key to the database before you try to darw its message.");
                return;
            }
            if (!infoMessage.ContainsKey(key))
            {
                Debug.Log("The infoMessage database does not contain any key named '" + key + "'. Check if it was added to the database or if you spelled the key wrong.");
                return;
            }
            QUI.DrawInfoMessage(infoMessage[key], width);
        }

        public void CenterWindow()
        {
            var pos = position;
            pos.center = new Rect(0f, 0f, Screen.currentResolution.width, Screen.currentResolution.height).center;
            position = pos;
        }
    }
}
