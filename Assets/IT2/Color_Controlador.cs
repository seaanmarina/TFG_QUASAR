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


    public GameObject CuboPrincipal;
    ParticleSystem sistema;


    public Color Blanco;
    public Color Actualizado;
    public Color Original;


    public GameObject controlador_blanca;
    Control_BlancaA controlblanca;

    public GameObject ObjetoContadorBlanca;
    Control_BlancaA control_blanca;


    PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {

        sistema = CuboPrincipal.GetComponent<ParticleSystem>();
        sistema.startSize = 0;


        controlblanca = controlador_blanca.GetComponent<Control_BlancaA>();

       
        Material1 = ObjetoACambiar.GetComponent<Renderer>().material;
        Actualizado = Material1.GetColor("_EmissionColor");
        Material1.DisableKeyword("_EMISSION");


      // original = CuboPrincipal.GetComponent<Renderer>().material;
       // Original = original.GetColor("_EmissionColor");

        cambio = false;
        control_blanca = ObjetoContadorBlanca.GetComponent<Control_BlancaA>();
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
        if (controlblanca.contadorBlanca >= 2)
        {
            Debug.Log("HA ENRTADO EN EL COLOR BLANCO");

            PhotonView pv = gameObject.GetComponent<PhotonView>();
            //  Debug.Log("dentro del if");
            Material1.color = blanco.color;
            sistema.startSize = 0.1f;
            pv.RPC("cambiocontroladorblanco", RpcTarget.All);

        }
        else
        {



            if (cambio)
            {
                PhotonView pv = gameObject.GetComponent<PhotonView>();
                //  Debug.Log("dentro del if");
               Material1.color = cambiar.color;
                sistema.startSize = 0.1f;
                // Material1.SetColor("_EmissionColor", Actualizado);  //LO HE QUITADO PORQUE DIRECTAMENTE LE HE PUESTO EL COLOR DEL BRILLO EN EL MATERIAL QUE TIENE. 
                //SOBRE LO DE ARRIBA, COMO EL BRILLO ESTÁ APAGADO, EL COLOR QUE SE LE PONGA NO AFECTA
                //A COMO SE VEA ORIGINALMENTE EL COLOR. CON LA COMBINACION DEL COLOR DE LA BASE CON 
                //EL COLOR DE LA EMISSION SE VE DELUXE
                Material1.EnableKeyword("_EMISSION");
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
                sistema.startSize = 0;
                Material1.color = original.color;
             //   Material1.SetColor("_EmissionColor", Original);
                Material1.DisableKeyword("_EMISSION");

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
        Material1.EnableKeyword("_EMISSION");
        //Material1.SetColor("_EmissionColor", Actualizado);
       Material1.color = cambiar.color;


    }


    [PunRPC]
    void cambiocontroladorblanco()
    {
        Material1.color = blanco.color;
        Material1.SetColor("_EmissionColor", Color.white);


    }

}
