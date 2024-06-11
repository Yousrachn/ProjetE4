using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mdp_ph_1 : MonoBehaviour
{
    public InputField passwordField;
    public Button submitButton;
    public string correctPassword = "votreMotDePasse";
    public string nextSceneName = "NomDeLaSceneSuivante";


    void Start()
    {
        submitButton.onClick.AddListener(CheckPassword);
    }


    void CheckPassword()
    {
        if (passwordField.text == correctPassword)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("Mot de passe incorrect. Réessayez.");
        }
    }
}

