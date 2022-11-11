using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Dvij : MonoBehaviour
{
    public GameObject[] Game;
    [SerializeField] float distance;
    [SerializeField] float speedMove;
    public GameObject Ball;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;

    Animator anim;

    public GameObject MiniGame;

    public GameObject sphr1;
    public GameObject sphr2;
    public GameObject sphr3;
    public GameObject sphr4;
    public GameObject sphr5;
    public GameObject sphr6;

    private Vector3 startPos;

    public GameObject ErrorCanvas;
    public GameObject WinCanvas;

    public GameObject Coins2;
    public GameObject Beacon;
    public GameObject Boxes;
    Rigidbody rigidBody;
    AudioSource audioSource;
    public GameObject ScreenRed;
    public GameObject ScreenGreen;
    public GameObject Quest2;
    public GameObject Quest3;

    public GameObject But1;
    public GameObject But2;
    public GameObject But3;

    public GameObject PLayer;

    public GameObject[] Zones;


    bool IsStop = true;

    //public GameObject GameCanvas;

    void Start()
    {
        
        StartCoroutine(c_Start());
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void Lose()
    {
        transform.position = startPos;
        MiniGame.SetActive(false);
        ErrorCanvas.SetActive(true);
    }
    IEnumerator ErrorCAnvas()
    {
        ErrorCanvas.SetActive(true);
        yield return new WaitForSeconds(2);
        ErrorCanvas.SetActive(false);
    }
    IEnumerator WinCAnvas()
    {
        WinCanvas.SetActive(true);
        yield return new WaitForSeconds(2);
        WinCanvas.SetActive(false);
        MiniGame.SetActive(false);
    }
    IEnumerator c_Start()
    {
        yield return new WaitForSeconds(1.0f);

        Vector3 startPosition = transform.position;
        Vector3 velocity = Vector3.forward * speedMove;

        while (IsStop == true)
        {
            if (transform.position.z > startPosition.z + distance)
                velocity.z = -speedMove;
            else if (transform.position.z < startPosition.z - distance)
                velocity.z = speedMove;

            transform.position += velocity * Time.deltaTime;

            yield return null;
        }
    }

    public void PressBut1()
    {
       // Game[0].transform.position = transform.position;
        IsStop = false;
        But1.SetActive(false);
        But2.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
        if (transform.localPosition.x < -1.5 && transform.localPosition.x > -3)

        {
            Game[1].SetActive(true);
            gameObject1.SetActive(false);
            gameObject2.SetActive(true);
            sphr1.SetActive(false);
            sphr2.SetActive(true);
        }
        else
        {
            Debug.Log("skfslkd");
            Invoke("Lose", 1);
        }
    }
    public void PressBut2()
    {
       // Game[1].transform.position = transform.position;
        But2.SetActive(false);
        But3.SetActive(true);
        IsStop = false;
        GetComponent<BoxCollider>().enabled = true;
        if (transform.localPosition.x < -1.5 && transform.localPosition.x > -3)
        {
            Game[2].SetActive(true);
            gameObject2.SetActive(false);
            gameObject3.SetActive(true);
            sphr3.SetActive(false);
            sphr4.SetActive(true);
        }
        else
        {
            Debug.Log("skfslkd");
            Invoke("Lose", 1);
        }
    }
    public void PressBut3()
    {
       // Game[2].transform.position = transform.position;
        IsStop = false;
        GetComponent<BoxCollider>().enabled = true;
        if (transform.localPosition.x < -1.5 && transform.localPosition.x > -3)
        {
            sphr5.SetActive(false);
            sphr6.SetActive(true);
            StartCoroutine(WinCAnvas());
            Beacon.SetActive(true);
            ScreenRed.SetActive(false);
            ScreenGreen.SetActive(true);
            Quest2.SetActive(false);
            Quest3.SetActive(true);
            Zones[0].SetActive(false);
            Zones[1].SetActive(false);
            Zones[2].SetActive(false);
            Zones[3].SetActive(false);
            Zones[4].SetActive(false);
            Zones[5].SetActive(false);
            anim.Play("TurningOn");
        }

        else
        {
            Debug.Log("skfslkd");
            Invoke("Lose", 1);
        }
    }
}