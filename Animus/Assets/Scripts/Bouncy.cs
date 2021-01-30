using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    [SerializeField] float bounceVelocity = 10f;
    public bool activated = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!activated)
            return;
        if(collision.collider.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySoundEffect("Jump");
            var rb2d = collision.collider.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, bounceVelocity);
            }
        }
    }
}
