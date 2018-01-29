using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEventManager : MonoBehaviour
{

    public GameObject[] players;
    public GameObject GameSceneHolder;
    public GameObject EndScreen;
    public Text[] playerScore;
    public float GameTime = 100.0f;
    private bool _isGameOver;

    // hacked bad code
    public GameObject PlayerOneEnd;
    public GameObject PlayerTwoEnd;
    public GameObject PlayerThreeEnd;
    public GameObject PlayerFourEnd;

    protected void Awake()
    {
        GameTime = 100.0f;
        EndScreen.SetActive(false);
    }

    protected void Update()
    {
        if (GameTime <= 0 && !_isGameOver)
        {
            GameTime = 0;
            EndGame();
            _isGameOver = true;
        }
        else if (!_isGameOver)
        {
            GameTime -= Time.deltaTime;
        }

        foreach (GameObject player in players)
        {
            var playerHealth = player.GetComponent<PlayerHealth>();
            var playerController = player.GetComponent<PlayerController>();
            if (playerHealth.health >= 100)
            {
                if (playerHealth.catPowerEnabled == false)
                {
                    Reset();
                    playerHealth.catPowerEnabled = true;
                    AudioController.Instance.PlayCatTransferSounds();
                }
            }
            playerScore[playerController.PlayerId - 1].text = Mathf.Floor(playerHealth.catScore).ToString();
        }
    }

    public void Reset()
    {
        foreach (GameObject player in players)
        {
            var playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.health = 0;
            playerHealth.catPowerEnabled = false;
        }
    }

    public void EndGame()
    {
        Debug.Log("GAME OVER!");

        EndScreen.SetActive(true);

        int topPlayer = 0;
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<PlayerHealth>().catScore > players[topPlayer].GetComponent<PlayerHealth>().catScore)
            {
                topPlayer = i;
            }
        }

        switch (topPlayer)
        {
            case 0:
                PlayerOneEnd.SetActive(true);
                break;
            case 1:
                PlayerTwoEnd.SetActive(true);
                break;
            case 2:
                PlayerThreeEnd.SetActive(true);
                break;
            case 3:
                PlayerFourEnd.SetActive(true);
                break;
        }

        GameSceneHolder.SetActive(false);
    }


}
