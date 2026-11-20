using chainsaw;
using REFrameworkNET;

namespace RE4ModdingAPI;

public class Singleton
{
    public static CharacterManager CharacterManager => API.GetManagedSingletonT<CharacterManager>();
    public static PlayerManager PlayerManager => API.GetManagedSingletonT<PlayerManager>();
    public static EnemyManager EnemyManager => API.GetManagedSingletonT<EnemyManager>();
    public static CostumeManager CostumeManager => API.GetManagedSingletonT<CostumeManager>();
    public static InventoryManager InventoryManager => API.GetManagedSingletonT<InventoryManager>();
}
