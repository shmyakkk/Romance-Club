using UnityEngine;

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
