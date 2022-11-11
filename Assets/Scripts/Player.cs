using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Ввод переменных энергии, хп и скорости
    float maxEnergy = 100;
    float recountEnergy = 0.01f;
    float curSpeed =0;
    float maxSpeed = 15;
    public float SpeedRotation;
    float cooldown = 5;
    int curHp;
    int maxHp = 6;
    float speeeeed;
    //Вспомогательный ввод
    Rigidbody rb;
    Animator anim;
    AudioSource audioSource;
    //Переменная монеток
    int coins = 0;
    //Звуки, частицы
    [SerializeField] AudioClip flySound;
    [SerializeField] AudioClip boomSound;
    [SerializeField] AudioClip finishSound;
    [SerializeField] ParticleSystem flyPartiles;
    [SerializeField] ParticleSystem boomPartiles;
    public ParticleSystem finishPartiles;
    //Ввод объектов
    public GameObject Game;
    public GameObject Buttons;
    public GameObject Coins3;
    public GameObject FinishBox;
    public GameObject Rocks;
    public GameObject PickedRocks;
    public GameObject FinishCanvas;
    public GameObject PLayer;
    public GameObject Quest1;
    public GameObject Quest2;
    public GameObject Quest3;
    public GameObject Quest4;
    //Переменные мониторов
    public Text hpMonitor;
    public Text energyMonitor;
    public Text speedMonitor;
    public Text CurSignal1;


    //Переменные экранов пройгрыша
    public GameObject loseScreenH;
    public GameObject loseScreenE;
    public GameObject DeadZoneCanvas;
    int CurSignal;

    public GameObject Wheel;


    //Камера
    public GameObject Cam;

    public GameObject SignalCam;
    public GameObject StSignalCam;

    //Pkjt,exbq поворот
    bool IsTurning = true;
    bool IsMoving = true;


    //Подбор образцов
    bool IsPickUp = false;

    public GameObject[] Exp1;
    public GameObject[] Exp2;

    //Мини-игра
    public GameObject Minigame;

    //ЛОГИ
    int TriesCount = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();   
        curHp = maxHp;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        string strr = CurSignal.ToString();
        CurSignal1.text = strr;

        string str = curHp.ToString();
        hpMonitor.text = str;

        RecountEnergy();
        
        string str1 = maxEnergy.ToString();
        energyMonitor.text = str1;



        string speedd = curSpeed.ToString();
        speedMonitor.text = speedd;

        ButtonReleased();
        //Vector2 input = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

    }

    /// <Система здоровья>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <Система здоровья>
    public void RecountHp(int deltaHp)
    {
        curHp = curHp + deltaHp;
        if (deltaHp < 0)
        {
            curHp = curHp + deltaHp;
        }
        else if (curHp > maxHp)
        {
            curHp = curHp + deltaHp;
            curHp = maxHp;
        }
        else if (curHp <=0)
        {
            curHp = 0;
        }
        if (curHp <= 0)
        {
            loseScreenH.SetActive(true);
            Invoke("Lose", 4f);
        }
    }
    /// <Расчет энергии>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <Расчет энергии>
    public void RecountEnergy()
    {
        if (maxEnergy > 0)
        {
            maxEnergy -= recountEnergy / 6;
        }
        if (maxEnergy <= 0)
        {
            loseScreenE.SetActive(true);
            Invoke("Lose", 4f);
        }
    }
    /// <Монетки>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <Монетки>
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")//Игрок подбирает объект с тегом Coin
        {
            Destroy(collision.gameObject);//этот объект уничтожается если игрок входит в коллайдер
            coins++;//на счет игрока начисляется монетка

        }
        switch (collision.gameObject.tag)
        {
            case "Station1":
                Activate1();
                Game.SetActive(true);
                break;
        } 
    }
    /// <Пройгрыш>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <Пройгрыш>
    public void Lose()
    {
        SceneManager.LoadScene("SampleScene");
        boomPartiles.Play();
    }
    /// <Управление стадиями игры>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <Управление стадиями игры>

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Rock")
        {
            RecountHp(-1);
            boomPartiles.Play();
            PLayer.GetComponent<Rigidbody>().AddForce(transform.up * 3f, ForceMode.Impulse);
            StartCoroutine(Damage());
        }
        if (collision.gameObject.tag == "Station3")
        {
            Activate3();
        }
    }

    IEnumerator Damage()
    {
        yield return new WaitForSeconds(2);
    }

    void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.tag == "Signal1")
        {
            SignalCam.GetComponent<GlitchEffect>().intensity = 0;
            SignalCam.GetComponent<GlitchEffect>().flipIntensity = 0;
            SignalCam.GetComponent<GlitchEffect>().colorIntensity = 0;
            StSignalCam.GetComponent<GlitchEffect>().intensity = 0;
            StSignalCam.GetComponent<GlitchEffect>().flipIntensity = 0;
            StSignalCam.GetComponent<GlitchEffect>().colorIntensity = 0;
            CurSignal = -50;
        }
        if (collision.gameObject.tag == "Signal2")
        {
            SignalCam.GetComponent<GlitchEffect>().intensity = 0.14f;
            SignalCam.GetComponent<GlitchEffect>().flipIntensity = 0.14f;
            SignalCam.GetComponent<GlitchEffect>().colorIntensity = 0.14f;
            StSignalCam.GetComponent<GlitchEffect>().intensity = 0.14f;
            StSignalCam.GetComponent<GlitchEffect>().flipIntensity = 0.14f;
            StSignalCam.GetComponent<GlitchEffect>().colorIntensity = 0.14f;
            CurSignal = -65;
        }
        if (collision.gameObject.tag == "Signal3")
        {
            SignalCam.GetComponent<GlitchEffect>().intensity = 0.22f;
            SignalCam.GetComponent<GlitchEffect>().flipIntensity = 0.22f;
            SignalCam.GetComponent<GlitchEffect>().colorIntensity = 0.22f;
            StSignalCam.GetComponent<GlitchEffect>().intensity = 0.22f;
            StSignalCam.GetComponent<GlitchEffect>().flipIntensity = 0.22f;
            StSignalCam.GetComponent<GlitchEffect>().colorIntensity = 0.22f;
            CurSignal = -75;
        }
        if (collision.gameObject.tag == "Signal4")
        {
            SignalCam.GetComponent<GlitchEffect>().intensity = 0.4f;
            SignalCam.GetComponent<GlitchEffect>().flipIntensity = 0.4f;
            SignalCam.GetComponent<GlitchEffect>().colorIntensity = 0.4f;
            StSignalCam.GetComponent<GlitchEffect>().intensity = 0.4f;
            StSignalCam.GetComponent<GlitchEffect>().flipIntensity = 0.4f;
            StSignalCam.GetComponent<GlitchEffect>().colorIntensity = 0.4f;
            CurSignal = -85;
        }
        if (collision.gameObject.tag == "Signal5")
        {
            SignalCam.GetComponent<GlitchEffect>().intensity = 1;
            SignalCam.GetComponent<GlitchEffect>().flipIntensity = 1;
            SignalCam.GetComponent<GlitchEffect>().colorIntensity = 1;
            StSignalCam.GetComponent<GlitchEffect>().intensity = 1;
            StSignalCam.GetComponent<GlitchEffect>().flipIntensity = 1;
            StSignalCam.GetComponent<GlitchEffect>().colorIntensity = 1;
            DeadZoneCanvas.SetActive(true);
            Invoke("Lose", 4f);
            CurSignal = -100;
        }
    }

    IEnumerator Cooldown5()
    {
        yield return new WaitForSeconds(cooldown);  
    }
    /// <Планшет и стадии>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <Планшет и стадии>

    void Activate1()
    {
        Game.SetActive(true);
        Quest1.SetActive(false);
        Quest2.SetActive(true);
    }
    void Activate2()
    {
        FinishBox.SetActive(true);
        Rocks.SetActive(false);
        PickedRocks.SetActive(true);
        Quest1.SetActive(false);
        Quest2.SetActive(false);
        Quest3.SetActive(false);
        Quest4.SetActive(true);
    }
    void Activate3()
    {
        FinishCanvas.SetActive(true);
        audioSource.PlayOneShot(finishSound);
        finishPartiles.Play();
    }
    /// <Управление>
    /// ////////////////////////////////////////////////////////////////////////////////////////
    /// <Управление>
    public void GoForward()
    {
        //Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        IsTurning = false;
        if (Wheel.transform.localRotation.y > 0 && IsMoving == true/* && primaryAxis.y > 0.0f*/)
        {
            anim.Play("Moving");
            StartCoroutine(WaitForMovingForward());
            IsTurning = true;
        }
        else
        {
            NoWaitForMovingForward();
            anim.Play("Idlee");
            IsTurning = true;
        }
    }
    public void GoRight()
    {
        //Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        IsMoving = false;
        if (Wheel.transform.localRotation.y < 1 && IsTurning == true/* && primaryAxis.x > 0.0f*/)
        {
            anim.Play("Turning");
            StartCoroutine(WaitForTurningRight());
            IsMoving = true;
            curSpeed = 0;
        }
        else
        {
            NoWaitForMovingRight();
            IsMoving = true;
        }
    }
    public void GoLeft()
    {
       // Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        IsMoving = false;
        if (Wheel.transform.localRotation.y < 1 && IsTurning == true/* && primaryAxis.x < 0.0f*/)
        {
            anim.Play("Turning");
            StartCoroutine(WaitForTurningLeft());
            IsMoving = true;
            curSpeed = 0;
        }
        else
        {
            NoWaitForMovingLeft();
            IsMoving = true;
        }
    }
    public void GoBack()
    {
        //Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        IsTurning = false;
        if (Wheel.transform.localRotation.y > 0 && IsMoving == true/* && primaryAxis.y < 0.0f*/)
        {
            anim.Play("Moving");
            StartCoroutine(WaitForMovingBack());
            IsTurning = true;
        }
        else
        {
            NoWaitForMovingBack();
            anim.Play("Idlee");
            IsTurning = true;
        }
    }
    public void ButtonReleased()
    {
        if (curSpeed > 0)
            curSpeed -= 0.1f;

        if (curSpeed < 0)
            curSpeed += 0.1f;
    }
    IEnumerator WaitForTurningRight()
    {
        yield return new WaitForSeconds(1);
        PLayer.transform.Rotate(0, SpeedRotation, 0);
    }
    IEnumerator WaitForTurningLeft()
    {
        yield return new WaitForSeconds(1);
        PLayer.transform.Rotate(0, -SpeedRotation, 0);
    }
    IEnumerator WaitForMovingForward()
    {
        yield return new WaitForSeconds(1);
        if (curSpeed <= 15 /*&& OVRInput.GetDown(OVRInput.Button.One)*/)
        {
            audioSource.Play();
            curSpeed += 0.5f;
            rb.AddRelativeForce(Vector3.forward * curSpeed * 2100, ForceMode.Impulse);
            PLayer.transform.Rotate(0.2f, 0, 0);
            audioSource.Stop();
        }
        if (curSpeed > maxSpeed)
        {
            curSpeed = maxSpeed;
        }
        if (curSpeed < 0)
            curSpeed = 0;
    }
    IEnumerator WaitForMovingBack()
    {
        yield return new WaitForSeconds(1);
        curSpeed -= 0.5f;
        rb.AddRelativeForce(Vector3.forward * curSpeed * 2100, ForceMode.Impulse);
        PLayer.transform.Rotate(-0.2f, 0, 0);
        if (curSpeed <= -15)
        {
            curSpeed = -15;
        }
    }

    public void NoWaitForMovingBack()
    {
        curSpeed -= 0.5f;
        rb.AddRelativeForce(Vector3.forward * curSpeed * 2100, ForceMode.Impulse);
        PLayer.transform.Rotate(-0.2f, 0, 0);
        if (curSpeed <= -15)
        {
            curSpeed = -15;
        }
    }

    public void NoWaitForMovingRight()
    {
        PLayer.transform.Rotate(0, SpeedRotation, 0);
    }

    public void NoWaitForMovingLeft()
    {
        PLayer.transform.Rotate(0, -SpeedRotation, 0);
    }

    public void NoWaitForMovingForward()
    {
        if(curSpeed <= 15)
        {
            audioSource.Play();
            curSpeed += 0.5f;
            rb.AddRelativeForce(Vector3.forward * curSpeed * 2100, ForceMode.Impulse);
            PLayer.transform.Rotate(0.2f, 0, 0);
            audioSource.Stop();
        }
        if (curSpeed > maxSpeed)
        {
            curSpeed = maxSpeed;
        }
        if (curSpeed < 0)
            curSpeed = 0;
    }

    public void CamMoveRight()
    {
        Cam.transform.Rotate(0, 1, 0);
    }
    public void CamMoveLeft()
    {
        Cam.transform.Rotate(0, -1, 0);
    }


    public void PickUp()
    {
        StartCoroutine(BackToFalse());
    }

    IEnumerator BackToFalse()
    {
        IsPickUp = true;
        yield return new WaitForSeconds(3);
        IsPickUp = false;
    }


    public void GreenBoxGrab()
    {
        anim.Play("GrabberGreen");
    }
    public void YellowBoxGrab()
    {
        anim.Play("GrabberYellow");
    }
    public void RedBoxGrab()
    {
        anim.Play("Grabber");
    }
    public void Drilll()
    {
        anim.Play("DrillMovingLeft");
    }
}