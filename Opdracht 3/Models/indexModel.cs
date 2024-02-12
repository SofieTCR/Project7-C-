namespace Opdracht_3.Models;

public class indexModel
{
    public List<ScreenShape> ShapeList = new List<ScreenShape>();
    public indexModel() {
        ShapeList.Add(new SquareShape(60, 80 , System.Drawing.Color.SandyBrown));
        ShapeList.Add(new SquareShape(55, 120 , System.Drawing.Color.Green));
        ShapeList.Add(new SquareShape(35, 35 , System.Drawing.Color.Chocolate));
        ShapeList.Add(new EllipseShape(75, 75, System.Drawing.Color.Goldenrod));
        ShapeList.Add(new EllipseShape(60, 35, System.Drawing.Color.DarkGreen));
        ShapeList.Add(new TriangleShape(85, 85 , System.Drawing.Color.Lavender));
        ShapeList.Add(new TriangleShape(125, 85 , System.Drawing.Color.MidnightBlue));
    }
}
public abstract class ScreenShape
{
    public int width { get; protected set; }
    public int height { get; protected set; }
    public System.Drawing.Color color { get; protected set; }

    public string getColor() {
        return $"rgb({color.R}, {color.G}, {color.B})";
    }
    public abstract string draw();
}

public class SquareShape : ScreenShape
{
    public SquareShape(int pWidth, int pHeight, System.Drawing.Color pColor) {
        width = pWidth;
        height = pHeight;
        color = pColor;
    }

    public override string draw() {
        return $@"<svg width=""{width}"" height=""{height}"" xmlns=""http://www.w3.org/2000/svg"">
                      <rect width=""{width * .95}"" height=""{height * .95}"" style=""fill:{getColor()}""/>
                  </svg>";
    }
}
public class EllipseShape : ScreenShape
{
    public EllipseShape(int pWidth, int pHeight, System.Drawing.Color pColor) {
        width = pWidth;
        height = pHeight;
        color = pColor;
    }
    public override string draw() {
        return $@"<svg width=""{width}"" height=""{height}"" xmlns=""http://www.w3.org/2000/svg"">
                      <ellipse rx=""{width *.5 * .95}"" ry=""{height *.5 * .95}"" cx=""{width * .5}"" cy=""{height * .5}"" style=""fill:{getColor()}""/>
                  </svg>";
    }
}
public class TriangleShape : ScreenShape
{
    public TriangleShape(int pWidth, int pHeight, System.Drawing.Color pColor) {
        width = pWidth;
        height = pHeight;
        color = pColor;
    }
    public override string draw() {
        return $@"<svg width=""{width}"" height=""{height}"" xmlns=""http://www.w3.org/2000/svg"">
                      <polygon points=""{width/2}, {height - height * .95}
                                        {width - width * .95}, {height * .95}
                                        {width * .95}, {height * .95}
                            "" style=""fill:{getColor()}""/>
                  </svg>";
    }
}