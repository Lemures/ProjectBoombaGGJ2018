using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEventManager : MonoBehaviour {

    public GameObject[] players;

    void Update() {
        if (Input.GetKey(KeyCode.F)) {
            Reset();
        }
    }

    public void Reset(){
        foreach (GameObject player in players) {
            var playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.health = 0;
            Debug.Log(playerHealth.health);
        }
    }
}
