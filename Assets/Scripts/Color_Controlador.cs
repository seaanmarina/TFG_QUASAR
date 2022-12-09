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

    // Start is called before the first frame update
    void Start()
    {
        Material1 = ObjetoACambiar.GetComponent<Renderer>().material;
        cambio = false;
    }

    // Update is called once per frame
    [PunRPC]
    void Update()
    {
        Debug.Log(cambio + "estado del cambio del color, si es true es cambio");

        base.photonView.RPC("cambiocontrolador", RpcTarget.All);
      
    }

    [PunRPC]
    void cambiocontrolador()
    {
        if (cambio)
        {
            Material1.color = cambiar.color;
        }
        else
        {
            Material1.color = original.color;
        }
    }

}
