using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_bulletSpeed;
    [SerializeField] private int m_bulletDamage;
    [SerializeField] private Rigidbody m_bulletRB;

    private void Start()
    {
        LaunchBullet();
    }

    private void LaunchBullet()
    {
        m_bulletRB.velocity = transform.forward * m_bulletSpeed;
    }

    private void OnTriggerEnter(Collider _collider)
    {
        HandleCollision(_collider);
    }

    private void HandleCollision(Collider _collider)
    {
        if(_collider.TryGetComponent(out Health health))
        {
            health.Damage(m_bulletDamage);
        }
        Destroy(gameObject);
    }
}
