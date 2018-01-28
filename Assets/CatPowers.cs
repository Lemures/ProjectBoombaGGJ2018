using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPowers : MonoBehaviour {

    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    private LineRenderer laserLine;
    private AudioSource gunAudio;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    // Use this for initialization
    void Start () {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if(Input.GetKeyDown(KeyCode.Space)){
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);
            if (Physics.SphereCast(transform.position, 1, transform.TransformDirection(Vector3.forward), out hit, weaponRange)) {
                if (hit.rigidbody != null) {

                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                
                }
            }
        }
    }

    private IEnumerator ShotEffect() {
        gunAudio.Play();
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}
