using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int Lives { get; private set; }
    public int MemoryFragments { get; private set; }

    public static GameManager Instance;

    public event Action<int> OnLivesChanged;
    public event Action<int> OnMemoryFragmentsChanged;
    public event Action OnGameOver;

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
            OnGameOver?.Invoke();
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



    public void RestartGame()
    {
        Lives = 3;
        MemoryFragments = 0;
        SceneManager.LoadScene(0);
    }

    public void GotMemoryFragment()
    {
        MemoryFragments++;
        OnMemoryFragmentsChanged?.Invoke(MemoryFragments);
    }
}
