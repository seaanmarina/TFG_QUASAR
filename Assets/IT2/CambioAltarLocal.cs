
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CambioAltarLocal : MonoBehaviour
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

    int valor;


    public bool nocambio;

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



           





            Debug.Log("Estoy en cambiocontrolador");
        }
        else
        {



            if (cambio && !nocambio)
            {

               
                

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
                }



                Debug.Log("Estoy en cambio");
            }
            else if (!nocambio)
            {
                reseteo = true;

                Material1.color = original.color;
               
                Material1.DisableKeyword("_EMISSION");
                

                if (valor == 1)
                {
                    valor = 0;
                    nocambio = true;
                    
                   
                    llamarcorutinacoloralone();


                }


                Debug.Log("Estoy en !nocambio");
            }
        }

    }





    
    IEnumerator ponerablanco()
    {

        yield return new WaitForSeconds(5f);
        cambiolocalBlanca = true;


       
        yaheentrado = false;

        nocambio = false;


        input_player.controlador = true;
       

        

        yield return null;

        Debug.Log("Estoy en ponerblanco");
    }



    


    void llamarcorutinacoloralone()
    {

        Material1.EnableKeyword("_EMISSION");


        StartCoroutine(conjuntodeCorutinas(StartColor, EndColor, permitido.tiempototal, Material1));
        Debug.Log("Estoy en llamarcorrutinacolor");

    }

    
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


        Material1.DisableKeyword("_EMISSION");
        

        nocambio = false;




    }




   



}
