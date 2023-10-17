using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimerReset : MonoBehaviour
{
	public float ResetTime = 4f;

	void Start()
	{
		Invoke("Reset", ResetTime);
	}

	void Reset()
	{

		SceneManager.LoadScene("StartScene");
	}
}