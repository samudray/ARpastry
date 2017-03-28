using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour, IButtonListener   {

	//variable button
	private Button buttonStart, buttonPanduan, buttonExit;

	//variable untuk memberikan image slideshow Panduan
	public Texture gambar1,gambar2,gambar3;

	//variable untuk menambahkan text pada slide show yang dibagi menjadi beberapa bagian (info1,2,3)
	public string info1,info2,info3;

	//variable untuk memberikan status aplikasi apakah sedang aktif(true) atau quit (false)
	public bool menuPanduan = false;

	//variable untuk mendaftarkan gambar tombol exit
	public Texture exit;

	//script untuk slideshow
	public Vector2 scrollPosition1 = Vector2.zero;
	public GUISkin guiSkin;

	void Start () {
		buttonStart = this.transform.FindChild("buttonStart").GetComponent<Button>();
		buttonPanduan = this.transform.FindChild("buttonPanduan").GetComponent<Button>();
		buttonExit = this.transform.FindChild("buttonExit").GetComponent<Button>();

		buttonStart.RegisterListener(this);
		buttonPanduan.RegisterListener(this);
		buttonExit.RegisterListener(this);
	}

	public void OnButtonStateChange(Button changedButton, int buttonPhaseId) {
		if (changedButton == buttonStart) { // jika button touch di tekan
			Application.LoadLevel(2); // pindah ke scene 2 (Menu Augmented Reality Pastry)
		}

		if(changedButton == buttonPanduan) { // jika panduan ditekan
			menuPanduan=true; // slideshow panduan ditampilkan 
		}
		if (changedButton == buttonExit) {
			Application.Quit(); // keluar dari aplikasi
		}
	}

	void OnGUI(){
		if(menuPanduan==true){

			//membentuk slideshow aplikasi
			GUI.BeginGroup(new Rect(Screen.width/2-200,Screen.height/2-250,800,500));
			GUI.Box(new Rect(0,50,405,360),"Informasi");

			if(GUI.Button(new Rect(0, 50, 30, 30),exit)){	
				menuPanduan = false; // jika tombol exit ditekan slideshow akan keluar
			}

			scrollPosition1 = GUI.BeginScrollView(new Rect(30,0,350,390),scrollPosition1,new Rect(0,0,1150,200));

			GUI.DrawTexture(new Rect(0,90,350,210),gambar1); // menampilkan gambar pada slideshow
			info1 = GUI.TextArea(new Rect(0,300,350,50),info1,200); // menampilkan informasi pada slideshow

			GUI.DrawTexture(new Rect(400,90,350,210),gambar2);
			info2 = GUI.TextArea(new Rect(400,300,350,50),info2,200);

			GUI.DrawTexture(new Rect(800,90,350,210),gambar3);
			info3 = GUI.TextArea(new Rect(800,300,350,50),info3,200);

			GUI.EndScrollView();
			GUI.EndGroup();
		}
	}
}
