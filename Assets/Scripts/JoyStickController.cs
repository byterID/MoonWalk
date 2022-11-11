using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{
    public GameObject PLayer;
    public GameObject Drill;
    public GameObject GrabHand;
    public Transform topOfJoyStick;
    private Vector3 startPos;
    [SerializeField]
    private float forwardBackwardTilt = 0;
    [SerializeField]
    private float sideToSideTilt = 0;
    int MasterInput = 1;
    public GameObject[] Monitors;
    bool drillIsTurned;
    bool grabIsTurned;
    bool roverIsTurned;

    [SerializeField] ParticleSystem DrilPart;

    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    public GameObject DrillCon;


    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        roverIsTurned = false;
        drillIsTurned = false;
        grabIsTurned = false;

    }


    void Update()
    {
        if (MasterInput == 1)
        {
            RoverControl();
        }
        else if (MasterInput == 2)
        {
            //DrillControl();
        }
        else if (MasterInput == 3)
        {
           // GrabberHand();
        }
    }

    public void RoverControl()
    {
        forwardBackwardTilt = topOfJoyStick.rotation.eulerAngles.x;
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 200)
        {
            forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);
            PLayer.GetComponent<Player>().GoBack();
        }
        else if (forwardBackwardTilt > 20 && forwardBackwardTilt < 74)
        {
            PLayer.GetComponent<Player>().GoForward();
        }

        sideToSideTilt = topOfJoyStick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Mathf.Abs(sideToSideTilt - 360);
            PLayer.GetComponent<Player>().GoRight();
        }
        else if (sideToSideTilt > 40 && sideToSideTilt < 74)
        {
            PLayer.GetComponent<Player>().GoLeft();
        }
    }
   /* public void DrillControl()
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
    }*/

  /*  public void GrabberHand()
    {
        forwardBackwardTilt = topOfJoyStick.rotation.eulerAngles.x;
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);
            GrabHand.transform.localPosition = new Vector3(0.1f, 0, 0);
            if (GrabHand.transform.localPosition.x >= 10)
            {
                GrabHand.transform.localPosition = new Vector3(10, 0, 0);
            }
        }
        else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
        {
            Drill.transform.localPosition = new Vector3(0.1f, 0, 0);
            if (GrabHand.transform.localPosition.x <= -10)
            {
                GrabHand.transform.localPosition = new Vector3(-10, 0, 0);
            }
        }

        sideToSideTilt = topOfJoyStick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Mathf.Abs(sideToSideTilt - 360);
            GrabHand.transform.localPosition = new Vector3(0, 0, -0.1f);
            if (GrabHand.transform.localPosition.z <= -10)
            {
                GrabHand.transform.localPosition = new Vector3(0, 0, -10);
            }
        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            Drill.transform.localPosition = new Vector3(0, 0, 0.1f);
            if (GrabHand.transform.localPosition.z >= 10)
            {
                GrabHand.transform.localPosition = new Vector3(0, 0, 10);
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

        /*RaycastHit hitInfo = Physics.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }

            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }
    }*/

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
    public void TurnOnOffRover()
    {
        if (!roverIsTurned)
        {
            PLayer.GetComponent<Player>().enabled = true;
            Monitors[0].SetActive(true);
            Monitors[1].SetActive(true);
            Monitors[2].SetActive(true);
            Monitors[3].SetActive(true);
            Monitors[4].SetActive(true);
            Monitors[5].SetActive(true);
            roverIsTurned = true;
        }
        else if (roverIsTurned)
        {
            PLayer.GetComponent<Player>().enabled = false;
            Monitors[0].SetActive(false);
            Monitors[1].SetActive(false);
            Monitors[2].SetActive(false);
            Monitors[3].SetActive(false);
            Monitors[4].SetActive(false);
            Monitors[5].SetActive(false);
            roverIsTurned = false;
        }
    }

    public void ChangeMasterInputRover()
    {
        MasterInput = 1;
    }

    public void ChangeMasterInputDrill()
    {
        if (!drillIsTurned)
        {
            MasterInput = 2;
            drillIsTurned = true;
        }
        else if (drillIsTurned)
        {
            MasterInput = 1;
            drillIsTurned = false;
        }
    }
    public void ChangeMasterInputGrab()
    {
        if (!grabIsTurned)
        {
            MasterInput = 3;
            grabIsTurned = true;
        }
        else if (grabIsTurned)
        {
            MasterInput = 1;
            grabIsTurned = false;
        }
    }
}