using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;

public class InputObj : MonoBehaviourPunCallbacks
{
   
    public bool _puedeInteraccionar;
    public bool _cambiodecolor;
    public bool _prueba;


    // Start is called before the first frame update
    void Start()
    {
        _puedeInteraccionar = false;
        _cambiodecolor = false;
        _prueba = false;
    }

    // Update is called once per frame
    void Update()
    {

    }




   [PunRPC]
    void OnInteraccionar()
    {
        if (_puedeInteraccionar )
        {
           // _cambiodecolor = !_cambiodecolor;
            Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            base.photonView.RPC("cambiodecolor", RpcTarget.All);
           // Debug.Log(_cambiodecolor);


        }
        
           
        

    }

    [PunRPC]
    void cambiodecolor()
    {
        _cambiodecolor = !_cambiodecolor;
    }

    void OnPrueba()
    {
        Debug.Log("Se hace la prueba");
        _prueba = true;
    }

}
