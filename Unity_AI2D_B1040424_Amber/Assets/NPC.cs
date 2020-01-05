using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NPC : MonoBehaviour
{
    #region 介面
    public enum state
	{
		//	 一般、尚未完成、完成、要求擊倒敵人、尚未擊倒、擊倒敵人
		normal, notComplete, complete, prepareAtk, notAtk, Atk
	}
	
	//使用列舉
	public state _state;
	

	[Header("對話")]
	public string sayStart = " 你好,你有看到我的金幣嗎?可以幫我找5個金幣嗎?";
	public string sayNotComplete = "呃....你還沒找到金幣喔";
	public string sayComplete = "是我的金幣!!謝謝你!進入旁邊的寶箱就可以過關囉!";
	
	[Header("對話速度")]
	public float speed = 2.0f;
	[Header("任務相關")]
	public bool complete;
	public int countPlayer;
	public int countFinish = 10;
	[Header("介面")]
	public GameObject objCanvas;
	public Text textSay;
	#endregion
	#region 對話
	private void OnTriggerEnter2D(Collider2D collision)
	{
		// 如果碰到物件為"Mace"
		if (collision.name == "Mace")
			Say();
			
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.name == "Mace")
			SayClose();
	}

	/// <summary>
	/// 開啟對話
	/// </summary>
	private void Say()
	{
		// 畫布.顯示
		objCanvas.SetActive(true);
		StopAllCoroutines();
		if (countPlayer >= countFinish)
		{
			_state = state.complete;
			

		}
		
		// 判斷式(狀態)
		switch (_state)
		{
			case state.normal:
				StartCoroutine(ShowDialog(sayStart));           // 開始對話
				_state = state.notComplete;
				break;
			case state.notComplete:
				StartCoroutine(ShowDialog(sayNotComplete));     // 開始對話未完成
				break;
			case state.complete:
				StartCoroutine(ShowDialog(sayComplete));        // 開始對話完成
				break;
			
		}
	}
	

	private void SayClose()
	{
		objCanvas.SetActive(false);
		StopAllCoroutines();
	}
    #endregion
	//協同程序
	private IEnumerator ShowDialog(string say)
	{
		textSay.text = "";                              // 清空文字

		for (int i = 0; i < say.Length; i++)            // 迴圈跑對話.長度
		{
			textSay.text += say[i].ToString();          // 累加每個文字
			yield return new WaitForSeconds(speed);     // 等待
		}
	}
	
	public void PlayerGet()
	{
		countPlayer ++; 
	}
}
