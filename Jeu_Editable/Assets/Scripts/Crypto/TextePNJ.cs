using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextePNJ : MonoBehaviour
{
     public TextMeshProUGUI dialogueText; // Référence au TextMeshPro où le dialogue sera affiché

    // Exemple de dialogue (peut être remplacé par une structure plus complexe)
    private string[] dialogues = {
        "Salut, aventurier!",
        "Bienvenue dans notre village.",
        "N'oublie pas de visiter la taverne pour te reposer."
    };

    private int currentDialogueIndex = 0;

    void Start()
    {
        // Assurez-vous que le TextMeshPro est référencé correctement
        if (dialogueText == null)
        {
            Debug.LogError("Référence manquante au TextMeshPro pour le dialogue.");
            enabled = false; // Désactive le script si le TextMeshPro n'est pas configuré correctement
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
        gameObject.SetActive(false); // Désactive le PNJ ou masque le dialogue
    }

}
