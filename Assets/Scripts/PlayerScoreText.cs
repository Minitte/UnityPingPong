using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlayerScoreText : MonoBehaviour {

	/// <summary>
	/// Score
	/// </summary>
	public int Score;

	/// <summary>
	/// Owning player number or slot
	/// </summary>
	public int OwningSlot;

	/// <summary>
	/// Text component
	/// </summary>
	private Text _text;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_text = gameObject.GetComponent<Text>();

		_text.text = Score + "pt";

		GameEventManager.OnGoal += IncScore;
	}

	/// <summary>
	/// Increments the score
	/// </summary>
	/// <param name="scoring"></param>
	public void IncScore(int scoring)
	{
		if (scoring == OwningSlot)
		{
			Score++;

			_text.text = Score + "pt";
		}
	}

}
