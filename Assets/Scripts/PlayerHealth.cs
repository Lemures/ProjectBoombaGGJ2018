using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health = 0;
    public float healthIncreaseRate = .1f;
    public LayerMask canDamage;
    public float playerDamage = 10;
    public float damageRate = 60;
    float number;
    Vector3 enemyVelocity;
    public Renderer BoombaRenderer;
    public bool catPowerEnabled = false;
    public GameObject cat;
    public float catScore = 0;
    public GameObject explosionPart;
    private Vector3 explodeLocation;


    private void Update()
    {
        health += healthIncreaseRate * Time.deltaTime;

        if (health >= 100)
        {
            health = 100;
        }
        if (health <= 0)
        {
            health = 0;
        }

        BoombaRenderer.materials[0].SetFloat("Float_639B7DA", health / 100);

        if (catPowerEnabled)
        {
            cat.SetActive(true);
            catScore += 10 * Time.deltaTime;
        }
        else
        {
            cat.SetActive(false);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        /*if (  collision.collider.gameObject.layer == 9 && gameObject.layer != 0) {
            var enemyVelocity = collision.gameObject.GetComponentInParent<Rigidbody>().velocity;
            health = health-(enemyVelocity.magnitude * playerDamage);
        }
        */

        /*if (collision.collider.gameObject.layer == 0){
            enemyVelocity = collision.collider.gameObject.GetComponentInParent<Rigidbody>().velocity;
        }
        */
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.thisCollider.gameObject.layer == 0 && (contact.otherCollider.gameObject.layer == 9 || contact.otherCollider.gameObject.layer == 0))
            {
                number++;
                if (number >= damageRate)
                {
                    health = health - playerDamage;
                    number = 0;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 0)
        {
            AudioController.Instance.PlayRoombaHitSounds();
        }
        if (collision.collider.gameObject.layer == 8)
        {
            explodeLocation = gameObject.transform.position;
            StartCoroutine("Explode");
            health = 0;
            AudioController.Instance.PlayRoombaExplosionSounds();
            catPowerEnabled = false;
            gameObject.SetActive(false);
            CameraMovement.CameraShake();

        }
    }
    IEnumerator Explode()
    {
        Instantiate(explosionPart, explodeLocation, Quaternion.identity);
        yield break;
    }
}

