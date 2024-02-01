using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void SubscribeEvents()
    {
        GameManager.I.OnScoreAdd += UpdateScoreUI;
    }

    private void UnSubscribeEvents()
    {
        GameManager.I.OnScoreAdd -= UpdateScoreUI;
    }

    private void UpdateScoreUI(int _newScore)
    {
        m_scoreText.text = _newScore.ToString();
    }

}
