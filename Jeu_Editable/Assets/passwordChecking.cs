using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class passwordChecking : MonoBehaviour
{
    public GameObject passwordPanel;
    public TMP_InputField passwordInput;
    public string correctPassword; // Le mot de passe à vérifier
    public Button enterButton;

    void Start()
    {
        // Assurez-vous que le bouton "Enter" est lié à la fonction CheckPassword
        enterButton.onClick.AddListener(CheckPassword);
    }

    public void CheckPassword()
    {
        if (passwordInput.text == correctPassword)
        {
            StartCoroutine(ChangeScene());
        }
        else
        {
            // Code incorrect
            passwordInput.image.color = Color.red;
            StartCoroutine(ClearInputField());
        }
    }



    IEnumerator ChangeScene()
    {
        passwordInput.image.color = Color.green;
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1); // Attendre 2 secondes
        passwordPanel.SetActive(false);
        Application.Quit();
    }

    IEnumerator ClearInputField()
    {
        yield return new WaitForSeconds(1); // Attendre 2 secondes
        passwordInput.text = ""; // Efface le texte
        passwordInput.image.color = Color.white; // Remet la couleur par défaut
    }
}