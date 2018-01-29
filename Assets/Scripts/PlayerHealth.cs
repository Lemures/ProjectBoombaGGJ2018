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
    public GameObject BoombaMeshObject;
    private Vector3 explodeLocation;
    private Rigidbody _rigidBody;
    public float spawnTime = 1;
    private float spawnSize = 4.0f;
    private Vector3 lastPos = new Vector3(50, 50, 50);
    private bool _isSpawning;

    protected void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

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
        if (collision.collider.gameObject.layer == 8 && !_isSpawning)
        {
            explodeLocation = gameObject.transform.position;
            StartCoroutine("Explode");
            health = 0;
            AudioController.Instance.PlayRoombaExplosionSounds();
            catPowerEnabled = false;
            HandleSpawn();
            CameraMovement.CameraShake();
        }
    }

    private void HandleSpawn()
    {
        _isSpawning = true;
        BoombaMeshObject.SetActive(false);
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
        StartCoroutine("Spawn", gameObject);
    }

    private IEnumerator Explode()
    {
        Instantiate(explosionPart, explodeLocation, Quaternion.identity);
        yield break;
    }

    private IEnumerator Spawn(GameObject player)
    {
        yield return new WaitForSeconds(spawnTime);
        player.GetComponent<PlayerHealth>().BoombaMeshObject.SetActive(true);
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        Vector3 newPos = Random.insideUnitCircle * spawnSize;
        //        while (Vector3.Distance(newPos, lastPos) <= .1)
        //        {
        //            newPos = Random.insideUnitCircle * spawnSize;
        //        }
        newPos.z = newPos.y + 0;
        newPos.y = 1;
        player.transform.position = newPos;
        lastPos = newPos;
        _isSpawning = false;
    }
}

