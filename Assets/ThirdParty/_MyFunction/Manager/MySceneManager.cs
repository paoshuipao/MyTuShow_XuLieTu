using System;
using System.Collections;
using System.Reflection;
using PSPUtil;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MySceneManager : Manager
{
    public bool IsAniming { get; private set; } // 是否播放动画中


    public void LoadScene(EF_Scenes scene)     // 加载场景只需要告诉我加载那个场景即可，详细的参数都在对应的类中
    {
        if (scene == EF_Scenes._0_Main)
        {
            MyLog.Red("去初始化场景？");
            return;
        }
        if (mCurrentScene == scene)
        {
            MyLog.Red("怎么加载回当前场景？");
            return;
        }
        IsAniming = true;
        if (null!= mSceneBean)             // 1 .先让原来的离开
        {
            mSceneBean.Enter();
        }
        // 2. 生成要加载的场景参数
        AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
        mSceneBean = (ISceneBean)Assembly.Load(assemblyName).CreateInstance(scene.ToString());
        if (null == mSceneBean)
        {
            throw new Exception("场景的类没有写？ ");
        }
        mCurrentScene = scene;
        EF_JumpSceneAnim[] anims = mSceneBean.GetJumpAnim();
        EF_JumpSceneAnim anim;
        if (null != anims && anims.Length > 0)         // 要指定的动画集合
        {

            int randomIndex = Random.Range(0, anims.Length);
            anim = anims[randomIndex];
        }
        else                                          // 没有指定就随机一个
        {
            Array array = Enum.GetValues(typeof(EF_JumpSceneAnim));
            anim = (EF_JumpSceneAnim)array.GetValue(Random.Range(0, array.Length));
        }
        // 3. 开始协程来加载需要用动画的情况
        StartCoroutine(StartLoadScene(anim));

    }




    private EF_Scenes mCurrentScene = EF_Scenes._0_Main;   // 当前场景标志
    private ISceneBean mSceneBean;                         // 当前场景的类
    private const string ANIM_PREFAB = "Prefabs/JumpSceneAnim/";             // 放场景动画的地方





    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (null!= mSceneBean && !IsAniming)
        {
            mSceneBean.OnUpdate();
        }
    }





    IEnumerator StartLoadScene(EF_JumpSceneAnim anim)
    {
        LoadManager mLoadManager = Get<LoadManager>(EF_Manager.Load);
        // 1. 加载动画 Prefab
        string animPath = ANIM_PREFAB + anim;
        Base_JumpSceneAnim loadingAnim = mLoadManager.LoadPrefab(animPath).GetComponent<Base_JumpSceneAnim>();
        if (null == loadingAnim)
        {
            MyLog.Red("这个是假的动画吧，取不到动画组件 —— " + anim);
            yield break;
        }
        yield return 0;
        // 2. 异步加载场景，手动跳转
        AsyncOperation aso = SceneManager.LoadSceneAsync(mSceneBean.ToString());
        aso.allowSceneActivation = false;

        // 3.加载场景过程
        float displayProgress = 0;                // 这个才是用来显示的进度
        float toProgress = 0;                     // 实际进度
        while (aso.progress < 0.9f)
        {
            if (displayProgress < 1)
            {
                displayProgress += 0.01f;
                mSceneBean.Loading(displayProgress);
            }
            yield return 0;
        }
        yield return 0;

        toProgress = 1;
        while (displayProgress < toProgress)
        {
            if (toProgress - displayProgress >= 0.2f)
            {
                displayProgress += 0.2f;
            }
            else
            {
                displayProgress += 0.5f;
            }
            if (displayProgress <= 1)
            {
                mSceneBean.Loading(displayProgress);

            }
            yield return 0;
        }
        mSceneBean.Loading(1);

        yield return 0;

        // 4.加载完搞动画
        loadingAnim.IsOut = true;
        loadingAnim.OnReady2Do();
        StartCoroutine(loadingAnim.DoLastRenderer());      // 开始渲染


        float time = 0;

        while (loadingAnim.OnProcessAnim(time))                // 开始动画
        {
            time += Time.deltaTime;
            yield return 0;
        }

        yield return Get<UIManager>(EF_Manager.UI).ChangScene(mCurrentScene);                       // 告诉 UI 切换场景了


        aso.allowSceneActivation = true;                   // 完成动画开始跳场景


        loadingAnim.IsOut = false;                                           // 进入新的场景
    
        loadingAnim.OnReady2Do();
        time = 0;
        mSceneBean.Enter();                               // 进入这个场景
        while (loadingAnim.OnProcessAnim(time))
        {
            time += Time.deltaTime;
            yield return 0;
        }

        mSceneBean.Start();
        MyEventCenter.SendEvent(E_GameEvent.RealJumpIntoScene, mCurrentScene);
        yield return 0;
        mLoadManager.DestroyPrefabAll(animPath, loadingAnim.gameObject);

        mLoadManager.CLearRes();                          // 删除上一个场景的 Res 资源
        IsAniming = false;

    }





}
