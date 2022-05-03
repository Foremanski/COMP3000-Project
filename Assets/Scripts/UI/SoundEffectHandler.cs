using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectHandler : MonoBehaviour
{
    [SerializeField]
    private AudioSource AudioButtonClick, AudioPowerStationActivate, AudioPlacement, AudioDestroy, AudioExtendLine, AudioMetreAlert, AudioMetreClear;

    public void PlayButtonClick()
    {
        AudioButtonClick.Play();
    }
    public void PlayPowerStationActivate()
    {
        AudioPowerStationActivate.Play();
    }
    public void PlayPlacementSound()
    {
        AudioPlacement.Play();
    }
    public void PlayDestroy()
    {
        AudioDestroy.Play();
    }
    public void PlayExtendLine()
    {
        AudioExtendLine.Play();
    }

    public void PlayMetreAlert()
    {
        AudioMetreAlert.Play();
    }
    public void PlayMetreClear()
    {
        AudioMetreClear.Play();
    }
}
