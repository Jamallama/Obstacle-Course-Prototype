using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public GameObject platformsParent; // Reference to the parent GameObject containing the platforms

    private Renderer platformRenderer;
    private Color initialColor; // Initial color of the platform
    private float initialAlpha; //Initial alpha value of the platform's color

    private void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        initialColor = platformRenderer.material.color;
        initialAlpha = initialColor.a;
    }
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
        initialColor.a = initialAlpha;
        GetComponent<Renderer>().material.color = initialColor;
        Debug.Log("Respawned Platform: " + platform.name +" with color value " + initialColor);
    }
}