using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;

public class InputHandler : MonoBehaviour
{
    public bool _dash;
    public bool jugadorinteraccion;
    public bool _salto;
    public bool _puedeInteraccionar;
    PhotonView view;
    public float Horizontal => _movement.x;
    public float Vertical => _movement.y;



    Puede_Interaccionar permitido;
     GameObject interaccion;

    Input_player input_player;
    public GameObject input;


    // Start is called before the first frame update
    void Start()
    {

        input = GameObject.FindGameObjectWithTag("Input");
        input_player = input.GetComponent<Input_player>();



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
            input_player._input = !input_player._input;
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






}
