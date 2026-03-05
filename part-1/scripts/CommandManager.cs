using Godot;
using System;
using System.Collections.Generic;


//interface
public interface ICommand
{
	//place and clear
	void Execute();

	void Undo();
}



public class CommandHandler
{
	//a singleton
	private static CommandHandler _instance;
	public static CommandHandler Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = new CommandHandler();
			}
			return _instance;
		}
	}

	private Stack<ICommand> _undoStack = new Stack<ICommand>();

	public void runCommand(ICommand command)
	{
		command.Execute();
		_undoStack.Push(command);
	}

	public void undoCommand()
	{
		if(_undoStack.Count > 0)
		{
			var command = _undoStack.Pop();
			command.Undo();
		}
		else
		{
			GD.Print("nothing to undo");
		}
	}
}
