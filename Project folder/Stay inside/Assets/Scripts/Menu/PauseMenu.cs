// Have a nice day ;)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

	[Header("UI")]
	public Canvas PauseCanvas;
	public Slider sdl_sensitivity;

	[Header("Paremeters")]
	[Range(1,3)]public int currectday;

	[Header("Player")]
	public PlayerLook pl;
	public PlayerHeadbob ph;

	[Header("Other")]
	public AudioMixer audiom;

	bool isPaused = false;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}

		pl.Sensitivity = sdl_sensitivity.value;

		if (isPaused) {
			Time.timeScale = 0;
			DOTween.timeScale = 0;

			pl.isCursorLocked = false;

			PauseCanvas.enabled = true;

			audiom.SetFloat ("param_lowpass", 1000f);

			ph.enabled = false;
		} else {
			Time.timeScale = 1;
			DOTween.timeScale = 1;

			pl.isCursorLocked = true;

			PauseCanvas.enabled = false;

			audiom.SetFloat ("param_lowpass", 5000f);

			ph.enabled = true;
		}
	}

	public void Menu(){
		switch(currectday){
		case 1 : SceneManeger.instance.ChangeScene(GameScenes.MENU, GameScenes.DAY_1, "MENU");
			break;
		case 2 : SceneManeger.instance.ChangeScene(GameScenes.MENU, GameScenes.DAY_2, "MENU");
			break;
		case 3 : SceneManeger.instance.ChangeScene(GameScenes.MENU, GameScenes.DAY_3, "MENU");
			break;
		}
	}
}
