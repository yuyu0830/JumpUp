using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    LineRenderer line;
    public EdgeCollider2D col2d;
    public bool allOn;
    // Start is called before the first frame update
    void Start()
    {
        allOn = true;
        line = GetComponent<LineRenderer>();
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        col2d = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (allOn)
        {
            line.SetPosition(0, GameObject.Find("Circle1").GetComponent<Transform>().position);
            line.SetPosition(1, GameObject.Find("Circle2").GetComponent<Transform>().position);
        }
    }
    public void setAllOn()
    {
        allOn = true;
    }
    public void setAllOff()
    {
        allOn = false;
    }
    public void setPoints(List<Vector2> temp)
    {
        col2d.SetPoints(temp);
    }
}