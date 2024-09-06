using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyPoint : MonoBehaviour
{
    public GameObject game_over, setting_panel;
    public Button Pausebtn;
    public Text score;
    int Score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Select(int s)
    {
        PlayerPrefs.SetInt("Selection", s);
        SceneManager.LoadScene("CarTraffic");
        Time.timeScale = 1;
    }
    public void setting()
    {
        if (Time.timeScale == 1)
        {
            pause();
            setting_panel.SetActive(true);
        }
        else
        {
            setting_panel.SetActive(false);
            pause();
        }
    }
    public void pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            Pausebtn.interactable = true;
        }
    }
    public void reset()
    {
        Time.timeScale = 1;
        game_over.SetActive(false);
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
        SceneManager.LoadScene("CarTraffic");
    }

    // Update is called once per frame
    void Update()
    {
        Score = PlayerPrefs.GetInt("Score", 0);
        score.text = Score.ToString();
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "car")
        {
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "coin")
        {
            Destroy(c.gameObject);
        }
    }
}
