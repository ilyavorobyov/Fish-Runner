using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Shield : MonoBehaviour
{
    [SerializeField] private List<Sprite> _strengthSprites;
    
    private SpriteRenderer _spriteRenderer;
    private Sprite _defaultSprite;
    private int _strength;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _strength = 3;
        _defaultSprite = _strengthSprites[_strength - 1];
        _spriteRenderer.sprite = _defaultSprite;
    }

    private void OnDisable()
    {
        
    }

    public void TakeDamage()
    {
        _strength--;

        if(_strength > 0)
        {
            _defaultSprite = _strengthSprites[_strength - 1];
            _spriteRenderer.sprite = _defaultSprite;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
