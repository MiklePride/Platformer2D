using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;

    private bool _isCoin;

    private void Start()
    {
        Instantiate(_coinTemplate, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
            _isCoin = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Coin>(out Coin coin))
        {
            _isCoin = false;

            StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        int waitTime = 10;
        var waitforSeconds = new WaitForSeconds(waitTime);

        if (!_isCoin)
        {
            yield return waitforSeconds;

            Instantiate(_coinTemplate, transform.position, Quaternion.identity);

            _isCoin = true;
        }
    }
}
