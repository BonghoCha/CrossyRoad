using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerController _playerController;
    
    private Vector2 _touchPoint;
    [Range(0f, 100f)] private readonly float _minMagnitude = 50f;

    private void Start()
    {
        if (_playerController == null)
        {
            _playerController = FindObjectOfType<PlayerController>();
        } 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPoint = eventData.position;
        _playerController.transform.DOScale(CommonValue.PlayerPressedScale, 0.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var touchMag = (_touchPoint - eventData.position).magnitude;
        var touchDir = (_touchPoint - eventData.position).normalized;
        
        var direction = CommonEnum.PlayerDirection.FRONT;

        // 일정 거리를 드래그했을 경우
        if (touchMag > _minMagnitude)
        {
            if (Mathf.Abs(touchDir.x) > Mathf.Abs(touchDir.y))
            {
                if (touchDir.x > 0) direction = CommonEnum.PlayerDirection.LEFT;
                else direction = CommonEnum.PlayerDirection.RIGHT;
            }
            else
            {
                if (touchDir.y > 0) direction = CommonEnum.PlayerDirection.BACK;
                else direction = CommonEnum.PlayerDirection.FRONT;
            }
        }

        _playerController.Move(direction);
    }
}
