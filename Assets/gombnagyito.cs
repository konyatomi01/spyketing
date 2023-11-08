using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonSoundEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AudioClip hoverSound;
    public AudioClip clickSound;
    private AudioSource audioSource;
    private Button button;
    private TextMeshProUGUI buttonText;
    private Vector3 originalScale;
    private bool isHovered = false;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        
        button = GetComponent<Button>();

        
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

        
        originalScale = buttonText.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        isHovered = true;
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }

        
        buttonText.transform.localScale = originalScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        isHovered = false;
        buttonText.transform.localScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (isHovered)
        {
            buttonText.transform.localScale = originalScale * 1.2f;
        }
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
