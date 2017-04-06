using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour {

    public GameObject card;
    public GameObject textHint;
    public GameObject textAbout;
    public GameObject deck;
    public GameObject camera;

    BoxCollider2D collider;
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
    public static App Instance() { if (pInst == null) pInst = new App(); return pInst; }
    int isAboutShown = 0;
    int isEndGameState;
    void Awake()
    {
        //called on appication init
        pInst = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //called on start this script
       
        cardModel = card.GetComponent<CardModel>();
        cardFlipper = card.GetComponent<CardFlipper>();
        textHintArea = textHint.GetComponent<TextMesh>();
        collider = GetComponent<BoxCollider2D>();
        isEndGameState = 0;
        collider.size = new Vector2(0, 0);
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
        return globalVars.getAskString() + globalVars.getObjectName(wantAnswerId) + " ?";
    }
    public void tryAnswer(int _id)
    {
        Debug.Log("onTryAnswer called.  "+_id);


        if (wantAnswerId == globalVars.cardInfos[_id].id)
        {
            textHintArea.text = globalVars.getSuccessString();
            doWinAnimation();

            isEndGameState = 1;
            collider.size = new Vector2(100, 100);

        }
        else
        {
            textHintArea.text = globalVars.getFailString() + getquestionStr();

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

    private void doStartNewGame()
    {
        isEndGameState = 0;
        collider.size = new Vector2(0, 0);
        stopWinAnimation();

        DeckModel thisDeckModel = deck.GetComponent<DeckModel>();
        DeckView thisDeckView = deck.GetComponent<DeckView>();
        thisDeckModel.Shuffle();
        thisDeckView.ShowCards();


    }
    private void OnMouseDown()
    {
        long a = 1;
        Debug.Log("OnMouseDown - on bg ");
        if (isEndGameState > 0)
        {
            doStartNewGame();

        }
    }

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
