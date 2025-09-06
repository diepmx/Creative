using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchEffectManager : MonoBehaviour
{
    [SerializeField] private SkeletonGraphic m_uiEffectPrefab;
    [SerializeField] private RectTransform m_canvasTransform;
    [SerializeField] private Camera m_mainCamera;
    private void Awake()
    {
        if (m_mainCamera == null) m_mainCamera = Camera.main;

        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick(Input.mousePosition);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleClick(Input.GetTouch(0).position);
        }
    }
    void HandleClick(Vector3 screenPos)
    {
        if (m_mainCamera == null) m_mainCamera = Camera.main;
        if (m_uiEffectPrefab != null && m_canvasTransform != null)
        {

            var fxUI = Instantiate(m_uiEffectPrefab, m_canvasTransform);
            fxUI.transform.position = screenPos;

            fxUI.AnimationState.SetAnimation(0, "animation", false);
            float duration = fxUI.Skeleton.Data.FindAnimation("animation").Duration;
            Destroy(fxUI.gameObject, duration);
        }
    }
}
