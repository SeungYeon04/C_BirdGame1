using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rogin : MonoBehaviour
{
    public GameObject LoginView;

    public InputField paswedRogin;
    public InputField IDRogin;
    public Button Button_Login;

    //Test를 위해 임의로 사용자 변수를 추가했음
    private string userID = "Name";
    private string password = "1234";

    public void LoginButtonClick()
    {
        if(IDRogin.text == userID && paswedRogin.text == password)
        {
            Debug.Log("로그인 성공");
            //로그인 성공시 로그인 창 닫음
            LoginView.SetActive(false);
        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
