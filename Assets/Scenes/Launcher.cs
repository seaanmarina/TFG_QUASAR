using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab;
    public GameObject contgame;
     Contador_Jug contador; 


    public Transform spawn1;
    public Transform spawn2;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    private int spawnIndex=1;

    private Vector3 randomPosition;
    // Start is called before the first frame update
    void Start()
    {

         randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

        contador = contgame.GetComponent<Contador_Jug>();
        

        //try to connect
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room succesfully");
        Debug.Log(contador.contador);

        if (contador.contador == 1)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawn1.position, Quaternion.identity);
            contador.contador--;
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawn2.position, Quaternion.identity);
            contador.contador--;
        }


        
    }

    // Update is called once per frame
    void Update()
    {






        
    }
}
