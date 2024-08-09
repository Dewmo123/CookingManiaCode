using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{//���� �ð� �Ŀ� �ֹ��� �� �ֹ��� �Ϸ�Ǹ� Ÿ�̸� ������ ���� �ð� �� �ٽ� �ֹ��� ��
    public List<Item> _orderItemList = new List<Item>();//�������� ����Ʈ �������� 2�� ���ؼ� �÷��̾ �� �����۰� ���ٸ� ����
    [HideInInspector] public Item _orderItem1, _orderItem2;
    [SerializeField] private GameObject _gage;
    [SerializeField] private GameObject _ui;
    public GameObject _order1;
    public GameObject _order2;
    private float _currentTime = 0;
    private float _orderTime;
    private bool _orderFlag = false;
    private IEnumerator _coroutine;
    private void Awake()
    {
        _orderTime = Random.Range(8f, 15f);
        _ui.SetActive(false);
    }
    private void Update()
    {
        if (!_orderFlag)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _orderTime)
            {
                _currentTime = 0;
                _orderTime = Random.Range(6f, 13f);
                _coroutine = Order();
                StartCoroutine(_coroutine);
            }
        }
    }
    private IEnumerator Order()
    {
        _ui.SetActive(true);
        _gage.GetComponent<CustomerGage>()._gageFlag = true;
        int order1Index = Random.Range(0, _orderItemList.Count);
        int order2Index = Random.Range(0, _orderItemList.Count);
        _orderItem1 = _orderItemList[order1Index];
        _orderItem2 = _orderItemList[order2Index];
        _order1.GetComponent<SpriteRenderer>().sprite = _orderItem1.ItemImage;
        _order2.GetComponent<SpriteRenderer>().sprite = _orderItem2.ItemImage;
        _orderFlag = true;
        yield return new WaitForSeconds(CookManager.instance._orderDelay);
        CookManager.instance._combo.Value = 0;
        SetNull();
    }


    public void SetNull()
    {
        StopCoroutine(_coroutine);
        _currentTime = 0;
        _orderTime = Random.Range(6f, 13f);
        _gage.GetComponent<CustomerGage>()._gageFlag = false;
        _ui.SetActive(false);
        _gage.gameObject.transform.localScale = new Vector3(1, _gage.gameObject.transform.localScale.y, _gage.gameObject.transform.localScale.z);
        _orderFlag = false;
        _orderItem1 = null;
        _orderItem2 = null;
        _order1.GetComponent<SpriteRenderer>().sprite = null;
        _order2.GetComponent<SpriteRenderer>().sprite = null;
    }
}
