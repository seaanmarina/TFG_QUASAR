using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionObjeto : MonoBehaviour
{
    public GameObject ObjetoACambiar;
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
        Material1 = ObjetoACambiar.GetComponent<Renderer>().material;
        controladordelcambio = ControlDelCambio.GetComponent<Color_Controlador>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("puede interaccioar");
            _inputobj._puedeInteraccionar = true;

            if (_inputobj._cambiodecolor)
            {
                controladordelcambio.cambio = true;
                Debug.Log("estoy interaccoinando a tope de power");
            }
            else
            {
                controladordelcambio.cambio = false;
            }

            
        }
    }
}
