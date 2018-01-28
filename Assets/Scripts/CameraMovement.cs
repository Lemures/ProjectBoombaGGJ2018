using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


    static GameObject mainCamera;

    void Start()
    {
        mainCamera = Camera.main.gameObject;
        StartCoroutine(CamStart());

    }

    private IEnumerator CamStart()
    {
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(mainCamera, new Vector3(0, 5.72f, -6.1f), 3);
    }
    public static void CameraShake() {
        iTween.ShakePosition(mainCamera, iTween.Hash("x", 0.1f, "time", 0.5f));
    }
}
