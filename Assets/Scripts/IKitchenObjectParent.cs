using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    // 키친오브젝트(토마토, 치즈... 등)은 카운터나 플레이어의 자식으로서 존재할 수 있기 때문에
    // 카운터, 플레이어 등은 IKitchenObjectParent를 상속 받아 공유 속성을 유지함

    public Transform GetKitchenObjectFollowTransform();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();   
}
