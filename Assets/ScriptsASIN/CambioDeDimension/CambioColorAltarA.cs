using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CambioColorAltarA : MonoBehaviourPunCallbacks
{
    public bool cambio;
    public GameObject ObjetoACambiar1;
    public GameObject ObjetoACambiar2;


    public GameObject cambiodeposicion;

    Material Material1;
    Material Material2;
    public Material original;
    public Material cambiar;
    public bool mantener;

    private int puederestar;
    private int puedesumar;

    private bool alreadyExited;


    CambioDimensionA cambio_Dimension;
    public GameObject change;


    public GameObject controlador_blanca;
    Control_BlancaA controlblanca;




    PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {

        alreadyExited = false;

        change = GameObject.FindGameObjectWithTag("CambioDimension");
        cambio_Dimension = change.GetComponent<CambioDimensionA>();


        controlblanca = controlador_blanca.GetComponent<Control_BlancaA>();
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
        //if (!cambio && !mantener)
        //{
        //    PhotonView pv = gameObject.GetComponent<PhotonView>();

        //    pv.RPC("cambiocontrolador", RpcTarget.All);
        //}
        // Debug.Log(cambio + "estado del cambio del color, si es true es cambio");

        //base.photonView.RPC("cambiocontrolador", RpcTarget.All);
        // Debug.Log(cambio);

        // Debug.Log(control_blanca.contadorBlanca);

    }

    [PunRPC]
    void OnTriggerStay(Collider other)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
        {
            if (mantener)
            {
                cambio_Dimension.puedeintCambiar = true;
                if (cambio_Dimension.permitidoCambiar)
                {
                    //other.transform.position = new Vector3(0, 0, 0);
                    other.transform.position = cambiodeposicion.transform.position;
                    cambio_Dimension.permitidoCambiar = false;
                    //cambio = false;
                    //mantener = false;
                    Debug.Log("Estoy dentro de if de mantener");
                    PhotonView pv = gameObject.GetComponent<PhotonView>();
                    pv.RPC("llamarcorutina", RpcTarget.All);
                }
            }
            else
            {
                cambio_Dimension.puedeintCambiar = false;
                Debug.Log("Estoy dentro de else mantener");
            }

           


        }

        }
    [PunRPC]
    void llamarcorutina()
    {
        PhotonView pv = gameObject.GetComponent<PhotonView>();
        StartCoroutine("Espera");
    }



    [PunRPC]
    IEnumerator Espera()
    {
        while (mantener == true)
        {
            yield return null;
        }

        cambio = false;
        mantener = false;
        PhotonView pv = gameObject.GetComponent<PhotonView>();
        pv.RPC("cambiocontrolador", RpcTarget.All);


    }




    //[PunRPC]
    // void OnTriggerExit(Collider other)
    //{
    //    cambio_Dimension.puedeintCambiar = false;

    //    if (PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
    //    {
    //        //mantener = false;
    //        //cambio = false;
    //        Debug.Log("Estoy fuera de trigger de mantener" + gameObject);

    //        //if (!alreadyExited)
    //        //{
    //        PhotonView pv = gameObject.GetComponent<PhotonView>();
    //        pv.RPC("EjecutarTriggerExitRPC", RpcTarget.All);
    

    //        //    alreadyExited = true;
    //        //}
    //    }
    //}

    //[PunRPC]
    //void EjecutarTriggerExitRPC()
    //{
    //    //mantener = false;
    //    //cambio = false;
    //    // Llama a la función OnTriggerExit en todos los clientes
    //    PhotonView pv = gameObject.GetComponent<PhotonView>();
    //    pv.RPC("cambiocontrolador", RpcTarget.All);

    //}



    [PunRPC]
    void cambiocontrolador()
    {
        if (controlblanca.mantenerAltar >= 2 || mantener==true)
        {
            mantener = true;
            //Debug.Log(mantener + "HA ENRTADO EN EL COLOR BLANCO");
            Debug.Log("Estoy dentro de empezar corrutina");

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

                Debug.Log("Estoy dentro de else normal mantener" + gameObject.name);
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
        Debug.Log("Estoy dentro del cambio de color por el cambio");

    }




    [PunRPC]
    void cambiocontroladorblanco()
    {
        
        //Material1.color = cambiar.color;
        //Material2.color = cambiar.color;
        Debug.Log("Estoy dentro del cambio a blanco");
        
        PhotonView pv = gameObject.GetComponent<PhotonView>();
        pv.RPC("iniciarcorrutina", RpcTarget.All);
        

    }

    [PunRPC]
    void iniciarcorrutina()
    {
        Debug.Log("Estoy dentro de llamar corrutina");
        StartCoroutine("Mantener");
    }


    [PunRPC]
    IEnumerator Mantener()
    {
        if (mantener)
        {
            Debug.Log("Estoy dentro de Mantener corrutina");
            float timer = 0;
            timer += Time.deltaTime;
            float waitTime = 5.0f;
            Debug.Log(mantener + "HA ENRTADO EN EL COLOR BLANCO MANTENER");
            Material1.color = cambiar.color;
            Material2.color = cambiar.color;
            Debug.Log("He entrado en la FUNCION DE MANTENER");
            float startTime = Time.time;
            while ((Time.time < startTime + 5.0f) && mantener == true)
            //while ((timer> waitTime) && mantener==true)
            {
                Debug.Log("Time.time" + mantener);
                Debug.Log(Time.time);
                yield return null;
            }
            //yield return new WaitForSeconds(5); NO VA
            Debug.Log("YA HAAN PASADO LOS 10 SEGUNDOS WACHOOOO");
            mantener = false;
        }


    }





}
