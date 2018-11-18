public enum EnumDropType
{
    /// <summary>
    /// 落在特定的位置。 例如 between items
    /// Drop at a specific position. E.g. between items
    /// </summary>
    AtPosition,

    /// <summary>
    /// 放入特定的项目。 例如。 从一个文件夹移动到另一个
    /// </summary>
    IntoItem,

    /// <summary>
    ///放入整个容器。 例如，改变物品状态的特殊情况。
    /// </summary>
    IntoContainer
}