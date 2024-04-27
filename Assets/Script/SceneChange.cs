using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void cha1()
    {
        SceneManager.LoadScene("RPGMain");  
    }

    public void home1()
    {
        SceneManager.LoadScene("Home");
    }
}
