using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneric : MonoBehaviour
{
    public float speed;


    private Rigidbody2D rb;
    private Animator an;

    private Vector2 direction;

    private void Awake()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  
        ControllAnimations();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    public void Movement()
    {
        rb.velocity = direction.normalized * speed;
        transform.localScale = direction.x > 0 ? new Vector3(1, 1, 1) : direction.x < 0 ? new Vector3(-1, 1, 1) : transform.localScale; 
    }
    private void ControllAnimations()
    {
        an.SetFloat("x", direction != Vector2.zero ? 1 : 0);
    }
}
