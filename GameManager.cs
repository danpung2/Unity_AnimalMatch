using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private List<Card> _allCards;
    private Card _flippedCard;
    private bool _isFlipping = false;

    [SerializeField] private Slider timeoutSlider;
    [SerializeField] private float timeLimit = 60f;
    private float currentTime;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Board board = FindObjectOfType<Board>();
        _allCards = board.GetCards();

        currentTime = timeLimit;
        StartCoroutine(nameof(FlipAllCardsRoutine));
        
    }

    IEnumerator FlipAllCardsRoutine()
    {
        _isFlipping = true;
        
        yield return new WaitForSeconds(0.5f);
        FlipAllCards();
        yield return new WaitForSeconds(3f);
        FlipAllCards();
        yield return new WaitForSeconds(0.5f);
        
        _isFlipping = false;

        yield return StartCoroutine(nameof(CountDownTimerRoutine));
    }

    IEnumerator CountDownTimerRoutine()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeoutSlider.value = currentTime / timeLimit;
            yield return null;
        }

        GameOver(false);
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
        if (_isFlipping)
        {
            return;
        }
        
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
        _isFlipping = true;
        
        if (targetCard.cardId == flippedCard.cardId)
        {
            targetCard.SetMatched();
            flippedCard.SetMatched();
        }
        else
        {
            yield return new WaitForSeconds(1f);
            
            targetCard.FlipCard();
            flippedCard.FlipCard();
            
            yield return new WaitForSeconds(0.4f);
        }
        
        _isFlipping = false;
        _flippedCard = null;
    }

    void GameOver(bool success)
    {
        if (success)
        {
            
        }
    }
}
