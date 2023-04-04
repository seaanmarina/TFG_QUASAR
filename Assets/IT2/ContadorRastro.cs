using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ContadorRastro : MonoBehaviourPunCallbacks
{

    public int contadorRastroLuz;
    // Start is called before the first frame update
    void Start()
    {
        contadorRastroLuz = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
