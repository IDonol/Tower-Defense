using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cit : MonoBehaviour
{
    [SerializeField] private GameObject _pan;
    [SerializeField] private GameObject _pan1;
    [SerializeField] private GameObject _up;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _player2;
    private bool _acti;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Destroy(_pan1);
            _pan.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            _player2.SetActive(false);
            _up.SetActive(_acti);
             _acti = !_acti;
             _player.SetActive(_acti);
        }
        if (_acti)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _up.SetActive(false);
            _player.SetActive(false);
            _player2.SetActive(true);
        }
    }
}
