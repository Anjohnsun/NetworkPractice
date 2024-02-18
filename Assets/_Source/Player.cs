using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private GameObject _chatContent;
    [SerializeField] private GameObject _superFrase;

    NetworkManager _networkManager;

    void Start()
    {
        _chatContent = GameObject.FindGameObjectWithTag("ChatContent");
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float speed = 6 * Time.deltaTime;
        transform.Translate(new Vector2(hor, ver) * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Message");
            Instantiate(_superFrase, _chatContent.transform);
        }
    }
}
