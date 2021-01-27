using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerBarCode : MonoBehaviour
{
    public PhotonView pv;
    private Color color;
    float speed = 12 ;

    void Start()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            transform.position = new Vector3(-4, 0, -1);
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            transform.position = new Vector3(4, 0, -1);
        }
    }

    void Update()
    {
        if (transform.position.x < 0)
        {
            transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (transform.position.x > 1)
        {
            transform.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }    

        if (pv.IsMine)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            translation *= Time.deltaTime;
            transform.Translate(0, translation, 0);
        }
    }
}
