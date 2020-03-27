// Have a nice day ;)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManeger : MonoBehaviour {
	public static SceneManeger instance;

	[Header("UI")]
	public Text txt_day;
	public Slider sdl_loadingbar;

	[Header("Objects")]
	public GameObject obj_UI;
	public GameObject obj_cam;

	void Awake () {
		instance = this;

		SceneManager.LoadSceneAsync ((int)GameScenes.MENU, LoadSceneMode.Additive);
	}

	List<AsyncOperation> ScenesLoading = new List<AsyncOperation>();

	public void ChangeScene(GameScenes SceneToGo, GameScenes CurrectScene, string SceneDay){
		txt_day.text = SceneDay;

		obj_UI.SetActive (true);
		obj_cam.SetActive (true);

		ScenesLoading.Add (SceneManager.UnloadSceneAsync ((int)CurrectScene));
		ScenesLoading.Add (SceneManager.LoadSceneAsync ((int)SceneToGo, LoadSceneMode.Additive));

		StartCoroutine (GetSceneLoadProgres());
	}

	float totalSceneProgres;
	IEnumerator GetSceneLoadProgres(){
		for (int i = 0; i < ScenesLoading.Count; i++) {
			while (!ScenesLoading [i].isDone) {
				totalSceneProgres = 0;

				foreach (AsyncOperation operation in ScenesLoading) {
					totalSceneProgres += operation.progress;
				}
					
				totalSceneProgres = (totalSceneProgres / ScenesLoading.Count) * 100f;
				sdl_loadingbar.value = Mathf.RoundToInt (totalSceneProgres);

				yield return null;
			}
		}

		obj_UI.SetActive (false);
		obj_cam.SetActive (false);
	}
}
