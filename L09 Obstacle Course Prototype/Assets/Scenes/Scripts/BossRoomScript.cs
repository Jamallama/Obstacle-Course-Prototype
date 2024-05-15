using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BossRoomScript : MonoBehaviour
{
    [SerializeField] private Animator myDoorBars = null;
    [SerializeField] private Animator myRoomBars = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (openTrigger)
            {
                myDoorBars.Play("Jail Bars Open", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                myDoorBars.Play("Jail Bars Close", 0, 0.0f);
                gameObject.SetActive(false);
            }

            if (openTrigger)
            {
                myRoomBars.Play("Boss Room Bars Open", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                myRoomBars.Play("Boss Room Bars Close", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }


}