using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEventManager : MonoBehaviour {

    public GameObject[] players;
    public Text[] playerScore;

    void Update() {
        foreach (GameObject player in players) {
            var playerHealth = player.GetComponent<PlayerHealth>();
            var playerController = player.GetComponent<PlayerController>();
            if(playerHealth.health >= 100) {
                if (playerHealth.catPowerEnabled == false){
                    Reset();
                    playerHealth.catPowerEnabled = true;
                    AudioController.Instance.PlayCatTransferSounds();
                }
            }
            playerScore[playerController.PlayerId-1].text = Mathf.Floor(playerHealth.catScore).ToString();
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
