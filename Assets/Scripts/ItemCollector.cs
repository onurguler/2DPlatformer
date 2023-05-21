using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text _cherriesText;

    [SerializeField] private AudioSource _collectSoundEffect;

    private int _cherries = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            _collectSoundEffect.Play();
            _cherries++;
            _cherriesText.text = "Cherries: " + _cherries;
            Destroy(collision.gameObject);
        }
    }
}
