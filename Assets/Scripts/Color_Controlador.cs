using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Color_Controlador : MonoBehaviourPunCallbacks
{
    public bool cambio;
    public GameObject ObjetoACambiar;
    Material Material1;
    public Material original;
    public Material cambiar;
    public Material blanco;

    private int puederestar;
    private int puedesumar;

    public GameObject ObjetoContadorBlanca;
    Control_Blanca control_blanca;


    PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        Material1 = ObjetoACambiar.GetComponent<Renderer>().material;
        cambio = false;
        control_blanca = ObjetoContadorBlanca.GetComponent<Control_Blanca>();
        puedesumar = 1;
        puederestar = 0;
       
    }

    // Update is called once per frame
    [PunRPC]
    void Update()
    {
       // Debug.Log(cambio + "estado del cambio del color, si es true es cambio");

        //base.photonView.RPC("cambiocontrolador", RpcTarget.All);
        Debug.Log(cambio);

       // Debug.Log(control_blanca.contadorBlanca);
      
    }

    [PunRPC]
    void cambiocontrolador()
    {
        if (cambio)
        {
            PhotonView pv = gameObject.GetComponent<PhotonView>();
            Debug.Log("dentro del if");
            Material1.color = cambiar.color;
            pv.RPC("cambiocontroladorotro", RpcTarget.All);

            /* for (int i = 0; i < puedesumar; i++)
             {
                 Debug.Log("estoy dentro de pulsar y sumar uno al contador de blanca");
                 control_blanca.contadorBlanca++;
                 puederestar++;
                 puedesumar--;
                // Debug.Log(puedesumar + "puede sumar");
                 Debug.Log(control_blanca.contadorBlanca + "controlador");
             }*/
        }
        else 
        {
            Material1.color = original.color;

           /* for (int i = 0; i < puederestar; i++)
            {
                Debug.Log("estoy dentro de no pulsar y sumar uno al contador de blanca");
                control_blanca.contadorBlanca--;
                puederestar--;
                puedesumar++;
                Debug.Log(control_blanca.contadorBlanca + " controlador al salir");
            }*/
        }
        
    }

    [PunRPC]
    void cambiocontroladorotro()
    {
        Material1.color = cambiar.color;


    }

    }
