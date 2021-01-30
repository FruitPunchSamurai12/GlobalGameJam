using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToAlly : MonoBehaviour,IHitable
{
    Enemy enemy;
    Bouncy bouncy;
    Rigidbody2D rb2d;
    Animator animator;
    [SerializeField]
    float timeChanged = 10f;
    bool goodGuy = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Evil", true);
        rb2d = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        bouncy = GetComponent<Bouncy>();
        bouncy.activated = false;

    }

    public void TakeHit()
    {
        if (!goodGuy)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            enemy.enabled = false;
            Destroy(GetComponent<KillOnTouch>());
            bouncy.activated = true;
            animator.SetBool("Evil", false);
            goodGuy = true;
            AudioManager.Instance.PlaySoundEffect("Enemy");
            StartCoroutine(RevertBackAfterSeconds());
        }
    }

    IEnumerator RevertBackAfterSeconds()
    {
        yield return new WaitForSeconds(timeChanged);
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        enemy.enabled = true;
        gameObject.AddComponent(typeof(KillOnTouch));
        bouncy.activated = false;
        animator.SetBool("Evil", true);
        goodGuy = false;
    }
}
