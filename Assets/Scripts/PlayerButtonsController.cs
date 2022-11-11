using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonsController : MonoBehaviour
{
    public BoxCollider ButBoxColUp;
    public BoxCollider ButBoxColRight;
    public BoxCollider ButBoxColLeft;
    public BoxCollider ButBoxColDown;
    public GameObject ButBoxColUp1;
    public GameObject ButBoxColRight1;
    public GameObject ButBoxColLeft1;
    public GameObject ButBoxColDown1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "UpArrow":
                ButBoxColRight.enabled = true;
                ButBoxColLeft.enabled = true;
                ButBoxColDown.enabled = true;
                
                break;
            case "RightArrow":
                ButBoxColUp.enabled = true;
                ButBoxColDown.enabled = true;
                ButBoxColLeft.enabled = true;
                break;
            case "LeftArrow":
                ButBoxColUp.enabled = true;
                ButBoxColDown.enabled = true;
                ButBoxColRight.enabled = true;
                break;
            case "DownArrow":
                ButBoxColRight.enabled = true;
                ButBoxColLeft.enabled = true;
                ButBoxColUp.enabled = true;
                break;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "UpArrow":
                //colrightarrow.setactive(false);
                //colleftarrow.setactive(false);
                ButBoxColRight.enabled = false;
                ButBoxColLeft.enabled = false;
                ButBoxColDown.enabled = false;
                ButBoxColRight1.SetActive(false);
                ButBoxColLeft1.SetActive(false);
                break;
            case "RightArrow":
                //colUpArrow.SetActive(false);
                //colDownArrow.SetActive(false);
                ButBoxColUp.enabled = false;
                ButBoxColDown.enabled = false;
                ButBoxColLeft.enabled = false;
                break;
            case "LeftArrow":
                //colUpArrow.SetActive(false);
                //colDownArrow.SetActive(false);
                ButBoxColUp.enabled = false;
                ButBoxColDown.enabled = false;
                ButBoxColRight.enabled = false;
                break;
            case "DownArrow":
                //colRightArrow.SetActive(false);
                //colLeftArrow.SetActive(false);
                ButBoxColRight.enabled = false;
                ButBoxColLeft.enabled = false;
                ButBoxColUp.enabled = false;
                break;
        }

    }
}
