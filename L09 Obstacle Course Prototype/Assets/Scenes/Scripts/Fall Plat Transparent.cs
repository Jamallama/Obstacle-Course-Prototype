using System.Collections;
using UnityEngine;

public class FallPlatTransparent : MonoBehaviour
{
    public float fallTime = 0.5f;
    public float fadeDuration = 0.5f; // Duration for the fade effect
    public float respawnTime = 2.0f;  // Time before the platform respawns
    private Renderer platformRenderer; // Reference to the platform's renderer component
    private Collider platformCollider; // Reference to the platform's collider component
    private Color initialColor; // Initial color of the platform
    private float initialAlpha; // Initial alpha value of the platform's color
    private Coroutine fallCoroutine; // Reference to the fall coroutine
    private bool isFalling = false; // Flag to track if the platform is currently falling

    void Start()
    {
        // Find and store the platform's renderer and collider components
        platformRenderer = GetComponent<Renderer>();
        platformCollider = GetComponent<Collider>();

        if (platformRenderer == null)
        {
            Debug.LogError("FallPlat: No Renderer component found on the platform GameObject.");
            enabled = false; // Disable the script if Renderer component is not found
            return;
        }

        if (platformCollider == null)
        {
            Debug.LogError("FallPlat: No Collider component found on the platform GameObject.");
            enabled = false; // Disable the script if Collider component is not found
            return;
        }

        // Store the initial color and alpha value of the platform
        initialColor = platformRenderer.material.color;
        initialAlpha = initialColor.a;

        Debug.Log($"Initial color: {initialColor}");
        Debug.Log($"Initial alpha: {initialAlpha}");
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.CompareTag("Player") && !isFalling)
            {
                fallCoroutine = StartCoroutine(FallAndFade(fallTime));
            }
        }
    }

    IEnumerator FallAndFade(float time)
    {
        isFalling = true;

        // Wait for the fall time
        yield return new WaitForSeconds(time);

        // Gradually decrease the transparency
        float elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value based on the elapsed time
            float newAlpha = Mathf.Lerp(initialAlpha, 0f, elapsedTime / fadeDuration);

            // Update the platform's color with the new alpha value
            Color newColor = initialColor;
            newColor.a = newAlpha;
            platformRenderer.material.color = newColor;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Make the platform invisible and disable its collider
        platformRenderer.enabled = false;
        platformCollider.enabled = false;

        // Wait for respawn time
        yield return new WaitForSeconds(respawnTime);

        // Re-enable the platform, its collider, and reset its color and alpha
        platformRenderer.enabled = true;
        platformCollider.enabled = true;
        initialColor.a = initialAlpha; // Reset the alpha value
        platformRenderer.material.color = initialColor;

        Debug.Log("Platform respawned with color: " + platformRenderer.material.color);

        isFalling = false;
    }

    void OnCollisionExit(Collision collision)
    {
        // If the player leaves before the platform falls, stop the fall coroutine
        if (collision.gameObject.CompareTag("Player") && !isFalling && fallCoroutine != null)
        {
            StopCoroutine(fallCoroutine);
        }
    }
}
