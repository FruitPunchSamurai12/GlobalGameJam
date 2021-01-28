using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] Transform sensor;
    float direction = -1;
    public float moveSpeed = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(direction* moveSpeed, rb2d.velocity.y);
        ScanSenson();
    }

    private void ScanSenson()
    {
        //scan for gap
        var result = Physics2D.Raycast(sensor.position, Vector2.down, 0.1f);
        if (result.collider == null)
        {
            TurnAround();
        }
        //scan for wall
        var sideResult = Physics2D.Raycast(sensor.position, new Vector2(direction, 0), 0.1f);
        if (sideResult.collider != null)
        {
            if (!sideResult.collider.CompareTag("Player"))
            {
                TurnAround();
            }
        }
    }

    private void TurnAround()
    {
        direction *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
    }
}
