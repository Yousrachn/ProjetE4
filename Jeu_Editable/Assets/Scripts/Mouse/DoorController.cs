using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorController : MonoBehaviour
{
    // Nom de la scène à charger
    public string sceneToLoad;
    public GameObject dialogBox; // Référence à la boîte de dialogue à afficher

    void Start()
    {
        // Optionnel: Désactivez le Canvas au début si pas déjà fait dans l'éditeur
        dialogBox.SetActive(false);
    }

    // Fonction de détection de collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifier si le joueur entre en collision avec la porte
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(DialogueCoroutine());
        }
    }

    IEnumerator DialogueCoroutine()
    {
        dialogBox.SetActive(true);
        Time.timeScale = 0f;

        // Attendre que la boîte de dialogue soit entièrement lue avant de changer de scène
        while (dialogBox.activeSelf)
        {
            yield return null;
        }

        // Une fois que la boîte de dialogue est désactivée, charger la nouvelle scène
        SceneManager.LoadScene(sceneToLoad);
    }
}
