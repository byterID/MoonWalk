using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed;
    public GameObject PLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveBack()
    {
        PLayer.transform.localPosition -= PLayer.transform.right * speed;
    }
}
