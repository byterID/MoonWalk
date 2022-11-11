using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLider : MonoBehaviour
{
    [SerializeField] private Slider volume;
    // Start is called before the first frame update
    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
    }
}
