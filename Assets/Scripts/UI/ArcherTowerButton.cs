using UnityEngine;

public class ArcherTowerButton : MonoBehaviour
{
    [SerializeField] private GameObject _archerTowerPrefab;

    public void OnClick()
    {
        GameObject gameObject = Instantiate(_archerTowerPrefab, Vector3.zero, Quaternion.identity);
    }
}
