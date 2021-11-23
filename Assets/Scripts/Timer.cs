using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    int time;
    Text timer_text;
    GameObject Object;
    string[] objects;
    // Start is called before the first frame update
    void Start()
    {
        objects = new string[] {"Square", "Line", "Circle1", "Circle2", "Ball", "Target", "Raycast"};
        timer_text = GameObject.Find("Timer").GetComponent<Text>();
        time = 3;
        GameObject Object = GameObject.Find("Object");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 1)
        {
            timer_text.text = "3";
        }
        else if(timer < 2)
        {
            timer_text.text = "2";
        }
        else if (timer < 3)
        {
            timer_text.text = "1";
        }
        else if (timer < 4)
        {
            timer_text.text = "Start!";
        }
        else
        {
            foreach (string obj in objects)
            {
                GameObject.Find("Object").transform.Find(obj).gameObject.SetActive(true);
            }
            GameObject.Find("Canvas").transform.Find("Score").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("InGameTimer").gameObject.SetActive(true);
            GameObject.Find("Timer").SetActive(false);
        }
    }
}
