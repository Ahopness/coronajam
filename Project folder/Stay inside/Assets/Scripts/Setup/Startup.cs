// Have a nice day ;)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Audio;

public class Startup : MonoBehaviour {

	[Header("UI")]
	public Image img_bg;
	public Text txt_info;
	public Text txt_mensage;

	[Header("Settings")]
	public float anm_speed;

	[Header("Player")]
	public PlayerLook scr_pl;
	public PlayerMove scr_pm;

	[Header("Mensage")]
	[TextArea()]public string str_text;
	public float normal_type_speed;
	public float fast_types_speed;

	[Header("Others")]
	public AudioSource audio_type;
	public AudioSource[] audio_outside;
	public AudioReverbZone[] reverb_zones;

	float typing_spd;
	bool isComplete;

	void Start(){
		scr_pl.enabled = false;
		scr_pm.enabled = false;

		StartCoroutine (TypeText ());

		isComplete = false;

		txt_info.enabled = false;
	}

	IEnumerator TypeText(){
		foreach (char letter in str_text.ToCharArray()) {
			txt_mensage.text += letter;

			audio_type.pitch = Random.Range (.8f, 1.2f);
			audio_type.Play ();

			yield return new WaitForSeconds (typing_spd);
		}
	}

	void Update(){
		if (txt_mensage.text == str_text) {
			isComplete = true;
		} else {
			isComplete = false;
		}

		if (isComplete) {
			DOTween.timeScale = 1;

			StopCoroutine (TypeText ());

			txt_info.enabled = true;

			if (Input.GetKeyDown (KeyCode.Space)) {
				Sequence sqc_mensage = DOTween.Sequence ();
					
				sqc_mensage.Append (txt_mensage.DOFade(0, anm_speed));
				sqc_mensage.Join (txt_info.DOFade (0, anm_speed));
				sqc_mensage.Append (img_bg.DOFade (0, anm_speed));

				scr_pl.enabled = true;
				scr_pm.enabled = true;

				foreach (AudioSource sound in audio_outside) {
					sound.Play ();
				}
				foreach (AudioReverbZone reverb in reverb_zones) {
					reverb.enabled = true;
				}

				this.enabled = false;
			}
		} else {
			txt_info.enabled = false;
		}

		if (Input.GetKey (KeyCode.Space)) {
			typing_spd = fast_types_speed;
		} else {
			typing_spd = normal_type_speed; 
		}
	}
}
