using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void Option()
    {
        SceneManager.LoadScene("Option");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
