using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float SpeedRotation;
    public GameObject PLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveLeft()
    {
        PLayer.transform.Rotate(0, -SpeedRotation, 0);
    }
}
