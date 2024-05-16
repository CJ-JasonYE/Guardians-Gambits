using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endUI;
    public Text endMessage;

    public static GameManager Instance;
    private EnemySpawner spawner;

    private void Awake()
    {
        Time.timeScale = 1;
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        spawner = GetComponent<EnemySpawner>();
    }

    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "WIN!";
    }

    public void Failed()
    {
        spawner.Stop();
        endUI.SetActive(true);
        endMessage.text = "GAME OVER";
        endUI.transform.GetChild(3).GetComponent<Text>().text = this.GetComponent<BuildManager>().GetScore().ToString();
        Time.timeScale = 0;
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
}
