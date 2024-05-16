using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public GameObject platformsParent; // Reference to the parent GameObject containing the platforms

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (platformsParent != null)
            {
                // Get all child objects of the platforms parent
                Debug.Log("Respawning Platforms");
                foreach (Transform child in platformsParent.transform)
                {
                    RespawnPlatform(child.gameObject);
                }
            }
            else
            {
                Debug.LogWarning("Platforms parent is not assigned!");
            }
        }
    }

    private void RespawnPlatform(GameObject platform)
    {
        platform.SetActive(true); // Activate the platform
        // You can add additional respawn logic here if needed
        Debug.Log("Respawned Platform: " + platform.name);
    }
}