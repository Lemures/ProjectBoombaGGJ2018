using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public float healthIncreaseRate = .1f;
    public LayerMask canDamage;

	void Start () {
	}

    private void FixedUpdate() {
        health += healthIncreaseRate;
    }

    private void Update() {
        if (health >= 100) {
            health = 100;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == 9) {
            var enemyVelocity = collision.collider.gameObject.GetComponent<Rigidbody>().velocity;
            health = health-enemyVelocity.magnitude;
        }
    }
}
