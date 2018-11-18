using PSPUtil.Attribute;
using UnityEngine;

public class Anim_Tiles3D : Base_JumpSceneAnim                                 // 3D 翻转
{

    public float duration = 2f;

    [MyHead("翻转的方块像素大小")]
    public Vector2 preferredTileSize = new Vector2(100, 100);

    [MyHead("翻转的方块翻滚时间")]
    public float tilesFlipTime = 0.5f;



    public override void OnReady2Do()
    {
        base.OnReady2Do();
        if (material == null)
        {
            material = new Material(Shader.Find("Scene Manager/Tiles Effect"));
            material.SetTexture("_Backface", Texture2D.blackTexture);
            material.SetTexture("_Background", Texture2D.blackTexture);
        }

        topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, distance));

        bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, distance));

        width = bottomRight.x - topLeft.x;
        height = topLeft.y - bottomRight.y;

        columns = Mathf.FloorToInt(Screen.width / TransitionUtils.ToAbsoluteSize(preferredTileSize.x, Screen.width));
        rows = Mathf.FloorToInt(Screen.height / TransitionUtils.ToAbsoluteSize(preferredTileSize.y, Screen.height));

        // recalculate size to avoid clipped tiles
        actualTileSize = new Vector2(width / columns, height / rows);

        tileStartOffset = (duration - tilesFlipTime) / (columns + rows);
    }

    public override bool OnProcessAnim(float elapsedTime)
    {
        effectTime = elapsedTime;
        return elapsedTime < duration;
    }


    protected override void OnLastRenderer2Do()
    {
        base.OnLastRenderer2Do();
        GL.PushMatrix();
        DrawBackground();
        GL.Clear(true, false, Color.black);

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                float tileProgress = TransitionUtils.SmoothProgress((x + y) * tileStartOffset, tilesFlipTime, effectTime);
                DrawTile(x, y, tileProgress * 180);
            }
        }

        GL.PopMatrix();
    }



    #region 私有

    private Material material;
    private float distance = 10f;
    private Vector2 actualTileSize;
    private int columns;
    private int rows;
    private float tileStartOffset;
    private Vector3 topLeft;
    private Vector3 bottomRight;
    private float width;
    private float height;

    private float effectTime;

    private void DrawBackground()
    {
        material.SetFloat("_BlendMode", 0);
        GL.LoadOrtho();
        GL.LoadIdentity();

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
    }

    private void DrawTile(int xIndex, int yIndex, float progress)
    {
        material.SetFloat("_BlendMode", 1);
        float halfWidth = actualTileSize.x / 2f;
        float halfHeight = actualTileSize.y / 2f;

        float xOffset = actualTileSize.x * xIndex;
        float yOffset = actualTileSize.y * yIndex;
        float umin = xOffset / width;
        float umax = (xOffset + actualTileSize.x) / width;
        float vmin = (height - yOffset - actualTileSize.y) / height;
        float vmax = (height - yOffset) / height;

        GL.LoadProjectionMatrix(Camera.main.projectionMatrix);
        GL.LoadIdentity();

        Vector3 translation = new Vector3(topLeft.x + xOffset + halfWidth, topLeft.y - yOffset - halfHeight, -distance);
        Quaternion rotation = Quaternion.AngleAxis(progress + (IsOut ? 0 : 180), Vector3.up);
        GL.MultMatrix(Matrix4x4.TRS(translation, rotation, Vector3.one));

        for (var i = 0; i < material.passCount; ++i)
        {
            material.SetPass(i);
            GL.Begin(GL.QUADS);
            GL.TexCoord3(i == 1 ? umin : umax, vmin, 0);
            GL.Vertex3(-halfWidth, -halfHeight, 0);
            GL.TexCoord3(i == 1 ? umin : umax, vmax, 0);
            GL.Vertex3(-halfWidth, halfHeight, 0);
            GL.TexCoord3(i == 1 ? umax : umin, vmax, 0);
            GL.Vertex3(halfWidth, halfHeight, 0);
            GL.TexCoord3(i == 1 ? umax : umin, vmin, 0);
            GL.Vertex3(halfWidth, -halfHeight, 0);
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