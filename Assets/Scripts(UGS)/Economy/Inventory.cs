using System.Collections;
using System.Collections.Generic;
using Unity.Services.Economy.Model;
using Unity.Services.Economy;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public async void RefreshInventory()
    {
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();

    }

    private async void GetInventoryItems()
    {
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();


        //Retrieves all inventory items from your cached configuration. Returns a list of InventoryItemDefinition objects.

        List<InventoryItemDefinition> definitions = EconomyService.Instance.Configuration.GetInventoryItems();
    }
    private async void GetInventorySingleItem(string catchItem)
    {
        await EconomyService.Instance.Configuration.SyncConfigurationAsync();


        //Retrieves a specific InventoryItemDefinition using an item ID from your cached configuration. Returns null if the item doesn't exist.

        string itemID = catchItem;
        InventoryItemDefinition definition = EconomyService.Instance.Configuration.GetInventoryItem(itemID);
        
    }
}
