using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMyself : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("KillMyself", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void KillMyself() {
        Destroy(gameObject);
    }
}
