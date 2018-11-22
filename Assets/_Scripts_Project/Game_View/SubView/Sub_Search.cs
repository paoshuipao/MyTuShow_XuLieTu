using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using PSPUtil;
using PSPUtil.Control;
using UnityEngine;
using UnityEngine.UI;

public class Sub_Search : SubUI 
{

    public void Show()
    {
        mUIGameObject.SetActive(true);
    }


    public void Close()
    {
        mUIGameObject.SetActive(false);
    }



    protected override void OnStart(Transform root)
    {

        MyEventCenter.AddListener(E_GameEvent.OnClickMouseLeftUp, E_OnClickMouseLeftUp);

        // 上
        mInputField = Get<InputField>("Top/InputField");
        AddButtOnClick("Top/BtnSearch", () =>
        {
            Btn_SureSearch(true);
        });
        anim_ErrorTip = Get<DOTweenAnimation>("ErrorTip");
        anim_SearchNull = Get<DOTweenAnimation>("SearchNullTip");
        AddInputOnEndEdit(mInputField, (str) =>            // 输入完，按下回车
        {
            Btn_SureSearch(false);
        });

        AddButtOnClick("Top/BtnClear", Btn_Clear);

        // 内容
        go_MoBanDuoTu = GetGameObject("Bottom/MoBan_DuoTu");
        rt_Contant = Get<RectTransform>("Bottom/Contant");



        // 历史
        go_Template = GetGameObject("Top/Histroy/Template");
        go_Template.SetActive(false);
        go_MoBanHistroy = GetGameObject("Top/Histroy/Template/Viewport/MoBan");
        rt_HistroyContant = Get<RectTransform>("Top/Histroy/Template/Viewport/Content");
        AddButtOnClick("Top/Histroy", Btn_Histroy);
    }

    
    #region 私有

    private string mCurrentInputStr;         // 当前搜索的字符


    // 上
    private InputField mInputField;
    private DOTweenAnimation anim_ErrorTip,anim_SearchNull;

    // 内容模版
    private GameObject go_MoBanDuoTu;
    private RectTransform rt_Contant;


    // 历史
    private readonly List<string> l_HistroyName = new List<string>();
    private readonly List<GameObject> l_HistroyGOItem = new List<GameObject>();
    private const ushort MaxHistroyCount = 6;
    private GameObject go_MoBanHistroy;
    private GameObject go_Template;
    private RectTransform rt_HistroyContant;


    public override string GetUIPathForRoot()
    {
        return "Right/EachContant/Search";
    }



    public override void OnEnable()
    {
    }

    public override void OnDisable()
    {
    }


    private bool isSelect;               // 是否之前点击了

    private IEnumerator CheckoubleClick() // 检测是否双击
    {
        isSelect = true;
        yield return new WaitForSeconds(MyDefine.DoubleClickTime);
        isSelect = false;
    }
    #endregion



    private void Btn_SureSearch(bool isShowNullTip)                         // 点击 确定搜索
    {

        // 提示输入少于 2 位数
        string kName = mInputField.text;

        int min = isShowNullTip ? 1 : 2;
        if (string.IsNullOrEmpty(kName) || kName.Length< min)
        {
            if (isShowNullTip)
            {
                anim_ErrorTip.gameObject.SetActive(true);
                anim_ErrorTip.DORestart();
            }
            return;
        }

        // 当前的字符等于之前的字符
        if (kName == mCurrentInputStr)
        {
            return;
        }
        mCurrentInputStr = kName;

        SearchAndShow(kName,true);     // 搜索 And 显示
    }


    private void SearchAndShow(string kName,bool isAddHisetory)
    {
        // 先把之前的删除
        for (int i = 0; i < rt_Contant.childCount; i++)
        {
            Object.Destroy(rt_Contant.GetChild(i).gameObject);
        }
        // 搜索 序列图的
        Dictionary<string, ResultBean[]> dir = Ctrl_XuLieTu.Instance.Search(kName);


        if (dir.Count == 0)
        {
            anim_SearchNull.gameObject.SetActive(true);
            anim_SearchNull.DORestart();
            return;
        }
        if (isAddHisetory)
        {
            AddHistroy(kName);         // 添加到历史
        }
        Ctrl_Coroutine.Instance.StartCoroutine(CreateXuLieTu(dir));
    }



    IEnumerator CreateXuLieTu(Dictionary<string, ResultBean[]> dir)
    {

        foreach (string kName in dir.Keys)
        {
            ResultBean[] resultBeanse = dir[kName];

            Transform t = InstantiateMoBan(go_MoBanDuoTu, rt_Contant);
            // 大小
            t.Find("AnimTu").GetComponent<RectTransform>().sizeDelta = new Vector2(resultBeanse[0].SP.rect.width, resultBeanse[0].SP.rect.height);

            // 动图
            Sprite[] sps = new Sprite[resultBeanse.Length];
            for (int j = 0; j < resultBeanse.Length; j++)
            {
                sps[j] = resultBeanse[j].SP;
            }
            t.Find("AnimTu/Anim").GetComponent<UGUI_SpriteAnim>().ChangeAnim(sps);

            // 名称
            t.Find("TxName").GetComponent<Text>().text = kName;

            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (isSelect)
                {
                    isSelect = false;
                    MyEventCenter.SendEvent(E_GameEvent.ShowDuoTuInfo, resultBeanse, EDuoTuInfoType.SearchShow);
                }
                else
                {
                    Ctrl_Coroutine.Instance.StartCoroutine(CheckoubleClick());
                }
            });
            yield return new WaitForEndOfFrame();
        }
    }



    private void Btn_Clear()                          // 点击 清除
    {
        mInputField.text = "";
        for (int i = 0; i < rt_Contant.childCount; i++)
        {
            Object.Destroy(rt_Contant.GetChild(i).gameObject);
        }
    }



    //—————————————————— 历史 ——————————————————

    private bool isClickHistroy;
    private void Btn_Histroy()                        // 点击历史
    {
        isClickHistroy = true;
        go_Template.SetActive(isClickHistroy);

    }



    private void AddHistroy(string kName)             // 添加到历史
    {
        if (!l_HistroyName.Contains(kName))
        {
            Transform t = InstantiateMoBan(go_MoBanHistroy, rt_HistroyContant);
            t.Find("Button/Text").GetComponent<Text>().text = kName;
            t.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
            {
                SearchAndShow(kName,false);     // 搜索 And 显示
            });

            l_HistroyName.Add(kName);
            l_HistroyGOItem.Add(t.gameObject);

            if (l_HistroyName.Count > MaxHistroyCount)
            {
                l_HistroyName.RemoveAt(0);
                GameObject go = l_HistroyGOItem[0];
                l_HistroyGOItem.RemoveAt(0);
                Object.Destroy(go);
            }
        }

    }

    //—————————————————— 事件 ——————————————————


    private void E_OnClickMouseLeftUp()               // 点击鼠标左键
    {
        if (mUIGameObject.activeSelf && go_Template.activeSelf)
        {
            if (isClickHistroy)
            {
                isClickHistroy = !isClickHistroy;
            }
            else
            {
                Ctrl_Coroutine.Instance.StartCoroutine(HideGOTemplate());
            }
        }
    }

    IEnumerator HideGOTemplate()
    {
        yield return new WaitForEndOfFrame();
        go_Template.SetActive(false);
    }


}
