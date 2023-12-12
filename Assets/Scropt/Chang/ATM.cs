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

    //�ϴ� �ӽ� �α��� ���� 
    public static int PMoney; //�׳� �����غ� �� 
    public static int MMoney; //�Աݵ� 

    public void Start()
    {
        //PlayerStack p = new PlayerStack();
        PlayerStack.Status.Chaingi();

        if (PlayerMoney != null)
        {
            //PlayerStack.Status.Money = 100;
            PlayerMoney.text = "���� ����: " + PlayerStack.Status.Money.ToString();
        }
        if (ATMMoney != null)
        {
            //PlayerStack.Status.Money = 100;
            ATMMoney.text = "���� �ݾ�: " + MMoney.ToString();
        }
    }

    public void BcakAtm()
    {
        SceneManager.LoadScene("RPGMain"); 
    }

    //atm������� �ȿ��� �� ���ϱ� InputField PlaseMoney�� �Էµ� ��ŭ 
    public void MoneyPluse()
    {
        int MoneyATMin = int.Parse(PlaseMoney.text);

        if (PlayerStack.Status.Money >= MoneyATMin) //���絷 ���� �Է°��� �۴ٸ�
        {
            //PlaseMoney.text += int.Parse(ATMMoney.text);
            //int ATMInput = int.Parse(ATMMoney.text); 
            //ATMMoney.text = PlayerMoney.text;
            //ATMInput += int.Parse(PlayerMoney.text);

            Debug.Log("!");
            //���ڿ��� int�� �ٲ㼭 ���ϱ� 


            PlayerStack.Status.Money -= MoneyATMin;
            MMoney += MoneyATMin;

            if (PlayerMoney != null)
            {
                //PlayerStack.Status.Money = 100;
                PlayerMoney.text = "���� ����: " + PlayerStack.Status.Money.ToString();
            }
            if (ATMMoney != null)
            {
                //PlayerStack.Status.Money = 100;
                ATMMoney.text = "���� �ݾ�: " + MMoney.ToString();
            }

            Debug.Log(PlayerStack.Status.Money);

            //�ٽ� �ۿ��� string���� ǥ�� 


        }
    }
}
