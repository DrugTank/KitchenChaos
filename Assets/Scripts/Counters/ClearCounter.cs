using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {   // Űģ ������Ʈ ���� ��

            if (player.HasKitchenObject()) 
            {   // �÷��̾ ��� �ִٸ� ����
                player.GetKitchenObject().SetKitchenObjectParent(this); 
            }

            else
            {   // �÷��̾ ��� ���� �ʴٸ�
                            
            }
        }

        else
        { // Űģ ������Ʈ�� �̹� ���� ���� ��

            if (player.HasKitchenObject())
            {   // �÷��̾ ��� �ִٸ�

            }

            else
            {   // �÷��̾ ������ ���ٸ�
                GetKitchenObject().SetKitchenObjectParent(player);
            }

        }
    }
}
