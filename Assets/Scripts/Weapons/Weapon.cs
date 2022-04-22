using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected float cooldown;
    [SerializeField]
    protected int projectiles;
    [SerializeField]
    protected int damage;

    protected float lastFired;

    protected void Update()
    {
        if (Time.time - lastFired > cooldown)
        {
            Fire();
        }
    }

    protected virtual void Fire()
    {
        lastFired = Time.time;
    }
}
