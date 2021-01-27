using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManagerCode : MonoBehaviourPunCallbacks
{
    public Text status;
   

    private bool roomExists = false;
  
    public Camera cam;
    public GameObject field;
    public GameObject player;
    public GameObject ball;

    Vector3 pos;
    Quaternion rot;
    byte group = 0;
    bool entrou = false;


    public Button buttonConnect;
    public Button buttonRandomMatch;
    public Button buttonDisconnect;
    
    
    

    public void Update()
    {
        if (roomExists)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && entrou == false )
            {
                entrou = true;

                buttonConnect.gameObject.SetActive(false);
                buttonRandomMatch.gameObject.SetActive(false);
                buttonDisconnect.gameObject.SetActive(false);
                status.text = "";
                status.gameObject.SetActive(false);

                if (PhotonNetwork.IsMasterClient)
                {
                    Vector3 p = new Vector3(0, 0, 1);
                    Quaternion r = Quaternion.identity;
                    PhotonNetwork.Instantiate(field.name, p, r, group);
                    PhotonNetwork.Instantiate(ball.name, new Vector3(0, 0, -1), r, group);
                }
            }

        }
    }

    public override void OnConnected()
    {
        Debug.Log("connection au serveur photon"); 
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the master, look for a room...");
        status.text = "Please, match a room";
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom("NewRoom" + Random.Range(10, 1000));
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom ");
        roomExists = true;

        pos = new Vector3(0, 0, -1);
        rot = Quaternion.identity;
        PhotonNetwork.Instantiate(player.name, pos, rot, group);

        Debug.Log("PlayerCount: " + PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            status.text = "Waiting for an opponent";

        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            status.text = "Ready";

        }  
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from the server : " + cause);
    }


}
