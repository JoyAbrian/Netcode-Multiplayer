using Unity.Netcode;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private Transform objectToSpawn;
    private Transform spawnedObjectTransform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnedObjectTransform = Instantiate(objectToSpawn);
            spawnedObjectTransform.GetComponent<NetworkObject>().Spawn(true);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            spawnedObjectTransform.GetComponent<NetworkObject>().Despawn(true);
            Destroy(spawnedObjectTransform.gameObject);
        }
    }
}
