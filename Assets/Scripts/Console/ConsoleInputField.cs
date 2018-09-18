using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class ConsoleInputField : MonoBehaviour {

	public Console TargetConsole;

	private InputField _input;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_input = GetComponent<InputField>();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		// focued, not empty and pressed enter/return
		if (_input.text != "" && Input.GetKey(KeyCode.Return))
		{
			TargetConsole.ProcessCommand(_input.text);
			
			_input.text = "";
		}
	}
}
