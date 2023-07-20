using UnityEngine;
using DG.Tweening;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Coin : MonoBehaviour
{
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        float waitTime = 0.5f;
        var waitForSeconds = new WaitForSeconds(waitTime);

        _audioSource.Play();
        _spriteRenderer.color = Color.clear;

        yield return waitForSeconds;

        Destroy(gameObject);
    }
}
