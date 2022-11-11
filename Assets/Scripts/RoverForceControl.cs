using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverForceControl : MonoBehaviour
{

    public GameObject PLayer;
    public float SpeedRotation;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "UpArrow":
                GoForward();
                break;
            case "RightArrow":
                GoRight();
                break;
            case "LeftArrow":
                GoLeft();
                break;
            case "DownArrow":
                GoBack();
                break;
        }
    }

    public void GoForward()
    {
        PLayer.GetComponent<Rigidbody>().AddForce(PLayer.transform.forward * speed);
    }

    public void GoRight()
    {
        PLayer.transform.Rotate(0, SpeedRotation, 0);
    }
    public void GoLeft()
    {
        PLayer.transform.Rotate(0, -SpeedRotation, 0);
    }
    public void GoBack()
    {
        PLayer.GetComponent<Rigidbody>().AddForce(-PLayer.transform.forward * speed);
    }
}
