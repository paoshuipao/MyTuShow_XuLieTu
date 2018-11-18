using System;
using System.Collections.Generic;
using DG.DemiEditor;
using DG.DOTweenEditor.Core;
using DG.Tweening;
using DG.Tweening.Core;
using PSPUtil.Extensions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

#if DOTWEEN_TMP
    using TMPro;
#endif

namespace DG.DOTweenEditor
{

    [CustomEditor(typeof(DOTweenAnimation))]
    public class DOTweenAnimation_Editor : ABSAnimationInspector
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            #region 私有
            GUILayout.Space(3);
            EditorGUIUtils.SetGUIStyles();

            bool playMode = Application.isPlaying;
            _runtimeEditMode = _runtimeEditMode && playMode;
      
            GUILayout.BeginHorizontal();
            EditorGUIUtils.InspectorLogo();
            DrawLablelOnClick();
 
            // Up-down buttons
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("▲", DeGUI.styles.button.toolIco)) UnityEditorInternal.ComponentUtility.MoveComponentUp(_src);
            if (GUILayout.Button("▼", DeGUI.styles.button.toolIco)) UnityEditorInternal.ComponentUtility.MoveComponentDown(_src);
            GUILayout.EndHorizontal();

            if (playMode)
            {
                if (!_runtimeEditMode)
                {
                    GUILayout.Space(8);
                    Label("在播放模式下禁用动画编辑器", "Animation Editor disabled while in play mode", EditorGUIUtils.wordWrapLabelStyle);
                    if (!_src.isActive)
                    {
                        Label("此动画已切换为非活动状态，不会生成", "This animation has been toggled as inactive and won't be generated", EditorGUIUtils.wordWrapLabelStyle);
                        GUI.enabled = false;
                    }
                    if (GUILayout.Button(NewGUIContent("激活编辑模式", "切换到运行时编辑模式，您可以在其中更改动画值并重新启动它们", "Activate Edit Mode", "Switches to Runtime Edit Mode, where you can change animations values and restart them")))
                    {
                        _runtimeEditMode = true;
                    }
                    Label("注意：使用DOPlayNext时，序列由目标 GameObject 的 Inspector 中的 DOTweenAnimation Components 顺序决定", "NOTE: when using DOPlayNext, the sequence is determined by the DOTweenAnimation Components order in the target GameObject's Inspector", EditorGUIUtils.wordWrapLabelStyle);



                    GUILayout.Space(10);

                    if (null != _src.btns && _src.btns.Length > 0)
                    {
                        GUILayout.Label("关闭的按钮：");
                        foreach (var btn in _src.btns)
                        {
                            GUILayout.Label(btn.name);
                        }
                    }

                    GUILayout.Space(10);

                    if (!_runtimeEditMode)
                    {
                        return;
                    }
                }
            }

            Undo.RecordObject(_src, "DOTween Animation");


            EditorGUIUtility.labelWidth = 120;

            if (playMode)
            {
                GUILayout.Space(4);
                DeGUILayout.Toolbar("Edit Mode Commands");
                DeGUILayout.BeginVBox(DeGUI.styles.box.stickyTop);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("TogglePause")) _src.tween.TogglePause();
                if (GUILayout.Button("Rewind")) _src.tween.Rewind();
                if (GUILayout.Button("Restart")) _src.tween.Restart();
                GUILayout.EndHorizontal();
                if (GUILayout.Button("Commit changes and restart"))
                {
                    _src.tween.Rewind();
                    _src.tween.Kill();
                    if (_src.isValid)
                    {
                        _src.CreateTween();
                        _src.tween.Play();
                    }
                }
                Label("要在退出播放模式时应用更改，请使用组件的右上方菜单并选择“复制组件”，然后在退出播放模式后选择“粘贴组件值”", "To apply your changes when exiting Play mode, use the Component's upper right menu and choose \"Copy Component\", then \"Paste Component Values\" after exiting Play mode", DeGUI.styles.label.wordwrap);
                DeGUILayout.EndVBox();
            }

            GUILayout.BeginHorizontal();
            DOTweenAnimationType prevAnimType = _src.animationType;
            _src.isActive = EditorGUILayout.Toggle(new GUIContent("", "If unchecked, this animation will not be created"), _src.isActive, GUILayout.Width(16));
            GUI.enabled = _src.isActive;
            _src.animationType = AnimationToDOTweenAnimationType(_AnimationType[EditorGUILayout.Popup(DOTweenAnimationTypeToPopupId(_src.animationType), _AnimationType)]);
            _src.autoPlay = DeGUILayout.ToggleButton(_src.autoPlay,  NewGUIContent("AutoPlay", "如果选中，则 tween 会自动播放", "AutoPlay", "If selected, the tween will play automatically"));
            _src.autoKill = DeGUILayout.ToggleButton(_src.autoKill, NewGUIContent("AutoKill", "如果选中，则 tween 将在完成时被终止，并且不可重用", "AutoKill", "If selected, the tween will be killed when it completes, and won't be reusable"));
            GUILayout.EndHorizontal();
            if (prevAnimType != _src.animationType)
            {
                // Set default optional values based on animation type
                switch (_src.animationType)
                {
                    case DOTweenAnimationType.Move:
                    case DOTweenAnimationType.LocalMove:
                    case DOTweenAnimationType.Rotate:
                    case DOTweenAnimationType.LocalRotate:
                    case DOTweenAnimationType.Scale:
                        _src.endValueV3 = Vector3.zero;
                        _src.endValueFloat = 0;
                        _src.optionalBool0 = _src.animationType == DOTweenAnimationType.Scale;
                        break;
                    case DOTweenAnimationType.Color:
                    case DOTweenAnimationType.Fade:
                        _src.endValueFloat = 0;
                        break;
                    case DOTweenAnimationType.Text:
                        _src.optionalBool0 = true;
                        break;
                    case DOTweenAnimationType.PunchPosition:
                    case DOTweenAnimationType.PunchRotation:
                    case DOTweenAnimationType.PunchScale:
                        _src.endValueV3 = _src.animationType == DOTweenAnimationType.PunchRotation ? new Vector3(0, 180, 0) : Vector3.one;
                        _src.optionalFloat0 = 1;
                        _src.optionalInt0 = 10;
                        _src.optionalBool0 = false;
                        break;
                    case DOTweenAnimationType.ShakePosition:
                    case DOTweenAnimationType.ShakeRotation:
                    case DOTweenAnimationType.ShakeScale:
                        _src.endValueV3 = _src.animationType == DOTweenAnimationType.ShakeRotation ? new Vector3(90, 90, 90) : Vector3.one;
                        _src.optionalInt0 = 10;
                        _src.optionalFloat0 = 90;
                        _src.optionalBool0 = false;
                        break;
                    case DOTweenAnimationType.CameraAspect:
                    case DOTweenAnimationType.CameraFieldOfView:
                    case DOTweenAnimationType.CameraOrthoSize:
                        _src.endValueFloat = 0;
                        break;
                    case DOTweenAnimationType.CameraPixelRect:
                    case DOTweenAnimationType.CameraRect:
                        _src.endValueRect = new Rect(0, 0, 0, 0);
                        break;
                }
            }
            if (_src.animationType == DOTweenAnimationType.None)
            {
                _src.isValid = false;
                if (GUI.changed) EditorUtility.SetDirty(_src);
                return;
            }

            if (prevAnimType != _src.animationType || ComponentsChanged())
            {
                _src.isValid = Validate();
            }

            if (!_src.isValid)
            {
                GUI.color = Color.red;
                GUILayout.BeginVertical(GUI.skin.box);
                Label("找不到所选动画的有效组件", "No valid Component was found for the selected animation", EditorGUIUtils.wordWrapLabelStyle);
                GUILayout.EndVertical();
                GUI.color = Color.white;
                if (GUI.changed) EditorUtility.SetDirty(_src);
                return;
            }

            #endregion

            _src.duration = FloatField("持续时间", "Duration", _src.duration);
            if (_src.duration < 0) _src.duration = 0;
            _src.delay = FloatField("延迟", "Delay", _src.delay);
            if (_src.delay < 0) _src.delay = 0;
            _src.isIndependentUpdate = Toggle("是否忽略 TimeScale", "Ignore TimeScale", _src.isIndependentUpdate);
            _src.easeType = EditorGUIUtils.FilteredEasePopup(_src.easeType);
            if (_src.easeType == Ease.INTERNAL_Custom)
            {
                _src.easeCurve = CurveField("   缓和曲线", "   Ease Curve", _src.easeCurve);
            }
            _src.loops = EditorGUILayout.IntField(NewGUIContent("循环", "无限循环设置为 -1", "Loops", "Set to -1 for infinite loops"), _src.loops);
            if (_src.loops < -1) _src.loops = -1;
            if (_src.loops > 1 || _src.loops == -1)
                _src.loopType = (LoopType)EnumPopup("   循环模式", "   Loop Type",LoopTypeStrs, _src.loopType);
            _src.id = EditorGUILayout.TextField("ID", _src.id);

            bool canBeRelative = true;
            // End value and eventual specific options
            switch (_src.animationType)
            {
                case DOTweenAnimationType.Move:
                case DOTweenAnimationType.LocalMove:
                    GUIEndValueV3();
                    DrawSnapping();
                    break;
                case DOTweenAnimationType.Rotate:
                case DOTweenAnimationType.LocalRotate:
                    if (_src.GetComponent<Rigidbody2D>()) GUIEndValueFloat();
                    else
                    {
                        GUIEndValueV3();
                        _src.optionalRotationMode = (RotateMode)EnumPopup("    旋转模式", "    Rotation Mode", RotationModeStrs, _src.optionalRotationMode);
                    }
                    break;
                case DOTweenAnimationType.Scale:
                    if (_src.optionalBool0) GUIEndValueFloat();
                    else GUIEndValueV3();
                    _src.optionalBool0 = ToggleLeft("    ture：统一规模缩放，即只用 float 而非 Vector3", "Uniform Scale", _src.optionalBool0);
                    break;
                case DOTweenAnimationType.Color:
                    GUIEndValueColor();
                    canBeRelative = false;
                    break;
                case DOTweenAnimationType.Fade:
                    GUIEndValueFloat();
                    if (_src.endValueFloat < 0) _src.endValueFloat = 0;
                    if (_src.endValueFloat > 1) _src.endValueFloat = 1;
                    canBeRelative = false;
                    break;
                case DOTweenAnimationType.Text:
                    GUIEndValueString();
                    _src.optionalBool0 = ToggleLeft("    是否启用富文本", "Rich Text Enabled", _src.optionalBool0);
                    _src.optionalScrambleMode = (ScrambleMode)EnumPopup("争夺模式", "Scramble Mode", ScrambleStrs, _src.optionalScrambleMode);
                    _src.optionalString = EditorGUILayout.TextField(NewGUIContent("自定义争夺", "争夺模式中使用的自定义字符", "Custom Scramble", "Custom characters to use in case of ScrambleMode.Custom"), _src.optionalString);
                    break;
                case DOTweenAnimationType.PunchPosition:
                case DOTweenAnimationType.PunchRotation:
                case DOTweenAnimationType.PunchScale:
                    GUIEndValueV3();
                    canBeRelative = false;
                    _src.optionalInt0 = EditorGUILayout.IntSlider(NewGUIContent("    振动", "冲头会振动多少", "    Vibrato", "How much will the punch vibrate"), _src.optionalInt0, 1, 50);
                    _src.optionalFloat0 = EditorGUILayout.Slider(NewGUIContent("    弹性", "当向后弹跳时，向量将超出起始位置", "    Elasticity", "How much the vector will go beyond the starting position when bouncing backwards"), _src.optionalFloat0, 0, 1);
                    if (_src.animationType == DOTweenAnimationType.PunchPosition)
                    {
                        DrawSnapping();
                    }
                    break;
                case DOTweenAnimationType.ShakePosition:
                case DOTweenAnimationType.ShakeRotation:
                case DOTweenAnimationType.ShakeScale:
                    GUIEndValueV3();
                    canBeRelative = false;
                    _src.optionalInt0 = EditorGUILayout.IntSlider(NewGUIContent("    振动", "冲头会振动多少", "    Vibrato", "How much will the shake vibrate"), _src.optionalInt0, 1, 50);
                    _src.optionalFloat0 = EditorGUILayout.Slider(NewGUIContent("    随机性", "摇晃随机性", "    Randomness", "The shake randomness"), _src.optionalFloat0, 0, 90);
                    if (_src.animationType == DOTweenAnimationType.ShakePosition)
                    {
                        DrawSnapping();
                    }
                    break;
                case DOTweenAnimationType.CameraAspect:
                case DOTweenAnimationType.CameraFieldOfView:
                case DOTweenAnimationType.CameraOrthoSize:
                    GUIEndValueFloat();
                    canBeRelative = false;
                    break;
                case DOTweenAnimationType.CameraBackgroundColor:
                    GUIEndValueColor();
                    canBeRelative = false;
                    break;
                case DOTweenAnimationType.CameraPixelRect:
                case DOTweenAnimationType.CameraRect:
                    GUIEndValueRect();
                    canBeRelative = false;
                    break;
            }

            // Final settings
            if (canBeRelative)
            {
                DrawRelative();
            }


            _src.isUseDTContrl = ToggleLeft("    true：使用 DTExpansion_Contrl 统一控制", "    isUseDTContrl", _src.isUseDTContrl);

            DrawToggleIsCloseBtn();

            DrawTip();
            DrawDesTip();


            // Events
            AnimationInspectorGUI.AnimationEvents(this, _src);

            if (GUI.changed) EditorUtility.SetDirty(_src);
        }


        private void DrawLablelOnClick()                          // 在Logo后面的字增加个点击
        {
            bool isClick = GUILayout.Button(_src.animationType + (string.IsNullOrEmpty(_src.id) ? "" : " [" + _src.id + "]"), EditorGUIUtils.sideLogoIconBoldLabelStyle);
            if (isClick)
            {
                _src.isShowTipInEditor = !_src.isShowTipInEditor;
                isEnglish = !isEnglish;
            }
        }


        private void DrawSnapping()                               // Snapping
        {
            _src.optionalBool0 = ToggleLeft("    true：所有值平滑到整数（结果没小数）", "    Snapping", _src.optionalBool0);
        }


        private void DrawRelative()                               // Relative
        {
            _src.isRelative = ToggleLeft("    true：结束值 = 开始值 + TO的结束值（非 TO）", "    Relative", _src.isRelative);
        }


        private void DrawTip()                                    // 添加提示的内容
        {
            if (!_src.isShowTipInEditor)
            {
                return;
            }
            string middleStr = _src.isFrom ? "    From <-    " : "    TO ->    ";
            string tittleStr = "";
            string valueStr = "";
            switch (_src.animationType)
            {
                case DOTweenAnimationType.Move:
                    tittleStr = "世界坐标";
                    valueStr = _src.transform.position + middleStr + _src.endValueV3;
                    break;
                case DOTweenAnimationType.LocalMove:
                    tittleStr = "本地坐标";
                    valueStr = _src.transform.localPosition + middleStr + _src.endValueV3;
                    break;
                case DOTweenAnimationType.Rotate:
                    tittleStr = "世界欧拉角";
                    valueStr = _src.transform.rotation.eulerAngles + middleStr + _src.endValueV3;
                    break;
                case DOTweenAnimationType.LocalRotate:
                    tittleStr = "本地欧拉角";
                    valueStr = _src.transform.localRotation.eulerAngles + middleStr + _src.endValueV3;
                    break;
                case DOTweenAnimationType.Scale:
                    tittleStr = "大小";
                    if (_src.optionalBool0)
                    {
                        valueStr = _src.transform.localScale + middleStr + _src.endValueFloat;
                    }
                    else
                    {
                        valueStr = _src.transform.localScale + middleStr + _src.endValueV3;
                    }
                 
                    break;
                case DOTweenAnimationType.Color:
                    break;
                case DOTweenAnimationType.Fade:
                    break;
                case DOTweenAnimationType.Text:
                    break;
                case DOTweenAnimationType.PunchPosition:
                    break;
                case DOTweenAnimationType.PunchRotation:
                    break;
                case DOTweenAnimationType.PunchScale:
                    break;
                case DOTweenAnimationType.ShakePosition:
                    break;
                case DOTweenAnimationType.ShakeRotation:
                    break;
                case DOTweenAnimationType.ShakeScale:
                    break;
                case DOTweenAnimationType.CameraAspect:
                    break;
                case DOTweenAnimationType.CameraBackgroundColor:
                    break;
                case DOTweenAnimationType.CameraFieldOfView:
                    break;
                case DOTweenAnimationType.CameraOrthoSize:
                    break;
                case DOTweenAnimationType.CameraPixelRect:
                    break;
                case DOTweenAnimationType.CameraRect:
                    break;
            }
            if (tittleStr.IsNullOrEmpty() || valueStr.IsNullOrEmpty())
            {
                return;
            }
            GUILayout.BeginHorizontal();

            GUILayout.Label(tittleStr, EditorGUIUtils.handlelabelStyle, GUILayout.Width(60));
            GUILayout.Label(valueStr, EditorGUIUtils.handleSelectedLabelStyle);

            GUILayout.EndHorizontal();


        }


        private void DrawDesTip()                                  // 说明
        {
            if (!_src.isShowTipInEditor)
            {
                return;
            }
            GUILayout.BeginHorizontal();
            bool tmp = GUILayout.Button("说明", EditorGUIUtils.handlelabelStyle, GUILayout.Width(60));
            if (tmp)
            {
                isTextTittle = !isTextTittle;
            }
            if (isTextTittle)
            {
                _src.tipStr = EditorGUILayout.TextArea(_src.tipStr);
            }
            else
            {
                EditorGUILayout.LabelField(_src.tipStr, EditorGUIUtils.handleSelectedLabelStyle);
            }
            

            GUILayout.EndHorizontal();

        }
    


        private void DrawToggleIsCloseBtn()                        // 是否关闭 按钮
        {
            if (_src.isUseDTContrl)
            {
                _src.isCloseAllButton = ToggleLeft("    true：运行时关闭所有按钮", "isCloseAllButton", _src.isCloseAllButton);
            }
          
        }





        [MenuItem("CONTEXT/DOTweenAnimation/是否使用英文")]
        static void YouJian()
        {
            isEnglish = !isEnglish;
        }



        #region 私有
        private static bool isEnglish,isTextTittle =true;



        static readonly string[] _AnimationType = new[] {
            "None",
            "Move", "LocalMove",
            "Rotate", "LocalRotate",
            "Scale",
            "Color", "Fade",
            "Text",
            "Punch/Position", "Punch/Rotation", "Punch/Scale",
            "Shake/Position", "Shake/Rotation", "Shake/Scale",
            "Camera/Aspect", "Camera/BackgroundColor", "Camera/FieldOfView", "Camera/OrthoSize", "Camera/PixelRect", "Camera/Rect"
        };


        private readonly string[] LoopTypeStrs = { "重新开始", "Yoyo", "增加的" };


        private readonly string[] RotationModeStrs = { "不超 360 最快方式", "超 360 最快方式", "WorldAxisAdd", "LocalAxisAdd" };


        private readonly string[] ScrambleStrs = { "None", "All", "A-Z 大写字母", "a-z 小写字母", "0-9 数字", "自定义字符" };





        static readonly Dictionary<DOTweenAnimationType, Type[]> _AnimationTypeToComponent = new Dictionary<DOTweenAnimationType, Type[]>() {
            { DOTweenAnimationType.Move, new[] { typeof(Rigidbody), typeof(Rigidbody2D), typeof(RectTransform), typeof(Transform) } },
            { DOTweenAnimationType.LocalMove, new[] { typeof(Transform) } },
            { DOTweenAnimationType.Rotate, new[] { typeof(Rigidbody), typeof(Rigidbody2D), typeof(Transform) } },
            { DOTweenAnimationType.LocalRotate, new[] { typeof(Transform) } },
            { DOTweenAnimationType.Scale, new[] { typeof(Transform) } },
            { DOTweenAnimationType.Color, new[] { typeof(SpriteRenderer), typeof(Renderer), typeof(Image), typeof(Text) } },
            { DOTweenAnimationType.Fade, new[] { typeof(SpriteRenderer), typeof(Renderer), typeof(Image), typeof(Text) } },
            { DOTweenAnimationType.Text, new[] { typeof(Text) } },
            { DOTweenAnimationType.PunchPosition, new[] { typeof(RectTransform), typeof(Transform) } },
            { DOTweenAnimationType.PunchRotation, new[] { typeof(Transform) } },
            { DOTweenAnimationType.PunchScale, new[] { typeof(Transform) } },
            { DOTweenAnimationType.ShakePosition, new[] { typeof(RectTransform), typeof(Transform) } },
            { DOTweenAnimationType.ShakeRotation, new[] { typeof(Transform) } },
            { DOTweenAnimationType.ShakeScale, new[] { typeof(Transform) } },
            { DOTweenAnimationType.CameraAspect, new[] { typeof(Camera) } },
            { DOTweenAnimationType.CameraBackgroundColor, new[] { typeof(Camera) } },
            { DOTweenAnimationType.CameraFieldOfView, new[] { typeof(Camera) } },
            { DOTweenAnimationType.CameraOrthoSize, new[] { typeof(Camera) } },
            { DOTweenAnimationType.CameraPixelRect, new[] { typeof(Camera) } },
            { DOTweenAnimationType.CameraRect, new[] { typeof(Camera) } },
        };


