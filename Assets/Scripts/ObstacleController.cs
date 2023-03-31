using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private CommonEnum.ObstacleType _type;
    private float _duration = 5f;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _endPoint;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.OnStart(() =>
        {
            transform.position = _spawnPoint.position;
            _duration = Random.Range(5f, 10f);
        });
        sequence.Append(transform.DOMove(_endPoint.position, _duration));
        sequence.SetLoops(-1);
    }
}
