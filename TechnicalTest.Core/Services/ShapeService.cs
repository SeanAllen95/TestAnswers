using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class ShapeService : IShapeService
    {
        public Shape ProcessTriangle(Grid grid, GridValue gridValue)
        {
            // TODO: Calculate the coordinates.
            // All the coordinates can be calculated from v3Y and v2Y

            int v3Y = gridValue.GetNumericRow() * grid.Size;
            int v3X;
            int v2Y = v3Y - grid.Size;
            int v2X;
            int v1X;
            int v1Y;

            if (gridValue.Column % 2 == 0) {
                // If the gridValue.column is even these calculations are performed
                v3X = (gridValue.Column / 2) * grid.Size;
                v2X = v3X - grid.Size;
                v1X = v2X + grid.Size;
                v1Y = v3Y - grid.Size;
            } else {
                // If the gridValue.column is odd these calculations are performed
                v3X = ((gridValue.Column + 1) / 2) * grid.Size;
                v2X = v3X - grid.Size;
                v1X = v2X;
                v1Y = v3Y;
            }

            return new Shape(new List<Coordinate>
            {
                new(v2X, v2Y),
                new(v1X, v1Y),
                new(v3X, v3Y)
            });
        }

        public GridValue ProcessGridValueFromTriangularShape(Grid grid, Triangle triangle)
        {
            // TODO: Calculate the grid value.
            // The row is found by dividing the Y coordinate of the bottom right vertex by the grid size
            int row = (triangle.BottomRightVertex.Y / grid.Size);
            // The column is found depending on if it is an even or odd triangle
            // If it is even then OuterVertex.X will be the same as BottomRightVertex.X and the first calculation will be perfomed, if they are not the same the second calculation will be performed
            int column;

            if (triangle.OuterVertex.X == triangle.BottomRightVertex.X) {
                column = (triangle.OuterVertex.X / grid.Size) * 2;
            } else {
                column = (triangle.BottomRightVertex.X + triangle.TopLeftVertex.X) / grid.Size;
            }

            GridValue gridValueResults = new (row, column);

            return gridValueResults;
        }
    }
}