using UnityEngine;


[ExecuteInEditMode]
public class UGUI_JiaoZhengCollider : MonoBehaviour          // 纠正 BoxCollider2D
{

    private RectTransform RT
    {
        get
        {
            if (null == mRT)
            {
                mRT = transform as RectTransform;
            }
            return mRT;
        }
    }

    private BoxCollider2D Collider
    {
        get
        {
            if (null == mCollider2D)
            {
                mCollider2D = GetComponent<BoxCollider2D>();
            }
            return mCollider2D;
        }
    }


    private BoxCollider2D mCollider2D;
    private RectTransform mRT;

    void Update()
    {

        Vector2 size = RT.sizeDelta;
        Collider.size = size;
        float x = RT.pivot.x;
        float y = RT.pivot.y;

        x = (x - 0.5f) * -1;
        y = (y - 0.5f) * -1;
        if (size == Vector2.zero)
        {
            Collider.enabled = false;
        }
        else
        {
            Collider.enabled = true;
            Collider.offset = new Vector2(size.x * x,size.y *y);
        }

    }



}
