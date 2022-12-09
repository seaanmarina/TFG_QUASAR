using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Color_Controlador : MonoBehaviourPunCallbacks
{
    public bool cambio;
    public GameObject ObjetoACambiar;
    Material Material1;
    public Material original;
    public Material cambiar;
    public Material blanco;

    private int puederestar;
    private int puedesumar;

    public GameObject ObjetoContadorBlanca;
    Control_Blanca control_blanca;

    // Start is called before the first frame update
    void Start()
    {
        Material1 = ObjetoACambiar.GetComponent<Renderer>().material;
        cambio = false;
        control_blanca = ObjetoContadorBlanca.GetComponent<Control_Blanca>();
        puedesumar = 1;
        puederestar = 0;
    }

    // Update is called once per frame
    [PunRPC]
    void Update()
    {
        Debug.Log(cambio + "estado del cambio del color, si es true es cambio");

        base.photonView.RPC("cambiocontrolador", RpcTarget.All);
      
    }

    [PunRPC]
    void cambiocontrolador()
    {
        if (cambio && (control_blanca.contadorBlanca != 2))
        {
            Material1.color = cambiar.color;
            
            
            for (int i = 0; i < puedesumar; i++)
            {
                control_blanca.contadorBlanca++;
                puederestar++;
                puedesumar--;
            }
        }
        else if(!cambio && (control_blanca.contadorBlanca != 2))
        {
            Material1.color = original.color;

            for (int i = 0; i < puederestar; i++)
            {
                control_blanca.contadorBlanca--;
                puederestar--;
                puedesumar++;
            }
        }
        else if(cambio && (control_blanca.contadorBlanca == 2))
        {
            Material1.color = blanco.color;
        }

        else
        {
            Material1.color = original.color;
        }
    }

}
