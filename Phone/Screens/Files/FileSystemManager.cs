using Godot;
using System;
using System.Collections.Generic;

public partial class FileSystemManager : PanelContainer
{
	[Export] private Control root;
	[Export] private Control pagesRoot;

	[Export] private Control docViewer;
	[Export] private Control docViewerContent;

	private Control currentFolder;
	private Stack<Control> navStack = new();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentFolder = root;
	}

	public void UpdateNav(Control c)
	{
		navStack.Push(currentFolder);

		currentFolder = c;
		foreach (Control child in pagesRoot.GetChildren())
		{
			child.Visible = false;
		}

		c.Visible = true;
	}

	public void BackNav()
	{
		if (navStack.Count <= 0) return;
		
		Control c = navStack.Pop();
		
		currentFolder = c;
		foreach (Control child in pagesRoot.GetChildren())
		{
			child.Visible = false;
		}

		c.Visible = true;
	}

	public void OpenDocument(Control c)
	{
		foreach (var child in docViewerContent.GetChildren())
		{
			child.QueueFree();
		}
		docViewerContent.AddChild(c);

		docViewer.Visible = true;
	}

	public void CloseViewer()
	{
		docViewer.Visible = false;
	}
}
