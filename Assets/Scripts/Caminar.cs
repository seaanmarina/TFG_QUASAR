using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : MonoBehaviour
{
    public Vector3 moveDir;


    public float dashSpeed;
    public float dashTime;
    

    [SerializeField] private TrailRenderer tr;


    public Camera cam;
    


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
        //cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(speed);
        moveVector = Vector2.zero;
        moveVector.x = _inputHandler.Horizontal * speed;


        Vector3 dir = new Vector3(moveVector.x, 0, 0).normalized;






        if (moveVector.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            transform.LookAt(transform.position + new Vector3(0, 0, moveVector.x));//mira a un punto
            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        }

        if (_inputHandler._dash)
        {
            StartCoroutine(Dash());
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

    private IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            controller.Move(moveDir * dashSpeed * Time.deltaTime);

            yield return null;
        }


    }

   



}
