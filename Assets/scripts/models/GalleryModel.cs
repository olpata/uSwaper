using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    // Update is called once per frame
    void Update ()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
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
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }
}
