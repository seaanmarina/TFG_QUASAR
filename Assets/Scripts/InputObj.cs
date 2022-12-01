using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputObj : MonoBehaviour
{
   
    public bool _puedeInteraccionar;
    public bool _cambiodecolor;

    
    // Start is called before the first frame update
    void Start()
    {
        _puedeInteraccionar = false;
        _cambiodecolor = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

   
   


    void OnInteraccionar()
    {
        if (_puedeInteraccionar)
        {
            _cambiodecolor = !_cambiodecolor;
            Debug.Log(_cambiodecolor);


        }
        
           
        

    }

}
