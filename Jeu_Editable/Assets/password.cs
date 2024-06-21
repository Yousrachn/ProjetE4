using UnityEngine;
public class password : MonoBehaviour
{
    public GameObject passwordPanel; // Assurez-vous d'assigner le Canvas dans l'inspecteur
    private bool isPlayerNear = false; // Pour suivre si le joueur est pr�s du GameObject sp�cifique
    public GameObject interactionText;

    void Start()
    {
        // Optionnel: D�sactivez le Canvas au d�but si pas d�j� fait dans l'�diteur
        passwordPanel.SetActive(false);
    }

    void Update()
    {
        // V�rifiez si le joueur est pr�s et appuie sur "H"
        if (isPlayerNear)
        {
            interactionText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
         
            {
            passwordPanel.SetActive(true);
            Time.timeScale = 0f;
            }
        }
        else
        {
            interactionText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) // Assurez-vous que le joueur a le tag "Player"
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
            passwordPanel.SetActive(false);
        }
    }

    public void CloseCanvasAndResumeGame()
    {
        passwordPanel.SetActive(false); // D�sactive le Canvas
        Time.timeScale = 1f; // Remet le temps � la normale pour reprendre le jeu
    }

}