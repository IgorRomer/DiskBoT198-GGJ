using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godScript : MonoBehaviour
{
    public GameObject[] easyList;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(easyList[Random.Range(0, 4)], new Vector3(0, 0, 0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
