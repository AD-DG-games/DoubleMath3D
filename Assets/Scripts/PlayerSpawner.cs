using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public GameObject GameManagerPrefab;
    public int maxHowManyPlayers;
    private int howManyPlayers;
    public void PlayerJoined(PlayerRef player)
    {
        howManyPlayers++;
        Debug.Log(howManyPlayers);
        Debug.Log(player == Runner.LocalPlayer);
        if (player == Runner.LocalPlayer)
        {
            int  i = (int)Random.Range(0, 9 + 1);
            string name = "Floor (" + i + ")";
            Vector3 pos = GameObject.Find(name).transform.position;
            Runner.Spawn(PlayerPrefab, pos, Quaternion.identity, player);
        }
        if (howManyPlayers == maxHowManyPlayers)
        {
            Runner.Spawn(GameManagerPrefab, Vector3.zero, Quaternion.identity, null);
        }
    }
}
