using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Puede_InteraccionarA : MonoBehaviourPunCallbacks
{
    public bool _puede;
    public float timer;
    public float timer2;
    public float tiempototal;
    public bool interacciona;
    [PunRPC]
    // Start is called before the first frame update
    void Start()
    {
        _puede = false;
    }

    // Update is called once per frame
    [PunRPC]
    void Update()
    {
        //Debug.Log(timer + "El timer esta en ese numero");
        //Debug.Log(timer2 + "El timer esta en ese numero2");
        //Debug.Log(tiempototal + "El timer esta en ese numero TOTAL");
        
    }
}
