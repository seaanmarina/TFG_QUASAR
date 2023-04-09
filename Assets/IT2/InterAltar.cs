//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;
//using Photon.Realtime;

//public class InterAltar : MonoBehaviourPunCallbacks
//{
//    Puede_InteraccionarA permitido;
//   public GameObject interaccion;

//    public bool cambio;
//    public GameObject ObjetoACambiar1;
//    public GameObject ObjetoACambiar2;

//    public bool Azul;
//    public bool Naranja;


//    public GameObject InputAltar;
//    InputAltarA input_player;

//    public GameObject cambiodeposicion;




//    public GameObject ObjetoCambiar3Local;
//    Material Material3;




//    CambioDimensionA cambio_Dimension;
//    public GameObject change;


//    public GameObject controlador_blanca;
//    Control_BlancaA controlblanca;

//    public bool estaCambiando;


//    Material Material1;
//    Material Material2;


//    public Material original;
//    public Material cambiar;
//    public Material blanco;

//    private int puederestar;
//    private int puedesumar;



//    bool reseteo = true;


//    public Color StartColor;
//    public Color EndColor;


//    Input_playerA input_playeer;
//    public GameObject IInput;



//    public GameObject ObjetoContadorBlanca;
//    Control_BlancaA control_blanca;

//    int valor;

//    PhotonView pv;

//    public bool nocambio;

//    public bool yaheentrado;

//    bool EntrarEnCorutinaBlanca;



//    bool cambiolocalBlanca;


//    public GameObject intermedioBlanco;
//    PonerseBlancoComunicacion intermediario;


//    public bool pararcorrutina;




//    // Start is called before the first frame update
//    void Start()
//    {
//        intermediario = intermedioBlanco.GetComponent<PonerseBlancoComunicacion>();

//        pararcorrutina = false;

//        yaheentrado = false;

//        nocambio = false;
//        EntrarEnCorutinaBlanca = true;

//        interaccion = GameObject.FindGameObjectWithTag("Interaccion");
//        permitido = interaccion.GetComponent<Puede_InteraccionarA>();

//        valor = 0;


//        input_player = InputAltar.GetComponent<InputAltarA>();


//        cambiolocalBlanca = false;


//        Material1 = ObjetoACambiar1.GetComponent<Renderer>().material;
//        Material2 = ObjetoACambiar2.GetComponent<Renderer>().material;
//        Material3 = ObjetoCambiar3Local.GetComponent<Renderer>().material;

//        Material1.DisableKeyword("_EMISSION");
//        Material2.DisableKeyword("_EMISSION");

//        cambio = false;
//        control_blanca = ObjetoContadorBlanca.GetComponent<Control_BlancaA>();
//        puedesumar = 1;
//        puederestar = 0;





//    }

//    // Update is called once per frame
//    [PunRPC]
//    void Update()
//    {

//            //if (control_blanca.contadorAsin >= 2)
//            //{
//            //    //input_player.sigueblanca = true;
//            //    PhotonView pv = gameObject.GetComponent<PhotonView>();
//            //    pv.RPC("cambiocontrolador", RpcTarget.All);

//            //}
//            // else
//            // {
//            //     input_player.sigueblanca = false;
//            // }
//            //// Debug.Log(cambio + "estado del cambio del color, si es true es cambio");

//            // //base.photonView.RPC("cambiocontrolador", RpcTarget.All);
//            //// Debug.Log(cambio);

//            //// Debug.Log(control_blanca.contadorBlanca);

//        }

//    [PunRPC]
//    public void cambiocontrolador()
//    {
//        if (control_blanca.contadorAsin >= 2 && intermediario.poderPonerseBlanco == 1)
//        //if (control_blanca.contadorAsin >= 2 && !yaheentrado)
//        {

//            //StopAllCoroutines();
//            //Debug.Log("HA ENRTADO EN EL COLOR BLANCO");
//            //EntrarEnCorutinaBlanca = false; //CREO QUE ENTONCES SOLO SIRVE PARA DOS PERSONAS PORQUE EN CUANTO LO DETECTE, SE CAMBIARÁ, AUNQUE CREO QUE SIRVE
//            PhotonView pv = gameObject.GetComponent<PhotonView>();
//            Debug.Log("dentro del if" + gameObject.name);
//            Material1.EnableKeyword("_EMISSION");

//            Material1.color = blanco.color;
//            Material1.SetColor("_EmissionColor", Color.white);

//            if (cambiolocalBlanca)
//            {
//                Material1.color = original.color;
//                Material1.DisableKeyword("_EMISSION");
//                cambiolocalBlanca = false;
//                intermediario.poderPonerseBlanco = 0;
//            }

