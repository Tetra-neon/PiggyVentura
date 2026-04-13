using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carga la siguiente escena en el orden de construcción
    }
    public void Salir()
    {
        Debug.Log("Saliendo del juego"); // Mensaje de depuración para confirmar que se ha llamado a la función
        Application.Quit(); // Cierra la aplicación
    }
    
}
