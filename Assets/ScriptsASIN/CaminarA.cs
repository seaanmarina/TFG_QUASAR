using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CaminarA : MonoBehaviour
{
    public Vector3 moveDir;


    public float dashSpeed;
    public float dashTime;
    

    [SerializeField] private TrailRenderer tr;

    PhotonView view;

    public Camera cam;



    public int iniciocaminar;


   // public GameObject ObjetoControllador;
    InputHandlerA _inputHandler;
    private CharacterController controller;
    private Vector2 moveVector;
    private float verticalVelocity;
    public float gravity = 25;
    public float jumpforce = 8;
    public float valorprueba;

    public float speed = 8;
    private Vector2 lastMove;
    // Start is called before the first frame update
    void Start()
    {

        iniciocaminar = 0;


        controller = GetComponent<CharacterController>();
        _inputHandler = GetComponent<InputHandlerA>();
        //cam = Camera.main;
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
        {
            cam.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (view.IsMine)
        {

           // Debug.Log(speed);
            moveVector = Vector2.zero;
           // moveVector.x = _inputHandler.Horizontal * speed;

            if (_inputHandler.Horizontal > 0)
            {
                
                valorprueba += ((_inputHandler.Horizontal*speed) / 0.2f) * Time.deltaTime;
                valorprueba = Mathf.Min(valorprueba, speed);
                iniciocaminar = 1;
                moveVector.x = valorprueba;
            }
            else if(_inputHandler.Horizontal < 0)
            {
                valorprueba += ((_inputHandler.Horizontal * speed) / 0.2f) * Time.deltaTime;
                valorprueba = Mathf.Max(valorprueba, -speed);
                iniciocaminar = 2;
                moveVector.x = valorprueba;
                //TO DO: PARA CADA UNO TOMARLO DIERENTE PORQUE UNO VA HACIA LA IZQUIERDA Y OTRO VA HACIA LA DERECHA. 
            }
            else if(_inputHandler.Horizontal == 0 && iniciocaminar==1)
            {
                valorprueba -= (speed / 0.2f) * Time.deltaTime;
                valorprueba = Mathf.Max(valorprueba, 0);
                moveVector.x = valorprueba;
                //iniciocaminar = true;
            }
            else if (_inputHandler.Horizontal == 0 && iniciocaminar == 2)
            {
                valorprueba += (speed / 0.2f) * Time.deltaTime;
                valorprueba = Mathf.Min(valorprueba, 0);
                moveVector.x = valorprueba;
                //iniciocaminar = true;
            }


            //moveVector.x = Mathf.Lerp(moveVector.x, _inputHandler.Horizontal * speed, 6 / 2);
            Vector3 dir = new Vector3(moveVector.x, 0, 0).normalized;


            /*if(_inputHandler.Horizontal != 0 && iniciocaminar)
            {
                iniciocaminar = false;
                StartCoroutine(AcelerarCaminar());
                



            }*/
            float changeRatePerSecond = 1 / 3 * Time.deltaTime;


            valorprueba  = Mathf.MoveTowards(valorprueba, speed, changeRatePerSecond);



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


    private IEnumerator AcelerarCaminar()
    {
        float currentTime = 0;

        valorprueba = 0;



        while (currentTime <= 5)
        {
            ////https://answers.unity.com/questions/1038571/colorlerp-for-spriterender-is-not-smooth.html
            currentTime += Time.deltaTime;
            float lerp_Percentage = currentTime / 5;


            //  Debug.Log("COOORRRUUUTIIINA");
            // input_player
            Debug.Log(valorprueba + "CAMINAR");
            valorprueba = Mathf.Lerp(valorprueba, _inputHandler.Horizontal * speed, lerp_Percentage);
            yield return null;

           
        }



    }




}
