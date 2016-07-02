using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Gestisce gli oggetti collezionabili al proprio interno
/// </summary>
namespace EH.FrameWork {
public class Inventory : MonoBehaviour {
	/* TODO :
	-Definizione di item
	-Lista di oggetti generici 
	-Aggiungere elementi alla lista 
	-Rimuovere elementi dalla lista
	-Usare elementi
	
	*/
	public List<ICollectableItem> Items = new List<ICollectableItem>();

	 /// <summary>
	/// aggiunge l'item alla lista
	 /// </summary>
	 /// <param name="itemToAdd">Item to add.</param>
	public void AddItem(ICollectableItem itemToAdd){
		Items.Add(itemToAdd);
		///casting = ItemToAdd è nell'interfaccia e non deriva da MonoBehaviour,il compilatore non sapendolo,foziamo ad utilizzarlo come MonoBehaviour.
		MonoBehaviour goItem = (MonoBehaviour)itemToAdd as MonoBehaviour;
		goItem.transform.position = this.transform.position;
		goItem.transform.SetParent (this.transform);
	}
	/// <summary>
	/// rimuove l'item dalla lista
	/// </summary>
	/// <param name="itemToRemove">Item to remove.</param>
	public void RemoveItem (ICollectableItem itemToRemove) {
		Items.Remove(itemToRemove);
	}
	
}

public interface ICollectableItem{

}

/*TODO
 *POSSIBILITà DI ESSERE UTLIZZATO 
*/
public interface IUsableItem{

	void UseItem();

}

public interface IThrowable : IUsableItem{

	void UseItem(Vector3 TargetPosition);

}
}