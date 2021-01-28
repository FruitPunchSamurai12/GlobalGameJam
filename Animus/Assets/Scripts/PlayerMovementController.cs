using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour,IMove
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 1000f;
    Rigidbody2D rb2d;
    CharacterGrounding characterGrounding;

    public float Speed { get; private set; }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();
        
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && characterGrounding.IsGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Speed = horizontal;//this is for the animation

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement* moveSpeed * Time.deltaTime;

        
    }
}
