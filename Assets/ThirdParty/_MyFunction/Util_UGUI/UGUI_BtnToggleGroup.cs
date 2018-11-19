using System;
using System.Collections;
using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UGUI_BtnToggleGroup : MonoBehaviour
{


    public void ChangeItem(ushort index)                      // 手动切换 Item
    {
        if (index<0 || index>= SubToggles.Length)
        {
            MyLog.Red("切换失败 —— "+ index);
            return;
        }

        if (mCurrentIndex != index)
        {
            // 关闭
            if (null != E_OnCloseOtherItem)
            {
                E_OnCloseOtherItem((ushort)mCurrentIndex);
            }
            SubToggles[mCurrentIndex].NoChooseThis();


            // 选中
            mCurrentIndex = index;
            SubToggles[mCurrentIndex].ChooseThis();
//            if (null != E_OnChooseItem)
//            {
//                E_OnChooseItem((ushort)mCurrentIndex);
//            }
        }
    }


    public Action<ushort> E_OnCloseOtherItem;    // 关闭这个 Item
    public Action<ushort> E_OnChooseItem;        // 选择这个 Item
    public Action<ushort> E_OnDoubleClickItem;   // 双击这个 Item




    #region 私有

    private bool isSelect = false;


    [ReadOnly]
    [MyHead("当前这个索引 Item 选中")]
    public int mCurrentIndex = -1;

    public UGUI_BtnToggleItem[] SubToggles;

    IEnumerator OnCheckDoubleClick()
    {
        isSelect = true;
        yield return new WaitForSeconds(MyDefine.DoubleClickTime);
        isSelect = false;
    }


    #endregion

    void Awake()
    {
        if (mCurrentIndex < 0)         // 之前没有刷新
        {
            ResetSubToggle();
        }
        for (int i = 0; i < SubToggles.Length; i++)
        {
            UGUI_BtnToggleItem item = SubToggles[i];
            SubToggles[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                if (mCurrentIndex != item.ItemIndex)
                {
                    // 关闭
                    if (null!= E_OnCloseOtherItem)
                    {
                        E_OnCloseOtherItem((ushort)mCurrentIndex);
                    }
                    SubToggles[mCurrentIndex].NoChooseThis();


                    // 选中
                    mCurrentIndex = item.ItemIndex;
                    item.ChooseThis();
                    if (null != E_OnChooseItem)
                    {
                        E_OnChooseItem((ushort)mCurrentIndex);
                    }
                }
                else
                {
                    if (isSelect)
                    {
                        isSelect = false;
                        if (null!= E_OnDoubleClickItem)
                        {
                            E_OnDoubleClickItem((ushort)mCurrentIndex);
                        }
                    }
                    else
                    {
                        StartCoroutine(OnCheckDoubleClick());
                    }
                }

            });
        }
    }



    void Start()
    {

        foreach (UGUI_BtnToggleItem item in SubToggles)
        {
            if (!item.IsOn)
            {
                if (null != E_OnCloseOtherItem)
                {
                    E_OnCloseOtherItem(item.ItemIndex);
                }
            }
        }
        if (null!= E_OnChooseItem)
        {
            E_OnChooseItem((ushort)mCurrentIndex);
        }

    }



    [Button("重新 刷新 UGUI_BtnToggleItem")]
    public void ResetSubToggle()                // 用来刷新
    {
        SubToggles = GetComponentsInChildren<UGUI_BtnToggleItem>();
        mCurrentIndex = -1;
        if (null!= SubToggles && SubToggles.Length>0)
        {
            for (ushort i = 0; i < SubToggles.Length; i++)
            {
                SubToggles[i].ItemIndex = i;
                if (SubToggles[i].IsOn)
                {
                    if (mCurrentIndex >= 0)  // 当前没有选中
                    {
                        SubToggles[i].NoChooseThis();
                    }
                    else
                    {
                        SubToggles[i].ChooseThis();
                        mCurrentIndex = i;
                    }
                }
                else
                {
                    SubToggles[i].NoChooseThis();
                }
            }
            if (mCurrentIndex<0)
            {
                SubToggles[0].ChooseThis();
                mCurrentIndex = 0;
            }

        }


    }



}
