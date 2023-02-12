using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {   // 키친 오브젝트 없을 때

            if (player.HasKitchenObject()) 
            {   // 플레이어가 들고 있다면 세팅
                player.GetKitchenObject().SetKitchenObjectParent(this); 
            }

            else
            {   // 플레이어가 들고 있지 않다면
                            
            }
        }

        else
        { // 키친 오브젝트를 이미 갖고 있을 때

            if (player.HasKitchenObject())
            {   // 플레이어가 들고 있다면

            }

            else
            {   // 플레이어가 가진게 없다면
                GetKitchenObject().SetKitchenObjectParent(player);
            }

        }
    }
}
