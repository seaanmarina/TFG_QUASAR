using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Input_player : MonoBehaviourPunCallbacks
{

    public GameObject controlador_blanca;
    Control_Blanca controlblanca;
    public bool _puedeInteraccionar;
    public bool _input;
    public bool _jugadorinteraccion;
    bool controlador;
    int contador = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        contador = 1;
        controlador = true;
        controlblanca = controlador_blanca.GetComponent<Control_Blanca>();
        _input = false;
        _puedeInteraccionar = false;
        _jugadorinteraccion = false;
    }


    // Update is called once per frame
    [PunRPC]
    void Update()
    {
        
        if (_puedeInteraccionar)
        {

            _jugadorinteraccion = _input;
            if (_jugadorinteraccion && controlador)
            {
                PhotonView pv = gameObject.GetComponent<PhotonView>();
                pv.RPC("sumarcontador", RpcTarget.All);
                controlador = false;
            }
            else if(!_jugadorinteraccion && controlblanca.contadorBlanca > 0 && !controlador)
            {
                PhotonView pv = gameObject.GetComponent<PhotonView>();
                pv.RPC("restarcontador", RpcTarget.All);
                controlador = true;
            }
            // _cambiodecolor = !_cambiodecolor;
            // Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            //  base.photonView.RPC("cambiodecolor", RpcTarget.All);
            //// Debug.Log(_cambiodecolor);


        }
        else
        {
            _jugadorinteraccion = false;
        }

        //if (_jugadorinteraccion && controlador)
        //{
        //    PhotonView pv = gameObject.GetComponent<PhotonView>();
        //    pv.RPC("sumarcontador", RpcTarget.All);
            
        //}
        //else if(!_jugadorinteraccion && controlblanca.contadorBlanca > 0 && !controlador)
        //{
   
        //    PhotonView pv = gameObject.GetComponent<PhotonView>();
        //    pv.RPC("restarcontador", RpcTarget.All);
            
        //}

    }

    [PunRPC]
        void sumarcontador()
        {
        controlblanca.contadorBlanca = controlblanca.contadorBlanca + contador;
            Debug.Log("Entro Contador=" + controlblanca.contadorBlanca);
           
        

        }

    [PunRPC]
    void restarcontador()
    {
        Debug.Log("Salgo Contador=" + controlblanca.contadorBlanca);
        controlblanca.contadorBlanca = controlblanca.contadorBlanca - 1;
        
        

    }



}
