using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [SerializeField] private AudioSource heaven;
    [SerializeField] private AudioSource hell;
    [SerializeField] private AudioMixer mixer;
    private bool isHeaven = true;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip buttonClickFX;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayHeaven();
    }

    public void PlaySFX(AudioClip clip)
    {

        sfxSource.PlayOneShot(clip);
    }

    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClickFX);

    }

    public void CrossFade()
    {
        if (isHeaven) PlayHell();
        else PlayHeaven();
        
    }

    private void PlayHell()
    {
        mixer.SetFloat("Hell", 0);
        mixer.SetFloat("Heaven", -80);
        isHeaven = false;
    }

    private void PlayHeaven()
    {
        mixer.SetFloat("Hell",-80);
        mixer.SetFloat("Heaven", 0);
        isHeaven = true;
    }
}
