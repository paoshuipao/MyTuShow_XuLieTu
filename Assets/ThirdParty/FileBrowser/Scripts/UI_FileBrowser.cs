/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Threading;
using PSPUtil.StaticUtil;

public class UI_FileBrowser : MonoBehaviour //  文件浏览器
{

    public void OpenFile()
    {
        if (CurrentlySelected == null)
        {
            return;
        }

        bool bClose = false;

        // Retrieve the name of the directory stored in the button label
        RectTransform _CurrentRect = CurrentlySelected.gameObject.GetComponent<RectTransform>();
        string _text = _CurrentRect.Find("Text").gameObject.GetComponent<Text>().text;

        if (CurrentlySelected.gameObject.name == "Folder" || CurrentlySelected.gameObject.name == "Drive")
        {
            // Open the folder if it is one
            _FB.GoInSubDirectory(_text);
        }
        else if (CurrentlySelected.gameObject.name == "File")     // 点击了文件就隐藏
        {
            m_pOpenedPath = _FB.GetFilePath(_text);
            bClose = true;
        }

        // Refresh the buttons with the new hierarchy
        RefreshButtons();
        CurrentlySelected = null;

        if (bClose)
        {
            Cancel();
        }
    }



    //—————————————————— UI 管理——————————————————
    public void Open()
    {
        m_pOpenedPath = null;
        FileBrowserWindow.SetActive(true);

        if (string.IsNullOrEmpty(StartingDirectory))
        {
            _FB.Relocate(null);
        }
        else
        {
            _FB.Relocate(StartingDirectory);
        }
        RefreshButtons();
    }

    public void Open(string Path)
    {
        m_pOpenedPath = null;
        FileBrowserWindow.SetActive(true);

        if (string.IsNullOrEmpty(Path))
        {
            _FB.Relocate(null);
        }
        else
        {
            _FB.Relocate(Path);
        }
        RefreshButtons();
    }

    public void Cancel()
    {
        FileBrowserWindow.SetActive(false);
    }

    public string GetPath()
    {
        return m_pOpenedPath;
    }

