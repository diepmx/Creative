using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonGroupSprite : MonoBehaviour
{
    [System.Serializable]
    public class ButtonItem
    {
        public Button button;
        public Image image;
    }

    public List<ButtonItem> buttons;
    public Sprite spriteNormal;   // sprite1 (chưa chọn)
    public Sprite spriteActive;   // sprite2 (đang chọn)
    public int defaultIndex = 0;  // nút nào được highlight ban đầu

    private ButtonItem currentActive;

    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            var item = buttons[i];

            if (!item.image) item.image = item.button.GetComponent<Image>();

            // Reset sprite
            item.image.sprite = spriteNormal;

            // Gắn sự kiện click
            int index = i; // tránh capture bug
            item.button.onClick.AddListener(() => OnButtonClicked(buttons[index]));
        }

        // Chọn nút mặc định
        if (buttons.Count > 0 && defaultIndex >= 0 && defaultIndex < buttons.Count)
        {
            OnButtonClicked(buttons[defaultIndex]);
        }
    }

    void OnButtonClicked(ButtonItem clicked)
    {
        if (currentActive != null)
        {
            currentActive.image.sprite = spriteNormal;
        }

        clicked.image.sprite = spriteActive;
        currentActive = clicked;
    }
}
