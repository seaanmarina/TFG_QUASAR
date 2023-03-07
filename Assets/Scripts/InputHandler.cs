using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;

public class InputHandler : MonoBehaviour
{
    public bool _dash;
    public bool _salto;
    public bool _puedeInteraccionar;
    PhotonView view;
    public float Horizontal => _movement.x;
    public float Vertical => _movement.y;



    Puede_Interaccionar permitido;
     GameObject interaccion;




    // Start is called before the first frame update
    void Start()
    {
        interaccion = GameObject.FindGameObjectWithTag("PUEDE");
        permitido = interaccion.GetComponent<Puede_Interaccionar>();




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



    void OnInteraccionar()
    {
        if (!view.IsMine) {
            permitido._puede = !permitido._puede;
            _puedeInteraccionar = !_puedeInteraccionar;


        }
           




    }






}
