using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Control_Blanca : MonoBehaviour
{
    public int contadorBlanca;
    // Start is called before the first frame update
    void Start()
    {
        contadorBlanca = 0;
    }

    // Update is called once per frame
    [PunRPC]
    void Update()
    {
        Debug.Log(contadorBlanca);



    }
}
