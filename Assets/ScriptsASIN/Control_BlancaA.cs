using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Control_BlancaA : MonoBehaviourPunCallbacks
{
    public int contadorBlanca;
    public int mantenerAltar;
    public int contadorAsin;
    public int contadorPararBlanco;

    public bool CambiodeContador;
    
    // Start is called before the first frame update
    void Start()
    {
        CambiodeContador = true;
    }

    // Update is called once per frame
    [PunRPC]
    void Update()
    {
       Debug.Log(contadorAsin + "CONTAAADOOOR" );



    }
}
