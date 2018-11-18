
namespace Sirenix.OdinInspector
{
    using System;

    /// <summary>
    /// Disables a property if it is drawn from a prefab asset.
    /// </summary>
    [DontApplyToListElements]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public class DisableInPrefabAssetsAttribute : Attribute
    {

    }
}
