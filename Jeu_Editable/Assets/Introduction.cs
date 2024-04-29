using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public string SceneToLoad;

    void Start()
    {
        // Activer la boîte de dialogue au début de la scène
        dialogueBox.SetActive(true);
    }

    void Update()
    {
        // Vérifier si la boîte de dialogue est active et si le joueur appuie sur une touche pour passer au dialogue suivant
        if (!dialogueBox)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
