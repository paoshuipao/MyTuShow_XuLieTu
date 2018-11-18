using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[AddComponentMenu("我的组件/UI/UGUI_ProgressBar(彩色进度条)", 5)]
public class UGUI_ProgressBar : MonoBehaviour
{

    public Color[] EachColors;



    private Image mImage;
    private float mCurrentValue;      // 当前的值
    private ushort mQuJian;           // 当前值的区间
    private EachColorValue[] l_Values;

    void Start()
    {
        mImage = GetComponent<Image>();
        if (null == EachColors || EachColors.Length < 2)
        {
            MyLog.Red("用这个彩色进度条的颜色值少过2个，有什么意义？");
            return;
        }
        l_Values =new EachColorValue[EachColors.Length];
        for (int i = 0; i < EachColors.Length; i++)
        {
            EachColorValue oneValue =new EachColorValue();
            oneValue.ColorValue = EachColors[i];
            oneValue.MinValue = (1f / EachColors.Length) * i;
            oneValue.MaxValue = (1f / EachColors.Length) * (i+1);
            if (i == EachColors.Length -1)       // 最后一个加 0.1
            {
                oneValue.MaxValue += 0.1f;
            }
            l_Values[i] = oneValue;
        }

        mCurrentValue = mImage.fillAmount;

    }


    void Update()
    {
        if (EachColors.Length < 2)        // 少过2个颜色就不要搞了
        {
            return;
        }
        if (mCurrentValue == mImage.fillAmount)         // 如果没有改变 mImage.fillAmount 的值就不需要动了
        {
            return;
        }

        mCurrentValue = mImage.fillAmount;
        for (int i = 0; i < l_Values.Length; i++)
        {
            if (mCurrentValue >= l_Values[i].MinValue && mCurrentValue < l_Values[i].MaxValue)
            {
                mImage.color = l_Values[i].ColorValue;
                break;
            }
        }



    }

    public struct EachColorValue
    {
        public Color ColorValue;   // 颜色
        public float MinValue;     // 最小值
        public float MaxValue;     // 最大值 

    }




}
