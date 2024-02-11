using Godot;
using System;
using System.Collections.Generic;

public partial class ColorHelper : Node
{
	[Export(PropertyHint.Range, "-1, 1")] float Normal { get; set; }
	[Export(PropertyHint.Range, "-1, 1")] float Hover { get; set; }
	[Export(PropertyHint.Range, "-1, 1")] float Pressed { get; set; }
	[Export(PropertyHint.Range, "-1, 1")] float Disabled { get; set; }
	[Export(PropertyHint.Range, "-1, 1")] float Focus { get; set; }

	public float ToFactor(ColorType colorType)
		=> colorType switch
		{
			ColorType.Normal => Normal,
			ColorType.Hover => Hover,
			ColorType.Pressed => Pressed,
			ColorType.Disabled => Disabled,
			ColorType.Focus => Focus,
			_ => throw new NotImplementedException(),
		};
	public Color ChangeColor(Color color, ColorType colorType)
	{
		float factor = ToFactor(colorType);
		return ChangeColor(color, factor);
	}
	public static Color ChangeColor(Color color, float factor)
	{
		var newColor = color;

		float correctionFactor = factor;
		if (correctionFactor < 0)
		{
			correctionFactor++;

			newColor *= correctionFactor;
		}
		else
		{
			newColor = (Colors.Black - newColor) * correctionFactor + newColor;
		}

		return newColor;
	}
}