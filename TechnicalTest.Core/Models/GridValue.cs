﻿namespace TechnicalTest.Core.Models
{
    public class GridValue
    {
        public GridValue(string gridValue)
        {
            if (string.IsNullOrEmpty(gridValue)) return;
            //  || gridValue.Length != 2 this or statement removed so that grid values with two integers could be calculated

            Row = gridValue[..1];
            Column = int.Parse(gridValue[1..]);
        }


        public GridValue(int row, int column)
        {
            var numericValueOfCharacter = (char)64 + row;
            Row = ((char)numericValueOfCharacter).ToString();
            Column = column;
        }

        public string? Row { get; set; }

        public int Column { get; set; }

        public int GetNumericRow() => Row != null ? char.ToUpper(char.Parse(Row)) - 64 : 0;
    }
}
