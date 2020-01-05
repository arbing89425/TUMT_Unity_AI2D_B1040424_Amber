using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoGround : MonoBehaviour {
	public float Speed =3.0f ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		transform.position = new Vector3(Mathf.PingPong(21, 3), transform.position.y, transform.position.z);
	}
}
