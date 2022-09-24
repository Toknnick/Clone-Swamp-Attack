using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _bar;

    public void ChangeHealth(int value, int maxValue)
    {
        _bar.value = (float)value / maxValue;
    }
}
