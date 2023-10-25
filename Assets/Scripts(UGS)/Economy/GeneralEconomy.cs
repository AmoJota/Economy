using UnityEngine;
using Unity.Services.Economy;
using Unity.Services.Economy.Model;
using System.Collections.Generic;
using TMPro;
public class GeneralEconomy : MonoBehaviour
{
    [SerializeField] TMP_Text goldText, iriumText;
    private void Start()
    {
        SincroniceConfiguration(); //LLAMAR ANTES DE CUALQUIER REQUEST.

        //En TODOS los metodos se llama a esta linea en vez de al método porque llamar al método da error de sincronización.
        //await EconomyService.Instance.Configuration.SyncConfigurationAsync();


        GetPlayerBalance();
    }
    public async void SincroniceConfiguration()
    {
        //SyncConfigurationAsync() caches the latest version of your Economy configuration.
        //Gets the currently published Economy configuration and caches it in the SDK.
        //You must call this method before calling any other configuration methods (for example, GetCurrencies()), otherwise an exception is thrown.

        await EconomyService.Instance.Configuration.SyncConfigurationAsync();
    }
    public async void IncrementBalanceAsync(string coinName)
    {
        string currencyID = coinName;
        int incrementAmount = 100;
        string writeLock = "someLockValueFromPreviousRequest";
        IncrementBalanceOptions options = new IncrementBalanceOptions
        {
            WriteLock = writeLock
        };

        PlayerBalance newBalance = await EconomyService.Instance.PlayerBalances.IncrementBalanceAsync(currencyID, incrementAmount);
        // OR
        // PlayerBalance otherNewBalance = await EconomyService.Instance.PlayerBalances.IncrementBalanceAsync(currencyID, incrementAmount, options);
        GetPlayerBalance();

        Debug.Log("Se ha añadido " + incrementAmount + " de oro a tu cuenta.");

    }
    public async void DecrementBalanceAsync(string coinName)
    {
        string currencyID = coinName;
        int decrementAmount = 100;
        string writeLock = "someLockValueFromPreviousRequest";
        DecrementBalanceOptions options = new DecrementBalanceOptions
        {
            WriteLock = writeLock
        };

        PlayerBalance newBalance = await EconomyService.Instance.PlayerBalances.DecrementBalanceAsync(currencyID, decrementAmount);
        // OR
        //PlayerBalance otherNewBalance = await EconomyService.Instance.PlayerBalances.DecrementBalanceAsync(currencyID, decrementAmount, options);
        GetPlayerBalance();

        Debug.Log("Se ha quitado " + decrementAmount + " de oro de tu cuenta.");

    }
   
    public async void SetBalanceAsync(string coinName)
    {
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();

        string currencyID = coinName;
        int newAmount = 100;
        string writeLock = "someLockValueFromPreviousRequest";
        SetBalanceOptions options = new SetBalanceOptions
        {
            WriteLock = writeLock
        };

        PlayerBalance newBalance = await EconomyService.Instance.PlayerBalances.SetBalanceAsync(currencyID, newAmount);
        // OR
        //PlayerBalance otherNewBalance = await EconomyService.Instance.PlayerBalances.SetBalanceAsync(currencyID, newAmount, options);
        Debug.Log("Establecer la cuenta con " + newAmount + " de oro.");
    }
    private async void MakePurchaseItem()
    {
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();

        string purchaseId = "BUY_BOOTS";
        
        MakeVirtualPurchaseResult purchaseResult = await EconomyService.Instance.Purchases.MakeVirtualPurchaseAsync(purchaseId);
    }
   
    public async void GetCurrencies()
    {
        //Retrieves all currencies from your cached configuration. Returns a list of CurrencyDefinition objects.
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();


        List<CurrencyDefinition> definitions = EconomyService.Instance.Configuration.GetCurrencies();
    }
    public async  void GetSpecificCurrency()
    {
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();


        string currencyID = "GOLD";
        CurrencyDefinition goldCurrencyDefinition = EconomyService.Instance.Configuration.GetCurrency(currencyID);
    }
    public async void GetPlayerBalance()
    {
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();
        
        //This method gets the balance for the currently signed in player of the currency specified in the CurrencyDefinition.
        //It returns a PlayerBalance as specified in Player balances.

        string goldID = "GOLD";
        CurrencyDefinition goldCurrencyDefinition = EconomyService.Instance.Configuration.GetCurrency(goldID);
        PlayerBalance playersGoldBarBalance = await goldCurrencyDefinition.GetPlayerBalanceAsync();
        goldText.text = playersGoldBarBalance.Balance.ToString();

        string iriumID = "IRIUM";
        CurrencyDefinition iriumCurrencyDefinition = EconomyService.Instance.Configuration.GetCurrency(iriumID);
        PlayerBalance playersiriumBarBalance = await iriumCurrencyDefinition.GetPlayerBalanceAsync();
        iriumText.text = playersiriumBarBalance.Balance.ToString();
    }

   
    private async void GetVirtualPurchases()
    {
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();


        //Retrieves all virtual purchases from your cached configuration. Returns a list of VirtualPurchaseDefinition objects.

        List<VirtualPurchaseDefinition> definitions = EconomyService.Instance.Configuration.GetVirtualPurchases();
    }

    private async void GetVirtualSinglePurchase()
    {
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();


        //Retrieves a single virtual purchase from your cached configuration. Returns a single VirtualPurchaseDefinition object.

        string purchaseId = "VIRTUAL_PURCHASE_ID";
        VirtualPurchaseDefinition definition = EconomyService.Instance.Configuration.GetVirtualPurchase(purchaseId);
    }
}
