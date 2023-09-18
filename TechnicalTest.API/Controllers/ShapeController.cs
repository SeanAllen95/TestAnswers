﻿using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TechnicalTest.API.DTOs;
using TechnicalTest.Core;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.API.Controllers
{
    /// <summary>
    /// Shape Controller which is responsible for calculating coordinates and grid value.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ShapeController : ControllerBase
    {
        private readonly IShapeFactory _shapeFactory;

        /// <summary>
        /// Constructor of the Shape Controller.
        /// </summary>
        /// <param name="shapeFactory"></param>
        public ShapeController(IShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }

        /// <summary>
        /// Calculates the Coordinates of a shape given the Grid Value.
        /// </summary>
        /// <param name="calculateCoordinatesRequest"></param>   
        /// <returns>A Coordinates response with a list of coordinates.</returns>
        /// <response code="200">Returns the Coordinates response model.</response>
        /// <response code="400">If an error occurred while calculating the Coordinates.</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Shape))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateCoordinates")]
        [HttpPost]
        public IActionResult CalculateCoordinates([FromBody]CalculateCoordinatesDTO calculateCoordinatesRequest)
        {
            // TODO: Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.
            // TODO: Call the Calculate function in the shape factory.
            // TODO: Return BadRequest with error message if the calculate result is null
            // TODO: Create ResponseModel with Coordinates and return as OK with responseModel.


            if (calculateCoordinatesRequest.ShapeType != 1) {
                return BadRequest("This is not a triangle!");
            }

            Grid grid = new (calculateCoordinatesRequest.Grid.Size);
            GridValue gridValue = new (calculateCoordinatesRequest.GridValue);
            ShapeEnum shapeEnum = ShapeEnum.Triangle;
            var results = _shapeFactory.CalculateCoordinates(shapeEnum, grid, gridValue);

            if (results == null){
                return BadRequest("Results are null!");
            }
            
            return Ok(results);
        }

        /// <summary>
        /// Calculates the Grid Value of a shape given the Coordinates.
        /// </summary>
        /// <remarks>
        /// A Triangle Shape must have 3 vertices, in this order: Top Left Vertex, Outer Vertex, Bottom Right Vertex.
        /// </remarks>
        /// <param name="gridValueRequest"></param>   
        /// <returns>A Grid Value response with a Row and a Column.</returns>
        /// <response code="200">Returns the Grid Value response model.</response>
        /// <response code="400">If an error occurred while calculating the Grid Value.</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GridValue))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateGridValue")]
        [HttpPost]
        public IActionResult CalculateGridValue([FromBody]CalculateGridValueDTO gridValueRequest)
        {
	        // TODO: Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.
            // TODO: Create new Shape with coordinates based on the parameters from the DTO.
            // TODO: Call the function in the shape factory to calculate grid value.
            // TODO: If the GridValue result is null then return BadRequest with an error message.
            // TODO: Generate a ResponseModel based on the result and return it in Ok();

            if (gridValueRequest.ShapeType != 1) {
                return BadRequest("This is not a triangle!");
            }

            Grid grid = new (gridValueRequest.Grid.Size);
            Coordinate coordinate1 = new (gridValueRequest.Vertices[0].x, gridValueRequest.Vertices[0].y);
            Coordinate coordinate2 = new (gridValueRequest.Vertices[1].x, gridValueRequest.Vertices[1].y);
            Coordinate coordinate3 = new (gridValueRequest.Vertices[2].x, gridValueRequest.Vertices[2].y);
            Shape shape = new (new List<Coordinate> { coordinate1, coordinate2, coordinate3 });
            ShapeEnum shapeEnum = ShapeEnum.Triangle;

            var results = _shapeFactory.CalculateGridValue(shapeEnum, grid, shape);

            if (results == null){
                return BadRequest("Results are null!");
            }

            return Ok(results);
        }
    }
}
