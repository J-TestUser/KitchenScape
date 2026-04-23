using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource audioFont;
    public AudioClip gameBGM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioFont = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Start()
    {
        PlayBGM();
    }

    void PlayBGM()
    {
        audioFont.loop = true;
        audioFont.clip = gameBGM;
        audioFont.Play();
    }

    public void StopBGM()
    {
        audioFont.Stop();
    }
}
