using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float height = 1.0f;         // The height the GameObject will move up and down
    public float loopDuration = 2.0f;   // The duration of one complete loop (up and down motion)
    public float timeOffset = 0.0f;     // The time offset for starting the motion

    private Vector3 startPos;
    private float speed;

    void Start()
    {
        // Store the starting position of the GameObject
        startPos = transform.position;

        // Calculate the speed based on the loop duration
        speed = (2 * Mathf.PI) / loopDuration;
    }

    void Update()
    {
        // Calculate the new Y position with time offset
        float newY = startPos.y + Mathf.Sin((Time.time + timeOffset) * speed) * height;

        // Update the GameObject's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
