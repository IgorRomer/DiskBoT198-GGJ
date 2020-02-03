using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class godScript : MonoBehaviour
{
    public GameObject[] easyList;
    public Text txt;
    public float timer = 25.198f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 25.198f;
        Instantiate(easyList[Random.Range(0, 4)], new Vector3(0, 0, 0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        txt.text = "" + timer;

        if(timer <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}
