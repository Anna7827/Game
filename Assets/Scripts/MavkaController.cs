using Unity.VisualScripting;
using UnityEngine;

public class MavkaController : MonoBehaviour
{
    const int ForceArrow = 400; 
    [SerializeField] private float speed = 5;
    [SerializeField] private float jump = 20;
    [SerializeField] private Transform SensorGround;
    [SerializeField] private GameUI gameUI;
    //[SerializeField] private UserDataController userDataController;
    [SerializeField] private Rigidbody2D lily;
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private Transform AttackPoint2;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private bool isRight = true;
    private bool IsGround;
    //private int hearts = 3;
    //private int countLilys = 5;
    public Vector3 chackPoint;

    public int coins
    {
        get => UserDataController.Instance.userData.Coins;
    }

    public int crystals
    {
        get => UserDataController.Instance.userData.Crystals;
    }

    public int lilys
    {
        get => UserDataController.Instance.userData.Lilys;
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
       
        chackPoint = transform.position;
        //UserDataController.Instance.userData.Lilys=5;
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(move * speed, rb.velocity.y, 0);
        anim.SetFloat("SpeedX", Mathf.Abs(move));
        Flip(move);
    }

    void Update()
    {
        Jump();
        Attack();
    }


    void Attack ()
    {
        if (Input.GetKeyDown(KeyCode.Return)&& UserDataController.Instance.userData.Lilys > 0)
        {
            UserDataController.Instance.RemoveLilys(1);
            gameUI.SetCountLilysUI(UserDataController.Instance.userData.Lilys);
            anim.SetTrigger("Attack");
        }
    }
    void Dart()
    {
        Rigidbody2D tempLily = Instantiate(lily, isRight ? AttackPoint.position : AttackPoint2.position, Quaternion.identity);
        tempLily.AddForce(new Vector2(isRight ? ForceArrow : -ForceArrow, 0));

        if (isRight)
        {
            SpriteRenderer srLily = tempLily.GetComponent<SpriteRenderer>();
            srLily.flipX = true;
            srLily.flipY = false;
        }

        else if (!isRight)
        {
            SpriteRenderer srLily = tempLily.GetComponent<SpriteRenderer>();
            srLily.flipX = false;
            srLily.flipY = false;
        }
    }

    void Jump()
    {
        IsGround = Physics2D.OverlapCircleAll(SensorGround.position, 0.3f).Length > 1;
        if (Input.GetButtonDown("Jump") && IsGround)
        {
            rb.AddForce(Vector2.up * jump);
        }
        anim.SetFloat("SpeedY", rb.velocity.y);
        anim.SetBool("IsGround", IsGround);
    }

    void Flip(float move)
    {
        if (move < 0 && isRight)
        {
            isRight = false;
            sr.flipX = true;
        }
        else if (move > 0 && !isRight)
        {
            isRight = true;
            sr.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coins")
        {
            //countCoins += 100;
            UserDataController.Instance.AddCoins (100);
            gameUI.SetCountCoinsUI(UserDataController.Instance.userData.Coins);
            Destroy(collision.gameObject);
        }

        else if (collision.tag == "Crystals")
        {
            //countCrystals += 150;
            UserDataController.Instance.AddCrystals(150);
            gameUI.SetCountCrystalsUI(UserDataController.Instance.userData.Crystals);
            Destroy(collision.gameObject);
        }


        else if (collision.tag == "Lilys")
        {
           // int count = collision.GetComponent<Item>().count;
            //countLilys += count;
            UserDataController.Instance.AddLilys(5);
            gameUI.SetCountLilysUI(UserDataController.Instance.userData.Lilys);
            Destroy(collision.gameObject);
        }

        else if (collision.tag == "Floor")
        {
            Damage();
        }

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    if (collision.transform.tag == "Mushroom")
        {
            Damage();
        }
    }
    
        private void Damage()
    {
        //hearts--;
        UserDataController.Instance.RemoveHealth(1);
        gameUI.UpdateHeart(UserDataController.Instance.userData.Hearts);
        if (UserDataController.Instance.userData.Hearts == 0)
        {
            Time.timeScale = 0;
            UserDataController.Instance.ResetLives();
            gameUI.GameOver();
        }
    }
}

    