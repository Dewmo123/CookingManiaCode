using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectPlayer : MonoBehaviour
{//플레이어가 손님이랑 상호작용 했을때 인벤토리꺼랑 랜덤오더랑 비교해서 하면 되겠다
     private Vector2 _rayDistance = new Vector2(2,2);
    [SerializeField] private Transform _detectPlayerTrm;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Image _inven1;
    [SerializeField] private Image _inven2;
    private AudioSource _success;
    private void Awake()
    {
        _success = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Collider2D detectPc = Physics2D.OverlapBox(_detectPlayerTrm.position, _rayDistance, 0, _playerLayer);
        Customer customerCompo = gameObject.GetComponent<Customer>();
        ChosenInven inven1Compo = _inven1.GetComponent<ChosenInven>();
        ChosenInven inven2Compo = _inven2.GetComponent<ChosenInven>();
        if (detectPc && Input.GetKeyDown(KeyCode.Space)&& customerCompo._orderItem2!=null&&customerCompo._orderItem1!=null)
        {
            if(inven1Compo._chosenItem== customerCompo._orderItem1|| inven1Compo._chosenItem == customerCompo._orderItem2)
            {
                if (inven2Compo._chosenItem == customerCompo._orderItem1 || inven2Compo._chosenItem == customerCompo._orderItem2)
                {
                    _success.Play();
                    CookManager.instance._money.Value += (int)((inven1Compo._chosenItem.SellPrice + inven2Compo._chosenItem.SellPrice) * CookManager.instance._orderMultiply);
                    CookManager.instance._combo.Value += 1;
                    inven1Compo._chosenItem = null;
                    inven2Compo._chosenItem = null;
                    inven1Compo.SetActiveUI(false);
                    inven2Compo.SetActiveUI(false);
                    customerCompo.SetNull();
                }
            }
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_detectPlayerTrm.position, _rayDistance);
        Gizmos.color = Color.white;
    }
#endif
}
