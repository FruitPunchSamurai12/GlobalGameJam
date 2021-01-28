using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    private IMove mover;
    SpriteRenderer sr;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<IMove>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        float speed = mover.Speed;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        if (speed != 0)
        {
            sr.flipX = speed > 0;
        }
    }
}
