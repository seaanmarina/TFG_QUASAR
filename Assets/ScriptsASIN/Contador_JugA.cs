using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Contador_JugA : MonoBehaviour
{

    public int contador;
    public int contadorNombre;
    // Start is called before the first frame update
    void Start()
    {
        contador = 2;
        contadorNombre = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(contador + "contador");
    }
}
