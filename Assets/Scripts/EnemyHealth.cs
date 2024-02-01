using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private int m_scoreValue;
    protected override void Die()
    {
        GameManager.I.AddScore(m_scoreValue);
        base.Die();
    }
}
