using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public static float musicVolume;

    [SerializeField]
    private GameObject volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<AudioSource>().volume = volumeSlider.GetComponent<Slider>().value;
    }

    public void setMusicVolume()
    {
        Camera.main.GetComponent<AudioSource>().volume = volumeSlider.GetComponent<Slider>().value;
    }
}
