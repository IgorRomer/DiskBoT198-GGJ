
using UnityEngine;
using System.Collections;

public class pegue_o_pombo : MonoBehaviour
{
    public float x = 0.05f;
    public float z = 0.05f;
    float speed = 5;

    void Start()
    {
        Invoke("changeMove", 0.6f);   
    }

    void Update()
    {
        this.transform.position += new Vector3(x, 0, z);    
    }

    void changeMove()
    {
        x = Random.Range(-0.05f, 0.05f);
        z = Random.Range(-0.05f, 0.05f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        x *= -1;
        z *= -1;
    }
}
