using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	#region event

	

	#endregion

	/// <summary>
	/// Event Manager
	/// </summary>
	public GameEventManager EventMngr;

	/// <summary>
	/// List of player info that is currently playing
	/// </summary>
	public PlayerInfo[] PlayerList;

	/// <summary>
	/// Ball prefab
	/// </summary>
	public GameObject BallPrefab;

	/// <summary>
	/// Text for displaying the winner
	/// </summary>
	public Text WinText;

	/// <summary>
	/// Player score text displays
	/// </summary>
	public PlayerScoreText[] PlayerScoreTexts;

	/// <summary>
	/// Score for each player by index
	/// </summary>
	public int[] Scores = new int[2];

	/// <summary>
	/// Win flag
	/// </summary>
	private bool _win;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		// find all players
		GameObject[] playerGO = GameObject.FindGameObjectsWithTag("PlayerInfo");

		PlayerList = new PlayerInfo[playerGO.Length];

		for (int i = 0; i < playerGO.Length; i++)
		{
			PlayerInfo pInfo = playerGO[i].GetComponent<PlayerInfo>();

			// each player shoudl have their own slot
			Debug.Assert(PlayerList[pInfo.Slot] == null, "Found multiple PlayerInfos with the same slot");

			PlayerList[pInfo.Slot] = pInfo;
		}

		// find all paddles
		GameObject[] paddleGO = GameObject.FindGameObjectsWithTag("Player");

		// Setup player stuff
		foreach (PlayerInfo pInfo in PlayerList)
		{
			if (pInfo.IsAI)
			{
				PlayerPaddle paddle = paddleGO[pInfo.Slot].GetComponent<PlayerPaddle>();

				// paddle.gameObject.AddComponent(typeof(PaddleAI));
				paddle.gameObject.GetComponent<PaddleAI>().enabled = true;
			}
		}

		// subscribe to event
		GameEventManager.OnGoal += SpawnBallOnGoal;

		SpawnBall();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (_win)
		{
			if (Input.GetAxis("P1Submit") != 0)
			{
				RestartGame();
				_win = false;
			}
		}
	}

	/// <summary>
	/// Spawns a ball on goal
	/// </summary>
	/// <param name="scoringTeam"></param>
	private void SpawnBallOnGoal(int scoringTeam)
	{
		Scores[scoringTeam]++;

		if (Scores[scoringTeam] > 6)
		{
			_win = true;
			WinText.text = "Player " + (scoringTeam + 1) + " wins!";
			WinText.gameObject.SetActive(true);
		}
		else
		{
			SpawnBall();
		}
	}

	/// <summary>
	/// Spawns a ball and triggers GameEventManager.OnNewBall event
	/// </summary>
	public void SpawnBall()
	{
		// create first ball.
		GameObject ballGO = GameObject.Instantiate(BallPrefab);

		// trigger event
		EventMngr.BroadcastBallSpawnEvent(ballGO.GetComponent<PingPongBall>());
	}

	/// <summary>
	/// Resets score and spawns a new ball
	/// </summary>
	public void RestartGame()
	{
		Scores[0] = 0;
		Scores[1] = 0;

		PlayerScoreTexts[0].Score = -1;
		PlayerScoreTexts[0].IncScore(0);
		PlayerScoreTexts[1].Score = -1;
		PlayerScoreTexts[1].IncScore(1);

		WinText.gameObject.SetActive(false);

		SpawnBall();
	}
	
}
