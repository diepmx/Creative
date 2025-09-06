using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [Header("Image hiển thị nhân vật")]
    public Image characterImage;

    [Header("Sprite theo size")]
    public Sprite sizeS;
    public Sprite sizeM;
    public Sprite sizeL;
    public Sprite sizeXL;

    // Hàm đổi size
    public void SetSize(string size)
    {
        switch (size)
        {
            case "S":
                characterImage.sprite = sizeS;
                break;
            case "M":
                characterImage.sprite = sizeM;
                break;
            case "L":
                characterImage.sprite = sizeL;
                break;
            case "XL":
                characterImage.sprite = sizeXL;
                break;
        }
    }
}
