using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using PSPUtil.StaticUtil;

public class FileBrowser
{


    //—————————————————— 访问器 ——————————————————
    public DirectoryInfo GetCurrentDirectory()               // 当前文件夹路径
    {
        return m_pCurrentDirectory;
    }

    public DirectoryInfo GetParentDirectory()
    {
        return m_pParentDirectory;
    }

    public DirectoryInfo[] GetChildDirectories()             // 获得当前路径的所有文件夹
    {
        return m_pChildDirectories.ToArray();
    }

    public FileInfo[] GetFiles()                             // 获得当前路径的所有文件
    {
        return m_pFiles.ToArray();
    }

    public string GetFilePath(string name)
    {
        // Look trough the current files and return the path of the one maching the given name
        for (int i = 0; i < m_pFiles.Count; i++)
        {
            if (m_pFiles[i].Name == name)
            {
                return m_pFiles[i].FullName;
            }
        }

        return null;
    }

    public string GetDirectoryPath(string name)
    {
        // Look trough the current files and return the path of the one maching the given name
        for (int i = 0; i < m_pChildDirectories.Count; i++)
        {
            if (m_pChildDirectories[i].Name == name)
            {
                return m_pChildDirectories[i].FullName;
            }
        }

        return null;
    }



    public FileInfo GetFileInfoByFileName(string fileName)      // 获得文件实例
    {
        for (int i = 0; i < m_pFiles.Count; i++)
        {
            if (m_pFiles[i].Name == fileName)
            {
                return m_pFiles[i];
            }
        }

        throw new Exception("没找到这个文件名的 文件实例 —— " + fileName);
    }



    //—————————————————— 主要的导航功能 ——————————————————



    public void Relocate(string path)                                 // 换目录（简单版）  -> 实际调用  RetrieveFiles 
    {
        if (path == null)
        {
            RetrieveFiles(new DirectoryInfo(Directory.GetCurrentDirectory()), true);
        }
        else
        {
            path = path.Trim();

            if (path == string.Empty)
            {
                GoToRoot(true);
            }
            else
            {
                DirectoryInfo Dir = new DirectoryInfo(path);

                if (Dir.Exists)
                    RetrieveFiles(new DirectoryInfo(path), true); // Retrieve hierarchy from given path
                else
                {
                    RetrieveFiles(m_pCurrentDirectory, true);
                }
            }
        }
    }


    public void RetrieveFiles(DirectoryInfo Dir, bool bHistory)       // 换目录
    {
        CancelCurrentSearch();

        // Write to history if needed
        if (bHistory)
            AddToHistory(Dir);

        // Set variables with current directory informations
        m_pCurrentDirectory = Dir;
        m_pParentDirectory = Dir.Parent;

        m_pChildDirectories.Clear();
        m_pFiles.Clear();

        DirectoryInfo[] dirArray = Dir.GetDirectories();
        FileInfo[] fileArray = Dir.GetFiles();


        for (int i = 0; i < dirArray.Length; i++)
        {
            m_pChildDirectories.Add(dirArray[i]);
        }

        for (int i = 0; i < fileArray.Length; i++)
        {
            m_pFiles.Add(fileArray[i]);
        }

        CleanFiles(ref m_pFiles);
        CleanDirs(ref m_pChildDirectories);

        Sort();


        //————————————————————————————————————
        parentFolderPaths.Clear();

        DirectoryInfo[] parentDirs = m_pParentDirectory.GetDirectories();

        for (int i = 0; i < parentDirs.Length; i++)
        {
            if (!Directory.Exists(parentDirs[i].FullName))
            {
                continue;
            }
            FileAttributes attributes = File.GetAttributes(parentDirs[i].FullName);
            if ((attributes & FileAttributes.System) == FileAttributes.System|| (attributes & FileAttributes.Hidden) == FileAttributes.Hidden || (attributes & FileAttributes.Archive) == FileAttributes.Archive)
            {
                continue;
            }
            parentFolderPaths.Add(parentDirs[i].FullName);
        }
    }


    //————————————————— 直接层次结构 ———————————————————

