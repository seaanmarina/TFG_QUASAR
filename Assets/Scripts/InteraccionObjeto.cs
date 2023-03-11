using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InteraccionObjeto : MonoBehaviourPunCallbacks
{
    public GameObject ObjetoACambiar;
    public GameObject ControlObjeto;

    

    Puede_Interaccionar puede;
    public GameObject interaccion;

    Input_player input_player;
    public GameObject input;

    InputObj _inputobj;
    Material Material1;
    public Material original;
    public Material cambio;
    Color_Controlador controladordelcambio;
    PhotonView view;
    PhotonView owner;
    private GameObject objeto;
    // Start is called before the first frame update
    [PunRPC]
    void Start()
    {
        



        input = GameObject.FindGameObjectWithTag("Input");
        input_player = input.GetComponent<Input_player>();

        //player = GameObject.FindGameObjectWithTag("Player");
        //inputhandler = player.GetComponent<InputHandler>();


        puede = interaccion.GetComponent<Puede_Interaccionar>();


        owner = gameObject.GetComponent<PhotonView>();
        _inputobj = GetComponent<InputObj>();
        Material1 = ObjetoACambiar.GetComponent<Renderer>().material;
        controladordelcambio = GetComponent<Color_Controlador>();
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
        PhotonView phView = other.gameObject.GetComponent<PhotonView>();
        // Debug.Log(owner.Controller.ActorNumber + "es el controlador del objeto");
        //if (phView.IsMine)
        if(PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
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

            controladordelcambio.cambio = input_player._jugadorinteraccion;
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
        input_player._puedeInteraccionar = false;
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
