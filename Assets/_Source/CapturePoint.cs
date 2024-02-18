using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapturePoint : MonoBehaviour
{
    [SerializeField] private Image _image;
    private List<int> _playersInside;
    private int _capturingPlayer;

    [SerializeField] private float _captureSpeed;

    private void Start()
    {
        _playersInside = new List<int>();
        _image.fillAmount = 0;
    }

    void Update()
    {
        if (_playersInside.Count == 1 && _capturingPlayer == _playersInside[0])
            _image.fillAmount += Time.deltaTime * _captureSpeed;
        else if (!_playersInside.Contains(_capturingPlayer))
        {
            _image.fillAmount -= Time.deltaTime * _captureSpeed;
            if (_image.fillAmount <= 0)
                if (_playersInside.Count == 1)
                    _capturingPlayer = _playersInside[0];
                else
                    _capturingPlayer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_capturingPlayer == 0)
        {
            _capturingPlayer = collision.transform.GetHashCode();
        }
        _playersInside.Add(transform.GetHashCode());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playersInside.Remove(transform.GetHashCode());
        if (_image.fillAmount <= 0)
            if (_playersInside.Count == 1)
                _capturingPlayer = _playersInside[0];
    }
}
