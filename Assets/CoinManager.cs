using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;
public class CoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    void Start()
    {
        if (PlayerBank.Instance != null)
        {
            PlayerBank.Instance.OnCoinCountChanged.AddListener(UpdateCoinUI);
            UpdateCoinUI();
        }
        else
        {
            Debug.LogError("Coin Manager is missing the reference to PlayerBank");
        }
    }

    private void UpdateCoinUI()
    {
        coinText.text = PlayerBank.Instance.GetBankAmount().ToString();
    }
    private void OnDestroy()
    {
        if(PlayerBank.Instance != null)
        {
            PlayerBank.Instance.OnCoinCountChanged.RemoveListener(UpdateCoinUI);
        }
    }





}
