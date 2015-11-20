using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour 
{
	public Text TimeText;
	private float time = 60;
	// Use this for initialization
	void Start ()
	{
		TimeText.text = ((int)time).ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//1秒に1ずつ減らしていく
		time -= Time.deltaTime;
		//マイナスは表示しない
		if (time < 0) time = 0;
		TimeText.text = ((int)time).ToString ();
	}
}
