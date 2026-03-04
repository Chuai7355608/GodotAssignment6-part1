using Godot;
using System;

public partial class Scene : Node3D
{
	[Export]
	public Button undo;
	
	public void OnUndoPressed()
	{
        CommandHandler.Instance.undoCommand();
	}
}
