using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Canvas _canvas;


    private void OnEnable()
    {
        _enemy.GetComponent<Enemy>().OnHealthChangedEvent += ChangeCurrentHealth;
    }

    private void Start()
    {
        _slider.maxValue = _enemy.GetComponent<Enemy>().Health;
        _slider.value = _enemy.GetComponent<Enemy>().Health;

    }

    private void ChangeCurrentHealth(float currentHealth)
    {
        _slider.value = currentHealth;
    }

    private void LateUpdate()
    {
        _canvas.transform.LookAt(_canvas.transform.position + Camera.main.transform.forward);
    }

    private void OnDisable()
    {
        _enemy.GetComponent<Enemy>().OnHealthChangedEvent -= ChangeCurrentHealth;
    }
}
