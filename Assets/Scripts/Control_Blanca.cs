using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Control_Blanca : MonoBehaviourPunCallbacks
{
    public int contadorBlanca;
    public int mantenerAltar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [PunRPC]
    void Update()
    {
        Debug.Log(mantenerAltar + "CONTAAADOOOR" );



    }
}
