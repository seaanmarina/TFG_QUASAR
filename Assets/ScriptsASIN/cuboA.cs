using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuboA : MonoBehaviour
{

    
    public GameObject ControlObjeto;
    public GameObject ControlDelCambio;
    InputObjA _inputobj;
    Material Material1;
    public Material original;
    public Material cambio;


    Color_ControladorA controladordelcambio;
    // Start is called before the first frame update
    void Start()
    {
        _inputobj = ControlObjeto.GetComponent<InputObjA>();
        Material1 = GetComponent<Renderer>().material;
        controladordelcambio = ControlDelCambio.GetComponent<Color_ControladorA>();

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
