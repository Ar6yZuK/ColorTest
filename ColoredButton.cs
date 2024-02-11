using Godot;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;

public partial class ColoredButton : Button
{
	private ColorHelper _colorFactor;
	private static readonly ImmutableArray<string> _colorTypes = Enum.GetNames<ColorType>().Select(x => x.ToLower()).ToImmutableArray();
	private readonly Dictionary<string, ColorType> _cache = new();

	public override void _Ready()
	{
		_colorFactor = this.GetColorHelper();
	}

	public void ChangeMainColor(Color color)
	{
		for (int i = 0; i < _colorTypes.Length; i++)
			ChangeColor(color, _colorTypes[i]);

		void ChangeColor(Color color, string colorType)
		{
			if ((StyleBox)Get($"theme_override_styles/{colorType}") is not StyleBoxFlat styleBoxFlat)
				return;

			if (!_cache.TryGetValue(colorType, out var colorTypeEnum))
				if (Enum.TryParse(colorType, true, out colorTypeEnum))
					_cache.Add(colorType, colorTypeEnum);
				else
					throw new InvalidEnumArgumentException($"{nameof(colorType)} was not {nameof(ColorType)}");

			styleBoxFlat.BgColor = _colorFactor.ChangeColor(color, colorTypeEnum);
		}
	}
}
