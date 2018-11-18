using PSPUtil.Attribute;
using UnityEngine;

public class Anim_Rotate : Base_JumpSceneAnim                    // 旋转场景动画
{
    public float duration = 2;


    [MyHead("旋转角度")]
    public float angle = 360;



    public override void OnReady2Do()
    {
        base.OnReady2Do();
        if (material == null)
        {
            material = new Material(Shader.Find("Scene Manager/Newspaper Effect"));
            material.SetTexture("_Background",Texture2D.blackTexture);
        }
    }

    public override bool OnProcessAnim(float elapsedTime)
    {
        float effectTime = elapsedTime;
        // invert direction 
        if (!IsOut)
        {
            effectTime = duration - effectTime;
        }

        progress = TransitionUtils.SmoothProgress(0, duration, effectTime);

        return elapsedTime < duration;
    }

    protected override void OnLastRenderer2Do()
    {
        base.OnLastRenderer2Do();
        GL.PushMatrix();
        // pixel matrix instead of orthogonal to maintain aspect ratio during rotation
        GL.LoadPixelMatrix();
        GL.LoadIdentity();

        DrawBackground();
        DrawImage();

        GL.PopMatrix();
    }


    #region 私有

    private Material material;
    private float progress;

    private void DrawBackground()
    {
        material.SetFloat("_BlendMode", 0);
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

    private void DrawImage()
    {
        material.SetFloat("_BlendMode", 1);

        float dx = Screen.width / 2f;
        float dy = Screen.height / 2f;

        Quaternion rotation = Quaternion.AngleAxis(progress * angle, Vector3.forward);
        GL.MultMatrix(Matrix4x4.TRS(new Vector3(dx, dy, 0), rotation, Vector3.one * (1 - progress)));
        for (var i = 0; i < material.passCount; ++i)
        {
            material.SetPass(i);
            GL.Begin(GL.QUADS);
            GL.TexCoord3(0, 0, 0);
            GL.Vertex3(-dx, -dy, 0);
            GL.TexCoord3(0, 1, 0);
            GL.Vertex3(-dx, dy, 0);
            GL.TexCoord3(1, 1, 0);
            GL.Vertex3(dx, dy, 0);
            GL.TexCoord3(1, 0, 0);
            GL.Vertex3(dx, -dy, 0);
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