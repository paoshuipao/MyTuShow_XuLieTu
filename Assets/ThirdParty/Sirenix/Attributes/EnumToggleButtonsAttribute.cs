using System;
using PSPUtil.StaticUtil;

namespace Sirenix.OdinInspector
{

    /// <summary>
    /// <para>Draws an enum in a horizontal button group instead of a dropdown.</para>
    /// </summary>
    /// <example>
    /// <code>
    /// public class MyComponent : MonoBehvaiour
    /// {
    ///
    ///     [EnumToggleButtons]
    ///     public MyBitmaskEnum MyBitmaskEnum;
    ///
    ///     [EnumToggleButtons]
    ///     public MyEnum MyEnum;
    /// }
    ///
    /// [Flags]
    /// public enum MyBitmaskEnum
    /// {
    ///     A = 1 &lt;&lt; 1, // 1
    ///     B = 1 &lt;&lt; 2, // 2
    ///     C = 1 &lt;&lt; 3, // 4
    ///     ALL = A | B | C
    /// }
    ///
    /// public enum MyEnum
    /// {
    ///     A,
    ///     B,
    ///     C
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="System.Attribute" />
    public class EnumToggleButtonsAttribute : Attribute
    {
        public bool IsBiaoTi { get; private set; }
        public MyEnumColor TextColor { get; private set; }

        public int ButtonSize { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumToggleButtonsAttribute"/> class.
        /// </summary>
        public EnumToggleButtonsAttribute(bool isBiaoTi = false,int size= 120)
        {
            IsBiaoTi = isBiaoTi;
            TextColor = MyEnumColor.Orange;
            ButtonSize = size;
        }


        public EnumToggleButtonsAttribute(MyEnumColor textColor, int size = 120)
        {
            IsBiaoTi = true;
            TextColor = textColor;
            ButtonSize = size;
        }



    }
}