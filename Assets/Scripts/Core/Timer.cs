﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assignment.Core
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] float duration = 1f;
        public event UnityAction OnTimerFinish;

        public void SetDuration(float duration) => this.duration = duration;
        public void StartTimer() => StartCoroutine(StartTimerCoroutine(duration));

        public void EndEarly()
        {
            OnTimerFinish?.Invoke();
            StopAllCoroutines();
        }

        private IEnumerator StartTimerCoroutine(float duration)
        {
            yield return new WaitForSeconds(duration);

            OnTimerFinish?.Invoke();
        }
    }
}