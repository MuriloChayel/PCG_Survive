using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTeste : MonoBehaviour
{
    public delegate void ClickAction(); // 

    public static event ClickAction onClicked;


    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "click"))
        {
            if (onClicked != null)
            {
                onClicked();
            }
        }
    }
}
