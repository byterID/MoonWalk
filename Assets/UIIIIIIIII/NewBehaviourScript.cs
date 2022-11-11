using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonHelp;

    //Планшет
    public GameObject VolumeMenu;
    public GameObject MainMenu;
    public GameObject SureExit;

    //Камеры
    public GameObject Cam1;
    public GameObject Cam2;

    bool PressedCam = false;
  

    public void ShowHelpButtons()
    {
        buttonsMenu.SetActive(false);
        buttonHelp.SetActive(true);
    }

    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonHelp.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("01");
    }

    public void ShowVolumeSettings()
    {
        VolumeMenu.SetActive(true);
        MainMenu.SetActive(false);
        SureExit.SetActive(false);
    }

    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        VolumeMenu.SetActive(false);
        SureExit.SetActive(false);
    }

    public void ShowSureExit()
    {
        SureExit.SetActive(true);
        VolumeMenu.SetActive(false);
        MainMenu.SetActive(false);
    }

    public void ChangeCam1()//Смена камер НАДО ПРОВЕРИТЬ!!!1!
    {
        if(PressedCam == false)
        {
            Cam2.SetActive(true);
            Cam1.SetActive(false);
            PressedCam = true;
        }
        else if (PressedCam == true)
        {
            Cam2.SetActive(false);
            Cam1.SetActive(true);
            PressedCam = false;
        }
    }
}
