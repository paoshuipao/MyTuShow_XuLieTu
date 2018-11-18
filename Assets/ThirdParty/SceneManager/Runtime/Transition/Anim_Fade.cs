using UnityEngine;

/// <summary>
/// 淡出淡入动画
/// </summary>
public class Anim_Fade : Base_JumpSceneAnim
{

    public float duration = 1f;                                  // 持续时间


    private float progress;


    public override bool OnProcessAnim(float elapsedTime)
    {
        float effectTime = elapsedTime;
        if (IsOut ==false)
        {
            effectTime = duration - effectTime;
        }

        progress = TransitionUtils.SmoothProgress(0, duration, effectTime);

        return elapsedTime < duration;
    }



    void OnGUI()
    {
        GUI.depth = 0;
        Color c = GUI.color;
        GUI.color = new Color(0, 0, 0, progress);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        GUI.color = c;
    }




}