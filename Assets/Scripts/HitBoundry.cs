using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoundry : MonoBehaviour {

    public LayerMask mask = 8;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == 8) {
        gameObject.SetActive(false);
            
        }
    }



}
