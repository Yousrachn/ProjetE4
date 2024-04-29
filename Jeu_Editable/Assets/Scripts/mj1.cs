using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mj1 : MonoBehaviour
{

    public float timeRemaining = 30f;
    public int score = 0;
    public Text timeText;
    public Text scoreText;
    public string sceneToLoad1;
    public string sceneToLoad2;

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.Round(timeRemaining).ToString();

        if (timeRemaining <= 0f)
        {
            EndGameLoose();
        }

    }

    void EndGameLoose()
    {
        // Afficher le score final ou effectuer d'autres actions de fin de jeu
        SceneManager.LoadScene(sceneToLoad1);
    }

    void EndGameWin()
    {
        SceneManager.LoadScene(sceneToLoad2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Coin"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            if (score >= 10) // Vérifie si le joueur a collecté toutes les pièces
            {
                EndGameWin();
            }
            Destroy(other.gameObject); // Détruit la pièce lorsque le joueur la touche
            Debug.Log("Coin touched by player!");
        }
    }
}