//            //Debug.Log("El jugador variable es");

//            //foreach (Player player in PhotonNetwork.PlayerList)
//            //{
//            //    GameObject playerObject = GameObject.Find(player.NickName);
//            //    Debug.Log(player.NickName + ("lo nombre"));
//            //    if (playerObject != null)
//            //    {
//            //        Debug.Log("lo nombre FANTASTIC");
//            //    }
//            //        ////tell use each player who is in the room
//            //        //Debug.Log(player.ActorNumber + " is in the room");
//            //        //GameObject playerObject = GameObject.Find(player.ActorNumber);
//            //        //if ()

//            //    }





//            Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
//            foreach (Photon.Realtime.Player player in players)
//            {
//                //int numeroID = player.ActorNumber;
//                //numeroID = 1000 + numeroID;

//                PhotonView playerView = PhotonView.Find(player.ActorNumber); // Obtiene el PhotonView del jugador.
//                int numeroID = playerView.ViewID;
//                int actorNr = player.ActorNumber;
//                int viewId = actorNr * PhotonNetwork.MAX_VIEW_IDS + 1; 
//                // https://forum.photonengine.com/discussion/19477/get-photonview-through-player-object-get-all-photonviews-in-current-room

//                PhotonView pvv = PhotonView.Find(viewId); // obtiene el PhotonView del jugador remoto
//                GameObject playerGO = pvv.gameObject;
//                Debug.Log("el nombre es " + playerGO.name);

//                GameObject playerObject = GameObject.Find(player.NickName);
//                if (playerGO != null)
//                {
//                    Debug.Log("El jugador variable es " + player.NickName);
//                    RecogerVariablesJugador playerController = playerGO.GetComponent<RecogerVariablesJugador>();
//                    //Debug.Log("El jugador variable es " + playerController.ponerseABlanco);
//                    if (playerController != null && playerController.booleanaPonerseBlanco == true)
//                    {
//                        Debug.Log("doit");
//                        pv.RPC("cambiocontroladorblanco", player); // Envía la actualización de la propiedad personalizada al jugador destino
//                       // break;
//                    }
//                }
//            }

//            //pv.RPC("cambiocontroladorblanco", RpcTarget.All);



//            Debug.Log("Estoy en cambiocontrolador");
//        }
//        else
//        {



//            if (cambio && !nocambio)
//            {

//                if (reseteo)
//                {
//                    input_player.reset = true;
//                    reseteo = false;
//                }
//                else
//                {
//                    input_player.reset = false ;
//                }

//                PhotonView pv = gameObject.GetComponent<PhotonView>();
//                //  Debug.Log("dentro del if");
//                // Material1.color = cambiar.color;
//                if (control_blanca.contadorAsin >= 1)
//                {
//                    cambiocontrolador();
//                    //pv.RPC("cambiocontrolador", RpcTarget.All);
//                }
//                else
//                {
//                    Material1.color = cambiar.color;
//                    Material1.SetColor("_EmissionColor", EndColor * 1);
//                    Material1.EnableKeyword("_EMISSION");

//                    pv.RPC("cambiocontroladorotros", RpcTarget.All);
//                }

//                /* for (int i = 0; i < puedesumar; i++)
//                 {
//                     Debug.Log("estoy dentro de pulsar y sumar uno al contador de blanca");
//                     control_blanca.contadorBlanca++;
//                     puederestar++;
//                     puedesumar--;
//                    // Debug.Log(puedesumar + "puede sumar");
//                     Debug.Log(control_blanca.contadorBlanca + "controlador");
//                 }*/

//                Debug.Log("Estoy en cambio");
//            }
//            else if (!nocambio)
//            {
//                reseteo = true;
//                //Debug.Log("vuelvo al original");
//                //  Debug.Log("aqui estoy");
//                Material1.color = original.color;
//                Material2.color = original.color;
//                Material1.DisableKeyword("_EMISSION");
//                Material2.DisableKeyword("_EMISSION");

//                if (valor == 1)
//                {
//                    valor = 0;
//                    nocambio = true;
//                    PhotonView pv = gameObject.GetComponent<PhotonView>();
//                    pv.RPC("llamarcorutinacolor", RpcTarget.All);
//                    //Debug.Log("Debug log ASDF");

//                    //pv.RPC("contadorrestar", RpcTarget.All);
//                }

