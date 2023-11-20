using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VNCreator;

public class MusicManager : MonoBehaviour
{
    private void Start()
    {
        GetComponent<AudioSource>().mute = !GameOptions.musicActive;
    }
    public void UpdateMusicActive(bool index)
    {
        GetComponent<AudioSource>().mute = !index;
    }
}
