
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    
    public float z;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
   

    void Start()
    {

        z = transform.position.z;
    }

    void Update()
    {
        

    }

    void LateUpdate()
    {//lo hace despues

        
            Vector3 position = (transform.position);
            position.y = (target.position + offset).y;
            position.x = (target.position + offset).x;
           // position.z = z;

            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, position, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            transform.LookAt(target);

 



    }
}
