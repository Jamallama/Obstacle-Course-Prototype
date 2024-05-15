using UnityEngine;

public class Button : MonoBehaviour
{
    public DoorController doorController;  // Reference to the DoorController script

    void OnTriggerEnter(Collider other)  // This method is called when something enters the button's trigger collider
    {
        if (other.CompareTag("Player"))  // Check if the object that collided has the tag "Player"
        {
            if (doorController != null)
            {
                doorController.ButtonPressed();  // Notify the DoorController that a button has been pressed
                gameObject.SetActive(false);  // Disable the button after it has been pressed
            }
            else
            {
                Debug.LogError("DoorController not set on Button.");
            }
        }
    }
}