using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeComp : MonoBehaviour
{
    public Animator  UpgradeBox;

    public Text coinsShow;
    public Text damagePrice;
    public Text speedPrice;
    public Text healthPrice;

    public Text healStat;
    public Text damageStat;
    public Text speedStat;

    private int damageUpPrice = 20;
    private int speedUpPrice = 20;
    private int healthUpPrice = 20;

    private int coins;

    void Start()
    {
      if(PlayerPrefs.HasKey("damageUpP"))
        damageUpPrice = PlayerPrefs.GetInt("damageUpP");
      if(PlayerPrefs.HasKey("speedUpP"))
        speedUpPrice = PlayerPrefs.GetInt("speedUpP");
      if(PlayerPrefs.HasKey("healUpP"))
        healthUpPrice = PlayerPrefs.GetInt("healUpP");

    }

    void Update()
    {
      coins = GetComponent<heroBehavior>().GetCoins();
      healthPrice.text = healthUpPrice + "";
      speedPrice.text = speedUpPrice + "";
      damagePrice.text = damageUpPrice + "";
      coinsShow.text = coins + "";

      healStat.text = "Health: " + GetComponent<heroBehavior>().GetHealth() + "/" + GetComponent<heroBehavior>().maxHealth;
      speedStat.text = "Speed: " + GetComponent<heroBehavior>().playerSpeed;
      damageStat.text = "Damage: " + GetComponent<AttackComp>().damage;

    }

    public void DamageUp()
    {
      if(coins >= damageUpPrice)
      {
        GetComponent<heroBehavior>().ChangeBalance(-damageUpPrice);
        GetComponent<AttackComp>().damage += 2.5f;
        damageUpPrice += 15;
        PlayerPrefs.SetInt("damageUpP", damageUpPrice);
        PlayerPrefs.SetFloat("damagePower",GetComponent<AttackComp>().damage);
        PlayerPrefs.SetInt("coins",coins);
      }

    }

    public void SpeedUp()
    {
      if(coins >= speedUpPrice)
      {
        GetComponent<heroBehavior>().ChangeBalance(-speedUpPrice);
        GetComponent<heroBehavior>().playerSpeed += 0.5f;
        speedUpPrice += 15;
        PlayerPrefs.SetInt("speedUpP", speedUpPrice);
        PlayerPrefs.SetFloat("speed",GetComponent<heroBehavior>().playerSpeed);
        PlayerPrefs.SetInt("coins",coins);
      }

    }

    public void HealthUp()
    {
      if(coins >= healthUpPrice)
      {
        GetComponent<heroBehavior>().ChangeBalance(-healthUpPrice);
        GetComponent<heroBehavior>().maxHealth += 10;
        GetComponent<heroBehavior>().Heal(10);
        healthUpPrice += 15;
        PlayerPrefs.SetInt("healthUpP", healthUpPrice);
        PlayerPrefs.SetFloat("health",GetComponent<heroBehavior>().maxHealth);
        PlayerPrefs.SetInt("coins",coins);
      }

    }

    public void Open()
    {
      UpgradeBox.SetBool("isOpen",true);

    }

    public void Close()
    {
      UpgradeBox.SetBool("isOpen",false);

    }


}
