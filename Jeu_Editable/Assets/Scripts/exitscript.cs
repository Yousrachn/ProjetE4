using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class exitscript : MonoBehaviour
{
    public GameObject exitPanel;
    // Start is called before the first frame update
    void Start()
    {
        exitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Exit()
    {
        exitPanel.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(ChangeScene());
    }

    public void Close()
    {
        exitPanel.SetActive(false); // D�sactive le Canvas
        Time.timeScale = 1f; // Remet le temps � la normale pour reprendre le jeu
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2); // Attendre 2 secondes
        SceneManager.LoadScene("SampleScene 1"); // Changez "NomDeLaNouvelleScene" par le nom de votre sc�ne
    }
}
