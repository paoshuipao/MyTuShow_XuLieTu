using System;

namespace Sirenix.OdinInspector
{

    /// <summary>
    /// <para>DisableInPlayMode is used on any property, and disables the property when in play mode.</para>
    /// <para>Use this to prevent users from editing a property when in play mode.</para>
    /// </summary>
    /// <example>
    /// <para>The following example shows how DisableInPlayMode is used to disable a property when in play mode.</para>
    /// <code>
    ///	public class MyComponent : MonoBehaviour
    ///	{
    ///		[DisableInPlayMode]
    ///		public int MyInt;
    ///	}
    /// </code>
    /// </example>
    /// <seealso cref="HideInPlayModeAttribute"/>
    /// <seealso cref="DisableInEditorModeAttribute"/>
    /// <seealso cref="HideInEditorModeAttribute"/>
    /// <seealso cref="EnableIfAttribute"/>
    /// <seealso cref="DisableIfAttribute"/>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    [DontApplyToListElements]
    public class DisableInPlayModeAttribute : Attribute
    {
        
    }
}