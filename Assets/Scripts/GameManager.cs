using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int frutas = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // MEJORA NO SE DESTRUYE AL CAMBIAR ESCENA como antes que se destruía y se perdía el conteo de frutas
        }
        else
        {
            Destroy(gameObject);
        }
    }
}