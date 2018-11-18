#define UseMy3DObject               // 如果不喜欢使用它，就把这个注释掉即可

using UnityEngine;

namespace UnityEditor
{
    public class Tools_RightKey                                   // 右键添加的都在这里
    {

#if UseMy3DObject          

        [MenuItem(LearnMenu.CUBE, priority = 0)]
        static void CreateCube()
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube);
        }

        [MenuItem(LearnMenu.SPHERE, priority = 1)]
        static void CreateSphere()
        {
            GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }

        [MenuItem(LearnMenu.CAPSULE, priority = 2)]
        static void CreateCapsule()
        {
            GameObject.CreatePrimitive(PrimitiveType.Capsule);
        }

        [MenuItem(LearnMenu.CYLINDER, priority = 3)]
        static void CreateCylinder()
        {
            GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        }

        [MenuItem(LearnMenu.PLANE, priority = 4)]
        static void CreatePlane()
        {
            GameObject.CreatePrimitive(PrimitiveType.Plane);
        }

        [MenuItem(LearnMenu.QUAD, priority = 5)]
        static void CreateQuad()
        {
            GameObject.CreatePrimitive(PrimitiveType.Quad);
        }

        [MenuItem(LearnMenu.ZONE1, priority = 7)]
        static void CreateWindZone1()
        {
            GameObject go = new GameObject("WindZone");
            WindZone wind = go.AddComponent<WindZone>();
            wind.mode = WindZoneMode.Directional;
            wind.windMain = 1;
            wind.windTurbulence = 0.1f;
            wind.windPulseMagnitude = 1f;
            wind.windPulseFrequency = 0.25f;
        }

        [MenuItem(LearnMenu.ZONE2, priority = 7)]
        static void CreateWindZone2()
        {
            GameObject go = new GameObject("WindZone");
            WindZone wind = go.AddComponent<WindZone>();
            wind.mode = WindZoneMode.Spherical;
            wind.radius = 5;
            wind.windMain = 3;
            wind.windTurbulence = 5f;
            wind.windPulseMagnitude = 0.1f;
            wind.windPulseFrequency = 1f;
        }

#endif

    }

}

