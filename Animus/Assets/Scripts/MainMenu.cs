using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayBGMusic("Title");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleSceneLvl1");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void ChangeSFXVolume(float volume)
    {
        AudioManager.Instance.ChangeSFXVolume(volume);
    }

    public void ChangeBGVolume(float volume)
    {
        AudioManager.Instance.ChangeBGVolume(volume);
    }
}
