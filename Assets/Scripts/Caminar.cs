using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : MonoBehaviour
{

    InputHandler _inputHandler;
    private CharacterController controller;
    private Vector2 moveVector;
    private float verticalVelocity;
    public float gravity = 25;
    public float jumpforce = 8;


    public float speed = 8;
    private Vector2 lastMove;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _inputHandler = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(speed);
        moveVector = Vector2.zero;
        moveVector.x = _inputHandler.Horizontal * speed;
        
        if (moveVector.magnitude > 0)
        {
            transform.LookAt(transform.position + new Vector3(0, 0, moveVector.x));//mira a un punto
        }

        if (_inputHandler._dash)
        {
            speed = 100;
            _inputHandler._dash = false;
        }
        else
        {
            speed = 8;
        }

         if (controller.isGrounded)
        {
           /// Debug.Log("estoy en el terra");
            //verticalVelocity = -1;

            if (_inputHandler._salto)
            {
                
                verticalVelocity = jumpforce;
                _inputHandler._salto = false;
            }


        }

        else
        {
          //  Debug.Log("no estoy e nel suelo");
            verticalVelocity -= gravity * Time.deltaTime;

            moveVector = lastMove;

        }

        moveVector.y = verticalVelocity; /////////////OJO PARA EL SALTO CONTROLADO


        controller.Move(moveVector * Time.deltaTime);
        lastMove = moveVector;

    }



   



}
