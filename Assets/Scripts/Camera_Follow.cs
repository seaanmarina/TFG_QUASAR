using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    
    public float z;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public GameObject capsula;
    public GameObject ojo;

    private GameObject playerCharacter;
    void Start()
    {

        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        //playerCharacter.layer = LayerMask.NameToLayer("Jugador");

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {

            
            if (go.GetComponent<PhotonView>().Owner.ActorNumber != PhotonNetwork.LocalPlayer.ActorNumber)
            {


                GameObject childCapsule = go.transform.Find("Capsule").gameObject;
                GameObject childTransform = childCapsule.transform.Find("Sphere").gameObject;
                go.layer = LayerMask.NameToLayer("Jugador");
                childCapsule.layer = LayerMask.NameToLayer("Jugador");
                childTransform.layer = LayerMask.NameToLayer("Jugador");

                //go.layer = LayerMask.NameToLayer("Jugador");
                //    PhotonView view = go.GetComponent<PhotonView>();
                //    if (view != null)
                //    {
                //        view.ObservedComponents = new List<Component>();
                //        view.Synchronization = ViewSynchronization.Off;
            }
            //}
        }



        z = transform.position.z;
    }


    
 

    void Update()
    {
        

    }

    void LateUpdate()
    {//lo hace despues

        
            Vector3 position = (transform.position);
            position.y = (target.position + offset).y;
            position.x = (target.position + offset).x;
           // position.z = z;

            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, position, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        transform.rotation = Quaternion.identity;
        transform.LookAt(target);

 



    }
}
