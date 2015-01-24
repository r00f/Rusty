using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

public void ChangeScrene (string sceneName)
	{
		Application.LoadLevel(sceneName);

	}
	
public void CloseGame ()
	{
		Application.Quit();
	}
}
