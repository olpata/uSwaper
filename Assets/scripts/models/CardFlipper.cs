using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlipper : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    CardModel cardModel;
    public AnimationCurve scaleCurve;
    public float duration = 0.5f;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cardModel = GetComponent<CardModel>();
    }

    IEnumerator Flip(Sprite startImg, Sprite endImg, int cardIndex)
    {
        spriteRenderer.sprite = startImg;
        float time = 0f;
        while (time <= 1f)
        {
            float scale = scaleCurve.Evaluate(time);
            time = time + Time.deltaTime / duration;

            Vector3 localScale = transform.localScale;
            localScale.x = scale;
            transform.localScale = localScale;

            if (time >= 0.5f)
            {
                spriteRenderer.sprite = endImg;
            }

            yield return new WaitForFixedUpdate();
        }

        if (cardIndex == -1)
        {
            cardModel.ToggleFace(false);
        }
        else
        {
            cardModel.cardIndex = cardIndex;
            cardModel.ToggleFace(true);
        }
    }
    public void FlipCard(Sprite startImg,Sprite endImg, int cardIndex)
    {
        StopCoroutine(Flip(startImg, endImg, cardIndex));
        StartCoroutine(Flip(startImg, endImg, cardIndex));

    }
    // Update is called once per frame
    void Update () {
		
	}
}
