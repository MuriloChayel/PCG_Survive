using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ProcessNoise : MonoBehaviour
{

    public Vector2 pos; // no mundo
    public float dir, speed, jump;
    
    private void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        if (Input.GetMouseButtonDown(0))
        {
            CheckArea(pos);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void CheckArea(Vector2 pos)
    {
        float width = 0;
        float height = 0;
        
        if(pos.x < width  && pos.y > height)
        {
            dir = 0;
        }
        else if(pos.x > width && pos.y > height)
        {
           
            print("Superior direito");
        }
        else if(pos.x < width && pos.y < height)
        {
            print("Inferior esquerdo");
            dir = -1;
        }
        else
        {
            dir = 1;
            print("Inferior direito");
        }
    }
    public Rigidbody2D rb;
    private void Move()
    {
        rb.velocity = new Vector2(speed * dir, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(new Vector2(0, jump));
    }
}
