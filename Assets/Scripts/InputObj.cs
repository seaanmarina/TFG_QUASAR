using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputObj : MonoBehaviour
{
   
    public bool _puedeInteraccionar;
    public bool _cambiodecolor;
    public bool _prueba;


    // Start is called before the first frame update
    void Start()
    {
        _puedeInteraccionar = false;
        _cambiodecolor = false;
        _prueba = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

   
   


    void OnInteraccionar()
    {
        if (_puedeInteraccionar)
        {
            Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            _cambiodecolor = !_cambiodecolor;
            Debug.Log(_cambiodecolor);


        }
        
           
        

    }

    void OnPrueba()
    {
        Debug.Log("Se hace la prueba");
        _prueba = true;
    }

}
