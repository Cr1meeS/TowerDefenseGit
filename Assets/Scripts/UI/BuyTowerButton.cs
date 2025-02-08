using UnityEngine;

public class BuyTowerButton : MonoBehaviour
{
    [SerializeField] private GameObject _towerPrefab;

    public void OnClick()
    {
        GameObject gameObject = Instantiate(_towerPrefab, Vector3.zero, Quaternion.identity);
    }
}
