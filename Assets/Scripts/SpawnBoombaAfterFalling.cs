using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoombaAfterFalling : MonoBehaviour {

    public float spawnTime = 1;
    public GameObject[] players;
    private GameObject currentSpawn;
    private Vector3 lastPos = new Vector3(50, 50, 50);
    private Vector3 thirdPos = new Vector3(50, 50, 50);


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
                StartCoroutine("Spawn");
            }
        }
	}


    IEnumerator Spawn() {
    yield return new WaitForSeconds(spawnTime);
        foreach (GameObject player in players) {
            if (player.activeSelf == false) {
                player.SetActive(true);
                player.transform.eulerAngles = new Vector3(0,0,0);
                Vector3 newPos = Random.insideUnitCircle * 15;
                while (Vector3.Distance(newPos, lastPos) <= 20 || Vector3.Distance(newPos, thirdPos) <= 20) {
                    newPos = Random.insideUnitCircle * 15;
                }
                newPos.z = newPos.y + transform.position.z;
                newPos.y = 5;
                player.transform.position = newPos;
                thirdPos = lastPos;
                lastPos = newPos;
    }
        }
    }
}
