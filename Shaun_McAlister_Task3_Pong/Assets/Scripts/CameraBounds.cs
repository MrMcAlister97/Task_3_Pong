using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public static Vector3 TopRight
    {
        get
        {
            return Camera.main.ViewportToWorldPoint(Vector3.one);
        }
    }

    public static Vector3 BottomLeft
    {
        get
        {
            return Camera.main.ViewportToWorldPoint(Vector3.zero);
        }
    }
}
