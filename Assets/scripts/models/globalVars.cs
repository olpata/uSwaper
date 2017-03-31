using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class globalVars : MonoBehaviour {
    //call like globalVars.Instance.cardFacesCount
  
    public static List<CardInfo> cardInfos = new List<CardInfo>
    {
        new CardInfo("monkey","Assets/resources/cardFaces/card_0.png",0)
        ,new CardInfo("dog","Assets/resources/cardFaces/card_1.png",1)
        ,new CardInfo("tiger","Assets/resources/cardFaces/card_2.png",2)
        ,new CardInfo("zebra","Assets/resources/cardFaces/card_3.png",3)
        ,new CardInfo("batterfly","Assets/resources/cardFaces/card_4.png",4)
        ,new CardInfo("dolphin","Assets/resources/cardFaces/card_5.png",5)
        ,new CardInfo("elefant","Assets/resources/cardFaces/card_6.png",6)
        ,new CardInfo("hippo","Assets/resources/cardFaces/card_7.png",7)
        ,new CardInfo("panda","Assets/resources/cardFaces/card_8.png",8)
        ,new CardInfo("parrot","Assets/resources/cardFaces/card_9.png",9)
        ,new CardInfo("turtle","Assets/resources/cardFaces/card_10.png",10)
    };
    public static int cardFacesCount = cardInfos.Count;
    public static string cardBackSprite = "Assets/resources/cardBack_2.png";
    public static List<string> winAnimations = new List<string>
    {
        "Assets/resources/winVariants/panda_0.gif"
        ,"Assets/resources/winVariants/panda_1.gif"
    };
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public struct CardInfo
{
    public string name;
    public string spriteName;
    public int id;
    public CardInfo(string _name,string _spriteName,int _id)
    {
        this.name = _name;
        this.spriteName = _spriteName;
        this.id = _id;
    }
}
