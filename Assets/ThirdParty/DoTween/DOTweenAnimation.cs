using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core;
using PSPUtil.Control;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#if DOTWEEN_TMP
	using TMPro;
#endif

#pragma warning disable 1591
namespace DG.Tweening
{

    [AddComponentMenu("DOTween/DOTween Animation")]
    public class DOTweenAnimation : ABSAnimationComponent
    {

        public bool isShowTipInEditor =true;           // 我自己添加的 是否在面板上显示提示
        public string tipStr;                          // 我自己添加的 这个动画的提示字符串
        public bool isCloseAllButton;              // 是否在动画时关闭所有按钮

        public Button[] btns;

        public bool isUseDTContrl ;
        public float delay;
        public float duration = 1;
        public Ease easeType = Ease.OutQuad;
        public AnimationCurve easeCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        public LoopType loopType = LoopType.Restart;
        public int loops = 1;
        public string id = "";
        public bool isRelative;
        public bool isFrom;
        public bool isIndependentUpdate = false;    
        public bool autoKill = true;

        public bool isActive = true;
        public bool isValid;
        public Component target;
        public DOTweenAnimationType animationType;
        public bool autoPlay = true;

        public float endValueFloat;
        public Vector3 endValueV3;
        public Color endValueColor = new Color(1, 1, 1, 1);
        public string endValueString = "";
        public Rect endValueRect = new Rect(0, 0, 0, 0);

        public bool optionalBool0;
        public float optionalFloat0;
        public int optionalInt0;
        public RotateMode optionalRotationMode = RotateMode.Fast;
        public ScrambleMode optionalScrambleMode = ScrambleMode.None;
        public string optionalString;



        void Awake()
        {
            if (!isActive || !isValid)
            {
                return;
            }
            CreateTween();

        }

        void Start()
        {
            StartCoroutine(OnInit());
        }


        IEnumerator OnInit()
        {
            if (isCloseAllButton)
            {
                btns = GetComponentsInChildren<Button>();
                if (btns.Length < 1)
                {
                    MyLog.Red("下面都没有 Button 按钮，开启这个选项干嘛");
                }
            }
            yield return 0;
        }


        void OnDestroy()
        {
            if (tween != null && tween.IsActive()) tween.Kill();
            tween = null;
        }


        private void OnPlaying()
        {
            MyLog.Red("一直运行？");
        }

