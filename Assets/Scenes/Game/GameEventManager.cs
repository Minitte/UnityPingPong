using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour {
	
	public delegate void BallEvent(PingPongBall ball);

	/// <summary>
	/// Event for when a new ball was created
	/// </summary>
	public static event BallEvent OnNewBall;

	/// <summary>
	/// Event for when a ball was removed
	/// </summary>
	public static event BallEvent OnRemoveBall;

	public delegate void GoalEvent(int scoringTeam);

	/// <summary>
	/// Event for when goal was scored
	/// </summary>
	public static event GoalEvent OnGoal;

	/// <summary>
	/// Triggers a OnNewBall event
	/// </summary>
	public void BroadcastBallSpawnEvent(PingPongBall ball)
	{
		if (OnNewBall != null)
		{
			OnNewBall(ball);
		}
	}

	/// <summary>
	/// Triggers a OnRemoveBall event
	/// </summary>
	public void BroadcastBallRemoveEvent(PingPongBall ball)
	{
		if (OnRemoveBall != null)
		{
			OnRemoveBall(ball);
		}
	}

	/// <summary>
	/// Triggers a OnGoal event
	/// </summary>
	/// <param name="scoringTeam"></param>
	public void BroadcastGoalEvent(int scoringTeam)
	{
		if (OnGoal != null)
		{
			OnGoal(scoringTeam);
		}
	}
}
