using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RastroDeLuz : MonoBehaviourPunCallbacks
{

    public Color Blanco;
    public Color Actualizado;
    public Color Original;

    public Material material;
    public GameObject GamecontadorRastro;
    ContadorRastro ObjetocontadorRastro;

    public bool CambioDesdeBlanco;


    private bool ContinuaCorrutina;
    private bool PuedeBlanco;
    private float startTime;


    public float emission;


    // Start is called before the first frame update
    void Start()
    {
        PuedeBlanco = false;
        ContinuaCorrutina = true;
        CambioDesdeBlanco = false;
        material = GetComponent<Renderer>().material;
        material.DisableKeyword("_EMISSION"); //ESTO SE UTILIZA SOBRE TODO PARA COMPONENTES DE MATERIALES, PARA ACTIVAR Y DESACTIVAR PROPIEDADES EN CONCRETO DEL MATERIAL

        Original = material.GetColor("_EmissionColor");

        


        ObjetocontadorRastro = GamecontadorRastro.GetComponent<ContadorRastro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjetocontadorRastro.contadorRastroLuz>=2 && PuedeBlanco)
        {
            material.SetColor("_EmissionColor", Color.white);
            CambioDesdeBlanco = true;

        }

        else if (CambioDesdeBlanco && ObjetocontadorRastro.contadorRastroLuz < 2)
        {
            //PhotonView pv = gameObject.GetComponent<PhotonView>();
            //StartCoroutine(Lerp());
            material.SetColor("_EmissionColor", Original);

            CambioDesdeBlanco = false;
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        PhotonView phView = other.gameObject.GetComponent<PhotonView>();
        // Debug.Log(owner.Controller.ActorNumber + "es el controlador del objeto");
        //if (phView.IsMine)
        if (PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
        {
            PuedeBlanco = true;
            material.EnableKeyword("_EMISSION");
            PhotonView pv = gameObject.GetComponent<PhotonView>();
           
            pv.RPC("SumarContadorRastro", RpcTarget.All);
        }


        }

    private void OnTriggerExit(Collider other)
    {
        PhotonView phView = other.gameObject.GetComponent<PhotonView>();
        // Debug.Log(owner.Controller.ActorNumber + "es el controlador del objeto");
        //if (phView.IsMine)
        if (PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
        {
            PuedeBlanco = false;
            //material.DisableKeyword("_EMISSION");
            PhotonView pv = gameObject.GetComponent<PhotonView>();

            pv.RPC("RestarContadorRastro", RpcTarget.All);
        }
    }



    [PunRPC]
    void SumarContadorRastro()
    {
        ContinuaCorrutina = false;
        
        material.SetColor("_EmissionColor", Original * 1);
        ObjetocontadorRastro.contadorRastroLuz++;
    }



    [PunRPC]
    void RestarContadorRastro()
    {
        ContinuaCorrutina = true;
        ObjetocontadorRastro.contadorRastroLuz--;
        StartCoroutine(Lerp());
        //float t = (Time.time - 1f) / 2f;
        //float emission = Mathf.Lerp(1, 0, t);

        //material.SetFloat("_EmissionScaleUI", emission);

        //PhotonView pv = gameObject.GetComponent<PhotonView>();
        //Actualizado = material.GetColor("_EmissionColor");
        //pv.RPC("LlamadaCoroutina", RpcTarget.All, Actualizado, Original, 5f);


    }


    [PunRPC]
    void LlamadaCoroutina(Color startColor, Color endColor, float t)
    {
        StartCoroutine(QuitarRastro());
    }

    [PunRPC]
    IEnumerator Lerp()
    {


        float currentTime = 0;
        
        //while (currentTime < t)
        //{
        float time = 5f;

        while ((currentTime <= time) && ContinuaCorrutina)
        {
            ////https://answers.unity.com/questions/1038571/colorlerp-for-spriterender-is-not-smooth.html
            currentTime += Time.deltaTime;
            float lerp_Percentage = currentTime / time;

            float emission = Mathf.Lerp(1, 0f, lerp_Percentage);

            
            material.SetColor("_EmissionColor", Original * emission);

            yield return null;
        }

    }





    [PunRPC]
    IEnumerator QuitarRastro()
    {
        float currentTime = 0;
        float initialEmission = material.GetFloat("_EmissionScaleUI");
        //while (currentTime < t)
        //{
        float time = 5f;

        while (currentTime <= time)
        {
            ////https://answers.unity.com/questions/1038571/colorlerp-for-spriterender-is-not-smooth.html
            currentTime += Time.deltaTime;
            float lerp_Percentage = currentTime / time;

            float emission = Mathf.Lerp(initialEmission, 0f, lerp_Percentage);
            //  Debug.Log("COOORRRUUUTIIINA");
            // input_player
            material.SetFloat("_EmissionScaleUI", emission);

            Debug.Log("Estoy en whilecambiocolor");
            yield return null;
        }

        material.DisableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Original);
        material.SetFloat("_EmissionScaleUI", 0f);
        material.DisableKeyword("_EMISSION");
    }




}
