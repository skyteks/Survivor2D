using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 5f;

    private Rigidbody2D rigid;

    private Vector2 input;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        rigid.velocity = input * Time.deltaTime * 100f * movementSpeed;
    }

    public void Move(Vector2 newInput)
    {
        input = newInput;
    }
}
