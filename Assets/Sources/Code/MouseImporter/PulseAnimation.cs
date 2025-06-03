﻿using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class PulseAnimation
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float pulseScale = 1.03f; // Насколько увеличивается объект
    [SerializeField] private float pulseDuration = 0.8f; // Длительность одного пульса

    private int pulseLoops = -1; // Количество пульсаций (-1 для бесконечного повторения)
    private Ease easeType = Ease.InOutSine; // Тип анимации
    private Tween _tween;
    private Vector3 originalScale;
        
    public Transform Transform => _transform;

    public void Play()
    {
        // Запоминаем исходный масштаб
        originalScale = _transform.localScale;

        // Создаем анимацию пульсации
        _tween = _transform.DOScale(originalScale * pulseScale, pulseDuration)
            .SetEase(easeType) // Тип плавности анимации
            .SetLoops(pulseLoops, LoopType.Yoyo) // Бесконечное повторение с возвратом
            .OnComplete(() => _transform.localScale = originalScale); // Возврат к исходному масштабу
    }

    public void Stop()
    {
        _tween.Kill();
    }
}
