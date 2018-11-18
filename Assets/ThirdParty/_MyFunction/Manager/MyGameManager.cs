using System.Collections;
using PSPUtil;
using PSPUtil.StaticUtil;
using UnityEngine;

public class MyGameManager : Manager
{


    protected override void OnStart()  
    {
        base.OnStart();
        MyEventCenter.AddListener<EF_Scenes>(E_GameEvent.RealJumpIntoScene, E_OnEnterStart);           // 进入开始场景的事件
        MyEventCenter.AddListener(E_GameEvent.OnClickEscOrOnPause, OnClickEsc);    // 点击了 Esc 事件
        MyEventCenter.AddListener(E_GameEvent.GameGoHead, OnGameGoHead);           // 游戏继续 事件
        MyEventCenter.AddListener<float>(E_GameEvent.OnQuitGame, OnQuitGame);     // 点击退出游戏 事件
    }



    #region 私有




    private bool isPaused =false;          // 是否暂停
    private bool isLogo = true;            // 是否在 LOGO 界面
    private bool isRealQuitGame = false;   // 是否真的退出游戏
    private float mCloseTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isLogo)
        {
            MyEventCenter.SendEvent(E_GameEvent.OnClickDown_Shift);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isLogo)
        {
            MyEventCenter.SendEvent(E_GameEvent.OnClickUp_Shift);

        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !isLogo)
        {
            MyEventCenter.SendEvent(E_GameEvent.OnClickDown_Ctrl);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && !isLogo)
        {
            MyEventCenter.SendEvent(E_GameEvent.OnClickUp_Ctrl);
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.A) && !isLogo)
        {
            MyEventCenter.SendEvent(E_GameEvent.OnClickCtrlAndA);
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C) && !isLogo)
        {
            MyEventCenter.SendEvent(E_GameEvent.OnClickCtrlAndC);
        }

        if (Input.GetMouseButtonUp(0))
        {
            MyEventCenter.SendEvent(E_GameEvent.OnClickMouseLeftUp);
        }

        if (Input.GetMouseButtonDown(1))
        {
            MyEventCenter.SendEvent(E_GameEvent.OnClickMouseRightDown);
        }


        if (Input.GetKeyDown(KeyCode.Escape) && !isLogo)
        {
            MyEventCenter.SendEvent(E_GameEvent.OnClickEscOrOnPause);
        }
        if (isRealQuitGame)
        {
            if (mCloseTime<=0)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
            }
            else
            {
                mCloseTime -= Time.fixedDeltaTime;
            }
        }


    }


    #endregion



    private void OnClickEsc()                              // 接收到点击了 Esc 退出键 或者点击了 暂停的按钮
    {
        if (isPaused)            // 已经暂停了就不管这里的事了
        {
            return;
        }
        MyEventCenter.SendEvent(E_GameEvent.ShowPauseUI);
        isPaused = true;
        Time.timeScale = 0f;
    }


    private void OnGameGoHead()                            // 游戏继续
    {
        isPaused = false;
        Time.timeScale = 1;

    }


    private void OnQuitGame(float closeTime)              // 收到退出游戏事件
    {
        mCloseTime = closeTime;
        isRealQuitGame = true;
    }


    private void E_OnEnterStart(EF_Scenes scene)                         // 接收到 LOGO 结束了
    {
        isLogo = false;
        MyEventCenter.RemoveListener<EF_Scenes>(E_GameEvent.RealJumpIntoScene, E_OnEnterStart);
    }




}
