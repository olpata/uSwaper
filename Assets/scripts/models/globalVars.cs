using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class globalVars : MonoBehaviour {
    //call like globalVars.Instance.cardFacesCount
  
    public static List<CardInfo> cardInfos = new List<CardInfo>
    {
        new CardInfo("monkey","обезьяна","Assets/resources/cardFaces/card_0.png",0)
        ,new CardInfo("dog","собака","Assets/resources/cardFaces/card_1.png",1)
        ,new CardInfo("tiger","тигр","Assets/resources/cardFaces/card_2.png",2)
        ,new CardInfo("zebra","зебра","Assets/resources/cardFaces/card_3.png",3)
        ,new CardInfo("batterfly","бабочка","Assets/resources/cardFaces/card_4.png",4)
        ,new CardInfo("dolphin","дельфин","Assets/resources/cardFaces/card_5.png",5)
        ,new CardInfo("elefant","слон","Assets/resources/cardFaces/card_6.png",6)
        ,new CardInfo("hippo","бегемот","Assets/resources/cardFaces/card_7.png",7)
        ,new CardInfo("panda","панда","Assets/resources/cardFaces/card_8.png",8)
        ,new CardInfo("parrot","попугай","Assets/resources/cardFaces/card_9.png",9)
        ,new CardInfo("turtle","черепаха","Assets/resources/cardFaces/card_10.png",10)
    };
    public static int cardFacesCount = cardInfos.Count;
    public static string cardBackSprite = "Assets/resources/cardBack_2.png";
    public static List<string> winAnimations = new List<string>
    {
        "Assets/resources/winVariants/panda_0.gif"
        ,"Assets/resources/winVariants/panda_1.gif"
    };
    public static int LanguageId = 1; //0 - eng / 1-ru

   public static string getAskString()
    {
        if (LanguageId == 0)
        {
            return "Where is ";
        }
        else
        {
            return "Где ";
        }
    }
    public static string getFailString()
    {
        if (LanguageId == 0)
        {
            return "No no no.";
        }
        else
        {
            return "Не не не.";
        }
    }
    public static string getSuccessString()
    {
        if (LanguageId == 0)
        {
            return "Good job. Let's play again. ";
        }
        else
        {
            return "Правильно. Давай снова.";
        }
    }
    public static string getObjectName(int _cardId)
    {
        if (LanguageId == 0)
        {
            return globalVars.cardInfos[_cardId].nameEng;
        }
        else
        {
            return globalVars.cardInfos[_cardId].nameRu;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public struct CardInfo
{
    public string nameEng;
    public string nameRu;
    public string spriteName;
    public int id;
    public CardInfo(string _nameEng, string _nameRu, string _spriteName,int _id)
    {
        this.nameEng = _nameEng;
        this.nameRu = _nameRu;
        this.spriteName = _spriteName;
        this.id = _id;
    }
}
