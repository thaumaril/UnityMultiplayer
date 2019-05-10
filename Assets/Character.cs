using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviourPun
{

    public PlayerMovement charMovment;
    public PlayerShoot charShoot;

    private void Awake()
    {
        if (!photonView.IsMine && GetComponent<Character>() != null)
        {
            Destroy(GetComponent<Character>());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        charMovment = gameObject.GetComponent<PlayerMovement>();
        charShoot = gameObject.GetComponent<PlayerShoot>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        charMovment.PlayerMove();
        charShoot.PlayerShooting();
    }

    public static void RefreshInstance(ref Character player, Character Prefab)
    {
        var position = Vector2.zero;
        var rotation = Quaternion.identity;
        if (player != null)
        {
            position = player.transform.position;
            rotation = player.transform.rotation;
            PhotonNetwork.Destroy(player.gameObject);
        }

        player = PhotonNetwork.Instantiate(Prefab.gameObject.name, position, rotation).GetComponent<Character>();
    }
}
