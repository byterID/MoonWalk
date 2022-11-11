using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comods : MonoBehaviour
{
    public bool isOpenedGreen;
    public bool isOpenedYellow;
    public bool isOpenedRed;

    public GameObject GreenBox;
    public GameObject YellowBox;
    public GameObject RedBox;

    public void Start()
    {
        isOpenedRed = false;
        isOpenedYellow = false;
        isOpenedGreen = false;
    }
    public void GreenBoxOpen()
    {
        if(!isOpenedGreen)
        {
            GreenBox.transform.localPosition = new Vector3(0, 0, -0.3f);
            isOpenedGreen = true;
        }
        else if (isOpenedGreen)
        {
            GreenBox.transform.localPosition = new Vector3(0, 0, 0);
            isOpenedGreen = false;
        }
    }
    public void YellowBoxOpen()
    {
        if (!isOpenedYellow)
        {
            YellowBox.transform.localPosition = new Vector3(0, 0, -0.4f);
            isOpenedYellow = true;
        }
        else if (isOpenedYellow)
        {
            YellowBox.transform.localPosition = new Vector3(0, 0, 0);
            isOpenedYellow = false;
        }
    }
    public void RedBoxOpen()
    {
        if (!isOpenedRed)
        {
            RedBox.transform.localPosition = new Vector3(0, 0, -0.6f);
            isOpenedRed = true;
        }
        else if (isOpenedRed)
        {
            RedBox.transform.localPosition = new Vector3(0, 0, 0);
            isOpenedRed = false;
        }
    }
}
