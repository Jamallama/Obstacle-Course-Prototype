using UnityEngine;

public class RotateParent : MonoBehaviour
{
    public float rotationSpeed = 10f;

    // Enum to select the axis of rotation
    public enum Axis { X, Y, Z }
    public Axis rotationAxis = Axis.Y; // Default to rotating around the Y-axis

    // Public variable to specify the offset from the child's position
    public Vector3 rotationOffset = Vector3.zero;

    void Update()
    {
        // Ensure the object has a parent
        if (transform.parent != null)
        {
            // Determine the rotation axis based on the selected enum
            Vector3 selectedAxis = Vector3.up; // Default to Y-axis
            switch (rotationAxis)
            {
                case Axis.X:
                    selectedAxis = Vector3.right;
                    break;
                case Axis.Y:
                    selectedAxis = Vector3.up;
                    break;
                case Axis.Z:
                    selectedAxis = Vector3.forward;
                    break;
            }

            // Calculate the rotation point based on the child's position and the offset
            Vector3 rotationPoint = transform.position + rotationOffset;

            // Rotate the parent object around the specified point and axis
            transform.parent.RotateAround(rotationPoint, selectedAxis, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("No parent object found to rotate.");
        }
    }
}
