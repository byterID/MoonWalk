using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] sound;
    public AudioSource a;
    // Start is called before the first frame update
    public void FirstSound()
    {
        a.clip = sound[0];
        a.Play();

    }
    public void SecondSound()
    {
        a.clip = sound[1];
        a.Play();

    }
    public void ThirdSound()
    {
        a.clip = sound[2];
        a.Play();

    }
    public void FourthSound()
    {
        a.clip = sound[3];
        a.Play();

    }
    public void FithSound()
    {
        a.clip = sound[4];
        a.Play();

    }
    public void SixthSound()
    {
        a.clip = sound[5];
        a.Play();

    }
    public void SeventhSound()
    {
        a.clip = sound[6];
        a.Play();

    }
    public void EightSound()
    {
        a.clip = sound[7];
        a.Play();

    }
    public void NinthSound()
    {
        a.clip = sound[8];
        a.Play();

    }
    public void TenthSound()
    {
        a.clip = sound[9];
        a.Play();

    }

}
