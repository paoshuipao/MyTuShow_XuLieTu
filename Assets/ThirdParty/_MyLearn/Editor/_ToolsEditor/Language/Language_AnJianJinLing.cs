using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;

namespace UnityEditor
{
    public class Language_AnJianJinLing : AbstractKuang<Language_AnJianJinLing>
    {
        protected override void OnEditorGUI()
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace();
                m_Tools.TextUrl("API文档  ".PadLeft(50), MyComputePath.AnJianJinLinLearnUrl);

            });
            BianLiang();
            KeyWord();
            Method();
            SelfMethod();

        }

        private void BianLiang()                                 //变量
        {
            m_Tools.BiaoTi_O("变量 "+"（不需要声明）".AddHui());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("屏幕宽度", "width = Plugin.Sys.GetScRX()");
                m_Tools.TextText_BL("屏幕高度", "height = Plugin.Sys.GetScRY()");
                m_Tools.TextText_BL("键盘的值", "Key=WaitKey()，if( key == 几)", ref isKey, () =>
                {
                    MyCreate.Box(() =>
                    {
                        KeyValue("回车", "13", "空格", "32", "Tab", "9", "", "");
                        KeyValue("Shift", "16", "Ctrl", "17", "Alt", "18", "CapsLock", "20");
                        KeyValue("~", "192", "-", "189", "+", "187", "←", "8");
                        KeyValue("0", "48", "1", "49", "8", "56", "9", "57");
                        KeyValue("a", "65", "b", "66", "y", "89", "z", "90");
                    });

                });

                m_Tools.TextText_BL("获得当前鼠标坐标", "GetCursorPos x,y  "+"(x ,y 就是参数 ref x,ref y)".AddGreen());
                MyCreate.Text("特殊：可在面板处修改：");
                m_Tools.TextText("UserVar str1 = “默认值 ”".AddLightBlue(), "用户可修改的 string （相当于Input）");
                m_Tools.Text_L("UserVar MoShi = DropList{“ Enum1名 ”：0 |  “ Enum2名 ”：1  } = 0 ");
                m_Tools.TextText("", "用户可修改的 int（相当 Enum）");
            });
        }

        private void KeyWord()                                   //关键字
        {
            m_Tools.BiaoTi_O("关键字");
            m_Tools.Text_Y("1. break  " + "(每个内部对应有不同的 break)".AddLightGreen(), ref isBreak, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.SelectTextText_B("Exit Do", "退出 while 循环");
                    m_Tools.SelectTextText_B("Exit For", "退出 for 循环");
                    m_Tools.SelectTextText_B("Exit Sub", "退出 子程序");
                    m_Tools.SelectTextText_B("Exit Function", "退出 Function 函数");
                    m_Tools.SelectTextText_B("Exit Event", "退出 Event 函数");
                });
            });

            m_Tools.Text_Y("2. 字符串连接用 " , "& ".AddGreen() , " (不用 + )".AddLightGreen());

        }

        private void Method()                                    //判断 循环
        {
            m_Tools.BiaoTi_O("方法");
            m_Tools.Text_Y("void 方法 不带返回值", ref isCreateMethod, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("Sub " + MethodName + "( value )", "// void " + MethodName + "( int / string value)");
                    m_Tools.TextText_BG("     ...  ", "// 内容 (跳出用 Exit Sub)");
                    m_Tools.TextText_BG("End Sub", "");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("Call " + MethodName + "( 1 )", "// 调用方法 ");
                });
            });

            m_Tools.Text_Y("var  方法 带返回值", ref isFunction, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("Function " + MethodName + "( value )", "   // var " + MethodName + "( int / string value)");
                    m_Tools.TextText_BG("     ...  ", "          // 内容 (跳出用 Exit Function)");
                    m_Tools.TextText_BG("     " + MethodName + " = 1", "         // return 1");
                    m_Tools.TextText_BG("End Function", "");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("i= " + MethodName + "( 2 )", "         // 调用方法");
                });
            });

            m_Tools.Text_Y("判断 if", ref isIf, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("If ( Key = w ) Then", "// if(判断语句)");
                    m_Tools.TextText_BG("     ...  ", "// 内容");
                    m_Tools.TextText_BG("ElseIf ( i=1 ) Then", "// else if(判断语句)");
                    m_Tools.TextText_BG("     ...  ", "");
                    m_Tools.TextText_BG("Else ", "// else");
                    m_Tools.TextText_BG("     ...  ", "");
                    m_Tools.TextText_BG("End If ", "");
                });
            });

            m_Tools.Text_Y("判断颜色 IfColor ", ref isIfColor, () =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.TextCenter("//判断条件(0:等于 1:不等于 2:近似等于) ");
                    m_Tools.TextText_BG("IfColor ( 860 , 27,“e1b072”," + "2".AddGreen() + " )  Then", "    // if 坐标颜色近似等于 e1b072");
                    m_Tools.TextText_BG("      Msgbox “ 颜色近似等于”", "");
                    m_Tools.TextText_BG("Else  ", "");
                    m_Tools.TextText_BG("      Msgbox “ 颜色不等于”", "");
                    m_Tools.TextText_BG("End If ", "");
                });
            });

            m_Tools.Text_Y("循环 while", ref isWhile, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("i=0 ", "// 先定义");
                    m_Tools.TextText_BG("Do While ( i=0 )", "// while( i=0 ) ，while true 也行");
                    m_Tools.TextText_BG("     ...  ", "// 内容 (跳出循环用 Exit Do)");
                    m_Tools.TextText_BG("Loop ", "");
                });
            });

            m_Tools.Text_Y("选择 switch", ref isSwitch, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("Select Case 变量", "// switch (变量)");
                    m_Tools.TextText_BG("    Case 0", "// case 0 :");
                    m_Tools.TextText_BG("       ...  ", "");
                    m_Tools.TextText_BG("    Case “str”", "// case “str”:");
                    m_Tools.TextText_BG("        ...  ", "");
                    m_Tools.TextText_BG("    Case Else", "// default :");
                    m_Tools.TextText_BG("         ...  ", "");
                    m_Tools.TextText_BG("End Select ", "");
                });
            });

            m_Tools.Text_Y("循环 for", ref isFor, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("For i=0 To 9", "// for(int i=0,i<=9,i++)");
                    m_Tools.TextText_BG("     ...  ", "// 内容 (跳出循环用 Exit For)");
                    m_Tools.TextText_BG("Next ", "");
                });

                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("For i=0 To 9 step 2", "// for(int i=0,i<=9,i+2)");
                    m_Tools.TextText_BG("     ...  ", "");
                    m_Tools.TextText_BG("Next ", "");
                });
            });

            m_Tools.Text_Y("Goto 跳转到标记 Rem", ref isGoto, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("Goto 标记 ", "// 跳到下面的标记处");
                    m_Tools.TextText_BG("   Delay 1000 ", "// 这时的延时就不会执行");
                    m_Tools.TextText_BG("Rem 标记 ", "");
                });

                MyCreate.Box(() =>
                {
                    MyCreate.TextCenter("Rem 既可以当标记用，也可以当注释用");
                    MyCreate.TextCenter("Rem 不支持数字开关或用符号");
                    m_Tools.TextText_BG("Rem 脚本开始", "");
                });
            });

            m_Tools.Text_Y("区域找颜色", ref isFinColor, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("区域(0 ,0 ,300 ,300)");
                    m_Tools.Text_G("颜色值 0000FF");
                    m_Tools.Text_G("1 ：从中心开始找 ，也可以使用 0 从左上角开始找");
                    m_Tools.Text_G("0.8：颜色值的相似度，越高越严格");
                    m_Tools.Text_G("x ，y 为 ref， 找到的点，找不到为 -1");
                    m_Tools.Text_B("FindColorEx 0 ,0 ,300 ,300 ,“ 颜色值 ”,1, 0.8 , x , y");
                    m_Tools.TextText_BG("   If x > 0 And y > 0 Then", "// 找不到 x = -1 或 y = -1");
                    m_Tools.TextText_BG("        MoveTo x, y", "// 移动到这个点");
                    m_Tools.Text_B("End If");

                });
            });

            m_Tools.Text_Y("区域找图", ref isTu, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("1.在附件那里添加图片");
                    m_Tools.Text_G("2.附件图片Url为 : “" + " Attachment".AddWhite() , ": \\text.bmp(png.jpg) ” ");
                    m_Tools.Text_G("3.0.8 为相似度");
                    m_Tools.Text_G("4.找到的（x，y）为左上点，找不到为 -1");
                    m_Tools.Text_B("FindPic 0 ,0 ,300 ,300 ,url , 0.8 , x , y");
                    m_Tools.Text_B("   If x > 0 And y > 0 Then");
                    m_Tools.TextText_BG("        MoveTo x, y", "// 移动到这个点");
                    m_Tools.Text_B("End If");

                });
            });


            m_Tools.Text_Y("区域找字", ref isFindZi, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("1.代码与（区域找图）相同");
                    m_Tools.Text_G("2.不同的是图片处理");

                    m_Tools.Text_B("一.把字的图放到画图工具上，按 " + "Ctrl + G".AddGreen() + " 显示格子");
                    m_Tools.Text_B("二.把字留下颜色，其它的都染上同一种颜色（四角必须是这种颜色）");


                });
            });



        }

        private void SelfMethod()                                //提供的方法
        {
            m_Tools.BiaoTi_O("自带方法", () =>
            {
                isKeyborad = false;
                isMouse = false;
                isContrl = false;
            });
            MyCreate.Box(() =>
            {
                MyCreate.Box(() =>
                {
                    MethodHasReturn("Key=WaitKey( )", "等待按任意键".AddGreen() + "，当点下才执行下面语句", "int");
                    m_Tools.SelectTextText_B("KeyPress string ,int", "点击键盘" + "(string 那个键，int 次数)".AddLightBlue());
                    m_Tools.Text_Y("键盘操作", ref isKeyborad, () =>
                    {
                        MethodHasReturn("Key=GetLastKey( )", "上次按键", "int");
                        m_Tools.SelectTextText_B("KeyDown/KeyUp string,int", "按下/弹起" + "(string 那个键，int 次数)".AddLightBlue());
                    });
                });
                MyCreate.Box(() =>
                {
                    m_Tools.SelectTextText_B("LeftClick ( int )", "左击" + "(int 次数)".AddLightBlue());
                    m_Tools.SelectTextText_B("LeftDoubleClick ( int )", "双击" + "(int 次数)".AddLightBlue());
                    m_Tools.SelectTextText_B("LockMouse ( )", "锁定鼠标".AddGreen() + ",调用防止乱动鼠标 " + "(解除：UnlockMouse)".AddLightBlue());
                    m_Tools.SelectTextText_B("GetCursorPos mx,my", "获得当前鼠标坐标 " + "GetCursorPos(ref mx,ref my)".AddGreen());

                    m_Tools.Text_Y("鼠标操作", ref isMouse, () =>
                    {
                        m_Tools.SelectTextText_B("MoveR int x ，int y", "在当前位置上加上(x,y)");
                        m_Tools.SelectTextText_B("MoveTo int x ，int y", "移动到(x,y)位置上");
                        m_Tools.SelectTextText_B("SaveMousePos ( )", "保存当前鼠标位置");
                        m_Tools.SelectTextText_B("RestoreMousePos ( )", "鼠标恢复到保存的位置上");
                        m_Tools.SelectTextText_B("MouseWheel ( int )", "鼠标滚轮" + "(1 表示向下1格，-1 表示向上1格)".AddLightBlue());
                        MethodHasReturn("Key=WaitClick ( )", "等待按任意鼠标点击".AddGreen() + "，当点下才执行下面语句", "int");
                        m_Tools.SelectTextText_B("RightClick ( int )", "右击" + "(int 次数)".AddLightBlue());
                        m_Tools.SelectTextText_B("LeftDown/LeftUp int", "左鼠标按下/弹起" + "( int 次数)".AddLightBlue());

                    });
                });
                MyCreate.Box(() =>
                {
                    m_Tools.SelectTextText_B("EndScript", "脚本到此为止");
                    m_Tools.SelectTextText_B("Call RunApp( string)", "打开程序（全路径或我定好的程序）、网页");
                    m_Tools.Text_Y("脚本控制", ref isContrl, () =>
                    {
                        m_Tools.SelectTextText_B("Delay 100", "延迟 100 毫秒");
                        m_Tools.SelectTextText_B("EndScript", "停止脚本");
                        m_Tools.SelectTextText_B("RestartScript", "重新启动脚本");
                        m_Tools.SelectTextText_B("ExitScript", "退出脚本");
                    });
                });

                MyCreate.Box(() =>
                {
                    m_Tools.SelectTextText_B("MsgBox", "弹出提示框，可当 Log");
                    m_Tools.SelectTextText_B("Input = InputBox(标题)", "弹出输入框提供输入");
                    m_Tools.SelectTextText_B("Call Plugin.Msg.Tips(string)", "Tips 显示气泡信息提示");
                    m_Tools.Text_Y("弹出框", ref isTang, () =>
                    {

                    });
                });

            });
        }



        #region 私有

        private bool isCreateMethod, isIf, isKey, isWhile, isBreak, isFor, isFunction, isGoto, isTu, isFindZi;
        private bool isIfColor, isSwitch, isKeyborad, isMouse, isContrl, isFinColor, isTang;

        private static readonly string MethodName = "MethodName".AddLightBlue();


        [MenuItem(LearnMenu.OtherLanguage1)]
        public static void ShowWindow()
        {
            CreateWindow("按键精灵",550,500);
        }

        protected override string Tittle()
        {
            return "";
        }


        protected override int OnChangeJianGe()
        {
            return 180;
        }

        #endregion

        private void MethodHasReturn(string str1, string str2, string str3)
        {
            MyCreate.Heng(() =>
            {
                m_Tools.SelectTextText_B(str1, str2);
                MyCreate.AddSpace();
                MyCreate.Text(str3.AddWhite());
            });

        }



        private void KeyValue(string str1, string str1Key, string str2, string str2Key, string str3, string str3Key, string str4, string str4Key)
        {
            MyCreate.Heng(() =>
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.Text(str1.AddYellow(), 55);
                    MyCreate.Text(str1Key.AddHui());
                });
                MyCreate.AddSpace(50);
                MyCreate.Heng(() =>
                {
                    MyCreate.Text(str2.AddYellow(), 55);
                    MyCreate.Text(str2Key.AddHui());
                });
                MyCreate.AddSpace(50);
                MyCreate.Heng(() =>
                {
                    MyCreate.Text(str3.AddYellow(), 55);
                    MyCreate.Text(str3Key.AddHui());
                });
                MyCreate.AddSpace(50);
                MyCreate.Heng(() =>
                {
                    MyCreate.Text(str4.AddYellow(), 55);
                    MyCreate.Text(str4Key.AddHui());
                });
            });

        }



    }

}