//                /* for (int i = 0; i < puederestar; i++)
//                 {
//                     Debug.Log("estoy dentro de no pulsar y sumar uno al contador de blanca");
//                     control_blanca.contadorBlanca--;
//                     puederestar--;
//                     puedesumar++;
//                     Debug.Log(control_blanca.contadorBlanca + " controlador al salir");
//                 }*/

//                Debug.Log("Estoy en !nocambio");
//            }
//        }

//    }

//    [PunRPC]
//    void cambiocontroladorotros()
//    {


//        Material2.color = cambiar.color;
//        Material2.SetColor("_EmissionColor", EndColor * 1);
//        Material2.EnableKeyword("_EMISSION");


//        valor = 1;

//        Debug.Log("Estoy en cambiocontroladorotro");

//    }

//    [PunRPC]
//    void contadorrestar()
//    {

//        //control_blanca.contadorAsin = control_blanca.contadorAsin - 1;


//    }


//    [PunRPC]
//    void cambiocontroladorblanco()
//    {
//        StopAllCoroutines();

//        nocambio = true;

//        StartCoroutine(ponerablanco());
//        EntrarEnCorutinaBlanca = false;
//        // Debug.Log("A por el cambio a blanco" + gameObject.name);
//        //if (control_blanca.contadorPararBlanco == control_blanca.contadorAsin)
//        //{
//        //    Debug.Log("Cambio de tiempo dentro del if");
//        //    input_player.cambiodetiempo = true;
//        //    control_blanca.contadorPararBlanco = 0;

//        //}
//        //Material1.color = blanco.color;
//        Debug.Log("Estoy en cambiocontroladorblanco");

//    }

//    [PunRPC]
//    IEnumerator ponerablanco()
//    {

//        Debug.Log("dentro de blanquit");

//        if (control_blanca.contadorPararBlanco < control_blanca.contadorAsin)
//        {
//            control_blanca.contadorPararBlanco++;
//            ///  Debug.Log("Cambio de tiempo dentro del if");
//            //yield return new WaitForSeconds(0.5f);
//            //input_player.cambiodetiempo = true;
//            //control_blanca.contadorPararBlanco = 0;
//            //Debug.Log("Estoy en ifpoerblanco");
//        }

//        if (control_blanca.contadorPararBlanco == control_blanca.contadorAsin)
//        {
//            input_player.cambiodetiempo = true;
//            control_blanca.contadorPararBlanco = 0;
//            Debug.Log("Estoy en ifpoerblanco");
//        }
//        //  Debug.Log("BLANCO QUE TE QUERO BLANCO INICIO");
//        Material2.EnableKeyword("_EMISSION");



//        Material2.color = blanco.color;

//        Material2.SetColor("_EmissionColor", Color.white);


//        yield return new WaitForSeconds(5f);
//        cambiolocalBlanca = true;
//        //Debug.Log("BLANCO QUE TE QUERO BLANCO");

//        Material2.color = original.color;
//        yaheentrado = false;
//        // input_player.controlador = true;
//        //input_player.controlador = true;
//        nocambio = false;


//        input_player.controlador = true;
//        control_blanca.contadorPararBlanco = 0;

//        Material2.DisableKeyword("_EMISSION");
//        intermediario.poderPonerseBlanco = 0;
//        // Debug.Log("BLANCO QUE TE QUERO BLANCO");
//        yield return null;
//        // input_player.cambiodetiempo = false;
//        //PhotonView pv = gameObject.GetComponent<PhotonView>();
//        //pv.RPC("cambiocontrolador", RpcTarget.All);
//        Debug.Log("Estoy en ponerblanco");
//    }



//    [PunRPC]
//    void llamarcorutinacolor()
//    {
//        // Debug.Log("DENTRO DE CORUTINA");

//        PhotonView pv = gameObject.GetComponent<PhotonView>();
//        // control_blanca.contadorAsin = control_blanca.contadorAsin + 1;
//        //Debug.Log("sumo" + gameObject.name);
//        StartCoroutine(conjuntodeCorutinas(StartColor, EndColor, permitido.tiempototal));
//        Debug.Log("Estoy en llamarcorrutinacolor");

//    }

//    [PunRPC]
//    IEnumerator conjuntodeCorutinas(Color startColor, Color endColor, float t)
//    {

//        if (nocambio)
//        {
//            PhotonView pv = gameObject.GetComponent<PhotonView>();
//            //pv.RPC("end_start", RpcTarget.All);

//            //yield return new WaitForSeconds(3.5f);
//            //pv.RPC("start_end", RpcTarget.All);
//            //pv.RPC("end_start", RpcTarget.All);

