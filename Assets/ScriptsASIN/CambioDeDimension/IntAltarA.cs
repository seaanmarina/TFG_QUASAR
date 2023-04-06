using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class IntAltarA : MonoBehaviourPunCallbacks
{
    public GameObject ObjetoACambiar1;
    public GameObject ObjetoACambiar2;
    public GameObject ControlObjeto;

    

    //Puede_Interaccionar puede;
    //public GameObject interaccion;

    InputAltarA input_player;
    public GameObject input;

    InputObjA _inputobj;
    Material Material1;
    public Material original;
    public Material cambio;
    //CambioColorAltarA controladordelcambio;
    InterAltar Altarasincrono;
    PhotonView view;
    PhotonView owner;
    private GameObject objeto;
    // Start is called before the first frame update
    [PunRPC]
    void Start()
    {




        input = GameObject.FindGameObjectWithTag("inputAltar");
        input_player = input.GetComponent<InputAltarA>();

        //player = GameObject.FindGameObjectWithTag("Player");
        //inputhandler = player.GetComponent<InputHandler>();


        //puede = interaccion.GetComponent<Puede_Interaccionar>();


        owner = gameObject.GetComponent<PhotonView>();
        _inputobj = GetComponent<InputObjA>();
        Material1 = ObjetoACambiar1.GetComponent<Renderer>().material;
        //controladordelcambio = GetComponent<CambioColorAltarA>();
        Altarasincrono = GetComponent<InterAltar>();
        view = GetComponent<PhotonView>();

    }





    // Update is called once per frame
    //    void Update()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    inputhandler = player.GetComponent<InputHandler>();
    //}

    [PunRPC]
    private void OnTriggerStay(Collider other)
    {

        if (!input)
        {
            Debug.Log("No se encuentra el input");
        }
        PhotonView phView = other.gameObject.GetComponent<PhotonView>();
        // Debug.Log(owner.Controller.ActorNumber + "es el controlador del objeto");
        //if (phView.IsMine)
        if (PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
        {

            owner.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
            owner.TransferOwnership(PhotonNetwork.LocalPlayer);
            // Debug.Log(owner.Controller.ActorNumber + "es el controlador del objeto" + gameObject.name);
            //   Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber + "id del jugador");

            //if (owner.Controller.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
            //{
            //   Debug.Log("es el mismo");
            //}
            //else
            //{
            //Debug.Log("he entrado en el else");

            // pickup.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player.ID);
            //Debug.Log("no es el mismo id");
            //}

            //if (owner.Controller.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
            ////{
            //{
            //    base.photonView.RPC("CambioColor", RpcTarget.All);

            //}
            PhotonView pv = gameObject.GetComponent<PhotonView>();

            //if () {
            //    // Debug.Log("puede interaccioar");
            input_player._puedeInteraccionar = true;
            //_inputobj._puedeInteraccionar = true;
            PhotonView photonView = PhotonView.Get(this);
            //this.photonView.RPC("prueba", RpcTarget.All);

            //if (_inputobj._cambiodecolor)
            //{
            // controladordelcambio.cambio = _inputobj._cambiodecolor;
            //Debug.Log("estoy interaccoinando a tope de power");
            if(input_player._jugadorinteraccion)
            Altarasincrono.poderPonerseBlanco = 1;


            Altarasincrono.cambio = input_player._jugadorinteraccion;
            //Altarasincrono.cambiocontrolador();
            pv.RPC("cambiocontrolador", RpcTarget.All);
            //this.photonView.RPC("CambioColor", RpcTarget.All);
            //}


            //}


        }
    }



    //[PunRPC]
    //void prueba()
    //{
    //    input_player._puedeInteraccionar = true;

    //    this.photonView.RPC("CambioColor", RpcTarget.All);

    //}




    [PunRPC]
    private void OnTriggerExit(Collider other)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
        {
            input_player._puedeInteraccionar = false;
            Altarasincrono.cambio = false;
        }
    }

    [PunRPC]
    void CambioColor()
    {

        Debug.Log(input_player._puedeInteraccionar + "Puede Interaccionar" + PhotonNetwork.LocalPlayer.ActorNumber);
        Debug.Log(input_player._input + "Input" + PhotonNetwork.LocalPlayer.ActorNumber);
        //if (valor)
        //{

        // controladordelcambio.cambio = input_player._jugadorinteraccion;


        //if (_inputobj._cambiodecolor)
        //{
        //    Debug.Log("estoy dentro del if");
        //    puede._puede = true;
        //    Debug.Log("estoy dentro del if2");
        //    Material1.color = cambio.color;
        //    Debug.Log("estoy dentro del if3");

        //}
        //else
        //{
        //    Material1.color = original.color;
        //}
        //Material1.color = cambio.color;
    }
    //else
    //{
    //    controladordelcambio.cambio = false;
    //    Material1.color = original.color;
    //}
}





//}
