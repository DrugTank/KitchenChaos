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
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {   // ����ִ°� Plate�� ��, Plate�� KitchenObject�� ��ӹޱ⿡ ������
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }

                else
                {   // �÷��̾ Plate�� �ƴ� �ٸ��� ����ִٸ�
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }

                }
            }

            else
            {   // �÷��̾ ������ ���ٸ�
                GetKitchenObject().SetKitchenObjectParent(player);
            }

        }
    }
}
