using UnityEngine;
using UnityEngine.EventSystems;

public enum MyUIExpandType
{
    DragWithAlwaysDown,                                      //拖拽需要一直按下
    DragWithTwoClick                                         //点击图跟着鼠标再点击图放下
}


[AddComponentMenu("我的组件/UI/UGUI_Drag(拖拽)", 3)]
[DisallowMultipleComponent]
public class UGUI_Drag :                                      //所有UI的扩展类
    MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerDownHandler
{

    public MyUIExpandType UiExpandType = MyUIExpandType.DragWithAlwaysDown;

    private Vector2 m_InSelfPos;                             //相对于自己小框框的位置
    private RectTransform m_CanvasRT;                        //Canvas RectTransform
    private RectTransform m_RT;                              //这个物体的 RectTransform

    private Vector2 m_InCanvasPos;                           //相对于Canvas大框框的位置
    private bool isClick = false;
    void Start()
    {
        m_RT = transform as RectTransform;
        m_CanvasRT = GetComponentInParent<Canvas>().transform as RectTransform;

    }

    //开始拖的时候记下位置
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (UiExpandType == MyUIExpandType.DragWithAlwaysDown)
        {
            //点击的坐标（eventData.position）根据 相对于自己的小框框 转成UGUI坐标 ->m_ThisPos(对于自己小框框的位置)
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_RT, eventData.position, eventData.enterEventCamera, out m_InSelfPos);
        }

    }

    //每拖一段调用一次这里
    public void OnDrag(PointerEventData eventData)
    {
        if (UiExpandType == MyUIExpandType.DragWithAlwaysDown)
        {
            //点击的坐标（eventData.position）根据 相对于Canvas的大框框 转成UGUI坐标 ->m_CanvasPos(对于Canvas大框框的位置)
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_CanvasRT, eventData.position, eventData.enterEventCamera, out m_InCanvasPos);
            //把转换后的坐标给我们的物体
            m_RT.anchoredPosition = m_InCanvasPos - m_InSelfPos;
        }

    }



    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isClick)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_RT, eventData.position, eventData.enterEventCamera, out m_InSelfPos);
            FollowMouse(eventData.position);
        }
        isClick = !isClick;
    }


    void Update()
    {
        if (!isClick)
        {
            return;
        }
        FollowMouse(Input.mousePosition);
    }

    private void FollowMouse(Vector2 position)
    {
        if (UiExpandType == MyUIExpandType.DragWithTwoClick)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_CanvasRT, position, null, out m_InCanvasPos);
            m_RT.anchoredPosition = m_InCanvasPos - m_InSelfPos;
        }
    }



}