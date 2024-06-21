using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mdp_crypto_1 : MonoBehaviour
{
    public InputField[] digitFields; // Les champs pour les 4 chiffres
    public string correctPassword = "7643"; // Le mot de passe correct
    private int currentFieldIndex = 0;
    public string SceneName;
    void Start()
    {
        // Ajouter des listeners à chaque InputField pour détecter les changements
        for (int i = 0; i < digitFields.Length; i++)
        {
            int index = i; // Capture de l'index dans une variable locale pour éviter les problèmes de fermeture
            digitFields[i].onValueChanged.AddListener(delegate { OnInputValueChanged(index); });
        }
        digitFields[0].Select();
    }

    void Update()
    {
        // Vérifiez si la touche Enter est pressée
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ValidatePassword();
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            HandleBackspace();
        }
    }

    void OnInputValueChanged(int index)
    {
        // Si l'InputField actuel contient un caractère, passer au suivant
        if (digitFields[index].text.Length > 0)
        {
            if (index < digitFields.Length - 1)
            {
                currentFieldIndex = index + 1;
                digitFields[currentFieldIndex].Select(); // Sélectionner le champ suivant
            }
            else
            {
                digitFields[index].DeactivateInputField(); // Désélectionner le dernier champ
            }
        }
    }

    void HandleBackspace()
    {
        if (currentFieldIndex >= 0)
        {
            if (digitFields[currentFieldIndex].text.Length > 0)
            {
                digitFields[currentFieldIndex].text = ""; // Effacer le contenu du champ actuel
            }
            else
            {
                if (currentFieldIndex > 0)
                {
                    currentFieldIndex--;
                    digitFields[currentFieldIndex].Select(); // Sélectionner le champ précédent
                    digitFields[currentFieldIndex].text = ""; // Effacer le contenu du champ précédent
                }
            }
            if(digitFields[currentFieldIndex].text.Length == 0)
            {
                digitFields[currentFieldIndex].ActivateInputField();
            }
        }
    }

    public void ValidatePassword()
    {
        string enteredPassword = "";

        // Concaténer les chiffres entrés
        foreach (InputField field in digitFields)
        {
            enteredPassword += field.text;
        }

        // Vérifier si le mot de passe est correct
        if (enteredPassword == correctPassword)
        {
            // Charger la scène suivante après une courte pause pour afficher le feedback
            Invoke("LoadNextScene", 1f);
        }
        
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneName); 
    }


}

