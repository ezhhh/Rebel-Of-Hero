using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioSource music;
    public Slider mSound;
    private float mSoundVal;

    void Awake()
    {
      if(PlayerPrefs.HasKey("mSoundVal"))
        mSound.GetComponent<Slider>().value = PlayerPrefs.GetFloat("mSoundVal");
      else mSound.GetComponent<Slider>().value = 1;
    }

    void Update()
    {
      mSoundVal = mSound.GetComponent<Slider>().value;
      music.GetComponent<AudioSource>().volume = mSoundVal;
      PlayerPrefs.SetFloat("mSoundVal",mSoundVal);

    }

}
