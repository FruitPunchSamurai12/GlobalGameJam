using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToAlly : MonoBehaviour,IHitable
{
    Enemy enemy;
    Bouncy bouncy;
    SpriteRenderer sr;
    Rigidbody2D rb2d;
    [SerializeField]
    Sprite evilSprite;
    [SerializeField]
    Sprite goodSprite;
    [SerializeField]
    float timeChanged = 10f;
    bool goodGuy = false;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        bouncy = GetComponent<Bouncy>();
        bouncy.enabled = false;

    }

    public void TakeHit()
    {
        if (!goodGuy)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            enemy.enabled = false;
            Destroy(GetComponent<KillOnTouch>());
            bouncy.enabled = true;
            sr.sprite = goodSprite;
            goodGuy = true;
            StartCoroutine(RevertBackAfterSeconds());
        }
    }

    IEnumerator RevertBackAfterSeconds()
    {
        yield return new WaitForSeconds(timeChanged);
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        enemy.enabled = true;
        gameObject.AddComponent(typeof(KillOnTouch));
        bouncy.enabled = false;
        sr.sprite = evilSprite;
        goodGuy = false;
    }
}
