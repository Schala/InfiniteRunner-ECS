using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	bool hasGameEnded = false;
	public float restartDelay = 1f;
	public GameObject completeLevelUI;
	public Text scoreUI;
	uint score = 0;
	bool paused = false;
	float lastTimeScale = 1f;
	int pauseDelay = 300;
	public void EndGame()
	{
		if (hasGameEnded) return;
		hasGameEnded = true;
		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.timeScale * .02f;
		Invoke("Restart", restartDelay);
	}

	void Update()
	{
		Keyboard keyboard = Keyboard.current;
		if (keyboard == null) return;
		if (pauseDelay > 0) pauseDelay--;

		if (pauseDelay <= 0 && keyboard.enterKey.isPressed)
		{
			paused = paused ? false : true;
			if (paused) lastTimeScale = Time.timeScale;
			Time.timeScale = paused ? 0f : lastTimeScale;
			scoreUI.text = paused ? "PAUSED" : "$" + score.ToString();
			pauseDelay = 300;
		}
	}

	void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	public void CompleteLevel() => completeLevelUI.SetActive(true);
	public void IncreaseScore()
	{
		score++;
		scoreUI.text = "$" + score.ToString();
	}
}
