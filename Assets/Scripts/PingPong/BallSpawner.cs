using Fusion;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject ballPrefab;
    // Start is called before the first frame update

    public void SpawnBall()
    {
        if (Runner.ActivePlayers.Count() == 2)
        {
            Runner.Spawn(ballPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    public void PlayerJoined(PlayerRef player)
    {
        SpawnBall();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}