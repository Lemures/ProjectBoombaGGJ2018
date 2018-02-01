using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticleScript : MonoBehaviour
{

    private Quaternion _startingRotation;

    protected void Awake()
    {
        _startingRotation = transform.rotation;
    }
    protected void lateUpdate()
    {
        transform.rotation = _startingRotation;
    }
}
