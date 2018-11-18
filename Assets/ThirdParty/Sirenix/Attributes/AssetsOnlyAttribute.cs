using System;

namespace Sirenix.OdinInspector
{
    /// <summary>
    /// <para>AssetsOnly is used on object properties, and restricts the property to project assets, and not scene objects.</para>
    /// <para>Use this when you want to ensure an object is from the project, and not from the scene.</para>
    /// </summary>
    /// <example>
	/// <para>The following example shows a component with a game object property, that must be a prefab from the project, and not a scene object.</para>
    /// <code>
    /// public MyComponent : MonoBehaviour
	/// {
	///		[AssetsOnly]
	///		public GameObject MyPrefab;
	/// }
    /// </code>
    /// </example>
	/// <seealso cref="SceneObjectsOnlyAttribute"/>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class AssetsOnlyAttribute : Attribute
    {
    }
}