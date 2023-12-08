using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
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
    private string userID = "Name";
    private string password = "1234";


    public void LoginButtonClick() //�α��� ��ư 
    {
        if(PlayerPrefs.HasKey(userID) || PlayerPrefs.HasKey(password))//(IDRogin.text == userID && paswedRogin.text == password)
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

    public void RegisterBtnClick() //ȸ������ ��ư 
    {

        LoginView.SetActive(false);
        RegisterView.SetActive(true);

      
    }

    public void GoBtnClick()
    {
        //�Էµ� ���̵� ��й�ȣ 
            string userID = IDRogin2.text; 
            string password = paswedRogin2.text;

        if (IDRogin2.text == userID && paswedRogin2.text == password)
        {
            // PlayerPrefs�� ����Ͽ� ����� �����͸� �����մϴ� 
            PlayerPrefs.SetString(userID, password);
            PlayerPrefs.Save();

            Debug.Log("����� ��� �Ϸ�: " + userID);

        }
        if (PlayerPrefs.HasKey(userID))
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
