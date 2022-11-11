using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPhoto : MonoBehaviour
{
    public RawImage rw; //Префаб RawImage (картинка фото)
    private GameObject Photo; //Объект фото (с помощью него будем удалять фото)
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScreenS());//Запускаем корутину с методом скриншота
        Photo = rw.gameObject; //указываем, что Photo это префаб RawImage
    }
    
    public void DeletePhoto(){
        Destroy(Photo);//удаляем фото
    }

    IEnumerator ScreenS(){
        yield return new WaitForEndOfFrame(); //ждем конец кадра
        var Screen = ScreenCapture.CaptureScreenshotAsTexture(); //создаем скрин экрана
        rw.texture=Screen; //присваеваем наш скрин, как текстуру RawImage 
    }
}
