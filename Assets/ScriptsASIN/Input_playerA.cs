using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Input_playerA : MonoBehaviourPunCallbacks
{
    Puede_InteraccionarA permitido;
    GameObject interaccion;

    public bool sigueblanca;


    public GameObject controlador_blanca;
    Control_BlancaA controlblanca;
    public bool _puedeInteraccionar;
    public bool _input;
    public bool _jugadorinteraccion;
    public bool controlador;
    int contador = 0;
    bool contadorTiempo;

    public bool cambiodetiempo;

    // Start is called before the first frame update
    void Start()
    {
        cambiodetiempo = false;

        sigueblanca = false;
        contadorTiempo = false;

        interaccion = GameObject.FindGameObjectWithTag("Interaccion");
        permitido = interaccion.GetComponent<Puede_InteraccionarA>();

        contador = 1;
        controlador = true;
        controlblanca = controlador_blanca.GetComponent<Control_BlancaA>();
        _input = false;
        _puedeInteraccionar = false;
        _jugadorinteraccion = false;
    }

    [PunRPC]
    void Controladortimer(bool valor)
    {
       
        if (valor && !contadorTiempo)
        {
            Debug.Log("en la parte de input");
            permitido.timer = Time.time;
            contadorTiempo = true;

        }
        if (contadorTiempo && !valor)
        {
            permitido.timer2 = Time.time;
            contadorTiempo = false;
            permitido.tiempototal = permitido.timer2 - permitido.timer;
        }
    }







    // Update is called once per frame
    [PunRPC]
    void Update()
    {
        Debug.Log("Cambio de tiempo" + cambiodetiempo);
        if (cambiodetiempo)
        {
            Debug.Log("Pico pala aqui estoy");
            StopAllCoroutines();
            controlblanca.contadorAsin = 0;
            cambiodetiempo = false;
            
            Debug.Log("Estoy en Cambiodetiempo");
            permitido.tiempototal = 0;
        }


        if (_puedeInteraccionar)
        {
            // while (_input == true)
            //{

            //   permitido.timer += Time.deltaTime;
            // }

            //if (_input)
            //{
            //    PhotonView pv = gameObject.GetComponent<PhotonView>();
            //    pv.RPC("Controladortimer", RpcTarget.All, true);
            //}
            //else
            //{
            //    PhotonView pv = gameObject.GetComponent<PhotonView>();
            //    pv.RPC("Controladortimer", RpcTarget.All, false);
            //}



            
            _jugadorinteraccion = _input;
            if (_jugadorinteraccion && controlador)
            {
               
                PhotonView pv = gameObject.GetComponent<PhotonView>();
                pv.RPC("Controladortimer", RpcTarget.All, true);


                Debug.Log("Interaccion");
                pv.RPC("sumarcontador", RpcTarget.All);
                controlador = false;
                Debug.Log("Estoy en _jugadorinteraccion");
            }
            else if(!_jugadorinteraccion && !controlador)
            {
                PhotonView pv = gameObject.GetComponent<PhotonView>();
                pv.RPC("Controladortimer", RpcTarget.All, false);
                
                Debug.Log("Estoy en !_jugadorinteraccion");
            }
            //else if(!_jugadorinteraccion && controlblanca.contadorBlanca > 0 && !controlador)
            //{

            //    PhotonView pv = gameObject.GetComponent<PhotonView>();
            //    pv.RPC("restarcontador", RpcTarget.All);
            //    controlador = true;
            //}
            // _cambiodecolor = !_cambiodecolor;
            // Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            //  base.photonView.RPC("cambiodecolor", RpcTarget.All);
            //// Debug.Log(_cambiodecolor);
            Debug.Log("Estoy en PuedeInteraccionar");

        }
        //else
        //{
        //    //PhotonView pv = gameObject.GetComponent<PhotonView>();
        //    //pv.RPC("Controladortimer", RpcTarget.All, false);
        //    _jugadorinteraccion = false;
        //}

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
    IEnumerator sumarcontadorasin ()
    {

        Debug.Log("Estoy en sumarcontadorasin antes");
        while (permitido.tiempototal == 0)
        {
            Debug.Log("No tengo tiempo de inicio");
            yield return null;
        }
        //controlblanca.contadorAsin = controlblanca.contadorAsin + 1;
        //if (sigueblanca)
        //    StopCoroutine(sumarcontadorasin());

        float tiempo = permitido.tiempototal * 5 + 3.5f * 2;


        controlblanca.contadorAsin = controlblanca.contadorAsin + 1;


        Debug.Log("Estoy en _jugadorinteraccion despues");
        // Debug.Log("Entro Contador=" + tiempo);
        yield return new WaitForSeconds(tiempo);
            controlblanca.contadorAsin = controlblanca.contadorAsin + -1;
        controlador = true;

        permitido.tiempototal = 0;
        Debug.Log("Estoy en saliendo");
    }



    [PunRPC]
        void sumarcontador()
        {
        //controlblanca.contadorAsin = controlblanca.contadorAsin + 1;
        //     Debug.Log("Entro Contador=" + controlblanca.contadorBlanca);
        StartCoroutine(sumarcontadorasin());

        Debug.Log("Estoy en sumarcontador");

    }

    

}
