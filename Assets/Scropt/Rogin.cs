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

    //Test�� ���� ���Ƿ� ����� ������ �߰�����
    private string userID = "Name";
    private string password = "1234";

    public void LoginButtonClick()
    {
        if(IDRogin.text == userID && paswedRogin.text == password)
        {
            Debug.Log("�α��� ����");
            //�α��� ������ �α��� â ����
            LoginView.SetActive(false);
        }
        else
        {
            Debug.Log("�α��� ����");
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
