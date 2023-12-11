using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ATM : MonoBehaviour
{
    public Text PlayerMoney;

    // Start is called before the first frame update
    public void Start()
    {
        //PlayerStack p = new PlayerStack();
        PlayerStack.Status.Chaingi();

        if (PlayerMoney != null)
        {
            //PlayerStack.Status.Money = 100;
            PlayerMoney.text = "보유 현금: " + PlayerStack.Status.Money.ToString();
        }
    }


    public void BcakAtm()
    {
        SceneManager.LoadScene("RPGMain");

       
    }
}
