// Have a nice day ;)
using UnityEngine;

public class FPSLock : MonoBehaviour {

     void Awake(){
        QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 24;
     }
}
