using System;
using PSPUtil.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UIRoot : MonoBehaviour           //单例类，直接用
{

    public Transform RootTransform { get; private set; }         // UIRoot 最根部




    public Transform[] UITransforms { get; private set; }        // 一般 UI 都放在这里


    public Transform FirstUiTransform { get; private set; }      // 如果需要确保 UI 一定要放在最前，就用这个

    public Camera UICamera { get; private set; }                 // 相机


    public void SetGraphicRaycaster(bool value)                  // 有需要的话，设置 GraphicRaycaster 的开关
    {
        mGR.enabled = value;
    }


    public Canvas RootCanvas { get; private set; }      




    #region 私有



    private GraphicRaycaster mGR;
    private static readonly Vector2 mReferenceResolution = new Vector2(1366f, 768f);

    public static UIRoot Instance
    {
        get
        {
            if (m_Instance == null)
            {
                InitRoot();
            }
            return m_Instance;
        }
    }
    private static UIRoot m_Instance = null;

    void OnDestroy()
    {
        m_Instance = null;
    }



    private static void InitRoot()
    {

        //根 UIRoot————————————————————————————————————
        GameObject go = new GameObject("UIRoot");
        Object.DontDestroyOnLoad(go);
        go.layer = LayerMask.NameToLayer("UI");
        m_Instance = go.AddComponent<UIRoot>();
        Transform rooTransform = go.transform;
        rooTransform.position = Vector3.zero;
        m_Instance.RootTransform = rooTransform;
        //Canvas———————————————————
        GameObject canvas = CreateGameObject("Canvas", rooTransform, Vector3.zero);
        canvas.AddComponent<RectTransform>();
        Canvas can = canvas.AddComponent<Canvas>();
        m_Instance.RootCanvas = can;
        can.renderMode = RenderMode.ScreenSpaceCamera;
        can.planeDistance = 8;
        can.pixelPerfect = true;
        CanvasScaler cs = canvas.AddComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        cs.referenceResolution = mReferenceResolution;
        cs.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

        //GraphicRaycaster————————————————————————————————————
        m_Instance.mGR = canvas.AddComponent<GraphicRaycaster>();


        //UICamera————————————————————————————————————
        GameObject camObj = CreateGameObject("UICamera", rooTransform, Vector3.zero);
        Camera cam = camObj.AddComponent<Camera>();
        cam.clearFlags = CameraClearFlags.Depth;
        // 这次设置成 2D相机
        cam.orthographic = true;
        cam.nearClipPlane = 0.1f;
        cam.farClipPlane = 100;
//        cam.fieldOfView = 45;
        cam.nearClipPlane = -15f;
        cam.farClipPlane = 15f;
        can.worldCamera = cam;
//        cam.cullingMask = 1 << 5;

        cam.depth = 10;
        cam.allowHDR = false;
        m_Instance.UICamera = cam;
        camObj.AddComponent<AudioListener>();
        camObj.AddComponent<FlareLayer>();

        //EventSystem————————————————————————————————————
        GameObject eventObj = CreateGameObject("EventSystem", rooTransform, Vector3.zero);
        eventObj.AddComponent<EventSystem>();
        eventObj.AddComponent<StandaloneInputModule>();

        //————————————————————————————————————
        string[] sceneNames = Enum.GetNames(typeof(EF_Scenes));
        m_Instance.UITransforms = new Transform[sceneNames.Length];
        for (int i = 0; i < sceneNames.Length; i++)
        {
            m_Instance.UITransforms[i] = CreateUI(sceneNames[i], canvas.transform);
        }
      

        m_Instance.FirstUiTransform = CreateUI("FirstView", canvas.transform);



    }




    private static Transform CreateUI(string uiName, Transform root)
    {

        GameObject viewObj = CreateGameObject(uiName, root, Vector3.zero);
        RectTransform viewRect = viewObj.AddComponent<RectTransform>();
        viewRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
        viewRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
        viewRect.SetAnchors(Vector2.zero, Vector2.one);
        return viewObj.transform;

    }



    private static GameObject CreateGameObject(string goName, Transform root, Vector3 position)
    {
        GameObject go = new GameObject(goName);
        go.transform.SetParent(root);
        go.layer = LayerMask.NameToLayer("UI");
        go.transform.localPosition = position;
        go.transform.localScale = Vector3.one;
        return go;
    }



    #endregion




}
