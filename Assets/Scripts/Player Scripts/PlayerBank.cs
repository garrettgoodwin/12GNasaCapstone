using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerBank : MonoBehaviour
{
    public static PlayerBank Instance { get; private set;}

    private int totalAmount = 0;
    private const string TotalCoinAmountKey = "PlayerTotalCoinAmount";
    public UnityEvent OnCoinCountChanged;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadBankAccount();
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    //private void Start()
    //{
    //    LoadBankAccount();
    //}

    public void IncreaseBankAmount(int amount)
    {
        totalAmount += amount;
        SaveBankAccount();
        OnCoinCountChanged?.Invoke();

        PrintOutAmount();
    }

    public void DecreaseAmount(int amount)
    {
        totalAmount -= amount;

        if(totalAmount < 0)
        {
            totalAmount = 0;
        }
        SaveBankAccount();
        OnCoinCountChanged?.Invoke();
        PrintOutAmount();
    }

    public int GetBankAmount()
    {
        return totalAmount;
    }

    public void SaveBankAccount()
    {
        PlayerPrefs.SetInt(TotalCoinAmountKey, totalAmount);
        PlayerPrefs.Save();
    }

    public void LoadBankAccount()
    {
        totalAmount = PlayerPrefs.GetInt(TotalCoinAmountKey, 0);
    }

    void PrintOutAmount()
    {
        //Debug.Log("Players Bank Amount is currently at: " + totalAmount);
    }
}
