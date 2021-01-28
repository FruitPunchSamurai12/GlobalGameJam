using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    private IMove mover;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<IMove>();
    }
    // Update is called once per frame
    void Update()
    {
        float speed = mover.Speed;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        if (speed != 0)
        {
            if(speed > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
