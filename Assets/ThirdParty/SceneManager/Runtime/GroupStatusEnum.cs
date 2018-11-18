/// <summary>
/// 组的状态
/// </summary>
public enum GroupStatusEnum
{
    /// <summary>
    /// 没有组的水平被发挥
    /// </summary>
    New,

    /// <summary>
    /// 组中至少有一个级别处于打开状态。 自动设置为第一个
    /// </summary>
    Open,

    /// <summary>
    /// 已经玩过至少一个级别的小组（但不一定完成）。
    /// </summary>
    Visited,

    /// <summary>
    /// 小组的最后一级已经完成
    /// </summary>
    Done
}