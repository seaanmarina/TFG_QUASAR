using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionObjeto : MonoBehaviour
{

    public GameObject ControlObjeto;
    InputObj _inputobj;
    // Start is called before the first frame update
    void Start()
    {
        _inputobj = ControlObjeto.GetComponent<InputObj>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("puede interaccioar");
            _inputobj._puedeInteraccionar = true;


        }
    }
}
