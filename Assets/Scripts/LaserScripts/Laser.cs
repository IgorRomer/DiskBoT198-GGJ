using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject lightReactor;
    private LineRenderer lr;
    public bool blue = false;
    public bool orange = false;
    

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }

            if (hit.collider.gameObject == lightReactor && blue == true)
            {
                PlayerConfig.blueGo = true;
            }
            
            if(hit.collider.gameObject != lightReactor && blue == true)
            {
                PlayerConfig.blueGo = false;
            }

            if (hit.collider.gameObject != lightReactor && orange == true)
            {
                PlayerConfig.orangeGo = false;
            }

            if (hit.collider.gameObject == lightReactor && orange == true)
            {
                PlayerConfig.orangeGo = true;
            }
            
        }

        
        else lr.SetPosition(1, transform.forward * 5000);
    }
}
