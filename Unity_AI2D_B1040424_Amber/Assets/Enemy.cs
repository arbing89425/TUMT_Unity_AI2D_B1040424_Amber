
using UnityEngine;

public class Enemy : MonoBehaviour {
    #region 參數項目 欄位
    [Header("移動速度"), Range(0, 100)]
	public float speed = 1.5f;
	[Header("傷害"), Range(0, 100)]
	public float damage = 20.0f;
	private Rigidbody2D rb2;

	public Transform checkPoint;
    #endregion
    private void Start()
	{
		rb2 = GetComponent<Rigidbody2D>();
	}
	private void FixedUpdate()
	{
		Move();
	}
	/// <summary>
	/// 繪製圖示
	/// </summary>
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(checkPoint.position, -checkPoint.up*3);
	}

	/// <summary>
	/// 持續觸發 如果碰到的物體名字是Mace 會追蹤
	/// </summary>
	/// <param name="collision"></param>
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.name == "Mace")
		{
			Track(collision.transform.position);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Mace" && collision.transform.position.y < transform.position.y + 0.5 )
		{
			collision.gameObject.GetComponent<player>().Damage(damage);
		}
	}

	/// <summary>
	/// 隨機移動
	/// </summary>
	private void Move()
	{
		//區域座標
		rb2.AddForce(-transform.right * speed);
		//偵測到地板 = 物理.偵測射線
		RaycastHit2D hit =  Physics2D.Raycast(checkPoint.position, -checkPoint.up, 1.5f, 1 << 9);
		if (hit == false)
		{
			this.transform.eulerAngles += new Vector3(0, 180, 0);
			
		}
	}

	/// <summary>
	/// 追蹤
	/// </summary>
	private void Track(Vector3 target)
	{
		//如果玩家在左邊 角度 0
		if (target.x < transform.position.x)
		{
			transform.eulerAngles = Vector3.zero;
		}
		//如果玩家在右邊 角度 180
		else
		{
			transform.eulerAngles = new Vector3(0 ,180 ,0 );
		}
	}

}
