using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public static event Action OnStaminaRunOut = delegate { };

    [SerializeField] float maxStamina = 100f;
    [SerializeField] float staminaDecreaseRate = 10;
    [SerializeField] Material playerMaterial;
    [SerializeField] Color exhaustedColor;
    [SerializeField] Color normalColor;

    float staminaIncreaseRate = 5;
    float staminaIncreaseInterval = 1;

    float currentStamina;

    void Start()
    {
        maxStamina = 100 * Mathf.Pow(1.1f, PlayerPrefs.GetFloat("StaminaUpgradeLevel", 1));
        currentStamina = maxStamina;
        StartCoroutine(IncreaseStamina());
    }

    void OnEnable()
    {
        PlayerMovement.OnStairCreate += DecreaseStamina;
    }

    void OnDisable()
    {
        PlayerMovement.OnStairCreate -= DecreaseStamina;
    }

    public void ResetStamina()
    {
        currentStamina = maxStamina;
    }

    private void Update()
    {
        playerMaterial.color = Color.Lerp(exhaustedColor, normalColor, (currentStamina / maxStamina));
    }

    IEnumerator IncreaseStamina()
    {
        while (true)
        {
            if (currentStamina <= maxStamina)
            {
                currentStamina += staminaIncreaseRate;
            }

            yield return new WaitForSeconds(staminaIncreaseInterval);
        }
    }

    void DecreaseStamina()
    {
        if (currentStamina > 0)
            currentStamina -= staminaDecreaseRate;

        if (currentStamina <= 0)
            OnStaminaRunOut();
    }
}
