using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatForward : MonoBehaviour
{
    protected void Update()
    {
        StartCoroutine("SelfInvis");
    }

    private IEnumerator SelfInvis()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}
