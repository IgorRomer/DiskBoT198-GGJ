using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    public bool entrouBlue = false;
    public GameObject blue;
    public GameObject orange;
    public static bool inControl = false;
    public bool entrouOrange = false;
    public static bool orangeGo = false;
    public static bool blueGo = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            inControl = false;
        }

     

        if (blueGo == true && orangeGo == true)
        {
            print("ESSA FEATURE TA PRONTA");
            goals.arrumarCabos = true;
            //COLOCAR AQUI O CHECK
        } else
        {
            goals.arrumarCabos = false;
            print("CONCERTA ESSA POHA");

        }

        if (entrouBlue == true)
        {

            if (Input.GetKey(KeyCode.E))
            {
                inControl = true;
                if (Input.GetKey(KeyCode.A))
                {
                    blue.transform.transform.Rotate(new Vector3(0, -2, 0), Space.Self);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    blue.transform.transform.Rotate(new Vector3(0, 2, 0), Space.Self);
                }

            } else
            {
                inControl = false;
            }
        }

        if (entrouOrange == true)
        {

            
            if (Input.GetKey(KeyCode.E))
            {
                inControl = true;
                if (Input.GetKey(KeyCode.A))
                {
                    orange.transform.transform.Rotate(new Vector3(0, -2, 0), Space.Self);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    orange.transform.transform.Rotate(new Vector3(0, 2, 0), Space.Self);
                }
            }
            else
            {
                inControl = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BlueConfig")
        {
            entrouBlue = true;
            blue = other.gameObject;
        }

        if (other.gameObject.tag == "OrangeConfig")
        {
            entrouOrange = true;
            orange = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlueConfig")
        {
            entrouBlue = false;
        }

        if (other.gameObject.tag == "OrangeConfig")
        {
            entrouOrange = false;
        }
    }
}
