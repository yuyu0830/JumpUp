using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameTimer : MonoBehaviour
{
    float timer;
    string record;
    Text InGameTimer_text;
    // Start is called before the first frame update
    void Start()
    {
        InGameTimer_text = GameObject.Find("InGameTimer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        record = string.Format("{0:N2}", 60 - timer);
        PlayerPrefs.SetString("time", record);
        InGameTimer_text.text = record;
        if (timer >= 60f)
        {
            PlayerPrefs.SetInt("Die", System.Convert.ToInt16(1));
            SceneManager.LoadScene("GameOver");
        }
    }
}
