using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PNJInteraction : MonoBehaviour
{
     
    public TextMeshProUGUI dialogueText; // Référence au TextMeshPro où le dialogue sera affiché
    public string[] dialogues; // Tableau des dialogues du PNJ
    private int currentDialogueIndex = 0;
    private bool isPlayerInRange = false;

    void Start()
    {
        // Assurez-vous que le TextMeshPro est référencé correctement
        if (dialogueText == null)
        {
            Debug.LogError("Référence manquante au TextMeshPro pour le dialogue.");
            enabled = false; // Désactive le script si le TextMeshPro n'est pas configuré correctement
        }
        dialogueText.text = ""; // Assurez-vous que le texte de dialogue est vide au démarrage
    }

    void Update()
    {
        // Vérifiez si la touche E est pressée et si le joueur est à portée
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CopyDialogueToClipboard();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifiez si le joueur est entré dans la zone de collision
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Vérifiez si le joueur est sorti de la zone de collision
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            EndDialogue();
        }
    }

    // Méthode pour démarrer et afficher le dialogue
    public void StartDialogue()
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

    // Méthode pour mettre fin au dialogue
    public void EndDialogue()
    {
        dialogueText.text = ""; // Efface le texte du dialogue
        currentDialogueIndex = 0; // Réinitialise l'index du dialogue
    }

    public void CopyDialogueToClipboard()
    {
        GUIUtility.systemCopyBuffer = dialogueText.text;
        Debug.Log("Texte copié : "+ dialogueText.text);
    }

}
