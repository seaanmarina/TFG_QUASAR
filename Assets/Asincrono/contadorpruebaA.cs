using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class contadorpruebaA : MonoBehaviourPunCallbacks
{

    private int contadordelaprueba;
    public GameObject prueba;
    InputObj _pruebacontrolador;
    // Start is called before the first frame update
    void Start()
    {
        contadordelaprueba = 0;
        _pruebacontrolador = prueba.GetComponent<InputObj>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   


   [PunRPC]
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (_pruebacontrolador._prueba)
            {
                Debug.Log("clicada la opcion");
                base.photonView.RPC("Contador", RpcTarget.All);

                
            }
        }
    }
      


    [PunRPC]
    void Contador()
    {
        Debug.Log("personaje dentro");
        contadordelaprueba++;
        Debug.Log(contadordelaprueba);
    }
}
