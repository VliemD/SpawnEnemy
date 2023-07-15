using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawer : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _points;
    [SerializeField] private Enemy _template;
    [SerializeField] private int _numberOfTemplates = 5;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        int secondsWaiting = 2;
        _waitForSeconds = new WaitForSeconds(secondsWaiting);

        StartCoroutine(LoadingInScene());     
    }

    private IEnumerator LoadingInScene()
    {
        for (int i = 0; i < _numberOfTemplates; i++)
        {
            for (int j = 0; j < _points.Count; j++)
            {
                Instantiate(_template, _points[j].transform.position, Quaternion.identity);
            }

            yield return _waitForSeconds;
        }        
    }
}
