// Have a nice day ;)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	[Header("UI Objects")]
	public GameObject Main;
	public GameObject Credits;

	void Start(){
		Main.SetActive (true);
		Credits.SetActive (false);
	}

	public void StartGame(){
		SceneManeger.instance.ChangeScene (GameScenes.DAY_1, GameScenes.MENU, "DIA I");
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void GoToCredits(){
		Main.SetActive (false);
		Credits.SetActive (true);
	}

	public void GoToMenu(){
		Main.SetActive (true);
		Credits.SetActive (false);
	}

	public void GoToWebsite(){
		Application.OpenURL ("http://jams.gamejolt.io/corona_jam");
	}
}