        public void CreateTween()
        {
            if (target == null)
            {
                Debug.LogWarning(
                    string.Format(
                        "{0} :: This tween's target is NULL, because the animation was created with a DOTween Pro version older than 0.9.255. To fix this, exit Play mode then simply select this object, and it will update automatically",
                        this.gameObject.name), this.gameObject);
                return;
            }

            Type t = target.GetType();

            #region switch 分支搞事

            switch (animationType)
            {
                case DOTweenAnimationType.None:
                    break;
                case DOTweenAnimationType.Move:
                    if (t.IsSameOrSubclassOf(typeof(RectTransform)))
                        tween = ((RectTransform) target).DOAnchorPos3D(endValueV3, duration, optionalBool0);
                    else if (t.IsSameOrSubclassOf(typeof(Transform)))
                        tween = ((Transform) target).DOMove(endValueV3, duration, optionalBool0);
                    else if (t.IsSameOrSubclassOf(typeof(Rigidbody2D)))
                        tween = ((Rigidbody2D) target).DOMove(endValueV3, duration, optionalBool0);
                    else if (t.IsSameOrSubclassOf(typeof(Rigidbody)))
                        tween = ((Rigidbody) target).DOMove(endValueV3, duration, optionalBool0);
                    break;
                case DOTweenAnimationType.LocalMove:
                    tween = transform.DOLocalMove(endValueV3, duration, optionalBool0);
                    break;
                case DOTweenAnimationType.Rotate:
                    if (t.IsSameOrSubclassOf(typeof(Transform)))
                        tween = ((Transform) target).DORotate(endValueV3, duration, optionalRotationMode);
                    else if (t.IsSameOrSubclassOf(typeof(Rigidbody2D)))
                        tween = ((Rigidbody2D) target).DORotate(endValueFloat, duration);
                    else if (t.IsSameOrSubclassOf(typeof(Rigidbody)))
                        tween = ((Rigidbody) target).DORotate(endValueV3, duration, optionalRotationMode);
                    break;
                case DOTweenAnimationType.LocalRotate:
                    tween = transform.DOLocalRotate(endValueV3, duration, optionalRotationMode);
                    break;
                case DOTweenAnimationType.Scale:
                    tween = transform.DOScale(
                        optionalBool0 ? new Vector3(endValueFloat, endValueFloat, endValueFloat) : endValueV3,
                        duration);
                    break;
                case DOTweenAnimationType.Color:
                    isRelative = false;
                    if (t.IsSameOrSubclassOf(typeof(SpriteRenderer)))
                        tween = ((SpriteRenderer) target).DOColor(endValueColor, duration);
                    else if (t.IsSameOrSubclassOf(typeof(Renderer)))
                        tween = ((Renderer) target).material.DOColor(endValueColor, duration);
                    else if (t.IsSameOrSubclassOf(typeof(Image)))
                        tween = ((Image) target).DOColor(endValueColor, duration);
                    else if (t.IsSameOrSubclassOf(typeof(Text)))
                        tween = ((Text) target).DOColor(endValueColor, duration);
#if DOTWEEN_TK2D
                else if (t.IsSameOrSubclassOf(typeof(tk2dTextMesh))) tween =
((tk2dTextMesh)target).DOColor(endValueColor, duration);
                else if (t.IsSameOrSubclassOf(typeof(tk2dBaseSprite))) tween =
((tk2dBaseSprite)target).DOColor(endValueColor, duration);
//                c = this.GetComponent<tk2dBaseSprite>();
//                if (c != null) {
//                   tween = ((tk2dBaseSprite)c).DOColor(endValueColor, duration);
//                    goto SetupTween;
//                }
#endif
#if DOTWEEN_TMP
                else if (t.IsSameOrSubclassOf(typeof(TextMeshProUGUI))) tween =
((TextMeshProUGUI)target).DOColor(endValueColor, duration);
                else if (t.IsSameOrSubclassOf(typeof(TextMeshPro))) tween =
((TextMeshPro)target).DOColor(endValueColor, duration);
//                c = this.GetComponent<TextMeshPro>();
//                if (c != null) {
//                   tween = ((TextMeshPro)c).DOColor(endValueColor, duration);
//                    goto SetupTween;
//                }
//                c = this.GetComponent<TextMeshProUGUI>();
//                if (c != null) {
//                   tween = ((TextMeshProUGUI)c).DOColor(endValueColor, duration);
//                    goto SetupTween;
//                }
#endif
                    break;
                case DOTweenAnimationType.Fade:
                    isRelative = false;
                    if (t.IsSameOrSubclassOf(typeof(SpriteRenderer)))
                        tween = ((SpriteRenderer) target).DOFade(endValueFloat, duration);
                    else if (t.IsSameOrSubclassOf(typeof(Renderer)))
                        tween = ((Renderer) target).material.DOFade(endValueFloat, duration);
                    else if (t.IsSameOrSubclassOf(typeof(Image)))
                        tween = ((Image) target).DOFade(endValueFloat, duration);
                    else if (t.IsSameOrSubclassOf(typeof(Text)))
                        tween = ((Text) target).DOFade(endValueFloat, duration);
#if DOTWEEN_TK2D
                else if (t.IsSameOrSubclassOf(typeof(tk2dTextMesh))) tween =
((tk2dTextMesh)target).DOFade(endValueFloat, duration);
                else if (t.IsSameOrSubclassOf(typeof(tk2dBaseSprite))) tween =
((tk2dBaseSprite)target).DOFade(endValueFloat, duration);
//                c = this.GetComponent<tk2dBaseSprite>();
//                if (c != null) {
//                   tween = ((tk2dBaseSprite)c).DOFade(endValueFloat, duration);
//                    goto SetupTween;
//                }
#endif
#if DOTWEEN_TMP
                else if (t.IsSameOrSubclassOf(typeof(TextMeshProUGUI))) tween =
((TextMeshProUGUI)target).DOFade(endValueFloat, duration);
                else if (t.IsSameOrSubclassOf(typeof(TextMeshPro))) tween =
((TextMeshPro)target).DOFade(endValueFloat, duration);
//                c = this.GetComponent<TextMeshPro>();
//                if (c != null) {
//                   tween = ((TextMeshPro)c).DOFade(endValueFloat, duration);
//                    goto SetupTween;
//                }
//                c = this.GetComponent<TextMeshProUGUI>();
//                if (c != null) {
//                   tween = ((TextMeshProUGUI)c).DOFade(endValueFloat, duration);
//                    goto SetupTween;
//                }
#endif
                    break;
                case DOTweenAnimationType.Text:
                    if (t.IsSameOrSubclassOf(typeof(Text)))
                        tween = ((Text) target).DOText(endValueString, duration, optionalBool0, optionalScrambleMode,
                            optionalString);
#if DOTWEEN_TK2D
                else if (t.IsSameOrSubclassOf(typeof(tk2dTextMesh))) tween =
((tk2dTextMesh)target).DOText(endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
//                c = this.GetComponent<tk2dTextMesh>();
//                if (c != null) {
//                   tween = ((tk2dTextMesh)c).DOText(endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
//                    goto SetupTween;
//                }
#endif
#if DOTWEEN_TMP
                else if (t.IsSameOrSubclassOf(typeof(TextMeshProUGUI))) tween =
((TextMeshProUGUI)target).DOText(endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
                else if (t.IsSameOrSubclassOf(typeof(TextMeshPro))) tween =
((TextMeshPro)target).DOText(endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
//                c = this.GetComponent<TextMeshPro>();
//                if (c != null) {
//                   tween = ((TextMeshPro)c).DOText(endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
//                    goto SetupTween;
//                }
//                c = this.GetComponent<TextMeshProUGUI>();
//                if (c != null) {
//                   tween = ((TextMeshProUGUI)c).DOText(endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
//                    goto SetupTween;
//                }
#endif
                    break;
                case DOTweenAnimationType.PunchPosition:
                    if (t.IsSameOrSubclassOf(typeof(RectTransform)))
                        tween = ((RectTransform) target).DOPunchAnchorPos(endValueV3, duration, optionalInt0,
                            optionalFloat0, optionalBool0);
                    else if (t.IsSameOrSubclassOf(typeof(Transform)))
                        tween = ((Transform) target).DOPunchPosition(endValueV3, duration, optionalInt0, optionalFloat0,
                            optionalBool0);
                    break;
                case DOTweenAnimationType.PunchScale:
                    tween = transform.DOPunchScale(endValueV3, duration, optionalInt0, optionalFloat0);
                    break;
                case DOTweenAnimationType.PunchRotation:
                    tween = transform.DOPunchRotation(endValueV3, duration, optionalInt0, optionalFloat0);
                    break;
                case DOTweenAnimationType.ShakePosition:
                    if (t.IsSameOrSubclassOf(typeof(RectTransform)))
                        tween = ((RectTransform) target).DOShakeAnchorPos(duration, endValueV3, optionalInt0,
                            optionalFloat0, optionalBool0);
                    if (t.IsSameOrSubclassOf(typeof(Transform)))
                        tween = ((Transform) target).DOShakePosition(duration, endValueV3, optionalInt0, optionalFloat0,
                            optionalBool0);
                    break;
                case DOTweenAnimationType.ShakeScale:
                    tween = transform.DOShakeScale(duration, endValueV3, optionalInt0, optionalFloat0);
                    break;
                case DOTweenAnimationType.ShakeRotation:
                    tween = transform.DOShakeRotation(duration, endValueV3, optionalInt0, optionalFloat0);
                    break;
                case DOTweenAnimationType.CameraAspect:
                    tween = ((Camera) target).DOAspect(endValueFloat, duration);
                    break;
                case DOTweenAnimationType.CameraBackgroundColor:
                    tween = ((Camera) target).DOColor(endValueColor, duration);
                    break;
                case DOTweenAnimationType.CameraFieldOfView:
                    tween = ((Camera) target).DOFieldOfView(endValueFloat, duration);
                    break;
                case DOTweenAnimationType.CameraOrthoSize:
                    tween = ((Camera) target).DOOrthoSize(endValueFloat, duration);
                    break;
                case DOTweenAnimationType.CameraPixelRect:
                    tween = ((Camera) target).DOPixelRect(endValueRect, duration);
                    break;
                case DOTweenAnimationType.CameraRect:
                    tween = ((Camera) target).DORect(endValueRect, duration);
                    break;
            }
            #endregion


            if (tween == null) return;

            if (isFrom)
            {
                ((Tweener) tween).From(isRelative);
            }
            else
            {
                tween.SetRelative(isRelative);
            }
            tween.SetTarget(this.gameObject).SetDelay(delay).SetLoops(loops, loopType).SetAutoKill(autoKill)
                .OnKill(() => tween = null);
            if (easeType == Ease.INTERNAL_Custom) tween.SetEase(easeCurve);
            else tween.SetEase(easeType);
            if (!string.IsNullOrEmpty(id)) tween.SetId(id);
            tween.SetUpdate(isIndependentUpdate);

            if (hasOnStart)
            {
                if (onStart != null) tween.OnStart(onStart.Invoke);
            }
            else onStart = null;
            if (hasOnPlay)
            {
                if (onPlay != null) tween.OnPlay(onPlay.Invoke);
            }
            else onPlay = null;
            if (hasOnUpdate)
            {
                if (onUpdate != null) tween.OnUpdate(onUpdate.Invoke);
            }
            else onUpdate = null;
            if (hasOnStepComplete)
            {
                if (onStepComplete != null) tween.OnStepComplete(onStepComplete.Invoke);
            }
            else onStepComplete = null;
            if (hasOnComplete)
            {
                if (onComplete != null) tween.OnComplete(onComplete.Invoke);
            }
            else onComplete = null;

            if (autoPlay) tween.Play();
            else tween.Pause();



        }


        public override void DOPlay()
        {
            DOTween.Play(this.gameObject);
        }

        public override void DOPlayBackwards()
        {
            DOTween.PlayBackwards(this.gameObject);
            if (isCloseAllButton && null!= btns && btns.Length>0)
            {
                StartCoroutine(SetCloseButton());
            }
            
        }

        public override void DOPlayForward()
        {
            DOTween.PlayForward(this.gameObject);
            if (isCloseAllButton && null != btns && btns.Length > 0)
            {

                StartCoroutine(SetCloseButton());
            }
        }



        IEnumerator SetCloseButton()
        {
            foreach (Button button in btns)
            {
                button.interactable = false;
            }
            yield return new WaitForSeconds(duration);

            foreach (Button button in btns)
            {
                button.interactable = true;
            }
        }

        public override void DOPause()
        {
            DOTween.Pause(this.gameObject);
        }

        public override void DOTogglePause()
        {
            DOTween.TogglePause(this.gameObject);
        }

        public override void DORewind()
        {
            _playCount = -1;
            // Rewind using Components order (in case there are multiple animations on the same property)
            DOTweenAnimation[] anims = this.gameObject.GetComponents<DOTweenAnimation>();
            for (int i = anims.Length - 1; i > -1; --i)
            {
                Tween t = anims[i].tween;
                if (t != null && t.IsInitialized()) anims[i].tween.Rewind();
            }
            // DOTween.Rewind(this.gameObject);
        }

        /// <summary>
        /// Restarts the tween
        /// </summary>
        /// <param name="fromHere">If TRUE, re-evaluates the tween's start and end values from its current position.
        /// Set it to TRUE when spawning the same DOTweenAnimation in different positions (like when using a pooling system)</param>
        public override void DORestart(bool fromHere = false)
        {
            _playCount = -1;
            if (tween == null)
            {
                if (Debugger.logPriority > 1) Debugger.LogNullTween(tween);
                return;
            }
            if (fromHere && isRelative) ReEvaluateRelativeTween();
            DOTween.Restart(this.gameObject);
        }

        public override void DOComplete()
        {
            DOTween.Complete(this.gameObject);
        }

        public override void DOKill()
        {
            DOTween.Kill(this.gameObject);
            tween = null;
        }


        public void DOPlayById(string id)
        {
            DOTween.Play(this.gameObject, id);
        }

        public void DOPlayAllById(string id)
        {
            DOTween.Play(id);
        }

        public void DOPlayNext()
        {
            DOTweenAnimation[] anims = this.GetComponents<DOTweenAnimation>();
            while (_playCount < anims.Length - 1)
            {
                _playCount++;
                DOTweenAnimation anim = anims[_playCount];
                if (anim != null && anim.tween != null && !anim.tween.IsPlaying() && !anim.tween.IsComplete())
                {
                    anim.tween.Play();
                    break;
                }
            }
        }

        public void DORewindAndPlayNext()
        {
            _playCount = -1;
            DOTween.Rewind(this.gameObject);
            DOPlayNext();
        }

        public void DORestartById(string id)
        {
            _playCount = -1;
            DOTween.Restart(this.gameObject, id);
        }

        public void DORestartAllById(string id)
        {
            _playCount = -1;
            DOTween.Restart(id);
        }

        public List<Tween> GetTweens()
        {
            return DOTween.TweensByTarget(this.gameObject);
        }



        #region 私有

        int _playCount = -1; // Used when calling DOPlayNext

        // Re-evaluate relative position of path
        void ReEvaluateRelativeTween()
        {
            if (animationType == DOTweenAnimationType.Move)
            {
                ((Tweener) tween).ChangeEndValue(transform.position + endValueV3, true);
            }
            else if (animationType == DOTweenAnimationType.LocalMove)
            {
                ((Tweener) tween).ChangeEndValue(transform.localPosition + endValueV3, true);
            }
        }

        #endregion


    }

    public static class DOTweenAnimationExtensions
    {
        public static bool IsSameOrSubclassOf(this Type t, Type tBase)
        {
            return t.IsSubclassOf(tBase) || t == tBase;
        }
    }
}