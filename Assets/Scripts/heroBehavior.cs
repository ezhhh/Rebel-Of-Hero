using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Animations;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class heroBehavior : MonoBehaviour
{
    Animator anim;
    public Rigidbody2D rb2d;

    private int Coins;
    public Text coinsCount;

    public Image leftButton;
    public Image jumpButton;
    public Image rightButton;
    public float PosBtnLeft;
    public float PosBtnRight;

    public bool facingRight = true;
    public float directionInput;

    public float playerSpeed;
    public float damage;
    public float jumpPower;
    public bool jump;
    public float maxHealth = 100;
    private float health;

    public Image healthBar;

    public Vector2 SpawnPoint;

    private int adsCount;

    void Awake()
    {
      if(PlayerPrefs.HasKey("spawnX"))
      {
        SpawnPoint = new Vector2(PlayerPrefs.GetFloat("spawnX"),PlayerPrefs.GetFloat("spawnY"));
        transform.position = SpawnPoint;
      } else SpawnPoint = transform.position;

      if(PlayerPrefs.HasKey("adsCount"))
        adsCount = PlayerPrefs.GetInt("adsCount");

      Advertisement.Initialize("3356514",false);

    }
    void Start()
    {
      health = maxHealth;
      Coins = PlayerPrefs.GetInt("coins");
      anim = GetComponent<Animator>();
      rb2d = GetComponent<Rigidbody2D>();
      PosBtnLeft = leftButton.transform.position.y;
      PosBtnRight = rightButton.transform.position.y;
      PlayerPrefs.SetInt("lastLvl",SceneManager.GetActiveScene().buildIndex);

      if(PlayerPrefs.HasKey("speed"))
        playerSpeed = PlayerPrefs.GetFloat("speed");
      if(PlayerPrefs.HasKey("health"))
        maxHealth = PlayerPrefs.GetFloat("health");

    }


    void Update()
    {

        healthBar.fillAmount = health / maxHealth;

        if(health <= 0)
        {
          PlayerPrefs.DeleteKey("spawnX");
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        coinsCount.text = Coins + "";
        anim.SetBool("isJumping",false);
        anim.SetBool("Move",false);

        //directionInput = Input.GetAxis("Horizontal");

        if(directionInput != 0)
          anim.SetBool("Move",true);

        if ((directionInput < 0) && (facingRight))
          Flip();

        if ((directionInput > 0) && (!facingRight))
          Flip();

    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * directionInput * playerSpeed * Time.deltaTime);
        //rb2d.velocity = new Vector2(playerSpeed * directionInput, rb2d.velocity.y);
    }


    public void Move(int InputAxis)
    {
      directionInput = InputAxis;

    }
    public void Jump(bool isJump)
    {
        if (jump == true)
        {
          rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
          anim.SetBool("isJumping",true);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float GetHealth()
    {
      return(health);
    }

    public void GetDamage(float d)
    {
      health -= d;
      //Debug.Log("Player damaged: " + d);
    }

    public void Heal(float h)
    {
      health += h;
      if(health > maxHealth)
        health = maxHealth;
    }

    public void ChangeBalance(int c)
    {
      Coins += c;
    }

    public int GetCoins()
    {
      return(Coins);
    }



    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "trap")
      {
        transform.position = SpawnPoint;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        adsCount++;
        PlayerPrefs.SetInt("adsCount",adsCount);
        if(adsCount % 10 == 0)
          Advertisement.Show();
      }
      if(col.gameObject.tag == "spawnPoint")
      {
        SpawnPoint = col.gameObject.transform.position;
        PlayerPrefs.SetFloat("spawnX",SpawnPoint.x);
        PlayerPrefs.SetFloat("spawnY",SpawnPoint.y);
      }

    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
            jump = true;

        if (coll.gameObject.tag == "trap")
        {
          //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          transform.position = SpawnPoint;
          adsCount++;
          PlayerPrefs.SetInt("adsCount",adsCount);
          if(adsCount % 10 == 0)
            Advertisement.Show();

        }

    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag != "Ground")
            jump = false;

        if (coll.transform.tag == "Ground")
            jump = false;
    }
}
