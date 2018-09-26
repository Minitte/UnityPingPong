using UnityEngine;

public class EnableAICommand : ConsoleCommand
{

    public EnableAICommand()
    {
        _helpMessage = "ai <Player> <true/false>";
    }

    public override string ProcessCommand(string[] args)
    {
        if (args.Length != 3)
        {
            return _helpMessage;
        }

        bool ai = false;
        int player = -1;

        // Try to parse the AI bool flag
        if (!bool.TryParse(args[2], out ai))
        {
            return _helpMessage;
        }

        // try to parse the player number
        if (!int.TryParse(args[1], out player))
        {
            return _helpMessage;
        }

        // only for player 1 or 2
        if (player != 1 && player != 2)
        {
            return _helpMessage;
        }

        GameObject paddleGO = GameObject.Find("Player " + player + " Paddle");

        paddleGO.GetComponent<PaddleAI>().enabled = ai;

        return "Player " + player + "'s AI is " + ai;
    }
}