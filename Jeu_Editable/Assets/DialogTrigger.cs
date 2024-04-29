using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject dialogBox; // Référence à la boîte de dialogue à afficher
    private bool inRange = false; // Pour suivre si le joueur est en contact avec le GameObject

    void Start()
    {
        // Optionnel: Désactivez le Canvas au début si pas déjà fait dans l'éditeur
        dialogBox.SetActive(false);
    }

    void Update()
        {
            // Vérifier si le joueur est en contact et s'il appuie sur la touche "E"
            if (inRange && Input.GetKeyDown(KeyCode.E))
            {
                // Afficher la boîte de dialogue
                dialogBox.SetActive(true);
                Time.timeScale = 0f;
            }
        }

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
}
