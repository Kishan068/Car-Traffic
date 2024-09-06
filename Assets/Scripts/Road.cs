using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Road : MonoBehaviour
{
    Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetY = Time.time * 0.5f;
        render.material.SetTextureOffset("_MainTex", new Vector2(0, offsetY));
    }
}
