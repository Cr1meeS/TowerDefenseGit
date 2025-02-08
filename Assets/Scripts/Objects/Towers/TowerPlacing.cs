using UnityEngine;

public class TowerPlacing : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _towerPlaceLayerMask;

    [SerializeField] private Material _cantPlaceMaterial;
    [SerializeField] private Material _canPlaceMaterial;
    [SerializeField] private Material _defaultMaterial;

    [SerializeField] GameObject _gameObject;

    private MeshRenderer _meshRender;
    private InputActions _inputActions;
    private bool _placed = false;

    private void Start()
    {
        _meshRender = _gameObject.GetComponent<MeshRenderer>();
        _inputActions.Game.MouseLeftClick.performed += ctx => Click();
    }

    private void OnEnable()
    {
        _inputActions = new InputActions();
        _inputActions.Enable();
    }

    private void Update()
    {
        if (_placed == true)
        {
            enabled = false;
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _groundLayerMask))
            {
                transform.position = raycastHit.point;
                _meshRender.material = _cantPlaceMaterial;
            }
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _towerPlaceLayerMask))
            {
                if (hit.transform.childCount == 0 || hit.transform.GetChild(0) == _gameObject.transform) 
                {
                    transform.SetParent(hit.transform);
                    transform.localPosition = new Vector3(0f, 1.2f, 0f);
                    _meshRender.material = _canPlaceMaterial;
                } 
            }
        }
    }

    private void Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHitGround, Mathf.Infinity, _groundLayerMask))
        {
            if (Physics.Raycast(ray, out RaycastHit raycastHitTowerPlace, Mathf.Infinity, _towerPlaceLayerMask))
            {
                if (raycastHitTowerPlace.transform.childCount == 0 || raycastHitTowerPlace.transform.GetChild(0) == _gameObject.transform)
                {
                    transform.SetParent(raycastHitTowerPlace.transform);
                    transform.localPosition = new Vector3(0f, 1.2f, 0f);
                    _meshRender.material = _defaultMaterial;
                    _placed = true;
                    transform.GetComponent<Tower>().enabled = true;
                }
                else Destroy(_gameObject);
            }
            else Destroy(_gameObject);
        }
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}
