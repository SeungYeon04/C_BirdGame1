using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ATM : MonoBehaviour
{/*
    //숫자 표시!!만 하는 아래 텍스트들 종류 
    public Text PlayerMoney; 
    public Text ATMMoney;

    //입력 창 인풋 텍스트 받는 칸!! 
    public InputField PlaseMoney;
    public InputField MinuseMoney;

    //은행 저장해둔 돈 값 저장소!! 데이터 
    public static int MMoney; 

    public void Start()
    {
        //PlayerStack p = new PlayerStack();
        PlayerStack.Status.Chaingi();

        if (PlayerMoney != null)
        {
            //PlayerStack.Status.Money = 100;
            PlayerMoney.text = "보유 현금: " + PlayerStack.Status.Money.ToString();
        }
        if (ATMMoney != null)
        {
            //PlayerStack.Status.Money = 100;
            ATMMoney.text = "저금 금액: " + MMoney.ToString();
        }
    }

    public void BcakAtm()
    {
        SceneManager.LoadScene("RPGMain"); 
    }

    //atm저장공간 안에다 돈 더하기 InputField PlaseMoney에 입력된 만큼 
    public void MoneyPluse()
    {
        //문자열을 int로 바꿔서 더하기 
        int MoneyATMin = int.Parse(PlaseMoney.text);

        if (PlayerStack.Status.Money >= MoneyATMin) //현재돈 보다 입력 값이 작다면
        {
            PlayerStack.Status.Money -= MoneyATMin;
            MMoney += MoneyATMin;

            if (PlayerMoney != null)
            {
                //PlayerStack.Status.Money = 100;
                PlayerMoney.text = "보유 현금: " + PlayerStack.Status.Money.ToString();
                 PlayerPrefs.SetInt(PlaseMoney.text, PlayerStack.Status.Money);
                  PlayerPrefs.Save(); 
            }
            if (ATMMoney != null)
            {
                //PlayerStack.Status.Money = 100;
                ATMMoney.text = "저금 금액: " + MMoney.ToString();
            }

            Debug.Log(PlayerStack.Status.Money);


            //다시 밖에선 string으로 표시 
        }
        else
        {
            Debug.Log("잘못된 값 입력");
        }
    }

    public void MoneyMinus()
    {
        int MoneyATMout = int.Parse(MinuseMoney.text); //text를 잠시 int형 데이터로 만들어서 

        if(MMoney >= MoneyATMout) //은행 돈보디 입력 값이 작다면 
        {
            PlayerStack.Status.Money += MoneyATMout; 
            MMoney -= MoneyATMout; 

            if(MinuseMoney != null)
            {
                PlayerMoney.text = "보유 현금 : " + PlayerStack.Status.Money.ToString(); 

            }
            if(PlayerMoney != null)
            {
                ATMMoney.text = "저금 금액 : " + MMoney.ToString(); 
                //PlayerPrefs.SetInt(MinuseMoney.text, MoneyATMout);
                //PlayerPrefs.Save();

            }
        }       

        
    }*/
}
