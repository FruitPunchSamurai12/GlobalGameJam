using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float launchForce = 5f;
    int bouncesRemaining = 3;
    [SerializeField] float bounceForce = 8f;

    public float Direction { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(launchForce * Direction, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHitable hitable = collision.collider.GetComponent<IHitable>();
        if (hitable != null)
        {
            hitable.TakeHit();
            Destroy(gameObject);
            return;
        }
        bouncesRemaining--;
        if (bouncesRemaining < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            rb2d.velocity = new Vector2(launchForce * Direction, bounceForce);
        }
    }
}
