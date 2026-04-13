using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public GameObject optionsMenu;
   public GameObject mainMenu;

   public void OpenOptionsPanel()
   {
      mainMenu.SetActive(false);
      optionsMenu.SetActive(true);
   }
    public void OpenMainMenuPanel()
   {
      mainMenu.SetActive(true);
      optionsMenu.SetActive(false);
   }
   public void QuitGame()
   {
      Debug.Log("Saliendo del juego"); // Mensaje de depuración ya que aun no se puede cerrar en Unity
      Application.Quit();
   }

   public void PlayGame()
   {
      SceneManager.LoadScene("Nivel_1"); //Carga la primera escena
   }

}
