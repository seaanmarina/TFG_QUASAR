using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class EntradaaAltar : MonoBehaviourPunCallbacks
{
    
    public bool _entradaNaranja;
    public bool _entradaAzul;

    EstadoAltar estadoaltar;


    public GameObject controlinputs;
    InputsAltar AltarInputs;


    // Start is called before the first frame update
    void Start()
    {
        
        estadoaltar = GetComponent<EstadoAltar>();
        controlinputs = GameObject.FindGameObjectWithTag("AltarInputs");
        AltarInputs = controlinputs.GetComponent<InputsAltar>();
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
        }
        


    }

    [PunRPC]
    void AñadiraArray(int id)
    {

        AltarInputs._miArray.Add(id);


    }


    [PunRPC]
    void Comprobar()
    {

        if (_entradaNaranja)
        {
            AltarInputs.estadoNaranja = true;
        }
        else
        {
            AltarInputs.estadoAzul = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        
    }



}
