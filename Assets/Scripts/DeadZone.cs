using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public GameObject DeadZoneCanvas;
    //float timer = 0f;
    float timeToDie = 10;
    public Text SecToDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        string strr = timeToDie.ToString();
        SecToDead.text = strr;
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timeToDie -= Time.deltaTime;
            {
            if (timeToDie <= 0) { 
                DeadZoneCanvas.SetActive(true);
                Invoke("Lose", 4f);
                }
            }
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timeToDie = 10;
        }
    }

    public void Lose()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
