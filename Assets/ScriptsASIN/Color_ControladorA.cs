using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Color_ControladorA : MonoBehaviourPunCallbacks
{
    public bool cambio;
    public GameObject ObjetoACambiar;
    Material Material1;
    public Material original;
    public Material cambiar;
    public Material blanco;

    private int puederestar;
    private int puedesumar;


    Puede_InteraccionarA permitido;
    GameObject interaccion;

    public Color StartColor;
    public Color EndColor;


    Input_playerA input_player;
    public GameObject input;


    public GameObject controlador_blanca;
    Control_BlancaA controlblanca;

    public GameObject ObjetoContadorBlanca;
    Control_BlancaA control_blanca;

    int valor;

    PhotonView pv;

    bool nocambio;

    // Start is called before the first frame update
    void Start()
    {

        nocambio = false;


        interaccion = GameObject.FindGameObjectWithTag("Interaccion");
        permitido = interaccion.GetComponent<Puede_InteraccionarA>();

        valor = 0;

        input = GameObject.FindGameObjectWithTag("Input");
        input_player = input.GetComponent<Input_playerA>();


        controlblanca = controlador_blanca.GetComponent<Control_BlancaA>();


        Material1 = ObjetoACambiar.GetComponent<Renderer>().material;
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
            pv.RPC("cambiocontroladorblanco", RpcTarget.All);

        }
        else
        {



            if (cambio && !nocambio)
            {
                PhotonView pv = gameObject.GetComponent<PhotonView>();
                //  Debug.Log("dentro del if");
               // Material1.color = cambiar.color;
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
            else if(!nocambio)
            {
                Debug.Log("vuelvo al original");
                Material1.color = original.color;
                if ( valor == 1)
                {
                    nocambio = true;
                    PhotonView pv = gameObject.GetComponent<PhotonView>();
                    pv.RPC("llamarcorutinacolor", RpcTarget.All);
                    
                    valor = 0;
                }

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
        StopAllCoroutines();
        valor = 1;

    }


    [PunRPC]
    void cambiocontroladorblanco()
    {
        Material1.color = blanco.color;


    }

    [PunRPC]
    void llamarcorutinacolor()
    {
        Debug.Log("DENTRO DE CORUTINA");
        
        PhotonView pv = gameObject.GetComponent<PhotonView>();
        StartCoroutine(conjuntodeCorutinas(StartColor, EndColor, permitido.tiempototal));
        
    }

    [PunRPC]
    IEnumerator conjuntodeCorutinas(Color startColor, Color endColor, float t)
    {
        
        StartCoroutine(cambiodecolor(endColor, startColor, t));
        yield return new WaitForSeconds(5);
        StartCoroutine(cambiodecolor(startColor, endColor, t));
        
        StartCoroutine(cambiodecolor(endColor, startColor, t));
        yield return new WaitForSeconds(5);
        StartCoroutine(cambiodecolor(startColor, endColor, t));
        StartCoroutine(cambiodecolor(endColor, startColor, t));

        PhotonView pv = gameObject.GetComponent<PhotonView>();
        
        pv.RPC("cambiocontrolador", RpcTarget.All);

        nocambio = false;
    }






    [PunRPC]
    IEnumerator cambiodecolor(Color startColor, Color endColor, float t)
    {
        float currentTime = 0;
        //while (currentTime < t)
        //{
        float time = t;

        while(currentTime <= time) {
            ////https://answers.unity.com/questions/1038571/colorlerp-for-spriterender-is-not-smooth.html
            currentTime += Time.deltaTime;
            float lerp_Percentage = currentTime / time;
        
            
            Debug.Log("COOORRRUUUTIIINA");
            // input_player
            Color currentColor = Color.Lerp(startColor, endColor, lerp_Percentage);
            Material1.color = currentColor;
            yield return null;
        }


    }






}
