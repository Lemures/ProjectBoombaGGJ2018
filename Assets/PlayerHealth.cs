using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public float healthIncreaseRate = .1f;
    public LayerMask canDamage;
    public float playerDamage = 10;

	void Start () {
	}

    private void FixedUpdate() {
        health += healthIncreaseRate;
    }

    private void Update() {
        if (health >= 100) {
            health = 100;
        }
        if (health <= 0) {
            health = 0;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == 9) {
            var enemyVelocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
            health = health-(enemyVelocity.magnitude * playerDamage);
        }
    }
}
