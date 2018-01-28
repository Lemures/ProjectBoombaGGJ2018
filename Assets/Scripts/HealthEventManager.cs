using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEventManager : MonoBehaviour {

    public GameObject[] players;

    void Update() {
        foreach (GameObject player in players) {
            var playerHealth = player.GetComponent<PlayerHealth>();
            if(playerHealth.health >= 100) {
                if (playerHealth.catPowerEnabled == false){
                    Reset();
                    playerHealth.catPowerEnabled = true;
                }
            }
        }
    }

    public void Reset(){
        foreach (GameObject player in players) {
            var playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.health = 0;
            playerHealth.catPowerEnabled = false;
        }
    }
}
