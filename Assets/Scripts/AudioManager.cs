using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource EffectAudioSource;
    [SerializeField] private AudioSource defaultAudioSource;
    [SerializeField] private AudioSource bossAudioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip energyClip;

    public void playShootSound()
    {
        EffectAudioSource.PlayOneShot(shootClip);
    }

    public void playReloadSound()
    {
        EffectAudioSource.PlayOneShot(reloadClip);
    }

    public void playEnergySound()
    {
        EffectAudioSource.PlayOneShot(energyClip);
    }

    public void playDefaultAudio()
    {
        bossAudioSource.Stop();
        defaultAudioSource.Play();
    }

    public void playBossSound()
    {
        defaultAudioSource.Stop();
        bossAudioSource.Play();
    }

    public void stopAudioGame()
    {
        EffectAudioSource.Stop();
        defaultAudioSource.Stop();
        bossAudioSource.Stop();
    }
}
