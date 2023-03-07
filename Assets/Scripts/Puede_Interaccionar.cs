using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Puede_Interaccionar : MonoBehaviourPunCallbacks
{
    public bool _puede;
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
        
    }
}
