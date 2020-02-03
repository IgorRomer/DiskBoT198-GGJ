using UnityEngine;
using System.Collections;

public class Simple : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.World);

    }
}
