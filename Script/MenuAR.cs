using UnityEngine;
using System.Collections;

public class MenuAR : MonoBehaviour {

	// Membuat variable untuk resize layar
	public GUISkin guiSkin;
	private float guiRatio;
	private float sWidth;
	private Vector3 GUIsF;

	public GameObject	cake,creature,Croissant;
	public float		kecepatanRotasi = 50f;
	bool statusRotasi = false;

	void Awake() {
		sWidth = Screen.width;
		guiRatio = sWidth / 1920;
		GUIsF = new Vector3 (guiRatio, guiRatio, 1);
	}

	void OnGUI(){
		GUI.skin = guiSkin;
		//letakan function
		Rotasi();
	}

	void Rotasi(){
		//button dipojok atas kanan
		GUI.matrix = Matrix4x4.TRS (new Vector3 (Screen.width - 258 * GUIsF.x, GUIsF.y, 0), Quaternion.identity, GUIsF);

		if (statusRotasi == false) {
			if (GUI.Button (new Rect (-208, 10, 238, 59), "Rotasi")) {
				statusRotasi = true;
			}
		} else {
			if (GUI.Button (new Rect (-208, 10, 238, 59), "Stop Rotasi")) {
				statusRotasi = false;
			}
		}

		if (GUI.Button (new Rect (40, 10, 208, 59), "Keluar")) {
			Application.Quit (); //untuk keluar App
		}
	 
		//Hanya Notif Info untuk klik object 3D product
		GUI.matrix = Matrix4x4.TRS (new Vector3 (Screen.width - 258 * GUIsF.x, Screen.height - 89 * GUIsF.y, 0), Quaternion.identity, GUIsF);
		if (GUI.Button (new Rect (-1650, -30, 640, 80), "Click 3D Object For Info Detail Product...!!!")) {
		}
	}
		
	void Update(){
		if (statusRotasi == true) {
			cake.transform.Rotate (Vector3.up, kecepatanRotasi * Time.deltaTime);
		}
		if (statusRotasi == true) {
			creature.transform.Rotate (Vector3.forward, kecepatanRotasi * Time.deltaTime);
		}
		if (statusRotasi == true) {
			Croissant.transform.Rotate (Vector3.forward, kecepatanRotasi * Time.deltaTime);
		}
	}
		
}
