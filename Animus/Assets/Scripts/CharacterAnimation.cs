using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] float respawnTime = 1f;
    Animator animator;
    private IMove mover;
    CharacterGrounding characterGrounding;
    PlayerMovementController playerMovement;
    Rigidbody2D rb2d;
    bool dead = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<IMove>();
        characterGrounding = GetComponent<CharacterGrounding>();
        playerMovement = GetComponent<PlayerMovementController>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float speed = mover.Speed;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        animator.SetBool("Grounded", characterGrounding.IsGrounded);
        if (speed != 0)
        {
            if(speed > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }


    public void Death()
    {
        if (dead)
            return;
        AudioManager.Instance.PlaySoundEffect("Death");
        dead = true;
        animator.SetBool("Dead", true);
        rb2d.simulated = false;
        playerMovement.enabled = false;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        dead = false;
        rb2d.simulated = true;
        animator.SetBool("Dead", false);
        playerMovement.enabled = true;
        GameManager.Instance.KillPlayer();
    }

    public void PlayStep()
    {
        AudioManager.Instance.PlaySoundEffect("Step");
    }
}
