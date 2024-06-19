using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputFieldNavigator : MonoBehaviour
{ public InputField[] digitFields; // Les champs pour les 4 chiffres

    void Start()
    {
        // Ajouter des listeners à chaque InputField pour détecter les changements
        for (int i = 0; i < digitFields.Length; i++)
        {
            int index = i; // Capture de l'index dans une variable locale pour éviter les problèmes de fermeture
            digitFields[i].onValueChanged.AddListener(delegate { OnInputValueChanged(index); });
        }
    }

    void OnInputValueChanged(int index)
    {
        // Si l'InputField actuel contient un caractère, passer au suivant
        if (digitFields[index].text.Length > 0)
        {
            if (index < digitFields.Length - 1)
            {
                digitFields[index + 1].Select(); // Sélectionner le champ suivant
            }
            else
            {
                digitFields[index].DeactivateInputField(); // Désélectionner le dernier champ
            }
        }
    }

}
