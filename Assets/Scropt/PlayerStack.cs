using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = " PlayerStack", menuName = "TopDownController/Attacks/Ranged", order = 1)]

public class PlayerStack : MonoBehaviour
{
    public Text PlayerHp;
    public Text PlayerDmg;
    public Text PlayerArmor;


    public enum StatsType1
    {
        Player0, 
    }
 
     public void Start()
     {
        Status.Chaingi(); //요거 실행하라! 가져오기 실행하기! 
        if (PlayerHp != null)
        {
           PlayerHp.text = "PlayerHp: " + Status.MaxHp.ToString();
        }
        if (PlayerDmg != null)
        {
           PlayerDmg.text = "PlayerDmg: " + Status.AtkDmg.ToString();
        }
        if (PlayerArmor != null)
        {
           PlayerArmor.text = "PlayerArmor: " + Status.Armor.ToString();
        }
    }

    public static class Status 
    {
       // private static int maxHp;

        public static StatsType1 statsType { get; } // 바꿀 수 없게 get만
        public static string name { get; set; }
        public static int MaxHp { get; set; }
        public static int nowHp { get; set; }
        public static int AtkDmg { get; set; }
        public static float atkSpeed { get; set; }
        public static float moveSpeed { get; set; }
        public static int atkRange { get; set; }
        public static int Armor { get; set; }
        public static int Money { get; set; }

        public static void Chaingi()
        {
            MaxHp = 10;
            nowHp = 10; 
            AtkDmg = 15;
            Armor = 10;
            Money = 100; 
        }

      /*
        public Status(StatsType1 statsType, string name, int maxHp, int atkDmg, float atkSpeed, float moveSpeed, float atkRange, float armor)
        {
            this.statsType = statsType;
            this.name = name;
            this.maxHp = maxHp;
            nowHp = maxHp;
            this.atkDmg = atkDmg;
            this.atkSpeed = atkSpeed;
            this.moveSpeed = moveSpeed;
            this.atkRange = atkRange;
            this.Armor = armor;
        }


        public Status SetUnitStatus(StatsType1 statsType)
        {
            Status status = null;

            switch (statsType)
            {
                case StatsType1.Player0:
                    status = new Status(statsType, "플레이어", 50, 10, 1f, 8f, 0, 5);
                    break;
            }
            return status;
        }*/
    }



    /*
    public enum StatsType1
    {
        Add, 
        Multiple, 
        Override, 
    }

    public static class PlayerStats
    {
        public static StatsType1 StatsType1;
        [Range(0f, 1f)] public static int maxHealth;
        [Range(0f, 1f)] public static float speed;

        static PlayerAttack playeratack;
    }

    public class PlayerAttack
    {
        [Header("Ranged Attack Data")]
        public string bulletNameTag;
        public float duration;
        public float speed;
        public int numberofProjectilesPerShot;
        public float multipleProjectilesAngel;
        public Color projectileColor;
        internal StatsType1 statsChangeType;
        internal int maxHealth;

        public Object PlayerStack { get; internal set; } //만든 거 
    }

    public class StatsHandler
    {

        [SerializeField] private PlayerAttack baseStats;
        public PlayerAttack CurrentStates { get; private set; }
        public List<PlayerAttack> statsModifiers = new List<PlayerAttack>();

        private void Awake()
        {
            UpdateCharacterStats();
        }

        private void UpdateCharacterStats()
        {
            PlayerStack playerStack = null;
            if (baseStats.PlayerStack != null)
            {
                playerStack = (PlayerStack)Instantiate(baseStats.PlayerStack);
            }

            CurrentStates = new PlayerAttack { PlayerStack = playerStack };
            // TODO
            PlayerStats.StatsType1 = baseStats.statsChangeType;
            PlayerStats.maxHealth = baseStats.maxHealth;
            PlayerStats.speed = baseStats.speed;

        }

    }*/
}
