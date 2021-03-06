﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour {
   // public Sprite[] faces;
    public Sprite cardBack ;
    public Sprite cardFace ;
    public int cardIndex = -1; //faces[cardIndex]
    SpriteRenderer spriteRenderer;
    public float rectSizeX = 2.0f;
    public float rectSizeY = 2.0f;
    public void ToggleFace(bool showFace)
    {
        Vector2 beforeSizeXX = spriteRenderer.bounds.size;
     Vector2 beforeSize = new Vector2(rectSizeX, rectSizeY); //= ren.transform.renderer.bounds.size;


        if (showFace)
        {
            //showFace
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            //showBack
            spriteRenderer.sprite = cardBack;

        }
        if (spriteRenderer.sprite == null)
        {
            long a = 1;

        }
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        Vector3 scaleMultiplier = new Vector3(beforeSize.x / spriteSize.x, beforeSize.y / spriteSize.y);
        spriteRenderer.transform.localScale = new Vector3(spriteRenderer.transform.localScale.x * scaleMultiplier.x, spriteRenderer.transform.localScale.y * scaleMultiplier.y);
    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    // Use this for initialization
    void Start () {
        cardBack = App.Instance().getCardBack();
        cardFace = App.Instance().getCardBack();

    }
	
	// Update is called once per frame
	void Update () {

        bool isDragActivity = (Input.touchCount > 0) || (Input.GetMouseButtonDown(0)) || (Input.GetMouseButtonUp(0));

        if (isDragActivity)
        {
            //do as press
          //  if (App.Instance() != null)
          //      App.Instance().tryAnswer(cardIndex);
        }


    }
    void OnMouseDown()
    {
       // Debug.Log("click on card id = " + cardIndex);


        if (App.Instance() != null)
            App.Instance().tryAnswer(cardIndex);
    

    //ToggleFace(false);

    }
    void OnMouseEnter()
    {
        if (Input.GetMouseButton(0) )
        {
            if (App.Instance() != null)
                App.Instance().tryAnswer(cardIndex);
        }
    }
    public void setCardId(int _id)
    {

        //Debug.Log(AssetDatabase.GetAssetPath(spriteRenderer.sprite));



        cardIndex = _id;
        if (cardIndex >= globalVars.cardFacesCount || cardIndex < 0)
            cardIndex = 0;
      //  cardFace = AssetDatabase.LoadAssetAtPath<Sprite>(globalVars.cardInfos[cardIndex].spriteName);
        cardFace = App.Instance().getCardFace(globalVars.cardInfos[cardIndex].id);
        ToggleFace(true);
    }

    public void setImg(Vector3 _pos, Vector2 _size,Sprite _img)
    {
        cardFace = _img;
        spriteRenderer.sprite = cardFace;
     
        Vector2 beforeSize = _size;
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        Vector3 scaleMultiplier = new Vector3(beforeSize.x / spriteSize.x, beforeSize.y / spriteSize.y);
        if (scaleMultiplier.x < scaleMultiplier.y)
            scaleMultiplier.y = scaleMultiplier.x;
        else
            scaleMultiplier.x = scaleMultiplier.y;
        Vector2 wantSize;
        wantSize.x =  beforeSize.x / scaleMultiplier.x ;
        wantSize.y = beforeSize.y / scaleMultiplier.y;
        //spriteRenderer.transform.localScale = new Vector3(spriteRenderer.transform.localScale.x * scaleMultiplier.x, spriteRenderer.transform.localScale.y * scaleMultiplier.y);
        //spriteRenderer.transform.position = _pos;
        this.transform.localScale = new Vector3(spriteRenderer.transform.localScale.x * scaleMultiplier.x, spriteRenderer.transform.localScale.y * scaleMultiplier.y);
        this.transform.position = _pos;

        this.GetComponent<BoxCollider2D>().size = wantSize;


    }
}

   
