using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform m_shootLocationTF;
    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private float m_shootFrequencyInSeconds;
    private float m_shootTimer;

    private void Update()
    {
        HandleShoot();
        CountShootTimer();
    }

    private void CountShootTimer()
    {
        m_shootTimer -= Time.deltaTime;
    }

    private void ResetShootTimer()
    {
        m_shootTimer = m_shootFrequencyInSeconds;
    }

    private bool CanShoot()
    {
        return m_shootTimer <= 0;
    }

    private void HandleShoot()
    {
        if(!Input.GetKey(KeyCode.Mouse0) || !CanShoot()) return;
        Shoot();
    }

    private void Shoot()
    {
        ResetShootTimer();
        Instantiate(m_bulletPrefab, m_shootLocationTF.position, m_shootLocationTF.rotation);
    }
}
