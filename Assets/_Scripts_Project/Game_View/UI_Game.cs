using System;
using PSPUtil;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : BaseUI
{
    protected override void OnStart(Transform root)
    {
        mLeftGroup = Get<UGUI_BtnToggleGroup>("Left");
        mLeftGroup.E_OnCloseOtherItem += E_OnLeftChangePre;     // 关闭其他 Item
        mLeftGroup.E_OnChooseItem += E_OnLeftGroupChange;       // 选中这个 Item
        mLeftGroup.E_OnDoubleClickItem += E_OnLeftDoubleClick;

        L_LeftText[0]= Get<Text>("Left/Item1/TxLeft");
        L_LeftText[1] = Get<Text>("Left/Item2/TxLeft");
        L_LeftText[2] = Get<Text>("Left/Item3/TxLeft");
        L_LeftText[3] = Get<Text>("Left/Item4/TxLeft");
        L_LeftText[4] = Get<Text>("Left/Item5/TxLeft");
        L_LeftText[5] = Get<Text>("Left/Item6/TxLeft");
        L_LeftText[6] = Get<Text>("Left/Item7/TxLeft");
        L_LeftText[7] = Get<Text>("Left/Item8/TxLeft");



    }

    protected override void OnEnable()
    {
        for (int i = 0; i < L_LeftText.Length; i++)
        {
            L_LeftText[i].text = Ctrl_Info.Instance.LeftItemNames[i];
        }
    }

    protected override void OnAddListener()
    {
        MyEventCenter.AddListener<ushort>(E_GameEvent.LeftChangeItem, E_LeftChangeItem);     // 切换其他 Item

    }

    #region 私有

    private readonly Text[] L_LeftText = new Text[8];

    private UGUI_BtnToggleGroup mLeftGroup;


    private readonly Sub_ItemContant sub_ItemContant = new Sub_ItemContant();
//    private readonly Sub_Item2 sub_Item2 = new Sub_Item2();
//    private readonly Sub_Item3 sub_Item3 = new Sub_Item3();
//    private readonly Sub_Item4 sub_Item4 = new Sub_Item4();
//    private readonly Sub_Item5 sub_Item5 = new Sub_Item5();
//    private readonly Sub_Item6 sub_Item6 = new Sub_Item6();
//    private readonly Sub_Item7 sub_Item7 = new Sub_Item7();
//    private readonly Sub_Item8 sub_Item8 = new Sub_Item8();


    private readonly Sub_DaoRu sub_DaoRu = new Sub_DaoRu();
    private readonly Sub_Search sub_Search = new Sub_Search();
    private readonly Sub_Setting sub_Setting = new Sub_Setting();




    protected override SubUI[] GetSubUI()
    {
        return new SubUI[]
        {
            sub_ItemContant,
            sub_DaoRu,sub_Search,sub_Setting,
        };
    }



    protected override void OnDisable()
    {
    }



    protected override void OnRemoveListener()
    {
    }

    protected override E_GameEvent GetShowEvent()
    {
        return E_GameEvent.ShowStartGameUI;
    }

    protected override E_GameEvent GetHideEvent()
    {
        return E_GameEvent.HideStartGameUI;
    }

    protected override string GetResName()
    {
        return "UI/UI_Game";
    }

    public override EF_Scenes GetSceneType()
    {
        return EF_Scenes._0_Main;
    }


    #endregion



    private void E_OnLeftChangePre(ushort preIndex)      // 切换前 先关闭之前的
    {
        switch (preIndex)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
                sub_ItemContant.Close(preIndex);
                break;
            case 8:
                sub_DaoRu.Close();
                break;
            case 9:
                sub_Search.Close();
                break;
            case 10:
                sub_Setting.Close();
                break;
            default:
                throw new Exception("未定义");
        }
    }


    private void E_OnLeftGroupChange(ushort index)       // 切换
    {
        switch (index)
        {
            case 0:
                
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
                sub_ItemContant.Show(index);
                break;
            case 8:
                sub_DaoRu.Show();
                break;
            case 9:
                sub_Search.Show();
                break;
            case 10:
                sub_Setting.Show();
                break;
            default:
                throw new Exception("未定义");
        }
    }


    private void E_OnLeftDoubleClick(ushort index)       // 双击左边的Item
    {

    }



    //—————————————————— 事件 ——————————————————

    private void E_LeftChangeItem(ushort index)           // 不是点击切换 Item ，而是其他要求切换
    {
        mLeftGroup.ChangeItem(index);
    }


}
