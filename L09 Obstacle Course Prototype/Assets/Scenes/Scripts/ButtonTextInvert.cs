using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CustomNamespace
{
    [RequireComponent(typeof(Button))]
    public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Text txt;
        private Button btn;
        private Image btnImage;
        private ColorBlock buttonColors;

        void Start()
        {
            txt = GetComponentInChildren<Text>();
            btn = GetComponent<Button>();
            btnImage = btn.GetComponent<Image>();
            buttonColors = btn.colors;
            UpdateTextColor();
        }

        void Update()
        {
            UpdateTextColor();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (btn.interactable)
            {
                btnImage.color = buttonColors.highlightedColor;
                txt.color = GetInverseColor(buttonColors.highlightedColor);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (btn.interactable)
            {
                btnImage.color = buttonColors.pressedColor;
                txt.color = GetInverseColor(buttonColors.pressedColor);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (btn.interactable)
            {
                btnImage.color = buttonColors.highlightedColor;
                txt.color = GetInverseColor(buttonColors.highlightedColor);
            }
            else
            {
                btnImage.color = buttonColors.normalColor;
                txt.color = GetInverseColor(buttonColors.normalColor);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (btn.interactable)
            {
                btnImage.color = buttonColors.normalColor;
                txt.color = GetInverseColor(buttonColors.normalColor);
            }
        }

        // Method to update the text color based on the current button state
        private void UpdateTextColor()
        {
            if (!btn || !btnImage) return;

            if (btn.interactable)
            {
                if (btnImage.color == buttonColors.highlightedColor)
                {
                    txt.color = GetInverseColor(buttonColors.highlightedColor);
                }
                else if (btnImage.color == buttonColors.pressedColor)
                {
                    txt.color = GetInverseColor(buttonColors.pressedColor);
                }
                else
                {
                    txt.color = GetInverseColor(buttonColors.normalColor);
                }
            }
            else
            {
                txt.color = GetInverseColor(buttonColors.disabledColor);
            }
        }

        // Method to get the inverse color
        private Color GetInverseColor(Color color)
        {
            return new Color(1.0f - color.r, 1.0f - color.g, 1.0f - color.b, color.a);
        }
    }
}
