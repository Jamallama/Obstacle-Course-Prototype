using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatforms : MonoBehaviour
{
    public GameObject touchedObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player touched object");
            if (touchedObject != null)
            {
                Debug.Log("Respawn Called");
                gameObject.SetActive(true);
                touchedObject.GetComponent<platformObject>().respawnPlatform();
            }
        }
    }
}

public class platformObject : MonoBehaviour
{
    public void respawnPlatform()
    {
        gameObject.SetActive(true);
        Debug.Log("Respawned Platform");
    }
}