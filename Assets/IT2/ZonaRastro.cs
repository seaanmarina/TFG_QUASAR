using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ZonaRastro : MonoBehaviourPunCallbacks
{

    public GameObject GamecontadorRastro;
    ContadorRastro ObjetocontadorRastro;

    public bool interaccionAzul;

    public int zona;

    private bool sumar;
    // Start is called before the first frame update
    void Start()
    {
        sumar = true;
        ObjetocontadorRastro = GamecontadorRastro.GetComponent<ContadorRastro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        PhotonView phView = other.gameObject.GetComponent<PhotonView>();
        // Debug.Log(owner.Controller.ActorNumber + "es el controlador del objeto");
        //if (phView.IsMine)
        if (PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
        {
            Debug.Log("Estoy dentro");



            PhotonView pv = gameObject.GetComponent<PhotonView>();

            pv.RPC("SumarContadorRastro", RpcTarget.All);
        }


    }


    private void OnTriggerExit(Collider other)
    {
        PhotonView phView = other.gameObject.GetComponent<PhotonView>();
        // Debug.Log(owner.Controller.ActorNumber + "es el controlador del objeto");
        //if (phView.IsMine)
        if (PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
        {

            PhotonView pv = gameObject.GetComponent<PhotonView>();

            pv.RPC("RestarContadorRastro", RpcTarget.All);
        }


    }

    [PunRPC]
    void SumarContadorRastro()
    {
        if (sumar)
        {
            if (interaccionAzul)
            {
                ObjetocontadorRastro.interaccionAzul = true;
                //ObjetocontadorRastro.zonaAzul = zona;
            }
            else
            {
                ObjetocontadorRastro.interaccionNaranja = true;
                //ObjetocontadorRastro.zonaNaranja = zona;
            }

            ObjetocontadorRastro.contadorRastroLuz++;
            sumar = false;
        }
    }



    [PunRPC]
    void RestarContadorRastro()
    {
        if (!sumar)
        {
            if (interaccionAzul)
                ObjetocontadorRastro.interaccionAzul = false;
            else
                ObjetocontadorRastro.interaccionNaranja = false;

            ObjetocontadorRastro.contadorRastroLuz--;
            sumar = true;
        }
      

    }



}
