using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }
    public event Action<int> OnScoreAdd;
    private int m_score;
    private PlayerController m_playerControllerCS;

    private void Awake()
    {
        Initialize();
        SingletonSetup();
    }

    private void Initialize()
    {
        m_playerControllerCS = FindObjectOfType<PlayerController>();
    }

    private void SingletonSetup()
    {
        if(I == null)
        {
            I = this;
        }
        else if(I != null && I != this)
        {
            Destroy(this);
        }
    }

    public void AddScore(int _score)
    {
        m_score += _score;
        OnScoreAdd?.Invoke(m_score);
    }

    public PlayerController GetPlayerControllerCS()
    {
        return m_playerControllerCS;
    }
}
