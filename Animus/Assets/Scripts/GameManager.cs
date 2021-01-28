using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Lives { get; private set; }

    public static GameManager Instance;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;            
            DontDestroyOnLoad(gameObject);

            RestartGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public void KillPlayer()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
