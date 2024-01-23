using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource BGM;

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
        if (!BGM.mute) StartCoroutine(Fade(music));
    }

    public void StopBGM()
    {
        BGM.Stop();
    }

    private IEnumerator Fade(AudioClip newClip)
    {
        float duration = 1f;
        float targetVolume = 0f;

        float currentTime = 0;
        float start = BGM.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            BGM.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        BGM.Stop();
        BGM.clip = newClip;
        BGM.Play();

        targetVolume = 1f;

        currentTime = 0;
        start = BGM.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            BGM.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        yield break;
    }
}
