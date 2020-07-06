using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserDefinedTargets : MonoBehaviour
{

    // Use this for initialization
    public GameObject FirstBookPrompt;
    public GameObject BrowseMenu;
	public GameObject loginButton;
    public Button BookYes;
    public Button BookNo;
    void Start()
    {

        // this.gameObject.SetActive(true);
		loginButton.SetActive(true);
        this.BookYes.onClick.AddListener(delegate { YesBook(); });
        this.BookNo.onClick.AddListener(delegate { NoBook(); });
    }

    void YesBook()
    {
        FirstBookPrompt.SetActive(false);
        BrowseMenu.SetActive(true);
    }
    void NoBook()
    {
        SceneManager.LoadScene("ModelsList");
    }

    public void BackButton()
    {
        FirstBookPrompt.SetActive(true);
        BrowseMenu.SetActive(false);
    }

    public void login()
    {

        loginButton.SetActive(false);
        FirstBookPrompt.SetActive(true);
        Debug.Log("Here");
    }
}
