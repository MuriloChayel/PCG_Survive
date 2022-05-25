using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    void Start(){
        Destroy(gameObject, 3f);
    }
    public void Setup(float speed, Vector2 direction){
        this.speed = speed;
        this.direction = direction;
    }
    public void Update(){
        transform.position += direction * Time.deltaTime * speed;
    }
}
