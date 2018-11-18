using System;

namespace Sirenix.OdinInspector
{
    /// <summary>
    /// Delays applying changes to properties while they still being edited in the inspector.
    /// Similar to Unity's built-in Delayed attribute, but this attribute can also be applied to properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DelayedPropertyAttribute : Attribute
    {
    }
}