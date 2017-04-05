using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class globalVars : MonoBehaviour {
    //call like globalVars.Instance.cardFacesCount
  
    public static List<CardInfo> cardInfos = new List<CardInfo>
    {
        new CardInfo("bear","медведь","Assets/resources/animals/card_0.png",0)
        ,new CardInfo("butterfly","бабочка","Assets/resources/cardFaces/card_1.png",1)
        ,new CardInfo("cammel","верблюд","Assets/resources/cardFaces/card_2.png",2)
        ,new CardInfo("cat","кот","Assets/resources/cardFaces/card_3.png",3)
        ,new CardInfo("chicken","курица","Assets/resources/cardFaces/card_4.png",4)
        ,new CardInfo("cow","корова","Assets/resources/cardFaces/card_5.png",5)
        ,new CardInfo("deer","олень","Assets/resources/cardFaces/card_6.png",6)
        ,new CardInfo("dog","собака","Assets/resources/cardFaces/card_7.png",7)
        ,new CardInfo("duck","утка","Assets/resources/cardFaces/card_8.png",8)
        ,new CardInfo("elefant","слон","Assets/resources/cardFaces/card_9.png",9)
        ,new CardInfo("fox","лиса","Assets/resources/cardFaces/card_10.png",10)
        ,new CardInfo("giraffe","жираф","Assets/resources/cardFaces/card_10.png",11)
        ,new CardInfo("goose","гусь","Assets/resources/cardFaces/card_10.png",12)
        ,new CardInfo("hedgehog","ёж","Assets/resources/cardFaces/card_10.png",13)
        ,new CardInfo("hippo","бегемот","Assets/resources/cardFaces/card_10.png",14)
        ,new CardInfo("horse","лошадь","Assets/resources/cardFaces/card_10.png",15)
        ,new CardInfo("lion","лев","Assets/resources/cardFaces/card_10.png",16)
        ,new CardInfo("monkey","обезьяна","Assets/resources/cardFaces/card_10.png",17)
        ,new CardInfo("mouse","мышь","Assets/resources/cardFaces/card_10.png",18)
        ,new CardInfo("owl","сова","Assets/resources/cardFaces/card_10.png",19)
        ,new CardInfo("panda","панда","Assets/resources/cardFaces/card_10.png",20)
        ,new CardInfo("parrot","попугай","Assets/resources/cardFaces/card_10.png",21)
        ,new CardInfo("penguin","пингвин","Assets/resources/cardFaces/card_10.png",22)
        ,new CardInfo("pig","свинья","Assets/resources/cardFaces/card_10.png",23)
        ,new CardInfo("rabbit","заяц","Assets/resources/cardFaces/card_10.png",24)
        ,new CardInfo("sheep","овца","Assets/resources/cardFaces/card_10.png",25)
        ,new CardInfo("squirrel","белка","Assets/resources/cardFaces/card_10.png",26)
        ,new CardInfo("tiger","тигр","Assets/resources/cardFaces/card_10.png",27)
        ,new CardInfo("turtle","черепаха","Assets/resources/cardFaces/card_10.png",28)
        ,new CardInfo("wolf","волк","Assets/resources/cardFaces/card_10.png",29)
        ,new CardInfo("zebra","зебра","Assets/resources/cardFaces/card_10.png",30)
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
