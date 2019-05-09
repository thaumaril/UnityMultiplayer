using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{
    Rigidbody2D body;
    public float runSpeed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        PlayerMove();
    }


    public void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.velocity = new Vector2(0, +runSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            body.velocity = new Vector2(0, -runSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            body.velocity = new Vector2(-runSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector2(+runSpeed, 0);
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
    }
}