    public void GoToRoot(bool bHistory)                               // 去根目录（c盘、d盘、e盘那里）
    {
        CancelCurrentSearch();

        // Write to history if needed
        if (bHistory)
            AddToHistory(null);

        // Empty everything
        m_pCurrentDirectory = null;
        m_pParentDirectory = null;
        m_pFiles.Clear();

        // Set directory entries for the currently active logical drives

        string[] drives = Directory.GetLogicalDrives();
        m_pChildDirectories.Clear();

        for (int i = 0; i < drives.Length; i++)
        {
            m_pChildDirectories.Add(new DirectoryInfo(drives[i]));
        }
    }


    public void GoInParent()                                          // 去上一级别的文件夹（或磁盘）
    { 
        // If there is no parent, you ara at the computer root
        if (m_pParentDirectory == null)
        {
            GoToRoot(true);
        }
        // Open the parent directory
        else
        {
            RetrieveFiles(m_pParentDirectory, true);
        }
    }

    public void GoInSubDirectory(string name)                        // 双击这个文件夹，进入
    {
        // Look trhough the current subdirectories and open the one maching the given name
        for (int i = 0; i < m_pChildDirectories.Count; i++)
        {
            if (m_pChildDirectories[i].Name == name)
            {
                RetrieveFiles(m_pChildDirectories[i], true);
            }
        }
    }



    #region 其他方法



    //————————————————— 排序 ———————————————————

    public void Sort()
    {
        switch (_SortMode)
        {
            case SortingMode.Name:
                {
                    m_pFiles.Sort(CompareFileByName);
                    m_pChildDirectories.Sort(CompareFolderByName);
                    break;
                }
            case SortingMode.Date:
                {
                    m_pFiles.Sort(CompareFileByDate);
                    m_pChildDirectories.Sort(CompareFolderByDate);
                    break;
                }
            case SortingMode.Type:
                {
                    m_pFiles.Sort(CompareFileByType);
                    m_pChildDirectories.Sort(CompareFolderByName);
                    break;
                }
        }
    }


    //—————————————————— 历史 ——————————————————


    public bool GetIsHasHistoryPre       // 是否有历史
    {
        get { return m_iCursor - 1 >= 0; }
    }

    public bool GetIsHasHistoryNext       // 是否有历史之前
    {
        get { return m_iCursor + 1 < m_pHistory.Count; }
    }

    public void GoToPrevious()             // 回到历史
    {

        m_iCursor--;
        // Clamp cursor and do not change if already at the first entry
        if (m_iCursor < 0)
        {
            m_iCursor = 0;
            return;
        }

        // Retrieve entry
        DirectoryInfo Dir = m_pHistory[m_iCursor];

        // Go to specified directory
        if (Dir == null)
        {
            GoToRoot(false);
        }
        else
        {
            RetrieveFiles(Dir, false);
        }
    }

    public void GotToNext()                // 走出历史
    {

        m_iCursor++;

        // Clamp cursor and do not change if already at the last entry
        if (m_iCursor >= m_pHistory.Count)
        {
            m_iCursor = m_pHistory.Count - 1;
            return;
        }

        // Retrieve entry
        DirectoryInfo Dir = m_pHistory[m_iCursor];

        // Go to specified directory
        if (Dir == null)
        {
            GoToRoot(false);
        }
        else
        {
            RetrieveFiles(Dir, false);
        }
    }



    //—————————————————— 搜索 ——————————————————

    public void SearchFor(string Key)      // 搜索包含给定字符串的文件
    {
        // Cancel current search
        CancelCurrentSearch();

        // If key do not contain anything, just retrieve current files
        if (Key.Length == 0)
        {
            if (m_pCurrentDirectory != null)
            {
                RetrieveFiles(m_pCurrentDirectory, false);
            }
            else
            {
                GoToRoot(false);
            }
        }
        // Else, retrieve files with given key
        else
        {
            // Reset search lists
            lock (m_pSearchedFiles)
            {
                m_pSearchedFiles.Clear();
            }
            lock (m_pSearchedDirectories)
            {
                m_pSearchedDirectories.Clear();
            }
            lock (m_pSearchDir)
            {
                m_pSearchDir = m_pCurrentDirectory;
            }
            lock (m_pSearchKey)
            {
                m_pSearchKey = Key;
            }

            StartNewSearch = true;
        }
    }