    public void RefreshButtons()
    {
        CancelCurrentThumbnails();

        MainPanel.sizeDelta = Vector2.zero;

        // Destroy previous buttons
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].gameObject.SetActive(false);
            DestroyImmediate(Buttons[i].gameObject);
        }

        // Clear List
        Buttons.Clear();

        DirectoryInfo Dir = _FB.GetCurrentDirectory();

        if (Dir != null)
            CurrentAdress.text = Dir.FullName;
        else
            CurrentAdress.text = string.Empty;

        bool isFavorite = false;
        for (int i = 0; i < Favorites.Count; i++)
        {
            RectTransform _CurrentRect = Favorites[i].gameObject.GetComponent<RectTransform>();

            if (_CurrentRect.Find("Name").gameObject.GetComponent<Text>().text == CurrentAdress.text)
            {
                isFavorite = true;
                break;
            }
        }

        if (isFavorite)
        {
            FavoriteImage.color = new Color(1, 1, 0, 1);
        }
        else
        {
            FavoriteImage.color = new Color(1, 1, 1, 1);
        }

        // Retrieve sub directories
        DirectoryInfo[] _childs = _FB.GetChildDirectories();

        // Add a button for each folder
        for (int i = 0; i < _childs.Length; i++)
        {
            // Dissociate folders from drives
            if (_childs[i].Parent != null)
                AddButton(_childs[i].Name, ButtonType.Folder);
            else
                AddButton(_childs[i].Name, ButtonType.Drive);
        }

        if (!FolderOnly.isOn)
        {
            // Retrieve files
            FileInfo[] _files = _FB.GetFiles();

            // Add a button for each file
            for (int i = 0; i < _files.Length; i++)
            {
                AddButton(_files[i].Name, ButtonType.File);
            }

            lock (_ThumbnailsFiles)
            {
                _ThumbnailsFiles = _files;
            }

            GenerateNewThumbnails = true;
            StartCoroutine(WaitForThumbnails());
        }

        CheckButtonsVisibility();
    }

    private void AddButton(string FileName, ButtonType Type)
    {
        // Get height from template button
        float ButtonHeight = MenuItem.gameObject.GetComponent<RectTransform>().rect.height;

        // Create new button
        Button NewButton = GameObject.Instantiate(MenuItem) as Button;
        NewButton.gameObject.SetActive(true);
        NewButton.gameObject.transform.SetParent(MainPanel.gameObject.transform);

        // Place button
        RectTransform _CurrentRect = NewButton.gameObject.GetComponent<RectTransform>();
        _CurrentRect.localPosition = new Vector3(0, (-10) * (Buttons.Count + 1) + (-ButtonHeight) * Buttons.Count, 0);
        _CurrentRect.sizeDelta = new Vector2(-20, ButtonHeight);

        // Set button label to retrieve it later
        _CurrentRect.Find("Text").gameObject.GetComponent<Text>().text = FileName;

        // Set button name to store it's type
        switch (Type)
        {
            case ButtonType.File:
                NewButton.gameObject.name = "File";
                _CurrentRect.Find("Image").gameObject.GetComponent<Image>().sprite = File;
                break;
            case ButtonType.Folder:
                NewButton.gameObject.name = "Folder";
                _CurrentRect.Find("Image").gameObject.GetComponent<Image>().sprite = Folder;
                break;
            case ButtonType.Drive:
                NewButton.gameObject.name = "Drive";
                _CurrentRect.Find("Image").gameObject.GetComponent<Image>().sprite = Drive;
                break;
            case ButtonType.Computer:
                NewButton.gameObject.name = "Computer";
                _CurrentRect.Find("Image").gameObject.GetComponent<Image>().sprite = Computer;
                break;
        }

        // Add the button callback
        NewButton.onClick.RemoveAllListeners();
        NewButton.onClick.AddListener(() => SelectFile(NewButton));

        // Add the button to the list
        Buttons.Add(NewButton);

        // Resize parent panel to fit the new button
        MainPanel.sizeDelta = new Vector2(0, 10 * (Buttons.Count + 1) + ButtonHeight * Buttons.Count);
    }

    public void ChangeItemSize()
    {
        ThumbSize = (int)ButtonSize.value;

        RectTransform _CurrentRect = MenuItem.gameObject.GetComponent<RectTransform>();
        _CurrentRect.localPosition = new Vector3(-5, -10, 0);
        _CurrentRect.sizeDelta = new Vector2(-30, ThumbSize);

        RectTransform _image = _CurrentRect.Find("Image").gameObject.GetComponent<RectTransform>();
        _image.anchoredPosition3D = new Vector3(ThumbSize / 2, 0, 0);
        _image.sizeDelta = new Vector2(ThumbSize - 10, ThumbSize - 10);

        RectTransform _text = _CurrentRect.Find("Text").gameObject.GetComponent<RectTransform>();
        _text.anchoredPosition3D = new Vector3(-20, 0, 0);
        _text.sizeDelta = new Vector2(-(ThumbSize * 2) - 40, 40);

        RefreshButtons();
    }


    //—————————————————— 快捷键 ——————————————————


 
    public void ToPrevious()                 // 转到上一个打开的文件
    {
        _FB.GoToPrevious();
        RefreshButtons();
    }

   
    public void ToNext()                     // 转到下一个打开的文件
    {
        _FB.GotToNext();
        RefreshButtons();
    }


    public void ToParent()                   // 回到层次结构中
    {
        _FB.GoInParent();
        RefreshButtons();
    }

    public void ToRoot()                      // 打开根文件夹
    {
        _FB.GoToRoot(true);
        RefreshButtons();
    }


    public void Desktop()                     // 打开桌面 
    {
        string Desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        _FB.RetrieveFiles(new DirectoryInfo(Desktop), true);
        RefreshButtons();
    }

    
    public void MyDocuments()                 // 打开 MyDocuments
    {
        string MyDocuments = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        _FB.RetrieveFiles(new DirectoryInfo(MyDocuments), true);
        RefreshButtons();
    }

    public void MyMusic()                     // 打开 MyMusic
    {
        string MyMusic = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic);
        _FB.RetrieveFiles(new DirectoryInfo(MyMusic), true);
        RefreshButtons();
    }

    public void MyPictures()                 // 打开 MyPictures
    { 
        string MyPictures = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
        _FB.RetrieveFiles(new DirectoryInfo(MyPictures), true);
        RefreshButtons();
    }

   
    public void GameDir()                    // 打开 Game directory
    {
        string GameDirectory = Application.dataPath;
        _FB.RetrieveFiles(new DirectoryInfo(GameDirectory), true);
        RefreshButtons();
    }



    //—————————————————— 文件夹管理 ——————————————————
    public void Rename()
    {
        if (RenameInputField.text.Trim() != string.Empty
            && CurrentlySelected != null
            && RenameInputField.text.IndexOfAny(new char[] { '/', '\\', '?', '%', '*', ':', '|', '"', '<', '>' }) == -1)
        {
            RectTransform _CurrentRect = CurrentlySelected.gameObject.GetComponent<RectTransform>();
            string _text = _CurrentRect.Find("Text").gameObject.GetComponent<Text>().text;

            string dirfullpath = _FB.GetDirectoryPath(_text);

            if (dirfullpath != null)
            {
                DirectoryInfo _current = new DirectoryInfo(dirfullpath);

                DirectoryInfo[] _currentChilds = _current.GetDirectories();
                FileInfo[] _currentFiles = _current.GetFiles();

                DirectoryInfo _new = new DirectoryInfo(NewFolder(RenameInputField.text));

                for (int i = 0; i < _currentChilds.Length; i++)
                {
                    System.IO.Directory.Move(_currentChilds[i].FullName, _new.FullName + "\\" + _currentChilds[i].Name);
                }

                for (int i = 0; i < _currentFiles.Length; i++)
                {
                    System.IO.Directory.Move(_currentFiles[i].FullName, _new.FullName + "\\" + _currentFiles[i].Name);
                }

                System.IO.Directory.Delete(_current.FullName);
            }
            else
            {
                string filefullpath = _FB.GetFilePath(_text);

                if (filefullpath != null)
                {
                    FileInfo _file = new FileInfo(filefullpath);

                    string _New = RenameInputField.text;
                    int iTry = 0;

                    while (_FB.GetFilePath(_New) != null)
                    {
                        _New = RenameInputField.text + " (" + iTry + ")";

                        iTry++;
                    }

                    byte[] fileData = new byte[_file.Length];

                    FileStream fs = _file.OpenRead();

                    fs.Read(fileData, 0, (int)_file.Length);

                    fs.Dispose();

                    System.IO.File.WriteAllBytes(_FB.GetCurrentDirectory().FullName + "\\" + _New + _file.Extension,
                        fileData);

                    System.IO.File.Delete(_file.FullName);
                }
            }

            _FB.Refresh();
            RefreshButtons();
        }

        WaitForNewName();
        RenameInputField.text = string.Empty;
    }

    public void WaitForNewName()
    {
        RenameInputField.gameObject.SetActive(!RenameInputField.gameObject.activeSelf);

        if (CurrentlySelected != null)
        {
            RectTransform _rect = RenameInputField.gameObject.GetComponent<RectTransform>();

            _rect.position = CurrentlySelected.gameObject.GetComponent<RectTransform>().position;
            _rect.sizeDelta = CurrentlySelected.gameObject.GetComponent<RectTransform>().sizeDelta;
            _rect.SetParent(null, true);
            _rect.SetParent(CurrentlySelected.gameObject.GetComponent<RectTransform>().parent, true);
            RenameInputField.Select();
        }
    }

    public void NewFolder()
    {
        string _New = "New Folder (0)";
        int iTry = 0;

        while (_FB.GetDirectoryPath(_New) != null)
        {
            _New = "New Folder (" + iTry + ")";

            iTry++;
        }

        System.IO.Directory.CreateDirectory(_FB.GetCurrentDirectory().FullName + "\\" + _New);
        _FB.Refresh();
        RefreshButtons();
    }

    public string NewFolder(string name)
    {
        string _New = name;
        int iTry = 0;

        while (_FB.GetDirectoryPath(_New) != null)
        {
            _New = name + " (" + iTry + ")";

            iTry++;
        }

        System.IO.Directory.CreateDirectory(_FB.GetCurrentDirectory().FullName + "\\" + _New);
        _FB.Refresh();
        RefreshButtons();

        return _FB.GetCurrentDirectory().FullName + "\\" + _New;
    }

    public void Delete()
    {
        if (CurrentlySelected != null)
        {
            RectTransform _CurrentRect = CurrentlySelected.gameObject.GetComponent<RectTransform>();
            string _text = _CurrentRect.Find("Text").gameObject.GetComponent<Text>().text;

            string FileToDelete = _FB.GetFilePath(_text);

            if (FileToDelete != null)
            {
                System.IO.File.Delete(FileToDelete);
            }
            else
            {
                string FolderToDelete = _FB.GetDirectoryPath(_text);

                if (FolderToDelete != null)
                {
                    System.IO.Directory.Delete(FolderToDelete);
                }
                else
                {
                    return;
                }
            }

            _FB.Refresh();
            RefreshButtons();
        }
    }

    public void SetSortMode(string mode)
    {
        if (mode == FileBrowser.SortingMode.Name.ToString())
            _FB.SetSortMode(FileBrowser.SortingMode.Name);
        else if (mode == FileBrowser.SortingMode.Date.ToString())
            _FB.SetSortMode(FileBrowser.SortingMode.Date);
        else if (mode == FileBrowser.SortingMode.Type.ToString())
            _FB.SetSortMode(FileBrowser.SortingMode.Type);

        SortModeOptions.parent.Find("Text").gameObject.GetComponent<Text>().text = "Sort by " + mode.ToLower() + ".";

        RefreshButtons();
        ShowSortMode();
    }

    public void ShowSortMode()
    {
        SortModeOptions.gameObject.SetActive(!SortModeOptions.gameObject.activeSelf);
    }


    //—————————————————— Favorites 标记 ——————————————————

    private string SAVE_FAVS_PATH ;   // 保存收藏路径
    
    public void OpenFavorite(Button _Button)        // 点击了一个收藏按钮
    {
        RectTransform _CurrentRect = _Button.gameObject.GetComponent<RectTransform>();
        _FB.Relocate(_CurrentRect.Find("Name").gameObject.GetComponent<Text>().text);
        RefreshButtons();
    }

    public void AddToFavs()            // 添加当前的路径进 收藏
    {
        if (_FB.GetCurrentDirectory() == null)
        {
            return;
        }

        StreamReader _sr = new StreamReader(SAVE_FAVS_PATH);   // 读取 txt

        string text = _sr.ReadToEnd();
        string[] paths = text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        bool bExist = false;
        string AllDirs = string.Empty;
        for (int i = 0; i < paths.Length; i++)
        {
            DirectoryInfo dir = new DirectoryInfo(paths[i]);

            if (dir.FullName == _FB.GetCurrentDirectory().FullName)
            {
                bExist = true;
            }
            else
            {
                AllDirs += dir.FullName;
                AllDirs += "\n";
            }
        }

        _sr.Dispose();

        if (!bExist)
        {
            StreamWriter _sw = new StreamWriter(SAVE_FAVS_PATH, true);
            _sw.WriteLine("\n" + _FB.GetCurrentDirectory().FullName);
            _sw.Dispose();
            FavoriteImage.color = new Color(1, 1, 0, 1);
        }
        else
        {
            StreamWriter _sw = new StreamWriter(SAVE_FAVS_PATH);
            _sw.Write(AllDirs);
            _sw.Dispose();
            FavoriteImage.color = new Color(1, 1, 1, 1);
        }

        RefreshFavorites();
    }


    //—————————————————— Filters 过滤器——————————————————



    public void ShowFilters()                    // 显示过滤器下拉列表或隐藏它 
    {
        FiltersOptions.gameObject.SetActive(!FiltersOptions.gameObject.activeSelf);
    }

  
    public void ChangeFilters(Button _Button)    // 回调过滤器按钮
    {
        // Set the selected filter tex
        RectTransform _CurrentRect = _Button.gameObject.GetComponent<RectTransform>();
        SelectedFilter.text = _CurrentRect.Find("Text").gameObject.GetComponent<Text>().text;

        // Retrieve the button index in the filters strings array

        int iIndex = 0;

        for (int i = 0; i < FiltersList.Count; i++)
        {
            if (_Button == FiltersList[i])
            {
                iIndex = i;
                break;
            }
        }

        // Set the new filter
        _FB.SetFilters(FiltersStrings[iIndex]);

        // Hide the filters and refresh the buttons with the new filter applied
        ShowFilters();
        RefreshButtons();
    }


    //—————————————————— 搜索 ——————————————————
    public void Search()
    {
        Loading.SetActive(true);

        CancelCurrentThumbnails();

        MainPanel.sizeDelta = Vector2.zero;

        // Destroy previous buttons
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].gameObject.SetActive(false);
            DestroyImmediate(Buttons[i].gameObject);
        }

        // Clear List
        Buttons.Clear();

        _FB.SearchFor(SearchField.text);

        StartCoroutine(WaitResults());
    }



    //—————————————————— 地址栏 ——————————————————


    public void SetNewPath()
    {
        _FB.Relocate(CurrentAdress.text);
        RefreshButtons();
    }



    //—————————————————— 缩略图 ——————————————————


    public void QuitThumbnailsThread()       // 退出线程
    {
        CancelThread = true;

        while (CancelThread)
        {
            Thread.Sleep(20);
        }

        ThumbnailsThread.Abort();
    }

    public void CancelCurrentThumbnails()    // 退出当前生成
    {
        if (!GenerateNewThumbnails)
            return;

        CancelGeneration = true;

        while (CancelGeneration)
        {
            Thread.Sleep(20);
        }
    }


    public void CheckButtonsVisibility()
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (Buttons[i].gameObject.transform.position.y > 1200)
            {
                Buttons[i].gameObject.SetActive(false);
            }
            else if (Buttons[i].gameObject.transform.position.y < 100)
            {
                Buttons[i].gameObject.SetActive(false);
            }
            else
            {
                Buttons[i].gameObject.SetActive(true);
            }
        }
    }



    #region 私有

    public RectTransform MainPanel;              // 将显示按钮的面板
    public Button MenuItem;                      // 按钮模板
    public Slider ButtonSize;                    // 提供按钮的大小 
    public GameObject FileBrowserWindow;         // 菜单根目录
    public Toggle FolderOnly;                    // 选择是否显示文件
    public Sprite Folder;                        // 文件夹 图片
    public Sprite Drive;
    public Sprite File;
    public Sprite Computer;
    public RectTransform SortModeOptions;        // 您可以选择的排序模式
    public InputField RenameInputField;          // 重命名输入文本字段
    public RectTransform FavoritePanel;          // 将显示按钮的面板
    public Button FavoriteTemplate;              // 按钮模板
    public Image FavoriteImage;                  // “星”图像，因此如果当前文件夹已经是最喜欢的，我们可以将其颜色更改为黄色
    public RectTransform FiltersOptions;         // 将显示过滤器的面板
    public Button FilterItem;                    // 过滤器模板
    public Text SelectedFilter;                  // 选定的过滤器文本区域
    public Text SearchField;                     // 搜索字段文本区域
    public GameObject Loading;
    public InputField CurrentAdress;             // 搜索字段文本区域


    private enum ButtonType // 点击按钮的类型
    {
        File,
        Folder,
        Drive,
        Computer,
    }

    private FileBrowser _FB;

    private string m_pOpenedPath = null;         // 您选择打开的文件的路径
    private bool ValidateDoubleClick = false;    // 一个变量加上一个冷却，这样你就可以双击菜单项来打开它们
    private Button CurrentlySelected;            // 当前选择的文件



    private bool GenerateNewThumbnails = false;           // Boolean 说明我们是否需要开始生成新的缩略图
    private bool m_bGenerationCompleted = false;          // Boolean 说明当前缩略图生成的状态
    private bool CancelGeneration = false;                // Boolean 允许我们取消当前的缩略图生成
    private bool CancelThread = false;                    // Boolean 允许我们退出缩略图线程
    private int ThumbSize;                                // 缩略图的大小（如果“ItemSize”滑块，则初始化为大小）

    struct ThumbData                             //  包含单个缩略图数据的 Bean
    {
        public byte[] _bytes;
        public string _fullName;
        public string _name;
        public float SizeX;
        public float SizeY;
    }

    private Thread ThumbnailsThread;                       // 缩略图线程
    private FileInfo[] _ThumbnailsFiles = new FileInfo[0]; // 需要缩略图的文件



    private readonly List<Button> Buttons = new List<Button>();                // 当前显示在界面的按钮列表
    private readonly List<Button> Favorites = new List<Button>();              // 当前按钮列表
    private readonly List<Button> FiltersList = new List<Button>();            // 过滤器按钮列表
    private readonly List<string[]> FiltersStrings = new List<string[]>();       // 将初始化过滤器按钮列表的字符串列表
    private readonly List<ThumbData> m_pImagesBytesArray = new List<ThumbData>(); // 将从上述FileInfo数组生成的缩略图数据列表





    IEnumerator DoubleClick()
    {
        ValidateDoubleClick = true;

        yield return new WaitForSeconds(.5f);

        ValidateDoubleClick = false;
    }

    void SelectFile(Button _Button)
    {
        // If file has been double clicked, open it
        if (_Button == CurrentlySelected && ValidateDoubleClick)
        {
            OpenFile();
        }
        // Selecte the file and start the double click cooldown
        else
        {
            CurrentlySelected = _Button;
            StartCoroutine(DoubleClick());
        }
    }



    private void CreateFavoriteFolder()
    {
        FileInfo _fav = new FileInfo(SAVE_FAVS_PATH);
        if (!_fav.Exists)
        {
            StreamWriter sw = System.IO.File.CreateText(SAVE_FAVS_PATH);
            sw.Close();
        }
    }

    private void RefreshFavorites()
    {
        FavoritePanel.sizeDelta = Vector2.zero;

        // Destroy previous buttons
        for (int i = 0; i < Favorites.Count; i++)
        {
            Favorites[i].gameObject.SetActive(false);
            DestroyImmediate(Favorites[i].gameObject);
        }

        // Clear List
        Favorites.Clear();

        StreamReader _sr = new StreamReader(SAVE_FAVS_PATH);

        string text = _sr.ReadToEnd();

        string[] paths = text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        // Get height from template button
        float ButtonHeight = FavoriteTemplate.gameObject.GetComponent<RectTransform>().rect.height;

        for (int i = 0; i < paths.Length; i++)
        {
            DirectoryInfo dir = new DirectoryInfo(paths[i]);

            // Create new button
            Button NewButton = GameObject.Instantiate(FavoriteTemplate) as Button;
            NewButton.gameObject.SetActive(true);
            NewButton.gameObject.transform.SetParent(FavoritePanel.gameObject.transform, false);

            // Place button
            RectTransform _CurrentRect = NewButton.gameObject.GetComponent<RectTransform>();
            _CurrentRect.localPosition = new Vector3(-5,
                (-10) * (Favorites.Count + 7) + (-ButtonHeight) * (Favorites.Count + 6), 0);
            _CurrentRect.sizeDelta = new Vector2(-30, ButtonHeight);

            // Set button label to retrieve it later
            _CurrentRect.Find("Text").gameObject.GetComponent<Text>().text = dir.Name;
            _CurrentRect.Find("Name").gameObject.GetComponent<Text>().text = dir.FullName;
            NewButton.gameObject.name = "Favorite";

            // Add the button callback
            NewButton.onClick.RemoveAllListeners();
            NewButton.onClick.AddListener(() => OpenFavorite(NewButton));

            // Add the button to the list
            Favorites.Add(NewButton);

            // Resize parent panel to fit the new button
            FavoritePanel.sizeDelta = new Vector2(0, 10 * (Favorites.Count + 7) + ButtonHeight * (Favorites.Count + 6));
        }

        _sr.Dispose();
    }


    private void CreateFiltersOptions(List<string[]> Filters)  // 调用函数创建过滤器下拉列表
    {
        for (int i = 0; i < Filters.Count; i++)
        {
            // Create a new filter button
            Button NewFilter = GameObject.Instantiate(FilterItem) as Button;
            NewFilter.gameObject.SetActive(true);
            NewFilter.gameObject.transform.SetParent(FiltersOptions.gameObject.transform);

            // Place it
            RectTransform _CurrentRect = NewFilter.gameObject.GetComponent<RectTransform>();
            _CurrentRect.localPosition = new Vector3(0, 10 + 20 * i, 0);
            _CurrentRect.sizeDelta = new Vector2(0, _CurrentRect.rect.height);

            // Create button label by concatenating each filter
            string text = string.Empty;

            if (Filters[i] != null)
            {
                for (int j = 0; j < Filters[i].Length; j++)
                {
                    text += "\"" + Filters[i][j] + "\" ";
                }
            }
            else
                text = "\".*\"";

            _CurrentRect.Find("Text").gameObject.GetComponent<Text>().text = text;

            // Add new callback
            NewFilter.onClick.RemoveAllListeners();
            NewFilter.onClick.AddListener(() => ChangeFilters(NewFilter));

            // Add filter
            FiltersList.Add(NewFilter);
        }

        // Set default filter
        SelectedFilter.text = "\".*\"";
    }



    private IEnumerator WaitResults()
    {
        StartCoroutine(_FB.WaitForSearchResult());

        while (!_FB.IsSearchComplete())
        {
            RefreshButtons();
            yield return new WaitForSeconds(.5f);
        }

        RefreshButtons();

        Loading.SetActive(false);
    }

    // 主功能
    private void GenerateThumbnails()
    {
        while (true)
        {
            if (GenerateNewThumbnails)
            {
                m_bGenerationCompleted = false;

                lock (_ThumbnailsFiles)
                {
                    // Add a button for each file
                    for (int i = 0; i < _ThumbnailsFiles.Length; i++)
                    {
                        if (_ThumbnailsFiles[i].Extension.ToLower() == ".png"
                            || _ThumbnailsFiles[i].Extension.ToLower() == ".jpg"
                            || _ThumbnailsFiles[i].Extension.ToLower() == ".jpeg"
                            || _ThumbnailsFiles[i].Extension.ToLower() == ".gif"
                            || _ThumbnailsFiles[i].Extension.ToLower() == ".bmp")
                        {
                            ThumbData _data = new ThumbData();
                            _data._fullName = _ThumbnailsFiles[i].FullName;
                            _data._name = _ThumbnailsFiles[i].Name;

                            try
                            {
                                System.Drawing.Image image = System.Drawing.Image.FromFile(_data._fullName);
                                System.Drawing.Image thumb = image.GetThumbnailImage(ThumbSize, ThumbSize, () => false,
                                    System.IntPtr.Zero);

                                _data._bytes = imageToByteArray(thumb);

                                if (image.Width == image.Height)
                                {
                                    _data.SizeX = ThumbSize;
                                    _data.SizeY = ThumbSize;
                                }
                                else if (image.Width > image.Height)
                                {
                                    _data.SizeX = ThumbSize;
                                    _data.SizeY = ThumbSize * ((float)image.Height / (float)image.Width);
                                }
                                else if (image.Width < image.Height)
                                {
                                    _data.SizeX = ThumbSize * ((float)image.Width / (float)image.Height);
                                    _data.SizeY = ThumbSize;
                                }

                                thumb.Dispose();
                                image.Dispose();
                            }
                            catch (System.ArgumentException e)
                            {
                                Debug.LogError("ArgumentException when generating thumbnail " + i + ".\n\n" + e.Message);
                            }
                            catch (System.IO.FileNotFoundException e)
                            {
                                Debug.LogError("FileNotFoundException when generating thumbnail " + i + ".\n\n" +e.Message);
                            }
                            catch (System.OutOfMemoryException e)
                            {
                                Debug.LogError("OutOfMemoryException when generating thumbnail " + i + ".\n\n" + e.Message);
                            }
                            catch
                            {
                                Debug.LogError("Unknow error when generating thumbnail " + i + ".\n\n");
                            }

                            lock (m_pImagesBytesArray)
                            {
                                m_pImagesBytesArray.Add(_data);
                            }

                            if (CancelThread || CancelGeneration)
                            {
                                break;
                            }
                        }
                    }
                }

                m_bGenerationCompleted = true;
                GenerateNewThumbnails = false;
            }

            if (CancelThread)
            {
                CancelThread = false;
                break;
            }

            if (CancelGeneration)
            {
                m_bGenerationCompleted = true;
                GenerateNewThumbnails = false;
                lock (m_pImagesBytesArray)
                {
                    m_pImagesBytesArray.Clear();
                }

                lock (_ThumbnailsFiles)
                {
                    _ThumbnailsFiles = new FileInfo[0];
                }
                CancelGeneration = false;
            }

            Thread.Sleep(100);
        }
    }

    // 将System.Drawing.Image 转换为字节数组，以便稍后将其转换为 Texture2D
    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        using (var ms = new MemoryStream())
        {
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }



    // 协同程序以设定的间隔显示新的缩略图
    public IEnumerator WaitForThumbnails()
    {
        while (true)
        {
            lock (m_pImagesBytesArray)
            {
                if (m_pImagesBytesArray.Count > 0)
                {
                    for (int i = 0; i < m_pImagesBytesArray.Count; i++)
                    {
                        for (int j = 0; j < Buttons.Count; j++)
                        {
                            RectTransform _CurrentRect = Buttons[j].gameObject.GetComponent<RectTransform>();
                            string _name = _CurrentRect.Find("Text").gameObject.GetComponent<Text>().text;

                            if (m_pImagesBytesArray[i]._name == _name)
                            {
                                Image _pic = Buttons[j].gameObject.transform.Find("Image").gameObject
                                    .GetComponent<Image>();

                                Texture2D _thumbnail = new Texture2D(2, 2);

                                _thumbnail.LoadImage(m_pImagesBytesArray[i]._bytes);

                                Sprite _sprite = Sprite.Create(_thumbnail,
                                    new Rect(0, 0, _thumbnail.width, _thumbnail.height), new Vector2(0.0f, 0.0f));

                                _pic.sprite = _sprite;
                                _pic.rectTransform.sizeDelta = new Vector2(m_pImagesBytesArray[i].SizeX - 10,
                                    m_pImagesBytesArray[i].SizeY - 10);
                            }

                            if (CancelGeneration || CancelThread)
                            {
                                break;
                            }
                        }
                    }
                }

                m_pImagesBytesArray.Clear();
            }

            if (m_bGenerationCompleted)
            {
                break;
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
            }
        }

        _ThumbnailsFiles = new FileInfo[0];
        m_bGenerationCompleted = false;
    }




    #endregion



    private string StartingDirectory = ""; // 您可以在此处为文件浏览器指定起始目录。 空字符串打开游戏文件夹

    void Awake()
    {

        SAVE_FAVS_PATH = Application.persistentDataPath + "\\FavoritesPath.txt";

        // 开始线程
        ThumbnailsThread = new Thread(GenerateThumbnails);
        ThumbnailsThread.Name = "Thumbnails Thread";
        ThumbnailsThread.Start();

        // 创建文件浏览器
        if (string.IsNullOrEmpty(StartingDirectory))       // 起始目录为空的情况
        {
            _FB = new FileBrowser();
        }
        else
        {
            _FB = new FileBrowser(StartingDirectory);
        }


        // 设置不同文件筛选器
        FiltersStrings.Add(null); //让这一个，它是默认的
        FiltersStrings.Add(new[] {".txt"}); // 添加这样的新过滤器。 这个只显示“.txt”文件
        FiltersStrings.Add(new[] {".jpg", ".jpeg", ".png" }); // 您还可以指定一个过滤器列表，因此将显示使用任何此扩展名的任何文件



        CreateFavoriteFolder();   // 创建收藏文件夹（如果没有）
        RefreshFavorites();       // 刷新收藏文件夹
    }

    void Start()
    {
        ThumbSize = (int) ButtonSize.value;

        // 从“Awake”中指定的过滤器列表中创建过滤器
        CreateFiltersOptions(FiltersStrings);

        // 刷新按钮
        RefreshButtons();
    }

    void OnApplicationQuit()
    {
        // Cancel Threads
        _FB.QuitSearchThread();
        QuitThumbnailsThread();
    }



}*/