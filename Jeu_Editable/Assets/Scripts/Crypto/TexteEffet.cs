using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TexteEffet : MonoBehaviour
{
   
 
    public TMP_Text textComponent; // Assure-toi d'utiliser TextMeshPro pour une meilleure qualité de texte
    public float delay = 0.1f; // Délai entre chaque caractère


    private string fullText;


    void Start()
    {
        fullText = textComponent.text; // Stocke le texte complet
        textComponent.text = ""; // Vide le texte au début
        StartCoroutine(ShowText());
    }


    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            textComponent.text += fullText[i];
            yield return new WaitForSeconds(delay);
        }
    }
}


