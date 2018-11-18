using System;
using DG.Tweening;
using PSPUtil;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pause : BaseUI_Mono
{

    protected override void OnStart()
    {
        anim_Scale = Get<DOTweenAnimation>("Contant");
         

        //——————————————————退出游戏页——————————————————
        AddButtOnClick("Contant/QuickPage/Left/AnimBtn_QuitGame", Btn_OnQuitGame);
        AddButtOnClick("Contant/QuickPage/Left/AnimBtn_Close", Btn_OnQuitEsc);





    }

    protected override void OnShow()
    {
        anim_Scale.DOPlayForward();
        isShowSetting = false;
      
    }


    protected override void OnHideAnim()
    {
        anim_Scale.DOPlayBackwards();
        isStartCloseAnim = true;
    }


    protected override void OnAddListener()
    {
        MyEventCenter.AddListener<float>(E_GameEvent.OnQuitGame, E_QuitGame);
        MyEventCenter.AddListener(E_GameEvent.OnClickEscOrOnPause, E_OnEsc);


    }

    protected override void OnRemoveListener()
    {
        MyEventCenter.RemoveListener<float>(E_GameEvent.OnQuitGame, E_QuitGame);
        MyEventCenter.RemoveListener(E_GameEvent.OnClickEscOrOnPause, E_OnEsc);


    }


    void Update()
    {

        if (!isStartCloseAnim)
        {
            return;
        }
        if (mTimer >= anim_Scale.duration)   // 结束动画完成
        {
            MyEventCenter.SendEvent(E_GameEvent.GameGoHead);           // 这里才发送游戏继续的事件
            gameObject.SetActive(false);
            isStartCloseAnim = false;
            mTimer = 0;
        }
        else
        {
            mTimer += Time.fixedDeltaTime;
        }

    }


    #region 私有



    private float mTimer = 0;
    private bool isStartCloseAnim = false;
    private DOTweenAnimation anim_Scale;
    private bool isShowSetting =false, isShowingPause =false;



    protected override E_GameEvent GetShowEvent()
    {
        return E_GameEvent.ShowPauseUI;
    }

    protected override E_GameEvent GetHideEvent()
    {
        return E_GameEvent.HidePauseUI;
    }





    private void Setting2FristPage()                      // 设置页回到开始的暂停页
    {
        isShowSetting = false;
    }


    private void SendEvent2HidePauseUI()                  // 发送事件去开始隐藏这个PauseUI
    {
        MyEventCenter.SendEvent(E_GameEvent.HidePauseUI);
        isShowingPause = false;
    }






    #endregion


    //UI 事件————————————————————————————————————
    private void Btn_OnQuitEsc()                  // 点击 关闭
    {
        SendEvent2HidePauseUI();
    }



    private void Btn_OnQuitGame()                // 点击了退出游戏
    {
       MyEventCenter.SendEvent<float>(E_GameEvent.OnQuitGame,0.4f);
    }




    //系统 事件————————————————————————————————————

      
    private void E_QuitGame(float closeTime)                     // 接到退出游戏的请求
    {
        Transform tBg =  GetTransform("BG");
        tBg.SetAsLastSibling();
        Tweener anim = tBg.GetComponent<Image>().DOColor(Color.black, closeTime);
        anim.SetUpdate(true);



    }


    private void E_OnEsc()                                       // 接到按了 Esc
    {
        if (!isShowingPause)
        {
            // 表壳第1下点击 Esc
            isShowingPause = true;
        }
        else
        {
            if (isShowSetting)         // 如果是按了设置
            {
                Setting2FristPage();
            }
            else                       // 没按设置的话就关闭
            {
                SendEvent2HidePauseUI();

            }
        }

    }



}
