using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace OwnCode
{
    public class NetworkConnectionManager : MonoBehaviourPunCallbacks
    {

        public Button btnConnectMaster;
        public Button btnConnectRoom;

        public bool triesToConnectToMaster;
        public bool triesToConenctToRoom;

        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            triesToConenctToRoom = false;
            triesToConnectToMaster = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(btnConnectMaster != null)
            {
                btnConnectMaster.gameObject.SetActive(!PhotonNetwork.IsConnected && !triesToConnectToMaster);
            }
            if(btnConnectRoom != null)
            {
                btnConnectRoom.gameObject.SetActive(PhotonNetwork.IsConnected && !triesToConnectToMaster & !triesToConenctToRoom);
            }
            
        }

        public void OnClickConnectToMaster()
        {
            //Settings (all optional and only for tut)
            PhotonNetwork.OfflineMode = false;
            PhotonNetwork.NickName = "PlayerName";
            //PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "v1";

            triesToConnectToMaster = true;
            //PhotonNetwork.ConnectToMaster(ip,port,appid); //manual conenction
            PhotonNetwork.ConnectUsingSettings(); // automatic connection based on the config file in Photon/PhotonUnityNetworking/Resources/PhotonServerSettings
        }


        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            triesToConnectToMaster = false;
            triesToConenctToRoom = false;
            Debug.Log(cause);
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            triesToConnectToMaster = false;
            Debug.Log("Conencted to Master!");
        }

        public void OnClickConnectToRoom()
        {
            if (!PhotonNetwork.IsConnected)
                return;

            triesToConenctToRoom = true;
            //PhotonNetwork.CreateRoom("Peters Game1"); //Create a specitfic Room   - Error: OnCreateRoomFailed
            //PhotonNetwork.JoinRoom("Peters Game1"); //Join a specific Room        - Error: OnJoinRoomFailed
            PhotonNetwork.JoinRandomRoom();             //Join a random Room        - Error: OnJoinRandomRoomFailed
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            triesToConenctToRoom = false;
            Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount + "| Room Name: " + PhotonNetwork.CurrentRoom.Name);
            SceneManager.LoadScene("Start");
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            //no room available
            //create a room (null as a name means "doesent matter")
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);
            Debug.Log(message);
            triesToConenctToRoom = false;
        }

    }
}
