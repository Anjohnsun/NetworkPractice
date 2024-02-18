using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Connection : MonoBehaviour
{
    [SerializeField] private NetworkManager _manager;

    private void Start()
    {
        if (Application.isBatchMode)
            _manager.StartClient();
    }

    public void JoinClient()
    {
        _manager.networkAddress = "localhost";
        _manager.StartClient();
    }
}
