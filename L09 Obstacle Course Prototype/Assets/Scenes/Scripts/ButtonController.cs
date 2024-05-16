using UnityEngine;

public class Button : MonoBehaviour
{
    public DoorController doorController;  // Reference to the DoorController script
    public Material pressedMaterial;  // Material to change to when button is pressed
    private Material originalMaterial;  // Original material of the button

    void Start()
    {
        // Store the original material of the button
        originalMaterial = GetComponent<Renderer>().material;
    }

    void OnTriggerEnter(Collider other)  // This method is called when something enters the button's trigger collider
    {
        if (other.CompareTag("Player"))  // Check if the object that collided has the tag "Player"
        {
            if (doorController != null)
            {
                doorController.ButtonPressed();  // Notify the DoorController that a button has been pressed
                // Change the material of the button to the pressed material
                GetComponent<Renderer>().material = pressedMaterial;
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                Debug.LogError("DoorController not set on Button.");
            }
        }
    }

    void ResetButton()
    {
        // Reset the material of the button to its original material
        GetComponent<Renderer>().material = originalMaterial;
    }
}
