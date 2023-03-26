using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InputAltarA : MonoBehaviourPunCallbacks
{

    public GameObject controlador_blanca;
    Control_BlancaA controlblanca;
    public bool _puedeInteraccionar;
    public bool _input;
    public bool _jugadorinteraccion;
    bool controlador;
    int contador = 0;


    public bool interaccionAzul;
    public bool interaccionNaranja;
    public bool PuedeChange;

    // Start is called before the first frame update
    void Start()
    {
        interaccionAzul = false;
        interaccionNaranja = false;
        PuedeChange = false;


        contador = 1;
        controlador = true;
        controlblanca = controlador_blanca.GetComponent<Control_BlancaA>();
        _input = false;
        _puedeInteraccionar = false;
        _jugadorinteraccion = false;
    }


    // Update is called once per frame
    [PunRPC]
    void Update()
    {

        if(interaccionAzul && interaccionNaranja)
        {
            PuedeChange = true;
        }
        else
        {
            PuedeChange = false;
        }



        if (_puedeInteraccionar)
        {

            _jugadorinteraccion = _input;
            if (_jugadorinteraccion && controlador)
            {
                PhotonView pv = gameObject.GetComponent<PhotonView>();
                pv.RPC("sumarcontador", RpcTarget.All);
                controlador = false;
            }
            //else if (!_jugadorinteraccion && controlblanca.mantenerAltar > 0 && !controlador)
            //{
            //    PhotonView pv = gameObject.GetComponent<PhotonView>();
            //    pv.RPC("restarcontador", RpcTarget.All);
            //    controlador = true;
            //}
            //_cambiodecolor = !_cambiodecolor;
            //Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            //base.photonView.RPC("cambiodecolor", RpcTarget.All);
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
       
        Debug.Log("Entro Contador=" + controlblanca.mantenerAltar);
        StartCoroutine(sumarcontadorasinaltar());



    }

    [PunRPC]
    IEnumerator sumarcontadorasinaltar()
    {

       
            controlblanca.mantenerAltar = controlblanca.mantenerAltar + 1;
            yield return new WaitForSeconds(5);
            controlblanca.mantenerAltar = controlblanca.mantenerAltar - 1;
            controlador = true;
        
    }



        [PunRPC]
    void restarcontador()
    {
        Debug.Log("Salgo Contador=" + controlblanca.mantenerAltar);
        controlblanca.mantenerAltar = controlblanca.mantenerAltar - 1;



    }



}
