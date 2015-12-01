//=====================================================================
//
// ボールの移動処理 [BallMove.cs]
// 制作者 坂本友希
//
//=====================================================================
using UnityEngine;
using System.Collections;
//=============================================
// ボールの移動処理クラス
//=============================================
public class BallMove : MonoBehaviour 
{
	//-----------------------------------------
	// 変数宣言
	//-----------------------------------------
	//初期の加速速度
	public Vector3 FirstMoveForce;
	//自身のリジッドボディ
	public Rigidbody myRigid;
	//ゲームマネージャークラス
	public GameManager myManager;

	private int PlayerCnt;
	private const int PlayerCntMax=30;

	//public GameObject Effect;

	//-----------------------------------------
	// 初期化処理
	//-----------------------------------------
	void Start () 
	{
		//ゲームマネージャークラスの取得
		GameObject obj=GameObject.Find("GameManagerHolder");;
		myManager = obj.GetComponent <GameManager>();
		//初期の加速の反映
		myRigid.AddForce(FirstMoveForce);
		PlayerCnt=0;
	}
	
	//-----------------------------------------
	// 更新処理
	//-----------------------------------------
	void Update () 
	{

	}

	//-----------------------------------------
	// 当たり判定時の処理
	//-----------------------------------------
	void OnCollisionStay(Collision other)
	{
		if(other.gameObject.tag=="Player")
		{
			PlayerCnt++;
		}

		else if(other.gameObject.tag!="Floor")
		{
			PlayerCnt=0;
		}

		if(PlayerCnt==PlayerCntMax)
		{
			//マネージャーに消えることを伝える
			myManager.SetisBall(false);
			//自身を破壊する
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.name=="Wall")
		{
			//Instantiate(Effect,myRigid.position,myRigid.rotation);
		}
	}

	void OnTriggerEnter(Collider other)
	{

		//マネージャーに消えることを伝える
		myManager.SetisBall(false);
		//自身を破壊する
		Destroy(this.gameObject);
	}
}
