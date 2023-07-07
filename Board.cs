using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Sprite[] cardSprites;

    private List<int> cardIdList = new List<int>();

    void Start()
    {
        GenerateCardId();
        InitBoard();
    }

    void GenerateCardId()
    {
        for (int i = 0; i < cardSprites.Length; i++)
        {
            cardIdList.Add(i);
            cardIdList.Add(i);
        }
    }

    void InitBoard()
    {
        float spaceY = 1.8f;
        float spaceX = 1.3f;
            
        int rowCount = 5;
        int colCount = 4;

        int cardIndex = 0;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                float posX = (col - (int)(colCount / 2)) * spaceX + (spaceX / 2);
                float posY = (row - (int)(rowCount / 2)) * spaceY;
                
                Vector3 pos = new Vector3( posX, posY, 0f);
                GameObject cardObject = Instantiate(cardPrefab, pos, Quaternion.identity);
                
                Card card = cardObject.GetComponent<Card>();
                int cardId = cardIdList[cardIndex++];
                
                card.SetCardId(cardIdList[cardId]);
                card.SetAnimalSprite(cardSprites[cardId]);

            }
        }
    }
}
