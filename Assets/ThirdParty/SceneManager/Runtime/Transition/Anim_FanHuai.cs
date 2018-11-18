using UnityEngine;
using System.Collections.Generic;
using PSPUtil.Attribute;

public class Anim_FanHuai : Base_JumpSceneAnim                                 // 方块掉落的场景动画
{

    [MyHead("方块的像素大小")]
    public Vector2 preferredTileSize = new Vector2(100, 100);

    [MyHead("一个方块落下时间")]
    public float tileFallTime = 1f;

    [MyHead("方块和它下面的方块之间的最小延迟")]
    public float minDelayBetweenTiles = 0.01f;

    [MyHead("方块和它下面的方块之间的最大延迟")]
    public float maxDelayBetweenTiles = 0.5f;



    public override void OnReady2Do()                         // 准备
    {
        base.OnReady2Do();
        if (material == null)
        {
            material = new Material(Shader.Find("Scene Manager/Tetris Effect"));
            material.SetTexture("_Background",Texture2D.blackTexture);
        }

        duration = 0;
        columns = Mathf.FloorToInt(Screen.width / TransitionUtils.ToAbsoluteSize(preferredTileSize.x, Screen.width));
        rows = Mathf.FloorToInt(Screen.height / TransitionUtils.ToAbsoluteSize(preferredTileSize.y, Screen.height));
        actualTileSize = new Vector2(1f / columns, 1f / rows);

        tiles = new List<Tile>(columns * rows);
        for (int x = 0; x < columns; x++)
        {
            float startTime = 0;
            for (int y = 0; y < rows; y++)
            {
                startTime += UnityEngine.Random.Range(minDelayBetweenTiles, maxDelayBetweenTiles);
                tiles.Add(new Tile(x, y,
                    new Vector2(x * actualTileSize.x, y * actualTileSize.y + (IsOut ? 0 : 1)),
                    startTime));
                duration = Mathf.Max(duration, startTime);
            }
        }

        duration += tileFallTime;
    }

    public override bool OnProcessAnim(float elapsedTime)           // 动画进度
    {
        effectTime = elapsedTime;
        return elapsedTime < duration;
    }


    protected override void OnLastRenderer2Do()                  // 渲染
    {
        base.OnLastRenderer2Do();
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.LoadIdentity();

        DrawBackground();
        DrawTiles();

        GL.PopMatrix();
    }



    #region 私有

    private Material material;
    private Vector2 actualTileSize; // relative screen size: 0 <= size <= 1
    private int columns;
    private int rows;
    private float duration;
    private List<Tile> tiles;
    private float effectTime;


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
            GL.Vertex3(0, 1, 0);
            GL.TexCoord3(1, 1, 0);
            GL.Vertex3(1, 1, 0);
            GL.TexCoord3(1, 0, 0);
            GL.Vertex3(1, 0, 0);
            GL.End();
        }
    }

    private void DrawTiles()
    {
        material.SetFloat("_BlendMode", 1);
        for (var i = 0; i < material.passCount; ++i)
        {
            material.SetPass(i);
            GL.Begin(GL.QUADS);

            foreach (Tile tile in tiles)
            {
                float tileProgress = TransitionUtils.SmoothProgress(tile.startTime, tileFallTime, effectTime);
                Vector2 position = tile.position - Vector2.up * tileProgress; // move the tile down

                if (position.y < 1 && position.y >= (-actualTileSize.y))
                {
                    GL.TexCoord3(tile.column * actualTileSize.x, tile.row * actualTileSize.y, 0);
                    GL.Vertex3(position.x, position.y, 0);
                    GL.TexCoord3(tile.column * actualTileSize.x, (tile.row + 1) * actualTileSize.y, 0);
                    GL.Vertex3(position.x, position.y + actualTileSize.y, 0);
                    GL.TexCoord3((tile.column + 1) * actualTileSize.x, (tile.row + 1) * actualTileSize.y, 0);
                    GL.Vertex3(position.x + actualTileSize.x, position.y + actualTileSize.y, 0);
                    GL.TexCoord3((tile.column + 1) * actualTileSize.x, tile.row * actualTileSize.y, 0);
                    GL.Vertex3(position.x + actualTileSize.x, position.y, 0);
                }
            }
            GL.End();
        }
    }


    struct Tile
    {
        public int column;
        public int row;
        public Vector2 position;
        public float startTime;

        public Tile(int column, int row, Vector2 position, float startTime)
        {
            this.column = column;
            this.row = row;
            this.position = position;
            this.startTime = startTime;
        }
    }


    protected override void OnDestroy2Do()
    {
        base.OnDestroy2Do();
        material = null;
    }



    #endregion



}