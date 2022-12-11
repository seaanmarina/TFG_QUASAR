using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InteraccionObjeto : MonoBehaviourPunCallbacks
{
    public GameObject ObjetoACambiar;
    public GameObject ControlObjeto;
    
    InputObj _inputobj;
    Material Material1;
    public Material original;
    public Material cambio;
    Color_Controlador controladordelcambio;
    PhotonView view;
    PhotonView owner;
    private GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        owner = GetComponent<PhotonView>();
        _inputobj = GetComponent<InputObj>();
        Material1 = ObjetoACambiar.GetComponent<Renderer>().material;
        controladordelcambio = GetComponent<Color_Controlador>();
        view = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    private void OnTriggerStay(Collider other)
    {
       // Debug.Log(owner.Controller.ActorNumber + "es el controlador del objeto");
            if (other.tag == "Player")
            {
            Debug.Log(owner.Controller.ActorNumber + "es el controlador del objeto");
            Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber + "id del jugador");

            if (owner.Controller.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
            {
               // Debug.Log("es el mismo");
            }
            else
            {
                owner.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
                // pickup.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player.ID);
                //Debug.Log("no es el mismo id");
            }


            //if () {
            //    // Debug.Log("puede interaccioar");
            //    _inputobj._puedeInteraccionar = true;

            //    //if (_inputobj._cambiodecolor)
            //    //{
            //    // controladordelcambio.cambio = _inputobj._cambiodecolor;
            //    //Debug.Log("estoy interaccoinando a tope de power");
            //    base.photonView.RPC("CambioColor", RpcTarget.All);
            //    //}


            //}


        }
    }

    private void OnTriggerExit(Collider other)
    {
        _inputobj._puedeInteraccionar = false;
    }

    [PunRPC]
    void CambioColor()
    {
        //if (valor)
        //{

        controladordelcambio.cambio = _inputobj._cambiodecolor;


        //if (controladordelcambio.cambio )
        //{
        //    Debug.Log("estoy dentro del if");
        //    Material1.color = cambio.color;

        //}
        //else
        //{
        //    Material1.color = original.color;
        //}
        // Material1.color = cambio.color;
        //}
        //else
        //{
        //    controladordelcambio.cambio = false;
        //    Material1.color = original.color;
        //}
    }





}
