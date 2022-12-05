using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubo : MonoBehaviour
{

    
    public GameObject ControlObjeto;
    public GameObject ControlDelCambio;
    InputObj _inputobj;
    Material Material1;
    public Material original;
    public Material cambio;


    Color_Controlador controladordelcambio;
    // Start is called before the first frame update
    void Start()
    {
        _inputobj = ControlObjeto.GetComponent<InputObj>();
        Material1 = GetComponent<Renderer>().material;
        controladordelcambio = ControlDelCambio.GetComponent<Color_Controlador>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controladordelcambio.cambio)
        {
            Material1.color = cambio.color;
            Debug.Log("estoy interaccoinando a tope de power");
        }
        else
        {
            Material1.color = original.color;
        }
    }
}
