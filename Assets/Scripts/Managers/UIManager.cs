using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider Healthbar;
    public TextMeshProUGUI enemyAmountText;
    public GameObject topHUD, pauseMenu, optionsMenu, powerUpIndicator;
    public Animator HealthIconIndicator;
    public bool IsMainMenu;

    private void Start()
    {
        if (!IsMainMenu)
        {
            GameManager.GM.enemyManager.OnEnemySlain.AddListener(() =>
            {
                int currentEnemyAmount = GameManager.GM.enemyManager.GetEnemyCountInWorld();
                enemyAmountText.text = $"{currentEnemyAmount}";
            });
        }
    }

    public void OnPlayerHealthChanged()
    {
        Healthbar.maxValue = GameManager.GM.playerManager.GetPlayerController().maxHealth;
        Healthbar.value = GameManager.GM.playerManager.GetPlayerController().currentHealth;
    }

    public void ShowOrHidePauseMenu()
    {
        pauseMenu.SetActive(GameManager.GM.isGamePaused);
    }

    public void ResumeButtonClick()
    {
        GameManager.GM.OnPauseRequested();
    }
    
    public void QuitButtonClick()
    {
        GameManager.ExitGame();
    }
    
    public void OptionsButtonClick()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ShowLowHealthIndicator()
    {
        HealthIconIndicator.SetBool("LowHealth", true);
    }

    public void ShowOrHideTopHud(bool show)
    {
        topHUD.SetActive(show);
    }
    
    public void CloseOptionsButtonClick()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ShowPowerUpIndicator()
    {
        powerUpIndicator.SetActive(true);
    }
}
