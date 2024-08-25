using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class InputManager : NetworkBehaviour
{
    private string currentBuildingName;

    private void Update()
    {
        if (IsOwner) // Vérifie si c'est le client qui possède cet objet
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.z = 0;
                RequestSpawnBuildingServerRpc(currentBuildingName, worldPosition);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentBuildingName = "machineGun";
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentBuildingName = "rocketLauncher";
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentBuildingName = "flamethrower";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentBuildingName = "howitzer";
            }
        }
    }

    [ServerRpc]
    void RequestSpawnBuildingServerRpc(string buildingName, Vector3 position)
    {
        GameManager.Instance.SpawnBuilding(buildingName, position);
    }
}
