using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using PSPUtil.StaticUtil;

public class UIManager : Manager
{

    public IEnumerator ChangScene(EF_Scenes scene)                       // 切换场景都调用下这个
    {
        if (scene ==EF_Scenes._0_Main)
        {
            MyLog.Red("写错了吧，切换成初始化场景？");
            yield break;
        }
        yield return Chang(scene);
    }


    #region 私有

    private IEnumerator Chang(EF_Scenes go2Scene)
    {
        int index = (int)go2Scene;     // 如 0 -> 初始化  1 ->开始场景  2 -> 游戏
        if (index > 1)                 // 2开始的才需要删除之前的啊
        {
            foreach (BaseUI ui in l_BaseUI)
            {
                EF_Scenes uiScene = ui.GetSceneType();   // 这个UI的场景
                if (uiScene != go2Scene)    // 不是这个场景都删除
                {
                    ui.Destroy();
                    yield return 0;
                }
            }
        }

        foreach (BaseUI ui in l_BaseUI)
        {
            EF_Scenes uiScene = ui.GetSceneType();
            if (uiScene == go2Scene)                      // 只要是这个场景的都预先加载好
            {
                ui.PreLoad();
                yield return 0;
            }
            yield return 0;
        }

    }



    private readonly List<BaseUI> l_BaseUI = new List<BaseUI>();

    protected override void OnAwake()
    {
        base.OnAwake();
        foreach (string windowType in Enum.GetNames(typeof(EF_UI)))
        {
            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            BaseUI baseUi = (BaseUI)Assembly.Load(assemblyName).CreateInstance(windowType);
            l_BaseUI.Add(baseUi);
        }
        StartCoroutine(Chang(EF_Scenes._0_Main));

    }


    protected override void OnUpdate()
    {
        base.OnUpdate();

        foreach (BaseUI ui in l_BaseUI) 
        {
            ui.Update();
        }
    }

    #endregion





}
