using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour {


	[SerializeField] Text energyText;
	[SerializeField] int energyTotal = 2000;
	[SerializeField] int energyApply = 5;
	[SerializeField] float rotSpeed = 40f;
	[SerializeField] float flySpeed = 10f;
	[SerializeField] AudioClip flySound;
	[SerializeField] AudioClip boomSound;
	[SerializeField] AudioClip finishSound;
	[SerializeField] ParticleSystem flyPartiles;
	[SerializeField] ParticleSystem boomPartiles;
	[SerializeField] ParticleSystem finishPartiles;
	public GameObject Coins2;
	public GameObject Beacon;
	public GameObject Boxes;
	Rigidbody rigidBody;
	AudioSource audioSource;
    private Vector3 startPos;
    public GameObject ScreenRed;
	public GameObject ScreenGreen;
    public GameObject Quest2;
    public GameObject Quest3;


    // Use this for initialization
    void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Quaternion currRotation = transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {
		Launch();
		Rotation();
		
	}

	void OnCollisionEnter(Collision collision)
	{

		switch(collision.gameObject.tag)
		{
			case "Friendly":
				print("OK");
				break;
			case "Finish":
				Finish();
				finishPartiles.Play();
                break;
            case "Fail":
                Fail();
                boomPartiles.Play();
				break;
            case "UpArrow":
                GoUp();
                audioSource.PlayOneShot(flySound);
                break;
            case "RightArrow":
                GoRight();
                break;
            case "LeftArrow":
                GoLeft();
                break;

        }
	}


    public void Fail()
    {
        transform.position = startPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void GoUp()
    {
        rigidBody.AddRelativeForce(Vector3.up * flySpeed);
        flyPartiles.Play(flyPartiles);
    }
    public void GoRight()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;
        rigidBody.freezeRotation = true;
        transform.Rotate(-Vector3.forward * rotationSpeed);
        rigidBody.freezeRotation = false;
    }
    public void GoLeft()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;
        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSpeed);
        rigidBody.freezeRotation = false;
    }


	void Finish()
	{
		finishPartiles.Play();
		audioSource.Stop();
		audioSource.PlayOneShot(finishSound);
		
		Coins2.SetActive(true);
		Beacon.SetActive(true);
		Boxes.SetActive(true);
		ScreenRed.SetActive(false);
		ScreenGreen.SetActive(true);
        Quest2.SetActive(false);
        Quest3.SetActive(true);
	}

	void Launch()
	{
		if(Input.GetKey(KeyCode.Space) && energyTotal > 0)
		{
			energyTotal -= Mathf.RoundToInt(energyApply*Time.deltaTime);

			energyText.text = energyTotal.ToString();
			rigidBody.AddRelativeForce(Vector3.up * flySpeed * Time.deltaTime);
			if(audioSource.isPlaying == false)
			audioSource.PlayOneShot(flySound);
			flyPartiles.Play();
		}
		else
		{
			audioSource.Pause();
			flyPartiles.Stop();
		}
		
	}
	void Rotation()
	{

		float rotationSpeed = rotSpeed * Time.deltaTime;

		rigidBody.freezeRotation = true;
		if(Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.forward * rotationSpeed);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			transform.Rotate(-Vector3.forward * rotationSpeed);
		}
		rigidBody.freezeRotation = false;
	}
}
