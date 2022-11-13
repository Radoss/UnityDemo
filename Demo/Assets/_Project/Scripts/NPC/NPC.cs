using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] AudioClip _qreetingClip;
    [SerializeField] AudioClip _question1Clip;
    [SerializeField] AudioClip _question2Clip;
    [SerializeField] AudioClip _waitClip;
    [SerializeField] AudioClip _welcomeClip;
    public AudioSource audioSource { get; private set; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGreeting()
    {
        audioSource.clip = _qreetingClip;
        audioSource.Play();
    }

    public void PlayQuestion1()
    {
        audioSource.clip = _question1Clip;
        audioSource.Play();
    }

    public void PlayQuestion2()
    {
        audioSource.clip = _question2Clip;
        audioSource.Play();
    }

    public void PlayWait()
    {
        audioSource.clip = _waitClip;
        audioSource.Play();
    }

    public void PlayWelcome()
    {
        audioSource.clip = _welcomeClip;
        audioSource.Play();
    }
}
