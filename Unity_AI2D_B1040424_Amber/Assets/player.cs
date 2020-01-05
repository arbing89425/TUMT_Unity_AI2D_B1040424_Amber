using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class player : MonoBehaviour {

    #region 參數項目 欄位
    [Header("移動速度")]
    [Range(0, 10)] 
    public float Speed;

   [Header("跳躍")]
   [Range(0, 500)] 
    public float JumpForce;
    [Header("血量")]
    [Range(0, 100)]
    public float HP ;
    public Image hpBar;
    public GameObject final;
    public GameObject final2;
    private float hpMax;

    public bool isGround = false;
	Rigidbody2D rgbdy;
    public UnityEvent onEat;
    #endregion
    // Use this for initialization
    void Start () {
		rgbdy = this.GetComponent<Rigidbody2D>();

        hpMax = HP;
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Speed * 1, 0, 0, Space.Self);
                
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            
            this.transform.Translate(-Speed * 1, 0, 0, Space.Self);
                
        }
    
            
        }
    public void Jump ()
    {
        if (Input.GetKey(KeyCode.Space)  && isGround == true )
        {
            isGround = false;
            rgbdy.AddForce(new Vector2(0 , JumpForce * Input.GetAxis("Jump")));
        }


       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGround = true;
       
        }
    
    private void FixedUpdate()
    {
        Walk();
        Jump();
    }
    private void Walk()
    {
        rgbdy.AddForce(new Vector2(Speed * Input.GetAxis("Horizontal"),0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果碰到物件為"金幣"
        if (collision.tag == "金幣")
        {
            Destroy(collision.gameObject);
            onEat.Invoke();
        }
        else if (collision.tag == "寶箱")
        {
            final2.SetActive(true);
        }
        else if (collision.tag == "消失")
        {
            final.SetActive(true);
        }
        
    }
    public void Damage(float damage)
    {
        HP -= damage;
        hpBar.fillAmount = HP / hpMax;
        if (HP <= 0)
        {
            final.SetActive(true);
        }
    }
   

}
