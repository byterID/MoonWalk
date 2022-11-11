using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGall : MonoBehaviour
{
    public GameObject PanelPhoto; //Панель фото-галереи
    private bool openGallery = false; //условие на открытие галереи
    public RectTransform ContentForms; //Трансформ контентной формы галереи
    // Start is called before the first frame update
    void Start()
    {
        PanelPhoto.SetActive(false);//отключаем панель галереи
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)&&openGallery==false){ //если нажали кнопку P и галерея закрыта
            PanelPhoto.SetActive(true); //включаем панель галереи
            openGallery=true; //указываем, что галерея открыта
            FindPhoto(); //запускаем метод поиска фото
           

        }
        else if(Input.GetKeyDown(KeyCode.P)&&openGallery==true){//если нажали кнопку P и галерея открыта
            PanelPhoto.SetActive(false);//отключаем панель галереи
            openGallery=false;//указываем, что галерея закрыта
        }
    }

   public void FindPhoto(){
    
    GameObject[] Photos; //создаем масив 
    Photos = GameObject.FindGameObjectsWithTag("Photo"); //ищем все объекты с тегом Photo
    foreach(GameObject photo in Photos){ 
        photo.transform.SetParent(ContentForms.transform, false);//устанавливаем (переносим), объект фото дочерним к контентой форме галереи
    }
    
    
   }
}
