using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    // Űģ������Ʈ(�丶��, ġ��... ��)�� ī���ͳ� �÷��̾��� �ڽ����μ� ������ �� �ֱ� ������
    // ī����, �÷��̾� ���� IKitchenObjectParent�� ��� �޾� ���� �Ӽ��� ������

    public Transform GetKitchenObjectFollowTransform();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();   
}
