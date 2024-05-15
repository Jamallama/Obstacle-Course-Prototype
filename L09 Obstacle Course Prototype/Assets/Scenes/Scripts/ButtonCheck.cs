using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    GameObject doorObject;
    ButtonCheck doorscript;
    [SerializeField] GameObject Trigger1;
    [SerializeField] GameObject Trigger2;
    [SerializeField] GameObject Trigger3;
    [SerializeField] private Animator myDoorBars = null;
    [SerializeField] private Animator myRoomBars = null;
    [SerializeField] Material onState;

    bool Trigger1Pressed = false;
    bool Trigger2Pressed = false;
    bool Trigger3Pressed = false;

    void Start()
    {
        doorscript = doorObject.GetComponent<ButtonCheck>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Trigger1.name)
        {
            doorscript.Trigger1Pressed = true;
            Trigger1.GetComponent<Renderer>().material = onState;
        }

        if (other.gameObject.tag == Trigger2.name)
        {
            doorscript.Trigger2Pressed = true;
            Trigger2.GetComponent<Renderer>().material = onState;
        }

        if (other.gameObject.tag == Trigger3.name)
        {
            doorscript.Trigger3Pressed = true;
            Trigger3.GetComponent<Renderer>().material = onState;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Trigger1Pressed && Trigger2Pressed && Trigger3Pressed)
        {
            myDoorBars.Play("Jail Bars Open", 0, 0.0f);

        }
    }
}