//            //yield return new WaitForSeconds(3.5f);

//            //pv.RPC("start_end", RpcTarget.All);
//            //pv.RPC("end_start", RpcTarget.All);
//            //StartCoroutine(cambiodecolor(startColor, endColor, t));


//            //Debug.Log("Empieza corrutina general" + nocambio);
//            Material1.EnableKeyword("_EMISSION");
//            Material2.EnableKeyword("_EMISSION");

//            yield return StartCoroutine(cambiodecolor(endColor, startColor, t, 1,0));

//            yield return new WaitForSeconds(3.5f);

//            yield return StartCoroutine(cambiodecolor(startColor, endColor, t,0,1));
//            yield return StartCoroutine(cambiodecolor(endColor, startColor, t,1,0));

//            yield return new WaitForSeconds(3.5f);

//            //StartCoroutine(cambiodecolor(startColor, endColor, t));
//            yield return StartCoroutine(cambiodecolor(startColor, endColor, t,0,1));
//            yield return StartCoroutine(cambiodecolor(endColor, startColor, t,1,0));


//            Material1.DisableKeyword("_EMISSION");
//            Material2.DisableKeyword("_EMISSION");
//            //control_blanca.contadorAsin = control_blanca.contadorAsin - 1;
//            //input_player.controlador = true; 
//            // Debug.Log("Empieza corrutina general caca");
//            nocambio = false;
//            Debug.Log("Estoy en corrutina conjuntocorrutinas");
//            //Debug.Log("Llamada al inicial");
//            //pv.RPC("cambiocontrolador", RpcTarget.All);
//        }
//        Debug.Log("Estoy en conjuntocorrutinas");

//    }
//    //[PunRPC]
//    //void start_end(Color startColor, Color endColor, float t)
//    //{
//    //    StartCoroutine(cambiodecolor(startColor, endColor, t));

//    //}
//    //[PunRPC]
//    //void end_start(Color startColor, Color endColor, float t)
//    //{
//    //    StartCoroutine(cambiodecolor(endColor, startColor, t));
//    //}




//    [PunRPC]
//    IEnumerator cambiodecolor(Color startColor, Color endColor, float t, int primero, int segundo)
//    {
//        if (control_blanca.contadorAsin >= 2)
//        {

//            //PhotonView pv = gameObject.GetComponent<PhotonView>();
//            //Debug.Log("Llamada al inicial");
//            //pv.RPC("cambiocontrolador", RpcTarget.All);
//            //StopAllCoroutines();
//            Debug.Log("Estoy en cambiodecolor if");

//        }

//        float currentTime = 0;
//        //while (currentTime < t)
//        //{
//        float time = t;

//        while ((currentTime <= time) && !pararcorrutina)
//        {
//            ////https://answers.unity.com/questions/1038571/colorlerp-for-spriterender-is-not-smooth.html
//            currentTime += Time.deltaTime;
//            float lerp_Percentage = currentTime / time;


//            //  Debug.Log("COOORRRUUUTIIINA");
//            // input_player
//            Color currentColor = Color.Lerp(startColor, endColor, lerp_Percentage);
//            float emission = Mathf.Lerp(primero, segundo, lerp_Percentage);

//            Material1.color = currentColor;
//            Material2.color = currentColor;

//            Material1.SetColor("_EmissionColor", currentColor * emission);
//            Material2.SetColor("_EmissionColor", currentColor * emission);
//            Debug.Log("Estoy en whilecambiocolor");
//            yield return null;
//        }

//        Debug.Log("Estoy en cmabiodecolor");

//    }






