using UnityEngine;
using System.Collections;

 
public class MoveLook : MonoBehaviour
{
    public CharacterController _controller;
    public float _speed = 5;
    public float _rotationSpeed = 180;

    private Vector3 rotation;

    void Update()
    {
        
            this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);

            Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
            move = this.transform.TransformDirection(move);
            _controller.Move(move * _speed);
            this.transform.Rotate(this.rotation);
        
    }
}

