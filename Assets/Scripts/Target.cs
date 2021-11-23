using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    float timer;
    float speed;
    float randomX, randomY;
    int score;
    Vector2 pos;
    private Text myScore;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        score = 0;
        PlayerPrefs.SetInt("Score", 0);
        myScore = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 0.2f;
        if (timer > speed)
        {
            timer = 0;
            Create();
        }
        transform.localScale = new Vector3(speed - timer,speed - timer, 0);
    }
    void Create()
    {
        randomX = UnityEngine.Random.Range(7f, -7f);
        randomY = UnityEngine.Random.Range(5f, -2f);
        pos = new Vector2(randomX, randomY);
        transform.position = pos;
        speed -= speed * 0.03f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            timer = 0;
            Create();
            score += 1;
            PlayerPrefs.SetInt("Score", score);
            myScore.text = "Score : " + score;
        }
    }
}
