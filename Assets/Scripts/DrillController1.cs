using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillController1 : MonoBehaviour
{

    public GameObject Drill;
    [SerializeField]
    private float forwardBackwardTilt = 0;
    [SerializeField]
    private float sideToSideTilt = 0;
    private Vector3 startPos;
    [SerializeField] ParticleSystem DrilPart;
    public GameObject DrillCon;
    public Transform topOfJoyStick;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrillControl()
    {
        forwardBackwardTilt = topOfJoyStick.rotation.eulerAngles.x;
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);
            Drill.transform.localPosition = new Vector3(0.1f, 0, 0);
            if (Drill.transform.localPosition.x >= 10)
            {
                Drill.transform.localPosition = new Vector3(10, 0, 0);
            }
        }
        else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
        {
            Drill.transform.localPosition = new Vector3(0.1f, 0, 0);
            if (Drill.transform.localPosition.x <= -10)
            {
                Drill.transform.localPosition = new Vector3(-10, 0, 0);
            }
        }

        sideToSideTilt = topOfJoyStick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Mathf.Abs(sideToSideTilt - 360);
            Drill.transform.localPosition = new Vector3(0, 0, -0.1f);
            if (Drill.transform.localPosition.z <= -10)
            {
                Drill.transform.localPosition = new Vector3(0, 0, -10);
            }
        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            Drill.transform.localPosition = new Vector3(0, 0, 0.1f);
            if (Drill.transform.localPosition.z >= 10)
            {
                Drill.transform.localPosition = new Vector3(0, 0, 10);
            }
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            transform.localPosition = new Vector3(0, -0.1f, 0);
        }
        else if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            transform.localPosition = new Vector3(0, 0.1f, 0);
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            DrillCon.transform.Rotate(0, 0.1f, 0);
            DrilPart.Play(DrilPart);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerH"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerH"))
        {
            transform.rotation = Quaternion.Euler(-90, 0, 90);
        }
    }
}
