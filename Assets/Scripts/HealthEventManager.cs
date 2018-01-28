using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEventManager : MonoBehaviour {

    public GameObject[] players;
    public Text[] playerScore;
    public float GameTime = 100.0f;
    private bool _isGameOver;

    protected void Awake() {
        GameTime = 100.0f;
    }

    protected void Update() {
        if(GameTime <= 0 && !_isGameOver) 
        {
            GameTime = 0;
            EndGame();
            _isGameOver = true;
        }
        else if(!_isGameOver){
            GameTime -= Time.deltaTime;
        }

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

    public void EndGame() 
    {
        Debug.Log("GAME OVER!");
    }


}
