using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("我的组件/UI/UGUI_Grid(Grid 表格)", 19)]
public class UGUI_Grid : MonoBehaviour 
{


    [MyHead("每 Item 多大")]
    public Vector2 CallSize = new Vector2(100, 100);

    [MyHead("相隔")]
    public Vector2 Spacing = new Vector2(5, 5);

    [MyHead("左边边框距离")]
    public float LeftPadding = 0;

    [MyHead("在这个范围内是显示的")]
    public Vector2 HidePosition = new Vector2(-7, 7);

    #region 私有


    void Reset()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(1, 1);
        rt.pivot = new Vector2(0.5f, 1);
        rt.anchoredPosition3D = Vector3.zero;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

    }


    private static readonly Vector2 ZERO_ONE = new Vector2(0, 1);

    #endregion



    void Update()
    {
        RectTransform mRT = transform as RectTransform;
        float width = mRT.rect.width;
        int hengCount = (int)(width / (CallSize.x + Spacing.x));    // 每行可以占几个
        int cout = transform.childCount;                            // 总共有几个 

        int shu = cout / hengCount;
        int yu = cout % hengCount;       // 如果有余数即竖多一行
        if (yu != 0)
        {
            shu++;
        }

        Vector2[] l_Position = new Vector2[shu * hengCount];

        int index = 0;
        for (int i = 0; i < shu; i++)
        {
            for (int j = 0; j < hengCount; j++)
            {
                l_Position[index] = new Vector2(LeftPadding + (CallSize.x + Spacing.x) * j, (CallSize.y + Spacing.y) * -i);
                index++;
            }
        }

        for (int i = 0; i < cout; i++)
        {
            RectTransform rt = transform.GetChild(i) as RectTransform;
            if (null == rt)
            {
                MyLog.Red("为什么为空？" + transform.GetChild(i));
                continue;
            }
            rt.anchorMin = ZERO_ONE;
            rt.anchorMax = ZERO_ONE;
            rt.pivot = ZERO_ONE;
            rt.sizeDelta = CallSize;
            rt.anchoredPosition = l_Position[i];
        }

        // 设置每个 Item 大小
        float height = (CallSize.y + Spacing.y) * shu;
        mRT.sizeDelta = new Vector2(0, height);

        // 隐藏
        if (Application.isPlaying)                          
        {
            for (int i = 0; i < mRT.childCount; i++)
            {
                if (mRT.GetChild(i).position.y > HidePosition.y)
                {
                    mRT.GetChild(i).gameObject.SetActive(false);
                }
                else if (mRT.GetChild(i).position.y < HidePosition.x)
                {
                    mRT.GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    mRT.GetChild(i).gameObject.SetActive(true);
                }
            }

        }

    }



}
