using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private Rigidbody m_enemyRB;
    private PlayerController m_playerControllerCS;
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        m_playerControllerCS = GameManager.I.GetPlayerControllerCS();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = (m_playerControllerCS.transform.position - transform.position).normalized;
        m_enemyRB.velocity = moveDirection * m_moveSpeed;
    }
}
