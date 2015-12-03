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
		GameObject obj=GameObject.Find("GameManagerHolder");

		myManager = obj.GetComponent <GameManager>();
		FirstMoveForce=myManager.BaseTrans_().position-this.gameObject.GetComponent <Transform>().position;
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
			AudioManager.Instance.PlaySE("SE_YARARE");
			if(this.gameObject.layer==8)
			{
				//マネージャーに消えることを伝える
				myManager.SetisBall(false,false);
			}
			else
			{
				//マネージャーに消えることを伝える
				myManager.SetisBall(false,true);
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{

		//if(other.gameObject.name=="Wall")
		{
			AudioManager.Instance.PlaySE("SE_HIT");
		}

		if(other.gameObject.tag=="Floor")
		{
			myRigid.velocity = new Vector3(myRigid.velocity.x,0,myRigid.velocity.z);
			myRigid.constraints = RigidbodyConstraints.FreezePositionY;
		}

		if(other.gameObject.tag=="Ball")
		{
			Vector3 PlayerPos=other.gameObject.GetComponent<Transform>().position;
			Vector3 Spd=myRigid.transform.position-PlayerPos;
			Spd*=18;
			myRigid.velocity=new Vector3(Spd.x,myRigid.velocity.y,Spd.z);
		}

		if(other.gameObject.name=="Cylinder")
		{
			Vector3 PlayerPos=other.gameObject.GetComponent<Transform>().position;
			Vector3 Spd=myRigid.transform.position-PlayerPos;
			Spd*=18;
			myRigid.velocity=new Vector3(Spd.x,myRigid.velocity.y,Spd.z);
		}

		if(other.gameObject.name=="Player")
		{
			Vector3 PlayerPos=other.gameObject.GetComponent<Transform>().position;
			Vector3 Spd=myRigid.transform.position-PlayerPos;
			Spd*=23;
			myRigid.velocity=new Vector3(Spd.x,myRigid.velocity.y,Spd.z);
		}
	}

	void OnTriggerEnter(Collider other)
	{

		AudioManager.Instance.PlaySE("SE_YARARE");
		//自身を破壊する
		Destroy(this.gameObject);

		if(this.gameObject.layer==8)
		{
			//マネージャーに消えることを伝える
			myManager.SetisBall(false,false);
		}
		else
		{
			//マネージャーに消えることを伝える
			myManager.SetisBall(false,true);
		}
	}
}
