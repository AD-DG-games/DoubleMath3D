using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseAndWin : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;
    [SerializeField] string EndScenes;
    [SerializeField] Color loseColor;
    [SerializeField] Color WinColor;

    private bool isTheGameStrat = false;
    public void FixedUpdate()
    {
        int whoManyPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        if (whoManyPlayers > 1)
        {
            isTheGameStrat = true;
        }
        
        if (whoManyPlayers == 1 && isTheGameStrat)
        {
            Debug.Log("You Win!");
            SceneManager.LoadScene(EndScenes);
            Camera cam = GameObject.Find("Camera").GetComponent<Camera>();
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = WinColor;

            Destroy(gameObject);
            Destroy(GameObject.Find("Music"));
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == triggeringTag && enabled)
        {

            Debug.Log("Game over!");
            SceneManager.LoadScene(EndScenes);
            GameObject.Find("Camera").GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
            Camera cam = GameObject.Find("Camera").GetComponent<Camera>();
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = loseColor;
            isTheGameStrat = false;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                if (player != gameObject)
                {
                    Destroy(player);
                }  
            }
            Destroy(gameObject);
            Destroy(GameObject.Find("Music"));
            
            // UnityEditor.EditorApplication.isPlaying = false;  # Error on editor 2021.3
        }
    }

}
