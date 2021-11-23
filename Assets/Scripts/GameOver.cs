using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Text isClear;
    Text myScore;
    Text myRecord;
    bool iscl;
    // Start is called before the first frame update
    void Start()
    {
        isClear = GameObject.Find("IsClear").GetComponent<Text>();
        myScore = GameObject.Find("Score").GetComponent<Text>();
        myRecord = GameObject.Find("Time").GetComponent<Text>();
        if (System.Convert.ToBoolean(PlayerPrefs.GetInt("Die"))) isClear.text = "Clear!!";
        else isClear.text = "Game Over";
        myScore.text = "Score : " + PlayerPrefs.GetInt("Score");
        myRecord.text = "Time : " + PlayerPrefs.GetString("time");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
