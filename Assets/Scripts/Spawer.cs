using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _points;
    [SerializeField] private GameObject _template;
    [SerializeField] private int _numberOfTemplates;

    private List<GameObject> _templates = new List<GameObject>();

    private void Start()
    {
        AddInListTamplates();
        StartCoroutine(LoadingInScene());      
    }

    private void AddInListTamplates()
    {
        for (int i = 0; i < _numberOfTemplates; i++)
        {
            _templates.Add(_template);
        }
    }

    private IEnumerator LoadingInScene()
    {
        int secondsWaiting = 2;

        for (int i = 0; i < _templates.Count; i++)
        {
            for (int j = 0; j < _points.Count; j++)
            {
                Instantiate(_templates[i], _points[j].transform.position, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(secondsWaiting);
        }        
    }
}
