using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{

    void Start()
    {
        Invoke("KillMyself", 2);
    }

    void KillMyself()
    {
        Destroy(gameObject);
    }
}
