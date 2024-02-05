namespace Opdracht_3.Models;

public class indexModel
{
    public List<object> ShapeList = new List<object>();
    public indexModel() {
        ShapeList.Add(new SquareShape(60, 80 , System.Drawing.Color.AliceBlue));
        ShapeList.Add(new SquareShape(55, 120 , System.Drawing.Color.Green));
        ShapeList.Add(new SquareShape(35, 35 , System.Drawing.Color.Chocolate));
        ShapeList.Add(new CircleShape(75, 75, System.Drawing.Color.Goldenrod));
        ShapeList.Add(new CircleShape(60, 35, System.Drawing.Color.DarkGreen));
        ShapeList.Add(new TriangleShape(85, 85 , System.Drawing.Color.Lavender));
        ShapeList.Add(new TriangleShape(125, 85 , System.Drawing.Color.MidnightBlue));
    }
}
public class ScreenShape {
    public int width { get; set; }
    public int height { get; set; }
    public System.Drawing.Color color { get; set; }
}

public class SquareShape : ScreenShape {
    public SquareShape(int pWidth, int pHeight, System.Drawing.Color pColor) {
        base.width = pWidth;
        base.height = pHeight;
        base.color = pColor;
    }
}
public class CircleShape : ScreenShape {
    public CircleShape(int pWidth, int pHeight, System.Drawing.Color pColor) {
        base.width = pWidth;
        base.height = pHeight;
        base.color = pColor;
    }
}
public class TriangleShape : ScreenShape {
    public TriangleShape(int pWidth, int pHeight, System.Drawing.Color pColor) {
        base.width = pWidth;
        base.height = pHeight;
        base.color = pColor;
    }
}