using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distr : MonoBehaviour
{
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 2)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
