using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler : MonoBehaviourPun
{
    public GameObject player;
    
    private void Awake()
    {
        if (!photonView.IsMine)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RefreshInstance(ref GameObject player, GameObject Prefab)
    {
        var position = Vector2.zero;
        var rotation = Quaternion.identity;
        if(player != null)
        {
            position = player.transform.position;
            rotation = player.transform.rotation;
            PhotonNetwork.Destroy(player.gameObject);
        }

        player = PhotonNetwork.Instantiate(Prefab.name, position, rotation);
    }
}
