using System.Collections.Generic;
using UnityEditor;

/// <summary>
/// Implementation of the DropTarget interface for the scene list
/// </summary>
public class SMSceneListDropTarget : CUListDropTarget {
	
	private DropDelegate dropHandler;
	
	public SMSceneListDropTarget(DropDelegate dropHandler) {
		this.dropHandler = dropHandler;
	}
		
	public bool CanDrop (int index, EnumDropType dropType) {
		if (dropType == EnumDropType.IntoContainer && SMLevelListDragSource.IsSender) {
			DragAndDrop.visualMode = DragAndDropVisualMode.Link;
			return true;
		}
		return false;
	}
	
	public void AcceptDrop(int index, EnumDropType dropType) {
		if (CanDrop(index, dropType)) {
			dropHandler(SMLevelListDragSource.DragData);
			DragAndDrop.AcceptDrag();
		}
	}
	
	public delegate void DropDelegate(IList<int> levelIndices);
	
}

