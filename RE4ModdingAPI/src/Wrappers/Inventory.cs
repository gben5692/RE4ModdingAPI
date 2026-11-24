using chainsaw;

namespace RE4ModdingAPI.Wrappers;

public class Inventory
{
#region Internal References
    private static InventoryManager InventoryManager => Singleton.InventoryManager;
    private static InGameShopManager InGameShopManager => Singleton.InGameShopManager;
#endregion

#region Properties

    /// <summary>
    /// In Game Currency
    /// </summary>
    public int CurrentPTAS
    {
        get
        {
            if (InventoryManager == null)
            return 0;

            return InventoryManager.CurrPTAS;
        }
        set
        {
            if (InventoryManager == null)
            return;

            InventoryManager.CurrPTAS = value;
        }
    } 

    /// <summary>
    /// In Game Currency
    /// </summary>
    public int CurrentSpinels
    {
        get
        {
            if (InGameShopManager == null)
            return 0;

            return InGameShopManager.CurrSpinelCount;
        }
        set
        {
            if (InGameShopManager == null)
            return;

            InGameShopManager.CurrSpinelCount = value;
        }
    }

#endregion 

#region Methods
    /// <summary>
    /// This adds PTAS to your inventory
    /// </summary>
    /// <param name="count">The amount to add</param>
    /// <param name="isPayBack">If the money is a refund</param>
    public void AddPTAS(int count, bool isPayBack = false)
    {
        if (InventoryManager == null)
        return;

        InventoryManager.addPTAS(count, isPayBack);
    }

    /// <summary>
    /// This removes PTAS from your inventory
    /// </summary>
    /// <param name="count">The amount to remove</param>
    public void ReducePTAS(int count)
    {
        if (InventoryManager == null)
        return;

        InventoryManager.reducePTAS(count);
    }

    /// <summary>
    /// This sets the PTAS in your inventory
    /// </summary>
    /// <param name="count">the amount to set</param>
    public void SetPTAS(int count)
    {
        if (InventoryManager == null)
        return;

        InventoryManager.setPTAS(count);
    }

    /// <summary>
    /// This adds spinels to your inventory
    /// </summary>
    /// <param name="count">The amount to add</param>
    public void AddSpinels(int count)
    {
        if (InGameShopManager == null)
        return;

        InGameShopManager.addSpinelCount(count);
    }

    /// <summary>
    /// This removes spinels from your inventory
    /// </summary>
    /// <param name="count">The amount of remove</param>
    public void ReduceSpinels(int count)
    {
        if (InGameShopManager == null)
        return;
        
        InGameShopManager.reduceSpinelCount(count);
    }

    /// <summary>
    /// This sets the spinels in your inventory
    /// </summary>
    /// <param name="count">The amount to set</param>
    public void SetSpinels(int count)
    {
        if (InGameShopManager == null)
        return;
        
        InGameShopManager.setSpinelCount(count);
    }
#endregion
}