using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private Transform _obstacle;

    [SerializeField] private Vector2 _pos1;
    [SerializeField] private Vector2 _pos2;

    private void Start()
    {
        _obstacle.position = _pos1;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered");
        _obstacle.position = (_obstacle.position.x == _pos1.x) && (_obstacle.position.y == _pos1.y) ? _pos2 : _pos1;
    }
}
