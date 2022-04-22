using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWand : Weapon
{
    [SerializeField]
    private float angle;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int possibleHits;

    [SerializeField]
    private GameObject projectilePrefab;

    private PlayerInput input;

    void Start()
    {
        input = PlayerHealth.playerInstance.GetComponent<PlayerInput>();
    }

    void OnDrawGizmosSelected()
    {
        Vector3 direction = input != null ? (Vector3)input.direction : Vector3.zero;
        if (direction.sqrMagnitude != 0f)
        {
            Color debugColor = Color.red;
            debugColor.a = 0.3f;
            UnityEditor.Handles.color = debugColor;
            UnityEditor.Handles.DrawSolidArc(transform.position, Vector3.forward, Quaternion.Euler(0f, 0f, angle * -0.5f) * direction, angle, 3f);
        }
    }

    protected override void Fire()
    {
        base.Fire();

        for (int i = 0; i < projectiles; i++)
        {
            Vector2 direction = Quaternion.Euler(0f, 0f, angle * (-0.5f + Random.value)) * input.direction;
            Debug.DrawRay(transform.position, direction, Color.yellow, cooldown * 0.9f);

            GameObject projectileInstance = GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileInstance.GetComponent<Projectile>().Setup(damage, possibleHits);
            projectileInstance.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed * 2f;
        }
    }
}
