using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Stats : MonoBehaviour
{
    //Speed
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] TextMeshProUGUI speedUpgradeLevelText;
    [SerializeField] TextMeshProUGUI speedUpgradePriceText;
    float speedUpgradeLevel = 1;
    float speedUpgradePrice = 100;

    //Stamina
    [SerializeField] PlayerStamina playerStamina;
    [SerializeField] TextMeshProUGUI staminaUpgradeLevelText;
    [SerializeField] TextMeshProUGUI staminaUpgradePriceText;
    float staminaUpgradeLevel = 1;
    float staminaUpgradePrice = 100;


    //Income
    [SerializeField] PlayerMoney playerMoney;
    [SerializeField] TextMeshProUGUI incomeUpgradeLevelText;
    [SerializeField] TextMeshProUGUI incomeUpgradePriceText;
    float incomeUpgradeLevel = 1;
    float incomeUpgradePrice = 100;

    float currentMoney;

    private void Start()
    {
        GetStatsFromPlayerPrefs();
        UpdateStatStatus();
        currentMoney = GetCurrentMoney();
    }

    private float GetCurrentMoney()
    {
        return PlayerPrefs.GetFloat("Money", 0);
    }

    void GetStatsFromPlayerPrefs()
    {
        speedUpgradeLevel = PlayerPrefs.GetFloat("SpeedUpgradeLevel", speedUpgradeLevel);
        speedUpgradePrice = PlayerPrefs.GetFloat("SpeedUpgradePrice", speedUpgradePrice);

        staminaUpgradeLevel = PlayerPrefs.GetFloat("StaminaUpgradeLevel", staminaUpgradeLevel);
        staminaUpgradePrice = PlayerPrefs.GetFloat("StaminaUpgradePrice", staminaUpgradePrice);

        incomeUpgradeLevel = PlayerPrefs.GetFloat("IncomeUpgradeLevel", incomeUpgradeLevel);
        incomeUpgradePrice = PlayerPrefs.GetFloat("IncomeUpgradePrice", incomeUpgradePrice);
    }

    public void SpeedUpgrade()
    {
        if (currentMoney < speedUpgradePrice)
            return;

        speedUpgradeLevel++;
        speedUpgradePrice *= 1.1f;

        PlayerPrefs.SetFloat("SpeedUpgradeLevel", speedUpgradeLevel);
        PlayerPrefs.SetFloat("SpeedUpgradePrice", speedUpgradePrice);

        UpdateStatStatus();
    }

    public void StaminaUpgrade()
    {
        if (currentMoney < staminaUpgradePrice)
            return;

        staminaUpgradeLevel++;
        staminaUpgradePrice *= 1.1f;

        PlayerPrefs.SetFloat("StaminaUpgradeLevel", staminaUpgradeLevel);
        PlayerPrefs.SetFloat("StaminaUpgradePrice", staminaUpgradePrice);

        UpdateStatStatus();
    }

    public void IncomeUpgrade()
    {
        if (currentMoney < incomeUpgradePrice)
            return;

        incomeUpgradeLevel++;
        incomeUpgradePrice *= 1.1f;

        PlayerPrefs.SetFloat("IncomeUpgradeLevel", incomeUpgradeLevel);
        PlayerPrefs.SetFloat("IncomeUpgradePrice", incomeUpgradePrice);

        UpdateStatStatus();
    }

    void UpdateStatStatus()
    {
        speedUpgradePriceText.SetText(speedUpgradePrice.ToString());
        speedUpgradeLevelText.SetText(speedUpgradeLevel.ToString());
        staminaUpgradePriceText.SetText(staminaUpgradePrice.ToString());
        staminaUpgradeLevelText.SetText(staminaUpgradeLevel.ToString());
        incomeUpgradePriceText.SetText(incomeUpgradePrice.ToString());
        incomeUpgradeLevelText.SetText(incomeUpgradeLevel.ToString());
    }

    public void ResetAllProgress()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
