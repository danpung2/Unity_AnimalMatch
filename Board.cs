using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;

    void Start()
    {
        InitBoard();
    }

    void InitBoard()
    {
        float spaceY = 1.8f;
        // float spaceX = 
            
        int rowCount = 5;
        int colCount = 4;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                float posY = (row - (int)(rowCount / 2)) * spaceY;
                Vector3 pos = new Vector3( 0f, posY, 0f);
                Instantiate(cardPrefab, pos, Quaternion.identity);
            }
        }
    }
}
