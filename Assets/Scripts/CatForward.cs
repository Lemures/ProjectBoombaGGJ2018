using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatForward : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            StartCoroutine("SelfInvis");
        }

    IEnumerator SelfInvis() {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
       
    }
}
