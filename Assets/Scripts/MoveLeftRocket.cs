using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRocket : MonoBehaviour
{
    public GameObject PLayer;
    public float rotSpeed = 100f;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnLeft()
    {
        PLayer.transform.Rotate(0, 0, rotSpeed);
    }

    public void TurnRight()
    {
        PLayer.transform.Rotate(0, 0, -rotSpeed);
    }
}
