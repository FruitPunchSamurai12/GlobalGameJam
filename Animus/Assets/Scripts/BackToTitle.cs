using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToTitle : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.StopBGMusic();
    }

    public void ToTitle()
    {
        GameManager.Instance.RestartGame();
    }
}
