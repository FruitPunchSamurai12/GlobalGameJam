using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] string bgMusic;
    [SerializeField] string sceneName;
    [SerializeField] float delayTime = 1f;

    private void Start()
    {
        AudioManager.Instance.PlayBGMusic(bgMusic);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        AudioManager.Instance.PlaySoundEffect("Portal");

        StartCoroutine(LoadAfterDelay());

    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }
}
