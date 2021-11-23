using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    bool isRedSet;
    bool isBlueSet;
    Vector2 mousePos;
    public List<Vector2> points;
    Lines line_com;
    GameObject line;
    Circle circle1;
    Circle circle2;
    bool allOn;
    // Start is called before the first frame update
    void Start()
    {
        isRedSet = true;
        isBlueSet = true;
        line = GameObject.Find("Line");
        line_com = line.GetComponent<Lines>();
        circle1 = GameObject.Find("Circle1").GetComponent<Circle>();
        circle2 = GameObject.Find("Circle2").GetComponent<Circle>();
        points.Add(new Vector2(1, 0)); //blue
        points.Add(new Vector2(-1, 0)); //red
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isBlueSet = false;
            isRedSet = false;
            line_com.setAllOff();
            line.SetActive(false);
            circle1.prepare(4.5f);
            circle2.prepare(5.5f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            //Vector2 wp = Camera.main.ScreenToWorldPoint(mousePos);
            //Ray2D ray = new Ray2D(wp, Vector2.zero);
            //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            var pos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
            if (!line_com.allOn)
            {
                if (!isBlueSet)
                {
                    points[0] = pos;
                    circle1.setPosition(pos);
                    isBlueSet = true;
                }
                else if (!isRedSet)
                {
                    points[1] = pos;
                    circle2.setPosition(pos);
                    isRedSet = true;
                }
                if (isBlueSet && isRedSet)
                {
                    line.SetActive(true);
                    line_com.setAllOn();
                    line_com.setPoints(points);
                }
            }
        }
    }
}
