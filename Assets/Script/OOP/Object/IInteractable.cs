using UnityEngine;
using TMPro;
public interface IInteractable
{
    // �س���ѵ�����Ѻ�����ѵ��
    string InteractionText { get; }
    // ���ʹ����ͧ�������ͧ�Ѻ�����ͺ
    void Interact(Player player);

}
