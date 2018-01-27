using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatRandomMovement : MonoBehaviour {

    private GameObject rat;
    private Rigidbody rb;
    public float ratVelocity;
    private float ratRandomness;
    public float ratRandomMin = .1f;
    public float ratRandomMax = 1f;
    private bool ratRunning;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(ratRunning == false) {

        }
	}

    IEnumerable MoveRat() {
        ratRunning = true;
        ratRandomness = Random.Range(ratRandomMin, ratRandomMax);
        yield return new WaitForSeconds(Random.Range(.1f,1));
        rb.AddForce(Vector3.forward * ratVelocity, ForceMode.Impulse);
        ratRunning = false;
    }

}
