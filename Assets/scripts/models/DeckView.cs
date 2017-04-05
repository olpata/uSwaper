using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeckModel))]
public class DeckView : MonoBehaviour {

    public Vector3 startPos;
    public float cardOfset_x = 1.1f;
    public float cardOfset_y = 1.1f;
    public int cardGrid_x = 4;

    public GameObject cardPrefab;
    DeckModel deckModel;

    List<GameObject> cards = new List<GameObject>();

   
	// Use this for initialization
	void Start () {
        deckModel = GetComponent<DeckModel>();
        ShowCards();
	}
    public void ShowCards()
    {
        if (cards.Count > 0)
        {
            foreach (GameObject thisCard in cards)
            {
                Destroy(thisCard);
            }
            cards.Clear();
        }
        int cardCount_x = 0;
        int cardCount_y = 0;
        int cardCount = 0;
        int rightAnswerPos = Random.Range(0, deckModel.elemCount);
        foreach (int i in deckModel.GetCards())
        {
            GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
            cards.Add(cardCopy);
            CardModel cardModel = cardCopy.GetComponent<CardModel>();
            float offsetX = cardOfset_x* cardModel.rectSizeX * cardCount_x;
            float offsetY = cardOfset_y * cardModel.rectSizeY * cardCount_y;
            float zlevel = 0.01f * cardCount;

            Vector3 temp = startPos + new Vector3(offsetX, -offsetY, zlevel);
            cardCopy.transform.position = temp;

            int cardFaceId = i - (globalVars.cardFacesCount * (i / globalVars.cardFacesCount));
           // int cardFaceId = deckModel.cards[i];
            if (cardCount == rightAnswerPos)
            {
                if (App.Instance() != null)
                    App.Instance().setWantAnswer(cardFaceId);

            }

            Vector2 cardLocalScaleToUse = new Vector2(3.5f, 3.5f);
            cardCopy.transform.localScale = cardLocalScaleToUse;
            cardModel.setImg(temp, new Vector2(1, 1), App.Instance().getCardFace(cardFaceId));
            cardModel.cardIndex = cardFaceId;
            //get cardModelSize:


            cardCount_x++;
            if (cardCount_x >= cardGrid_x)
            {
                cardCount_x = 0;
                cardCount_y++;
            }
            cardCount++;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
