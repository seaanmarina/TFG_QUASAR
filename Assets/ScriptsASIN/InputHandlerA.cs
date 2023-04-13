using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;

public class InputHandlerA : MonoBehaviour
{
    public bool _dash;
    private bool contador;
    public bool jugadorinteraccion;
    public bool _salto;
    public bool _puedeInteraccionar;
    PhotonView view;
    public float Horizontal => _movement.x;
    public float Vertical => _movement.y;

    public GameObject controlinputs;
    InputsAltar  AltarInputs;


    public bool saltoControlado;

    public bool InteraccionCambio;
    public bool puedeInteraccion;


    Puede_InteraccionarA permitido;
     GameObject interaccion;

    Input_Objetos input_player;
    public GameObject input;

    CambioDimensionA cambio_Dimension;
    public GameObject change; 


     InputAltarA input_Altar;
    public GameObject inputaltar;


    


    // Start is called before the first frame update
    void Start()
    {
        InteraccionCambio = false;

        puedeInteraccion = false;

         interaccion = GameObject.FindGameObjectWithTag("Interaccion");
        
        permitido = interaccion.GetComponent<Puede_InteraccionarA>();


        controlinputs = GameObject.FindGameObjectWithTag("AltarInputs");
        AltarInputs = controlinputs.GetComponent<InputsAltar>();
        
        change = GameObject.FindGameObjectWithTag("CambioDimension");
        cambio_Dimension = change.GetComponent<CambioDimensionA>();


        contador = false;

        input = GameObject.FindGameObjectWithTag("Input");
        input_player = input.GetComponent<Input_Objetos>();

        inputaltar = GameObject.FindGameObjectWithTag("inputAltar");
        input_Altar = inputaltar.GetComponent<InputAltarA>();

        _salto = false;
        view = GetComponent<PhotonView>();



        saltoControlado = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 _movement;
    void OnMove(InputValue inputValue)
    {
      //  Debug.Log("hola");
        _movement = inputValue.Get<Vector2>();
       // Debug.Log(_movement);

    }


    void OnJump() {
       // Debug.Log("salto");
        _salto = true;
    }

    void OnDash()
    {
        Debug.Log("dash");
        _dash = true;
    }


    [PunRPC]
    void OnInteraccionar()
    {
        
        if (view.IsMine)
        {
            PhotonView pv = gameObject.GetComponent<PhotonView>();
            InteraccionCambio = !InteraccionCambio;
            //if (!input_player._input)
            //{
            //    permitido.timer = 0;
            //}

            AltarInputs._input = !input_player._input;

            input_player._input = !input_player._input;
            input_Altar._input = !input_Altar._input;

            contador = !contador;

            if (puedeInteraccion)
            {

                pv.RPC("InteraccionPlayer", RpcTarget.All, InteraccionCambio);

            }

        }


       



    }
 [PunRPC]
        void InteraccionPlayer(bool valor)
        {
            
            int actorNr = view.OwnerActorNr;
            int viewId = actorNr * PhotonNetwork.MAX_VIEW_IDS + 1;


            Debug.Log("INPUT HANDLER A TOPEEEEEEEEE" + viewId);

            PhotonView pvv = PhotonView.Find(viewId); // obtiene el PhotonView del jugador remoto
            GameObject playerGO = pvv.gameObject;
            RecogerVariablesJugador playerController = playerGO.GetComponent<RecogerVariablesJugador>();
            playerController.InteraccionInputHandler = valor;

    }

    void OnInteraccionarCambio()
    {
        if (view.IsMine)
        {
            if (cambio_Dimension.puedeintCambiar)
            {
                cambio_Dimension.permitidoCambiar = true;
            }
           
        }
    }



    void OnSalto()
    {

        saltoControlado = !saltoControlado;
        Debug.Log("Salto Controlado es " + saltoControlado);

    }






}
