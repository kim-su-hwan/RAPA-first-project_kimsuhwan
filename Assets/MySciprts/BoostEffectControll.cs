using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostEffectControll : MonoBehaviour
{
    public GameObject pFire;
    float time = 0;
    GameObject go = null;
    bool makeit = false;
    ParticleSystem ps;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (time == 0)
            {
                go = Instantiate(pFire, transform.position, Quaternion.identity);
                ps = go.GetComponent<ParticleSystem>();
                ps.Play();
            }
            else
            {

                time += Time.deltaTime;
                if (time > ps.duration)
                {
                    Destroy(go);
                }
                else
                {
                    go.transform.position = transform.position;
                }
            }

        }


        //EffectPlay();
    }

    void EffectPlay()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //GameObject go = Instantiate(pFire, transform.position, Quaternion.identity);
            //ParticleSystem ps = go.GetComponent<ParticleSystem>();
            //ps.Play();



            if (time > pFire.GetComponent<ParticleSystem>().duration)
            {
                GameObject go = Instantiate(pFire, transform.position, Quaternion.identity);
                ParticleSystem ps = go.GetComponent<ParticleSystem>();
                ps.Play();
                time = 0;
                //print("effect play");
            }


        }

    }

}
