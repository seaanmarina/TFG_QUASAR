using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;

public class InputObj : MonoBehaviourPunCallbacks
{
     Puede_Interaccionar puede;
    GameObject interaccion;

    public bool _puedeInteraccionar;
    public bool _cambiodecolor;
    public bool _prueba;


    // Start is called before the first frame update
    [PunRPC]
    void Start()
    {
        interaccion = GameObject.FindGameObjectWithTag("PUEDE");
        puede = interaccion.GetComponent<Puede_Interaccionar>();


        _puedeInteraccionar = false;
        _cambiodecolor = false;
        _prueba = false;
    }

    // Update is called once per frame
    void Update()
    {
        OnInteraccionarObj();
    }




   [PunRPC]
    void OnInteraccionarObj()
    {
      
         if (_puedeInteraccionar)
            {
                
                        // _cambiodecolor = !_cambiodecolor;
                        // Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
                        base.photonView.RPC("cambiodecolor", RpcTarget.All);
                        //// Debug.Log(_cambiodecolor);


                   
        }
        
           
        

    }

    [PunRPC]
    void cambiodecolor()
    {
        _cambiodecolor = puede._puede;
    }

    void OnPrueba()
    {
        Debug.Log("Se hace la prueba");
        _prueba = true;
    }

}
