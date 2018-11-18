using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TopTipItem : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{

    public UGUI_Grid mGrid;
    public bool IsAllUse = false;



    private GameObject go_TopTip;
    private Text tx_Size;

    void Start()
    {
        go_TopTip = transform.Find("TopTip").gameObject;
        if (null!= mGrid)
        {
            Transform t = transform.Find("TopTip/TxTopTip");
            if (null != t)
            {
                tx_Size = t.GetComponent<Text>();
            }
            else
            {
                MyLog.Red("找不到 TopTip —— "+name);
            }

        }
        go_TopTip.SetActive(false);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Ctrl_UserInfo.Instance.IsXuLieTuShowTip || IsAllUse)
        {
            go_TopTip.SetActive(true);
            if (null!= tx_Size)
            {
                tx_Size.text = mGrid.CallSize.x + "x" + mGrid.CallSize.y;
            }
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Ctrl_UserInfo.Instance.IsXuLieTuShowTip || IsAllUse)
        {
            go_TopTip.SetActive(false);
        }
       

    }





}
