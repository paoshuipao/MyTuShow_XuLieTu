using PSPUtil;
using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TopTipItem : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{

    public UGUI_Grid mGrid;

    [MyHead("是导入按钮就 true")]
    public bool isDaoRuBtn;


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

        if (isDaoRuBtn)
        {
            MyEventCenter.AddListener<ResultBean[],EDuoTuInfoType> (E_GameEvent.ShowDuoTuInfo, E_ShowDuoTuInfo);
        }

        go_TopTip.SetActive(false);
    }


    private bool isShow;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Ctrl_DaoRuInfo.Instance.IsXuLieTuShowTip)
        {
            isShow = true;
            go_TopTip.SetActive(true);
            if (null!= tx_Size)
            {
                tx_Size.text = mGrid.CallSize.x + "x" + mGrid.CallSize.y;
            }
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Ctrl_DaoRuInfo.Instance.IsXuLieTuShowTip)
        {
            isShow = false;
            go_TopTip.SetActive(false);
        }
    }

    private void E_ShowDuoTuInfo(ResultBean[] resultBeans,EDuoTuInfoType type)
    {
        if (isShow && go_TopTip.activeSelf)
        {
            go_TopTip.SetActive(false);
        }
    }




    void OnDestroy()
    {
        if (isDaoRuBtn)
        {
            MyEventCenter.RemoveListener<ResultBean[],EDuoTuInfoType>(E_GameEvent.ShowDuoTuInfo, E_ShowDuoTuInfo);
        }
    }






}
