
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QuickEditor
{
    public class QEditor : Editor
    {
        public bool UseFixedUpdate = false;
        public float UpdateInterval = 2f;
        double startTime;
        double elapsedInterval = 0;

        #region QLabel
        private QLabel _qLabel;
        public QLabel QLabel { get { if(_qLabel == null) { _qLabel = new QLabel(); } return _qLabel; } }

        public Dictionary<string, QLabel> qLabels;
        public QLabel GetQLabel(string text, Style.Text style = Style.Text.Normal)
        {
            if(qLabels == null) { qLabels = new Dictionary<string, QLabel>(); }
            if(!qLabels.ContainsKey(text)) { qLabels.Add(text, new QLabel(text, style)); }
            return qLabels[text];
        }
        #endregion

        public Dictionary<string, InfoMessage> infoMessage;

        #region Colors
        private Color tempColor = Color.white;
        private Color tempContentColor = Color.white;
        private Color tempBackgroundColor = Color.white;

        public void SaveColors(bool resetColors = false)
        {
            tempColor = GUI.color;
            tempContentColor = GUI.contentColor;
            tempBackgroundColor = GUI.backgroundColor;
            if(resetColors) { QUI.ResetColors(); }
        }

        public void RestoreColors()
        {
            GUI.color = tempColor;
            GUI.contentColor = tempContentColor;
            GUI.backgroundColor = tempBackgroundColor;
        }
        #endregion

        #region Dimensions
        public const float WIDTH_420 = 330;
        public const float WIDTH_210 = 210f;
        public const float WIDTH_140 = 140f;
        public const float WIDTH_105 = 105f;

        public const float HEIGHT_8 = 8f;
        /// <summary>
        /// This is the EditorGUIUtility.singleLineHeight value
        /// </summary> 
        public const float HEIGHT_16 = 16f;
        public const float HEIGHT_24 = 24f;
        public const float HEIGHT_36 = 36f;
        public const float HEIGHT_42 = 42f;

        public const float INDENT_24 = 24f;

        /// <summary>
        /// This is the EditorGUIUtility.standardVerticalSpacing value
        /// </summary>
        public const int SPACE_2 = 2;
        public const int SPACE_4 = 4;
        public const int SPACE_8 = 8;
        /// <summary>
        /// This is the EditorGUIUtility.singleLineHeight value
        /// </summary> 
        public const int SPACE_16 = 16;
        #endregion

        #region RequiresConstantRepaint

        public bool requiresContantRepaint = false;
        public override bool RequiresConstantRepaint()
        {
            return requiresContantRepaint;
        }
        #endregion

        protected virtual void OnEnable()
        {
            startTime = EditorApplication.timeSinceStartup;
            EditorApplication.update += Update;

            SerializedObjectFindProperties();
            InitAnimBools();
            InitializeVariables();
            GenerateInfoMessages();
        }

        protected virtual void InitAnimBools() { }

        protected virtual void GenerateInfoMessages()
        {
            infoMessage = new Dictionary<string, InfoMessage>();
        }
        protected virtual void SerializedObjectFindProperties() { }
        protected virtual void InitializeVariables() { }

        protected virtual void OnDisable()
        {
            EditorApplication.update -= Update;
        }

        void OnDestroy()
        {
            EditorApplication.update -= Update;
        }

        protected virtual void Update()
        {
            if(!UseFixedUpdate) { return; }
            if(EditorApplication.timeSinceStartup > (startTime + elapsedInterval + UpdateInterval))
            {
                elapsedInterval += UpdateInterval;
                FixedUpdate();
            }
        }

        protected virtual void FixedUpdate() { }

        protected void DrawHeader(Texture texture, float width = WIDTH_420, float height = HEIGHT_36)
        {
            QUI.Space(SPACE_4);
            SaveColors(true);
            QUI.DrawTexture(texture, width, height);
            RestoreColors();
            QUI.Space(SPACE_4);
        }
        protected void DrawInfoMessage(string key, float width)
        {
            if (infoMessage == null)
            {
                Debug.Log("The infoMessage database is null."); return;
            }
            if (infoMessage.Count == 0)
            {
                Debug.Log("The infoMessage database is empty. Add the key to the database before you try to darw its message."); return;
            }
            if (!infoMessage.ContainsKey(key))
            {
                Debug.Log("The infoMessage database does not contain any key named '" + key + "'. Check if it was added to the database or if you spelled the key wrong."); return;
            }
            QUI.DrawInfoMessage(infoMessage[key], width);
        }
    }
}
