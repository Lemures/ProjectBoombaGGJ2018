﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatRandomMovement : MonoBehaviour {

    public float ratRandomMin = .1f;
    public float ratRandomMax = 1f;
    private bool ratRunning = false;
    public float circleSize = 15;
    public Vector3 target;
    public float speed;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        Vector3 targetDir = target - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);

        if (ratRunning == false) {
            StartCoroutine("TurnRat");
        }
	}

    IEnumerator TurnRat() {
        ratRunning = true;
        var ratRandomness = Random.Range(ratRandomMin, ratRandomMax);
        target = Random.insideUnitCircle * circleSize;
        target.z = target.y + transform.position.z;
        target.y = .5f;
        yield return new WaitForSeconds(ratRandomness);
        ratRunning = false;
        
    }

}
