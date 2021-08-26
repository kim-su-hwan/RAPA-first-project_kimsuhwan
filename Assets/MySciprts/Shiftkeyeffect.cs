using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiftkeyeffect : MonoBehaviour
{
    // Start is called before the first frame update

    float time = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (time < 5)
            {

                GameObject go = Instantiate(transform.gameObject, transform.position, Quaternion.identity);
                ParticleSystem ps = go.GetComponent<ParticleSystem>();
                ps.Stop();
                ps.Play();
                time = 0;
            }

        }
    }
}
