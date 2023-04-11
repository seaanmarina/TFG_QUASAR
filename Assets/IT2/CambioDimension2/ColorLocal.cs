using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ColorLocal : MonoBehaviourPunCallbacks
{

    public bool CambioColorLocal;


    public GameObject ObjetoACambiar1;
    public GameObject ObjetoACambiar2;


    Material Material1;
    Material Material2;


    public Material original;
    public Material cambiar;
    public Material blanco;


    public Color StartColor;
    public Color EndColor;


    public GameObject estadoAltarObj;
    EstadoAltar estadoaltar;

    int valor;

    PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        valor = 1;
        CambioColorLocal = false;
        pv = GetComponent<PhotonView>();

        Material1 = ObjetoACambiar1.GetComponent<Renderer>().material;
        Material2 = ObjetoACambiar2.GetComponent<Renderer>().material;


        estadoAltarObj = GameObject.FindGameObjectWithTag("AltarInputs");
        estadoaltar = estadoAltarObj.GetComponent<EstadoAltar>();

        Material1.DisableKeyword("_EMISSION");
        Material2.DisableKeyword("_EMISSION");
    }

    // Update is called once per frame
    [PunRPC]
    void Update()
    {
        
       

    }

    
    public void cambiocontrolador()
    {
        if (CambioColorLocal && !estadoaltar.altarActivado)
        {
            Material1.color = cambiar.color;
            Material1.SetColor("_EmissionColor", EndColor * 1);
            Material1.EnableKeyword("_EMISSION");
            valor = 1;
            PhotonView pv = gameObject.GetComponent<PhotonView>();
            pv.RPC("CambiarColorPublico", RpcTarget.All);
            //pv.RPC("CambiarColorPublico", RpcTarget.All);
        }
        else
        {
            Material1.color = original.color;
            Material2.color = original.color;
            Material1.DisableKeyword("_EMISSION");
            Material2.DisableKeyword("_EMISSION");
        }
    }




        [PunRPC]
    void CambiarColorPublico()
    {
        Material2.color = cambiar.color;
        Material2.SetColor("_EmissionColor", EndColor * 1);
        Material2.EnableKeyword("_EMISSION");

        Debug.Log("Estoy en cambiocontroladorotro");

    }


}
