
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractionTerminal : MonoBehaviour
{
    public float interactionDistance = 3f;
    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.E))
        {
            LoadTerminalScene();
        }
    }


    void LoadTerminalScene()
    {
        SceneManager.LoadScene("TerminalCrypto");
    }
}



