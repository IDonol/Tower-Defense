using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    [Space(5)]
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 50;
    private Transform _target;

    public void Find(Transform target)
    {
        _target = target;
    }

    private void Update()
    {


                


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(_damage);
            Instantiate(_effect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        
    }
}
