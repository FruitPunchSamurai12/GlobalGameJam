using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerAnimation = collision.collider.GetComponent<CharacterAnimation>();
        if (playerAnimation != null)
        {
            playerAnimation.Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerAnimation = collision.GetComponent<CharacterAnimation>();
        if (playerAnimation != null)
        {
            playerAnimation.Death();
        }
    }
}
