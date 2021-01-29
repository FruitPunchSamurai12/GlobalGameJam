using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILives : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
        text.SetText(GameManager.Instance.Lives.ToString());
    }

    private void HandleOnLivesChanged(int livesRemaining)
    {
        text.SetText(GameManager.Instance.Lives.ToString());
    }
}
