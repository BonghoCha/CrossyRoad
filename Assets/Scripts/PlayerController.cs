using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
                _root.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                nextPosition += new Vector3(0, 0, 1); 
                break;
            }
            case CommonEnum.PlayerDirection.BACK:
            {
                _root.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                nextPosition += new Vector3(0, 0, -1);
                break;
            }
            case CommonEnum.PlayerDirection.LEFT:
            {
                _root.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                nextPosition += new Vector3(-1, 0, 0);
                break;
            }
            case CommonEnum.PlayerDirection.RIGHT:
            {
                _root.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                nextPosition += new Vector3(1, 0, 0);
                break;
            }
        }

        _player.DOComplete();
        _player.DOMove(nextPosition, 0.25f).OnStart(() =>
        {
            _animator.Play("Jump W Root");
        }).OnComplete(() =>
        {
            isMoving = false;
        });
    }
}
