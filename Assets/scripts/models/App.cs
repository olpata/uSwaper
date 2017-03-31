using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour {

    public GameObject card;
    public GameObject textHint;
    public GameObject textAbout;
    public GameObject deck;
    public GameObject camera;
    CardModel cardModel;
    CardFlipper cardFlipper;
    TextMesh textHintArea;
    int cardIndex = 0;
    int wantAnswerId = 0;
    List<GameObject> winAnimations = new List<GameObject>();
    public List<Sprite> cardFaces;
    public Sprite cardBack;
    public List<GameObject> spriteWinAnimations;
    static App pInst;
    public static App Instance() { return pInst; }
    int isAboutShown = 0;
    void Awake()
    {
        //called on appication init
        pInst = this;
    }

    // Use this for initialization
    void Start()
    {
        //called on start this script
       
        cardModel = card.GetComponent<CardModel>();
        cardFlipper = card.GetComponent<CardFlipper>();
        textHintArea = textHint.GetComponent<TextMesh>();

        Camera sceneCamObj = camera.GetComponent<Camera>();
        //GameObject sceneCamObj = GameObject.Find("SceneCamera");
        if (sceneCamObj != null)
        {
            // Should output the real dimensions of scene viewport
            Debug.Log(sceneCamObj.pixelRect);
            //textHintArea.text = sceneCamObj.pixelRect.ToString();
        }

        {
            float screenX = sceneCamObj.pixelRect.width;
            float screenY = sceneCamObj.pixelRect.height;
            //cardModel.rectSizeX = screenX / 350.0f;
           // cardModel.rectSizeY = cardModel.rectSizeX;
        }
        textAbout.transform.position = new Vector2(20, 20);


    }
    public Sprite getCardFace(int _id)
    {
        if (_id <= cardFaces.Count)
            return cardFaces[_id];
        else
            return null;
    }
    public Sprite getCardBack()
    {
       return cardBack;
    }
    public GameObject getWinAnimationSprite()
    {
        int thisId = Random.Range(0, spriteWinAnimations.Count);
        return spriteWinAnimations[thisId];
    }
    string getquestionStr()
    {
//        return "Где " + globalVars.cardInfos[wantAnswerId].name + " ?";
        return "Where is " + globalVars.cardInfos[wantAnswerId].name + " ?";
    }
    public void tryAnswer(int _id)
    {
        Debug.Log("onTryAnswer called.");


        if (wantAnswerId == globalVars.cardInfos[_id].id)
        {
//            textHintArea.text = "Правильно. Давай снова.";
            textHintArea.text = "Good job. Let's play again.";
            doWinAnimation();
        }
        else
        {
//            textHintArea.text = "Не не не." + getquestionStr();
            textHintArea.text = "No no no." + getquestionStr();

        }

    }
    public void stopWinAnimation()
    {
        foreach(GameObject thisObj in winAnimations)
        {
            //move out of scene


            thisObj.transform.position = new  Vector2(20,20);
        }
        winAnimations.Clear();
    }
    void doWinAnimation()
    {
        stopWinAnimation();
        GameObject thisAnimation = App.Instance().getWinAnimationSprite();
//        thisAnimation.transform.position = new Vector2(3.2f, 1);
        thisAnimation.transform.position = new Vector2(-2.5f, 2);

        winAnimations.Add(thisAnimation);
       
    }
    public void setWantAnswer(int _id)
    {
        Debug.Log("setWantAnswer called.");
        wantAnswerId = globalVars.cardInfos[_id].id;
        textHintArea.text = getquestionStr();


    }
    /*

    //add to any place:
    //  onTryAnswerSend += onTryAnswer;
    public delegate void TryAnswerCallback(int _answerId);
    // Event declaration
    public event TryAnswerCallback onTryAnswerSend;
    void onTryAnswer(int _answerId)
    {
        Debug.Log("onTryAnswer called.");
    }

    public void tryAnswer(int _id)
    {
        if (onTryAnswerSend != null)
            onTryAnswerSend(_id);
    }
    */

   
    void OnGUI()
    {
        /*
        //add gui to scene
        GUI.BeginGroup(new Rect(10, 10, 150, 500));

        if (GUILayout.Button("Restart"))
        {

            //deck
            DeckModel thisDeckModel = deck.GetComponent<DeckModel>();
            DeckView thisDeckView = deck.GetComponent<DeckView>();
            stopWinAnimation();
            thisDeckModel.Shuffle();
            thisDeckView.ShowCards();

        }

        if (GUILayout.Button("About"))
        {
            // cardViewScript.FlipDown();
            Debug.Log("About called.");
            if (isAboutShown == 0)
            {
                isAboutShown = 1;
                string sAbout =
                "images" + System.Environment.NewLine +
                "Author: Visualpharm site: http://all-free-download.com  link: http://all-free-download.com/free-icon/download/" + System.Environment.NewLine + "animals -icons-icons-pack_120701.html" + System.Environment.NewLine +
                "Author: Iconshock - icon sets site: http://all-free-download.com  link: http://all-free-download.com/free-icon/download/" + System.Environment.NewLine + "super-vista-animals-icons-pack_120923.html" + System.Environment.NewLine +
                "animation" + System.Environment.NewLine +
                "Author: ily4everbang site: photobucket.com link: http://media.photobucket.com/user/ily4everbang/media/FUNNY%20CUTE%20GIFS/" + System.Environment.NewLine + "21.gif.html?filters[term]=dancing%20panda&filters[primary] = images & filters[secondary] = videos & sort = 1 & o = 9" + System.Environment.NewLine +
                 "Author: ly4everbang site: photobucket.com link: http://media.photobucket.com/user/turbo73_photos/media/dancing.gif.html?" + System.Environment.NewLine + "filters[term]=dancing%20panda&filters[primary]= images & filters[secondary] = videos & sort = 1 & o = 13" + System.Environment.NewLine
                 ;

                textAbout.GetComponent<TextMesh>().text = sAbout;
                textAbout.transform.position = new Vector2(-6, -1);
            }
            else
            {
                isAboutShown = 0;
                textAbout.transform.position = new Vector2(20, 20);

            }
        }
        if (GUILayout.Button("Exit"))
        {
            Application.Quit();
        }

        GUI.EndGroup();
        */
    }


    // Update is called once per frame
    void Update () {
		
	}
}
