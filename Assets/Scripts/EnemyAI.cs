using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private PlayerHealth target;
    private Vector2 input;
    private bool touchingTarget;
    private float lastHitTime;

    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        target = PlayerHealth.playerInstance;
    }

    void Update()
    {
        input = Vector2.zero;
        if (touchingTarget)
        {
            if (Time.time - lastHitTime > 0.2f)
            {
                DamageEnemy();
            }
        }
        else
        {
            input = (target.transform.position - transform.position).normalized;
        }
        controller.Move(input);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>() == null)
        {
            return;
        }
        touchingTarget = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>() == null)
        {
            return;
        }
        touchingTarget = false;
    }

    private void DamageEnemy()
    {
        target.TakeDamage(damage);
        lastHitTime = Time.time;
    }
}
