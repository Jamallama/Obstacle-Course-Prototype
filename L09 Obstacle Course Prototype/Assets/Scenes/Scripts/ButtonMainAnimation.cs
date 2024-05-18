using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMainAnimation : MonoBehaviour
{   public void ButtonMoveIn()
    {
        Debug.Log("Mouse hovered on button.");
        transform.LeanMoveX(184, 0.3f);
    } 

    public void ButtonMoveOut()
    {
        Debug.Log("Mouse hovered off of button.");
        transform.LeanMoveX(138, 0.5f).setEaseOutQuart();
    }
}
