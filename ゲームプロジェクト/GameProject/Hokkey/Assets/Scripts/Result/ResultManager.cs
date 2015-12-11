using UnityEngine;
using System.Collections;

public class ResultManager : MonoBehaviour 
{
	
	public UI_NumberManager ChainUiManager;
	public UI_NumberManager ScoreUiManager;
	static private bool LiveFlag;
	// Use this for initialization
	void Start () 
	{
		AudioManager.Instance.PlayBGM("ResultBGM");
		//ゲームマネージャークラスの取得
		GameObject obj;

		obj=GameObject.Find("ChainNum");
		ChainUiManager = obj.GetComponent <UI_NumberManager>();

		obj=GameObject.Find("ScoreNum");
		ScoreUiManager = obj.GetComponent <UI_NumberManager>();


		if(ScoreManager.Instance)
		{
			ScoreUiManager.SetNum(ScoreManager.Instance.GetScore());
		}

		else
		{
			ScoreUiManager.SetNum(0);
		}

		if(ChainManager.Instance)
		{
			ChainUiManager.SetNum(ChainManager.Instance.GetMaxScore());
		}

		else
		{
			ChainUiManager.SetNum(0);
		}

		LiveFlag=false;
		CameraFade.StartAlphaFade(Color.black, true,2.0f, 0f,()=>ChengeFlag(true));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(LiveFlag)
		{
			if(Input.anyKeyDown)
			{
				AudioManager.Instance.PlaySE("TitleSelect");
				LiveFlag=false;
				CameraFade.StartAlphaFade(Color.black, false, 2.0f, 0f,()=>{Application.LoadLevel("Title");});
			}
		}
	}
	
	public static void ChengeFlag(bool Flag)
	{
		LiveFlag = Flag;
	}
}
