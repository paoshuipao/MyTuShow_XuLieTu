using PSPUtil.Attribute;
using UnityEngine;

/// <summary>
///一行一行的百叶窗动画
/// </summary>
public class Anim_OneLineOneLine : Base_JumpSceneAnim
{

    public float duration = 1f;                                  // 持续时间

    [MyHead("每行翻转的时间")]
    [Range(0.1f,0.9f)]
    public float BlindsTime = 0.5f;           
    
    [MyHead("翻转的高度")]
    [Range(0.1f,0.9f)]
    public float BlindsHeight = 0.1f;




    public override void OnReady2Do()
    {
        int preferredHeightInPixel = TransitionUtils.ToAbsoluteSize(BlindsHeight, Screen.height);
        numberOfBlinds = Mathf.FloorToInt(Screen.height / preferredHeightInPixel);
        actualBlindsHeight = (float) Screen.height / (float) numberOfBlinds;
        blindsStartOffset = (duration - BlindsTime) / (float) numberOfBlinds;
    }

    public override bool OnProcessAnim(float elapsedTime)
    {
        effectTime = elapsedTime;
        if (!IsOut)
        {
            effectTime = duration - effectTime;
        }
        return elapsedTime < duration;
    }

    void OnGUI()
    {
        GUI.depth = 0;
        Color firstColor = GUI.color;
        GUI.color = Color.black;
        for (int i = 0; i < numberOfBlinds; i++)
        {
            float progress = TransitionUtils.SmoothProgress(i * blindsStartOffset, BlindsTime, effectTime);
            float visibleHeight = actualBlindsHeight * progress;
            GUI.DrawTexture(new Rect(0, i * actualBlindsHeight + (actualBlindsHeight - visibleHeight) / 2f, Screen.width,  visibleHeight), Texture2D.whiteTexture);
        }
        GUI.color = firstColor;


    }


    #region 私有

    private float effectTime;
    private float blindsStartOffset;
    private int numberOfBlinds;
    private float actualBlindsHeight;


    #endregion



}