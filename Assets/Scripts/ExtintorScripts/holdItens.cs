using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdItens : MonoBehaviour
{
    public bool eSwitch = false;
    public bool extintorGo = false;
    public bool desentupidorGo = false;
    public bool silverGo = false;
    public bool holding = false;
    public GameObject objExt;
    public GameObject miniObjExt;
    public GameObject extPowerObj;
    public GameObject miniObjDes;
    public GameObject desPowerObj;
    public GameObject miniObjSil;
    public GameObject silPowerObj;

    public Material placeHolderVaso;
    public Mesh preso;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            eSwitch = !eSwitch;
        }

        //Programação do extintor
        if(extintorGo == true)
        {
            if (eSwitch && holding == false)
            {
                objExt.SetActive(false);
                holding = true;
                miniObjExt.SetActive(true);
                
            }
        }

        if (miniObjExt.activeSelf == true && Input.GetKey(KeyCode.Space))
        {
            extPowerObj.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            extPowerObj.SetActive(false);
        }

        //Programação do desentupidor
        if (desentupidorGo == true)
        {
            if (eSwitch && holding == false)
            {
                objExt.SetActive(false);
                holding = true;
                miniObjDes.SetActive(true);

            }
        }

        if (miniObjDes.activeSelf == true && Input.GetKey(KeyCode.Space))
        {
            desPowerObj.SetActive(true);
            miniObjDes.GetComponent<Animator>().SetBool("go", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            desPowerObj.SetActive(false);
            miniObjDes.GetComponent<Animator>().SetBool("go", false);
        }

        //Programação do silver tape
        if (silverGo == true)
        {
            if (eSwitch && holding == false)
            {
                objExt.SetActive(false);
                holding = true;
                miniObjSil.SetActive(true);

            }
        }

        if (miniObjSil.activeSelf == true && Input.GetKey(KeyCode.Space))
        {
            silPowerObj.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            silPowerObj.SetActive(false);
        }

        //Largando o item no chão
        if (!eSwitch && holding == true)
        {
            objExt.transform.position = new Vector3(miniObjExt.transform.position.x, objExt.transform.position.y, miniObjExt.transform.position.z);
            objExt.transform.rotation = this.transform.rotation;
            objExt.SetActive(true);
            
            holding = false;
            miniObjExt.SetActive(false);
            miniObjDes.SetActive(false);
            miniObjSil.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //Programação do extintor
        if (other.gameObject.tag == "extintor" && holding == false)
        {
            objExt = other.gameObject;
            extintorGo = true;
            desentupidorGo = false;
            silverGo = false;
        }
        if (other.gameObject.tag == "fire" && extPowerObj.activeSelf == true)
        {
            Destroy(other.gameObject);
            goals.totalFires--;
        }


        //Programação do desentupidor
        if (other.gameObject.tag == "desentupidor" && holding == false)
        {
            objExt = other.gameObject;
            desentupidorGo = true;
            extintorGo = false;
            silverGo = false;
        }
        if (other.gameObject.tag == "vaso" && desPowerObj.activeSelf == true)
        {
            other.gameObject.GetComponent<Renderer>().material = placeHolderVaso;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            goals.totalVasos--;
        }

        //Programação da Silver Tape
        if (other.gameObject.tag == "silver" && holding == false)
        {
            objExt = other.gameObject;
            silverGo = true;
            extintorGo = false;
            desentupidorGo = false;
        }
        if (other.gameObject.tag == "fuga" && silPowerObj.activeSelf == true)
        {
            other.GetComponent<pegue_o_pombo>().x = 0;
            other.GetComponent<pegue_o_pombo>().z = 0;
            other.gameObject.GetComponent<MeshFilter>().sharedMesh = preso;

            goals.totalFugas--;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "extintor")
        {
            extintorGo = false;
        }

        if (other.gameObject.tag == "desentupidor")
        {
            desentupidorGo = false;
        }

        if (other.gameObject.tag == "silver")
        {
            silverGo = false;
        }
    }
}
