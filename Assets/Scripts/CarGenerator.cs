using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    public GameObject parentholder, coin;
    public GameObject[] cars;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generatecars", 2f, 5f);
        InvokeRepeating("generatecoin", 5f, 6f);
    }
    void generatecars()
    {
        int car = Random.Range(0, 9);
        float posX = Random.Range(-2f, 2f);
        Instantiate(cars[car], new Vector2(posX, 7), Quaternion.identity, parentholder.transform);
    }
    void generatecoin()
    {
        float posX = Random.Range(-2f, 2f);
        Instantiate(coin, new Vector2(posX, 7), Quaternion.identity, parentholder.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
