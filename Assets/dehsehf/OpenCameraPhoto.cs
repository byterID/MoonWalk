using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCameraPhoto : MonoBehaviour
{
    public GameObject PanelPhotoCamera; //панель фото-камеры
    private bool openCam=false; //условие на открытие фото-камеры
    public Camera mainCam; //камера игрока
    public int standartField=60; //стандартное положение зума
    public int maxField=80; //Максимальное значение (чем больше от стандартного, тем меньше зум)
    public int minField=40; // минимальное значение (чем меньше от стандартного, тем больше зум)
    public int speedZoom = 5; //скорость изменения дальности
    
   
    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.T)&&openCam==false){ //если нажали кнопку T и камера не открыта
            PanelPhotoCamera.SetActive(true);//включаем камеру
            openCam=true; //устанавливаем, что камера включена
           

        }
        else if(Input.GetKeyDown(KeyCode.T)&&openCam==true){ //если нажали кнопку T и камера открыта
            PanelPhotoCamera.SetActive(false); //отключаем камеру
            openCam=false; // устанавливаем, что камера выключена
            mainCam.fieldOfView=standartField; //возвращаем зум к стандартному значению
        }
        if(openCam==true){ //если камера открыта включаем зум
            Zoom();
            
        }
        
    }



    public void Zoom(){
        if(Input.GetAxis("Mouse ScrollWheel") < 0f ) { // Двигаем колесико мышки вниз 
        
         mainCam.fieldOfView+=speedZoom; //увеличиваем значение Field, тем самым уменьшая зум
        
         if( mainCam.fieldOfView>maxField){//Если Field больше максимального значения
            mainCam.fieldOfView=maxField;//значение Field фиксируем на максимальное значение
        }
        
        } 
       
       
        else if(Input.GetAxis("Mouse ScrollWheel") > 0f ) { //Двигаем колесико мышки вверх
       
            mainCam.fieldOfView-=speedZoom;//уменьшаем значение Field, тем самым увеличивая зум
        
       
            if(mainCam.fieldOfView<minField){ //Если Field меньше минимального значения
            mainCam.fieldOfView=minField; //значение Field фиксируем на минимальном значении
        }   

        
        }
     }
}
