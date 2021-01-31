using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameOver += HandleGameOver;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver -= HandleGameOver;
    }

    void HandleGameOver()
    {
        gameOverPanel.SetActive(true);
        FindObjectOfType<PlayerMovementController>().gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        GameManager.Instance.RestartGame();
    }
}
