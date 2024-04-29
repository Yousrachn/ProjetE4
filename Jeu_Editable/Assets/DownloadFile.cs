using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class DownloadFile : MonoBehaviour
{
    public string fileURL; // URL du fichier à télécharger

    private bool inRange = false; // Pour suivre si le joueur est en contact avec le GameObject

    public string fileName;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifier si le joueur est en collision avec le GameObject
        if (other.CompareTag("Player"))
        {
            inRange = true; // Le joueur est en contact
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Vérifier si le joueur sort de la collision avec le GameObject
        if (other.CompareTag("Player"))
        {
            inRange = false; // Le joueur n'est plus en contact
        }
    }

    void Update()
    {
        // Vérifier si le joueur est en contact et s'il appuie sur la touche "E"
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            // Déclencher le téléchargement du fichier
            StartCoroutine(DownloadFileFromGitHub(fileURL));
        }
    }

    IEnumerator DownloadFileCoroutine()
    {
        // Créer une requête pour télécharger le fichier
        using (UnityWebRequest webRequest = UnityWebRequest.Get(fileURL))
        {
            // Attendre la fin du téléchargement
            yield return webRequest.SendWebRequest();

            // Vérifier s'il y a eu une erreur lors du téléchargement
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                // Sauvegarder le contenu du fichier dans un fichier local
                string filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "/Downloads/" + fileName;
                System.IO.File.WriteAllBytes(filePath, webRequest.downloadHandler.data);
                Debug.Log("Fichier téléchargé avec succès : " + filePath);
            }
            else
            {
                Debug.LogError("Erreur lors du téléchargement du fichier : " + webRequest.error);
            }
        }
    }

    IEnumerator DownloadFileFromGitHub(string fileURL)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(fileURL))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "/Downloads/" + fileName;
                System.IO.File.WriteAllBytes(filePath, webRequest.downloadHandler.data);
                Debug.Log("Fichier téléchargé avec succès : " + filePath);
            }
            else
            {
                Debug.LogError("Erreur lors du téléchargement du fichier : " + webRequest.error);
            }
        }
    }
    }
