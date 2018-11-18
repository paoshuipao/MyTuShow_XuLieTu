using UnityEngine;
using UnityEditor;
using System.Linq;

namespace ES3Editor
{
	public class ES3Window : EditorWindow
	{
	    [MenuItem(EasySaveToolsPath.EasySave3UI, false, 1000)]
	    public static void Init()
	    {
	        // Get existing open window or if none, make a new one:
	        ES3Window window = (ES3Window)EditorWindow.GetWindow(typeof(ES3Window));
	        window.Show();
	    }


	    public void InitSubWindows()        // 这里的核心是里面这几个子UI，画图同样是调用 OnGUI
        {
	        windows = new SubWindow[]{
	            new HomeWindow(this),
	            new SettingsWindow(this),
	            new ToolsWindow(this),
	            new TypesWindow(this),
	            new AutoSaveWindow(this)
	        };
	    }


        #region 私有


        private SubWindow[] windows = null;

		public SubWindow currentWindow;



		public static void InitAndShowHome()
		{
			// Get existing open window or if none, make a new one:
			ES3Window window = (ES3Window)EditorWindow.GetWindow(typeof(ES3Window));
			window.Show();
			window.SetCurrentWindow(typeof(HomeWindow));
		}

		public static void InitAndShowAutoSave()
		{
			// Get existing open window or if none, make a new one:
			ES3Window window = (ES3Window)EditorWindow.GetWindow(typeof(ES3Window));
			window.Show();
			window.SetCurrentWindow(typeof(AutoSaveWindow));
		}



	    void SetCurrentWindow(SubWindow window)
	    {
	        currentWindow = window;
	        EditorPrefs.SetString("ES3Editor.Window.currentWindow", window.name);
	    }

	    void SetCurrentWindow(System.Type type)
	    {
	        currentWindow = windows.First(w => w.GetType() == type);
	        EditorPrefs.SetString("ES3Editor.Window.currentWindow", currentWindow.name);
	    }

	    // Shows the Easy Save Home window if it's not been disabled.
	    // This method is called from the Postprocessor.
	    public static void OpenEditorWindowOnStart()
	    {
	        if (EditorPrefs.GetBool("Show ES3 Window on Start", true))
	            ES3Window.InitAndShowHome();
	        EditorPrefs.SetBool("Show ES3 Window on Start", false);
	    }

	    #endregion


        void OnEnable()
		{
		    if (windows == null)
		    {
		        InitSubWindows();
		    }
			// Set the window name and icon.
			var icon = AssetDatabase.LoadAssetAtPath<Texture2D>(ES3EditorUtility.PathToEasySaveFolder()+ "Editor/Texture/es3Logo16x16.png");
			titleContent = new GUIContent("Easy Save", icon);

			// Get the last opened window and open it.
			if(currentWindow == null)
			{
				var currentWindowName = EditorPrefs.GetString("ES3Editor.Window.currentWindow", windows[0].name);
				for(int i=0; i<windows.Length; i++)
				{
					if(windows[i].name == currentWindowName)
					{
						currentWindow = windows[i];
						break;
					}
				}
			}
		}

		void OnGUI()    
		{
			var style = EditorStyle.Get;

			// Display the menu.
			EditorGUILayout.BeginHorizontal();

			for(int i=0; i<windows.Length; i++)
			{
			    if (GUILayout.Button(windows[i].name, currentWindow == windows[i] ? style.menuButtonSelected : style.menuButton))
			    {
			        SetCurrentWindow(windows[i]);
			    }
			}

			EditorGUILayout.EndHorizontal();
			if(currentWindow != null)
				currentWindow.OnGUI();
		}


	}



    public abstract class SubWindow          // toggle 下的每个小项
	{
		public string name;
		public EditorWindow parent;
		public abstract void OnGUI();     

		public SubWindow(string name, EditorWindow parent)
		{
			this.name = name;
			this.parent = parent;
		}
	}

}