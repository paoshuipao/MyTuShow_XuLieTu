using System;

namespace Sirenix.OdinInspector
{

    /// <summary>
    /// Disables a property if it is drawn from a non-prefab asset or instance.
    /// </summary>
    [DontApplyToListElements]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public class DisableInNonPrefabsAttribute : Attribute
    {

    }
}
