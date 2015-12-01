using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public bool isDebug;
	public KeyCode RefreshKey;
	public GameObject Ball;
	private GameObject ActiveBall;
	private bool isBall;
	public Transform[] points;
	private float RespornCnt;
	public float RespornTime;
	static private bool LiveFlag;

	// Use this for initialization
	void Start () 
	{
		LiveFlag=false;
		CameraFade.StartAlphaFade(Color.black, true,2.0f, 0f,()=>ChengeFlag(true));
		RespornCnt=0;
		isBall=false;
		AudioManager.Instance.PlayBGM("BGM_TEST");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(LiveFlag)
		{
			if(!isBall)
			{
				if(RespornCnt>=RespornTime)
				{
					RespornCnt=0;
					isBall=true;
					int idx=Random.Range(0,points.Length);
					Instantiate(Ball,points[idx].position,points[idx].rotation);
				}

				else
				{
					RespornCnt+=Time.deltaTime;
				}
			}

			if(isDebug&&(Input.GetKeyDown(RefreshKey)))
			{
				CameraFade.StartAlphaFade(Color.black, false, 2.0f, 0f,()=>{Application.LoadLevel("Game");});
			}
		}
	}

	public static void ChengeFlag(bool Flag)
	{
		LiveFlag = Flag;
	}

	public void SetisBall(bool value)
	{
		isBall=value;
	}
}
