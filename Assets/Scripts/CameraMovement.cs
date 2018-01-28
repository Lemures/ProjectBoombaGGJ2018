using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


    static GameObject mainCamera;

    void Start()
    {
        mainCamera = Camera.main.gameObject;

    }
    public static void CameraShake() {
        iTween.ShakePosition(mainCamera, iTween.Hash("x", 0.1f, "time", 0.5f));
    }
}
