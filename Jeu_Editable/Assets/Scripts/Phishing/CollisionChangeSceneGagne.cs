using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionChangeSceneGagne : MonoBehaviour


{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifiez si l'objet a bien touché l'objet cible
        if (other.gameObject.CompareTag("Target"))
        {
            // Changez de scène
            SceneManager.LoadScene("fin_ph");
        }
    }
}
