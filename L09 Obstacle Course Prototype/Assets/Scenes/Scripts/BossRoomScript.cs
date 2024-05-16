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
    [SerializeField] private string AnimationName = "Animation";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (bossActivatable)
            {
                AnimatedObject.Play(AnimationName, 0, 0.0f);
            }
        }
    }
}