    public void QuitSearchThread()
    {
        // Ask for the thread to cancel itslef
        CancelThread = true;

        // Wait for the thread to be cancelled
        while (CancelThread)
        {
            Thread.Sleep(20);
        }

        // Abort the thread
        SearchThread.Abort();
    }

    public void CancelCurrentSearch()
    {
        // Return if there is no current search
        if (!StartNewSearch)
            return;

        // Ask for the thread ti cancel the current search
        CancelSearch = true;

        // Wait for the search to be cancelled
        while (CancelSearch)
        {
            Thread.Sleep(20);
        }
    }

    public bool IsSearchComplete()
    {
        if (m_bSearchCompleted)
        {
            m_bSearchCompleted = false;
            return true;
        }

        return false;
    }

    //———————————————— 修饰符 ————————————————————

    public void SetHistoryLength(int iLength)
    {
        iLength = Mathf.Max(iLength, 0);
        m_iHistoryLength = iLength;
    }

    public void SetFilters(string[] filters)
    {
        m_pFilters = filters;
        RetrieveFiles(m_pCurrentDirectory, false);
    }

    public void SetSortMode(SortingMode mode)
    {
        _SortMode = mode;
        Refresh();
    }




    //—————————————————— 构造函数 ——————————————————



    public FileBrowser()
    {
        //		SearchThread = new Thread(SearchInStart);
        //		SearchThread.Name = "Search Thread";
        //		SearchThread.Start();

        RetrieveFiles(new DirectoryInfo(Directory.GetCurrentDirectory()), true); // Retrieve hierarchy from current directory

        m_pSearchDir = m_pCurrentDirectory;
    }



    public FileBrowser(string path)
    {
        //		SearchThread = new Thread(SearchInStart);
        //		SearchThread.Name = "Search Thread";
        //		SearchThread.Start();

        if (path.Trim() == string.Empty)
        {
            Debug.LogError("Invalid Path : string is empty.");
            GoToRoot(true);
        }
        else
        {
            DirectoryInfo Dir = new DirectoryInfo(path);

            if (Dir.Exists)
                RetrieveFiles(new DirectoryInfo(path), true); // Retrieve hierarchy from given path
            else
            {
                Debug.LogError("Invalid Path : " + path);
                GoToRoot(true);
            }
        }

        m_pSearchDir = m_pCurrentDirectory;
    }
    #endregion


    #region 私有



    // Current Hierarchy

    private DirectoryInfo m_pCurrentDirectory;
	private DirectoryInfo m_pParentDirectory;
	private List<DirectoryInfo> m_pChildDirectories = new List<DirectoryInfo>();
	private List<FileInfo> m_pFiles = new List<FileInfo>();                   // 所有的文件 集合

		// Filters

	private string[] m_pFilters = null;

        // Sorting

    public enum SortingMode
    {
        Name,
        Date,
        Type,
    };

    private SortingMode _SortMode = SortingMode.Name;

		// History

	private List<DirectoryInfo> m_pHistory = new List<DirectoryInfo> ();
	private int m_iHistoryLength = 0;
	private int m_iCursor = -1;

		// Search

	private Thread SearchThread;
	private List<FileInfo> m_pSearchedFiles = new List<FileInfo>();
	private List<DirectoryInfo> m_pSearchedDirectories = new List<DirectoryInfo>();
	private DirectoryInfo m_pSearchDir;
	private string m_pSearchKey = string.Empty;
	private bool m_bSearchCompleted = false;
	private bool StartNewSearch = false;
	private bool CancelSearch = false;
	private bool CancelThread = false;


