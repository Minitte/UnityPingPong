using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

	public Text ConsoleOutput;

	public InputField ConsoleInput;

	public GameObject ConsolePanel;

	private Dictionary<string, ConsoleCommand> _cmds = new Dictionary<string, ConsoleCommand>();

	private string _helpMessage;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		// register commands
		_cmds.Add("setscore", new SetScoreCommand());
		_cmds.Add("background", new SetBackgroundCommand());
		_cmds.Add("ai", new EnableAICommand());

		// create help message
		List<string> keyList = new List<string>(_cmds.Keys);

		_helpMessage = "--- Commands ---\n";

		foreach (string key in keyList)
		{
			_helpMessage += _cmds[key].HelpMessage + "\n";
		}

		_helpMessage = "----------------\n";


		// hide console by default
		ConsolePanel.SetActive(false);
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (!ConsoleInput.isFocused && Input.GetKeyDown(KeyCode.C))
		{
			ConsolePanel.SetActive(!ConsolePanel.activeSelf);
		}
		else if (Input.GetKeyDown(KeyCode.Escape))
		{
			ConsolePanel.SetActive(false);
		}
	}

	public void ProcessCommand(string command)
	{
		string[] args = command.Split(' ');

		string cmd = args[0].ToLower();

		if (cmd == "help")
		{
			ConsoleOutput.text += _helpMessage;

			return;
		}

		if (!_cmds.ContainsKey(cmd))
		{
			ConsoleOutput.text += "Unknown command\n";
			return;
		}
		else
		{
			string result = _cmds[cmd].ProcessCommand(args);

			ConsoleOutput.text += result + "\n";
		}
	}
}
