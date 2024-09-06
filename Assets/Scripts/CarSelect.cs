using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void selectcar(int n)
    {
        PlayerPrefs.SetInt("CarNo", n);
        SceneManager.LoadScene("CarTraffic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
