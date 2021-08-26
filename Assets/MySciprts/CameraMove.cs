using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject TheCar;
    public float carx;
    public float cary;
    public float carz;

    public Transform cPositionup;
    public Transform cPositionback;

    public float cameraMovespeed = 0.5f;

    bool carUnderBridge;
    GameObject findCar;

    CarMove cmove;


    private void Start()
    {
        carUnderBridge = false;
        //transform.position = cPositionup.transform.position;
    }

    void Update()
    {
        /*
        carx = TheCar.transform.eulerAngles.x;
        cary = TheCar.transform.eulerAngles.y;
        carz = TheCar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(carx - carx, cary, carz - carz);
        
        //transform.eulerAngles = new Vector3(carx, cary, carz);
        */
        //CameraSetting();
        findCar = GameObject.Find("Car");


        transform.LookAt(findCar.transform.position);
    }

    void CameraSetting()
    {
        cmove = GameObject.Find("Car").GetComponent<CarMove>();
        
        if(cmove)
        {
            //카메라 무브
            if (cmove.isCollider)
            {
                transform.position = Vector3.Slerp(cPositionup.position, cPositionback.position, cameraMovespeed);
            }
            else
            {
                transform.position = Vector3.Slerp(cPositionback.position, cPositionup.position, cameraMovespeed);
            }
        }
        else
        {
            Debug.Log("No scripst reference");
        }

        


    }

}
