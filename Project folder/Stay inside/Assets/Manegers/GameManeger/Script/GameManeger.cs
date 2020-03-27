// Have a nice day ;)
using UnityEngine;

public class GameManeger : MonoBehaviour {
	public static GameManeger instance;

	void Awake(){
		instance = this;
	}
}
