using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<AudioSource>().mute = !GameOptions.musicActive;
    }

    public void UpdateMusicActive(bool index)
    {
        GetComponent<AudioSource>().mute = !index;
    }
}
