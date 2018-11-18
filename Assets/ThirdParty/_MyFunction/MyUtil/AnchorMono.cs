using PSPUtil.StaticUtil;
using UnityEngine;

[ExecuteInEditMode]
public class AnchorMono : MonoBehaviour
{

    public Camera AnchorCamera;
    public EAnchor Anchor;
    public Vector2 Offset;
    private float mHalfHigh;


    private Transform _myTransform;

    Transform mTransform
    {
        get
        {
            if (_myTransform == null)
            {
                _myTransform = transform;
            }
            return _myTransform;
        }
    }


    void Start ()
	{
	    if (null == AnchorCamera)
	    {
	        AnchorCamera = Camera.main;
	    }
	    if (!AnchorCamera.orthographic)
	    {
            MyLog.Red("暂时只能应用于正交相机 ");
	    }

	}


    void LateUpdate()
    {
        if (null == AnchorCamera || !AnchorCamera.orthographic)
        {
            MyLog.Red("相机为空 或者 不是正交");
            return;
        }
        float halfHeigh = AnchorCamera.orthographicSize;      // 一半高
        float halfWidth = AnchorCamera.aspect * halfHeigh;    // 一半宽

        switch (Anchor)
        {
            case EAnchor.BottomLeft:
                mTransform.localPosition = new Vector3(-halfWidth + Offset.x, -halfHeigh + Offset.y, mTransform.localPosition.z);
                break;
            case EAnchor.BottomCenter:
                mTransform.localPosition = new Vector3(Offset.x, -halfHeigh + Offset.y, mTransform.localPosition.z);
                break;
            case EAnchor.BottomRight:
                mTransform.localPosition = new Vector3(halfWidth + Offset.x, -halfHeigh + Offset.y, mTransform.localPosition.z);
                break;
            case EAnchor.MiddleLeft:
                mTransform.localPosition = new Vector3(-halfWidth +Offset.x, Offset.y, mTransform.localPosition.z);
                break;
            case EAnchor.MiddleCenter:
                mTransform.localPosition = new Vector3(Offset.x, Offset.y, mTransform.localPosition.z);
                break;
            case EAnchor.MiddleRight:
                mTransform.localPosition = new Vector3(halfWidth + Offset.x, Offset.y, mTransform.localPosition.z);
                break;
            case EAnchor.TopLeft:
                mTransform.localPosition = new Vector3(-halfWidth + Offset.x, halfHeigh + Offset.y, mTransform.localPosition.z);
                break;
            case EAnchor.TopCenter:
                mTransform.localPosition = new Vector3(Offset.x, halfHeigh + Offset.y, mTransform.localPosition.z);
                break;
            case EAnchor.TopRight:
                mTransform.localPosition = new Vector3(halfWidth + Offset.x, halfHeigh + Offset.y, mTransform.localPosition.z);
                break;
        }
    }










    public enum EAnchor
    {
        BottomLeft,       // 下左
        BottomCenter,     // 下中
        BottomRight,      // 下右
        MiddleLeft,       // 中左
        MiddleCenter,     // 中间
        MiddleRight,      // 中右
        TopLeft,          // 上左
        TopCenter,        // 上中
        TopRight,         // 上右
    }



}
