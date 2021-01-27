using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;




public class BallCode : MonoBehaviour
{
    float velx = 0.1f;
    float vely = 0.002f;
    int player_1_Score=0;
    int player_2_Score=0;
    //list = new List<float>{0.001f,0.002f,0.003f,-0.001,-0.002,-0.003,-0.0025,0.0025};
    Vector3 pos;
    //Random rand = new Random();
    void Start()
    {
        pos = new Vector3(0, 0, -1);
    }

    void Update()
    {	
    	//int index = random.Next(list.Count);
    	vely=Random.Range(-0.1f, 0.1f);
    	//Console.WriteLine((vely));
        transform.position += new Vector3(pos.x + velx, pos.y + vely, 0);
        
        if (transform.position.x >= 7f)
        {
        	transform.position = new Vector3(0,0,-1);
        	player_1_Score++;
        	Debug.Log("player_1_score: " +player_1_Score +" *** player_2_score : " +player_2_Score);
      
        	
        }
        if(transform.position.x <=-7f){
        	
        	transform.position = new Vector3(0,0,-1);
        	player_2_Score++;
        	Debug.Log("player_1_score: " +player_1_Score +" *** player_2_score : " +player_2_Score);
        }
        
        if(player_2_Score ==10 || player_1_Score==10)
        {	
        	velx=0;
        	vely=0;
        	transform.position = new Vector3(0,0,-1);
        	Debug.Log("Game Over");
        	if(player_2_Score ==10)
        	{
        	Debug.Log("PLAYER_2_WIN");
        	}
        	else
        	{
        	Debug.Log("PLAYER_1_WIN");
        	}
        	
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        velx *= (-1);
    }
}
