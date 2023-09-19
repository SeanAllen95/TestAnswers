using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class ShapeService : IShapeService
    {
        public Shape ProcessTriangle(Grid grid, GridValue gridValue)
        {
            // TODO: Calculate the coordinates.

            int v3Y = gridValue.GetNumericRow() * grid.Size;
            int v3X;
            int v2Y = v3Y - grid.Size;
            int v2X;
            int v1X;
            int v1Y;

            if (gridValue.Column % 2 == 0) {
                v3X = (gridValue.Column / 2) * grid.Size;
                v2X = v3X - grid.Size;
                v1X = v2X + grid.Size;
                v1Y = v3Y - grid.Size;
            } else {
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
            int row = (triangle.BottomRightVertex.Y / grid.Size);
            int column = 0;

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