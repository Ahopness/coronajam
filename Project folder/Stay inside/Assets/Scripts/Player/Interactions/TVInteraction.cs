// Have a nice day ;)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TVInteraction : MonoBehaviour {

	[Header ("TV Tag")]
	[SerializeField] private string TVTag;

	[Header ("TV Sound")]
	public AudioSource audio;

	[Header ("Raycast Prop.")]
	[SerializeField] private int RayDistace = 3;

	[Header ("Icon")]
	public Image Icon;

	[Header ("TV Video")]
	public VideoPlayer _VideoPlayer;

	[Header ("Timer")]
	public float VideoDuretion;
	float timer;
	bool beguinTimer;

	void Start () {
		Icon.color = Color.white;
	}

	void Update () {
		// Raycast
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, RayDistace)) {

			if (hit.collider.CompareTag (TVTag)) {
				Icon.color = Color.green;
				if (Input.GetKeyDown(KeyCode.Space)) {
					audio.Play ();
					_VideoPlayer.enabled = true;
					_VideoPlayer.Play ();
					beguinTimer = true;
				}
			}
		} else {
			Icon.color = Color.white;
		}

		if (beguinTimer) {
			timer += Time.deltaTime;
		}

		if (timer == VideoDuretion) {
			_VideoPlayer.enabled = false;
		}

		if (timer >= VideoDuretion + 5) {
			SceneManeger.instance.ChangeScene (GameScenes.DAY_2, GameScenes.DAY_1, "DIA II");
		}
	}
}
