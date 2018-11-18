using UnityEngine;

public class CUDefaultItemRenderer<T> : AB_CUItemRenderer<T>
{
    public float defaultHeight = 20f;

    public override float MeasureHeight(T item)
    {
        return defaultHeight;
    }

    public override void Arrange(T item, int itemIndex, bool selected, bool focused, Rect itemRect)
    {
        GUIStyle backgroundStyle = itemIndex % 2 == 1 ? ListStyle.oddBackground : ListStyle.evenBackground;
        backgroundStyle.Draw(itemRect, false, false, selected, focused);
        ListStyle.item.Draw(itemRect, item.ToString(), true, false, selected, false);
    }
}