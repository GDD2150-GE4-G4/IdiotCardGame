using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public void OnStartPress(){
		Application.LoadLevel ("MainGame");
	}

	public void OnRulesPress(){
		Application.LoadLevel ("Rules");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
