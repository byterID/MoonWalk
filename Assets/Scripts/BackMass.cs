using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMass : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(Vector3.down * speed *2, ForceMode.Impulse);
    }
}
