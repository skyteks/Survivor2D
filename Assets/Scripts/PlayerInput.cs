using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private Vector2 input;
    private CharacterController controller;

    public Vector2 direction { get; private set; } = Vector2.up;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
        if (Mathf.Abs(input.x) > 0.01f || Mathf.Abs(input.y) > 0.01f)
        {
            direction = input.normalized;
        }
        else
        {
            input = Vector2.zero;
        }
        controller.Move(input);
    }
}
