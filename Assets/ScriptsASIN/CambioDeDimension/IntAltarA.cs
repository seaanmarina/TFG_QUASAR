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

    bool hacer;

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


    public GameObject intermedioBlanco;
    PonerseBlancoComunicacion intermediario;


    // Start is called before the first frame update
    [PunRPC]
    void Start()
    {

        hacer = true;

        intermediario = intermedioBlanco.GetComponent<PonerseBlancoComunicacion>();


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


            int actorNr = other.GetComponent<PhotonView>().Owner.ActorNumber;
            int viewId = actorNr * PhotonNetwork.MAX_VIEW_IDS + 1;

            //Debug.Log("INTERACCIOOOOONNNN " + viewId);

            if(intermediario.poderPonerseBlanco == 0 && !hacer)
            {///CUANDO PARE LO DE BLANCO, ESTO SE PONDRÁ EN 0, POR LO QUE HARA QUE LAS BOLEANAS
                //DE  LOS JUGADORES SE PONGAN EN FALSE PARA QUE TENGAN QUE SER ACTIVADAS SI SE VUELVE 
                // A INTERACCIONAR
                
                pv.RPC("Desactive", RpcTarget.All, viewId);
            }

            bool nocambioActivar = true;
            if (input_player._jugadorinteraccion && hacer)
                pv.RPC("VariableJugador", RpcTarget.All, viewId);
            //if (input_player._jugadorinteraccion && nocambioActivar)
            //{
            //    Altarasincrono.nocambio = false;
            //    nocambioActivar = false;
            //}
            //else if(!input_player._jugadorinteraccion && !nocambioActivar)
            //{
                
            //    nocambioActivar = true;
            //}

            //if (input_player._jugadorinteraccion)
            //    intermediario.poderPonerseBlanco = 1;

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
    void VariableJugador(int id)
    {

        intermediario.poderPonerseBlanco = 1;
        PhotonView pvv = PhotonView.Find(id); // obtiene el PhotonView del jugador remoto
            GameObject playerGO = pvv.gameObject;
            RecogerVariablesJugador playerController = playerGO.GetComponent<RecogerVariablesJugador>();
            playerController.booleanaPonerseBlanco = true;
             hacer = false;



    }


    [PunRPC]
    void Desactive(int id)
    {

        PhotonView pvv = PhotonView.Find(id); // obtiene el PhotonView del jugador remoto
        GameObject playerGO = pvv.gameObject;
        RecogerVariablesJugador playerController = playerGO.GetComponent<RecogerVariablesJugador>();
        playerController.booleanaPonerseBlanco = false;
        hacer = true;


    }


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
