using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine;

public class SpineUIPlayOnClick : MonoBehaviour
{
    [Header("Refs")]
    public SkeletonGraphic skeleton;
    public Button triggerButton;

    [Header("Anim")]
    public string animationName = "animation";

    void Awake()
    {
        if (!skeleton) skeleton = GetComponent<SkeletonGraphic>();
        if (triggerButton) triggerButton.onClick.AddListener(Play);
        gameObject.SetActive(false); // ban đầu ẩn
    }

    public void Play()
    {
        gameObject.SetActive(true); // bật khi chạy
        var state = skeleton.AnimationState;
        state.ClearTrack(0);

        TrackEntry entry = state.SetAnimation(0, animationName, false);
        entry.Complete += OnAnimationComplete;
    }

    private void OnAnimationComplete(TrackEntry trackEntry)
    {
        gameObject.SetActive(false); // tắt khi xong
    }
}
