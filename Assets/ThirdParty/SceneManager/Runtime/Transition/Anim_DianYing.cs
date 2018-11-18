using PSPUtil.Attribute;
using UnityEngine;

public class Anim_DianYing : Base_JumpSceneAnim                                // 电影场景动画
{

    [Range(0.01f,0.4f)]
    [MyHead("上下黑幕落下大小的百分比")]
    public float borderSize = 0.15f;

    [MyHead("上下黑幕落下开始时间")]
    public float borderStartTime = 0;

    [MyHead("上下黑幕落下持续时间")]
    public float borderDuration = 1f;

    [MyHead("色调效果开始时间")]
    public float tintStartTime = 0.5f;

    [MyHead("色调效果持续时间")]
    public float tintDuration = 1f;

    [MyHead("开始淡出效果开始时间")]
    public float fadeOutStartTime = 2f;

    [MyHead("开始淡出效果持续时间")]
    public float fadeOutDuration = 1f;


    public override void OnReady2Do()                         // 准备
    {
        base.OnReady2Do();

        duration = fadeOutStartTime + fadeOutDuration;
        float borderSizeInPixel = TransitionUtils.ToAbsoluteSize(borderSize, Screen.height);
        actualBorderSize = borderSizeInPixel / Screen.height;
    }

    public override bool OnProcessAnim(float elapsedTime)           // 动画进度
    {
        float effectTime = elapsedTime;
        // invert direction 
        if (!IsOut)                                      // 如果是进入新场景了
        {
            effectTime = duration - effectTime;
        }

        borderProgress = TransitionUtils.SmoothProgress(borderStartTime, borderDuration, effectTime);
        tintProgress = TransitionUtils.SmoothProgress(tintStartTime, tintDuration, effectTime);
        fadeProgress = TransitionUtils.SmoothProgress(fadeOutStartTime, fadeOutDuration, effectTime);

        return elapsedTime < duration;
    }

    protected override void OnLastRenderer2Do()                  // 渲染
    {
        base.OnLastRenderer2Do();
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.LoadIdentity();

        DrawImage();
        DrawBorder();

        GL.PopMatrix();
    }

    #region 私有

    private Material tintMaterial;
    private Material backMaterial;


    private float actualBorderSize;
    private float duration;
    private float borderProgress;
    private float tintProgress;
    private float fadeProgress;


    private Material TintMaterial
    {
        get
        {
            if (tintMaterial == null)
            {
                tintMaterial = new Material(Shader.Find("Scene Manager/Cinema Effect"));
            }
            return tintMaterial;
        }
    }

    private Material BackMaterial
    {
        get
        {
            if (backMaterial == null)
            {
                backMaterial = new Material(Shader.Find("Unlit/Texture"));
                backMaterial.mainTexture = Texture2D.blackTexture;
            }
            return backMaterial;
        }
    }



    private void DrawImage()
    {
        TintMaterial.SetFloat("_TintOffset", tintProgress);
        TintMaterial.SetFloat("_FadeOffset", fadeProgress);
        for (var i = 0; i < TintMaterial.passCount; ++i)
        {
            TintMaterial.SetPass(i);
            GL.Begin(GL.QUADS);
            GL.TexCoord3(0, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord3(0, 1, 0);
            GL.Vertex3(0, 1, 0);
            GL.TexCoord3(1, 1, 0);
            GL.Vertex3(1, 1, 0);
            GL.TexCoord3(1, 0, 0);
            GL.Vertex3(1, 0, 0);
            GL.End();
        }
    }

    private void DrawBorder()
    {
        float height = actualBorderSize * borderProgress;
        if (height > 0)
        {
            for (var i = 0; i < BackMaterial.passCount; ++i)
            {
                BackMaterial.SetPass(i);
                GL.Begin(GL.QUADS);
                GL.TexCoord3(0, 0, 0);
                GL.Vertex3(0, 1 - height, 0);
                GL.TexCoord3(0, 1, 0);
                GL.Vertex3(0, 1, 0);
                GL.TexCoord3(1, 1, 0);
                GL.Vertex3(1, 1, 0);
                GL.TexCoord3(1, 0, 0);
                GL.Vertex3(1, 1 - height, 0);

                GL.TexCoord3(0, 0, 0);
                GL.Vertex3(0, 0, 0);
                GL.TexCoord3(0, 1, 0);
                GL.Vertex3(0, height, 0);
                GL.TexCoord3(1, 1, 0);
                GL.Vertex3(1, height, 0);
                GL.TexCoord3(1, 0, 0);
                GL.Vertex3(1, 0, 0);
                GL.End();
            }
        }
    }


    protected override void OnDestroy2Do()
    {
        base.OnDestroy2Do();
        tintMaterial = null;
        backMaterial = null;
    }


    #endregion
}