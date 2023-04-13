using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ColisionadorAltar : MonoBehaviourPunCallbacks
{
    InputHandlerA handler;

    // Start is called before the first frame update
    void Start()
    {
        handler = GetComponent<InputHandlerA>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    { /*Debug.Log("INPUT HANDLER A TOPEEEEEEEEE" + other.name);*/
        if (other.tag=="Entrada")
        {
            //Debug.Log("INPUT HANDLER A TOPEEEEEEEEE TAAAAAG");
            handler.puedeInteraccion = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Entrada")
        {
            handler.puedeInteraccion = false;
        }
    }



}
