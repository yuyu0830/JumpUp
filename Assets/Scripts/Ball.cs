using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Die", System.Convert.ToInt16(0));
        if (transform.position.y <= -5) SceneManager.LoadScene("GameOver");
    }
}
