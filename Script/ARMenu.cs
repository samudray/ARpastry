using UnityEngine;
using System.Collections;

public class ARMenu : MonoBehaviour {

	public GUISkin guiSkin;
	public float guiRatio;
	public float sWidth;
	public Vector3 GUIsF;

	void Awake(){
		sWidth = Screen.width;
		guiRatio = sWidth / 1920;
		GUIsF = new Vector3 (guiRatio, guiRatio, 1);
	}

	void OnGUI(){
		GUI.skin = guiSkin;

		//Meletakan Button di pojok kiri
		GUI.matrix = Matrix4x4.TRS (new Vector3 (GUIsF.x, GUIsF.y, 0), Quaternion.identity, GUIsF);
		GUI.Button (new Rect (20, 20, 258, 89), "Button 1");
	
	}

}
