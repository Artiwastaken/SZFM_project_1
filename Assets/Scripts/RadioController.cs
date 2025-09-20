using UnityEngine;

public class RadioController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
    int clipCounter = 0;
    [SerializeField] GameObject radioButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radioButtons.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.1f;
        audioSource.loop = true;
        audioSource.clip = clips[clipCounter];
        audioSource.Play();
    }
    public void IncreaseClipCounter()
    {
        if (clipCounter != clips.Length)
        {
            //clipCounter++;
            audioSource.clip = clips[clipCounter];
        }
        else
        {
            //clipCounter = 0;
            audioSource.clip = clips[clipCounter];
        }
        audioSource.Play();
    }
    public void DecreaseClipCounter()
    {
        if (clipCounter != 0)
        {
            //clipCounter--;
            audioSource.clip = clips[clipCounter];
        }
        else
        {
            //clipCounter = clips.Length;
            audioSource.clip = clips[clipCounter];
        }
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
