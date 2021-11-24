using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float xSensitivity = 2f;
    float ySensitivity = 2f;
    float xMouse = 0f;
    float yMouse = 0f;

    public Transform objectA;
    public Transform objectB;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Make ObjectA's position match objectB
        objectA.position = objectB.position;

        //Now parent the object so it is always there
        objectA.parent = objectB;
        
        if (Input.GetMouseButton(1)) //right click
        {
            xMouse += Input.GetAxis("Mouse X") * xSensitivity;
            yMouse -= Input.GetAxis("Mouse Y") * ySensitivity;
            transform.eulerAngles = new Vector3(yMouse, xMouse, 0f);
        }

    }
}
