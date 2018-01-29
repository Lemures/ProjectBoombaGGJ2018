using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookat : MonoBehaviour
{
    public Transform LookatAnchor;
    public float YOffset = 0;

    void Update()
    {
        Vector3 Lookat = LookatAnchor.position;
        Lookat.y += YOffset;
        transform.LookAt(Lookat);
    }
}
