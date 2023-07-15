using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _points;
    [SerializeField] private GameObject _template;
    [SerializeField] private int _numberOfTemplates;

    private System.Random random = new System.Random();
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
            yield return new WaitForSeconds(secondsWaiting);

            Instantiate(_templates[i], _points[random.Next(_points.Count)].transform.position, Quaternion.identity);
        }
    }
}
