using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cargar la siguiente escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        Debug.Log("Algo entró al trigger");

    if (collision.gameObject.CompareTag("Player"))
    {
        Debug.Log("Es el jugador, cambiando escena...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    }

    
}
