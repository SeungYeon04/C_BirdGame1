using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement; //씬
using UnityEngine.UI;

public class Rogin : MonoBehaviour
{
    //창 
    public GameObject LoginView;
    public GameObject RegisterView;

    //로그인용 
    public InputField paswedRogin; 
    public InputField IDRogin;

    //회원가입용 
    public InputField paswedRogin2;
    public InputField IDRogin2;

    //일단 임시 로그인 정보 
    public static string userID;
    public static string password;


    public void LoginButtonClick() //로그인 버튼 
    {
        string IDinput = IDRogin.text;
        string PSinput = paswedRogin.text;

        Debug.Log(userID); //되면 지우기 

        if(PlayerPrefs.GetString(userID) == IDRogin.text && PlayerPrefs.GetString(password) == password)// (IDRogin.text == userID && paswedRogin.text == password) //(PlayerPrefs.HasKey(userID) || PlayerPrefs.HasKey(password)) //(PlayerPrefs.HasKey(userID) || PlayerPrefs.HasKey(password)) //(IDRogin.text == userID && paswedRogin.text == password)//(PlayerPrefs.HasKey(userID) || PlayerPrefs.HasKey(password))
        {
            Debug.Log("로그인 성공");
            SceneManager.LoadScene("RPGMain");
        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }

    public void RegisterBtnClick() //회원가입 버튼 
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
        //입력된 아이디 비밀번호 
        string IDinput2 = IDRogin2.text; 
        string PSinput2 = paswedRogin2.text;

        Debug.Log(userID);

        if (IDRogin2.text != userID)
        {
            userID = IDinput2;
            password = PSinput2;

            // PlayerPrefs를 사용하여 사용자 데이터를 저장합니다 
            PlayerPrefs.SetString(userID, password);
            PlayerPrefs.Save();

            Debug.Log("사용자 등록 완료: " + userID);



        }
        else if (PlayerPrefs.HasKey(userID))
        {
            Debug.LogWarning("이미 사용자가 존재합니다.");
        }
        else if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(password))
        {
            Debug.LogWarning("사용자명과 비밀번호는 비어있을 수 없습니다.");
        }
        else
        {
            Debug.Log("오류 그 잡채: " + userID);
        }
    }

    public void BackBtnClick() //뒤로가기 버튼 
    {
        LoginView.SetActive(true);
        RegisterView.SetActive(false);
    }

}
