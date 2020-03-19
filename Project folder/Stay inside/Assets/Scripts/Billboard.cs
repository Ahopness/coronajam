// Have a nice day ;)
using UnityEngine;

public class Billboard : MonoBehaviour {

    public Camera cam;

	void LateUpdate () {
        var target = cam.transform.position;
        target.y = transform.position.y;
        transform.LookAt(target);
    
    }
}
