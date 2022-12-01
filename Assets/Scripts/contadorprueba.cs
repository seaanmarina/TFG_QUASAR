using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contadorprueba : MonoBehaviour
{

    private int contadordelaprueba;
    // Start is called before the first frame update
    void Start()
    {
        contadordelaprueba = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("personaje dentro");
            contadordelaprueba++;
            Debug.Log(contadordelaprueba);
        }
    }
}
