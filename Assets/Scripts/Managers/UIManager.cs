using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider Healthbar;
    [SerializeField] private TextMeshProUGUI enemyAmountText;

    private void Start()
    {
        GameManager.GM.enemyManager.OnEnemySlain.AddListener(() =>
        {
            int currentEnemyAmount = GameManager.GM.enemyManager.GetEnemyCountInWorld();
            enemyAmountText.text = $"Enemigos Restantes {currentEnemyAmount}/10";
        });
    }

    public void OnPlayerHealthChanged()
    {
        Healthbar.maxValue = GameManager.GM.playerManager.GetPlayerController().maxHealth;
        Healthbar.value = GameManager.GM.playerManager.GetPlayerController().currentHealth;
    }
}
