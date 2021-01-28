using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField]
    Transform leftFoot;
    [SerializeField]
    Transform rightFoot;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask layerMask;

    public bool IsGrounded { get; private set; }

    // Update is called once per frame
    void Update()
    {
        CheckFootForGrounding(leftFoot);
        if (!IsGrounded)
        {
            CheckFootForGrounding(rightFoot);
        }
    }

    private void CheckFootForGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
        if (raycastHit.collider != null)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
