using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTeleport : MonoBehaviour
{
    public GameObject target; 

    public void OnEnable()
    {
        EventTeste.onClicked += Teleport;
    }
    public void OnDisable()
    {
        EventTeste.onClicked -= Teleport;

    }
    void Teleport()
    {
        Color cor = new Color(255, 0, 0, 255);
        target.GetComponent<SpriteRenderer>().color = cor;
    }
}
