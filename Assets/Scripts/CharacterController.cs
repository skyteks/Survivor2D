using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;

    private Vector2 input;
    private Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer sprite;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rigid.velocity = input * Time.deltaTime * 100f * movementSpeed;
    }

    void Update()
    {
        if (anim != null)
        {
            anim.SetFloat("movement", rigid.velocity.magnitude);
        }
        if (sprite != null)
        {
            if (input.x > 0f)
            {
                sprite.flipX = true;
            }
            if (input.x < 0f)
            {
                sprite.flipX = false;
            }
        }
    }

    public void Move(Vector2 newInput)
    {
        input = newInput;
    }
}
