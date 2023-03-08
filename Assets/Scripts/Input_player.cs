using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Input_player : MonoBehaviourPunCallbacks
{
    public bool _puedeInteraccionar;
    public bool _input;
    public bool _jugadorinteraccion;
   
    // Start is called before the first frame update
    void Start()
    {
        
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
            // _cambiodecolor = !_cambiodecolor;
            // Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            //  base.photonView.RPC("cambiodecolor", RpcTarget.All);
            //// Debug.Log(_cambiodecolor);


        }
        else
        {
            _jugadorinteraccion = false;
        }




    }
}
