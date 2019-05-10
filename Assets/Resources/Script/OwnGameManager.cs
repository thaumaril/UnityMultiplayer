using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OwnGameManager : MonoBehaviourPunCallbacks
{
    [Header("Tutorial Game Manager")]
    public Character playerPrefab;

    [HideInInspector]
    public Character localplayer;

    private void Awake()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("Server");
        }

    }

    void Start()
    {
        Character.RefreshInstance(ref localplayer, playerPrefab);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Character.RefreshInstance(ref localplayer, playerPrefab);
    }
}
