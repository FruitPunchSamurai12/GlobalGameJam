using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UILives : MonoBehaviour
{
    public Image[] soulImages = new Image[3];


    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
        for (int i = 0; i < soulImages.Length; i++)
        {
            if (GameManager.Instance.Lives <= i)
            {
                soulImages[i].enabled = false;
            }
        }
    }

    private void HandleOnLivesChanged(int livesRemaining)
    {
        for (int i = 0; i < soulImages.Length; i++)
        {
            if(livesRemaining<=i)
            {
                soulImages[i].enabled = false;
            }
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= HandleOnLivesChanged;
    }
}
