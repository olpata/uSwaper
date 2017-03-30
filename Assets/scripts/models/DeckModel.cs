using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckModel : MonoBehaviour {
    //cardIndex 0..51
    List<int> cards;
    public int elemCount = 6;
    public string wantAnswer;
    public IEnumerable<int> GetCards()
    {
         for(int i=0;i< elemCount;i++)
        {
            yield return cards[i];
        }
    }
    public void Shuffle()
    {
        if (cards == null)
        {
            cards = new List<int>();
        }
        else
        {
            cards.Clear();
        }
        for (int i = 0; i < globalVars.cardFacesCount; i++)
            cards.Add(i);

        int n = globalVars.cardFacesCount;

        while (n> 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
        long a = 1;

    }
	// Use this for initialization
	void Start () {
       

        //Shuffle();
	}

    void Awake()
    {


        Shuffle();
    }


    // Update is called once per frame
    void Update () {
		
	}
}
