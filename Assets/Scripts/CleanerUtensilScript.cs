using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerUtensilScript : MonoBehaviour
{

    public float SpinMultiplier;

    protected void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * SpinMultiplier * 2);
    }
}
