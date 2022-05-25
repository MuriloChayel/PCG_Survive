using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaraPesca : MonoBehaviour
{
    public Rigidbody2D anzol;
    public Vector2 v0;
    public float force;
    public Vector2 mousePos;

    void Start(){

    }
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Arremessar();
        }
    }
    public void Arremessar(){
       
    }
    //dont call hook
    /*IEnumerator Hook(){
        yield return null;
        anzol.isKinematic = false;
    
        anzol.velocity = transform.right * -1 *  force;
    }*/
}
