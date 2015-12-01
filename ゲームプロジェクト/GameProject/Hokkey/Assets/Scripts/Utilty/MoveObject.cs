//=====================================================================
//
// オブジェクトの移動処理 [MoveObject.cs]
// 制作者 坂本友希
//
//=====================================================================
using UnityEngine;
using System.Collections;
//=============================================
// オブジェクトの移動処理クラス
//=============================================
public class MoveObject : MonoBehaviour 
{
	//---------------------------------------
	//  変数宣言
	//---------------------------------------
	//自身のトランスフォーム
	public Transform myTrans;
	//自身のリジッドボディ
	public Rigidbody myRigid;
	//操作時のキーコード
	public  KeyCode KEY_MOVE_RIGHT = KeyCode.D;
	public  KeyCode KEY_MOVE_LEFT = KeyCode.A;
	public  KeyCode KEY_MOVE_UP = KeyCode.W;
	public  KeyCode KEY_MOVE_DOWN = KeyCode.S;
	public  KeyCode KEY_MOVE_JUMP = KeyCode.Return;
	//移動速度
	public  float MoveSpeed=1.0f;
	//ジャンプ力
	public  float SPD_JUMP=1.0f;
	//現在の移動速度を格納する変数
	private Vector3 m_moveSpeed;
	//摩擦力
	public float InertiaPow;

	//-----------------------------------------
	// 初期化処理
	//-----------------------------------------
	void Start ()
	{
		//移動速度を格納する変数を0で初期化
		m_moveSpeed=new Vector3(0,0,0);
	}

	//-----------------------------------------
	// 更新処理
	//-----------------------------------------
	void Update ()
	{
		m_moveSpeed=new Vector3(0,0,0);

		//入力に合わせて移動速度を計算
		if(Input.GetKey(KEY_MOVE_LEFT))
		{
			m_moveSpeed.x=-MoveSpeed;
		}
		
		if(Input.GetKey(KEY_MOVE_RIGHT))
		{
			m_moveSpeed.x=MoveSpeed;
		}
		
		if(Input.GetKey(KEY_MOVE_DOWN))
		{
			m_moveSpeed.z=-MoveSpeed;
		}
		
		if(Input.GetKey(KEY_MOVE_UP))
		{
			m_moveSpeed.z=MoveSpeed;
		}
	}


	//-----------------------------------------
	// 物理計算時の更新処理
	//-----------------------------------------
	void FixedUpdate () 
	{
		//加速させる
		myRigid.AddForce(m_moveSpeed,ForceMode.VelocityChange);
	}

}
