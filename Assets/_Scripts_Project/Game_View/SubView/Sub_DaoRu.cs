using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using DG.Tweening;
using PSPUtil;
using PSPUtil.Control;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class Sub_DaoRu : SubUI
{


    public void Show()
    {
        mUIGameObject.SetActive(true);

        if (isFirstShow)    // 第一次显示
        {
            isFirstShow = false;

            // 收藏
            List<string> favPaths = Ctrl_UserInfo.Instance.L_FavoritesPath;
            foreach (string favPath in favPaths)
            {
                CreateFavoites(favPath);     // 获取之前已保存的，创建收藏按键出来
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt_ShuQianContant);


            // 过滤设置
            mFileBrowser.SetFilters(MyFilterUtil.ONLY_TU_AUDIO_FILTER);

            // 中间内容
            RefreshMiddleContent();          // 生成中间的内容
        }
    }


    public void Close()
    {
        mUIGameObject.SetActive(false);
    }



    protected override void OnStart(Transform root)
    {
        MyEventCenter.AddListener(E_GameEvent.OnClickMouseRightDown, E_OnMouseLeftClick);            // 鼠标右键点击
//        MyEventCenter.AddListener<EGameType, ushort, List<ResultBean>, bool>(E_GameEvent.DaoRuTuFromResult, E_OnDuoTuDaoRu);  // 确定导入图片
        MyEventCenter.AddListener(E_GameEvent.GoToNextFolderDaoRu, E_GoToNextFolderDaoRu);          // 导入后 到一个文件夹
        MyEventCenter.AddListener(E_GameEvent.OnClickCtrlAndA, E_OnClickCtrlAndA);                  // 按下 Ctrl + A
        MyEventCenter.AddListener(E_GameEvent.OnClickCtrlAndC, E_OnClickCtrlAndC);                  // 按下 Ctrl + C

        // 总
        rt_Right = Get<RectTransform>("Right/Contant");

        l_AddressPaths[0] = Ctrl_UserInfo.Instance.ShowFirstPath;
        l_AddressPaths[1] = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        l_AddressPaths[2] = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        l_AddressPaths[3] = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        l_AddressPaths[4] = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        mFileBrowser = string.IsNullOrEmpty(l_AddressPaths[0]) ? new FileBrowser() : new FileBrowser(l_AddressPaths[0]);

        #region 书签

        go_ShuQian = GetGameObject("Right/Contant/GO_ShuQian");
        moBan_Favorites = GetGameObject("Right/Contant/GO_ShuQian/ScrollView/Contant/MoBan_ItemFav");
        AddToggleOnValueChanged("Right/Contant/Toggle_ShuQian", OnToggle_ShuQian);
        rt_ShuQianContant = Get<RectTransform>("Right/Contant/GO_ShuQian/ScrollView/Contant");

        #endregion

        #region 大小

        go_ModeSize = GetGameObject("Right/Contant/Size2_Mode");
        tx_Size1 = Get<Text>("Right/Contant/Size1_Btn/Text");
        tx_SizeBig = Get<Text>("Right/Contant/Size2_Mode/Contant/ItemBig/Text");
        tx_SizeMiddle = Get<Text>("Right/Contant/Size2_Mode/Contant/ItemMiddle/Text");
        tx_SizeSmall = Get<Text>("Right/Contant/Size2_Mode/Contant/ItemSmall/Text");
        tg_ModeSize = Get<UGUI_ToggleGroup>("Right/Contant/Size2_Mode/Contant");
        anim_SizeIcon = Get<DOTweenAnimation>("Right/Contant/Size1_Btn/Left");
        tg_ModeSize.OnChangeValue += OnToggle_ChangeSizeMode;
        tg_ModeSize.OnEachClick += Btn_CloseSize;
        AddButtOnClick("Right/Contant/Size1_Btn", Btn_OpenSize);

        #endregion

        #region 过滤

        go_ModeFilter = GetGameObject("Right/Contant/Filter2_Mode");
        tx_Filter1 = Get<Text>("Right/Contant/Filter1_Btn/Text");
        tx_FilterAll = Get<Text>("Right/Contant/Filter2_Mode/Contant/ItemAll/Text");
        tx_FilterTexture = Get<Text>("Right/Contant/Filter2_Mode/Contant/ItemTexture/Text");
        tx_FilterFolder = Get<Text>("Right/Contant/Filter2_Mode/Contant/ItemFolder/Text");
        tg_FilterMode = Get<UGUI_ToggleGroup>("Right/Contant/Filter2_Mode/Contant");
        anim_FilterIcon = Get<DOTweenAnimation>("Right/Contant/Filter1_Btn/Left");
        tg_FilterMode.OnChangeValue += OnToggle_ChangeFilterMode;
        tg_FilterMode.OnEachClick += Btn_CloseFilter;
        AddButtOnClick("Right/Contant/Filter1_Btn", Btn_OpenFilter);


        #endregion

        #region 排序

        go_ModeSorting = GetGameObject("Right/Contant/Sorting2_Mode");
        tx_Sort1 = Get<Text>("Right/Contant/Sorting1_Btn/Text");
        tx_SortName = Get<Text>("Right/Contant/Sorting2_Mode/Contant/ItemName/Text");
        tx_SortType = Get<Text>("Right/Contant/Sorting2_Mode/Contant/ItemType/Text");
        tx_SortDate = Get<Text>("Right/Contant/Sorting2_Mode/Contant/ItemDate/Text");
        tg_SortMode = Get<UGUI_ToggleGroup>("Right/Contant/Sorting2_Mode/Contant");
        anim_SortIcon = Get<DOTweenAnimation>("Right/Contant/Sorting1_Btn/Left");
        tg_SortMode.OnChangeValue += OnToggle_ChangeSortMode;
        tg_SortMode.OnEachClick += Btn_CloseSorting;
        AddButtOnClick("Right/Contant/Sorting1_Btn", Btn_OpenSorting);

        #endregion

        #region 头部栏

        // 上方的头部菜单
        go_ItemPath2 = GetGameObject("Top/Top/ItemPath2");
        go_ItemPath3 = GetGameObject("Top/Top/ItemPath3");
        go_ItemPath4 = GetGameObject("Top/Top/ItemPath4");
        go_ItemPath5 = GetGameObject("Top/Top/ItemPath5");
        go_Add = GetGameObject("Top/Top/Add");
        rt_Top = Get<RectTransform>("Top/Top");
        tg_ItemPath = Get<UGUI_ToggleGroup>("Top/Top");
        tg_ItemPath.OnChangeValue += E_OnTopPathChange;
        AddButtOnClick("Top/Top/Add/Btn", Btn_AddItem);
        AddButtOnClick("Top/Top/ItemPath2/Close", () => { CloseItemPath(go_ItemPath2); });
        AddButtOnClick("Top/Top/ItemPath3/Close", () => { CloseItemPath(go_ItemPath3); });
        AddButtOnClick("Top/Top/ItemPath4/Close", () => { CloseItemPath(go_ItemPath4); });
        AddButtOnClick("Top/Top/ItemPath5/Close", () => { CloseItemPath(go_ItemPath5); });

        tx_TopPath1 = Get<Text>("Top/Top/ItemPath1/Text");
        tx_TopPath2 = Get<Text>("Top/Top/ItemPath2/Text");
        tx_TopPath3 = Get<Text>("Top/Top/ItemPath3/Text");
        tx_TopPath4 = Get<Text>("Top/Top/ItemPath4/Text");
        tx_TopPath5 = Get<Text>("Top/Top/ItemPath5/Text");


        AddButtOnClick("Top/BtnSuaiXin", Btn_ShuaiXin);
        // 下方的 历史、地址栏
        tx_Path = Get<Text>("Top/Bottom/Middle/AddressPath/Text");

        // 收藏的星星
        toggle_Star = Get<Toggle>("Top/Bottom/Middle/ToggleStar");
        AddToggleOnValueChanged(toggle_Star, Toggle_ChangeIsStar);

        // 历史的左右按钮
        btn_HistoryPre = Get<Button>("Top/Bottom/Left/BtnLeft");
        btn_HistoryNext = Get<Button>("Top/Bottom/Left/BtnRight");
        AddButtOnClick(btn_HistoryPre, Btn_OnHistoryPre);
        AddButtOnClick(btn_HistoryNext, Btn_OnHistoryNext);
        // 中间的地址栏
        AddButtOnClick("Top/Bottom/Middle/AddressPath/Btn", Btn_OnClickAddressPath);
        // 右边上层
        AddButtOnClick("Top/Bottom/Right/BtnUp", Btn_OnGoToParent);
        AddButtOnClick("Top/Bottom/Right/BtnOpenFolder", Btn_OpenFolder);



        #endregion

        #region 导入 && 改名
        // 导入
        tx_TipZhang = Get<Text>("Right/BtnDaoRu/Tip/Num");
        btnDaoRu = Get<Button>("Right/BtnDaoRu");
        AddButtOnClick(btnDaoRu, Btn_OnDaoRuClick);

        // 改名
        go_IsGaiMing = GetGameObject("IsGaiMing");
        rt_GeiMing = Get<RectTransform>("IsGaiMing/Contant/Middle/Cotant");
        go_MoBanGeiMing = GetGameObject("IsGaiMing/Contant/Middle/MoBan");
        input_GeiMing = Get<InputField>("Right/Contant/GeiMing/InputField");
        go_BottomBtn = GetGameObject("IsGaiMing/Contant/BottomBtn");
        go_BottomWait = GetGameObject("IsGaiMing/Contant/BottomWait");
        btnGeiMing = Get<Button>("Right/Contant/GeiMing/BtnSure");
        input_GeiMing222 = Get<InputField>("IsGaiMing/Contant/Top/InputField");
        AddInputOnEndEdit(input_GeiMing222, InputEnd_GeiMing222);
        AddButtOnClick(btnGeiMing, Btn_GeiMing);
        AddButtOnClick("IsGaiMing/Contant/Top/BtnChange", Btn_GeiMing222);
        AddButtOnClick("IsGaiMing/Contant/BottomBtn/BtnSure", Btn_OnSureGaiMing);
        AddButtOnClick("IsGaiMing/Contant/BottomBtn/BtnFalse", Btn_OnFalseGeiMing);

        #endregion

        #region 中间

        t_MiddleGrid = GetTransform("Bottom/ScrollView/Contant");
        grid_Contant = t_MiddleGrid.GetComponent<UGUI_Grid>();
        moBan_File = GetGameObject("Bottom/ScrollView/MoBan_File");
        moBan_Folder = GetGameObject("Bottom/ScrollView/MoBan_Folder");
        moBan_YinPan = GetGameObject("Bottom/ScrollView/MoBan_YinPan");
        moBan_Computer = GetGameObject("Bottom/ScrollView/MoBan_Computer");
        moBan_ZhuoMain = GetGameObject("Bottom/ScrollView/MoBan_ZhuoMain");
        moBan_Music = GetGameObject("Bottom/ScrollView/MoBan_Music");


        MyEventCenter.AddListener(E_GameEvent.OnClickDown_Shift, E_OnShiftClick);
        MyEventCenter.AddListener(E_GameEvent.OnClickUp_Shift, E_OnShiftUp);
        MyEventCenter.AddListener(E_GameEvent.OnClickDown_Ctrl, E_OnCtrlClick);
        MyEventCenter.AddListener(E_GameEvent.OnClickUp_Ctrl, E_OnCtrlUp);

        AddScrollbarValueChange("Bottom/Scrollbar", (position) =>
        {
            if (isShowLeftTip)
            {
                go_MouseLeftClick.SetActive(false);
            }
        });

        #endregion

        #region 框选
        rt_Kuang = Get<RectTransform>("Bottom/ScrollView/KuangXuan");
        mKuangXuan = rt_Kuang.GetComponent<KuangXuan>();
        mKuangXuan.Init(chooseGOK_BgV);
        UGUI_KuangXuan kuangXuan = Get<UGUI_KuangXuan>("Bottom/ScrollView");

        kuangXuan.E_OnClickDown += E_OnClickKuangDown;
        kuangXuan.E_OnDarg += E_OnKuangDarg;
        kuangXuan.E_OnClickUp += E_OnClickKuangUp;
        #endregion

        #region 鼠标右键

        go_MouseLeftClick = GetGameObject("MouseLeftClick");
        AddButtOnClick("MouseLeftClick/BtnBlue", () =>
        {
            Btn_ChooseColor(MyEnumColor.Blue);
        });
        AddButtOnClick("MouseLeftClick/BtnYellow", () =>
        {
            Btn_ChooseColor(MyEnumColor.Yellow);
        });
        AddButtOnClick("MouseLeftClick/BtnWhite", () =>
        {
            Btn_ChooseColor(MyEnumColor.White);
        });
        AddButtOnClick("MouseLeftClick/BtnGreen", () =>
        {
            Btn_ChooseColor(MyEnumColor.Green);
        });
        AddButtOnClick("MouseLeftClick/BtnNull", () =>
        {
            Btn_ChooseColor(MyEnumColor.Hui, true);
        });
        #endregion


    }


    #region 私有

    private bool isFirstShow = true;      // 是否第一次Show
    private FileBrowser mFileBrowser;     // 核心功能
    private RectTransform rt_Right;       // 总的右边
    private readonly Color LBColor = MyColor.GetColor(MyEnumColor.LightBlue);


    enum MiddleButtonType // 中间点击按钮的类型
    {
        File,        // 文件
        Folder,      // 文件夹
        Drive,       // 磁盘
        Computer,    // 我的电脑
        ZhuoMain,    // 桌面
        Music,       // 音乐文件
    }



    private GameObject go_CurrentSelect;    // 当前选择的按钮
    private FileSystemInfo m_CurrentSelectFile; // 当前选择的文件或者文件夹


    // 中间
    private bool isShift = false;                 // 是否按下 Shift
    private bool isNormalClick = true;            // 是否普通的单击
    private bool isSelect;                  // 是否之前点击了
    private readonly Dictionary<GameObject, GameObject> chooseGOK_BgV = new Dictionary<GameObject, GameObject>();    // 选中的对象作为Key，其背景作为 Value
    private readonly List<GameObject> l_MiddleItems = new List<GameObject>();   // 中间每一个 Item
    private Transform t_MiddleGrid;         // 中间 Grid  设置模版的父位置
    private UGUI_Grid grid_Contant;         // 中间核心 Grid

    //模版
    private GameObject moBan_File;          // 模版_文件
    private GameObject moBan_Folder;        // 模版_文件夹
    private GameObject moBan_YinPan;        // 模版_磁盘
    private GameObject moBan_Computer;      // 模版_我的电脑
    private GameObject moBan_ZhuoMain;      // 模版_桌面
    private GameObject moBan_Music;         // 模版_音乐文件
    

    private const string FILE_NAME = "File";           // 根据模版产生的对象的名字
    private const string FLODER_NAME = "Folder";
    private const string YINPAN_NAME = "YinPan";
    private const string COMPUTER_NAME = "Computer";
    private const string ZHUOMAIN_NAME = "ZhuoMain";
    private const string MUSIC_NAME = "Music";

    private IEnumerator CheckoubleClick()           // 检测是否双击
    {
        isSelect = true;
        yield return new WaitForSeconds(MyDefine.DoubleClickTime);
        isSelect = false;

    }




    #region 头部栏
    private string[] l_AddressPaths = new string[5];

    // 上
    private GameObject go_ItemPath2, go_ItemPath3, go_ItemPath4, go_ItemPath5, go_Add;
    private RectTransform rt_Top;
    private UGUI_ToggleGroup tg_ItemPath;
    private Text tx_TopPath1, tx_TopPath2, tx_TopPath3, tx_TopPath4, tx_TopPath5;
    private ushort mCurrentTopIndex = 0;                  // 当前上头的索引   1 就是第一页

    // 下
    public Text tx_Path;          // 搜索字段文本区域
    private Toggle toggle_Star;   // 星星（收藏）
    private Button btn_HistoryPre,btn_HistoryNext;

    #endregion

    #region 大小
    private static readonly Vector2 SIZE_BIG = new Vector2(200, 240);    //最大尺寸
    private static readonly Vector2 SIZE_MIDDLE = new Vector2(136, 169);  //中等尺寸
    private static readonly Vector2 SIZE_SMALL = new Vector2(88, 110);    //最小尺寸
    private Text tx_SizeBig, tx_SizeMiddle, tx_SizeSmall; // 字体没选中的用灰色
    private Text tx_Size1;
    private UGUI_ToggleGroup tg_ModeSize;
    private GameObject go_ModeSize;
    private DOTweenAnimation anim_SizeIcon;

    #endregion

    #region 文件过滤
    private bool isOnlyShowFolder;                 // true：只显示文件夹
    private Text tx_FilterAll, tx_FilterTexture, tx_FilterFolder; // 字体没选中的用灰色
    private Text tx_Filter1;
    private UGUI_ToggleGroup tg_FilterMode;
    private GameObject go_ModeFilter;
    private DOTweenAnimation anim_FilterIcon;
    private const string SHOW_NAME1 = "显示全部";
    private const string SHOW_NAME2 = "图片音频";
    private const string SHOW_NAME3 = "仅文件夹";





    #endregion

    #region 排序

    private Text tx_SortName, tx_SortType, tx_SortDate; // 字体没选中的用灰色
    private Text tx_Sort1;
    private UGUI_ToggleGroup tg_SortMode;
    private GameObject go_ModeSorting;
    private DOTweenAnimation anim_SortIcon;

    #endregion

    #region 书签

    private GameObject go_ShuQian;
    private GameObject moBan_Favorites; // 模板_单个书签按钮
    private RectTransform rt_ShuQianContant;
    private readonly List<GameObject> mb_Favorites = new List<GameObject>();

    #endregion

    #region 导入 && 改名

    private Text tx_TipZhang;
    private Button btnDaoRu,btnGeiMing;
    private GameObject go_IsGaiMing;
    private InputField input_GeiMing,input_GeiMing222;
    private RectTransform rt_GeiMing;
    private GameObject go_MoBanGeiMing;
    private GameObject go_BottomBtn,go_BottomWait;

    #endregion

    #region 框选

    private RectTransform rt_Kuang;
    private KuangXuan mKuangXuan;

    #endregion

    #region 鼠标右键

    private GameObject go_MouseLeftClick;


    #endregion

    #region 私有


    public override void OnEnable()
    {

    }

    public override void OnDisable()
    {

    }


    public override string GetUIPathForRoot()
    {
        return "Right/EachContant/DaoRu";
    }


    #endregion

    #endregion





    private readonly Dictionary<GameObject, ResultBean> allGoK_ResultBeanV = new Dictionary<GameObject, ResultBean>();  // 以 中间每个 Item 为Key，以图片结果为 Value


    private void RefreshMiddleContent()                                                        // 刷新中间的内容
    {
        //——————————————————  1. 先清除原来的   ——————————————————
        btnDaoRu.interactable = false;                  // 不能导入
        btnGeiMing.interactable = false;
        go_CurrentSelect = null;
        input_GeiMing.text = "";
        ClearAllChooseZhong();                          // 清除所有选中的
        Ctrl_Coroutine.Instance.StopAllCoroutines();    // 关闭所有协程
        for (int i = 0; i < l_MiddleItems.Count; i++)   // 删除原来生成的
        {
            Object.Destroy(l_MiddleItems[i].gameObject);
        }
        l_MiddleItems.Clear();
        allGoK_ResultBeanV.Clear();

        //—————————————————— 2. 判断是否桌面，如果是，再添加我的电脑——————————————————

        DirectoryInfo dir = mFileBrowser.GetCurrentDirectory();      // 当前文件夹路径
        if (null != dir && dir.FullName == System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop))
        {
            AddMiddleButton(dir, MiddleButtonType.Computer);       // 我的电脑
        }

        //—————————————————— 3. 添加文件夹和文件——————————————————
        DirectoryInfo[] folderList = mFileBrowser.GetChildDirectories();        // 获得所有文件夹
        Ctrl_Coroutine.Instance.StartCoroutine(LoadFileAndFolder(folderList, dir));



        //—————————————————— 4. 设置头部栏 历史、地址、书签——————————————————



        btn_HistoryPre.interactable = mFileBrowser.GetIsHasHistoryPre;          // 有没有上下历史
        btn_HistoryNext.interactable = mFileBrowser.GetIsHasHistoryNext;


        // 设置头部栏的地址
        string topPath;
        if (dir != null) 
        {
            tx_Path.text = dir.FullName;
            topPath = dir.Name;
            l_AddressPaths[mCurrentTopIndex] = dir.FullName;
            Ctrl_UserInfo.Instance.ShowFirstPath = dir.FullName;
        }
        else
        {
            tx_Path.text = "计算机";
            topPath = "计算机";
        }

        switch (mCurrentTopIndex)
        {
            case 0:
                tx_TopPath1.text = topPath;
                break;
            case 1:
                tx_TopPath2.text = topPath;
                break;
            case 2:
                tx_TopPath3.text = topPath;
                break;
            case 3:
                tx_TopPath4.text = topPath;
                break;
            case 4:
                tx_TopPath5.text = topPath;
                break;
        }



        // 这个路径是否书签
        bool isFavorite = false; 
        foreach (string path in Ctrl_UserInfo.Instance.L_FavoritesPath)
        {
            if (tx_Path.text.Equals(path))
            {
                isFavorite = true;
                break;
            }
        }
        toggle_Star.isOn = isFavorite;



    }


    IEnumerator LoadFileAndFolder(DirectoryInfo[] foloderList, DirectoryInfo currentDic)       // 加载文件和文件夹
    {
        for (int i = 0; i < foloderList.Length; i++)
        {
            if (foloderList[i].Parent != null)
            {
                AddMiddleButton(foloderList[i], MiddleButtonType.Folder);       // 有父文件夹的是文件夹
            }
            else
            {
                AddMiddleButton(foloderList[i], MiddleButtonType.Drive);         // 没有的就是磁盘啊
            }
            yield return 0;
        }

        if (!isOnlyShowFolder)
        {

            FileInfo[] files = mFileBrowser.GetFiles();   // 获得所有文件
            foreach (FileInfo fileInfo in files)
            {
                if (MyFilterUtil.IsAudio(fileInfo))
                {
                    AddMiddleButton(fileInfo, MiddleButtonType.Music);
                }
                else
                {
                    Transform t = AddMiddleButton(fileInfo, MiddleButtonType.File);
                    if (MyFilterUtil.IsTu(fileInfo))          // 是图片那就加载图片
                    {
                        InitMoBan_Tu(t, fileInfo);
                    }
                }
                yield return new WaitForEndOfFrame();

            }
        }


        if (null == currentDic)
        {
            AddMiddleButton(null, MiddleButtonType.ZhuoMain);       // 桌面
        }

    }



    private void Btn_OnDaoRuClick()                                     // 点击导入
    {
        if (chooseGOK_BgV.Count > 1)               // 选择了 多张
        {
            List<GameObject> sortList = GetSortChoose();      // 1. 先排好序
            ResultBean[] resultBeans = new ResultBean[sortList.Count];
            for (int i = 0; i < sortList.Count; i++)
            {
                resultBeans[i] = allGoK_ResultBeanV[sortList[i]];
            }
            MyEventCenter.SendEvent(E_GameEvent.ShowDuoTuInfo, resultBeans, EDuoTuInfoType.DaoRu);

        }
        else if (chooseGOK_BgV.Count == 1)       // 选择了 1 张
        {
            foreach (GameObject go in chooseGOK_BgV.Keys)
            {
                MyEventCenter.SendEvent(E_GameEvent.ShowSingleTuDaoRu, allGoK_ResultBeanV[go]);
                break;
            }
        }
        else
        {
            MyLog.Red("不可能吧");
        }

    }



    #region 中间


    private void E_OnShiftClick()                // 按下了 Shift
    {
        isShift = true;
    }


    private void E_OnShiftUp()                   // 松开了 Shift
    {
        isShift = false;

    }


    private void E_OnCtrlClick()                 // 按下 Ctrl
    {
        isNormalClick = false;

    }

    private void E_OnCtrlUp()                    // 松开 Shift
    {
        isNormalClick = true;

    }



    private string GetShortName(string str,int longLeght =8)                               // 获得短名
    {
        if (str.Length> longLeght)
        {
            return str.Substring(0, longLeght)+"...";
        }
        else
        {
            return str;
        }
    }


    private Transform AddMiddleButton(FileSystemInfo fileInfo, MiddleButtonType type)     // 按分类添加中间按钮
    {
        Transform t;
        switch (type)
        {
            case MiddleButtonType.File:       // 文件
                t = InstantiateMoBan(moBan_File, t_MiddleGrid, FILE_NAME,true);
                t.Find("Text").GetComponent<Text>().text = GetShortName(Path.GetFileNameWithoutExtension(fileInfo.FullName));
                t.Find("GeiShi/Text").GetComponent<Text>().text = fileInfo.Extension.Substring(1);
                break;
            case MiddleButtonType.Folder:    // 文件夹
                t = InstantiateMoBan(moBan_Folder, t_MiddleGrid, FLODER_NAME, true);
                t.Find("Text").GetComponent<Text>().text = GetShortName(fileInfo.Name);

                MyEnumColor biaoJiColor = MyEnumColor.Hui;
                bool isBiaoJi = Ctrl_UserInfo.Instance.GetIsBiaoJi(fileInfo.FullName, ref biaoJiColor);
                if (isBiaoJi)
                {
                    GameObject biaoJi = t.Find("BiaoJi").gameObject;
                    biaoJi.SetActive(true);
                    biaoJi.GetComponent<Image>().color = MyColor.GetColor(biaoJiColor);
                }

                break;
            case MiddleButtonType.Drive:     // 磁盘
                t = InstantiateMoBan(moBan_YinPan, t_MiddleGrid, YINPAN_NAME, true);
                string reStr = fileInfo.Name;
                reStr= reStr.Replace(":\\", " 盘");
                t.Find("Text").GetComponent<Text>().text = reStr;
                break;
            case MiddleButtonType.Computer:  // 我的电脑
                t = InstantiateMoBan(moBan_Computer, t_MiddleGrid, COMPUTER_NAME, true);
                t.Find("Text").GetComponent<Text>().text ="我的电脑";
                break;
            case MiddleButtonType.ZhuoMain:  // 桌面
                t = InstantiateMoBan(moBan_ZhuoMain, t_MiddleGrid, ZHUOMAIN_NAME, true);
                t.Find("Text").GetComponent<Text>().text = "桌面";
                break;
            case MiddleButtonType.Music:    // 音频文件
                t = InstantiateMoBan(moBan_Music, t_MiddleGrid, MUSIC_NAME, true);
                t.Find("Text").GetComponent<Text>().text = GetShortName(Path.GetFileNameWithoutExtension(fileInfo.FullName));
                t.Find("GeiShi/Text").GetComponent<Text>().text = fileInfo.Extension.Substring(1);
                break;
            default:
                throw new Exception("未定义");
        }

        GameObject go = t.gameObject;
        if (type != MiddleButtonType.File)                             // 文件加载完图才添加按钮事件
        {
            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (go.Equals(go_CurrentSelect) && isSelect)            // 双击
                {
                    isSelect = false;
                    switch (go_CurrentSelect.name)
                    {
                        case FLODER_NAME:    //双击文件夹
                        case YINPAN_NAME:    //双击硬盘
                            mFileBrowser.GoInSubDirectory(fileInfo.Name);
                            RefreshMiddleContent();      // 刷新
                            break;
                        case COMPUTER_NAME: // 双击我的电脑
                            mFileBrowser.GoToRoot(true);
                            RefreshMiddleContent();      // 刷新
                            break;
                        case ZHUOMAIN_NAME: // 双击桌面
                            string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            mFileBrowser.RetrieveFiles(new DirectoryInfo(Desktop), true);
                            RefreshMiddleContent();      // 刷新
                            break;
                        case MUSIC_NAME:    //音乐文件
                            MyEventCenter.SendEvent(E_GameEvent.ShowMusicInfo, t.Find("Text").GetComponent<Text>(),(FileInfo)fileInfo,true);
                            break;
                        default:
                            throw new Exception("没有定义 —— "+ go_CurrentSelect.name);
                    }
     
                }
                else
                {
                    if (isShowLeftTip)
                    {
                        isShowLeftTip = false;
                        go_MouseLeftClick.SetActive(false);
                    }
                    go_CurrentSelect = go;
                    m_CurrentSelectFile = fileInfo;
                    Ctrl_Coroutine.Instance.StartCoroutine(CheckoubleClick());
                }
            });
        }
        l_MiddleItems.Add(go);
        return t;
    }




    private void InitMoBan_Tu(Transform t, FileInfo fileInfo)   // 初始化图片文件
    {
        MyLoadTu.LoadSingleTu(fileInfo, (bean) =>
        {
            allGoK_ResultBeanV.Add(t.gameObject, bean);
            t.Find("Icon").GetComponent<Image>().sprite = bean.SP;
            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (t.gameObject.Equals(go_CurrentSelect) && isSelect)            // 双击
                {
                    isSelect = false;
                    MyEventCenter.SendEvent(E_GameEvent.ShowSingleTuDaoRu, bean);
                }
                else                                                              // 单击
                {
                    go_CurrentSelect = t.gameObject;
                    m_CurrentSelectFile = fileInfo;
                    if (isNormalClick && !isShift)
                    {
                        if (chooseGOK_BgV.Count > 0)
                        {
                            foreach (GameObject bgGo in chooseGOK_BgV.Values)
                            {
                                bgGo.SetActive(false);
                            }
                            chooseGOK_BgV.Clear();
                        }
                    }
                    if (isShift && chooseGOK_BgV.Count > 0)         // 按下 Shift
                    {

                        List<GameObject> tmpList = new List<GameObject>(chooseGOK_BgV.Keys);
                        GameObject lastGo = tmpList[tmpList.Count - 1];
                        int index1 = l_MiddleItems.IndexOf(go_CurrentSelect);
                        int index2 = l_MiddleItems.IndexOf(lastGo);
                        int minIndex = Mathf.Min(index1, index2);
                        int maxIndex = Mathf.Max(index1, index2);
                        for (int i = minIndex + 1; i < maxIndex; i++)
                        {
                            AddChoose(l_MiddleItems[i]);
                        }
                    }
                    AddChoose(go_CurrentSelect);
                    input_GeiMing.text = allGoK_ResultBeanV[go_CurrentSelect].SP.name; 
                    Ctrl_Coroutine.Instance.StartCoroutine(CheckoubleClick());
                }
            });

        });
    }



    #endregion



    #region 书签

    private void OnToggle_ShuQian(bool ison) // 切换 书签
    {
        go_ShuQian.SetActive(ison);
        if (ison)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt_Right);
        }
    }



    private void CreateFavoites(string favPath)     // 创建收藏的按钮出来
    {
        DirectoryInfo dir = new DirectoryInfo(favPath);
        Transform t = InstantiateMoBan(moBan_Favorites, rt_ShuQianContant);
        GameObject go = t.gameObject;
        t.Find("Text").GetComponent<Text>().text = dir.Name; // 设置文字
        t.GetComponent<Button>().onClick.AddListener(() =>   // 设置点击回调
        {
            mFileBrowser.Relocate(dir.FullName);
            RefreshMiddleContent();  // 刷新中间
        });
        go.SetActive(true);
        mb_Favorites.Add(go);

    }


    #endregion


    #region 大小

    private void Btn_OpenSize()  // 打开大小设置
    {
        if (!go_ModeSize.activeSelf)
        {
            anim_SizeIcon.DOPlayForward();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt_Right);
            go_ModeSize.SetActive(true);
            if (go_ModeFilter.activeSelf&& go_ModeSorting.activeSelf)
            {
                Btn_CloseFilter();
                Btn_CloseSorting();

            }
        }
        else
        {
            Btn_CloseSize();
        }
    }

    private void Btn_CloseSize() // 关闭大小设置
    {
        anim_SizeIcon.DOPlayBackwards();
        go_ModeSize.SetActive(false);
    }


    private void OnToggle_ChangeSizeMode(string changeName) // 切换大小模式
    {
        tx_SizeBig.color = Color.gray;
        tx_SizeMiddle.color = Color.gray;
        tx_SizeSmall.color = Color.gray;

        switch (changeName)
        {
            case "ItemBig":
                tx_SizeBig.color = LBColor;
                tx_Size1.text = "大图标";
                grid_Contant.CallSize = SIZE_BIG;
                break;
            case "ItemMiddle":
                tx_SizeMiddle.color = LBColor;
                tx_Size1.text = "中等图标";
                grid_Contant.CallSize = SIZE_MIDDLE;
                break;
            case "ItemSmall":
                tx_SizeSmall.color = LBColor;
                tx_Size1.text = "小图标";
                grid_Contant.CallSize = SIZE_SMALL;
                break;
            default:
                throw new Exception("未定义 —— "+changeName);
        }



    }

    #endregion


    #region 过滤

    private void Btn_OpenFilter()                  // 打开过滤设置
    {
        if (!go_ModeFilter.activeSelf)
        {
            anim_FilterIcon.DOPlayForward();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt_Right);
            go_ModeFilter.SetActive(true);

            if (go_ModeSize.activeSelf&& go_ModeSorting.activeSelf)
            {
                Btn_CloseSize();
                Btn_CloseSorting();

            }
        }
        else
        {
            Btn_CloseFilter(); // 如果开着就关闭啊
        }
    }

    private void Btn_CloseFilter()                  // 关闭过滤设置
    {
        anim_FilterIcon.DOPlayBackwards();
        go_ModeFilter.SetActive(false);
    }

    private void OnToggle_ChangeFilterMode(string changeName) // 切换过滤模式
    {
        tx_FilterAll.color = Color.gray;
        tx_FilterTexture.color = Color.gray;
        tx_FilterFolder.color = Color.gray;

        switch (changeName)
        {
            case "ItemAll":
                tx_FilterAll.color = LBColor;
                tx_Filter1.text = SHOW_NAME1;
                isOnlyShowFolder = false;
                mFileBrowser.SetFilters(null);
                break;
            case "ItemTexture":
                tx_FilterTexture.color = LBColor;
                tx_Filter1.text = SHOW_NAME2;
                isOnlyShowFolder = false;
                mFileBrowser.SetFilters(MyFilterUtil.ONLY_TU_AUDIO_FILTER);
                break;
            case "ItemFolder":
                tx_FilterFolder.color = LBColor;
                tx_Filter1.text = SHOW_NAME3;
                isOnlyShowFolder = true;
                break;
            default:
                throw new Exception("未定义 —— " + changeName);
        }

        RefreshMiddleContent();         // 中间的内容刷新
    }

    #endregion


    #region 排序


    private void Btn_OpenSorting()  // 打开排序设置
    {
        if (!go_ModeSorting.activeSelf)
        {
            anim_SortIcon.DOPlayForward();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt_Right);
            go_ModeSorting.SetActive(true);

            if (go_ModeSize.activeSelf&& go_ModeFilter.activeSelf)
            {
                Btn_CloseSize();
                Btn_CloseFilter();

            }
        }
        else
        {
            Btn_CloseSorting();
        }
    }

    private void Btn_CloseSorting() // 关闭排序设置
    {
        anim_SortIcon.DOPlayBackwards();
        go_ModeSorting.SetActive(false);
    }


    private void OnToggle_ChangeSortMode(string changeName) // 切换排序模式
    {
        tx_SortName.color = Color.gray;
        tx_SortType.color = Color.gray;
        tx_SortDate.color = Color.gray;

        switch (changeName)
        {
            case "ItemName":
                tx_SortName.color = LBColor;
                tx_Sort1.text = "名称排序";
                mFileBrowser.SetSortMode(FileBrowser.SortingMode.Name);
                break;
            case "ItemType":
                tx_SortType.color = LBColor;
                tx_Sort1.text = "类型排序";
                mFileBrowser.SetSortMode(FileBrowser.SortingMode.Type);
                break;
            case "ItemDate":
                tx_SortDate.color = LBColor;
                tx_Sort1.text = "日期排序";
                mFileBrowser.SetSortMode(FileBrowser.SortingMode.Date);
                break;
            default:
                throw new Exception("未定义 —— " + changeName);
        }


        RefreshMiddleContent();

    }

    #endregion

    #region 改名

    
    private readonly Dictionary<FileInfo,string> fileK_NewFullPathV = new Dictionary<FileInfo, string>();
    private void Btn_GeiMing()                     // 点击 准备改名
    {
        Ctrl_Coroutine.Instance.StartCoroutine(StartSetGeiMingItem(input_GeiMing));
        go_IsGaiMing.SetActive(true);

    }

    private void Btn_GeiMing222()                 // 点击 再次改名
    {
        Ctrl_Coroutine.Instance.StartCoroutine(StartSetGeiMingItem(input_GeiMing222));
    }

    private void InputEnd_GeiMing222(string value)             // 输入完成 再次改名
    {
        if (!string.IsNullOrEmpty(value) && value.Length >1)
        {
            Ctrl_Coroutine.Instance.StartCoroutine(StartSetGeiMingItem(input_GeiMing222));
        }
    }


    private int addIndex;

    IEnumerator StartSetGeiMingItem(InputField inputField)         // 设置名称每个小 Item
    {
        addIndex = 0;
        if (rt_GeiMing.childCount > 0)
        {
            for (int i = 0; i < rt_GeiMing.childCount; i++)
            {
                Object.Destroy(rt_GeiMing.GetChild(i).gameObject);
            }
            fileK_NewFullPathV.Clear();
        }

        string newFileName = inputField.text;              // 要改的名称的前缀
        if (string.IsNullOrEmpty(newFileName))
        {
            newFileName = "未定义名称";
        }

        List<GameObject> sortList = GetSortChoose();      // 排序
        for (int i = 1; i < sortList.Count + 1; i++)
        {
            FileInfo fileInfo = allGoK_ResultBeanV[sortList[i - 1]].File;
            string yuanName = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            string path = fileInfo.FullName.Replace(@"\", "/");        
            int tmpCount = path.LastIndexOf("/", StringComparison.Ordinal);
            string folderPath = path.Substring(0, tmpCount + 1);                  // 前路径
            string fileFullPath;
            if (addIndex>0)
            {
                fileFullPath = folderPath + newFileName + "_" + (i + addIndex-1).ToString("D2") + fileInfo.Extension;

            }
            else
            {
                fileFullPath = folderPath + newFileName + "_" + i.ToString("D2") + fileInfo.Extension;
            }
            while (File.Exists(fileFullPath))     // 如果存在的话在上面加1
            {
                addIndex++;
                fileFullPath = folderPath + newFileName + "_" + addIndex.ToString("D2") + fileInfo.Extension;
            }
            fileK_NewFullPathV.Add(fileInfo, fileFullPath);

            Transform t = InstantiateMoBan(go_MoBanGeiMing, rt_GeiMing);
            t.Find("TxYuanName").GetComponent<Text>().text = yuanName;
            t.Find("TxGeiMing").GetComponent<Text>().text = Path.GetFileNameWithoutExtension(fileFullPath);
            yield return 0;
        }
    }


    private void Btn_OnSureGaiMing()           // 确定改名
    {
        go_BottomBtn.SetActive(false);
        go_BottomWait.SetActive(true);
        Ctrl_Coroutine.Instance.StartCoroutine(StartGaiMing());
    }

    IEnumerator StartGaiMing()                 // 开始改名
    {
        bool isWhile2Do = true;
        new Thread(() =>
        {
            Foreach2Do(ref isWhile2Do);
        }).Start();

        while (isWhile2Do)
        {
            yield return 0;
        }
        Btn_ShuaiXin();
        CloseIsGetMing();
    }
    private void Foreach2Do(ref bool isWhile2Do)   // 一直循环改，改到成功为止
    {

        while (isWhile2Do)
        {
            try
            {
                foreach (FileInfo fileInfo in fileK_NewFullPathV.Keys)
                {
                    string newPath = fileK_NewFullPathV[fileInfo];
                    if (!File.Exists(newPath))
                    {
                        fileInfo.MoveTo(newPath);
                    }
                }
                isWhile2Do = false;
            }
            catch
            {
                isWhile2Do = true;
            }
        }

    }



    private void Btn_OnFalseGeiMing()          // 取消
    {
        CloseIsGetMing();
    }


    private void CloseIsGetMing()             // 关闭
    {
        go_IsGaiMing.SetActive(false);
        go_BottomBtn.SetActive(true);
        go_BottomWait.SetActive(false);
        input_GeiMing222.text = "";
        fileK_NewFullPathV.Clear();
        for (int i = 0; i < rt_GeiMing.childCount; i++)
        {
            Object.Destroy(rt_GeiMing.GetChild(i).gameObject);
        }
    }




    #endregion

    #region  头部栏

    // 上
    private void CloseItemPath(GameObject go)               // 点击了文件路径的 x，关闭自己 
    {
        go.SetActive(false);
        if (!go_Add.activeSelf)
        {
            go_Add.SetActive(true);
        }
    }


    private void Btn_AddItem()                             // 点击再添加头文件夹 菜单
    {
        if (!go_ItemPath2.activeSelf)
        {
            go_ItemPath2.SetActive(true);
            tg_ItemPath.ChangeToggleOn(go_ItemPath2.name);
            mCurrentTopIndex = 1;
        }
        else if (!go_ItemPath3.activeSelf)
        {
            go_ItemPath3.SetActive(true);
            tg_ItemPath.ChangeToggleOn(go_ItemPath3.name);
            mCurrentTopIndex = 2;
        }
        else if (!go_ItemPath4.activeSelf)
        {
            go_ItemPath4.SetActive(true);
            tg_ItemPath.ChangeToggleOn(go_ItemPath4.name);
            mCurrentTopIndex = 3;
        }
        else if (!go_ItemPath5.activeSelf)
        {
            go_ItemPath5.SetActive(true);
            tg_ItemPath.ChangeToggleOn(go_ItemPath5.name);
            go_Add.SetActive(false);
            mCurrentTopIndex = 4;
        }


        LayoutRebuilder.ForceRebuildLayoutImmediate(rt_Top);
    }


    private void E_OnTopPathChange(string changeName)      // 切换头部路径
    {
        switch (changeName)
        {
            case "ItemPath1":
                mCurrentTopIndex = 0;
                break;
            case "ItemPath2":
                mCurrentTopIndex = 1;
                break;
            case "ItemPath3":
                mCurrentTopIndex = 2;
                break;
            case "ItemPath4":
                mCurrentTopIndex = 3;
                break;
            case "ItemPath5":
                mCurrentTopIndex = 4;
                break;
            default:
                MyLog.Red("为什么还有其他？ —— "+ changeName);
                break;
        }
        mFileBrowser.Relocate(l_AddressPaths[mCurrentTopIndex]);
        RefreshMiddleContent();

    }


    private void Btn_ShuaiXin()                            // 刷新
    {
        mFileBrowser.Refresh();
        RefreshMiddleContent();
    }


    // 下

    private void Btn_OnHistoryPre()                   // 点击 <-  转到上一个打开的文件夹
    {
        mFileBrowser.GoToPrevious();
        RefreshMiddleContent();
    }

    private void Btn_OnHistoryNext()                  // 点击 ->  转到下一个打开的文件夹
    {
        mFileBrowser.GotToNext();
        RefreshMiddleContent();
    }
      

    private void Btn_OnClickAddressPath()             // 点击更改路径
    {

        MyOpenFileOrFolder.OpenFolder(tx_Path.text, "选择文件夹", (path) =>
        {
            tx_Path.text = path;
            mFileBrowser.Relocate(path);
            RefreshMiddleContent();       // 刷新下中间
        });
    }


    private void Toggle_ChangeIsStar(bool isOn)       // 切换是否收藏
    {
        string favPath = tx_Path.text;
        if (isOn) 
        {
            if (!Ctrl_UserInfo.Instance.L_FavoritesPath.Contains(favPath))
            {
                CreateFavoites(favPath);
                Ctrl_UserInfo.Instance.L_FavoritesPath.Add(favPath);
                LayoutRebuilder.ForceRebuildLayoutImmediate(rt_ShuQianContant);
            }
        }
        else
        {
            if (Ctrl_UserInfo.Instance.L_FavoritesPath.Contains(favPath))
            {
                int index = Ctrl_UserInfo.Instance.L_FavoritesPath.IndexOf(favPath);
                GameObject go = mb_Favorites[index];
                Ctrl_UserInfo.Instance.L_FavoritesPath.RemoveAt(index);
                mb_Favorites.RemoveAt(index);
                Object.DestroyImmediate(go);
            }
        }
    }



    private void Btn_OpenFolder()                     // 打开文件夹
    {
        string path = tx_Path.text;
        Application.OpenURL(path);

    }

    private void Btn_OnGoToParent()                   // 去父文件夹中
    {
        mFileBrowser.GoInParent();
        RefreshMiddleContent();

    }

    #endregion


    #region  框选  选中

    private void AddChoose(GameObject go)                 // 添加进选中
    {
        GameObject goBg = go.transform.Find("Bg").gameObject;
        if (!chooseGOK_BgV.ContainsKey(go) && !goBg.activeSelf)
        {
            goBg.SetActive(true);
            chooseGOK_BgV.Add(go, goBg);
        }

        tx_TipZhang.text = chooseGOK_BgV.Count.ToString();   // 多少张
        btnDaoRu.interactable = true;   //可以导入了
        btnGeiMing.interactable = true;// 可以改名了

    }




    private void ClearAllChooseZhong()                                    // 清除所有选中的
    {
        rt_Kuang.sizeDelta = Vector2.one;

        if (chooseGOK_BgV.Count > 0)
        {
            foreach (GameObject bgGo in chooseGOK_BgV.Values)
            {
                bgGo.SetActive(false);
            }
            chooseGOK_BgV.Clear();
            tx_TipZhang.text = "0";
            btnDaoRu.interactable = false;
            go_CurrentSelect = null;
            m_CurrentSelectFile = null;
            btnGeiMing.interactable = false;
            input_GeiMing.text = "";
        }
    }

    private void E_OnClickKuangDown(Vector2 startPosition)                 // 开始框选 或者 单单是点击一下
    {
        rt_Kuang.gameObject.SetActive(true);
        rt_Kuang.anchoredPosition = startPosition;
        ClearAllChooseZhong();
        mKuangXuan.OnClickDown();
    }


    private void E_OnKuangDarg(Vector2 widthHeigh)                        // 在拖动 调整框的大小
    {
        rt_Kuang.sizeDelta = widthHeigh;
    }


    private void E_OnClickKuangUp()                                       // 结束框选
    {
        rt_Kuang.sizeDelta = Vector2.zero;
        mKuangXuan.OnClickUp();
        tx_TipZhang.text = chooseGOK_BgV.Count.ToString();

        if (chooseGOK_BgV.Count > 0)
        {
            btnDaoRu.interactable = true;
            btnGeiMing.interactable = true;
            foreach (GameObject tmpGo in chooseGOK_BgV.Keys)
            {
                go_CurrentSelect = tmpGo;
                break;
            }
            if (allGoK_ResultBeanV.ContainsKey(go_CurrentSelect))
            {
                input_GeiMing.text = allGoK_ResultBeanV[go_CurrentSelect].SP.name;
            }

        }

    }


    #endregion


    #region 鼠标右键 文件夹

    private bool isShowLeftTip =false;



    private void E_OnMouseLeftClick()                   // 点击了鼠标右键
    {
        if (!mUIGameObject.activeSelf)
        {
            return;
        }
        if (isShowLeftTip)
        {
            go_MouseLeftClick.SetActive(false);
        }
        if (null!=go_CurrentSelect && !isShowLeftTip && go_CurrentSelect.name == FLODER_NAME)
        {
            isShowLeftTip = true;
            go_MouseLeftClick.transform.position = go_CurrentSelect.transform.position;
            go_MouseLeftClick.SetActive(true);

        }

    }


    private void Btn_ChooseColor(MyEnumColor colorEnum,bool isNull =false)
    {
        if (isShowLeftTip)
        {
            isShowLeftTip = false;
            go_MouseLeftClick.SetActive(false);

            switch (go_CurrentSelect.name)
            {
                case FLODER_NAME:         // 文件夹
                    GameObject biaoJi = go_CurrentSelect.transform.Find("BiaoJi").gameObject;
                    biaoJi.SetActive(!isNull);
                    if (!isNull)
                    {
                        biaoJi.GetComponent<Image>().color = MyColor.GetColor(colorEnum);
                        Ctrl_UserInfo.Instance.AddBiaoJi(m_CurrentSelectFile.FullName,colorEnum);
                    }
                    else
                    {
                        Ctrl_UserInfo.Instance.RemoveBiaoJi(m_CurrentSelectFile.FullName);
                    }
                    break;
            }


        }
    }

    #endregion


//    private void E_OnDuoTuDaoRu(EGameType type,ushort index, List<ResultBean> resultBeans, bool isFromDaoRu)       // 点击了信息页的导入
//    {
//        if (isFromDaoRu)
//        {
//            // 把导入的都变成绿色字体
//            foreach (ResultBean resultBean in resultBeans)
//            {
//                foreach (GameObject go in chooseGOK_BgV.Keys)
//                {
//                    if (resultBean == allGoK_ResultBeanV[go])
//                    {
//                        go.transform.Find("Text").GetComponent<Text>().color = Color.green;
//                        break;
//                    }
//                }
//            }
//
//            // 清空选择
//            ClearAllChooseZhong();
//        }
//    }


    private void E_GoToNextFolderDaoRu()                       // 导入后 到下个文件兲
    {
        if (!mUIGameObject.activeSelf)
        {
            return;
        }
        string nextPath = mFileBrowser.GetNextFolderPath();
        if (string.IsNullOrEmpty(nextPath))
        {
            MyLog.Red("没有下个文件夹了");
        }
        else
        {
            mFileBrowser.Relocate(nextPath);
            RefreshMiddleContent();
        }

    }


    private void E_OnClickCtrlAndA()                          // 按下了 Ctrl + A
    {
        if (!mUIGameObject.activeSelf)
        {
            return;
        }
        foreach (GameObject allGo in allGoK_ResultBeanV.Keys)
        {
            AddChoose(allGo);
        }
    }


    private void E_OnClickCtrlAndC()                          // 按下了 Ctrl + C
    {
        if (!mUIGameObject.activeSelf || null == m_CurrentSelectFile)
        {
            return;
        }
        switch (go_CurrentSelect.name)
        {
            case FILE_NAME:
            case FLODER_NAME:
                GUIUtility.systemCopyBuffer = Path.GetFileNameWithoutExtension(m_CurrentSelectFile.FullName);
                break;
        }
        
    }


    private List<GameObject> GetSortChoose()                  // 排序
    {
        List<GameObject> sortList = new List<GameObject>(chooseGOK_BgV.Keys);
        for (int i = 0; i < sortList.Count - 1; i++)
        {
            for (int j = i + 1; j < sortList.Count; j++)
            {
                string current = allGoK_ResultBeanV[sortList[i]].SP.name;
                string duiBi = allGoK_ResultBeanV[sortList[j]].SP.name;
                if (String.CompareOrdinal(current, duiBi) > 0)
                {
                    GameObject tmpGo = sortList[i];
                    sortList[i] = sortList[j];
                    sortList[j] = tmpGo;
                }
            }
        }
        return sortList;
    }



}