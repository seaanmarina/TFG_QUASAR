using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab;
    public GameObject contgame;
    Contador_JugA contador;

    int contadorNombre = 0;
    public Transform spawn1;
    public Transform spawn2;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    private int spawnIndex=1;
    string nombre_jugador;
    private Vector3 randomPosition;
    // Start is called before the first frame update
    void Start()
    {

         randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

        contador = contgame.GetComponent<Contador_JugA>();
        

        //try to connect
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
        //contador.contador--;
        

    }

    public override void OnJoinedRoom()
    {
        string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Range(0, s.Length)]).ToArray());
        }

        string randomString = GenerateRandomString(8);



        nombre_jugador = randomString;
        Debug.Log("Joined a room succesfully");
        

        if (PhotonNetwork.IsMasterClient)
        {
           
            PhotonNetwork.Instantiate(playerPrefab.name, spawn1.position, Quaternion.identity);

            PhotonNetwork.NickName = randomString;
            //playerObj.GetComponent<PhotonView>().RPC("CambiarNombre", RpcTarget.All, randomString);
            Debug.Log("naranja");
            
        }
        else 
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawn2.position, Quaternion.identity);
            PhotonNetwork.NickName = randomString;
            //playerObj2.GetComponent<PhotonView>().RPC("CambiarNombre", RpcTarget.All, randomString);

            // Debug.Log("azul");
        }


        
    }

    //public void StartTheGame()
    //{
    //    PhotonNetwork.NickName = randomString;
    //}

    [PunRPC]
    void CambiarNombre(string nombre)
    {
        gameObject.name = nombre;
    }

    // Update is called once per frame
    void Update()
    {






        
    }
}
