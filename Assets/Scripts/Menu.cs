using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public static int _hr = 10;
    public static int buildIndex = 1;
	public void PlayGame()
	{
        buildIndex++;
		SceneManager.LoadScene(buildIndex);
		Time.timeScale = 1f;
    }
    public void Pesoc()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    /*    public void PlayGame1()
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1f;
        }
        public void PlayGame2()
        {
            SceneManager.LoadScene(3);
            Time.timeScale = 1f;
        }*/
    public void Rest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
	{
		Application.Quit();
	}
	public void Easy()
	{
		_hr = 10;
	}
	public void Normal()
	{
        _hr = 6;
    }
	public void Hard()
	{
        _hr = 0;
    }
}
