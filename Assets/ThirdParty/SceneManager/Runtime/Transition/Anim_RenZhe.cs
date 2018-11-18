using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using UnityEngine;

public class Anim_RenZhe : Base_JumpSceneAnim                                // 忍者场景动画
{

    [MyHead("刀片 材质")]
    public Material bladeMaterial;

    [MyHead("切一刀要用多长时间")]
    public float cutDuration = 0.3f;

    [MyHead("两刀相隔时间")]
    public float delayBetweenCuts = 0.5f;


    [MyHead("掉下来需要用多长时间")]
    public float pieceFallTime = 1f;

    [MyHead("那个刀片的大小像素")]
    public float bladeSize = 128;

    public override void OnReady2Do()                         // 准备
    {
        base.OnReady2Do();
        if (material == null)
        {
            material = new Material(Shader.Find("Scene Manager/Ninja Effect"));
            material.SetTexture("_Background", Texture2D.blackTexture);
        }

        duration = 2 * (cutDuration + delayBetweenCuts) + pieceFallTime;

        firstCutStart = new Vector3(0, Screen.height * .2f, 0);
        firstCutEnd = new Vector3(Screen.width, Screen.height * .4f, 0);
        secondCutStart = new Vector3(Screen.width, Screen.height * .6f, 0);
        secondCutEnd = new Vector3(0, Screen.height * .9f, 0);
    }

    public override bool OnProcessAnim(float elapsedTime)           // 动画播放进度
    {
        effectTime = elapsedTime;
        return elapsedTime < duration;
    }

    protected override void OnLastRenderer2Do()                  // 最后一帧 屏幕怎么渲染
    {
        base.OnLastRenderer2Do();
        GL.PushMatrix();
        GL.LoadPixelMatrix();
        GL.LoadIdentity();

        DrawBackground();
        DrawPieces(effectTime);
        DrawBlade(effectTime);

        GL.PopMatrix();
    }



    #region 私有

    private Vector3 firstCutStart;
    private Vector3 firstCutEnd;
    private Vector3 secondCutStart;
    private Vector3 secondCutEnd;

    private Material material;
    private float duration;
    private float effectTime;





    private void DrawBackground()
    {
        material.SetFloat("_BlendMode", IsOut ? 0 : 1);
        for (var i = 0; i < material.passCount; ++i)
        {
            material.SetPass(i);
            GL.Begin(GL.QUADS);
            GL.TexCoord3(0, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord3(0, 1, 0);
            GL.Vertex3(0, Screen.height, 0);
            GL.TexCoord3(1, 1, 0);
            GL.Vertex3(Screen.width, Screen.height, 0);
            GL.TexCoord3(1, 0, 0);
            GL.Vertex3(Screen.width, 0, 0);
            GL.End();
        }
    }

    private void DrawPieces(float time)
    {
        material.SetFloat("_BlendMode", IsOut ? 1 : 0);

        for (var i = 0; i < material.passCount; ++i)
        {
            material.SetPass(i);
            GL.Begin(GL.QUADS);

            Vector3 progress = new Vector3(0,
                -Screen.height * TransitionUtils.SmoothProgress(cutDuration, pieceFallTime, time), 0);
            GL.TexCoord3(0, 0, 0);
            GL.Vertex3(0, progress.y, 0);
            GL.TexCoord3(0, .2f, 0);
            GL.Vertex(firstCutStart + progress);
            GL.TexCoord3(1, .4f, 0);
            GL.Vertex(firstCutEnd + progress);
            GL.TexCoord3(1, 0, 0);
            GL.Vertex3(Screen.width, progress.y, 0);

            progress = new Vector3(0,
                -Screen.height *
                TransitionUtils.SmoothProgress(2 * cutDuration + delayBetweenCuts, pieceFallTime, time), 0);
            GL.TexCoord3(0, .2f, 0);
            GL.Vertex(firstCutStart + progress);
            GL.TexCoord3(0, .9f, 0);
            GL.Vertex(secondCutEnd + progress);
            GL.TexCoord3(1, .6f, 0);
            GL.Vertex(secondCutStart + progress);
            GL.TexCoord3(1, .4f, 0);
            GL.Vertex(firstCutEnd + progress);

            progress = new Vector3(0,
                -Screen.height *
                TransitionUtils.SmoothProgress(2 * cutDuration + 2 * delayBetweenCuts, pieceFallTime, time), 0);
            GL.TexCoord3(0, .9f, 0);
            GL.Vertex(secondCutEnd + progress);
            GL.TexCoord3(0, 1, 0);
            GL.Vertex3(0, Screen.height + progress.y, 0);
            GL.TexCoord3(1, 1, 0);
            GL.Vertex3(Screen.width, Screen.height + progress.y, 0);
            GL.TexCoord3(1, .6f, 0);
            GL.Vertex(secondCutStart + progress);

            GL.End();
        }
    }

    private void DrawBlade(float time)
    {
        float cutProgress = TransitionUtils.Progress(0, cutDuration, time);
        if (cutProgress > 0 && cutProgress < 1)
        {
            DrawBlade(firstCutStart, firstCutEnd, cutProgress, false);
        }

        cutProgress = TransitionUtils.Progress(cutDuration + delayBetweenCuts, cutDuration, time);
        if (cutProgress > 0 && cutProgress < 1)
        {
            DrawBlade(secondCutEnd, secondCutStart, 1 - cutProgress, true);
        }
    }

    private void DrawBlade(Vector3 cutStart, Vector3 cutEnd, float progress, bool flip)
    {
        Vector3 direction = cutEnd - cutStart;

        Vector3 directionNormalized = direction.normalized;
        Vector3 normal = Vector3.Cross(direction, Vector3.back).normalized;
        Vector3 pos1 = cutStart + direction * progress;
        Vector3 pos2 = pos1 + normal * bladeSize;
        Vector3 pos3 = pos2 + directionNormalized * bladeSize;
        Vector3 pos4 = pos1 + directionNormalized * bladeSize;

        for (var i = 0; i < bladeMaterial.passCount; ++i)
        {
            bladeMaterial.SetPass(i);
            GL.Begin(GL.QUADS);

            GL.TexCoord3(flip ? 1 : 0, 0, 0);
            GL.Vertex(pos1);
            GL.TexCoord3(flip ? 1 : 0, 1, 0);
            GL.Vertex(pos2);
            GL.TexCoord3(flip ? 0 : 1, 1, 0);
            GL.Vertex(pos3);
            GL.TexCoord3(flip ? 0 : 1, 0, 0);
            GL.Vertex(pos4);

            GL.End();
        }
    }


    protected override void OnDestroy2Do()
    {
        base.OnDestroy2Do();
        material = null;
    }



    #endregion




}