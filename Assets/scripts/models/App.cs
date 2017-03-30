using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour {

    public GameObject card;
    public GameObject textHint;
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
    public List<Sprite> spriteWinAnimations;
    static App pInst;
    public static App Instance() { return pInst; }

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
    public Sprite getWinAnimationSprite()
    {
        return spriteWinAnimations[0];
    }
    string getquestionStr()
    {
        return "Где " + globalVars.cardInfos[wantAnswerId].name + " ?";
    }
    public void tryAnswer(int _id)
    {
        Debug.Log("onTryAnswer called.");


        if (wantAnswerId == globalVars.cardInfos[_id].id)
        {
            textHintArea.text = "Правильно. Давай снова.";
            doWinAnimation();
        }
        else
        {
            textHintArea.text = "Не не не."+ getquestionStr();

        }

    }
    public void stopWinAnimation()
    {
        foreach(GameObject thisObj in winAnimations)
        {
            Destroy(thisObj);
        }
        winAnimations.Clear();
    }
    void doWinAnimation()
    {
        GameObject cardCopy = (GameObject)Instantiate(card);
        winAnimations.Add(cardCopy);
        cardCopy.GetComponent<CardModel>().setImg(new Vector3(5, 0, 0), new Vector2(5, 5), App.Instance().getWinAnimationSprite());
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
            cardModel.ToggleFace(false);
            cardFlipper.FlipCard(cardModel.cardFace, cardModel.cardBack, -1);
        }
        if (GUILayout.Button("Exit"))
        {
            Application.Quit();
        }

        GUI.EndGroup();
    }


    // Update is called once per frame
    void Update () {
		
	}
}
