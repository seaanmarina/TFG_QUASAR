using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionObjeto : MonoBehaviour
{
    public GameObject ObjetoACambiar;
    public GameObject ControlObjeto;
    InputObj _inputobj;
    Material Material1;
    public Material original;
    public Material cambio;
    // Start is called before the first frame update
    void Start()
    {
        _inputobj = ControlObjeto.GetComponent<InputObj>();
        Material1 = ObjetoACambiar.GetComponent<Renderer>().material;
      
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
                Material1.color = cambio.color;
                Debug.Log("estoy interaccoinando a tope de power");
            }
            else
            {
                Material1.color = original.color;
            }


        }
    }
}
