using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int Lives { get; private set; }

    public static GameManager Instance;

    public event Action<int> OnLivesChanged;

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
        Lives--;
        OnLivesChanged?.Invoke(Lives);
        if (Lives <= 0)
        {
            RestartGame();
        }
        else
        {
            SendPlayerToCheckpoint();
        }
    }

    private void SendPlayerToCheckpoint()
    {
        var checkpointManager = FindObjectOfType<CheckpointManager>();
        var checkpoint = checkpointManager.GetLastCheckpointThatWasPassed();
        var player = FindObjectOfType<PlayerMovementController>();
        player.transform.position = checkpoint.transform.position;
    }



    private void RestartGame()
    {
        Lives = 3;
        SceneManager.LoadScene(0);
    }
}
