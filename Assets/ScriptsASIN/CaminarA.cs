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

    private TrailRenderer cola;

    public GameObject particulas;
    ParticleSystem sistema;



    public int iniciocaminar;


   // public GameObject ObjetoControllador;
    InputHandlerA _inputHandler;
    private CharacterController controller;
    private Vector2 moveVector;
    private float verticalVelocity;
    public float gravity = 25;
    public float jumpforce = 8;
    public float valorprueba;

    float principiodash = 0;

    public float valordash;

    public float speed = 8;
    private Vector2 lastMove;
    // Start is called before the first frame update
    void Start()
    {

        sistema = particulas.GetComponent<ParticleSystem>();

        sistema.startSize = 0;
        valordash= 0;


        cola = GetComponent<TrailRenderer>();

        cola.enabled = false;
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

            if (_inputHandler.Horizontal > 0) //SE COMPRUEBA SI SE VA PARA LA IZQUIERDA O VA PARA LA DERECHA
            {
                
                valorprueba += ((_inputHandler.Horizontal*speed) / 0.2f) * Time.deltaTime;
                valorprueba = Mathf.Min(valorprueba, speed); //COGE EL VALOR MINIMO
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
            else if(_inputHandler.Horizontal == 0 && iniciocaminar==1) //DEPENDIENDO DE SI VA PARA LA IZQUIERDA O DERECHA HARA UNA COSA U OTRA YA QUE HABRÁN NUMEROS EN NEGATIVO
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
               // moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            }

            if (_inputHandler._dash)
            {

                


                    sistema.startSize = 1;
                    //valordash += (dashSpeed / 5f) * Time.deltaTime;
                    //valordash = Mathf.Min(valordash, dashSpeed);
                //COGE EL VALOR MINIMO
                //Debug.Log("InicioDash");
                StartCoroutine(InicioDash());
                //Debug.Log("FinalDash");
                //valordash -= (dashSpeed / 5f) * Time.deltaTime;
                //valordash = Mathf.Max(valorprueba, 0);
                //moveVector.x = valordash;
                //sistema.startSize = 0;
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

    private IEnumerator ConjuntoDash()
    {
        yield return StartCoroutine(InicioDash());
        yield return  StartCoroutine(Dash());
        yield return  StartCoroutine(FinalDash());
        yield return null;

    }


    private IEnumerator InicioDash()
    {
        float currentTime = 0;
        
        //while (currentTime < t)
        //{
        float time = 0.20f;
        while (currentTime <= time)
        {
            currentTime += Time.deltaTime;
            float lerp_Percentage = currentTime / time;
            Vector3 dashDirection = Vector3.Cross(transform.forward, Vector3.up).normalized;

            valordash = Mathf.Lerp(principiodash, dashSpeed, lerp_Percentage);
            //valordash = Mathf.Lerp(valordash, dashSpeed, lerp_Percentage); ASI ESTABA ANTES, COMO EL VALOR DE VALOR DASH NO PARABA DE ACTUALIZARSE, NO SE ESTABA HACIENDO CORRECTAMENTE
            
            //moveVector.x = valorprueba;
            controller.Move(-dashDirection * valordash * Time.deltaTime);

            Debug.Log("dentro del While Dash");
            
            
            //valordash = Mathf.Lerp(valordash, dashSpeed, lerp_Percentage);
            //controller.Move(-dashDirection * valordash * Time.deltaTime);
            yield return null;
        }
        principiodash = valordash;
        //moveVector.x = valordash;
        yield return StartCoroutine(Dash());

    }


    private IEnumerator FinalDash()
    {
        float currentTime = 0;

        //while (currentTime < t)
        //{
        float time = 0.1f;
        while (currentTime <= time)
        {
            currentTime += Time.deltaTime;
            float lerp_Percentage = currentTime / time;
            Vector3 dashDirection = Vector3.Cross(transform.forward, Vector3.up).normalized;

            valordash = Mathf.Lerp(principiodash, 0, lerp_Percentage);
            //valordash = Mathf.Lerp(valordash, dashSpeed, lerp_Percentage); ASI ESTABA ANTES, COMO EL VALOR DE VALOR DASH NO PARABA DE ACTUALIZARSE, NO SE ESTABA HACIENDO CORRECTAMENTE

            //moveVector.x = valorprueba;
            controller.Move(-dashDirection * valordash * Time.deltaTime);

            Debug.Log("Final");


            //valordash = Mathf.Lerp(valordash, dashSpeed, lerp_Percentage);
            //controller.Move(-dashDirection * valordash * Time.deltaTime);
            yield return null;
        }
        principiodash = valordash;
        sistema.startSize = 0;
    }





    private IEnumerator Dash()
    {
        float startTime = Time.time;

        Debug.Log("Dash");


        while (Time.time < startTime + dashTime)
        {
            //cola.enabled = true;
            Vector3 dashDirection = Vector3.Cross(transform.forward, Vector3.up).normalized;
            controller.Move(-dashDirection * dashSpeed * Time.deltaTime);
           // controller.Move(transform.forward * dashSpeed * Time.deltaTime);

            yield return null;



        }



        yield return StartCoroutine(FinalDash());
        //cola.enabled = false;
        //sistema.startSize = 0;

    }


    




}