//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InterAltar : MonoBehaviourPunCallbacks
{
    Puede_InteraccionarA permitido;
    public GameObject interaccion;

    public bool cambio;
    public GameObject ObjetoACambiar1;
    public GameObject ObjetoACambiar2;

    public bool Azul;
    public bool Naranja;


    public GameObject InputAltar;
    InputAltarA input_player;

    public GameObject cambiodeposicion;




    public GameObject ObjetoCambiar3Local;
    Material Material3;




    CambioDimensionA cambio_Dimension;
    public GameObject change;


    public GameObject controlador_blanca;
    Control_BlancaA controlblanca;

    public bool estaCambiando;


    Material Material1;
    Material Material2;


    public Material original;
    public Material cambiar;
    public Material blanco;

    private int puederestar;
    private int puedesumar;



    bool reseteo = true;


    public Color StartColor;
    public Color EndColor;


    Input_playerA input_playeer;
    public GameObject IInput;



    public GameObject ObjetoContadorBlanca;
    Control_BlancaA control_blanca;

    [SerializeField]
    private int valor;

    PhotonView pv;



    [SerializeField]
    private bool nocambio;

    public bool yaheentrado;

    bool EntrarEnCorutinaBlanca;



    bool cambiolocalBlanca;


    public GameObject intermedioBlanco;
    PonerseBlancoComunicacion intermediario;


    public bool pararcorrutina;

     



    // Start is called before the first frame update
    void Start()
    {
        intermediario = intermedioBlanco.GetComponent<PonerseBlancoComunicacion>();

        pararcorrutina = false;

        yaheentrado = false;

        nocambio = false;
        EntrarEnCorutinaBlanca = true;

        interaccion = GameObject.FindGameObjectWithTag("Interaccion");
        permitido = interaccion.GetComponent<Puede_InteraccionarA>();

        valor = 0;


        input_player = InputAltar.GetComponent<InputAltarA>();


        cambiolocalBlanca = false;


        Material1 = ObjetoACambiar1.GetComponent<Renderer>().material;
        Material2 = ObjetoACambiar2.GetComponent<Renderer>().material;
        Material3 = ObjetoCambiar3Local.GetComponent<Renderer>().material;

        Material1.DisableKeyword("_EMISSION");
        Material2.DisableKeyword("_EMISSION");

        cambio = false;
        control_blanca = ObjetoContadorBlanca.GetComponent<Control_BlancaA>();
        puedesumar = 1;
        puederestar = 0;





    }

    // Update is called once per frame
  
    void Update()
    {

        
    }


    public void cambiocontrolador()
    {
        if (control_blanca.contadorAsin >= 2 && intermediario.poderPonerseBlanco == 1)

        {

            //CREO QUE ENTONCES SOLO SIRVE PARA DOS PERSONAS PORQUE EN CUANTO LO DETECTE, SE CAMBIARÁ, AUNQUE CREO QUE SIRVE
            PhotonView pv = gameObject.GetComponent<PhotonView>();
            Debug.Log("dentro del if" + gameObject.name);
            Material1.EnableKeyword("_EMISSION");

            Material1.color = blanco.color;
            Material1.SetColor("_EmissionColor", Color.white);

            if (cambiolocalBlanca)
            {
                Material1.color = original.color;
                Material1.DisableKeyword("_EMISSION");
                cambiolocalBlanca = false;
                intermediario.poderPonerseBlanco = 0;
            }



            Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
            foreach (Photon.Realtime.Player player in players)
            {


                PhotonView playerView = PhotonView.Find(player.ActorNumber); // Obtiene el PhotonView del jugador.
                int numeroID = playerView.ViewID;
                int actorNr = player.ActorNumber;
                int viewId = actorNr * PhotonNetwork.MAX_VIEW_IDS + 1;
                // https://forum.photonengine.com/discussion/19477/get-photonview-through-player-object-get-all-photonviews-in-current-room

                PhotonView pvv = PhotonView.Find(viewId); // obtiene el PhotonView del jugador remoto
                GameObject playerGO = pvv.gameObject;
                Debug.Log("el nombre es " + playerGO.name);

                GameObject playerObject = GameObject.Find(player.NickName);
                if (playerGO != null)
                {
                    Debug.Log("El jugador variable es " + player.NickName);
                    RecogerVariablesJugador playerController = playerGO.GetComponent<RecogerVariablesJugador>();

                    if (playerController != null && playerController.booleanaPonerseBlanco == true)
                    {
                        Debug.Log("doit");
                        pv.RPC("cambiocontroladorblanco", player); // Envía la actualización de la propiedad personalizada al jugador destino
                                                                   // break;
                    }
                }
            }





            Debug.Log("Estoy en cambiocontrolador");
        }
        else
        {



            if (cambio && !nocambio)
            {

                if (reseteo)
                {
                    input_player.reset = true;
                    reseteo = false;
                }
                else
                {
                    input_player.reset = false;
                }

                PhotonView pv = gameObject.GetComponent<PhotonView>();

                if (control_blanca.contadorAsin >= 1)
                {
                    cambiocontrolador();

                }
                else
                {
                    Material1.color = cambiar.color;
                    Material1.SetColor("_EmissionColor", EndColor * 1);
                    Material1.EnableKeyword("_EMISSION");
                     valor = 1;
                    pv.RPC("cambiocontroladorotros", RpcTarget.All);
                }



                Debug.Log("Estoy en cambio");
            }
            else if (!nocambio)
            {
                reseteo = true;

                Material1.color = original.color;
                Material2.color = original.color;
                Material1.DisableKeyword("_EMISSION");
                Material2.DisableKeyword("_EMISSION");

                if (valor == 1)
                {
                    valor = 0;
                    nocambio = true;
                    PhotonView pv = gameObject.GetComponent<PhotonView>();
                    pv.RPC("llamarcorutinacolor", RpcTarget.All);
                    llamarcorutinacoloralone();


                }


                Debug.Log("Estoy en !nocambio");
            }
        }

    }

    [PunRPC]
    void cambiocontroladorotros()
    {


        Material2.color = cambiar.color;
        Material2.SetColor("_EmissionColor", EndColor * 1);
        Material2.EnableKeyword("_EMISSION");


       

        Debug.Log("Estoy en cambiocontroladorotro");

    }




    [PunRPC]
    void cambiocontroladorblanco()
    {
        StopAllCoroutines();

        nocambio = true;

        StartCoroutine(ponerablanco());
        EntrarEnCorutinaBlanca = false;

        Debug.Log("Estoy en cambiocontroladorblanco");

    }

    [PunRPC]
    IEnumerator ponerablanco()
    {

        Debug.Log("dentro de blanquit");

        if (control_blanca.contadorPararBlanco < control_blanca.contadorAsin)
        {
            control_blanca.contadorPararBlanco++;

        }

        if (control_blanca.contadorPararBlanco == control_blanca.contadorAsin)
        {
            input_player.cambiodetiempo = true;
            control_blanca.contadorPararBlanco = 0;
            Debug.Log("Estoy en ifpoerblanco");
        }

        Material2.EnableKeyword("_EMISSION");



        Material2.color = blanco.color;

        Material2.SetColor("_EmissionColor", Color.white);


        yield return new WaitForSeconds(5f);
        cambiolocalBlanca = true;


        Material2.color = original.color;
        yaheentrado = false;

        nocambio = false;


        input_player.controlador = true;
        control_blanca.contadorPararBlanco = 0;

        Material2.DisableKeyword("_EMISSION");
        intermediario.poderPonerseBlanco = 0;

        yield return null;

        Debug.Log("Estoy en ponerblanco");
    }



    [PunRPC]
    void llamarcorutinacolor()
    {


        PhotonView pv = gameObject.GetComponent<PhotonView>();

        StartCoroutine(conjuntodeCorutinas(StartColor, EndColor, permitido.tiempototal, Material2));
        Debug.Log("Estoy en llamarcorrutinacolor");

    }


    void llamarcorutinacoloralone()
    {

        Material1.EnableKeyword("_EMISSION");


        StartCoroutine(conjuntodeCorutinas(StartColor, EndColor, permitido.tiempototal, Material1));
        Debug.Log("Estoy en llamarcorrutinacolor");

    }

    [PunRPC]
    IEnumerator conjuntodeCorutinas(Color startColor, Color endColor, float t, Material material)
    {
        bool primero = true;


        Color cambio1;
        Color cambio2;

        int numero1;
        int numero2;

        nocambio = true;



        for (int i = 0; i < 5; i++)
        {
            if (primero)
            {
                cambio1 = endColor;
                cambio2 = startColor;
                numero1 = 1;
                numero2 = 0;
            }
            else
            {
                cambio1 = startColor;
                cambio2 = endColor;
                numero1 = 0;
                numero2 = 1;
            }

            float currentTime = 0;

            float time = t;

            while ((currentTime <= time))
            {
                ////https://answers.unity.com/questions/1038571/colorlerp-for-spriterender-is-not-smooth.html
                currentTime += Time.deltaTime;
                float lerp_Percentage = currentTime / time;

                Color currentColor = Color.Lerp(cambio1, cambio2, lerp_Percentage);
                float emission = Mathf.Lerp(numero1, numero2, lerp_Percentage);

                material.color = currentColor;
                //Material2.color = currentColor;

                material.SetColor("_EmissionColor", currentColor * emission);
                //Material2.SetColor("_EmissionColor", currentColor * emission);
                Debug.Log("Estoy en whilecambiocolor");
                yield return null;
            }

            if (primero)
            {
                yield return new WaitForSeconds(3.5f);
            }

            primero = !primero;
        }

        intermediario.poderPonerseBlanco = 0;
        Material1.DisableKeyword("_EMISSION");
        Material2.DisableKeyword("_EMISSION");

        nocambio = false;



        //if (nocambio)
        //{
        //    PhotonView pv = gameObject.GetComponent<PhotonView>();


        //    Material2.EnableKeyword("_EMISSION");

        //    yield return StartCoroutine(cambiodecolor(endColor, startColor, t, 1, 0, material));

        //    yield return new WaitForSeconds(3.5f);

        //    yield return StartCoroutine(cambiodecolor(startColor, endColor, t, 0, 1, material));
        //    yield return StartCoroutine(cambiodecolor(endColor, startColor, t, 1, 0, material));

        //    yield return new WaitForSeconds(3.5f);


        //    yield return StartCoroutine(cambiodecolor(startColor, endColor, t, 0, 1, material));
        //    yield return StartCoroutine(cambiodecolor(endColor, startColor, t, 1, 0, material));


        //    Material1.DisableKeyword("_EMISSION");
        //    Material2.DisableKeyword("_EMISSION");

        //    nocambio = false;
        //    Debug.Log("Estoy en corrutina conjuntocorrutinas");

        //}
        //Debug.Log("Estoy en conjuntocorrutinas");

    }




    //[PunRPC]
    //IEnumerator cambiodecolor(Color startColor, Color endColor, float t, int primero, int segundo, Material material)
    //{

    //    float currentTime = 0;

    //    float time = t;

    //    while ((currentTime <= time) && !pararcorrutina)
    //    {
    //        ////https://answers.unity.com/questions/1038571/colorlerp-for-spriterender-is-not-smooth.html
    //        currentTime += Time.deltaTime;
    //        float lerp_Percentage = currentTime / time;

    //        Color currentColor = Color.Lerp(startColor, endColor, lerp_Percentage);
    //        float emission = Mathf.Lerp(primero, segundo, lerp_Percentage);

    //        material.color = currentColor;
    //        //Material2.color = currentColor;

    //        material.SetColor("_EmissionColor", currentColor * emission);
    //        //Material2.SetColor("_EmissionColor", currentColor * emission);
    //        Debug.Log("Estoy en whilecambiocolor");
    //        yield return null;
    //    }

    //    Debug.Log("Estoy en cmabiodecolor");

    //}



    //public void cambiocontrolador()
    //{
    //    if (control_blanca.contadorAsin >= 2 && intermediario.poderPonerseBlanco == 1)

    //    {

    //        //CREO QUE ENTONCES SOLO SIRVE PARA DOS PERSONAS PORQUE EN CUANTO LO DETECTE, SE CAMBIARÁ, AUNQUE CREO QUE SIRVE
    //        PhotonView pv = gameObject.GetComponent<PhotonView>();
    //        Debug.Log("dentro del if" + gameObject.name);




    //        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
    //        foreach (Photon.Realtime.Player player in players)
    //        {


    //            PhotonView playerView = PhotonView.Find(player.ActorNumber); // Obtiene el PhotonView del jugador.
    //            int numeroID = playerView.ViewID;
    //            int actorNr = player.ActorNumber;
    //            int viewId = actorNr * PhotonNetwork.MAX_VIEW_IDS + 1;
    //            // https://forum.photonengine.com/discussion/19477/get-photonview-through-player-object-get-all-photonviews-in-current-room

    //            PhotonView pvv = PhotonView.Find(viewId); // obtiene el PhotonView del jugador remoto
    //            GameObject playerGO = pvv.gameObject;
    //            Debug.Log("el nombre es " + playerGO.name);

    //            GameObject playerObject = GameObject.Find(player.NickName);
    //            if (playerGO != null)
    //            {
    //                Debug.Log("El jugador variable es " + player.NickName);
    //                RecogerVariablesJugador playerController = playerGO.GetComponent<RecogerVariablesJugador>();

    //                if (playerController != null && playerController.booleanaPonerseBlanco == true)
    //                {
    //                    Debug.Log("doit");
    //                    pv.RPC("cambiocontroladorblanco", player); // Envía la actualización de la propiedad personalizada al jugador destino
    //                                                               // break;
    //                }
    //            }
    //        }





    //        Debug.Log("Estoy en cambiocontrolador");
    //    }
    //    else
    //    {



    //        if (cambio && !nocambio)
    //        {

    //            if (reseteo)
    //            {
    //                input_player.reset = true;
    //                reseteo = false;
    //            }
    //            else
    //            {
    //                input_player.reset = false;
    //            }

    //            PhotonView pv = gameObject.GetComponent<PhotonView>();

    //            if (control_blanca.contadorAsin >= 1)
    //            {
    //                cambiocontrolador();

    //            }
    //            else
    //            {


    //                pv.RPC("cambiocontroladorotros", RpcTarget.All);
    //                valor = 1;
    //            }



    //            Debug.Log("Estoy en cambio");
    //        }
    //        else if (!nocambio)
    //        {
    //            reseteo = true;


    //            //Material2.color = original.color;

    //            //Material2.DisableKeyword("_EMISSION");

    //            if (valor == 1)
    //            {
    //                valor = 0;
    //                nocambio = true;
    //                PhotonView pv = gameObject.GetComponent<PhotonView>();
    //                pv.RPC("llamarcorutinacolor", RpcTarget.All);



    //            }


    //            Debug.Log("Estoy en !nocambio");
    //        }
    //    }

    //}

    //[PunRPC]
    //void cambiocontroladorotros()
    //{


    //    Material2.color = cambiar.color;
    //    Material2.SetColor("_EmissionColor", EndColor * 1);
    //    Material2.EnableKeyword("_EMISSION");




    //    Debug.Log("Estoy en cambiocontroladorotro");

    //}




    //[PunRPC]
    //void cambiocontroladorblanco()
    //{
    //    StopAllCoroutines();

    //    nocambio = true;

    //    StartCoroutine(ponerablanco());
    //    EntrarEnCorutinaBlanca = false;

    //    Debug.Log("Estoy en cambiocontroladorblanco");

    //}

    //[PunRPC]
    //IEnumerator ponerablanco()
    //{

    //    Debug.Log("dentro de blanquit");

    //    if (control_blanca.contadorPararBlanco < control_blanca.contadorAsin)
    //    {
    //        control_blanca.contadorPararBlanco++;

    //    }

    //    if (control_blanca.contadorPararBlanco == control_blanca.contadorAsin)
    //    {
    //        input_player.cambiodetiempo = true;
    //        control_blanca.contadorPararBlanco = 0;
    //        Debug.Log("Estoy en ifpoerblanco");
    //    }

    //    Material2.EnableKeyword("_EMISSION");



    //    Material2.color = blanco.color;

    //    Material2.SetColor("_EmissionColor", Color.white);


    //    yield return new WaitForSeconds(5f);
    //    cambiolocalBlanca = true;


    //    Material2.color = original.color;
    //    yaheentrado = false;

    //    nocambio = false;


    //    input_player.controlador = true;
    //    control_blanca.contadorPararBlanco = 0;

    //    Material2.DisableKeyword("_EMISSION");
    //    intermediario.poderPonerseBlanco = 0;

    //    yield return null;

    //    Debug.Log("Estoy en ponerblanco");
    //}



    //[PunRPC]
    //void llamarcorutinacolor()
    //{


    //    PhotonView pv = gameObject.GetComponent<PhotonView>();

    //    StartCoroutine(conjuntodeCorutinas(StartColor, EndColor, permitido.tiempototal, Material2));
    //    Debug.Log("Estoy en llamarcorrutinacolor");

    //}




    //[PunRPC]
    //IEnumerator conjuntodeCorutinas(Color startColor, Color endColor, float t, Material material)
    //{
    //    bool primero = true;


    //    Color cambio1;
    //    Color cambio2;

    //    int numero1;
    //    int numero2;

    //    nocambio = true;



    //    for (int i = 0; i < 5; i++)
    //    {
    //        if (primero)
    //        {
    //            cambio1 = endColor;
    //            cambio2 = startColor;
    //            numero1 = 1;
    //            numero2 = 0;
    //        }
    //        else
    //        {
    //            cambio1 = startColor;
    //            cambio2 = endColor;
    //            numero1 = 0;
    //            numero2 = 1;
    //        }

    //        float currentTime = 0;

    //        float time = t;

    //        while ((currentTime <= time))
    //        {
    //            ////https://answers.unity.com/questions/1038571/colorlerp-for-spriterender-is-not-smooth.html
    //            currentTime += Time.deltaTime;
    //            float lerp_Percentage = currentTime / time;

    //            Color currentColor = Color.Lerp(cambio1, cambio2, lerp_Percentage);
    //            float emission = Mathf.Lerp(numero1, numero2, lerp_Percentage);

    //            material.color = currentColor;
    //            //Material2.color = currentColor;

    //            material.SetColor("_EmissionColor", currentColor * emission);
    //            //Material2.SetColor("_EmissionColor", currentColor * emission);
    //            Debug.Log("Estoy en whilecambiocolor");
    //            yield return null;
    //        }

    //        if (primero)
    //        {
    //            yield return new WaitForSeconds(3.5f);
    //        }

    //        primero = !primero;
    //    }



    //    Material2.DisableKeyword("_EMISSION");

    //    nocambio = false;





    //}









}
