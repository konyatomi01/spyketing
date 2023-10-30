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
        // Get the AudioSource component from the button's GameObject.
        audioSource = GetComponent<AudioSource>();

        // Get the Button component.
        button = GetComponent<Button>();

        // Get the TMP Text component within the button.
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

        // Store the original scale of the TMP text.
        originalScale = buttonText.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Set the hover flag and play the hover sound when the mouse hovers over the button.
        isHovered = true;
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }

        // Enlarge the TMP text when the mouse hovers over the button.
        buttonText.transform.localScale = originalScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Reset the TMP text to its original size when the mouse exits the button.
        isHovered = false;
        buttonText.transform.localScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Play the click sound when the button is clicked, and handle the hover effect.
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
