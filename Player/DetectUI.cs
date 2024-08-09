using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetectUI : MonoBehaviour {
    public static DetectUI instance;
    [SerializeField] private GameObject _pan1UI;
    [SerializeField] private GameObject _pan2UI;
    [SerializeField] private GameObject _storageUI;
    [SerializeField] private GameObject _storeUI;
    [SerializeField] private GameObject _burgerUI;
    [SerializeField] private GameObject _postUI;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask _UILayer;
    public bool _UIFlag = false;
    private Vector2 _rayDir;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _rayDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        ControlUI();
    }

    private void ControlUI()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, _rayDir, rayDistance, _UILayer);
        if (ray != false && ray.collider.gameObject.layer == 3 && Input.GetKeyDown(KeyCode.Space) && !_UIFlag)
        {
            _UIFlag = true;
            _pan1UI.gameObject.SetActive(true);
        }
        if (ray != false && ray.collider.gameObject.layer == 6 && Input.GetKeyDown(KeyCode.Space) && !_UIFlag)
        {
            _UIFlag = true;
            _storageUI.gameObject.SetActive(true);
        }
        if (ray != false && ray.collider.gameObject.layer == 8 && Input.GetKeyDown(KeyCode.Space) && !_UIFlag)
        {
            _UIFlag = true;
            _storeUI.gameObject.SetActive(true);
        }
        if (ray != false && ray.collider.gameObject.layer == 9 && Input.GetKeyDown(KeyCode.Space) && !_UIFlag)
        {
            _UIFlag = true;
            _burgerUI.gameObject.SetActive(true);
        }
        if (ray != false && ray.collider.gameObject.layer == 10 && Input.GetKeyDown(KeyCode.Space) && !_UIFlag)
        {
            _UIFlag = true;
            _pan2UI.gameObject.SetActive(true);
        }
        if (ray != false && ray.collider.gameObject.layer == 11 && Input.GetKeyDown(KeyCode.Space) && !_UIFlag)
        {
            _UIFlag = true;
            _postUI.gameObject.SetActive(true);
        }
        if (ray != false && ray.collider.gameObject.layer == 12 && Input.GetKeyDown(KeyCode.Space)&&DebtManager.instance._currentDebt<=CookManager.instance._money.Value)
        {
            CookManager.instance._money.Value -=DebtManager.instance._currentDebt;
            CookManager.instance.ChangeStage();
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(_rayDir.x,_rayDir.y,0 * rayDistance));
    }
#endif
}
