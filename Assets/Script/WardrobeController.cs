using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BodySize { S, M, L, XL }
public enum WeekDay { Mon, Tue, Wed, Thu, Fri, Sat, Sun }

[System.Serializable]
public class WeekSprites
{
    public Sprite Mon, Tue, Wed, Thu, Fri, Sat, Sun;
    public Sprite Get(WeekDay d) => d switch
    {
        WeekDay.Mon => Mon,
        WeekDay.Tue => Tue,
        WeekDay.Wed => Wed,
        WeekDay.Thu => Thu,
        WeekDay.Fri => Fri,
        WeekDay.Sat => Sat,
        _ => Sun
    };
}

[System.Serializable]
public class SizeWardrobe
{
    public BodySize size;     // S/M/L/XL
    public Sprite poseBase;   // sprite cơ thể theo size
    public WeekSprites outfits; // 7 outfit của size này
}

public class WardrobeController : MonoBehaviour
{
    [Header("Lớp nền (pose theo size)")]
    public Image characterImage;  // Image A

    [Header("Lớp outfit (đè lên)")]
    public Image outfitImage;     // Image B (trên A)

    [Header("Bảng dữ liệu 4 size")]
    public SizeWardrobe[] wardrobe; // 4 phần tử

    BodySize curSize = BodySize.S;
    WeekDay curDay = WeekDay.Mon;

    // map đúng kiểu để truy xuất cả poseBase và outfits
    Dictionary<BodySize, SizeWardrobe> map = new();

    void Awake()
    {
        foreach (var w in wardrobe)
            if (w != null) map[w.size] = w;
        Apply();
    }

    // Hook cho nút S/M/L/XL (0..3)
    public void SetSize(int sizeIndex)
    {
        curSize = (BodySize)sizeIndex;
        Apply();
    }

    // Hook cho nút Mon..Sun (0..6)
    public void SetDay(int dayIndex)
    {
        curDay = (WeekDay)dayIndex;
        Apply();
    }

    void Apply()
    {
        if (!map.TryGetValue(curSize, out var w)) return;

        if (characterImage) characterImage.sprite = w.poseBase;

        if (outfitImage)
        {
            var s = w.outfits != null ? w.outfits.Get(curDay) : null;
            outfitImage.enabled = s != null;
            outfitImage.sprite = s;
        }
    }
}
