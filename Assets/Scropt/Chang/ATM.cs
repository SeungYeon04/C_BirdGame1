using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ATM : MonoBehaviour
{
    public Text PlayerMoney; 
    public Text ATMMoney;

    public InputField PlaseMoney;
    public InputField MinuseMoney;

    //일단 임시 로그인 정보 
    public static int PMoney; //그냥 선언해본 돈 
    public static int MMoney; //입금돈 

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
        int MoneyATMin = int.Parse(PlaseMoney.text);

        if (PlayerStack.Status.Money >= MoneyATMin) //현재돈 보다 입력값이 작다면
        {
            //PlaseMoney.text += int.Parse(ATMMoney.text);
            //int ATMInput = int.Parse(ATMMoney.text); 
            //ATMMoney.text = PlayerMoney.text;
            //ATMInput += int.Parse(PlayerMoney.text);

            Debug.Log("!");
            //문자열을 int로 바꿔서 더하기 


            PlayerStack.Status.Money -= MoneyATMin;
            MMoney += MoneyATMin;

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

            Debug.Log(PlayerStack.Status.Money);

            //다시 밖에선 string으로 표시 


        }
    }
}
