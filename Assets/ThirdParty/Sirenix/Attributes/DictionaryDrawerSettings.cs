using System;

namespace Sirenix.OdinInspector
{
    /// <summary>
    /// Customize the behavior for dictionaries in the inspector.
    /// </summary>
    public sealed class DictionaryDrawerSettings : Attribute
    {
        private string keyLabel = "Keys";
        private string valueLabel = "Values";

        /// <summary>
        /// Specify how the dictionary should draw its items.
        /// </summary>
        public DictionaryDisplayOptions DisplayMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read only.
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Specify an alternative key label for the dictionary drawer.
        /// </summary>
        public string KeyLabel
        {
            get { return this.keyLabel; }
            set { this.keyLabel = value; }
        }

        /// <summary>
        /// Specify an alternative value label for the dictionary drawer.
        /// </summary>
        public string ValueLabel
        {
            get { return this.valueLabel; }
            set { this.valueLabel = value; }
        }
    }
}