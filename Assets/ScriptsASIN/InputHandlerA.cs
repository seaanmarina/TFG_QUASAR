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









    Puede_InteraccionarA permitido;
     GameObject interaccion;

    Input_playerA input_player;
    public GameObject input;

    CambioDimensionA cambio_Dimension;
    public GameObject change; 


     InputAltarA input_Altar;
    public GameObject inputaltar;


    // Start is called before the first frame update
    void Start()
    {
        interaccion = GameObject.FindGameObjectWithTag("Interaccion");
        permitido = interaccion.GetComponent<Puede_InteraccionarA>();


        change = GameObject.FindGameObjectWithTag("CambioDimension");
        cambio_Dimension = change.GetComponent<CambioDimensionA>();


        contador = false;

        input = GameObject.FindGameObjectWithTag("Input");
        input_player = input.GetComponent<Input_playerA>();

        inputaltar = GameObject.FindGameObjectWithTag("inputAltar");
        input_Altar = inputaltar.GetComponent<InputAltarA>();

        _salto = false;
        view = GetComponent<PhotonView>();
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

            //if (!input_player._input)
            //{
            //    permitido.timer = 0;
            //}

            input_player._input = !input_player._input;
            input_Altar._input = !input_Altar._input;

            contador = !contador;
            //if (input_player._puedeInteraccionar)
            //{
            //    if (input_player._input && !contador)
            //    {
            //        permitido.timer = Time.time;
            //        contador = true;

            //    }
            //    if (contador && !input_player._input)
            //    {
            //        permitido.timer2 = Time.time;
            //        contador = false;
            //        permitido.tiempototal = permitido.timer2 - permitido.timer;
            //    }
            //}
         //   cambio_Dimension.permitidoCambiar = !cambio_Dimension.permitidoCambiar;
        }


        //if (_puedeInteraccionar && view.IsMine)
        //{

        //    jugadorinteraccion = !jugadorinteraccion;
        //    // _cambiodecolor = !_cambiodecolor;
        //    // Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
        //    //  base.photonView.RPC("cambiodecolor", RpcTarget.All);
        //    //// Debug.Log(_cambiodecolor);


        //}




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






}
