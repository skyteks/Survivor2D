using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private int possibleHits;
    private int currentHits;

    void OnEnable()
    {
        currentHits = 0;
    }

    public void Setup(int newDamage, int newPossibleHits)
    {
        damage = newDamage;
        possibleHits = newPossibleHits;
        currentHits = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy;
        if (collision.transform.TryGetComponent<EnemyHealth>(out enemy))
        {
            enemy.TakeDamage(damage);
            currentHits++;
        }

        if (currentHits >= possibleHits)
        {
            Destroy(gameObject);
        }
    }
}
