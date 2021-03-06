﻿
public enum E_GameEvent                           // 这里写事件
{

    LogoExit,                    // 离开Logo事件     logo -> 动画 -> 离开Logo -> 动画 -> RealJumpIntoScene 最终进入场景
    RealJumpIntoScene,           // 动画全部播放完成，进入了场景 （带 EF_Scenes scene 参数）

    ShowStartGameUI,             //进入 开始游戏 UI
    HideStartGameUI,             //隐藏


    ShowLog,                    // 显示 Log UI
    HideLog,                    // 隐藏



    ChangeLeftItem,             // 切换左边总的 Item （ushort 大的索引，ushort 小 底下的索引）
    
    ItemChange,                 // 大 Item 真的切换了,右边有什么开着的就关闭吧



    RealyDaoRu_File,             // 准备要导入（不知道是否成功,需要返回个结果的）(EDuoTuInfoType 样式，ushort 大的索引，ushort 小 底下的索引,List<FileInfo> 文件集合)
    RealyDaoRu_Result,           // 准备要导入（不知道是否成功,需要返回个结果的）(EDuoTuInfoType 样式，ushort 大的索引，ushort 小 底下的索引,List<ResultBean> 结果集合)


    DaoRu_FromFile,              // 直接导入 通过文件(ushort 大的索引，ushort 小 底下的索引，List<FileInfo> 文件集合)
    DaoRu_FromResult,            // 直接导入 通过结果(ushort 大的索引，ushort 小 底下的索引，List<ResultBean> 结果集合)



    ShowDuoTuInfo,           // 显示多图信息(ResultBean[] 文件集合，EDuoTuInfoType 展示类型)
    CloseDuoTuInfo,          // 关闭(EDuoTuInfoType 类型)
    OnClickNoSaveThisDuoTu,  // 点击了 不保存这个多图（EDuoTuInfoType 类型,string[] 删除路径）


    ShowSingleTuInfo,      // 显示单图信息（ResultBean 文件）





    ShowBeforeClick,            // 显示前置的按钮界面(EBeforeShow)
    OnClickChangeColor,         // 点击了 改变颜色按钮(ushort 大的索引 string 颜色字符)
    OnClickSureDeleteAll,       // 点击了 确定删除所有




    ChangeDaoRuGreenText,       // 导入成功 可以改变绿色字体了( List<ResultBean>)
    DaoRuSucees2Delete,         // 转换成功 可以把原来的删除了(List<ResultBean> )


    GaiBottomName,                // 底下的名称修改了（ushort 大的索引，ushort 小 底下的索引，string 修改后的名称）

    //————————————————————————————————————


    OpenFileContrl,                // 打开 文件 资源管理器
    OpenFolderContrl,              // 打开 文件夹 资源管理器
    CloseFileOrFolderContrl,       // 关闭 文件或者文件夹资源管理器







    OnClickDown_Shift,              // 按下 Shift
    OnClickUp_Shift,               //  松开 Shift

    OnClickDown_Ctrl,              // 按下 Ctrl
    OnClickUp_Ctrl,                // 松开 Ctrl

    OnClickCtrlAndA,               // 按下 Ctrl + A

    OnClickCtrlAndC,               // 按下 Ctrl + C

    OnClickMouseLeftUp,           // 点击鼠标左键
    OnClickMouseRightDown,          // 按下鼠标右键


    GoToNextFolderDaoRu,            // 去一个文件夹导入






    //————————————————————————————————————


    OnClickEscOrOnPause,       // 点击了 Esc 退出键 或者点击了 暂停的按钮


    ShowPauseUI,               // 显示 PauseUI


    HidePauseUI,               // Esc(马上游戏暂停)  -> PauseUI 动画 -> PauseUI  ->  Esc(还是暂停)   -> PauseUI 动画隐藏结束 -> 游戏才继续

    

    GameGoHead,                // 游戏继续


    OnQuitGame,                // 点击退出游戏



    //——————————————————— 导入 —————————————————



    ZhuangOtherDRSuccess,           // 转到其他导入成功




    //————————————————————————————————————





    DelteAll,               // 所有重置



    ShowChangeSizeSlider,         // 显示能改变大小的Slider


    ChangeAudioVolumeing,                   // 改变音量大小ing(float 大小)
    ChangeAudioVolumeEnd,                   // 结束改变音量大小(float 大小)





}
