using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
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
    private string userID = "Name";
    private string password = "1234";


    public void LoginButtonClick() //로그인 버튼 
    {
        if(PlayerPrefs.HasKey(userID) || PlayerPrefs.HasKey(password))//(IDRogin.text == userID && paswedRogin.text == password)
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

    public void RegisterBtnClick() //회원가입 버튼 
    {

        LoginView.SetActive(false);
        RegisterView.SetActive(true);

      
    }

    public void GoBtnClick()
    {
        //입력된 아이디 비밀번호 
            string userID = IDRogin2.text; 
            string password = paswedRogin2.text;

        if (IDRogin2.text == userID && paswedRogin2.text == password)
        {
            // PlayerPrefs를 사용하여 사용자 데이터를 저장합니다 
            PlayerPrefs.SetString(userID, password);
            PlayerPrefs.Save();

            Debug.Log("사용자 등록 완료: " + userID);

        }
        if (PlayerPrefs.HasKey(userID))
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
