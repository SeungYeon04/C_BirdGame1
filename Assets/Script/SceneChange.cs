using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void square()
    {
        SceneManager.LoadScene("Square");  
    }

    public void corr()
    {
        SceneManager.LoadScene("corridor");
    }

    public void fsihshop()
    {
        SceneManager.LoadScene("Fishshop");
    }

    public void fishing1()
    {
        SceneManager.LoadScene("River-fs1");
    }

    public void market()
    {
        SceneManager.LoadScene("Markets");
    }
}
