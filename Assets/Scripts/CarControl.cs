using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarControl : MonoBehaviour
{
    public GameObject game_over, car, button;
    public Button Pausebtn;
    public Sprite[] cars;
    int CarNo = 1;
    float speed = 0.07f;
    int Score = 0, Selection = 1;
    bool isGoingRight = false, isGoingLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score", 0);
        CarNo = PlayerPrefs.GetInt("CarNo", 1);
        car.GetComponentInChildren<SpriteRenderer>().sprite = cars[CarNo];
        Selection = PlayerPrefs.GetInt("Selection", 1);
        if (Selection == 1)
        {
            button.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Selection == 0)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                float border = Mathf.Clamp(transform.position.x + speed, -2, 2);
                transform.position = new Vector2(border, transform.position.y);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, -20);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                float border = Mathf.Clamp(transform.position.x - speed, -2, 2);
                transform.position = new Vector2(border, transform.position.y);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 20);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if (Selection == 1)
        {
            if (isGoingRight)
            {
                float border = Mathf.Clamp(transform.position.x + speed, -2, 2);
                transform.position = new Vector2(border, transform.position.y);
            }
            if (isGoingLeft)
            {
                float border = Mathf.Clamp(transform.position.x - speed, -2, 2);
                transform.position = new Vector2(border, transform.position.y);
            }
        }
        if (Selection == 2)
        {
            if (Time.timeScale == 1)
            {
                accelaratorMove();
            }
        }
        if (Selection == 3)
        {
            if (Time.timeScale == 1)
            {
                touchMove();
            }
        }
    }
    void touchMove()
    {
        if (Input.touchCount==1)
        {
            Touch t = Input.GetTouch(0);
            if (t.position.x < (Screen.width/2))
            {
                float border = Mathf.Clamp(transform.position.x - speed, -2, 2);
                transform.position = new Vector2(border, transform.position.y);
                transform.rotation = Quaternion.Euler(0, 0, 20);
            }
            else if (t.position.x > (Screen.width/2))
            {
                float border = Mathf.Clamp(transform.position.x + speed, -2, 2);
                transform.position = new Vector2(border, transform.position.y);
                transform.rotation = Quaternion.Euler(0, 0, -20);
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void accelaratorMove()
    {
        if (Input.acceleration.x < -0.1f)
        {
            float border = Mathf.Clamp(transform.position.x - speed, -2, 2);
            transform.position = new Vector2(border, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }
        else if (Input.acceleration.x > 0.1f)
        {
            float border = Mathf.Clamp(transform.position.x + speed, -2, 2);
            transform.position = new Vector2(border, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, -20);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void btnRightDown()
    {
        isGoingRight = true;
        transform.rotation = Quaternion.Euler(0, 0, -20);
    }
    public void btnRightUp()
    {
        isGoingRight = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void btnLestDown()
    {
        isGoingLeft = true;
        transform.rotation = Quaternion.Euler(0, 0, 20);
    }
    public void btnLeftUp()
    {
        isGoingLeft = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void right()
    {
        float border = Mathf.Clamp(transform.position.x + speed, -2, 2);
        transform.position = new Vector2(border, transform.position.y);
    }
    public void left()
    {
        float border = Mathf.Clamp(transform.position.x - speed, -2, 2);
        transform.position = new Vector2(border, transform.position.y);
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "car")
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            Pausebtn.interactable = false;
            game_over.SetActive(true);
        }
        if (c.gameObject.tag == "coin")
        {
            Destroy(c.gameObject);
            Score += 10;
            PlayerPrefs.SetInt("Score", Score);
        }
    }
}
