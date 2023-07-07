using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cardRenderer;
    [SerializeField] private Sprite animalSprite;
    [SerializeField] private Sprite backSprite;

    private bool _isFlipped;
    private bool _isFlipping;

    public int cardId;
    
    public void SetCardId(int id)
    {
        this.cardId = id;
    }
    public void SetAnimalSprite(Sprite sprite)
    {
        this.animalSprite = sprite;
    }
    
    public void FlipCard()
    {
        _isFlipping = true;
        
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);

        transform.DOScale(targetScale, 0.2f).OnComplete(() =>
        {
            _isFlipped = !_isFlipped;
        
            if (_isFlipped)
            {
                cardRenderer.sprite = animalSprite;
            }
            else
            {
                cardRenderer.sprite = backSprite;
            }

            transform.DOScale(originalScale, 0.2f).OnComplete(() =>
            {
                _isFlipping = false;
            });
        });

        
    }
    
    void OnMouseDown()
    {
        if (!_isFlipping)
        {
            GameManager.Instance.CardClicked(this);
        }
    }
    
}
