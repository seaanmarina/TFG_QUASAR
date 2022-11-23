using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public bool _dash;
    public bool _salto;

    public float Horizontal => _movement.x;
    public float Vertical => _movement.y;

    // Start is called before the first frame update
    void Start()
    {
        _salto = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 _movement;
    void OnMove(InputValue inputValue)
    {
      //  Debug.Log("hola");
        _movement = inputValue.Get<Vector2>();
       // Debug.Log(_movement);

    }


    void OnJump() {
       // Debug.Log("salto");
        _salto = true;
    }

    void OnDash()
    {
        Debug.Log("dash");
        _dash = true;
    }

}
