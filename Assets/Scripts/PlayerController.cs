using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _root;
    [SerializeField] private Animator _animator;

    private bool isMoving = false;

    public void Move(CommonEnum.PlayerDirection direction)
    {
        if (isMoving) return;
        isMoving = true;
        
        var nextPosition = _player.transform.position;
        switch (direction)
        {
            case CommonEnum.PlayerDirection.FRONT:
            {
                _root.rotation = CommonValue.PlayerFrontRotation;
                nextPosition += CommonValue.PlayerFrontBackVector; 
                break;
            }
            case CommonEnum.PlayerDirection.BACK:
            {
                _root.rotation = CommonValue.PlayerBackRotation;
                nextPosition -= CommonValue.PlayerFrontBackVector;
                break;
            }
            case CommonEnum.PlayerDirection.LEFT:
            {
                _root.rotation = CommonValue.PlayerLeftRotation;
                nextPosition -= CommonValue.PlayerLeftRightVector;
                break;
            }
            case CommonEnum.PlayerDirection.RIGHT:
            {
                _root.rotation = CommonValue.PlayerRightRotation;
                nextPosition += CommonValue.PlayerLeftRightVector;
                break;
            }
        }

        _player.DOComplete();
        _player.transform.DOScale(CommonValue.PlayerOriginalScale, 0.1f);
        _player.DOMove(nextPosition, 0.25f).OnStart(() =>
        {
            _animator.Play("Jump W Root");
        }).OnComplete(() =>
        {
            isMoving = false;
        });
    }

    public void Die()
    {
        _player.DOComplete();
        _player.DOScale(new Vector3(1f, 0.1f, 1f), 0.1f);
    }
}
