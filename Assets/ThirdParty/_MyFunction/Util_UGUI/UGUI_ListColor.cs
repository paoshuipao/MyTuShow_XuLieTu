using System.Collections.Generic;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using UnityEngine;


[AddComponentMenu("我的组件/UI/UGUI_ListColor(颜色集合)", 13)]

public class UGUI_ListColor : MonoBehaviour
{

    public List<Color> L_Colors;





    
    [Button("添加几个进来")]
    void AddSomeColor()
    {
        if (null == L_Colors)
        {
            L_Colors = new List<Color>();
        }

        L_Colors.Add(MyColor.GetColor(MyEnumColor.LightBlue));
        L_Colors.Add(MyColor.GetColor(MyEnumColor.Blue));
        L_Colors.Add(MyColor.GetColor(MyEnumColor.Yellow));
        L_Colors.Add(MyColor.GetColor(MyEnumColor.Orange));
        L_Colors.Add(MyColor.GetColor(MyEnumColor.Green));
        L_Colors.Add(MyColor.GetColor(MyEnumColor.LightGreen));


    }



}
