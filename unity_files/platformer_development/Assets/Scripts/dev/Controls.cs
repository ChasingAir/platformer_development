using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed = 3f;
    public bool moveright;
    public bool moveleft;
    public SpriteRenderer mySpriteRenderer;
    public Joystick joystick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(joystick.Horizontal > .5)
        {
        rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        else if(joystick.Horizontal < -.5)
        {
        rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        else
        {
          rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //this stuff just flips the sprite for direction
        if(joystick.Horizontal > 0)
        {
          mySpriteRenderer.flipX = false;
        }
        else if(joystick.Horizontal < 0)
        {
          mySpriteRenderer.flipX = true;
        }
/*
        if (Input.GetKey(KeyCode.LeftArrow)) //if arrow key is pressed, set velocity equal to movespeed
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.RightArrow)) //if arrow key is pressed, set velocity equal to movespeed
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);

        }

        if (moveright)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        if (moveleft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        */
    }
}
