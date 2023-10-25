using System.Collections;
using System.Collections.Generic;
using Unity.Services.Economy.Model;
using Unity.Services.Economy;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GeneralEconomy generalEconomy;
    public async void MakeVirtualPurchaseAsync(string item)
    {
        string purchaseID = item;
        MakeVirtualPurchaseResult purchaseResult = await EconomyService.Instance.Purchases.MakeVirtualPurchaseAsync(purchaseID);
        generalEconomy.GetPlayerBalance();
    }
}
