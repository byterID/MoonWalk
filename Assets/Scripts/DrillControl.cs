using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillControl : MonoBehaviour
{
    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject Ground3;
    public ParticleSystem DrillParticle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground1")
        {
            StartCoroutine(GroundDestroy1());
        }
        if (other.gameObject.tag == "Ground2")
        {
            StartCoroutine(GroundDestroy2());
        }
        if (other.gameObject.tag == "Ground3")
        {
            StartCoroutine(GroundDestroy3());
        }
    }

    IEnumerator GroundDestroy1()
    {
        yield return new WaitForSeconds(4);
        Ground1.SetActive(false);
        DrillParticle.Play(DrillParticle);
    }
    IEnumerator GroundDestroy2()
    {
        yield return new WaitForSeconds(4);
        Ground2.SetActive(false);
        DrillParticle.Play(DrillParticle);
    }
    IEnumerator GroundDestroy3()
    {
        yield return new WaitForSeconds(4);
        Ground3.SetActive(false);
        DrillParticle.Play(DrillParticle);
    }

}
