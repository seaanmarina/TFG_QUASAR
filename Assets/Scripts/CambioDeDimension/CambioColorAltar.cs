using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CambioColorAltar : MonoBehaviourPunCallbacks
{
    public bool cambio;
    public GameObject ObjetoACambiar1;
    public GameObject ObjetoACambiar2;
    Material Material1;
    Material Material2;
    public Material original;
    public Material cambiar;

    private int puederestar;
    private int puedesumar;



    public GameObject controlador_blanca;
    Control_Blanca controlblanca;




    PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {

        controlblanca = controlador_blanca.GetComponent<Control_Blanca>();


        Material1 = ObjetoACambiar1.GetComponent<Renderer>().material;
        Material2 = ObjetoACambiar2.GetComponent<Renderer>().material;

        cambio = false;

        puedesumar = 1;
        puederestar = 0;

    }

    // Update is called once per frame
    [PunRPC]
    void Update()
    {
        // Debug.Log(cambio + "estado del cambio del color, si es true es cambio");

        //base.photonView.RPC("cambiocontrolador", RpcTarget.All);
        // Debug.Log(cambio);

        // Debug.Log(control_blanca.contadorBlanca);

    }

    [PunRPC]
    void cambiocontrolador()
    {
        if (controlblanca.mantenerAltar >= 2)
        {
            Debug.Log("HA ENRTADO EN EL COLOR BLANCO");

            PhotonView pv = gameObject.GetComponent<PhotonView>();
   
            pv.RPC("cambiocontroladorblanco", RpcTarget.All);

        }
        else
        {



            if (cambio)
        {
            PhotonView pv = gameObject.GetComponent<PhotonView>();
            //  Debug.Log("dentro del if");
            Material1.color = cambiar.color;
            Material2.color = cambiar.color;
            pv.RPC("cambiocontroladorotro", RpcTarget.All);

            /* for (int i = 0; i < puedesumar; i++)
             {
                 Debug.Log("estoy dentro de pulsar y sumar uno al contador de blanca");
                 control_blanca.contadorBlanca++;
                 puederestar++;
                 puedesumar--;
                // Debug.Log(puedesumar + "puede sumar");
                 Debug.Log(control_blanca.contadorBlanca + "controlador");
             }*/
        }
        else
        {
            Material1.color = original.color;
            Material2.color = original.color;

            /* for (int i = 0; i < puederestar; i++)
             {
                 Debug.Log("estoy dentro de no pulsar y sumar uno al contador de blanca");
                 control_blanca.contadorBlanca--;
                 puederestar--;
                 puedesumar++;
                 Debug.Log(control_blanca.contadorBlanca + " controlador al salir");
             }*/

        }

    }
}

    [PunRPC]
    void cambiocontroladorotro()
    {
        Material1.color = cambiar.color;
        Material2.color = cambiar.color;


    }




    [PunRPC]
    void cambiocontroladorblanco()
    {
        Material1.color = cambiar.color;
        Material2.color = cambiar.color;
        Debug.Log("He entrado en el cambiocontrolador  BLANCO");
        PhotonView pv = gameObject.GetComponent<PhotonView>();
        pv.RPC("Mantener", RpcTarget.All);

    }


    [PunRPC]
    IEnumerator Mantener()
    {
        Material1.color = cambiar.color;
        Material2.color = cambiar.color;
        Debug.Log("He entrado en la FUNCION DE MANTENER");
        yield return new WaitForSeconds(10f);
        Debug.Log("YA HAAN PASADO LOS 10 SEGUNDOS WACHOOOO");
        Material1.color = original.color;
        Material2.color = original.color;
    }





}
