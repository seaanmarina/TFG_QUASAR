using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Controlador : MonoBehaviour
{
    public bool cambio;
    
    // Start is called before the first frame update
    void Start()
    {
        cambio = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cambio);
    }
}
