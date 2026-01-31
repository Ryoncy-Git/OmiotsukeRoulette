using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sourceSE;
    [SerializeField] private AudioSource sourceBGM;
    [SerializeField] private AudioSource sourceSEResult;
    [SerializeField] private AudioClip[] se;
    [SerializeField] private AudioClip bgm;
    [SerializeField] private AudioClip seResult;
    

    public void PlaySE(int i)
    {
        sourceSE.PlayOneShot(se[i]);
    }

    public void PlayBGM()
    {
        sourceBGM.clip = bgm;
        sourceBGM.loop = true;
        sourceBGM.Play();
    }

    public void ChangeMasterVolume(float f)
    {
        sourceBGM.volume = f;
        sourceSE.volume = f;
        sourceSEResult.volume = f;
    }

    public void PlaySEResult()
    {
        sourceSEResult.PlayOneShot(seResult);
    }
}
