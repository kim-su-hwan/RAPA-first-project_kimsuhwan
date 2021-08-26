using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapsCount : MonoBehaviour
{

    //public GameObject startpoint;
    //public GameObject halfpoint;
    public GameObject laps;


    bool startcheck;
    bool halfcheck;
    bool endcheck;

    int now_laps = 0;
    int first_lap_exception = 0;
    
    void Start()
    {
        startcheck = false;
        halfcheck = false;
        endcheck = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (halfcheck == true && startcheck == true && endcheck == true)
        {
            now_laps++;
            laps.GetComponent<Text>().text = "" + now_laps.ToString();
            halfcheck = false;
            startcheck = false;
            endcheck = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("StartLapTrigger"))
        {
            if (endcheck == true)
            {
                startcheck = true;
            }
            else
            {
                startcheck = false;
            }
        }
        else if (other.gameObject.name.Contains("HalfLapTrigger"))
        {
            halfcheck = true;
        }
        else if (other.gameObject.name.Contains("EndLapTrigger"))
        {
            if (halfcheck == true)
            {
                endcheck = true;
            }
            else
            {
                endcheck = false;
            }
        }
    }
}
