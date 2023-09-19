using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;
using TechnicalTest.Core.Services;

namespace TechnicalTest.Core.Factories
{
    public class ShapeFactory : IShapeFactory
    {
	    private readonly IShapeService _shapeService;

        public ShapeFactory(IShapeService shapeService)
        {
	        _shapeService = shapeService;
        }

        public Shape? CalculateCoordinates(ShapeEnum shapeEnum, Grid grid, GridValue gridValue)
        {
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:
                    // TODO: Return shape returned from service.
                    Shape shape = _shapeService.ProcessTriangle(grid, gridValue);
                    
	                return shape;
                default:
                    return null;
            }
        }

        public GridValue? CalculateGridValue(ShapeEnum shapeEnum, Grid grid, Shape shape)
        {
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:
                    if (shape.Coordinates.Count != 3)
                        return null;

                    // TODO: Return grid value returned from service.
                    Triangle triangle = new (shape.Coordinates[0], shape.Coordinates[1], shape.Coordinates[2]);
                    var triangleValues = _shapeService.ProcessGridValueFromTriangularShape(grid, triangle);

                    GridValue calculateGridValueResults = new (triangleValues.Row + triangleValues.Column);
                
                    return calculateGridValueResults;
                default:
                    return null;
            }
        }
    }
}
