
public enum E_GameEvent                           // 这里写事件
{

    LogoExit,                    // 离开Logo事件     logo -> 动画 -> 离开Logo -> 动画 -> RealJumpIntoScene 最终进入场景
    RealJumpIntoScene,           // 动画全部播放完成，进入了场景 （带 EF_Scenes scene 参数）

    ShowStartGameUI,             //进入 开始游戏 UI
    HideStartGameUI,             //隐藏


    ShowLog,                    // 显示 Log UI
    HideLog,                    // 隐藏


    LeftChangeItem,             // 切换左边总的 Item （ushort 大的索引，ushort 小 底下的索引）




    RealyDaoRu_File,             // 准备要导入（不知道是否成功,需要返回个结果的）(EButtonType 按钮样式，ushort 大的索引，ushort 小 底下的索引,List<FileInfo> 文件集合)
    RealyDaoRu_Result,           // 准备要导入（不知道是否成功,需要返回个结果的）(EButtonType 按钮样式，ushort 大的索引，ushort 小 底下的索引,List<ResultBean> 结果集合)


    DaoRu_FromFile,              // 直接导入 通过文件(ushort 大的索引，ushort 小 底下的索引，List<FileInfo> 文件集合)
    DaoRu_FromResult,            // 直接导入 通过结果(ushort 大的索引，ushort 小 底下的索引，List<ResultBean> 结果集合)




    ShowDuoTuInfo,           // 显示多图信息(ResultBean[] 文件集合，EDuoTuInfoType 展示类型)
    CloseDuoTuInfo,          // 关闭(EDuoTuInfoType 类型)
    OnClickNoSaveThisDuoTu,  // 点击了 不保存这个多图（EDuoTuInfoType 类型,string[] 删除路径）





    //————————————————————————————————————


    OpenFileContrl,                // 打开 文件 资源管理器
    OpenFolderContrl,              // 打开 文件夹 资源管理器
    CloseFileOrFolderContrl,       // 关闭 文件或者文件夹资源管理器


    //—————————————————— Old ——————————————————







    OnClickDown_Shift,              // 按下 Shift
    OnClickUp_Shift,               //  松开 Shift

    OnClickDown_Ctrl,              // 按下 Ctrl
    OnClickUp_Ctrl,                // 松开 Ctrl

    OnClickCtrlAndA,               // 按下 Ctrl + A

    OnClickCtrlAndC,               // 按下 Ctrl + C

    OnClickMouseLeftUp,           // 点击鼠标左键
    OnClickMouseRightDown,          // 按下鼠标右键


    ChangGameToggleType,            // 切换左边总的选项 （EGameType,int）
    GoToNextFolderDaoRu,            // 去一个文件夹导入




    /*
        导入过程：   点击导入  -> 发DaoRuTuFromFile/DaoRuTuFromResult  ->（在 Sub_DaoRuResult 处理） 合格了才向各大项发送导入事件
     
     */







    //————————————————————————————————————


    OnClickEscOrOnPause,       // 点击了 Esc 退出键 或者点击了 暂停的按钮


    ShowPauseUI,               // 显示 PauseUI


    HidePauseUI,               // Esc(马上游戏暂停)  -> PauseUI 动画 -> PauseUI  ->  Esc(还是暂停)   -> PauseUI 动画隐藏结束 -> 游戏才继续

    

    GameGoHead,                // 游戏继续


    OnQuitGame,                // 点击退出游戏


    //——————————————————— 导入 —————————————————


    DaoRuTuFromFile,                //导入图片通过文件(EGameType 大类型，ushort 小类型,List<FileInfo> 文件集合，bool 是否保存)
    DaoRuTuFromResult,              //导入图片通过已加载的结果(EGameType 大类型,ushort 小类型,List<ResultBean> 结果集合,bool 是否从直接导入处导入)

    DaoRuAudioFromFiles,            // 从快速导入处 导入音频（EAudioType 类型,List<FileInfo> 文件集合，bool 是否保存）
    DaoRuAudioFromResult,            // 从快速导入处 导入音频（EAudioType 类型,AudioResBean 结果）




    DaoRu_XLT_FromFile,                // 导入序列图（EXuLieTu222 类型 ，List<FileInfo> 文件集合)
    DaoRu_XLT_FromResult,              // （已加载）导入序列图(EXuLieTu222 类，List<ResultBean> 结果集合)


    DaoRu_XLT222_FromFile,            // 导入 序列图222（EXuLieTu 类型 ，List<FileInfo> 文件集合)
    DaoRu_XLT222_FromResult,          //（已加载）导入序列图222(EXuLieTu 类，List<ResultBean> 结果集合)



    DaoRu_JiHeXLT_FromFile,           // 导入 集合序列图 (EJiHeXuLieTuType 类型, List<FileInfo> 多文件)
    DaoRu_JiHeXLT_FromResult,         // （已加载）导入 集合序列图（EJiHeXuLieTuType 类型 ， List<ResultBean> 结果集合）



    DaoRu_TaoMing_FromFile,           // 导入 透明图 (ETaoMingType 类型, List<FileInfo> 多文件)
    DaoRu_TaoMing_FromResult,         // （已加载）导入 透明图（ETaoMingType 类型 ， List<ResultBean> 结果集合）


    DaoRu_Jpg_FromFile,               // 导入 Jpg图 (ENormalTuType 类型, List<FileInfo> 多文件)
    DaoRu_Jpg_FromResult,             // （已加载）导入 Jpg图（ENormalTuType 类型 ， List<ResultBean> 结果集合）


    DaoRu_JiHe_FromFile,              // 导入 集合图 (EJiHeType 类型, List<FileInfo> 多文件)
    DaoRu_JiHe_FromResult,            // （已加载）导入 集合图（EJiHeType 类型 ， List<ResultBean> 结果集合）



    DaoRu_Audio,                      // 真正 导入音频(EAudioType 类型,AudioResBean 结果)



    ZhuangOtherDRSuccess,           // 转到其他导入成功




    //————————————————————————————————————


    ShowMusicInfo,         // 显示音乐信息(Text 用于导入变绿色,FileInfo,bool true:需要导入)
    CloseMusicInfo,        // 关闭音乐信息




    ShowIsSure,            // 显示 确定是否的界面（EGameType 标记,string 标题）
    ClickTrue,             // 点击确定(EGameType)，
    ClickFalse,            // 点击取消(EGameType)


    ShowSingleTuInfo,      // 显示单图信息（EGameType 标记，ResultBean 文件）
    CloseSingleTuInfo,     // 关闭（EGameType 标记）
    OnClickNoSaveThis,     // 点击了 不保存这个（EGameType 标记）



    ShowDuoTuDaoRu,         // 显示多图导入(ResultBean[] 结果集合,string 文件夹路径)
    ShowSingleTuDaoRu,      // 显示单张图片导入（ResultBean 结果）



    DelteAll,               // 所有重置



    ShowChangeSizeSlider,         // 显示能改变大小的Slider

    ShowGeiMingUI,               // 显示改名UI(EGameType,string 原名)
    SureGeiMing,                 // 确定改名（EGameType，string 修改后的名称）

    ChangeAudioVolumeing,                   // 改变音量大小ing(float 大小)
    ChangeAudioVolumeEnd,                   // 结束改变音量大小(float 大小)





}
