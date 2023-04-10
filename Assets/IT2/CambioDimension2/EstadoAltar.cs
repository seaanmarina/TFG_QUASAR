using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class EstadoAltar : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private bool altarActivado;


    public bool estadoAzul;
   
    public bool estadoNaranja;
    // Start is called before the first frame update
    void Start()
    {
        
        altarActivado = false;
        estadoAzul = false;
        estadoNaranja = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ALTAR ESTÁ " + altarActivado);
        

    }


    [PunRPC]
    void AltarActivo(bool valor)
    {

        Debug.Log("ALTAR ACTIVO");
    }
}
