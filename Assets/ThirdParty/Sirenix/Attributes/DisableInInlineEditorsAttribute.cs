using System;


namespace Sirenix.OdinInspector
{

    /// <summary>
    /// Disables a property if it is drawn within an <see cref="InlineEditorAttribute"/>.
    /// </summary>
    [DontApplyToListElements]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public class DisableInInlineEditorsAttribute : Attribute
    {

    }
}
