using chainsaw;
using REFrameworkNET;
using via.hid;
using via.wwiselib;

namespace RE4ModdingAPI;

public class Singleton
{
    public static MercenariesManager MercenariesManager => API.GetManagedSingletonT<MercenariesManager>();
    public static CharacterManager CharacterManager => API.GetManagedSingletonT<CharacterManager>();
    public static PlayerManager PlayerManager => API.GetManagedSingletonT<PlayerManager>();
    public static EnemyManager EnemyManager => API.GetManagedSingletonT<EnemyManager>();
    public static CostumeManager CostumeManager => API.GetManagedSingletonT<CostumeManager>();
    public static InventoryManager InventoryManager => API.GetManagedSingletonT<InventoryManager>();
    public static CampaignManager CampaignManager => API.GetManagedSingletonT<CampaignManager>();
    public static InGameShopManager InGameShopManager => API.GetManagedSingletonT<InGameShopManager>();
}
