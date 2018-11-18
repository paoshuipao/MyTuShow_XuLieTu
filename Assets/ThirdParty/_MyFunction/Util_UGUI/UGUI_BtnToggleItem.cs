using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Button))]
public class UGUI_BtnToggleItem : MonoBehaviour
{

    [ReadOnly]
    [MyHead("这个 Item 的索引")]
    public ushort ItemIndex;


    [MyHead("是否勾中这个 Item")]
    public bool IsOn;


    [Title("选择这个 Item 要显示的 GameObject")]
    public GameObject[] l_On;



    public void ChooseThis()            // 选中这个
    {
        if (null!= l_On && l_On.Length>0)
        {
            foreach (GameObject go in l_On)
            {
                go.SetActive(true);
            }
        }
        IsOn = true;
    }

    public void NoChooseThis()            // 不是选中这个啦
    {
        if (null != l_On && l_On.Length > 0)
        {
            foreach (GameObject go in l_On)
            {
                go.SetActive(false);
            }
        }
        IsOn = false;

    }





}
