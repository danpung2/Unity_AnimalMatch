using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<Card> _allCards;
    private Card _flippedCard;
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

    public void CardClicked(Card card)
    {
        card.FlipCard();

        if (_flippedCard == null)
        {
            _flippedCard = card;
        }
        else
        {
            StartCoroutine(CheckMatchRoutine(card, _flippedCard));
        }
    }

    IEnumerator CheckMatchRoutine(Card targetCard, Card flippedCard)
    {
        if (targetCard.cardId == flippedCard.cardId)
        {
            
        }
        else
        {
            yield return new WaitForSeconds(1f);
            
            targetCard.FlipCard();
            flippedCard.FlipCard();
            
            yield return new WaitForSeconds(0.4f);
        }
        
        _flippedCard = null;
    }
}
