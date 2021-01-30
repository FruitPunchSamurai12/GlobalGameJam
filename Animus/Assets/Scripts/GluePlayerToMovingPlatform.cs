using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluePlayerToMovingPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y < 0)
        {
            collision.collider.transform.SetParent(transform);
            Debug.Log("collided");
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("leaving");
        collision.collider.transform.SetParent(null);
    }
}
