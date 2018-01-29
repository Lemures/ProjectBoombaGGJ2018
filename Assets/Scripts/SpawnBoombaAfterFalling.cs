using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoombaAfterFalling : MonoBehaviour
{
    public float spawnTime = 1;
    public float spawnSize = 10;
    private Vector3 lastPos = new Vector3(50, 50, 50);
    public PlayerHealth[] players;
    private GameObject currentSpawn;

    void Update()
    {

    }
}
