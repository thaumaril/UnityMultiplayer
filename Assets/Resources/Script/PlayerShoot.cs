using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public string playerfacing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void PlayerShooting()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerfacing = "up";
                Instantiate(bullet, transform);
                
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerfacing = "down";
                Instantiate(bullet, transform);

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerfacing = "left";
                Instantiate(bullet, transform);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerfacing = "right";
                Instantiate(bullet, transform);
            }

        
    }

    public string ReturnPlayerFacing()
    {
        return playerfacing;
    }
}
