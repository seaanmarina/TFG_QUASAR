using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class InputsAltar : MonoBehaviourPunCallbacks
{

    public bool _input;
    public bool _puedeInteraccionar;
    public bool InteraccionAltar;

    public bool estadoAzul;
    private bool altarActivado;

    public bool estadoNaranja;
    PhotonView pv;


   public GameObject objetocambiar;
    Material Material1;

   public GameObject objetocambiar2;
    Material Material2;

    public Material original;

    private bool booleanaPrueba;

    bool acceder;

    public bool Temporizador;
    public bool PuedeTemporizador;


    // Start is called before the first frame update
    void Start()
    {

        Temporizador = false;
        PuedeTemporizador = true;

        Material1 = objetocambiar.GetComponent<Renderer>().material;
        Material2 = objetocambiar2.GetComponent<Renderer>().material;
        pv = gameObject.GetComponent<PhotonView>();
        _input = false;
        _puedeInteraccionar = false;
        InteraccionAltar = false;
        altarActivado = false;
        estadoAzul = false;
        estadoNaranja = false;
        acceder = true;

    }

    // Update is called once per frame
    void Update()
    {









        if (_puedeInteraccionar)
        {

            PhotonView pv = gameObject.GetComponent<PhotonView>();
            pv.RPC("comprobacionEstados", RpcTarget.All);
            InteraccionAltar = _input;
            if (InteraccionAltar && PuedeTemporizador)
            {
                Temporizador = true;
                PuedeTemporizador = false;
            }
        }
        else
        {
            InteraccionAltar = false;
        }
            

        // if(estadoAzul && estadoNaranja)    
        //    {

        //        foreach (int valor in _miArray)
        //        {
        //            PhotonView pvv = PhotonView.Find(valor); // obtiene el PhotonView del jugador remoto
        //            GameObject playerGO = pvv.gameObject;
        //            Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
        //            foreach (Photon.Realtime.Player player in players)
        //            {


        //                PhotonView playerView = PhotonView.Find(player.ActorNumber); // Obtiene el PhotonView del jugador.
                       
        //                int actorNr = player.ActorNumber;
        //                int viewId = actorNr * PhotonNetwork.MAX_VIEW_IDS + 1;

        //                if(viewId == valor)
        //                {
        //                    pv.RPC("comprobacionEstado", player);
        //                }
        //            }
        //            }
            
        //}
    }


    [PunRPC]
    void comprobacionEstados()
    {
        InteraccionAltar = _input;

    }


    //[PunRPC]
    //void cambioEstado()
    //{
    //    _miArray.Clear();
    //    estadoAzul = false;
    //    estadoNaranja = false;

    //}
}
