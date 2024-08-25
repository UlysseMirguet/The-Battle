using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject machineGun;
    [SerializeField]
    private GameObject rocketLauncher;
    [SerializeField]
    private GameObject flamethrower;
    [SerializeField]
    private GameObject howitzer;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnBuilding(string buildingName, Vector3 pos)
    {
        GameObject prefab = null;

        switch (buildingName)
        {
            case "machineGun":
                prefab = machineGun;
                break;
            case "rocketLauncher":
                prefab = rocketLauncher;
                break;
            case "flamethrower":
                prefab = flamethrower;
                break;
            case "howitzer":
                prefab = howitzer;
                break;
        }

        if (prefab != null)
        {
            GameObject buildingInstance = Instantiate(prefab, pos, Quaternion.identity);
            buildingInstance.GetComponent<NetworkObject>().Spawn(); // Synchronise l'instance sur le réseau
        }
        else
        {
            Debug.LogWarning($"Building name '{buildingName}' not recognized.");
        }
    }
}
