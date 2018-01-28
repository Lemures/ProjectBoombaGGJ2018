using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPitchVelocity : MonoBehaviour {

    Rigidbody rb;
    AudioSource audioSucc;
    public float startingPitch;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
        audioSucc = GetComponent<AudioSource>();
        audioSucc.pitch = startingPitch;
	}
	
	// Update is called once per frame
	void Update () {
        audioSucc.pitch = startingPitch * (1+rb.velocity.magnitude)/4;
    }
}
