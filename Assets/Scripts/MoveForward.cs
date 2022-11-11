using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public GameObject PLayer;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
    
    }

    public void moveForward()
    {
        PLayer.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
}
