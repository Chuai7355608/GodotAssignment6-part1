using Godot;
using System;

public partial class Sqare : Area3D
{
	[Export]
	public MeshInstance3D target;

	 private bool _isMouseHovered = false;

    public override void _Ready()
    {
        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
		target.Visible=false;
    }

    private void OnMouseEntered()
    {
        _isMouseHovered = true;
    }

    private void OnMouseExited()
    {
        _isMouseHovered = false;
    }


    public override void _Process(double delta)
    {
        if (!_isMouseHovered) return;

        if (Input.IsMouseButtonPressed(MouseButton.Left))
        {
            if (Input.IsActionJustPressed("left_click"))
            {
                var showCommand = new AreaCommand(target, true);
                CommandHandler.Instance.runCommand(showCommand);
            }
        }

        if (Input.IsMouseButtonPressed(MouseButton.Right))
        {
            if (Input.IsActionJustPressed("right_click"))
            {
                var hideCommand = new AreaCommand(target, false);
                CommandHandler.Instance.runCommand(hideCommand);
            }
        }
    }
	
	// public override void _Ready()
	// {
	// 	Visible = false;
	// 	this.InputRayPickable = true;

	// }

	// public void OnMouseEntered()
	// {
	// 	if(Input.IsActionJustPressed("left_click"))
	// 	{
	// 		var show = new AreaCommand(this, true);
	// 		CommandHandler.Instance.runCommand(show);	
	// 	}
	// 	if(Input.IsActionJustPressed("right_click"))
	// 	{
	// 		var hide = new AreaCommand(this,false);
	// 		CommandHandler.Instance.runCommand(hide);
	// 	}
	// 	GD.Print("has entered");
	// }

	
	// public override void _Process(double delta)
	// {
	// }



	
}

public class AreaCommand : ICommand
{
	public MeshInstance3D _targetMesh;
	public bool _targetVisible;
	public bool _originalVisible;

	public AreaCommand(MeshInstance3D targetMesh, bool targetVisible)
	{
		_targetMesh = targetMesh;
		_targetVisible = targetVisible;
		_originalVisible = _targetMesh.Visible;
	}

	public void Execute()
	{
		_targetMesh.Visible = _targetVisible;
	}

	public void Undo()
	{
		_targetMesh.Visible = _originalVisible;
	}
}
