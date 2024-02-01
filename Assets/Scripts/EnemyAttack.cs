using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int m_attackDamage;

    private void OnTriggerEnter(Collider _collider)
    {
        HandleCollision(_collider);
    }
    private void HandleCollision(Collider _collider)
    {
        if(_collider.TryGetComponent(out Health health) && _collider.CompareTag("Player"))
        {
            health.Damage(m_attackDamage);
            Destroy(gameObject);
        }
    }
}
