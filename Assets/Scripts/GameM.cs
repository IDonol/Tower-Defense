using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class GameM : MonoBehaviour
{
    public static GameM instance;

    [SerializeField] private Text _healthText;
    [SerializeField] private int _health = 100;
    [Space(5)]
    [SerializeField] private Text _goldText;
    [Space(5)]
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Enemy _enemy2;
    [SerializeField] private Enemy _boss;
    [SerializeField] private GameObject[] _startCube;
    [SerializeField] private Text _waveText;
    [SerializeField] private Text _waveTimeText;
    [Space(5)]
    [SerializeField] private int _wavesCount = 5;
    [SerializeField] private float _nextWaveTime = 10;
    [SerializeField] private float _spawnInterval = 0.5f;
    [SerializeField] private float _startTime = 5;
    [Space(5)]
    [SerializeField] private GameObject pan;
    [SerializeField] private GameObject pan1;
    public int _gold = 50;
    public int _turretCost = 50;
    public GameObject PausMenu;
    public GameObject Defeat;

    private int _waveIndex;
    [SerializeField] private int _complexity;
    private bool _endGame;
    private bool _flag;
    bool isOpened;
    // ссылка на панель
    public GameObject panel;

  
    private void Start()
    {
        instance = this;

        _healthText.text = "ХП: " + _health;
        _waveText.gameObject.SetActive(false);

        UpdateGold();
        _complexity = Menu._hr;
    }

    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // меняем состояние
            isOpened = !isOpened;
            // присваиваем
            panel.SetActive(isOpened);
            Menu.buildIndex = 1;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(pan1);
            _flag = !_flag;
            pan.SetActive(_flag);
        }
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        if(_waveIndex >= _wavesCount && enemies.Length == 0 && !_endGame)
        {
            _endGame = true;
            Debug.Log("Victory!");
            
            PausMenu.gameObject.SetActive(true);
        }

        if(_waveIndex >= _wavesCount)
        {
            _waveTimeText.gameObject.SetActive(false);
            return;
        }

        if(_startTime <= 0)
        {
            StartCoroutine(Spawn());
            _startTime = _nextWaveTime;
        }

        _startTime -= Time.deltaTime;
        _startTime = Mathf.Clamp(_startTime, 0, Mathf.Infinity);
        _waveTimeText.text = string.Format("{0:00.00}", _startTime);
        if(_waveIndex > 0)
        {
            _waveText.gameObject.SetActive(true);
            _waveText.text = _waveIndex + "/" + _wavesCount + " Волна";
        }
    }

    public void UpdateGold()
    {
        _goldText.text = _gold + "G";
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            _endGame = true;
            Debug.Log("Defeat!");
            
            Defeat.gameObject.SetActive(true);
        }

        _healthText.text = "ХП: " + _health;
    }

    IEnumerator Spawn()
    {
        _waveIndex++;

        for(int i = 0; i < _waveIndex; i++)
        {
            if(i < _complexity)
            {
                for (int j = 0; j < _startCube.Length; j++)
                {
                    Instantiate(_enemy, _startCube[j].transform.position, _enemy.transform.rotation);
                   yield return new WaitForSeconds(_spawnInterval);
                }
            }
            else
            {
                for (int j = 0; j < _startCube.Length; j++)
                {
                    Instantiate(_enemy2, _startCube[j].transform.position, _enemy2.transform.rotation);
                    yield return new WaitForSeconds(_spawnInterval);
                }
            }
            if(i == _complexity)
            {
                Instantiate(_boss, _startCube[0].transform.position, _boss.transform.rotation);
                yield return new WaitForSeconds(_spawnInterval);
            }
        }
    }
}