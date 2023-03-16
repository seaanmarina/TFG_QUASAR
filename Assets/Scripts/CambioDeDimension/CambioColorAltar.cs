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
    public bool mantener;

    private int puederestar;
    private int puedesumar;



    public GameObject controlador_blanca;
    Control_Blanca controlblanca;




    PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {

        controlblanca = controlador_blanca.GetComponent<Control_Blanca>();
        mantener = false;

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
        if (controlblanca.mantenerAltar >= 2 || mantener==true)
        {
            mantener = true;
            Debug.Log(mantener + "HA ENRTADO EN EL COLOR BLANCO");

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

                Debug.Log("Cambio else");
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
        Debug.Log("Cambio colorrr");

    }




    [PunRPC]
    void cambiocontroladorblanco()
    {
        
        //Material1.color = cambiar.color;
        //Material2.color = cambiar.color;
        Debug.Log("He entrado en el cambiocontrolador  BLANCO");
        
        PhotonView pv = gameObject.GetComponent<PhotonView>();
        pv.RPC("iniciarcorrutina", RpcTarget.All);
        

    }

    [PunRPC]
    void iniciarcorrutina()
    {
        StartCoroutine("Mantener");
    }


    [PunRPC]
    IEnumerator Mantener()
    {
        if (mantener)
        {
            float timer = 0;
            timer += Time.deltaTime;
            float waitTime = 5.0f;
            Debug.Log(mantener + "HA ENRTADO EN EL COLOR BLANCO MANTENER");
            Material1.color = cambiar.color;
            Material2.color = cambiar.color;
            Debug.Log("He entrado en la FUNCION DE MANTENER");
            float startTime = Time.time;
            while ((Time.time < startTime + 5.0f) && mantener==true)
           //while ((timer> waitTime) && mantener==true)
            {
                Debug.Log("Time.time" + mantener);
                Debug.Log(Time.time);
                yield return null;
            }
            Debug.Log("YA HAAN PASADO LOS 10 SEGUNDOS WACHOOOO");
            mantener = false;
        }


    }





}
