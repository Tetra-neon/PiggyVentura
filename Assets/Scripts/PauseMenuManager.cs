using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu; // Variable para el menú de pausa
    public GameObject pauseButton; // Variable para el botón de pausa
    void Update() 
{
    if (Input.GetKeyDown(KeyCode.Escape)) // Detecta si se presiona la tecla "Escape"
    {
        if (Time.timeScale == 1)
            PauseGame();
        else
            ResumeGame();
    }
}
    public void PauseGame()
    {
        Time.timeScale = 0; // Detiene el tiempo del juego
        pauseButton.SetActive(false); // Oculta el botón de pausa
        pauseMenu.SetActive(true); // Muestra el menú de pausa
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Reanuda el tiempo del juego
        pauseButton.SetActive(true); // Muestra el botón de pausa
        pauseMenu.SetActive(false); // Oculta el menú de pausa
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual para reiniciar el juego
        Time.timeScale = 1; // Asegura que el tiempo del juego esté en marcha
    }

    public void QuitGame()
    {
        Debug.Log("Close Game"); // Mensaje de depuración para confirmar que se ha llamado a la función
        Application.Quit(); // Cierra la aplicación
    }
}

