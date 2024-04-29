using UnityEngine;
using UnityEngine.SceneManagement;

public class Buzer : MonoBehaviour
{
    // Nom de la scène à charger
    public string sceneToLoad;

    // Fonction de détection de collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision détectée");
        // Vérifier si le joueur entre en collision avec la porte
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Charger la nouvelle scène
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
