using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BossRoomScript : MonoBehaviour
{
    [SerializeField] private Animator AnimatedObject = null;
    [SerializeField] private bool bossActivatable = false;
    [SerializeField] private AnimationClip AnimationClip = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            if (bossActivatable)
            {
                Debug.Log("Boss is activatable.");
                if (AnimatedObject != null)
                {
                    Debug.Log("AnimatedObject is assigned.");
                    if (AnimationClip != null)
                    {
                        Debug.Log("AnimationClip is assigned and will be played.");
                        AnimatedObject.Play(AnimationClip.name, 0, 0.0f);
                        bossActivatable = false;  // Deactivate after triggering
                        Debug.Log("Boss activatable set to false.");
                    }
                    else
                    {
                        Debug.LogError("AnimationClip is not assigned.");
                    }
                }
                else
                {
                    Debug.LogError("AnimatedObject is not assigned.");
                }
            }
        }
    }
}
