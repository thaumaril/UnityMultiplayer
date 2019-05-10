using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public string direction;
    public float bulletspeed;

    private Rigidbody2D rgb2d;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        bulletspeed = 9f;
        direction = GetComponentInParent<PlayerShoot>().ReturnPlayerFacing();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveBullet();
    }

    public void moveBullet()
    {
        switch (direction)
        {
            case "up":
                transform.position.Set(gameObject.transform.position.x, gameObject.transform.position.y + bulletspeed, 0);
                rgb2d.velocity = new Vector2(0, bulletspeed);
                break;
            case "down":
                rgb2d.velocity = new Vector2(0, -bulletspeed);
                break;
            case "left":
                rgb2d.velocity = new Vector2(-bulletspeed, 0);
                break;
            case "right":
                rgb2d.velocity = new Vector2(+bulletspeed, 0);
                break;
        }

    }
}