    private void CleanFiles(ref List<FileInfo> _files)
    {
        // Apply filters if existing
        if (m_pFilters != null)
        {
            List<FileInfo> _tmpFiles = new List<FileInfo>();

            for (int i = 0; i < _files.Count; i++)
            {
                for (int j = 0; j < m_pFilters.Length; j++)
                {
                    // Add only with with extension maching a filter
                    if (_files[i].Extension.ToLower().Contains(m_pFilters[j].ToLower()))
                    {
                        _tmpFiles.Add(_files[i]);
                    }
                }
            }

            _files = _tmpFiles;
        }

        for (int i = 0; i < _files.Count; i++)
        {
            if (!File.Exists(_files[i].FullName))
                continue;

            FileAttributes attributes = File.GetAttributes(_files[i].FullName);

            if ((attributes & FileAttributes.System) == FileAttributes.System
                || (attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                _files.RemoveAt(i);
            }
        }
    }

    private void CleanDirs(ref List<DirectoryInfo> _dirs)
    {
        for (int i = 0; i < _dirs.Count; i++)
        {
            if (!Directory.Exists(_dirs[i].FullName))
            {
                _dirs.RemoveAt(i);
                continue;
            }

            FileAttributes attributes = File.GetAttributes(_dirs[i].FullName);

            if ((attributes & FileAttributes.System) == FileAttributes.System
                || (attributes & FileAttributes.Hidden) == FileAttributes.Hidden
                || (attributes & FileAttributes.Archive) == FileAttributes.Archive)
            {
                _dirs.RemoveAt(i);
            }
        }
    }


    private static int CompareFileByName(FileInfo i1, FileInfo i2)
    {
        return i1.Name.CompareTo(i2.Name);
    }

    private static int CompareFileByType(FileInfo i1, FileInfo i2)
    {
        return i1.Extension.CompareTo(i2.Extension);
    }

    private static int CompareFileByDate(FileInfo i1, FileInfo i2)
    {
        return i1.CreationTime.CompareTo(i2.CreationTime);
    }

    private static int CompareFolderByName(DirectoryInfo i1, DirectoryInfo i2)
    {
        return i1.Name.CompareTo(i2.Name);
    }

    private static int CompareFolderByDate(DirectoryInfo i1, DirectoryInfo i2)
    {
        return i1.CreationTime.CompareTo(i2.CreationTime);
    }


    // Add new entry to history
    private void AddToHistory(DirectoryInfo Dir)
    {
        m_iCursor++;

        // If we are not on the last item, delete what follow
        if (m_iCursor != m_pHistory.Count)
        {
            m_pHistory.RemoveRange(m_iCursor, m_pHistory.Count - m_iCursor);
        }

        // Add entry
        m_pHistory.Add(Dir);

        // Delete oldest entries if the history has a length
        if (m_iHistoryLength > 0)
        {
            m_pHistory.RemoveRange(0, m_pHistory.Count - m_iHistoryLength);
            m_iCursor = m_pHistory.Count - 1;
        }
    }



    // Main Thread function
    private void SearchInStart()
    {
        while (true)
        {
            if (StartNewSearch)
            {
                m_bSearchCompleted = false;

                string Key = null;
                DirectoryInfo Dir = null;

                lock (m_pSearchKey)
                {
                    Key = m_pSearchKey;
                }
                lock (m_pSearchDir)
                {
                    Dir = m_pSearchDir;
                }

                SearchIn(Dir, Key);

                m_bSearchCompleted = true;
                StartNewSearch = false;
            }

            if (CancelThread)
            {
                CancelThread = false;
                break;
            }

            if (CancelSearch)
            {
                m_bSearchCompleted = false;
                StartNewSearch = false;
                CancelSearch = false;

                lock (m_pSearchedFiles)
                {
                    m_pSearchedFiles.Clear();
                }
                lock (m_pSearchedDirectories)
                {
                    m_pSearchedDirectories.Clear();
                }
                lock (m_pSearchDir)
                {
                    m_pSearchDir = m_pCurrentDirectory;
                }
                lock (m_pSearchKey)
                {
                    m_pSearchKey = string.Empty;
                }
            }

            Thread.Sleep(100);
        }
    }

    // Recursive version of the main function    
    private void SearchIn(DirectoryInfo Dir, string Key)
    {
        if (CancelSearch || CancelThread)
        {
            return;
        }

        // Retrieve files
        FileInfo[] files = Dir.GetFiles();

        // Check if the files name contain the specified key
        for (int i = 0; i < files.Length; i++)
        {
            if ((files[i].Name + files[i].Extension).Contains(Key))
            {
                if (CancelSearch || CancelThread)
                {
                    return;
                }

                lock (m_pSearchedFiles)
                {
                    m_pSearchedFiles.Add(files[i]);
                }
            }
        }

        if (CancelSearch || CancelThread)
        {
            return;
        }

        // Retrieve directories
        DirectoryInfo[] dirs = Dir.GetDirectories();

        // Check if the files name contain the specified key
        for (int i = 0; i < dirs.Length; i++)
        {
            FileAttributes attributes = File.GetAttributes(dirs[i].FullName);

            if ((attributes & FileAttributes.System) != FileAttributes.System
                && (attributes & FileAttributes.Hidden) != FileAttributes.Hidden
                && (attributes & FileAttributes.Archive) != FileAttributes.Archive)
            {
                if (dirs[i].Name.Contains(Key))
                {
                    lock (m_pSearchedDirectories)
                    {
                        m_pSearchedDirectories.Add(dirs[i]);
                    }
                }

                // Check every subfolders by recursion
                SearchIn(dirs[i], Key);

                if (CancelSearch || CancelThread)
                {
                    return;
                }
            }
        }
    }

    public IEnumerator WaitForSearchResult()
    {
        m_pChildDirectories.Clear();
        m_pFiles.Clear();

        List<FileInfo> _files = new List<FileInfo>();
        List<DirectoryInfo> _dirs = new List<DirectoryInfo>();

        while (true)
        {
            lock (m_pSearchedDirectories)
            {
                for (int i = 0; i < m_pSearchedDirectories.Count; i++)
                {
                    _dirs.Add(m_pSearchedDirectories[i]);
                }

                m_pSearchedDirectories.Clear();
            }

            lock (m_pSearchedFiles)
            {
                for (int i = 0; i < m_pSearchedFiles.Count; i++)
                {
                    _files.Add(m_pSearchedFiles[i]);
                }

                m_pSearchedFiles.Clear();
            }

            CleanFiles(ref _files);
            CleanDirs(ref _dirs);

            for (int i = 0; i < _files.Count; i++)
            {
                m_pFiles.Add(_files[i]);
            }

            for (int i = 0; i < _dirs.Count; i++)
            {
                m_pChildDirectories.Add(_dirs[i]);
            }

            _files.Clear();
            _dirs.Clear();
            Sort();

            if (m_bSearchCompleted)
            {
                break;
            }

            yield return new WaitForSeconds(.3f);
        }
    }
    public void Refresh()
    {
        if (m_pCurrentDirectory != null)
        {
            RetrieveFiles(m_pCurrentDirectory, false);
        }
        else
        {
            GoToRoot(false);
        }
    }
    #endregion


    private readonly List<string> parentFolderPaths = new List<string>();


    public string GetPreFolderPath()            // 获得上一文件夹
    {
        string currentPath = m_pCurrentDirectory.FullName;
        for (int i = 0; i < parentFolderPaths.Count; i++)
        {
            if (parentFolderPaths[i] == currentPath)
            {
                int index = i - 1;
                if (index < 0)
                {
                    return null;
                }
                else
                {
                    return parentFolderPaths[index];
                }
            }
        }
        return null;
    }


    public string GetNextFolderPath()            // 获得上一文件夹
    {
        string currentPath = m_pCurrentDirectory.FullName;
        for (int i = 0; i < parentFolderPaths.Count; i++)
        {
            if (parentFolderPaths[i] == currentPath)
            {
                int index = i + 1;
                if (index>= parentFolderPaths.Count)
                {
                    return null;
                }
                else
                {
                    return parentFolderPaths[index];
                }
            }
        }
        return null;
    }





}
