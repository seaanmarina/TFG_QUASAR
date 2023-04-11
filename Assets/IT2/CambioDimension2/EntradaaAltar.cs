using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class EntradaaAltar : MonoBehaviourPunCallbacks
{
    
    public bool _entradaNaranja;
    public bool _entradaAzul;


    public GameObject estadoAltarObj;
    EstadoAltar estadoaltar;


    public GameObject controlinputs;
    InputsAltar AltarInputs;

    bool AñadirArray;

    bool canEnter;


    // Start is called before the first frame update
    void Start()
    {

        canEnter = true;
        controlinputs = GameObject.FindGameObjectWithTag("AltarInputs");
        AltarInputs = controlinputs.GetComponent<InputsAltar>();

        estadoAltarObj = GameObject.FindGameObjectWithTag("AltarInputs");
        estadoaltar = estadoAltarObj.GetComponent<EstadoAltar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        PhotonView phView = other.gameObject.GetComponent<PhotonView>();
        if (PhotonNetwork.LocalPlayer.ActorNumber == other.GetComponent<PhotonView>().Owner.ActorNumber)
        {
            PhotonView pv = gameObject.GetComponent<PhotonView>();
            AltarInputs._puedeInteraccionar = true;
            int actorNr = other.GetComponent<PhotonView>().Owner.ActorNumber;
            int viewId = actorNr * PhotonNetwork.MAX_VIEW_IDS + 1;

            if (AltarInputs.InteraccionAltar)
            {
                
                //int longitud = AltarInputs._miArray.Length;

                //int[] nuevoArray = new int[longitud + 1];

                //nuevoArray[longitud + 1] = viewId;

                pv.RPC("AñadiraArray", RpcTarget.All, viewId);

                pv.RPC("Comprobar", RpcTarget.All);

            }
            //else
            //{
            //    canEnter = true;
            //}
         
        }
        


    }

    [PunRPC]
    void AñadiraArray(int id)
    {
        //if (canEnter)
        //{
            foreach (int valor in estadoaltar._miArray)
            {
                if (valor == id)
                {
                    AñadirArray = true;
                }
            }

            if(!AñadirArray)
            {
                estadoaltar._miArray.Add(id);
                AñadirArray = false;
            }
            
            canEnter = false;
           
        //}
    }


    [PunRPC]
    void Comprobar()
    {

        if (_entradaNaranja)
        {
            estadoaltar.estadoNaranja = true;
        }
        else
        {
            estadoaltar.estadoAzul = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        AltarInputs._puedeInteraccionar = false;
    }



}
