using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ATM : MonoBehaviour
{/*
    //���� ǥ��!!�� �ϴ� �Ʒ� �ؽ�Ʈ�� ���� 
    public Text PlayerMoney; 
    public Text ATMMoney;

    //�Է� â ��ǲ �ؽ�Ʈ �޴� ĭ!! 
    public InputField PlaseMoney;
    public InputField MinuseMoney;

    //���� �����ص� �� �� �����!! ������ 
    public static int MMoney; 

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
        //���ڿ��� int�� �ٲ㼭 ���ϱ� 
        int MoneyATMin = int.Parse(PlaseMoney.text);

        if (PlayerStack.Status.Money >= MoneyATMin) //���絷 ���� �Է� ���� �۴ٸ�
        {
            PlayerStack.Status.Money -= MoneyATMin;
            MMoney += MoneyATMin;

            if (PlayerMoney != null)
            {
                //PlayerStack.Status.Money = 100;
                PlayerMoney.text = "���� ����: " + PlayerStack.Status.Money.ToString();
                 PlayerPrefs.SetInt(PlaseMoney.text, PlayerStack.Status.Money);
                  PlayerPrefs.Save(); 
            }
            if (ATMMoney != null)
            {
                //PlayerStack.Status.Money = 100;
                ATMMoney.text = "���� �ݾ�: " + MMoney.ToString();
            }

            Debug.Log(PlayerStack.Status.Money);


            //�ٽ� �ۿ��� string���� ǥ�� 
        }
        else
        {
            Debug.Log("�߸��� �� �Է�");
        }
    }

    public void MoneyMinus()
    {
        int MoneyATMout = int.Parse(MinuseMoney.text); //text�� ��� int�� �����ͷ� ���� 

        if(MMoney >= MoneyATMout) //���� ������ �Է� ���� �۴ٸ� 
        {
            PlayerStack.Status.Money += MoneyATMout; 
            MMoney -= MoneyATMout; 

            if(MinuseMoney != null)
            {
                PlayerMoney.text = "���� ���� : " + PlayerStack.Status.Money.ToString(); 

            }
            if(PlayerMoney != null)
            {
                ATMMoney.text = "���� �ݾ� : " + MMoney.ToString(); 
                //PlayerPrefs.SetInt(MinuseMoney.text, MoneyATMout);
                //PlayerPrefs.Save();

            }
        }       

        
    }*/
}
