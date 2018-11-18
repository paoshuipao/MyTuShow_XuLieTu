using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CUListData {

    public CUListDragSource DragSource { get; set; }
    public CUListDropTarget DropTarget { get; set; }
    public CUListContextMenuListener ContextMenuHandler { get; set; }
    public CUListKeyListener KeyListener { get; set; }
    public CUListExecutionListener ExecutionListener { get; set; }
    public bool MultiSelection { get; private set; }

    public Vector2 scrollPosition = Vector2.zero;

	private readonly HashSet<int> selection = new HashSet<int>();
	private List<int> selectionList = new List<int>(0);
	private bool changed = false;
    private int pivot = -1;

    public CUListData() : this(false) {
	}
	
	public CUListData(bool multiSelection) {
		this.MultiSelection = multiSelection;
	}
	
	public bool this[int index] {
		get {
			return selection.Contains(index);
		}
		set {
			changed = true;
			if (value) {
				if (!MultiSelection) {
					ClearSelection();
				}
				if (Empty) {
					pivot = index;
				}
				selection.Add(index);
			} else {
				selection.Remove(index);
				if (pivot == index) {
					pivot = First;
				}
				if (Empty) {
					pivot = -1;
				}
			}
		}
	}
	
	public bool IsDragSupported {
		get { return DragSource != null; }
	}

    public bool IsDropSupported {
		get { return DropTarget != null; }
	}

    public bool IsContextMenuSupported {
		get { return ContextMenuHandler != null; }
	}

    public bool IsKeyInputSupported {
		get { return KeyListener != null; }
	}

    public bool IsExecutionSupported {
		get { return ExecutionListener != null; }
	}

    public int Pivot {
		get { return pivot; }	
	}
	
	public bool Empty {
		get { return selection.Count == 0; }
	}
	
	public int First {
		get { return Empty ? -1 : Selection[0]; }
	}
	
	public int Last {
		get { return Empty ? -1 : Selection[Selection.Count - 1]; }
	}
	
	public List<int> Selection {
		get {
			if (changed) {
				selectionList = selection.ToList();
				selectionList.Sort();
				changed = false;
			}
			return selectionList;
		}
	}
	
	public IList<T> GetSelectedItems<T>(IList<T> items) {
		IList<T> result = new List<T>();
		if (Empty) {
			return result; 
		}
		
		foreach(int index in Selection) {
			result.Add(items[index]);
		}
		
		return result;
	}
	
	public void SetSelectedItems<T>(IList<T> items, IList<T> itemsToSelect) {
		ClearSelection();
		foreach(T item in itemsToSelect) {
			this[items.IndexOf(item)] = true;
		}
	}
	
	public void SetSelectedItem<T>(IList<T> items, T itemToSelect) {
		ClearSelection();
		this[items.IndexOf(itemToSelect)] = true;
	}
	
	public void ClearSelection() {
		changed = true;
		pivot = -1;
		selection.Clear();
	}



}

