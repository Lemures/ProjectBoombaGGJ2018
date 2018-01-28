using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public float healthIncreaseRate = .1f;
    public LayerMask canDamage;
    public float playerDamage = 10;
    public float damageRate = 60;
    float number;
    Vector3 enemyVelocity;
    public Renderer BoombaRenderer;

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

        BoombaRenderer.materials[0].SetFloat("Float_639B7DA", health/100);
    }

    private void OnCollisionStay(Collision collision) {
        /*if (  collision.collider.gameObject.layer == 9 && gameObject.layer != 0) {
            var enemyVelocity = collision.gameObject.GetComponentInParent<Rigidbody>().velocity;
            health = health-(enemyVelocity.magnitude * playerDamage);
        }
        */
        
        /*if (collision.collider.gameObject.layer == 0){
            enemyVelocity = collision.collider.gameObject.GetComponentInParent<Rigidbody>().velocity;
        }
        */
        foreach (ContactPoint contact in collision.contacts) {
            if(contact.thisCollider.gameObject.layer == 0 && (contact.otherCollider.gameObject.layer == 9 || contact.otherCollider.gameObject.layer == 0)) {
                number++;
                if (number >= damageRate){
                    health = health-playerDamage;
                    number = 0;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == 8) {
        health = 0;
        gameObject.SetActive(false);
        CameraMovement.CameraShake();
        
    }
    }



}
