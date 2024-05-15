using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator1;  // Reference to the first door's Animator component
    public Animator doorAnimator2;  // Reference to the second door's Animator component
    public string openAnimationName1 = "OpenDoor1";  // The name of the door opening animation
    public string openAnimationName2 = "OpenDoor2";  // The name of the door opening animation
    private int buttonsPressed = 0;  // Counter to keep track of how many buttons have been pressed

    void Start()
    {
        buttonsPressed = 0;  // Initialize the button press counter
    }

    public void ButtonPressed()
    {
        buttonsPressed++;  // Increment the counter when a button is pressed

        // Check if all three buttons have been pressed
        if (buttonsPressed == 3)
        {
            OpenDoors();
        }
    }

    void OpenDoors()
    {
        if (doorAnimator1 != null)
        {
            doorAnimator1.Play(openAnimationName1);  // Play the first door opening animation
        }
        else
        {
            Debug.LogError("First door Animator not set.");
        }

        if (doorAnimator2 != null)
        {
            doorAnimator2.Play(openAnimationName2);  // Play the second door opening animation
        }
        else
        {
            Debug.LogError("Second door Animator not set.");
        }
    }
}