using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement; //��
using UnityEngine.UI;

public class Rogin : MonoBehaviour
{
    //â 
    public GameObject LoginView;
    public GameObject RegisterView;

    //�α��ο� 
    public InputField paswedRogin; 
    public InputField IDRogin;

    //ȸ�����Կ� 
    public InputField paswedRogin2;
    public InputField IDRogin2;

    //�ϴ� �ӽ� �α��� ���� 
    public static string userID;
    public static string password;


    public void LoginButtonClick() //�α��� ��ư 
    {
        string IDinput = IDRogin.text;
        string PSinput = paswedRogin.text;

        Debug.Log(userID); //�Ǹ� ����� 

        if(PlayerPrefs.GetString(userID) == IDRogin.text && PlayerPrefs.GetString(password) == password)// (IDRogin.text == userID && paswedRogin.text == password) //(PlayerPrefs.HasKey(userID) || PlayerPrefs.HasKey(password)) //(PlayerPrefs.HasKey(userID) || PlayerPrefs.HasKey(password)) //(IDRogin.text == userID && paswedRogin.text == password)//(PlayerPrefs.HasKey(userID) || PlayerPrefs.HasKey(password))
        {
            Debug.Log("�α��� ����");
            SceneManager.LoadScene("RPGMain");
        }
        else
        {
            Debug.Log("�α��� ����");
        }
    }

    public void RegisterBtnClick() //ȸ������ ��ư 
    {
        LoginView.SetActive(false);
        RegisterView.SetActive(true);
    }

    public string GetUserID()
    {
        return userID;
    }

    public void GoBtnClick()
    {
        //�Էµ� ���̵� ��й�ȣ 
        string IDinput2 = IDRogin2.text; 
        string PSinput2 = paswedRogin2.text;

        Debug.Log(userID);

        if (IDRogin2.text != userID)
        {
            userID = IDinput2;
            password = PSinput2;

            // PlayerPrefs�� ����Ͽ� ����� �����͸� �����մϴ� 
            PlayerPrefs.SetString(userID, password);
            PlayerPrefs.Save();

            Debug.Log("����� ��� �Ϸ�: " + userID);



        }
        else if (PlayerPrefs.HasKey(userID))
        {
            Debug.LogWarning("�̹� ����ڰ� �����մϴ�.");
        }
        else if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("����ڸ�� ��й�ȣ�� ������� �� �����ϴ�.");
        }
        else
        {
            Debug.Log("���� �� ��ä: " + userID);
        }
    }

    public void BackBtnClick() //�ڷΰ��� ��ư 
    {
        LoginView.SetActive(true);
        RegisterView.SetActive(false);
    }

}
