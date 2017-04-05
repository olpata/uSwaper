using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GalleryModel : MonoBehaviour {
    int currentImgId = 0;
    int nowShownImgId = 0;
    public GameObject cardPrefab;
    GameObject cardCurrentView;
    public GameObject textHint;
    public List<Sprite> cardFaces;
    Vector2 cardLocalScaleToUse = new Vector2(6, 6);
    // Use this for initialization
    void Start () {
        dragDistance = Screen.height * 15 / 100;
        maxSwipeTime = 10;
        cardCurrentView = (GameObject)Instantiate(cardPrefab);
        cardCurrentView.transform.position = new Vector2(0, 0);
        cardCurrentView.transform.localScale = cardLocalScaleToUse;
        currentImgId = 0;
        nowShownImgId = 0;
        updateView();
    }
    void updateView()
    {
        //do change view from nowShownImgId 
        //to currentImgId
        TextMesh textOutput = textHint.GetComponent<TextMesh>();
        textOutput.text = globalVars.getObjectName(currentImgId);

        CardModel cardModel = cardCurrentView.GetComponent<CardModel>();
        cardCurrentView.transform.localScale = cardLocalScaleToUse;
        cardModel.setImg(new Vector3(0,0,0),new Vector2(1,1),cardFaces[currentImgId]);
        nowShownImgId = currentImgId;
    }
    public void goToNextImg()
    {
        currentImgId++;
        if (currentImgId >= globalVars.cardInfos.Count)
        {
            currentImgId = 0;
        }
        updateView();
    }
    public void goToPrevImg()
    {
        currentImgId--;
        if (currentImgId < 0)
        {
            currentImgId = globalVars.cardInfos.Count - 1;
        }
        updateView();
    }

    private Vector3 swipeStartPos;   //First touch position
    private Vector3 swipeEndPos;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    float maxSwipeTime;
    float swipeStartTime;
    float swipeEndTime;
    Vector3 swipeDist;


    void swipe(Vector3 _swipeVector)
    {
        //check if the drag is vertical or horizontal
        if (Mathf.Abs(_swipeVector.x) > Mathf.Abs(_swipeVector.y))
        {   //If the horizontal movement is greater than the vertical movement...
            if (_swipeVector.x > 0)  //If the movement was to the right)
            {   //Right swipe
                Debug.Log("Right Swipe");
            }
            else
            {   //Left swipe
                Debug.Log("Left Swipe");
            }
        }
        else
        {   //the vertical movement is greater than the horizontal movement
            if (_swipeVector.y > 0)  //If the movement was up
            {   //Up swipe
                Debug.Log("Up Swipe");
            }
            else
            {   //Down swipe
                Debug.Log("Down Swipe");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount > 0) { }
        //if (Input.GetMouseButton(0))

        //if (touch.phase == TouchPhase.Began) { }
        ///if (Input.GetMouseButtonDown()) { }

        //else if (touch.phase == TouchPhase.Ended) { }
        //else if (Input.GetMouseButtonUp()) { }


        if (Input.touchCount > 0)
        {
            Debug.Log("touchCount event");
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                swipeStartPos = touch.position;
                swipeEndPos = touch.position;
                swipeStartTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                swipeEndPos = touch.position;
                swipeEndTime = Time.time;
                float swipeDist = (swipeEndPos - swipeStartPos).magnitude;
                float swipeTime = swipeEndTime - swipeStartTime;
                Vector3 swipeVector = swipeEndPos - swipeStartPos;
                if (swipeDist > dragDistance && swipeTime < maxSwipeTime)
                {
                    swipe(swipeVector);
                    //It's a drag
               
                }
                else
                {
                    swipeEndPos = touch.position;
                    swipeEndTime = Time.time;
                }
            }
            


        }

        
    }
}
