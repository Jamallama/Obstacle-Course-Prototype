using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;  // Reference to the first door's Animator component
    public string openAnimationName = "OpenDoor";  // The name of the door opening animation
    public int buttonsRequired = 3;
    private int buttonsPressed = 0;  // Counter to keep track of how many buttons have been pressed

    void Start()
    {
        buttonsPressed = 0;  // Initialize the button press counter
    }

    public void ButtonPressed()
    {
        buttonsPressed++;  // Increment the counter when a button is pressed

        // Check if all three buttons have been pressed
        if (buttonsPressed == buttonsRequired)
        {
            OpenDoors();
        }
    }

    void OpenDoors()
    {
        if (doorAnimator != null)
        {
            doorAnimator.Play(openAnimationName);  // Play the first door opening animation
        }
        else
        {
            Debug.LogError("First door Animator not set.");
        }
    }
}