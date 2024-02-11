using Godot;

[Tool]
public partial class ColorText : ColorRect
{
	private ColorType _colorType;
	private Label _label;
	private ColorHelper _colorHelper;

	public override void _Ready()
	{
		_label = GetNode<Label>("Label");
		_label.Text = ColorType.ToString();
		_colorHelper = this.GetColorHelper();

		ChangeColor(GetNode<ColorPickerButton>("/root/Node2D/ColorPickerButton").Color);
	}

	private void ChangeColor(Color color)
		=> Color = _colorHelper.ChangeColor(color, ColorType);

	[Export] ColorType ColorType
	{
		get => _colorType;
		set
		{
			_colorType = value;
			if(_label is not null)
				_label.Text = value.ToString();
		}
	}
}
