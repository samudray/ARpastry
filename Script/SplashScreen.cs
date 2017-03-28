using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public float timer = 7; //Lama waktu pindah dari splash screen ke loading menu

	public void Update(){
		timer -= Time.deltaTime; //Timer mundur
		if (timer > 0){
			Debug.Log(timer);
		}else {
			Application.LoadLevel(1); // Jika waktu <0 maka otomatis pindah ke main menu app
		}
	}

}