using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    //[SerializeField] private KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // Нету объекта на столе
            if (player.HasKitchenObject())
            {
                //У игрока в руке есть объект 
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // У игрока в руке нету объекта
            }
        }
        else
        {
            // объект лежит на столе
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // в руках тарелка и добавляем в нее ингридиенты
                    if (plateKitchenObject.TryAddIngridient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    // Добавляем на стоячую тарелку ингридиенты
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        if (plateKitchenObject.TryAddIngridient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
                //У игрока в руке есть объект и на столе тоже лежит объект
            }
            else
            {
                // У игрока нет ничего в руке и на столе лежит объект, то мы его берем в руки
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
