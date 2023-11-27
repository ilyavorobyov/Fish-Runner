using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthImage : MonoBehaviour
{
    [SerializeField] private Sprite _imageFullHealth;
    [SerializeField] private Sprite _imageEmptyHealth;

    private Image _imageHealth;

    private void Awake()
    {
        _imageHealth = GetComponent<Image>();
    }

    public void SetFullHealth()
    {
        _imageHealth.sprite = _imageFullHealth;
    }

    public void SetEmptyHealth()
    {
        _imageHealth.sprite = _imageEmptyHealth;
    }
}