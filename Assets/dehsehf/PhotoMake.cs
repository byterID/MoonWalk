using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoMake : MonoBehaviour
{
    public RawImage rwPrefab; //Префаб фото
    public AudioSource auds; //Компонент звука
   
   // public RectTransform ContentForm;
    void Update()
    {
       if (Input.GetMouseButtonDown(0)){ //если нажали левую кнопку иыши
            MakePhoto(); //Делаем снимок
        }
      
    }

    public void MakePhoto(){
       Instantiate(rwPrefab);//создаем объект фото
        auds.Play();//проигрываем звук 
        
       
    }

}
