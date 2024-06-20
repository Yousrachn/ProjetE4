using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PNJInteraction : MonoBehaviour
{
     
    public TextMeshProUGUI dialogueText; // Référence au TextMeshPro où le dialogue sera affiché
    public string[] dialogues; // Tableau des dialogues du PNJ
    private int currentDialogueIndex = 0;
    private bool isPlayerInRange = false;
    private bool isDialogueActive = false;
    public Image dialogueBackground;
    public GameObject interactionText;
    void Start()
    {
        // Assurez-vous que le TextMeshPro est référencé correctement
        if (dialogueText == null)
        {
            Debug.LogError("Référence manquante au TextMeshPro pour le dialogue." + gameObject.name);
            enabled = false; // Désactive le script si le TextMeshPro n'est pas configuré correctement
        }
        dialogueText.text = ""; // Assurez-vous que le texte de dialogue est vide au démarrage
        dialogueBackground.gameObject.SetActive(false);
    }

    void Update()
    {
        // Vérifiez si la touche E est pressée et si le joueur est à portée
        if (isPlayerInRange)
         
        {   
            interactionText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if( !isDialogueActive)
                {
                    StartDialogue();
                }
                else 
                {
                DisplayNextDialogue();
                }
            }
        }

        if (!isPlayerInRange)
        {
            interactionText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CopyDialogueToClipboard();
        }
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextDialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifiez si le joueur est entré dans la zone de collision
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player entered range of " + gameObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Vérifiez si le joueur est sorti de la zone de collision
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            EndDialogue();
            Debug.Log("Player exited range of " + gameObject.name);

        }
    }

    // Méthode pour démarrer et afficher le dialogue
    public void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
            currentDialogueIndex++;
        }
        else
        {
            EndDialogue(); // Fin du dialogue lorsque tous les dialogues sont affichés
        }
    }

    public void StartDialogue()
        {
            isDialogueActive = true;
            currentDialogueIndex = 0;
            dialogueBackground.gameObject.SetActive(true);
            DisplayNextDialogue();
            Debug.Log("Dialogue started with" + gameObject.name);

        }
    

    // Méthode pour mettre fin au dialogue
    public void EndDialogue()
    {
        dialogueText.text = ""; // Efface le texte du dialogue
        dialogueBackground.gameObject.SetActive(false);
        isDialogueActive = false;
        Debug.Log("Dialogue ended with " + gameObject.name);

    }

    public void CopyDialogueToClipboard()
    {
        GUIUtility.systemCopyBuffer = dialogueText.text;
        Debug.Log("Texte copié : "+ dialogueText.text);
    }

}
