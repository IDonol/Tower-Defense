using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigan : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    public float _vtlbt = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject necstbt = Instantiate(_bullet, transform.position, transform.rotation);
            necstbt.GetComponent<Rigidbody>().velocity = transform.forward * _vtlbt;
        } 
    }
}
