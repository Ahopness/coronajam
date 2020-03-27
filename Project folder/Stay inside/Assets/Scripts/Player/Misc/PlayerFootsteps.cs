// Have a nice day ;)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {

	[Header("Components")]
	public CharacterController cc;
	public AudioSource sfx_footsteps;

	[Header("Paremeters")]
	public float minVol = .8f;
	public float maxVol = 1f;
	[Space]
	public float minPitch = .8f;
	public float maxPitch = 1.1f;

	void Update () {
		if (sfx_footsteps.isPlaying == false && cc.velocity.magnitude > 0) {
			sfx_footsteps.volume = Random.Range(minVol, maxVol);
			sfx_footsteps.pitch = Random.Range(minPitch, maxPitch);

			sfx_footsteps.Play ();
		}
	}
}
