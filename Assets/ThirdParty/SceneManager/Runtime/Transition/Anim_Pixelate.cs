using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using UnityEngine;

public class Anim_Pixelate : Base_JumpSceneAnim           // 像素化场景动画
{
    public float Duration = 2;

    [MyHead("像素的最大尺寸")]
    public float MaxBlockSize = 50;

    [MyHead("像素化效果的开始")]
    public float StartOffset = 0;

    [MyHead("开始淡化效果的时间是")]
    public float fadeStartOffset = 1.5f;

    [MyHead("淡化效果的持续时间")]
    public float fadeDuration = 0.5f;



    public override void OnReady2Do()                         // 准备工作
    {
        base.OnReady2Do();
        if (m_PixelateMaterial == null)
        {
            m_PixelateMaterial = new Material(Shader.Find("Scene Manager/Pixelate Effect"));
        }

        duration = Mathf.Max(StartOffset + Duration, fadeStartOffset + fadeDuration);
    }

    public override bool OnProcessAnim(float elapsedTime)           // While 控制动画播放时间
    {
        float effectTime = elapsedTime;
        if (!IsOut)
        {
            effectTime = duration - effectTime;
        }

        pixelateProgress = TransitionUtils.SmoothProgress(StartOffset, Duration, effectTime);
        fadeProgress = TransitionUtils.SmoothProgress(fadeStartOffset, fadeDuration, effectTime);

        return elapsedTime < duration;
    }

    protected override void OnLastRenderer2Do()                  // 最后一帧调用
    {
        base.OnLastRenderer2Do();
        GL.PushMatrix();                                   //把材质压在堆栈上
        GL.LoadOrtho();                                    //固定设置
        GL.LoadIdentity();                                 //固定设置
        DrawImage();
        GL.PopMatrix();                                    //堆栈弹出读取该材质
    }

    private void DrawImage()
    {
        m_PixelateMaterial.SetFloat("_BlockSize", pixelateProgress * MaxBlockSize + 1);
        m_PixelateMaterial.SetFloat("_FadeOffset", fadeProgress);
        for (var i = 0; i < m_PixelateMaterial.passCount; ++i)
        {
            m_PixelateMaterial.SetPass(i);
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


    #region 私有


    private Material m_PixelateMaterial;
    private float duration;
    private float pixelateProgress;
    private float fadeProgress;

    protected override void OnDestroy2Do()
    {
        base.OnDestroy2Do();
        m_PixelateMaterial = null;
    }

    #endregion

}