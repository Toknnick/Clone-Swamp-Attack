using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButton;

    public void OnButtonClicked()
    {
        _spawner.NextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _spawner.OnAllSpawned += AllSpawned;
        _nextWaveButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _spawner.OnAllSpawned -= AllSpawned;
        _nextWaveButton.onClick.RemoveListener(OnButtonClicked);
    }

    private void AllSpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }
}
