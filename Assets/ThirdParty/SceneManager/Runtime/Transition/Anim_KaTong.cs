using PSPUtil.Attribute;
using UnityEngine;

public class Anim_KaTong : Base_JumpSceneAnim                    // 卡通场景动画
{

    public float duration = 2;

    [MyHead("圆圆边缘颜色")]
    public Color borderColor = new Color(.5f, 0, 0, 1);
    [MyHead("中心点")]
    public Vector2 center = new Vector2(0.5f, 0.5f);




    public override void OnReady2Do()
    {
        base.OnReady2Do();
        if (material == null)
        {
            material = new Material(Shader.Find("Scene Manager/Cartoon Effect"));
            material.SetTexture("_Background", Texture2D.blackTexture);
        }

        Vector2 pixelCenter = new Vector2(TransitionUtils.ToAbsoluteSize(center.x, Screen.width),TransitionUtils.ToAbsoluteSize(center.y, Screen.height));

        Vector2 bottomLeftPath = pixelCenter - new Vector2(0, 0);
        Vector2 topLeftPath = pixelCenter - new Vector2(0, Screen.height);
        Vector2 topRightPath = pixelCenter - new Vector2(Screen.width, Screen.height);
        Vector2 bottomRightPath = pixelCenter - new Vector2(Screen.width, 0);

        length = Mathf.Max(bottomLeftPath.magnitude, topLeftPath.magnitude, topRightPath.magnitude, bottomRightPath.magnitude);
        material.SetFloat("_CenterX", pixelCenter.x);
        material.SetFloat("_CenterY", pixelCenter.y);

        material.SetColor("_BorderColor", borderColor);
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
        GL.LoadOrtho();
        GL.LoadIdentity();

        material.SetFloat("_Distance", length * (1 - progress));
        for (var i = 0; i < material.passCount; ++i)
        {
            material.SetPass(i);
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

        GL.PopMatrix();
    }



    #region 私有
    private Material material;
    private float length;
    private float progress;

    protected override void OnDestroy2Do()
    {
        base.OnDestroy2Do();
        material = null;
    }


    #endregion


}