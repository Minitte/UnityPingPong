using UnityEngine;
using UnityEngine.UI;

public abstract class ConsoleCommand
{

    /// <summary>
    /// Help message
    /// </summary>
    /// <value></value>
    public string HelpMessage
    {
        get { return _helpMessage; }
    }

    /// <summary>
    /// Help message
    /// </summary>
    protected string _helpMessage;

    /// <summary>
    /// Processes the command
    /// </summary>
    /// <param name="args">command args.</param>
    /// <returns>a string output for the console</returns>
    public abstract string ProcessCommand(string[] args);



}