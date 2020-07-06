using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectModel : MonoBehaviour {

 
	public static string ModelName;
	void Start () {
		Button[] buttons = this.GetComponentsInChildren<Button>();
		foreach (var button in buttons){
			  button.onClick.AddListener(delegate {TaskWithParameters(button.name);});
		}
	}

	 void TaskWithParameters(string message)
    {
		ModelName = message;
        Debug.Log(message);
        SceneManager.LoadScene(3);
    }

	public 	void BackButton(){
		SceneManager.LoadScene("Menu");
	}
	
}
