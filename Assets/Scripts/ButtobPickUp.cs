using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtobPickUp : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    public float speed;
    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    Rigidbody rb;
    public float SpeedRotation;
    public GameObject PLayer;
    public GameObject ButBoxColUp;
    public GameObject ButBoxColRight;
    public GameObject ButBoxColLeft;
    public GameObject ButBoxColDown;
    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        rb = GetComponent<Rigidbody>();
        gameObject.tag = "Button";

    }

    // Update is called once per frame
    void Update()
    {
        while (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        while (_isPressed && GetValue() - threshold <= 0)
            Released();
    }
    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }

    public void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }
    public void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerH")
        {
            Pressed();
        }
    }
}
