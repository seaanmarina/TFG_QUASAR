using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorA : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Que me chocoAAAAAAAAAAAAAAAAAAAAA");
        if (other.gameObject.tag == "Player")
        {
          //  Debug.Log("Que me chocoAAAAAAAAAAAAAAAAAAAAA");
            Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>(), true);
        }

    }

}
