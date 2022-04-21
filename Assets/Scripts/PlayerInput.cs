using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private Vector2 input;
    private PlayerController controller;

    void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
        if (!(Mathf.Abs(input.x) > 0.1f || Mathf.Abs(input.y) > 0.1f))
        {
            input = Vector2.zero;
        }
        controller.Move(input);
    }
}
