using System.Collections;
using UnityEngine;

public class DestrolOnAudioFinishPlaying : MonoBehaviour
{
    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(source.clip.length);
        Destroy(gameObject);
    }
}
