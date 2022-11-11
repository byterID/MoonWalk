using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyable : MonoBehaviour
{
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider mycollider)
    {
        if (mycollider.tag == "default")
        {
            
            loseScreen.SetActive(true);
            Invoke("Lose", 4f);
        }
    }

    public void Lose()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
