using Godot;

public static class NodeExtensions
{
	public static ColorHelper GetColorHelper(this Node node)
		=> node.GetNode<ColorHelper>("/root/Node2D/ColorTypeToCorrectionFactor");
}