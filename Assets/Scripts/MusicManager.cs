using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        BGM.mute = !GameOptions.musicActive;

        BGM.clip = Resources.Load<AudioClip>("Music/startedClip");
        BGM.Play();
    }

    public void UpdateMusicActive(bool index)
    {
        BGM.mute = !index;
    }

    public void ChangeBGM(AudioClip music)
    {
        StartCoroutine(Fade(music));
    }

    public void StopBGM()
    {
        BGM.Stop();
    }

    private IEnumerator Fade(AudioClip newClip)
    {
        float timeToFade = 1f;
        float timeElapsed = 0f;

        while (timeElapsed < timeToFade)
        {
            BGM.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        BGM.Stop();
        BGM.clip = newClip;
        BGM.Play();

        timeElapsed = 0f;

        while (timeElapsed < timeToFade)
        {
            BGM.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }
}