#if DOTWEEN_TK2D
        static readonly Dictionary<DOTweenAnimationType, Type[]> _Tk2dAnimationTypeToComponent = new Dictionary<DOTweenAnimationType, Type[]>() {
            { DOTweenAnimationType.Color, new[] { typeof(tk2dBaseSprite), typeof(tk2dTextMesh) } },
            { DOTweenAnimationType.Fade, new[] { typeof(tk2dBaseSprite), typeof(tk2dTextMesh) } },
            { DOTweenAnimationType.Text, new[] { typeof(tk2dTextMesh) } }
        };
#endif
#if DOTWEEN_TMP
        static readonly Dictionary<DOTweenAnimationType, Type[]> _TMPAnimationTypeToComponent = new Dictionary<DOTweenAnimationType, Type[]>() {
            { DOTweenAnimationType.Color, new[] { typeof(TextMeshPro), typeof(TextMeshProUGUI) } },
            { DOTweenAnimationType.Fade, new[] { typeof(TextMeshPro), typeof(TextMeshProUGUI) } },
            { DOTweenAnimationType.Text, new[] { typeof(TextMeshPro), typeof(TextMeshProUGUI) } }
        };
#endif

        static string[] _animationTypeNoSlashes; // _AnimationType list without slashes in values
        static string[] _datString; // String representation of DOTweenAnimation enum (here for caching reasons)

        DOTweenAnimation _src;
        bool _runtimeEditMode; // If TRUE allows to change and save stuff at runtime
        int _totComponentsOnSrc; // Used to determine if a Component is added or removed from the source


        void OnEnable()
        {
            _src = target as DOTweenAnimation;

            onStartProperty = base.serializedObject.FindProperty("onStart");
            onPlayProperty = base.serializedObject.FindProperty("onPlay");
            onUpdateProperty = base.serializedObject.FindProperty("onUpdate");
            onStepCompleteProperty = base.serializedObject.FindProperty("onStepComplete");
            onCompleteProperty = base.serializedObject.FindProperty("onComplete");

            // Convert _AnimationType to _animationTypeNoSlashes
            int len = _AnimationType.Length;
            _animationTypeNoSlashes = new string[len];
            for (int i = 0; i < len; ++i) {
                string a = _AnimationType[i];
                a = a.Replace("/", "");
                _animationTypeNoSlashes[i] = a;
            }
        }



        bool ComponentsChanged()
        {
            int prevTotComponentsOnSrc = _totComponentsOnSrc;
            _totComponentsOnSrc = _src.gameObject.GetComponents<Component>().Length;
            return prevTotComponentsOnSrc != _totComponentsOnSrc;
        }

        bool Validate()
        {
            if (_src.animationType == DOTweenAnimationType.None) return false;

            Component srcTarget;
            // First check for external plugins
#if DOTWEEN_TK2D
            if (_Tk2dAnimationTypeToComponent.ContainsKey(_src.animationType)) {
                foreach (Type t in _Tk2dAnimationTypeToComponent[_src.animationType]) {
                    srcTarget = _src.GetComponent(t);
                    if (srcTarget != null) {
                        _src.target = srcTarget;
                        return true;
                    }
                }
            }
#endif
#if DOTWEEN_TMP
            if (_TMPAnimationTypeToComponent.ContainsKey(_src.animationType)) {
                foreach (Type t in _TMPAnimationTypeToComponent[_src.animationType]) {
                    srcTarget = _src.GetComponent(t);
                    if (srcTarget != null) {
                        _src.target = srcTarget;
                        return true;
                    }
                }
            }
#endif
            // Then check for regular stuff
            if (_AnimationTypeToComponent.ContainsKey(_src.animationType)) {
                foreach (Type t in _AnimationTypeToComponent[_src.animationType]) {
                    srcTarget = _src.GetComponent(t);
                    if (srcTarget != null) {
                        _src.target = srcTarget;
                        return true;
                    }
                }
            }
            return false;
        }

        DOTweenAnimationType AnimationToDOTweenAnimationType(string animation)
        {
            if (_datString == null)
            {
                _datString = Enum.GetNames(typeof(DOTweenAnimationType));
            }
            animation = animation.Replace("/", "");
            return (DOTweenAnimationType)(Array.IndexOf(_datString, animation));
        }
        int DOTweenAnimationTypeToPopupId(DOTweenAnimationType animation)
        {
            return Array.IndexOf(_animationTypeNoSlashes, animation.ToString());
        }

        void GUIEndValueFloat()
        {
            GUILayout.BeginHorizontal();
            GUIToFromButton();
            _src.endValueFloat = EditorGUILayout.FloatField(_src.endValueFloat);
            GUILayout.EndHorizontal();
        }

        void GUIEndValueColor()
        {
            GUILayout.BeginHorizontal();
            GUIToFromButton();
            _src.endValueColor = EditorGUILayout.ColorField(_src.endValueColor);
            GUILayout.EndHorizontal();
        }

        void GUIEndValueV3()
        {
            GUILayout.BeginHorizontal();
            GUIToFromButton();
            _src.endValueV3 = EditorGUILayout.Vector3Field("", _src.endValueV3, GUILayout.Height(16));
            GUILayout.EndHorizontal();
        }

        void GUIEndValueString()
        {
            GUILayout.BeginHorizontal();
            GUIToFromButton();
            _src.endValueString = EditorGUILayout.TextArea(_src.endValueString, EditorGUIUtils.wordWrapTextArea);
            GUILayout.EndHorizontal();
        }

        void GUIEndValueRect()
        {
            GUILayout.BeginHorizontal();
            GUIToFromButton();
            _src.endValueRect = EditorGUILayout.RectField(_src.endValueRect);
            GUILayout.EndHorizontal();
        }

        void GUIToFromButton()
        {
            if (GUILayout.Button(_src.isFrom ? "FROM" : "TO", EditorGUIUtils.sideBtStyle, GUILayout.Width(100))) _src.isFrom = !_src.isFrom;
            GUILayout.Space(16);
        }



        #endregion




        private void Label(string china,string englis, GUIStyle style)
        {
            GUILayout.Label(isEnglish? englis: china, style);

        }


        private GUIContent NewGUIContent(string china1,string china2,string english1,string elglish2)
        {
            return new GUIContent(isEnglish? english1:china1, isEnglish? elglish2: china2);
        }

        private bool Toggle(string chinaStr, string englishStr, bool value)
        {
            return EditorGUILayout.Toggle(isEnglish ? englishStr : chinaStr, value);
        }


        private bool ToggleLeft(string chinaStr, string englishStr, bool value)
        {
            return EditorGUILayout.ToggleLeft(isEnglish ? englishStr : chinaStr, value);
        }



        private bool BeginFoldOut(string chinaStr, string englishStr, bool isFold)
        {
            return EditorGUILayout.Foldout(isFold,isEnglish ? englishStr : chinaStr);
        }

        private int EnumPopup(string chinaStr, string englishStr, string[] diPplay, Enum value)
        {
            if (isEnglish)
            {
                return EditorGUILayout.EnumPopup(englishStr, value).GetHashCode();
            }
            else
            {

                return EditorGUILayout.Popup(chinaStr, value.GetHashCode(), diPplay);
            }
        }

        private Enum EnumPopup(string chinaStr, string englishStr, Enum value)
        {
            return EditorGUILayout.EnumPopup(englishStr, value);
        }

        private Vector2 Vector2Field(string chinaStr, string englishStr, Vector2 value)
        {
            return EditorGUILayout.Vector2Field(isEnglish ? englishStr : chinaStr, value);
        }

        private float FloatField(string chinaStr, string englishStr, float value)
        {
            return EditorGUILayout.FloatField(isEnglish ? englishStr : chinaStr, value);
        }



        private AnimationCurve CurveField(string chinaStr, string englishStr, AnimationCurve value)
        {
          return EditorGUILayout.CurveField(isEnglish ? englishStr : chinaStr, value);

        }



    }
}