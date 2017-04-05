using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour {

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void setLangNext()
    {
        int _langId = 0;
        if (globalVars.LanguageId == 0)
        {
            _langId = 1;
        }
        else
        {
            _langId = 0;
         }
      
        globalVars.LanguageId = _langId;
        setUI_lang();
    }
    public void onExit()
    {
        Application.Quit();
    }
    void setUI_lang()
    {
        Text ButtonPlayText = GameObject.Find("txt_play").GetComponent<Text>();
        Text ButtonGalleryText = GameObject.Find("txt_gallery").GetComponent<Text>();
        Text ButtonAboutText = GameObject.Find("txt_about").GetComponent<Text>();
        Text ButtonExitText = GameObject.Find("txt_exit").GetComponent<Text>();
        Text ButtonLangText = GameObject.Find("txt_lang").GetComponent<Text>();
        if (globalVars.LanguageId == 0)
        {
            //eng
            ButtonPlayText.text = "Play";
            ButtonGalleryText.text = "Gallery";
            ButtonAboutText.text = "About";
            ButtonExitText.text = "Exit";

            ButtonLangText.text = "Рус";
        }
        else
        {
            //rus
            ButtonPlayText.text = "Старт";
            ButtonGalleryText.text = "Просмотр";
            ButtonAboutText.text = "Справка";
            ButtonExitText.text = "Выход";

            ButtonLangText.text = "Eng";
        }
    }
	// Use this for initialization
	void Start () {
        setUI_lang();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
