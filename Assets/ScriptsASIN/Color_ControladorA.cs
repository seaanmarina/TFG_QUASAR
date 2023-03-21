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

   public bool yaheentrado;

    bool EntrarEnCorutinaBlanca;

    // Start is called before the first frame update
    void Start()
    {

        yaheentrado = false;

        nocambio = false;
        EntrarEnCorutinaBlanca = true;

        interaccion = GameObject.FindGameObjectWithTag("Interaccion");
        permitido = interaccion.GetComponent<Puede_InteraccionarA>();

        valor = 0;

        input = GameObject.FindGameObjectWithTag("Input");
        input_player = input.GetComponent<Input_playerA>();


       


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

        //if (control_blanca.contadorAsin >= 2)
        //{
        //    //input_player.sigueblanca = true;
        //    PhotonView pv = gameObject.GetComponent<PhotonView>();
        //    pv.RPC("cambiocontrolador", RpcTarget.All);

        //}
        // else
        // {
        //     input_player.sigueblanca = false;
        // }
        //// Debug.Log(cambio + "estado del cambio del color, si es true es cambio");

        // //base.photonView.RPC("cambiocontrolador", RpcTarget.All);
        //// Debug.Log(cambio);

        //// Debug.Log(control_blanca.contadorBlanca);

    }

    [PunRPC]
    void cambiocontrolador()
    {
        if (control_blanca.contadorAsin >= 2)
        //if (control_blanca.contadorAsin >= 2 && !yaheentrado)
        {

            //StopAllCoroutines();
            //Debug.Log("HA ENRTADO EN EL COLOR BLANCO");
            //EntrarEnCorutinaBlanca = false; //CREO QUE ENTONCES SOLO SIRVE PARA DOS PERSONAS PORQUE EN CUANTO LO DETECTE, SE CAMBIARÁ, AUNQUE CREO QUE SIRVE
            PhotonView pv = gameObject.GetComponent<PhotonView>();
              Debug.Log("dentro del if" + gameObject.name);
            Material1.color = blanco.color;
            pv.RPC("cambiocontroladorblanco", RpcTarget.All);

            Debug.Log("Estoy en cambiocontrolador");
        }
        else
        {



            if (cambio && !nocambio)
            {
                
                PhotonView pv = gameObject.GetComponent<PhotonView>();
                //  Debug.Log("dentro del if");
                // Material1.color = cambiar.color;
                if (control_blanca.contadorAsin >= 1)
                {
                    
                    pv.RPC("cambiocontrolador", RpcTarget.All);
                }
                else
                {
                    pv.RPC("cambiocontroladorotro", RpcTarget.All);
                }

                /* for (int i = 0; i < puedesumar; i++)
                 {
                     Debug.Log("estoy dentro de pulsar y sumar uno al contador de blanca");
                     control_blanca.contadorBlanca++;
                     puederestar++;
                     puedesumar--;
                    // Debug.Log(puedesumar + "puede sumar");
                     Debug.Log(control_blanca.contadorBlanca + "controlador");
                 }*/

                Debug.Log("Estoy en cambio");
            }
            else if(!nocambio)
            {
                //Debug.Log("vuelvo al original");
              //  Debug.Log("aqui estoy");
                Material1.color = original.color;

                if ( valor == 1)
                {
                    valor = 0;
                    nocambio = true;
                    PhotonView pv = gameObject.GetComponent<PhotonView>();
                    pv.RPC("llamarcorutinacolor", RpcTarget.All);
                    //Debug.Log("Debug log ASDF");
                    
                    //pv.RPC("contadorrestar", RpcTarget.All);
                }

                /* for (int i = 0; i < puederestar; i++)
                 {
                     Debug.Log("estoy dentro de no pulsar y sumar uno al contador de blanca");
                     control_blanca.contadorBlanca--;
                     puederestar--;
                     puedesumar++;
                     Debug.Log(control_blanca.contadorBlanca + " controlador al salir");
                 }*/

                Debug.Log("Estoy en !nocambio");
            }
        }
        
    }

    [PunRPC]
    void cambiocontroladorotro()
    {
        Material1.color = cambiar.color;
        
        valor = 1;

        Debug.Log("Estoy en cambiocontroladorotro");

    }

    [PunRPC]
    void contadorrestar()
    {

        //control_blanca.contadorAsin = control_blanca.contadorAsin - 1;


    }


    [PunRPC]
    void cambiocontroladorblanco()
    {
        StopAllCoroutines();
        
        nocambio = true;

            StartCoroutine(ponerablanco());
            EntrarEnCorutinaBlanca = false;
        // Debug.Log("A por el cambio a blanco" + gameObject.name);
        //if (control_blanca.contadorPararBlanco == control_blanca.contadorAsin)
        //{
        //    Debug.Log("Cambio de tiempo dentro del if");
        //    input_player.cambiodetiempo = true;
        //    control_blanca.contadorPararBlanco = 0;

        //}
        //Material1.color = blanco.color;
        Debug.Log("Estoy en cambiocontroladorblanco");

    }

    [PunRPC]
    IEnumerator ponerablanco()
    {
        
        if (control_blanca.contadorPararBlanco < control_blanca.contadorAsin)
        {
            control_blanca.contadorPararBlanco++;
            ///  Debug.Log("Cambio de tiempo dentro del if");
            //yield return new WaitForSeconds(0.5f);
            //input_player.cambiodetiempo = true;
            //control_blanca.contadorPararBlanco = 0;
            //Debug.Log("Estoy en ifpoerblanco");
        }

        if (control_blanca.contadorPararBlanco == control_blanca.contadorAsin)
        {
            input_player.cambiodetiempo = true;
            control_blanca.contadorPararBlanco = 0;
            Debug.Log("Estoy en ifpoerblanco");
        }
      //  Debug.Log("BLANCO QUE TE QUERO BLANCO INICIO");
        Material1.color = blanco.color;
        yield return new WaitForSeconds(5f);
        //Debug.Log("BLANCO QUE TE QUERO BLANCO");
        Material1.color = original.color;
        yaheentrado = false;
       // input_player.controlador = true;
        //input_player.controlador = true;
        nocambio = false;
        Material1.color = original.color;

        input_player.controlador = true;
        // Debug.Log("BLANCO QUE TE QUERO BLANCO");
        yield return null;
        // input_player.cambiodetiempo = false;
        //PhotonView pv = gameObject.GetComponent<PhotonView>();
        //pv.RPC("cambiocontrolador", RpcTarget.All);
        Debug.Log("Estoy en ponerblanco");
    }



    [PunRPC]
    void llamarcorutinacolor()
    {
       // Debug.Log("DENTRO DE CORUTINA");
        
        PhotonView pv = gameObject.GetComponent<PhotonView>();
       // control_blanca.contadorAsin = control_blanca.contadorAsin + 1;
        //Debug.Log("sumo" + gameObject.name);
        StartCoroutine(conjuntodeCorutinas(StartColor, EndColor, permitido.tiempototal));
        Debug.Log("Estoy en llamarcorrutinacolor");

    }

    [PunRPC]
    IEnumerator conjuntodeCorutinas(Color startColor, Color endColor, float t)
    {

        if (nocambio)
        {
            PhotonView pv = gameObject.GetComponent<PhotonView>();
            //pv.RPC("end_start", RpcTarget.All);

            //yield return new WaitForSeconds(3.5f);
            //pv.RPC("start_end", RpcTarget.All);
            //pv.RPC("end_start", RpcTarget.All);

            //yield return new WaitForSeconds(3.5f);

            //pv.RPC("start_end", RpcTarget.All);
            //pv.RPC("end_start", RpcTarget.All);
            //StartCoroutine(cambiodecolor(startColor, endColor, t));


            //Debug.Log("Empieza corrutina general" + nocambio);



            yield return StartCoroutine(cambiodecolor(endColor, startColor, t));

            yield return new WaitForSeconds(3.5f);

            yield return StartCoroutine(cambiodecolor(startColor, endColor, t));
            yield return StartCoroutine(cambiodecolor(endColor, startColor, t));

            yield return new WaitForSeconds(3.5f);

            //StartCoroutine(cambiodecolor(startColor, endColor, t));
            yield return StartCoroutine(cambiodecolor(startColor, endColor, t));
            yield return StartCoroutine(cambiodecolor(endColor, startColor, t));

            //control_blanca.contadorAsin = control_blanca.contadorAsin - 1;
            //input_player.controlador = true; 
           // Debug.Log("Empieza corrutina general caca");
            nocambio = false;
            Debug.Log("Estoy en corrutina conjuntocorrutinas");
            //Debug.Log("Llamada al inicial");
            //pv.RPC("cambiocontrolador", RpcTarget.All);
        }
        Debug.Log("Estoy en conjuntocorrutinas");

    }
    [PunRPC]
    void start_end(Color startColor, Color endColor, float t)
    {
        StartCoroutine(cambiodecolor(startColor, endColor, t));

    }
    [PunRPC]
    void end_start(Color startColor, Color endColor, float t)
    {
        StartCoroutine(cambiodecolor(endColor, startColor, t));
    }




    [PunRPC]
    IEnumerator cambiodecolor(Color startColor, Color endColor, float t)
    {
        if (control_blanca.contadorAsin >= 2)
        {
            
            //PhotonView pv = gameObject.GetComponent<PhotonView>();
            //Debug.Log("Llamada al inicial");
            //pv.RPC("cambiocontrolador", RpcTarget.All);
            //StopAllCoroutines();
            Debug.Log("Estoy en cambiodecolor if");

        }

        float currentTime = 0;
        //while (currentTime < t)
        //{
        float time = t;

        while(currentTime <= time) {
            ////https://answers.unity.com/questions/1038571/colorlerp-for-spriterender-is-not-smooth.html
            currentTime += Time.deltaTime;
            float lerp_Percentage = currentTime / time;
        
            
          //  Debug.Log("COOORRRUUUTIIINA");
            // input_player
            Color currentColor = Color.Lerp(startColor, endColor, lerp_Percentage);
            Material1.color = currentColor;
            Debug.Log("Estoy en whilecambiocolor");
            yield return null;
        }

        Debug.Log("Estoy en cmabiodecolor");

    }






}
