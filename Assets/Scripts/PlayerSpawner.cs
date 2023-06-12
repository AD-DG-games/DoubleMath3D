using Cinemachine;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public GameObject GameManagerPrefab;

    public int maxHowManyPlayers;
    private int howManyPlayers = 0;
    public void PlayerJoined(PlayerRef player)
    {
        howManyPlayers++;
        Debug.Log(howManyPlayers);
        if (player == Runner.LocalPlayer)
        {
            int i = (new System.Random()).Next(1, 9 + 1);
            string name = "Floor (" + i + ")";
            Vector3 pos = GameObject.Find(name).transform.position;
            Runner.Spawn(PlayerPrefab, pos, Quaternion.identity);
        }
        if (howManyPlayers == maxHowManyPlayers)
        {
            Runner.SetActiveScene("Game");


        }
    }
}
