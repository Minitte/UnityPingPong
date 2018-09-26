using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameVSBtn : MonoBehaviour {

    /// <summary>
    /// Loads game scene
    /// </summary>
	public void BeginGame()
    {
        SceneManager.LoadScene("Game");
    }
	
}
