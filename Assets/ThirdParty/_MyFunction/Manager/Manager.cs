using System;
using System.Collections;
using System.Collections.Generic;
using PSPUtil.Control;
using PSPUtil.StaticUtil;
using UnityEngine;


public abstract class Manager : MonoBehaviour
{

    public static T Get<T>(EF_Manager type)
        where T : Manager
    {
        return (T)Get(type);
    }


    public static Manager Get(EF_Manager type)
    {
        if (typeK_ManagerV.ContainsKey(type))
        {
            return typeK_ManagerV[type];
        }
        else
        {
            throw new Exception("在 EF_Manager 中写好这个 Manager 的 前缀名称 —— " + type);
        }
    }


    public static void Init()
    {
        foreach (EF_Manager managerType in Enum.GetValues(typeof(EF_Manager)))
        {
            Type type = Type.GetType(managerType + MANAGER);
            if (null == type)
            {
                MyLog.Red("是否有命名空间、是否没有写 EF_Manager —— " + managerType + MANAGER);
                continue;
            }
            if (null == tRootManager)
            {
                GameObject goManager = new GameObject(MANAGER);
                DontDestroyOnLoad(goManager);
                tRootManager = goManager.transform;
            }
            GameObject m = new GameObject(type.Name);
            m.transform.SetParent(tRootManager);
            Manager baseManager= (Manager)m.AddComponent(type);
            typeK_ManagerV.Add(managerType, baseManager);
        }

        Ctrl_Coroutine.Instance.StartCoroutine(InitAsync());

    }



    #region 私有

    private const string MANAGER = "Manager";
    private static Transform tRootManager = null;
    private static readonly Dictionary<EF_Manager,Manager> typeK_ManagerV=new Dictionary<EF_Manager, Manager>();

    void Awake()
    {
        OnAwake();
    }

    void Start()
    {
        OnStart();
    }

    void Update()
    {
        OnUpdate();
    }



    #endregion

    private static IEnumerator InitAsync()
    {
        foreach (Manager manager in typeK_ManagerV.Values)
        {
            manager.OnInitAsync();
            yield return 0;
        }
        
    }


    protected virtual void OnAwake(){ }
    protected virtual void OnStart(){ }

    protected virtual void OnUpdate(){ }


    protected virtual void OnInitAsync()            // 所有 Manager 都添加上,而且是异步的
    {

    }



}
