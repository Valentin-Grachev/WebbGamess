using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayoutGroup : LayoutGroup
{
    public enum FitType
    {
        Uniform, Width, Height, FixedRows, FixedColumns
    }



    public int rows;
    public int columns;
    public Vector2 cellSize;
    public Vector2 spacing;
    public FitType fitType;

    public bool fitX;
    public bool fitY;


    public override void CalculateLayoutInputVertical()
    {

        if (fitType == FitType.Uniform || fitType == FitType.Width || fitType == FitType.Height)
        {
            fitX = true;
            fitY = true;

            float sqrRt = Mathf.Sqrt(transform.childCount);
            rows = Mathf.CeilToInt(sqrRt);
            columns = Mathf.CeilToInt(sqrRt);
        }

        switch (fitType)
        {
            case FitType.Uniform:
                break;

            case FitType.Width: case FitType.FixedColumns:
                rows = Mathf.CeilToInt(transform.childCount / (float)columns);
                break;
            case FitType.Height: case FitType.FixedRows:
                columns = Mathf.CeilToInt(transform.childCount / (float)rows);
                break;
        }



        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = (parentWidth / (float)columns) - ((spacing.x / (float)columns) * 2)
            - (padding.left + padding.right) / columns;
        float cellHeight = (parentHeight / (float)rows) - ((spacing.y / rows) * 2)
            - (padding.top + padding.bottom) / rows;

        cellSize.x = fitX ? cellWidth : cellSize.x;
        cellSize.y = fitY ? cellHeight : cellSize.y;

        int columnCount = 0;
        int rowCount = 0;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / columns;
            columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = cellSize.x * columnCount + spacing.x * columnCount + padding.left;
            var yPos = cellSize.y * rowCount + spacing.y * rowCount + padding.top;

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);

        }


    }

    public override void SetLayoutHorizontal()
    {
        
    }

    public override void SetLayoutVertical()
    {
        
    }
}
