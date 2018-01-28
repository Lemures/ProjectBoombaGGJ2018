using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoombaAfterFalling : MonoBehaviour {

    public float spawnTime = 1;
    public GameObject[] players;
    private GameObject currentSpawn;
    private Vector3 lastPos = new Vector3(50, 50, 50);
    public float spawnSize = 10;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject player in players) {
            if (player.activeSelf == false) {
                var rb = player.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                StartCoroutine("Spawn", player);
            }
        }
	}


    IEnumerator Spawn(GameObject player) {
    yield return new WaitForSeconds(spawnTime);
            if (player.activeSelf == false) {
                player.SetActive(true);
                player.transform.eulerAngles = new Vector3(0,0,0);
                Vector3 newPos = Random.insideUnitCircle * spawnSize;
                while (Vector3.Distance(newPos, lastPos) <= .1) {
                    newPos = Random.insideUnitCircle * spawnSize;
                }
                newPos.z = newPos.y + transform.position.z;
                newPos.y = 1;
                player.transform.position = newPos;
                lastPos = newPos;
        }
    }
}
