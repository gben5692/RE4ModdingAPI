using chainsaw;

namespace RE4ModdingAPI.Wrappers;

public class Inventory
{
#region Internal References
    private InventoryManager InventoryManager => Singleton.InventoryManager;
    private InGameShopManager InGameShopManager => Singleton.InGameShopManager;
#endregion

#region Properties

    /// <summary>
    /// In Game Currency
    /// </summary>
    public int CurrentPTAS
    {
        get => InventoryManager.CurrPTAS;
        set => InventoryManager.CurrPTAS = value;
    } 

    /// <summary>
    /// In Game Currency
    /// </summary>
    public int CurrentSpinels
    {
        get => InGameShopManager.CurrSpinelCount;
        set => InGameShopManager.CurrSpinelCount = value;
    }

#endregion 

#region Methods
    /// <summary>
    /// This adds PTAS to your inventory
    /// </summary>
    /// <param name="count">The amount to add</param>
    /// <param name="isPayBack">If the money is a refund</param>
    public void AddPTAS(int count, bool isPayBack = false) => InventoryManager.addPTAS(count, isPayBack);

    /// <summary>
    /// This removes PTAS from your inventory
    /// </summary>
    /// <param name="count">The amount to remove</param>
    public void ReducePTAS(int count) => InventoryManager.reducePTAS(count);

    /// <summary>
    /// This sets the PTAS in your inventory
    /// </summary>
    /// <param name="count">the amount to set</param>
    public void SetPTAS(int count) => InventoryManager.setPTAS(count);

    /// <summary>
    /// This adds spinels to your inventory
    /// </summary>
    /// <param name="count">The amount to add</param>
    public void AddSpinels(int count) => InGameShopManager.addSpinelCount(count);

    /// <summary>
    /// This removes spinels from your inventory
    /// </summary>
    /// <param name="count">The amount of remove</param>
    public void ReduceSpinels(int count) => InGameShopManager.reduceSpinelCount(count);

    /// <summary>
    /// This sets the spinels in your inventory
    /// </summary>
    /// <param name="count">The amount to set</param>
    public void SetSpinels(int count) => InGameShopManager.setSpinelCount(count);
#endregion
}