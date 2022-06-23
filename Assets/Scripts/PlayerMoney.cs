using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] float income = 1f;
    [SerializeField] GameObject floatingText;
    [SerializeField] Transform floatingTextSpawnPoint;
    [SerializeField] Transform floatingTextParent;
    [SerializeField] Vector3 floatingTextOffset;
    float currentMoney;



    private void Start()
    {
        income = Mathf.Pow(1.1f, PlayerPrefs.GetFloat("IncomeUpgradeLevel", 1));
        currentMoney = PlayerPrefs.GetFloat("Money", 0);
        UpdateMoney(currentMoney);
    }

    private void OnEnable()
    {
        PlayerMovement.OnStairCreate += EarnMoney;
    }

    private void OnDisable()
    {
        PlayerMovement.OnStairCreate -= EarnMoney;
    }

    void EarnMoney()
    {
        currentMoney += income;
        UpdateMoney(currentMoney);

        GameObject instance = Instantiate(floatingText, floatingTextSpawnPoint.position + floatingTextOffset, Quaternion.identity, floatingTextParent);
        instance.GetComponentInChildren<TextMeshProUGUI>().SetText("+ " + income.ToString("f1"));
        Destroy(instance, .5f);

        PlayerPrefs.SetFloat("Money", currentMoney);
    }

    public void UpdateMoney(float value)
    {
        moneyText.SetText(value.ToString("f0"));
    }




}
