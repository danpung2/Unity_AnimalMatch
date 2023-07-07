using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<Card> _allCards;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Board board = FindObjectOfType<Board>();
        _allCards = board.GetCards();

        StartCoroutine(nameof(FlipAllCardsRoutine));
    }

    IEnumerator FlipAllCardsRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        FlipAllCards();
        yield return new WaitForSeconds(3f);
        FlipAllCards();
        yield return new WaitForSeconds(0.5f);
    }

    void FlipAllCards()
    {
        foreach (Card card in _allCards)
        {
            card.FlipCard();
        }
    }

}
